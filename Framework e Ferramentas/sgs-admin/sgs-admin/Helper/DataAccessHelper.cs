using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Configuration;

namespace sgs_admin.Helper
{
    public class DataAccessHelper
    {
        public static dynamic GetData(string query, string connectionString)
        {
            using (var con =new OracleConnection(ConfigurationManager.ConnectionStrings[connectionString].ConnectionString))
            {
                con.Open();
                var result = new DataAccessHelper().Serialize(new OracleCommand(query,con).ExecuteReader());


                con.Close();
                

                return result;
            }
        }

        public IEnumerable<Dictionary<string, object>> Serialize(OracleDataReader reader)
        {
            var results = new List<Dictionary<string, object>>();
            var cols = new List<string>();
            for (var i = 0; i < reader.FieldCount; i++)
                cols.Add(reader.GetName(i));

            while (reader.Read())
                results.Add(SerializeRow(cols, reader));

            return results;
        }

        private static Dictionary<string, object> SerializeRow(IEnumerable<string> cols, IDataRecord reader)
        {
            return cols.ToDictionary(col => col, col => reader[(string) col]);
        }

        public static void ExecuteCommand(string sqlCommand, string connectionString)
        {
            using (var con = new OracleConnection(ConfigurationManager.ConnectionStrings[connectionString].ConnectionString))
            {
                con.Open();
                new OracleCommand(sqlCommand, con).ExecuteNonQuery();
                con.Close();
            }
        }

        public static void ExecuteCommand(string sqlCommand, string connectionString, List<OracleParameter> parameters)
        {
            using (var con = new OracleConnection(ConfigurationManager.ConnectionStrings[connectionString].ConnectionString))
            {
                con.Open();
                var cmd = new OracleCommand(sqlCommand, con);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}