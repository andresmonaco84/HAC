using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.Services.Seguranca.DTO;

namespace HospitalAnaCosta.Services.Seguranca.Model
{
	public partial class Usuario : Entity
	{
        public string GeraToken(string usuario, string acao)
        {
            string query = "PRC_SEGURANCA_TOKEN";
            DbParameterCollection param = Connection.CreateDataParameterCollection();
            param.Add(Connection.CreateParameter("P_IDENTIFICACAO", usuario, ParameterDirection.Input, DbType.String));
            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);


            DataTable result = new DataTable();
            string sql = string.Format("SELECT SGS.FNC_SEGURANCA_TOKEN('{0}','{1}') FROM DUAL",usuario, acao);
            Connection.RecordSet(sql, result, CommandType.Text);

            if (result.Rows.Count > 0)
                return result.Rows[0][0].ToString();
            else
                return string.Empty;
        }
	}
}
