using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Threading;

namespace HospitalAnaCosta.Framework.Common
{

    public abstract class Entity : TransactionContextObject
    {
        public Entity() { }
        private ProviderBase connection;

        /// <summary>
        /// Implementa a obten��o dos parametros de conex�o e cria��o do objeto 
        /// de conex�o.
        /// </summary>
        /// <returns>Retorna a conex�o, ProviderBase, a ser utilizado pelo objeto Entity.</returns>
        protected abstract ProviderBase CreateConnection();

        protected ProviderBase Connection
        {
            get
            {
                if (connection == null)
                    connection = ContextConnection();
                return connection;
            }
        }

        #region protected methods
        /// <summary>
        /// Retorna a conex�o atual com o provedor do objeto para execu��o dos comandos.
        /// Chama <see cref="CreateConnection"/> quando necessitar criar uma nova conex�o.
        /// </summary>
        private ProviderBase ContextConnection()
        {
            ProviderBase connection;
            connection = CreateConnection();

            //Caso exista alguma Transacao insere a conexao na mesma
            IncludeConnectionInTransactionScope(connection);

            return connection;
        }
        #endregion
    }
}
