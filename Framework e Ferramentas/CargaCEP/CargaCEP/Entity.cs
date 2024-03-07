using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalAnaCosta.Framework.Data;
using MVC = HospitalAnaCosta.Framework.Common;
using System.Configuration;
using System.Data;
using System.Dynamic;

namespace CargaCEP
{

    public class Data : MVC.Entity, IDisposable
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

        private List<dynamic> ToDynamic(DataTable dt)
        {
            var dynamicDt = new List<dynamic>();
            foreach (DataRow row in dt.Rows)
            {
                dynamic dyn = new ExpandoObject();
                foreach (DataColumn column in dt.Columns)
                {
                    var dic = (IDictionary<string, object>)dyn;
                    dic[column.ColumnName] = row[column];

                }
                dynamicDt.Add(dyn);
            }
            return dynamicDt;
        }

        public DataTable Result(string query)
        {
            var result = new DataTable();
            
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }

        public List<dynamic> DynamicResult(string query)
        {
            return ToDynamic(Result(query));
        }

        public void ExecuteCommand(string query)
        {      
            Connection.ExecuteCommand(query);
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);     
        }
        bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                this.Connection.Dispose();                
            }

            // Free any unmanaged objects here. 
            //
            disposed = true;
        }
    }
}
