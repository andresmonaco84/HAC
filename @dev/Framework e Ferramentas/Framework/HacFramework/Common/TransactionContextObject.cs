using System;
using System.Collections.Generic;
using System.Transactions;
using System.Text;
using HospitalAnaCosta.Framework.Data;

namespace HospitalAnaCosta.Framework.Common
{
    [TransactionContextAttribute()]
    [Serializable]
    public abstract class TransactionContextObject : ContextBoundObject
    {
        protected System.Transactions.DependentTransaction transaction;        
        private System.Transactions.TransactionScope transactionScope;

        /// <summary>
        /// Usado para indica que a classe atual que criou a transacao e somente ela pode 
        /// Finalizar a mesma
        /// </summary>
        private bool prepared = false;


        public TransactionContextObject() { }

        /// <summary>
        /// Faz a finalizacao das transacoes pendentes 
        /// </summary>
        ~TransactionContextObject()
        {
            // //Se a transacao nao acabou, faz o rollback da mesma
            //if (transaction != null)
            //{
            if (transactionScope != null)
            {
                this.RollbackTransaction();
            }

        }

        /// <summary>
        /// Inicia uma transacao, caso ja exista uma em execucao, faz o "join"  na mesma
        /// </summary>
        protected void BeginTransaction()
        {
            //Prepara o inicio da  transacao
            this.Prepare();

            //Cria uma nova transacao a partir da transacao atual para ser usada          
            //   transaction = System.Transactions.Transaction.Current.DependentClone(DependentCloneOption.BlockCommitUntilComplete);           
        }


        /// <summary>
        /// Confirma a atualizacao atual
        /// </summary>
        protected void CommitTransaction()
        {
            //Caso esta instancia tenha criado a transacao principal, faz o "termino" da mesma
            if (prepared)
            {
                transactionScope.Complete();
                FinalizeComponents();
            }
        }

        internal void FinalizeComponents()
        {
            if (transactionScope != null)
            {
                try
                {
                    transactionScope.Dispose();
                }
                catch
                {
                }
                finally
                {
                    transactionScope = null;
                }

            }
        }

        /// <summary>
        /// Cancela as alteracoes realizadas
        /// </summary>
        protected void RollbackTransaction()
        {

            //   if (transaction != null)
            //   {
            // transaction.Rollback();

            //Caso esta instancia tenha criado a transacao principal, faz o "termino" da mesma
            if (prepared)
            {
                if (transactionScope != null)
                {
                    FinalizeComponents();
                }
            }
        }

        /// <summary>
        /// Faz a preparacao do objeto de transacao
        /// </summary>
        internal void Prepare()
        {
            // Primeiro verifica se nao existe nenhuma transacao atual
            if (System.Transactions.Transaction.Current != null)
            {
                if (System.Transactions.Transaction.Current.TransactionInformation.Status != TransactionStatus.Active)
                {
                    System.Transactions.Transaction.Current.Dispose();
                    System.Transactions.Transaction.Current = null;
                }
            }


            //if (System.Transactions.Transaction.Current == null)
            //{

            //Caso ainda nao tenha sido criado o objeto de controle de transacao, cria o mesmo
            if (transactionScope == null)
            {
                //Cria a transacao principal
                //Transaction committableTransaction = new CommittableTransaction();


                //Cria o Scopo de transacao
                transactionScope = new System.Transactions.TransactionScope(TransactionScopeOption.Required);


                //Troca o Flag para indicar que a classe atual criou a transacao
                prepared = true;
                //}
            }
        }

        /// <summary>
        /// Inclui a conexao atual em uma transacao, caso ela exista
        /// </summary>
        /// <param name="connection"></param>
        internal void IncludeConnectionInTransactionScope(ProviderBase connection)
        {
            // Primeiro verifica se nao existe nenhuma transacao atual
            //if (System.Transactions.Transaction.Current != null)
            //{
            //    if (System.Transactions.Transaction.Current.TransactionInformation.Status == TransactionStatus.Active)
            //    {
            //        connection.EnlistTransaction(this.transaction);
            //    }
            //}
        }
    }
}
