using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace HospitalAnaCosta.Framework.Data
{
    public interface IProvider
    {
        #region Properties
        /// <summary>
        /// Get / Set Connection string for database
        /// </summary>
        string ConnectionString
        {
            get;
            set;
        }


        /// <summary>
        /// Return the openned connection
        /// </summary>
        DbConnection Connection
        {
            get;
            set;
        }

        /// <summary>
        /// Get/Set the Transaction for database
        /// </summary>
        DbTransaction Transaction
        {
            get;
            set;
        }


        /// <summary>
        /// Get/Set the maximus time to executo off a command
        /// </summary>
        int CommandTimeout
        {
            get;
            set;
        }
        #endregion

        #region Methods


        /// <summary>
        /// Return a Connection with database
        /// </summary>
        /// <returns></returns>
        DbConnection OpenConnection();

        /// <summary>
        /// Close the database connection if this is openned
        /// </summary>
        void CloseConnection();

        /// <summary>
        /// Open a trasaction with database
        /// </summary>
        /// <returns></returns>
        DbTransaction BeginTransaction();

        /// <summary>
        /// Commit Transaction
        /// </summary>
        void CommitTransaction();


        /// <summary>
        /// RollbackTransaction
        /// </summary>
        void RollBackTransaction();


        /// <summary>
        /// 
        /// </summary>
        /// <returns>Uma colecao vazia de parametros</returns>
        DbParameterCollection CreateDataParameterCollection();

        /// <summary>
        /// Cria uma parametro para ser inserido no banco de dadoss
        /// </summary>
        /// <param name="name">nome do parametro</param>
        /// <param name="value">valor do mesmo</param>
        /// <returns></returns>
        DbParameter CreateParameter(string name, object value);

        /// <summary>
        /// Cria uma parametro para ser inserido no banco de dadoss
        /// </summary>
        /// <param name="name">nome do parametro</param>
        /// <param name="value">valor do mesmo</param>
        /// <param name="ParameterDirection">direcão do parametro</param>/// 
        /// <returns></returns>
        DbParameter CreateParameter(string name, object value, System.Data.ParameterDirection direction);

        /// <summary>
        /// Cria um parametro "io_cursor" utilizado para retorno em bases oracle
        /// </summary>
        /// <returns></returns>
        DbParameter CreateParameterCursor();

        /// <summary>
        /// Cria um parametro "pNewIdt" utilizado para retorno da sequence
        /// </summary>
        /// <returns></returns>
        DbParameter CreateParameterSequence();
        #endregion
    }
}
