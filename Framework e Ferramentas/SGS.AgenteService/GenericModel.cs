using HospitalAnaCosta.Framework.Data;
using MVC = HospitalAnaCosta.Framework.Common;
using System.Configuration;
using System.Data;
using System.Data.Common;
using Oracle.DataAccess.Client;

namespace SGS.AgenteService
{
    public class GenericModel : MVC.Entity
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

        public DataTable GetData(string query)
        {
            DataTable result = new DataTable();

            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }

        public void ExecuteCommand(string query)
        {


            Connection.ExecuteCommand(query);

        }

        public void ExecuteCommand(string query, DbParameterCollection pars)
        {            

            Connection.ExecuteCommand(query,ref pars);

        }

        public DbParameterCollection CreateParameterCollecion()
        {
            return Connection.CreateDataParameterCollection();
        }

        public DbParameterCollection CreateParameterCollecion(Parameter[] pars)
        {
            var parames = Connection.CreateDataParameterCollection();

            foreach (var item in pars)
            {
                parames.Add(CreateParameter(item.Name, item.Obj));
            }

            return parames;
        }

        public DbParameter CreateParameter(string name, object value)
        {
            return Connection.CreateParameter(name, value);
        }
       
    }

}

public class Parameter
{
    public Parameter(string name, object obj)
    {
        Name = name;
        Obj = obj;
    }

    public string Name { get; set; }
    public object Obj { get; set; }
}