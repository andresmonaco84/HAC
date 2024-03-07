using System;
using System.Data;
using System.Data.Common;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace HospitalAnaCosta.Framework.Data
{
    /// <summary>
    /// Summary description for OracleProvider.
    /// </summary>
    public class OracleNativeProvider : ProviderBase
    {
        public OracleNativeProvider()
        {
            connection = new OracleConnection();
        }

        #region RecordSet
        override public DataSet RecordSet(DbCommand command, string tableName, DataSet dataSetReturn)
        {
            // adicionando a Conection e a Transacao						
            command.Connection = Connection;
            command.Transaction = Transaction;

            if (commandTimeout > -1) { command.CommandTimeout = commandTimeout; }


            using (OracleDataAdapter objOracleAdapter = new OracleDataAdapter((OracleCommand)command))
            {
                OpenConnection();

                objOracleAdapter.Fill(dataSetReturn, tableName);

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


            using (OracleDataAdapter objOracleAdapter = new OracleDataAdapter((OracleCommand)command))
            {
                OpenConnection();

                objOracleAdapter.Fill(dataTableReturn);

                CloseConnection();

                return dataTableReturn;
            }
        }


        #endregion

        #region CreateCommand

        override protected DbCommand CreateCommand(string query, ref DbParameterCollection parameters, CommandType commandType)
        {
            DbCommand command = null;

            using (OracleCommand oracleCommand = new OracleCommand(query))
            {
                oracleCommand.CommandType = commandType;

                foreach (DbParameter param in parameters)
                {
                    OracleParameter oraParameter = new OracleParameter();
                    CopyParameter(param, oraParameter);
                    oracleCommand.Parameters.Add(oraParameter);
                }

                parameters = oracleCommand.Parameters;

                command = oracleCommand;
                return command;
            }

        }
        #endregion

        #region CreateDataParameterCollection
        public override DbParameterCollection CreateDataParameterCollection()
        {
            return new OracleCommand().Parameters;
        }
        #endregion

        #region CreateParameter

        public override DbParameter CreateParameterCursor()
        {
            OracleParameter par = new OracleParameter();
            par.Direction = ParameterDirection.Output;
            par.OracleDbType = OracleDbType.RefCursor;
            par.ParameterName = "io_cursor";
            return par;
        }

        public override DbParameter CreateParameterSequence()
        {
            OracleParameter par = new OracleParameter();
            par.Direction = ParameterDirection.Output;
            par.OracleDbType = OracleDbType.Int64;
            par.ParameterName = "pNewIdt";
            return par;
        }

        public override DbParameter CreateParameter(string name, object value, ParameterDirection direction)
        {
            if (value == null)
                value = DBNull.Value;
            OracleParameter param = new OracleParameter(name, value);
            param.Direction = direction;
            return param;
        }
        #endregion

    }
}