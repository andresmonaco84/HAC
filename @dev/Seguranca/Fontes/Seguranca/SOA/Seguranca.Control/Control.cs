using System;
using System.Collections.Generic;
using System.Text;
using MVC = HospitalAnaCosta.Framework.Common;
using System.Runtime.Remoting.Messaging;
using HospitalAnaCosta.SGS.Seguranca.Interface;

namespace HospitalAnaCosta.SGS.Seguranca.Control
{
    [MVC.CredentialContextAttribute()]
    public abstract class Control : MVC.Control, IControl
    {
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
    }
}
