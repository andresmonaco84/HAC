using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Activation;
using HospitalAnaCosta.Framework.Data;
using System.Runtime.Serialization;

namespace HospitalAnaCosta.Framework.Common
{
    #region TransactionContextAttribute
    /// <summary>
    /// Esta classe deve ser usada por todas as classes que querem participar do contexto de transcacao atraves de "Sinks"
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    [Serializable]
    public class TransactionContextAttribute : ContextAttribute
    {
        public TransactionContextAttribute()
            : base(TransactionContextAttribute.PropertyName) { }

        private BaseData connection;
        private bool needsTransaction = false;

        public override void GetPropertiesForNewContext(IConstructionCallMessage ctor)
        {
            ctor.ContextProperties.Add(this);
        }

        public override bool IsContextOK(Context ctx, IConstructionCallMessage ctor)
        {
            TransactionContextAttribute transactionContextAttribute
                    = ctx.GetProperty(TransactionContextAttribute.PropertyName) as TransactionContextAttribute;

           // Se não existir transação no contexto ele cria uma 
            if (transactionContextAttribute == null)
            {
                return false;
            }
            return true;
        }

        public static string PropertyName
        {
            get { return "HacFramework.Common.TransactionContextAttribute"; }
        }
    }
    #endregion
}
