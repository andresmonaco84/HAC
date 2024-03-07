using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace HospitalAnaCosta.Framework.Data
{
    public class SQLServerProvider : ProviderBase
    {
        public SQLServerProvider()
        {
            connection = new SqlConnection();
        }

        #region DataSet
        override public DataSet RecordSet(DbCommand command, string tableName, DataSet dataSetReturn)
        {
            // adicionando a Conection e a Transacao						
            command.Connection = Connection;
            command.Transaction = Transaction;

            if (commandTimeout > -1) { command.CommandTimeout = commandTimeout; }


            using (SqlDataAdapter sqlAdapter = new SqlDataAdapter((SqlCommand)command))
            {
                OpenConnection();

                sqlAdapter.Fill(dataSetReturn, tableName);

                CloseConnection();

                return dataSetReturn;
            }
        }
        override public DataTable RecordSet(DbCommand command, DataTable dataTableReturn)
        {
            // adicionando a Conection e a Transacao						
            command.Connection = Connection;
            command.Transaction = Transaction;

            if (commandTimeout > -1) { command.CommandTimeout = commandTimeout; }


            using (SqlDataAdapter sqlAdapter = new SqlDataAdapter((SqlCommand)command))
            {
                OpenConnection();

                sqlAdapter.Fill(dataTableReturn);

                CloseConnection();

                return dataTableReturn;
            }
        }

        #endregion

        #region CreateCommand

        override protected DbCommand CreateCommand(string query, ref DbParameterCollection parameters, CommandType commandType)
        {
            DbCommand command = null;

            using (SqlCommand sqlCommand = new SqlCommand(query))
            {
                sqlCommand.CommandType = commandType;

                foreach (DbParameter param in parameters)
                {
                    SqlParameter sqlParameter = new SqlParameter();
                    CopyParameter(param, sqlParameter);
                    sqlCommand.Parameters.Add(sqlParameter);
                }

                parameters = sqlCommand.Parameters;

                command = sqlCommand;
                return command;
            }
        }
        #endregion

        #region CreateDataParameterCollection
        public override DbParameterCollection CreateDataParameterCollection()
        {
            return new SqlCommand().Parameters;
        }
        #endregion

        #region CreateParameter
        public override DbParameter CreateParameter(string name, object value, ParameterDirection direction)
        {
            if (value == null)
                value = DBNull.Value;
            SqlParameter param = new SqlParameter(name, value);
            param.Direction = direction;
            return param;
        }
        #endregion

        public override DbParameter CreateParameterSequence()
        {
            SqlParameter par = new SqlParameter();
            par.Direction = ParameterDirection.Output;
            par.DbType = DbType.Int32;
            par.ParameterName = "@pNewIdt";
            return par;
        }

        public override DbParameter CreateParameterCursor()
        {
            return null;
        }
    }    
}
