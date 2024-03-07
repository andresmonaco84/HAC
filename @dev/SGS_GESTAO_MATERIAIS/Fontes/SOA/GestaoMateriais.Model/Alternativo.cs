using System;
using System.Collections.Generic;
using System.Text;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using System.Data.OracleClient;
using System.Data;


namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class Alternativo : Entity
    {
        public DataTable InformacoesInternadoAla(int? nroInternacao, string nome)
        {
            string connectionString = "";
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringOracle"].ConnectionString;
            using (OracleConnection db = new OracleConnection(connectionString))
            {
                StringBuilder cmdSql = new StringBuilder(700);
                cmdSql.AppendFormat(@"SELECT INTER.NOMPAC,      EMPRES.NOMEMP, {0}", Environment.NewLine);
                cmdSql.AppendFormat(@"       EMPRES.CODCON,     SETOR.DS_SETOR,{0}", Environment.NewLine);
                cmdSql.AppendFormat(@"       QUARTO.COD_QUARTO, QUARTO.COD_LEITO {0}", Environment.NewLine);
                cmdSql.AppendFormat(@"FROM TB_INTERNADO     INTER,{0}", Environment.NewLine);
                cmdSql.AppendFormat(@"     TB_QUARTO        QUARTO,{0}", Environment.NewLine);
                cmdSql.AppendFormat(@"     TB_SETOR         SETOR,{0}", Environment.NewLine);
                cmdSql.AppendFormat(@"     TB_TRANSFERENCIA TRANSF,{0}", Environment.NewLine);
                cmdSql.AppendFormat(@"     EMPRESA          EMPRES{0}", Environment.NewLine);
                cmdSql.AppendFormat(@"WHERE TRANSF.NR_SEQINTER = INTER.nr_seqinter{0}", Environment.NewLine);
                cmdSql.AppendFormat(@"AND   QUARTO.COD_QUARTO  = TRANSF.COD_QUARTO{0}", Environment.NewLine);
                cmdSql.AppendFormat(@"AND   QUARTO.COD_LEITO    = TRANSF.COD_LEITO{0}", Environment.NewLine);
                cmdSql.AppendFormat(@"AND   SETOR.CD_SETOR     = QUARTO.CD_SETOR{0}", Environment.NewLine);
                cmdSql.AppendFormat(@"AND   EMPRES.CODCON      = INTER.CODCON{0}", Environment.NewLine);
                if (nroInternacao != null)
                {
                    cmdSql.AppendFormat(@"AND   INTER.NR_SEQINTER  = {1}{0}", Environment.NewLine, nroInternacao);
                }
                if (nome.Length != 0)
                {
                    cmdSql.AppendFormat(@"AND INTER.NOMPAC LIKE '{1}'{0}", Environment.NewLine, nome);
                }
                cmdSql.AppendFormat(@"AND   TRANSF.DT_SAIDA IS NULL AND TRANSF.HORA_SAIDA IS NULL");

                using (OracleCommand dbCommand = db.CreateCommand())
                {
                    dbCommand.CommandText = cmdSql.ToString();
                    dbCommand.CommandType = CommandType.Text;
                    using (OracleDataAdapter adp = new OracleDataAdapter(dbCommand))
                    {
                        DataTable dt = new DataTable();
                        dt.TableName = "Dados";
                        adp.Fill(dt);

                        return dt;
                    }
                }
            }
        }
    }
}
