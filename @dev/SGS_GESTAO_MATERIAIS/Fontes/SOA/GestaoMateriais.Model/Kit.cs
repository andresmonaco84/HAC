using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class Kit : Entity
    {
        public void Gravar(KitDTO dto, int idUsuario)
        {
            string query;
            if (dto.IdKit.Value.IsNull)
            {
                DataTable dtNewID = new DataTable();
                string queryID = "SELECT SEQ_FAT_KMM_01.NEXTVAL FROM DUAL";

                //Executa o procedimento
                Connection.RecordSet(queryID, dtNewID, CommandType.Text);
                dto.IdKit.Value = dtNewID.Rows[0][0].ToString();

                query = "INSERT INTO TB_CAD_MTMD_KIT(CAD_MTMD_KIT_ID, CAD_MTMD_KIT_STATUS, CAD_MTMD_KIT_DSC, SEG_USU_ID_USUARIO, CAD_MTMD_KIT_DATA) " +
                        " VALUES (" + dto.IdKit.Value + ", " + dto.Ativo.Value + ", '" + dto.Descricao.Value + "', " + idUsuario.ToString() + ", SYSDATE)";
            }
            else
            {
                query = "UPDATE TB_CAD_MTMD_KIT SET " +
                        "   CAD_MTMD_KIT_DSC = '" + dto.Descricao.Value + "'" +
                        " , CAD_MTMD_KIT_STATUS = " + dto.Ativo.Value +
                        " , SEG_USU_ID_USUARIO = " + idUsuario.ToString() +
                        " , CAD_MTMD_KIT_DATA = SYSDATE" +
                        " WHERE CAD_MTMD_KIT_ID = " + dto.IdKit.Value;
            }
            Connection.ExecuteCommand(query);
        }

        public void GravarItem(KitDTO dto, int idUsuario)
        {
            DataTable dtExistente = new DataTable();
            string queryRegExistente = "select t.cad_mtmd_kit_id\n" +
                                       "  from TB_CAD_MTMD_KIT_ITEM t\n" +
                                       "where t.cad_mtmd_kit_id = " + dto.IdKit.Value + " and\n" + 
                                       "      t.cad_mtmd_id = " + dto.IdProduto.Value;
            //Executa o procedimento
            Connection.RecordSet(queryRegExistente, dtExistente, CommandType.Text);
            
            string queryExec;
            if (dtExistente.Rows.Count == 0)
                queryExec = "INSERT INTO TB_CAD_MTMD_KIT_ITEM(CAD_MTMD_KIT_ID, CAD_MTMD_ID, CAD_MTMD_QTDE, SEG_USU_ID_USUARIO, CAD_MTMD_KIT_ITEM_DATA) " +
                           " VALUES (" + dto.IdKit.Value + ", " + dto.IdProduto.Value + ", " + dto.QtdeItem.Value + ", " + idUsuario.ToString() + ", SYSDATE)";
            else
                queryExec = "UPDATE TB_CAD_MTMD_KIT_ITEM SET " +
                            "   CAD_MTMD_QTDE = " + dto.QtdeItem.Value +
                            " , SEG_USU_ID_USUARIO = " + idUsuario.ToString() +
                            " , CAD_MTMD_KIT_ITEM_DATA = SYSDATE" +
                            " WHERE CAD_MTMD_KIT_ID = " + dto.IdKit.Value +
                              " AND CAD_MTMD_ID = " + dto.IdProduto.Value;

            Connection.ExecuteCommand(queryExec);
        }

        public void ExcluirItem(KitDTO dto)
        {
            string queryExec = "DELETE TB_CAD_MTMD_KIT_ITEM " +                            
                              " WHERE CAD_MTMD_KIT_ID = " + dto.IdKit.Value +
                              " AND CAD_MTMD_ID = " + dto.IdProduto.Value;

            Connection.ExecuteCommand(queryExec);
        }

        public KitDataTable Listar(KitDTO dto)
        {
            string filtros = string.Empty;

            if (!dto.IdKit.Value.IsNull)
                filtros += " AND CAD_MTMD_KIT_ID = " + dto.IdKit.Value.ToString() + "\n";

            if (!dto.Ativo.Value.IsNull)
                filtros += " AND CAD_MTMD_KIT_STATUS = " + dto.Ativo.Value.ToString() + "\n";

            if (!dto.IdSetor.Value.IsNull)
                filtros += " AND CAD_SET_ID = " + dto.IdSetor.Value.ToString() + "\n";

            string sqlString = string.Format("SELECT\n" +
                                            "       CAD_MTMD_KIT_ID,\n" +
                                            "       CAD_MTMD_KIT_STATUS,\n" +
                                            "       CAD_MTMD_KIT_DSC,\n" +
                                            "       SEG_USU_ID_USUARIO,\n" +                                            
                                            "       CAD_MTMD_KIT_DATA,\n" +
                                            "       CAD_SET_ID\n" +
                                            "FROM TB_CAD_MTMD_KIT \n" +                                            
                                            "WHERE NULL IS NULL {0} \n" +
                                            "ORDER BY CAD_MTMD_KIT_DSC ",
                                            filtros);

            KitDataTable result = new KitDataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);

            return result;
        }

        public KitDataTable ListarItem(KitDTO dto)
        {
            string filtros = string.Empty;

            if (!dto.IdKit.Value.IsNull)
                filtros += " AND KIT.CAD_MTMD_KIT_ID = " + dto.IdKit.Value.ToString() + "\n";

            if (!dto.IdProduto.Value.IsNull)
                filtros += " AND KIT.CAD_MTMD_ID = " + dto.IdProduto.Value.ToString() + "\n";

            string sqlString = string.Format("SELECT\n" +
                                            "       KIT.CAD_MTMD_KIT_ID,\n" +
                                            "       KIT.CAD_MTMD_ID,\n" +
                                            "       FNC_MTMD_SOUNDALIKE(M.CAD_MTMD_NOMEFANTASIA,M.CAD_MTMD_GRUPO_ID) CAD_MTMD_NOMEFANTASIA,\n" +
                                            "       KIT.CAD_MTMD_QTDE,\n" +
                                            "       KIT.SEG_USU_ID_USUARIO,\n" +
                                            "       KIT.CAD_MTMD_KIT_ITEM_DATA,\n" +
                                            "       M.CAD_MTMD_GRUPO_ID\n" +
                                            "FROM TB_CAD_MTMD_KIT_ITEM KIT JOIN TB_CAD_MTMD_MAT_MED M ON M.CAD_MTMD_ID = KIT.CAD_MTMD_ID \n" +
                                            "WHERE NULL IS NULL {0} \n" +
                                            "ORDER BY M.CAD_MTMD_NOMEFANTASIA ",
                                            filtros);

            KitDataTable result = new KitDataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);

            return result;
        }

        public DataTable ListarSaldo(int? idSaldo, MovimentacaoDTO dto)
        {
            string filtros = string.Empty;

            if (idSaldo != null)
                filtros += " AND KIS.CAD_MTMD_KIT_SALDO_ID = " + idSaldo.Value.ToString() + "\n";

            if (!dto.IdtProduto.Value.IsNull)
                filtros += " AND KIS.CAD_MTMD_ID = " + dto.IdtProduto.Value.ToString() + "\n";

            if (!dto.CodLote.Value.IsNull)
                filtros += " AND KIS.MTMD_COD_LOTE = '" + dto.CodLote.Value.ToString() + "'\n";

            string sqlString = string.Format("SELECT KIS.CAD_MTMD_KIT_SALDO_ID ,\n" +
                                            "       KIS.CAD_MTMD_KIT_ID        ,\n" +
                                            "       KIS.CAD_SET_ID             ,\n" +
                                            "       KIS.CAD_MTMD_FILIAL_ID     ,\n" +
                                            "       KIS.CAD_MTMD_ID            ,\n" +
                                            "       KIS.MTMD_COD_LOTE          ,\n" +
                                            "       KIS.CAD_MTMD_QTDE          ,\n" +
                                            "       KIS.SEG_USU_ID_USUARIO     ,\n" +
                                            "       KIS.CAD_MTMD_KIT_ITEM_DATA ,\n" +
                                            "       KIT.CAD_MTMD_KIT_DSC       ,\n" +
                                            "       SETOR.CAD_SET_DS_SETOR     ,\n" +
                                            "       MM.CAD_MTMD_NOMEFANTASIA\n" +
                                            "FROM TB_CAD_MTMD_KIT_ITEM_SALDO KIS JOIN\n" +
                                            "     TB_CAD_MTMD_KIT KIT ON KIT.CAD_MTMD_KIT_ID = KIS.CAD_MTMD_KIT_ID JOIN\n" +
                                            "     TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = KIS.CAD_SET_ID JOIN\n" +
                                            "     TB_CAD_MTMD_MAT_MED MM ON MM.CAD_MTMD_ID = KIS.CAD_MTMD_ID\n" +
                                            "WHERE NULL IS NULL {0} \n" +
                                            "ORDER BY KIT.CAD_MTMD_KIT_DSC, SETOR.CAD_SET_DS_SETOR, MM.CAD_MTMD_NOMEFANTASIA, KIS.MTMD_COD_LOTE ",
                                            filtros);

            DataTable result = new DataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);

            return result;
        }

        public int GerarSaldoID()
        {
            DataTable dtNewID = new DataTable();
            string queryID = "SELECT SEQ_MTMD_KIT_SALDO.NEXTVAL FROM DUAL";

            //Executa o procedimento
            Connection.RecordSet(queryID, dtNewID, CommandType.Text);
            return int.Parse(dtNewID.Rows[0][0].ToString());
        }

        public void InsSaldoKit(int idSaldo, int idKit, MovimentacaoDTO dto)
        {
            string query;
            string codLote = "NULL";
            if (!dto.CodLote.Value.IsNull)
                codLote = "'" + dto.CodLote.Value + "'";

            query = "INSERT INTO TB_CAD_MTMD_KIT_ITEM_SALDO(CAD_MTMD_KIT_SALDO_ID, CAD_MTMD_KIT_ID, CAD_SET_ID, CAD_MTMD_FILIAL_ID, CAD_MTMD_ID, MTMD_COD_LOTE, CAD_MTMD_QTDE, SEG_USU_ID_USUARIO, CAD_MTMD_KIT_ITEM_DATA) " +
                    " VALUES (" + idSaldo + ", " + idKit + ", " + dto.IdtSetor.Value + ", " + dto.IdtFilial.Value + ", " + dto.IdtProduto.Value + "," + codLote + ", " + dto.Qtde.Value + ", " + dto.IdtUsuario.Value + ", SYSDATE)";

            Connection.ExecuteCommand(query);
        }

        public void UpdSaldoKit(int idSaldo, MovimentacaoDTO dto)
        {
            string query;
            query = "UPDATE TB_CAD_MTMD_KIT_ITEM_SALDO SET " +
                    "   CAD_MTMD_QTDE = " + dto.Qtde.Value +
                    " , SEG_USU_ID_USUARIO = " + dto.IdtUsuario.Value +
                    " , CAD_MTMD_KIT_ITEM_DATA = SYSDATE" +
                    " WHERE CAD_MTMD_KIT_SALDO_ID = " + idSaldo +
                    "   AND CAD_MTMD_ID = " + dto.IdtProduto.Value;

            if (!dto.CodLote.Value.IsNull)
                query += " AND MTMD_COD_LOTE = '" + dto.CodLote.Value.ToString() + "'\n";

            Connection.ExecuteCommand(query);
        }

        public void UpdSaldoKitImpressp(int idSaldo)
        {
            string query;
            query = "UPDATE TB_CAD_MTMD_KIT_ITEM_SALDO SET " +
                    "   CAD_MTMD_KIT_IMPRESSO = 1" +
                    " WHERE CAD_MTMD_KIT_SALDO_ID = " + idSaldo;

            Connection.ExecuteCommand(query);
        }

        public KitDataTable ListarMateriaisAplicaMedicamento(MaterialMedicamentoDTO dtoMedicamento)
        {
            string filtros = " AND ASS_KM.CAD_MTMD_ID = " + dtoMedicamento.Idt.Value;
            string sqlString = "SELECT KI.CAD_MTMD_ID,\n" +
                                "      SUM(KI.CAD_MTMD_QTDE) CAD_MTMD_QTDE\n" +
                                "  FROM TB_CAD_MTMD_ASS_KIT ASS_KM JOIN\n" +
                                "       TB_CAD_MTMD_MAT_MED MED ON MED.CAD_MTMD_ID = ASS_KM.CAD_MTMD_ID JOIN\n" +
                                "       TB_CAD_MTMD_KIT_ITEM KI ON KI.CAD_MTMD_KIT_ID = ASS_KM.CAD_MTMD_KIT_ID JOIN\n" +
                                "       TB_CAD_MTMD_MAT_MED MAT ON MAT.CAD_MTMD_ID = KI.CAD_MTMD_ID\n" +
                                " WHERE ASS_KM.ASS_FL_ATIVO = 1\n" +
                                "   AND MAT.CAD_MTMD_GRUPO_ID = 6\n";
            string sqlGroupBy = " GROUP BY KI.CAD_MTMD_ID";
            string sqlQuery = sqlString + filtros + sqlGroupBy;

            KitDataTable result = new KitDataTable();
            Connection.RecordSet(sqlQuery, result, CommandType.Text);

            if (result.Rows.Count == 0 && dtoMedicamento.IdtPrincipioAtivo.Value != 0)
            {
                filtros = " AND MED.CAD_MTMD_PRIATI_ID = " + dtoMedicamento.IdtPrincipioAtivo.Value + "\n";
                sqlQuery = sqlString + filtros + sqlGroupBy;

                result = new KitDataTable();
                Connection.RecordSet(sqlQuery, result, CommandType.Text);
            }

            return result;
        }

        public KitDataTable ListarMedicamentosAssociadosAplicaKit(KitDTO dto)
        {
            string filtros = " AND ASS_KM.CAD_MTMD_KIT_ID = " + dto.IdKit.Value;
            string sqlString = "SELECT DISTINCT ASS_KM.CAD_MTMD_KIT_ID,\n" +
                                "               MED.CAD_MTMD_ID,\n" +
                                "               MED.CAD_MTMD_NOMEFANTASIA\n" +
                                "  FROM TB_CAD_MTMD_ASS_KIT ASS_KM JOIN\n" +
                                "       TB_CAD_MTMD_MAT_MED MED ON MED.CAD_MTMD_ID = ASS_KM.CAD_MTMD_ID JOIN\n" +
                                "       TB_CAD_MTMD_KIT_ITEM KI ON KI.CAD_MTMD_KIT_ID = ASS_KM.CAD_MTMD_KIT_ID\n" +
                                " WHERE ASS_KM.ASS_FL_ATIVO = 1\n" +
                                "   AND MED.CAD_MTMD_GRUPO_ID = 1\n";
            string sqlQuery = sqlString + filtros;

            KitDataTable result = new KitDataTable();
            Connection.RecordSet(sqlQuery, result, CommandType.Text);

            return result;
        }

        public void InsMedicamentoAssociadoAplicaKit(KitDTO dto, int idUsuario)
        {
            string query;

            query = "INSERT INTO TB_CAD_MTMD_ASS_KIT(CAD_MTMD_ID, CAD_MTMD_KIT_ID, ASS_FL_ATIVO, SEG_USU_ID_USUARIO, SEG_DT_ATUALIZACAO) " +
                    " VALUES (" + dto.IdProduto.Value + ", " + dto.IdKit.Value + ", 1, " + idUsuario + ", SYSDATE)";

            Connection.ExecuteCommand(query);
        }

        public void ExcluirMedicamentoAssociadoAplicaKit(KitDTO dto, int idUsuario)
        {
            string query;
            query = "UPDATE TB_CAD_MTMD_ASS_KIT SET " +
                    "   ASS_FL_ATIVO = 0 \n" +
                    " , SEG_USU_ID_USUARIO = " + idUsuario +
                    " , SEG_DT_ATUALIZACAO = SYSDATE" +
                    " WHERE CAD_MTMD_KIT_ID = " + dto.IdKit.Value +
                    "   AND CAD_MTMD_ID = " + dto.IdProduto.Value;

            Connection.ExecuteCommand(query);
        }
    }
}