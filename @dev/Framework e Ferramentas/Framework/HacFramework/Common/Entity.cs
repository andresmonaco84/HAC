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
        /// Implementa a obtenção dos parametros de conexão e criação do objeto 
        /// de conexão.
        /// </summary>
        /// <returns>Retorna a conexão, ProviderBase, a ser utilizado pelo objeto Entity.</returns>
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
        /// Retorna a conexão atual com o provedor do objeto para execução dos comandos.
        /// Chama <see cref="CreateConnection"/> quando necessitar criar uma nova conexão.
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
