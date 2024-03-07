using System;
using System.Collections.Generic;
using System.Text;
using MVC = HospitalAnaCosta.Framework.Common;
using System.Runtime.Remoting.Messaging;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
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
