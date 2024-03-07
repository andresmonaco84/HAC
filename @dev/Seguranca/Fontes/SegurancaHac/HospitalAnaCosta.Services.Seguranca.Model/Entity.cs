using System.Configuration;
using HospitalAnaCosta.Framework.Data;
using MVC = HospitalAnaCosta.Framework.Common;

namespace HospitalAnaCosta.Services.Seguranca.Model
{
    public class Entity : MVC.Entity
    {
        protected override ProviderBase CreateConnection()
        {
            OracleProvider provider = new OracleProvider();
            provider.ConnectionString = this.LoadDSN();
            return provider;
        }

        protected virtual string LoadDSN()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionStringOracle"].ConnectionString;
        }
    }
}