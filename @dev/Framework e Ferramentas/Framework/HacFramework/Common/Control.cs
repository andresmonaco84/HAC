using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting.Messaging;

namespace HospitalAnaCosta.Framework.Common
{
    public class Control : TransactionContextObject
    {
        public Control() { }
        /// <summary>
        /// Guarda a Credencial do Usuario que esta usando a aplicacao 
        /// </summary>
        public object Credential
        {
            get
            {

                return CallContext.LogicalGetData("CredentialContextAttribute");
            }
            set
            {
                CallContext.LogicalSetData("CredentialContextAttribute", value);
            }
        }

        public string Culture
        {
            get
            {
                return System.Threading.Thread.CurrentThread.CurrentUICulture.ToString();
            }

            set
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(value);
                CallContext.LogicalSetData("System.Threading.Thread.CurrentThread.CurrentUICulture", value);
            }
        }
    }
}
