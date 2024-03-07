using System;
using System.Data;
using System.Data.Common;
using System.Data.OracleClient;
using System.Text;
using HospitalAnaCosta.Services.BeneficiarioACS.DTO;

namespace HospitalAnaCosta.Services.BeneficiarioACS.Model
{
    public partial class BeneficiarioACS : Entity
    {

        public DataTable ListarCarenciaBeneficiario(string strCodPlano, int? codEst, int? codBen, int? codSeqBen)
        {
            String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringOracle"].ConnectionString;
            using (OracleConnection db = new OracleConnection(connectionString))
            {

                StringBuilder sqlCommand = new StringBuilder();

                sqlCommand.Append("SELECT B.CODSER, S.NOMSER, B.DATFIMCAR \n");
                sqlCommand.Append("FROM   BNF_CARENCIA_BENEFICIARIO B, \n");
                sqlCommand.Append("       BNF_SERVICO S \n");
                sqlCommand.Append("WHERE  B.CODCON = :pCODCON\n");
                sqlCommand.Append("AND    B.CODEST = :pCODEST\n");
                sqlCommand.Append("AND    B.CODBEN = :pCODBEN\n");
                sqlCommand.Append("AND    B.CODSEQBEN = :pCODSEQBEN\n");
                //sqlCommand.Append("AND    B.DATFIMCAR >= TRUNC(SYSDATE) \n");
                sqlCommand.Append("AND    S.CODSER = B.CODSER \n");

                OracleCommand dbCommand = db.CreateCommand();
                dbCommand.CommandText = sqlCommand.ToString();
                dbCommand.CommandType = CommandType.Text;

                #region "Parametros"
                dbCommand.Parameters.AddWithValue(":pCODCON", strCodPlano);
                dbCommand.Parameters.AddWithValue(":pCODEST", codEst);
                dbCommand.Parameters.AddWithValue(":pCODBEN", codBen);
                dbCommand.Parameters.AddWithValue(":pCODSEQBEN", codSeqBen);
                #endregion

                OracleDataAdapter adp = new OracleDataAdapter(dbCommand);
                DataTable dt = new DataTable();
                try
                {
                    adp.Fill(dt);
                    adp.Dispose();
                }
                finally
                {
                    if (dbCommand.Connection != null)
                    {
                        dbCommand.Connection.Close();
                    }
                    dbCommand.Dispose();
                }
                return dt;
            }
        }

        public DataTable ListarCarenciaPorCid(string strCodPlano, int? codEst, int? codBen, int? codSeqBen)
        {
            String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringOracle"].ConnectionString;
            using (OracleConnection db = new OracleConnection(connectionString))
            {

                StringBuilder sqlCommand = new StringBuilder();

                sqlCommand.Append("SELECT A.CID, B.DESCID, A.DATLIMITE \n");
                sqlCommand.Append("FROM   BNF_BENDEPAGRAV A, \n");
                sqlCommand.Append("       DIAGNOSTICO B \n");
                sqlCommand.Append("WHERE  A.CODCON = :pCODCON\n");
                sqlCommand.Append("AND    A.CODEST = :pCODEST\n");
                sqlCommand.Append("AND    A.CODBEN = :pCODBEN\n");
                sqlCommand.Append("AND    A.CODSEQBEN = :pCODSEQBEN\n");
                //sqlCommand.Append("AND    TRUNC(A.DATLIMITE) >= TRUNC(SYSDATE) \n");
                sqlCommand.Append("AND    A.CID = B.CID(+) \n");

                OracleCommand dbCommand = db.CreateCommand();
                dbCommand.CommandText = sqlCommand.ToString();
                dbCommand.CommandType = CommandType.Text;

                #region "Parametros"
                dbCommand.Parameters.AddWithValue(":pCODCON", strCodPlano);
                dbCommand.Parameters.AddWithValue(":pCODEST", codEst);
                dbCommand.Parameters.AddWithValue(":pCODBEN", codBen);
                dbCommand.Parameters.AddWithValue(":pCODSEQBEN", codSeqBen);
                #endregion

                OracleDataAdapter adp = new OracleDataAdapter(dbCommand);
                DataTable dt = new DataTable();
                try
                {
                    adp.Fill(dt);
                    adp.Dispose();
                }
                finally
                {
                    if (dbCommand.Connection != null)
                    {
                        dbCommand.Connection.Close();
                    }
                    dbCommand.Dispose();
                }
                return dt;
            }
        }

        public bool IdentificacaoCronico(BeneficiarioACSDTO dto)
        {
            StringBuilder cmdSQL = new StringBuilder(400);
            cmdSQL.AppendFormat(@"SELECT 'PACIENTE CRÔNICO'{0}", Environment.NewLine);
            cmdSQL.AppendFormat(@"FROM BNF_BENEF_CRONICO{0}", Environment.NewLine);
            cmdSQL.AppendFormat(@"WHERE CODCON   =  '{0}'{1}", dto.CodigoEmpresa.Value, Environment.NewLine);
            cmdSQL.AppendFormat(@"AND CODEST = '{0}'{1}", dto.CodigoLoja.Value, Environment.NewLine);
            cmdSQL.AppendFormat(@"AND CODBEN    = '{0}'{1}", dto.CodigoMatricula.Value, Environment.NewLine);
            cmdSQL.AppendFormat(@"AND CODSEQBEN = '{0}'{1}", dto.CodigoSeqMatricula.Value, Environment.NewLine);
            cmdSQL.AppendFormat(@"AND DT_EXCLUSAO IS NULL");

            DataTable result = new DataTable();

            Connection.RecordSet(cmdSQL.ToString(), result, CommandType.Text);
            bool isCronico = result.Rows.Count != 0;


            cmdSQL = null;
            result.Dispose();
            result = null;

            return isCronico;
        }

        public string ValidaRestricaoFinanceira(BeneficiarioACSDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            param.Add(Connection.CreateParameterCursor());

            param.Add(Connection.CreateParameter("pCODCON", dto.CodigoEmpresa.DBValue, ParameterDirection.Input, dto.CodigoEmpresa.DbType));

            //Parametro pCODEST
            param.Add(Connection.CreateParameter("pCODEST", dto.CodigoLoja.DBValue, ParameterDirection.Input, dto.CodigoLoja.DbType));

            //Parametro pCODBEN
            param.Add(Connection.CreateParameter("pCODBEN", dto.CodigoMatricula.DBValue, ParameterDirection.Input, dto.CodigoMatricula.DbType));

            //Parametro pCODSEQBEN
            param.Add(Connection.CreateParameter("pCODSEQBEN", dto.CodigoSeqMatricula.DBValue, ParameterDirection.Input, dto.CodigoSeqMatricula.DbType));
            #endregion

            string query = "PRC_BNF_VALIDA_REST_FINANC";

            DataTable result = new DataTable();

            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            if (result.Rows.Count == 1)
            {
                return Convert.ToString(result.Rows[0]["RETORNO"]);
            }
            else
            {
                return string.Empty;
            }
        }

    }

}
