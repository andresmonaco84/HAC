using System;
using System.Text;
using MVC = HospitalAnaCosta.Framework.Common;
using HospitalAnaCosta.Framework.Data;
using System.Configuration;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public class Entity : MVC.Entity//, IDisposable
    {
        OracleProvider provider;
        protected override ProviderBase CreateConnection()
        {
            provider = new OracleProvider();
            provider.ConnectionString = this.LoadDSN();
            return provider;
        }

        protected virtual string LoadDSN()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionStringOracle"].ConnectionString;
        }

        //~Entity()
        //{
        //    Dispose();
        //}

        //public void Dispose()
        //{
        //    if (provider.Connection != null)
        //    {
        //        provider.Connection.Close();
        //    }
        //    if (provider != null)
        //    {
        //        provider.Dispose();
        //    }
        //    GC.SuppressFinalize(this);
        //}
    }
}
