using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class LivroRegistroMovimentos : Entity
    {
        public LivroRegistroMovimentosDataTable GerarDados(LivroRegistroMovimentosDTO dto, int ano, int mes, bool excluirDadoPosterior)
        {
            string query = "PRC_MTMD_LIR_LIVRO_GERAR";

            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));
                        
            //Parametro pANO_REF
            param.Add(Connection.CreateParameter("pANO_REF", ano, ParameterDirection.Input, DbType.Int16));

            //Parametro pMES_REF
            param.Add(Connection.CreateParameter("pMES_REF", mes, ParameterDirection.Input, DbType.Int16));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.UsuarioCriacao.DBValue, ParameterDirection.Input, dto.UsuarioCriacao.DbType));

            //Parametro pCAD_MTMD_ID
            if (!dto.IdtProduto.Value.IsNull)
                param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            if (excluirDadoPosterior)
                param.Add(Connection.CreateParameter("pEXCLUIR_DADO_POSTERIOR", 1, ParameterDirection.Input, DbType.Byte));            

            #endregion

            // Executa o Procedimento
            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);

            if (!dto.IdtProduto.Value.IsNull)
                return this.Listar(dto, ano, mes);
            else
                return new LivroRegistroMovimentosDataTable();
        }

        public LivroRegistroMovimentosDataTable Listar(LivroRegistroMovimentosDTO dto, int ano, int mes)
        {
            string filtros = string.Empty;

            if (!dto.IdtProduto.Value.IsNull)
                filtros += " AND LIR.CAD_MTMD_ID = " + dto.IdtProduto.Value.ToString() + "\n";
                        
            string sqlString = string.Format("SELECT MTMD_LIR_ID                   ,\n" +
                                            "      LIR.CAD_UNI_ID_UNIDADE         ,\n" +
                                            "      LIR.CAD_MTMD_ID                ,\n" +
                                            "      MTMD_LIR_DT_REGISTRO           ,\n" +
                                            "      MTMD_LIR_DS_HISTORICO          ,\n" +
                                            "      MTMD_LIR_DS_HISTORICO_MANUAL   ,\n" +
                                            "      MTMD_LIR_QT_ENTRADA            ,\n" +
                                            "      MTMD_LIR_QT_SAIDA              ,\n" +
                                            "      MTMD_LIR_QT_PERDA              ,\n" +
                                            "      MTMD_LIR_QT_ESTOQUE            ,\n" +
                                            "      MTMD_LIR_DS_OBSERVACAO         ,\n" +
                                            "      MTMD_LIR_DT_CRIACAO            ,\n" +
                                            "      LIR.SEG_USU_ID_USUARIO_CRIACAO     ,\n" +
                                            "      LIR.MTMD_LIR_DT_ATUALIZACAO        ,\n" +
                                            "      LIR.SEG_USU_ID_USUARIO_ATUALIZACAO ,\n" +
                                            "      LIR.MTMD_LIR_FL_AUDITADO           ,\n" +
                                            "      LIR.CAD_MTMD_FILIAL_ID             ,\n" +
                                            "      PROD.CAD_MTMD_CODMNE               ,\n" +
                                            "      PROD.CAD_MTMD_NOMEFANTASIA         ,\n" +
                                            "      PROD.CAD_MTMD_CD_GRUPO_ANVISA\n" +
                                            "FROM TB_MTMD_LIR_LIVRO_REGISTRO LIR JOIN\n" +
                                            "     TB_CAD_MTMD_MAT_MED PROD ON PROD.CAD_MTMD_ID = LIR.CAD_MTMD_ID\n" +
                                            "WHERE TO_CHAR(LIR.MTMD_LIR_DT_REGISTRO,'YYYYMM') = '{0}' AND\n" +
                                            "      LIR.CAD_MTMD_FILIAL_ID = {1} AND\n" +
                                            "      LIR.CAD_UNI_ID_UNIDADE = {2} {3} \n" +
                                            "ORDER BY PROD.CAD_MTMD_NOMEFANTASIA, LIR.MTMD_LIR_DT_REGISTRO, LIR.MTMD_LIR_ID", ano.ToString() + mes.ToString().PadLeft(2, '0'),
                                                                                                                              dto.IdtFilial.Value,
                                                                                                                              dto.IdtUnidade.Value,
                                                                                                                              filtros);

            LivroRegistroMovimentosDataTable result = new LivroRegistroMovimentosDataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);

            return result;
        }

        public void AtualizarItem(LivroRegistroMovimentosDTO dto)
        {            
            string query = string.Format("UPDATE TB_MTMD_LIR_LIVRO_REGISTRO LIR\n" +
                                                "SET LIR.MTMD_LIR_DS_HISTORICO_MANUAL = '{0}',\n" +
                                                "    LIR.MTMD_LIR_DS_OBSERVACAO = '{1}',\n" +
                                                "    LIR.SEG_USU_ID_USUARIO_ATUALIZACAO = {2},\n" +
                                                "    LIR.MTMD_LIR_DT_ATUALIZACAO = SYSDATE\n" +
                                                "WHERE LIR.MTMD_LIR_ID = {3}", dto.HistoricoManual.Value,
                                                                               dto.Observacao.Value,
                                                                               dto.UsuarioAlteracao.Value,
                                                                               dto.IdtLivro.Value);

            Connection.ExecuteCommand(query);
        }

        public DataTable ObterResponsavel(string tipoReponsavel, int idUnidade)
        {
            string sqlString = string.Format("SELECT RUD.TIS_CPR_CD_CONSELHOPROF CD_CONSELHOPROF,\n" +
                                            "       RUD.CAD_PRO_NR_CONSELHO NR_CONSELHO,\n" +
                                            "       PES.CAD_PES_NM_PESSOA NM_PESSOA\n" +
                                            "  FROM TB_CAD_RUD_RESPONSAVEL_UNIDADE RUD JOIN\n" +
                                            "       TB_CAD_PES_PESSOA PES ON PES.CAD_PES_ID_PESSOA = RUD.CAD_PES_ID_PESSOA\n" +
                                            "WHERE RUD.CAD_RUD_TP_RESPONSAVEL = '{0}' AND\n" +
                                            "      RUD.CAD_UNI_ID_UNIDADE = {1}", tipoReponsavel, idUnidade);

            DataTable result = new DataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);

            return result;
        }

        public DateTime? ObterUltimaDataRegistro(int idProduto, int idUnidade)
        {
            string sqlString = "SELECT MAX(LIR.MTMD_LIR_DT_REGISTRO)\n" +
                                "FROM TB_MTMD_LIR_LIVRO_REGISTRO LIR\n" +
                                "WHERE LIR.CAD_MTMD_FILIAL_ID = 1 AND\n" +
                                "      LIR.MTMD_LIR_DT_REGISTRO > TO_DATE('01062020','DDMMYYYY') AND\n" +
                                "      LIR.CAD_UNI_ID_UNIDADE = " + idUnidade + " AND\n" + 
                                "      LIR.CAD_MTMD_ID = " + idProduto;
 
            DataTable result = new DataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);

            if (string.IsNullOrEmpty(result.Rows[0][0].ToString()))
                return null;
            else
                return DateTime.Parse(result.Rows[0][0].ToString());
        }
    }
}