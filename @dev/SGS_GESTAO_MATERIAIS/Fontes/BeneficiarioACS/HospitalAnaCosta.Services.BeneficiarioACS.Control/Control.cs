using System.Runtime.Remoting.Messaging;
using MVC = HospitalAnaCosta.Framework.Common;
using HospitalAnaCosta.Services.BeneficiarioACS.Interface;

namespace HospitalAnaCosta.Services.BeneficiarioACS.Control
{
    [MVC.CredentialContextAttribute()]
    public abstract class Control : MVC.Control, IControl
    {
        public new object Credential
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
