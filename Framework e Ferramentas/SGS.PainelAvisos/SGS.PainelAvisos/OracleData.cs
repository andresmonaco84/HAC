using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalAnaCosta.Framework.Common;
using HospitalAnaCosta.Framework.Data;
using System.Configuration;

public class OracleData : Entity
{
    protected override ProviderBase CreateConnection()
    {
        return new OracleProvider { ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionStringOracle"].ConnectionString };
    }

    public DataTable ExecuteQuery(string query)
    {
        var result = new DataTable();

        Connection.RecordSet(query, result, CommandType.Text);

        return result;
    }
    public void ExecuteCommand(string query)
    {
        Connection.RecordSet(query);
    }
}

public static class DataExtensions
{

    public static DataTable QueryToDataTable(this string query)
    {
        return new OracleData().ExecuteQuery(query);
    }

    public static void ExecuteCommand(this string query)
    {
        new OracleData().ExecuteCommand(query);
    }

    public static List<Dictionary<string, string>> QueryToList(this string query)
    {
        return new OracleData().ExecuteQuery(query).ToList();
    }

    public static List<Dictionary<string, string>> ToList(this DataTable dtb)
    {
        return (from DataRow row in dtb.Rows select dtb.Columns.Cast<DataColumn>().ToDictionary(column => column.ColumnName, column => row[column.ColumnName].ToString())).ToList();
    }

    public static Dictionary<string, string> FirstRowToDictionary(this DataTable dtb)
    {
        return dtb.Rows.Count == 0 ? null : dtb.Columns.Cast<DataColumn>().ToDictionary(column => column.ColumnName, column => dtb.Rows[0][column.ColumnName].ToString());
    }


}
