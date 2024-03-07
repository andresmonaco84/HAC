using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Activation;
using HospitalAnaCosta.Framework.Data;

namespace HospitalAnaCosta.Framework.Common
{
    #region CredentialContextAttribute
    /// <summary>
    /// Atributo usado para trafegar o usuario que esta logado no sistema
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    [SerializableAttribute]
    public class CredentialContextAttribute : ContextAttribute
    {
        #region atributos internos
        object credential;

        public object Credential
        {
            get { return credential; }
            set { credential = value; }
        }
        #endregion

        public CredentialContextAttribute()
            : base(CredentialContextAttribute.PropertyName) { }

        public override void GetPropertiesForNewContext(IConstructionCallMessage ctor)
        {
            ctor.ContextProperties.Add(this);
        }

        public override bool IsContextOK(Context ctx, IConstructionCallMessage ctor)
        {
            CredentialContextAttribute credentialContextAttribute
                    = ctx.GetProperty(CredentialContextAttribute.PropertyName) as CredentialContextAttribute;

            // If there is no existing transaction context then create a new one
            if (credentialContextAttribute == null)
            {
                return false;
            }
            return true; // The current context is fine!!
        }

        public static string PropertyName
        {
            get { return "Hac.CredentialContextAttribute"; }
        }
    }
    #endregion
}
