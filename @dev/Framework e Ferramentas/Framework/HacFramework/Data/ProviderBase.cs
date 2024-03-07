using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Reflection;

namespace HospitalAnaCosta.Framework.Data
{
    /// <summary>
    /// Classe base para acesso ao banco de dados
    /// </summary>
    /// 
    [Serializable()]
    public abstract class ProviderBase : IProvider, IDisposable
    {
        #region atributos internos
        protected string connectionString;                   // string de conexao    
        protected DbConnection connection;                         // conexao com o banco de dados
        protected DbTransaction transaction;                        // transacao
        protected int commandTimeout = -1;                // tempo máximo para execução de um command 
        private string defaultTableName = "DADOS";
        private bool keepConnectionAlive = false;
        private ConnectionState StateConnection = ConnectionState.Closed;
        #endregion

        #region contrutor

        public ProviderBase()
        {
        }

        #endregion

        #region propriedades
        /// <summary>
        /// Permite que o componente manhenha a conexão aberta após executar algum procedimento no banco
        /// </summary>
        public bool KeepConnectionAlive
        {
            get { return keepConnectionAlive; }
            set { keepConnectionAlive = value; }
        }

        /// <summary>
        /// Nome padrão da tabela que será usado no retorno dos datasets
        /// </summary>
        public string DefaultTableName
        {
            get { return defaultTableName; }
            set { defaultTableName = value; }
        }


        #region IProvider Members

        /// <summary>
        /// String para conexão com o banco de dados
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return connectionString;
            }
            set
            {
                connectionString = value;
            }
        }

        /// <summary>
        /// Conexão com o banco de dados, por padrão a conexao é aberta (e fechada) quando algum método de banco é exegido
        /// </summary>
        public DbConnection Connection
        {
            get
            {
                return this.connection;
            }
            set
            {
                connection = value;
            }
        }

        /// <summary>
        /// Transação com o banco de dados. Por padrao os procedimentos não são executados sobre uma transação
        /// </summary>
        public DbTransaction Transaction
        {
            get
            {
                return this.transaction;
            }
            set
            {
                this.transaction = value;
            }
        }

        /// <summary>
        /// Define qual o tempo máximo para que o banco atenda a uma requisição. O valor padrão é -1 (sem limite)
        /// </summary>
        public int CommandTimeout
        {
            get
            {
                return this.commandTimeout;
            }
            set
            {
                this.commandTimeout = value;
            }
        }


        #endregion

        #endregion

        #region Destrutor
        ~ProviderBase()
        {
            CloseConnection();

            try
            {
                connection.Dispose();
            }
            catch { }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            try
            {
                this.connection.Dispose();
                this.transaction.Dispose();
            }
            catch { }

        }
        #endregion

        #region Metodos

        #region IProvider Members
        /// <summary>
        /// Abre uma conexão com o banco de dados. 
        /// </summary>
        /// <returns></returns>
        public DbConnection OpenConnection()
        {
            if (StateConnection != ConnectionState.Open)
            {
                this.connection.ConnectionString = this.connectionString;
                this.connection.Open();
                StateConnection = ConnectionState.Open;                
            }
            return this.connection;
        }

        /// <summary>
        /// Fecha a conexao o banco de dados
        /// <seealso cref="ProviderBase.OpenConnection"/>
        /// </summary>
        public void CloseConnection()
        {
            CloseConnection(!keepConnectionAlive);
        }

        /// <summary>
        /// Fecha a conexao com o banco de dados. 
        /// <seealso cref="ProviderBase.OpenConnection"/>
        /// <seealso cref="KeepConnectionAlive"/>
        /// </summary>
        /// <param name="force">caso verdadeiro ignora a propriedade KeepConnectionAlive </param>
        public void CloseConnection(bool force)
        {
            if (this.connection != null && force)
            {
                if (StateConnection != ConnectionState.Closed)
                {
                    try
                    {
                        this.connection.Close();
                        StateConnection = ConnectionState.Closed;
                    }
                    catch { }
                }
            }
        }

        /// <summary>
        /// Abre uma transação no banco de dados e caso
        /// </summary>
        /// <returns>Transação aberta com o banco de dados</returns>
        public DbTransaction BeginTransaction()
        {
            this.transaction = connection.BeginTransaction();
            return this.transaction;
        }

        /// <summary>
        /// Confirma as altereçaões feitas no banco de dados. Necessita que uma transação aberta no banco de dados
        /// <seealso cref="ProviderBase.BeginTransaction"/>
        /// <seealso cref="ProviderBase.RollBackTransaction"/>
        /// </summary>
        public void CommitTransaction()
        {
            this.transaction.Commit();
        }


        /// <summary>
        /// Reverte as alterações feitas no banco de dados . Necessita que uma trasação aberta no banco de dados 
        /// <seealso cref="ProviderBase.BeginTransaction"/>
        /// <seealso cref="ProviderBase.CommitTransaction"/>
        /// </summary>
        public void RollBackTransaction()
        {
            this.transaction.Rollback();
        }

        /// <summary>
        /// Cria uma coleacao vazia de parametros
        /// </summary>
        /// <returns></returns>
        public abstract DbParameterCollection CreateDataParameterCollection();

        /// <summary>
        /// Cria uma parametro para ser inserido no banco de dadoss
        /// </summary>
        /// <param name="name">nome do parametro</param>
        /// <param name="value">valor do mesmo</param>
        /// <returns></returns>
        public DbParameter CreateParameter(string name, object value)
        {
            return CreateParameter(name, value, ParameterDirection.Input);
        }
        /// <summary>
        /// Cria uma parametro para ser inserido no banco de dadoss
        /// </summary>
        /// <param name="name">nome do parametro</param>
        /// <param name="value">valor do mesmo</param>
        /// <param name="size">Tamanho do Parametro</param>
        /// <returns></returns>
        public DbParameter CreateParameter(string name, object value, int size)
        {
            return CreateParameter(name, value, ParameterDirection.Input, size);
        }
        /// <summary>
        /// Cria uma parametro para ser inserido no banco de dadoss
        /// </summary>
        /// <param name="name">nome do parametro</param>
        /// <param name="value">valor do mesmo</param>
        /// <param name="direction">Direcao do Parametro</param>
        /// <param name="size">Tamanho do Parametro</param>
        /// <returns></returns>
        public DbParameter CreateParameter(string name, object value, ParameterDirection direction, int size)
        {
            DbParameter param = CreateParameter(name, value, direction);
            param.Size = size;
            return param;
        }

        public DbParameter CreateParameter(string name, object value, ParameterDirection direction, System.Data.DbType dbType)
        {
            DbParameter param = CreateParameter(name, value, direction);
            param.DbType = dbType;            
            return param;
        }

        public DbParameter CreateParameter(string name, object value, ParameterDirection direction, System.Data.DbType dbType, int size)
        {
            DbParameter param = CreateParameter(name, value, direction, dbType);
            param.Size = size;
            return param;
        }


        /// <summary>
        /// Cria uma parametro para ser inserido no banco de dadoss
        /// </summary>
        /// <param name="name">nome do parametro</param>
        /// <param name="value">valor do mesmo</param>
        /// <param name="direction">direcao do parametro</param>
        /// <returns></returns>
        public abstract DbParameter CreateParameter(string name, object value, ParameterDirection direction);

        #endregion

        #region RecordSet
        /// <summary>
        /// Este metodo deve ser sobrecrito pela classe especialização, este método é chamado por todas outras sobrecargas
        /// </summary>
        /// <param name="command">comanda para execução no banco</param>
        /// <param name="tableName">nome do dataTable que ira ser adicionando ao dataset</param>
        /// <param name="dataSetReturn">referencia do dataset que ver será preenchido</param>
        /// <returns></returns>
        public abstract DataSet RecordSet(DbCommand command, string tableName, DataSet dataSetReturn);

        public abstract DataTable RecordSet(DbCommand command, DataTable dataTableReturn);


        public DataSet RecordSet(DbCommand command, string tableName)
        {
            return RecordSet(command, tableName, new DataSet());
        }

        public DataSet RecordSet(DbCommand command)
        {
            return RecordSet(command, defaultTableName, new DataSet());
        }

        public DataSet RecordSet(string query, string tableName)
        {
            return RecordSet(query, tableName, new DataSet());
        }

        public DataSet RecordSet(string query, string tableName, DataSet dataSetReturn)
        {
            DbParameterCollection parameter = CreateDataParameterCollection();
            DbCommand command = CreateCommand(query, ref parameter);

            return RecordSet(command, tableName, dataSetReturn);
        }

        public DataTable RecordSet(string query, DataTable dataTableReturn, CommandType commandType)
        {
            DbParameterCollection parameter = CreateDataParameterCollection();

            return RecordSet(query, ref parameter, dataTableReturn, commandType);
        }

        public DataTable RecordSet(string query, ref DbParameterCollection parameter, DataTable dataTableReturn, CommandType commandType)
        {
            DbCommand command = CreateCommand(query, ref parameter, commandType);

            return RecordSet(command, dataTableReturn);
        }

        public DataSet RecordSet(string query)
        {
            return RecordSet(query, defaultTableName);
        }

        public DataSet RecordSet(string query, ref DbParameterCollection parameters)
        {

            return RecordSet(query, ref parameters, defaultTableName);
        }

        public DataSet RecordSet(string query, ref DbParameterCollection parameters, string tableName)
        {

            return RecordSet(query, ref parameters, tableName, new DataSet());
        }

        public DataSet RecordSet(string query, ref DbParameterCollection parameters, string tableName, DataSet dataSetReturn)
        {

            DbCommand command = CreateCommand(query, ref parameters);
            return RecordSet(command, tableName, dataSetReturn);
        }


        #endregion

        #region DbCommand
        /// <summary>
        /// Este metodo deve ser sobrecrito pela classe especialização, este método é chamado por todas outras sobrecargas
        /// </summary>
        /// <param name="query">Query dever ser executada no banco</param>
        /// <param name="parameters">lista de parametros usado para alimentar as as variaveis do command </param>
        /// <returns></returns>
        protected abstract DbCommand CreateCommand(string query, ref DbParameterCollection parameters, CommandType commandType);

        public DbCommand CreateCommand(string query, ref DbParameterCollection parameters)
        {
            return CreateCommand(query, ref parameters, CommandType.Text);
        }

        public abstract DbParameter CreateParameterCursor();

        public abstract DbParameter CreateParameterSequence();

        #endregion

        #region ExecuteCommand
        /// <summary>
        /// Executa um Command
        /// </summary>
        /// <param name="strSQL">Query para Execução</param>
        /// <returns>Quantidade Registros afetados</returns>
        public int ExecuteCommand(string query)
        {
            DbParameterCollection parameter = CreateDataParameterCollection();
            DbCommand oCmd = CreateCommand(query, ref parameter);

            return ExecuteCommand(oCmd);

        }
        /// <summary>
        /// Executa um Command
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public int ExecuteCommand(string query, ref DbParameterCollection parameters)
        {
            DbCommand oCmd = CreateCommand(query, ref parameters);

            return ExecuteCommand(oCmd);

        }

        /// <summary>
        /// Executa um Command
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public int ExecuteCommand(string query, ref DbParameterCollection parameters, CommandType commandType)
        {
            DbCommand oCmd = CreateCommand(query, ref parameters, commandType);

            return ExecuteCommand(oCmd);

        }

        /// <summary>
        /// Executa um Command
        /// </summary>
        /// <param name="CommandToExecute">Command para Execução</param>
        /// <returns>Quantidade de registros afetados</returns>
        public int ExecuteCommand(DbCommand command)
        {

            command.Connection = this.Connection;

            command.Transaction = this.Transaction;

            if (commandTimeout > -1) { command.CommandTimeout = commandTimeout; }

            this.OpenConnection();

            int ret = command.ExecuteNonQuery();

            this.CloseConnection();

            return ret;

        }
        #endregion

        #region ExecuteScalar
        public object ExecuteScalar(string query)
        {
            DbParameterCollection parameter = CreateDataParameterCollection();

            DbCommand oCmd = CreateCommand(query, ref parameter);

            return ExecuteScalar(oCmd);
        }

        public object ExecuteScalar(string query, ref DbParameterCollection parameters)
        {

            // Varre a hash de controles
            DbCommand oCmd = CreateCommand(query, ref parameters);

            // adciionando os parametros

            return ExecuteScalar(oCmd);
        }


        public object ExecuteScalar(DbCommand command)
        {

            command.Connection = this.Connection;
            command.Transaction = this.Transaction;

            if (commandTimeout > -1) { command.CommandTimeout = commandTimeout; }

            this.OpenConnection();

            object ret = command.ExecuteScalar();

            this.CloseConnection();

            return ret;
        }
        #endregion

        protected void CopyParameter(DbParameter source, DbParameter target)
        {

            foreach (PropertyInfo ppt in source.GetType().GetProperties())
            {
                try
                {
                    target.GetType().GetProperty(ppt.Name).SetValue(target, ppt.GetValue(source, null), null);
                }
                catch
                {
                }
            }


        }

        #endregion

        #region "Métodos Auxiliares IDataReader"

        /// <summary>
        /// Converte o campo desejado de um DataReader para Binary (Image)
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="reader">DataReader</param>
        /// <returns></returns>
        public byte[] GetAsBinary(string name, IDataReader reader)
        {
            if (reader[name] == System.DBNull.Value)
                return null;
            else
                return (Byte[])reader[name];
        }


        /// <summary>
        /// Converte o campo desejado de um DataReader para Short
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="reader">DataReader</param>
        /// <returns></returns>
        public short? GetAsShort(string name, IDataReader reader)
        {
            if (reader[name] == System.DBNull.Value)
                return null;
            else
                return Convert.ToInt16(reader[name]);
        }


        /// <summary>
        /// Converte o campo desejado de um DataReader para Byte
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="reader">DataReader</param>
        /// <returns></returns>
        public byte? GetAsByte(string name, IDataReader reader)
        {
            if (reader[name] == System.DBNull.Value)
                return null;
            else
                return Convert.ToByte(reader[name]);
        }


        /// <summary>
        /// Converte o campo desejado de um DataReader para Int
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="reader">DataReader</param>
        /// <returns></returns>
        public int? GetAsInt(string name, IDataReader reader)
        {
            if (reader[name] == System.DBNull.Value)
                return null;
            else
                return Convert.ToInt32(reader[name]);
        }

        /// <summary>
        /// Converte o campo desejado de um DataReader para Int64 (long)
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="reader">DataReader</param>
        /// <returns></returns>
        public Int64? GetAsLong(string name, IDataReader reader)
        {
            if (reader[name] == System.DBNull.Value)
                return null;
            else
                return Convert.ToInt64(reader[name]);
        }

        /// <summary>
        /// Converte o campo desejado de um DataReader para string
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="reader">DataReader</param>
        /// <returns></returns>
        public string GetAsString(string name, IDataReader reader)
        {
            string sRetorno = (reader[name] == System.DBNull.Value ? "" : reader[name]).ToString();
            return sRetorno.Trim();
        }

        /// <summary>
        /// Converte o campo desejado de um DataReader para float
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="reader">DataReader</param>
        /// <returns></returns>
        public float? GetAsFloat(string name, IDataReader reader)
        {
            if (reader[name] == System.DBNull.Value)
                return null;
            else
                return (float)Convert.ToDecimal(reader[name]);
        }

        /// <summary>
        /// Converte o campo desejado de um DataReader para double
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="reader">DataReader</param>
        /// <returns></returns>
        public double? GetAsDouble(string name, IDataReader reader)
        {
            if (reader[name] == System.DBNull.Value)
                return null;
            else
                return Convert.ToDouble(reader[name]);
        }

        /// <summary>
        /// Converte o campo desejado de um DataReader para decimal
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="reader">DataReader</param>
        /// <returns></returns>
        public decimal? GetAsDecimal(string name, IDataReader reader)
        {
            if (reader[name] == System.DBNull.Value)
                return null;
            else
                return Convert.ToDecimal(reader[name]);
        }

        /// <summary>
        /// Converte o campo desejado de um DataReader para DateTime
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="reader">DataReader</param>
        /// <returns></returns>
        public DateTime? GetAsDateTime(string name, IDataReader reader)
        {
            if (reader[name] == System.DBNull.Value)
                return null;
            else
                return Convert.ToDateTime(reader[name]);
        }

        /// <summary>
        /// Converte o campo desejado "S" ou "N" de um DataReader para Booleano
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="reader">DataReader</param>
        /// <returns></returns>
        public bool GetAsBoolean(string name, IDataReader reader)
        {
            string result = reader[name] == System.DBNull.Value || reader[name].ToString().Trim().Equals("") ? "N" : reader[name].ToString();
            return result.Equals("S") ? true : false;
        }

        #endregion

        #region "Métodos Auxiliares DataRow"

        /// <summary>
        /// Converte o campo desejado de um DataRow para Binary (Image)
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        public byte[] GetAsBinary(string name, DataRow row)
        {
            if (row[name] == System.DBNull.Value)
                return null;
            else
                return (Byte[])row[name];
        }


        /// <summary>
        /// Converte o campo desejado de um DataRow para Short
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        public short? GetAsShort(string name, DataRow row)
        {
            if (row[name] == System.DBNull.Value)
                return null;
            else
                return Convert.ToInt16(row[name]);
        }


        /// <summary>
        /// Converte o campo desejado de um DataRow para Byte
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        public byte? GetAsByte(string name, DataRow row)
        {
            if (row[name] == System.DBNull.Value)
                return null;
            else
                return Convert.ToByte(row[name]);
        }


        /// <summary>
        /// Converte o campo desejado de um DataRow para Int
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        public int? GetAsInt(string name, DataRow row)
        {
            if (row[name] == System.DBNull.Value)
                return null;
            else
                return Convert.ToInt32(row[name]);
        }

        /// <summary>
        /// Converte o campo desejado de um DataRow para Int64 (long)
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        public Int64? GetAsLong(string name, DataRow row)
        {
            if (row[name] == System.DBNull.Value)
                return null;
            else
                return Convert.ToInt64(row[name]);
        }

        /// <summary>
        /// Converte o campo desejado de um DataRow para string
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        public string GetAsString(string name, DataRow row)
        {
            string sRetorno = (row[name] == System.DBNull.Value ? "" : row[name]).ToString();
            return sRetorno.Trim();
        }

        /// <summary>
        /// Converte o campo desejado de um DataRow para float
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        public float? GetAsFloat(string name, DataRow row)
        {
            if (row[name] == System.DBNull.Value)
                return null;
            else
                return (float)Convert.ToDecimal(row[name]);
        }

        /// <summary>
        /// Converte o campo desejado de um DataRow para double
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        public double? GetAsDouble(string name, DataRow row)
        {
            if (row[name] == System.DBNull.Value)
                return null;
            else
                return Convert.ToDouble(row[name]);
        }

        /// <summary>
        /// Converte o campo desejado de um DataRow para decimal
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        public decimal? GetAsDecimal(string name, DataRow row)
        {
            if (row[name] == System.DBNull.Value)
                return null;
            else
                return Convert.ToDecimal(row[name]);
        }

        /// <summary>
        /// Converte o campo desejado de um DataRow para DateTime
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        public DateTime? GetAsDateTime(string name, DataRow row)
        {
            if (row[name] == System.DBNull.Value)
                return null;
            else
                return Convert.ToDateTime(row[name]);
        }

        /// <summary>
        /// Converte o campo desejado "S" ou "N" de um DataRow para Booleano
        /// </summary>
        /// <param name="name">Nome do Campo</param>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        public bool GetAsBoolean(string name, DataRow row)
        {
            string result = row[name] == System.DBNull.Value || row[name].ToString().Trim().Equals("") ? "N" : row[name].ToString();
            return result.Equals("S") ? true : false;
        }

        #endregion
    }
}
