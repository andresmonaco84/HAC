using System.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using System;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class Paciente : Entity
    {
        /// <summary>
        /// Listar todos os registros limitando pela data da alta
        /// </summary>
        public PacienteDataTable Sel(PacienteDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //
            param.Add(Connection.CreateParameter("pATD_ATE_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
            //Parametro 
            param.Add(Connection.CreateParameter("pATD_ATE_TP_PACIENTE", dto.TpAtendimento.DBValue, ParameterDirection.Input, dto.TpAtendimento.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocalAtendimento.DBValue, ParameterDirection.Input, dto.IdtLocalAtendimento.DbType));

            //Parametro 
            param.Add(Connection.CreateParameter("pCAD_PES_NM_PESSOA", dto.NmPaciente.DBValue, ParameterDirection.Input, dto.NmPaciente.DbType));

            //Parametro 
            param.Add(Connection.CreateParameter("pCAD_CNV_CD_HAC_PRESTADOR", dto.CdEmpresa.DBValue, ParameterDirection.Input, dto.CdEmpresa.DbType));

            //Parametro 
            param.Add(Connection.CreateParameter("pCAD_PLA_CD_PLANO", dto.CdPlano.DBValue, ParameterDirection.Input, dto.CdPlano.DbType));
           
            #endregion

            PacienteDataTable result = new PacienteDataTable();
            string query = "PRC_CAD_ATENDIMENTO_S";
            try
            {
                //Executa o procedimento
                Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        /// <summary>
        /// Listar todos os registros NÃO limitando pela data da alta
        /// </summary>
        public PacienteDTO SelChave(PacienteDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //
            param.Add(Connection.CreateParameter("pATD_ATE_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
            //Parametro 
            param.Add(Connection.CreateParameter("pATD_ATE_TP_PACIENTE", dto.TpAtendimento.DBValue, ParameterDirection.Input, dto.TpAtendimento.DbType));


            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocalAtendimento.DBValue, ParameterDirection.Input, dto.IdtLocalAtendimento.DbType));

            #endregion

            PacienteDataTable result = new PacienteDataTable();
            string query = "PRC_CAD_ATENDIMENTO_SID";
            try
            {
                //Executa o procedimento
                Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            if (result.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return result.TypedRow(0);
            }
            
        }

        public DataTable SelDataHoraAlta(MovimentacaoDTO dto)
        {
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());
                        
            //Parametro pATD_ATE_ID
            param.Add(Connection.CreateParameter("pATD_ATE_ID", dto.IdtAtendimento.DBValue, ParameterDirection.Input, dto.IdtAtendimento.DbType));                        
            
            MovimentacaoDataTable result = new MovimentacaoDataTable();
            string query = "PRC_MTMD_CCIRURGICO_DT_ALTA";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }

        public int ObterQtdeRegistrosContaFaturadaComNF(decimal idtAtendimento)
        {
            DataTable result = new DataTable();

            string sqlString =
            "SELECT CCP.FAT_CCP_ID FROM TB_FAT_CCP_CONTA_CONS_PARC CCP\n" +
            "WHERE CCP.ATD_ATE_ID = #ATD_ATE_ID\n" +
            "AND   CCP.CAD_PAC_ID_PACIENTE = FNC_BUSCAR_PACIENTE_ATUAL(#ATD_ATE_ID)\n" +
            "AND   TRUNC(CCP.FAT_CCP_DT_PARCELA) = (SELECT TRUNC(INA.ATD_INA_DT_ALTA_ADM)\n" +
            "\t  \t\t\t                               FROM TB_ATD_INA_INT_ALTA INA\n" +
            "                                        WHERE INA.ATD_ATE_ID = #ATD_ATE_ID)\n" +
            "AND   CCP.ATD_ATE_TP_PACIENTE = (SELECT E.ATD_ATE_TP_PACIENTE FROM TB_ATD_ATE_ATENDIMENTO E WHERE E.ATD_ATE_ID = #ATD_ATE_ID)\n" +
            "AND   CCP.FAT_NOF_ID IS NOT NULL\n" +
            "AND   ((SELECT E.ATD_ATE_TP_PACIENTE FROM TB_ATD_ATE_ATENDIMENTO E WHERE E.ATD_ATE_ID = #ATD_ATE_ID) = 'E' OR\n" +
            "        CCP.TIS_MSI_CD_MOTIVOSAIDAINT != 51)";

            sqlString = sqlString.Replace("#ATD_ATE_ID", idtAtendimento.ToString());

            //Executa o procedimento
            Connection.RecordSet(sqlString, result, CommandType.Text);

            return result.Rows.Count;
        }

        public DataTable ObterPaciente(decimal idAtendimento)
        {
            DataTable result = new DataTable();
            string query = "SELECT ATENDIMENTO.ATD_ATE_ID,\n" +
                            "      PESSOA.CAD_PES_NM_PESSOA CAD_PES_NM_PESSOA,\n" +                            
                            "      ATENDIMENTO.ATD_ATE_TP_PACIENTE TP_PACIENTE,\n" +
                            "      ALTA.ATD_INA_DT_ALTA_ADM DT_ALTA,\n" +
                            "      ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO DT_INT,\n" +
                            "      ATENDIMENTO.ATD_ATE_HR_ATENDIMENTO HR_TRANSF,\n" +
                            "      ATENDIMENTO.CAD_SET_ID,\n" +
                            "      PESSOA.CAD_PES_DT_NASCIMENTO\n" +
                            " FROM TB_ATD_ATE_ATENDIMENTO       ATENDIMENTO,\n" + 
                            "      TB_CAD_PES_PESSOA            PESSOA,\n" + 
                            "      TB_ASS_PAT_PACIEATEND        PAC_ATE,\n" + 
                            "      TB_CAD_PAC_PACIENTE          PACIENTE,\n" +
                            "      TB_ATD_INA_INT_ALTA          ALTA\n" +
                            " WHERE ATENDIMENTO.ATD_ATE_ID       = " + idAtendimento.ToString() + "\n" +
                            " AND   ATENDIMENTO.ATD_ATE_ID       = ALTA.ATD_ATE_ID(+)\n" + 
                            " AND   PAC_ATE.ATD_ATE_ID           = ATENDIMENTO.ATD_ATE_ID\n" + 
                            " AND   PACIENTE.CAD_PAC_ID_PACIENTE = PAC_ATE.CAD_PAC_ID_PACIENTE\n" + 
                            " AND   PESSOA.CAD_PES_ID_PESSOA     = PACIENTE.CAD_PES_ID_PESSOA";                                 

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }

        public DataTable ObterPacienteSetor(decimal idAtendimento)
        {
            DataTable result = new DataTable();

            string query = "SELECT ATD.ATD_ATE_ID, QLE.CAD_SET_ID, SETOR.CAD_SET_DS_SETOR\n" +
                            "  FROM TB_ATD_IML_INT_MOV_LEITO IML JOIN\n" +
                            "       TB_CAD_QLE_QUARTO_LEITO QLE ON QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID JOIN\n" +
                            "       TB_ATD_ATE_ATENDIMENTO ATD ON ATD.ATD_ATE_ID = IML.ATD_ATE_ID JOIN\n" +
                            "       TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = QLE.CAD_SET_ID\n" +
                            "WHERE IML.ATD_IML_FL_STATUS = 'A' AND (IML.ATD_IML_DT_SAIDA IS NULL OR IML.ATD_IML_DT_SAIDA >= SYSDATE-3)\n" +
                            "  AND FNC_JUNTAR_DATA_HORA(IML.ATD_IML_DT_ENTRADA,IML.ATD_IML_HR_ENTRADA) =\n" +
                            "      (SELECT MAX(FNC_JUNTAR_DATA_HORA(IML2.ATD_IML_DT_ENTRADA, IML2.ATD_IML_HR_ENTRADA))\n" +
                            "         FROM TB_ATD_IML_INT_MOV_LEITO IML2\n" +
                            "        WHERE IML2.ATD_ATE_ID = ATD.ATD_ATE_ID AND IML2.ATD_IML_FL_STATUS = 'A')\n" +
                            "  AND ATD.ATD_ATE_ID = " + idAtendimento.ToString() + "\n" +
                            "UNION\n" +
                            "SELECT IMS.ATD_ATE_ID, IMS.CAD_SET_ID_SETOR, SETOR.CAD_SET_DS_SETOR\n" +
                            "  FROM TB_ATD_IMS_INT_MOV_SETOR IMS JOIN\n" +
                            "       TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = IMS.CAD_SET_ID_SETOR\n" +
                            "WHERE IMS.ATD_IMS_FL_STATUS = 'A' AND IMS.CAD_SET_ID_SETOR IN (22,61)\n" +
                            "  AND IMS.ATD_IMS_DT_ENTRADA >= SYSDATE-2 AND IMS.ATD_IMS_DT_SAIDA IS NULL\n" +
                            "  AND IMS.ATD_ATE_ID NOT IN (SELECT ATD_ATE_ID FROM TB_ATD_IML_INT_MOV_LEITO WHERE ATD_ATE_ID = IMS.ATD_ATE_ID)\n" +
                            "  AND IMS.ATD_ATE_ID = " + idAtendimento.ToString();

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }

        public DataTable ListarTransferenciasRecentesUTI()
        {
            string sqlString = "SELECT ATD_ATE_ID, CAD_SET_ID, CAD_SET_ID_ATUAL FROM\n" +
                                "(SELECT IML.ATD_ATE_ID, SETOR.CAD_SET_ID,\n" +
                                "      (SELECT QLE2.CAD_SET_ID\n" +
                                "        FROM TB_ATD_IML_INT_MOV_LEITO IML2\n" +
                                "        JOIN TB_CAD_QLE_QUARTO_LEITO QLE2 ON QLE2.CAD_QLE_ID = IML2.CAD_CAD_QLE_ID\n" +
                                "        JOIN TB_ATD_ATE_ATENDIMENTO ATD2 ON ATD2.ATD_ATE_ID = IML2.ATD_ATE_ID\n" +
                                "        JOIN TB_CAD_SET_SETOR SETOR2 ON SETOR2.CAD_SET_ID = QLE2.CAD_SET_ID\n" +
                                "      WHERE IML2.ATD_IML_FL_STATUS = 'A' AND\n" +
                                "            IML2.ATD_IML_DT_SAIDA IS NULL AND\n" +
                                "            IML2.ATD_ATE_ID = IML.ATD_ATE_ID) CAD_SET_ID_ATUAL\n" +
                                "  FROM TB_ATD_IML_INT_MOV_LEITO IML JOIN\n" +
                                "       TB_CAD_QLE_QUARTO_LEITO QLE ON QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID JOIN\n" +
                                "       TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = QLE.CAD_SET_ID\n" +
                                "WHERE FNC_JUNTAR_DATA_HORA(IML.ATD_IML_DT_SAIDA, IML.ATD_IML_HR_SAIDA) >= SYSDATE-1\n" +
                                "AND SETOR.CAD_SET_DS_SETOR LIKE '%UTI%')\n" +
                                "WHERE CAD_SET_ID != CAD_SET_ID_ATUAL";

            DataTable result = new DataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);
            return result;
        }       

        public DataTable ObterPacienteEndereco(decimal idAtendimento)
        {
            DataTable result = new DataTable();
            string query = "SELECT L.TIS_TLG_DS_TPLOGRADOURO || ' ' || E.CAD_END_NM_LOGRADOURO || ', ' || E.CAD_END_DS_NUMERO || ' ' || E.CAD_END_DS_COMPLEMENTO || ', ' || E.CAD_END_NM_BAIRRO || ', ' || M.AUX_MUN_NM_MUNICIPIO || '/' || E.CAD_END_SG_UF || ' - ' || E.CAD_END_CD_CEP ENDERECO\n" +
                            "FROM TB_CAD_END_ENDERECO E JOIN\n" +
                            "     TB_AUX_MUN_MUNICIPIO M ON (M.AUX_MUN_CD_IBGE = E.AUX_MUN_CD_IBGE AND M.AUX_MUN_SG_UF = E.CAD_END_SG_UF) JOIN\n" +
                            "     TB_TIS_TLG_TP_LOGRADOURO L ON L.TIS_TLG_CD_TPLOGRADOURO = E.TIS_TLG_CD_TPLOGRADOURO\n" +
                            "WHERE E.CAD_END_ID_ENDERECO = (SELECT MAX(END2.CAD_END_ID_ENDERECO)\n" +
                            "                                FROM TB_CAD_END_ENDERECO END2 JOIN\n" +
                            "                                     TB_CAD_PAC_PACIENTE PAC ON PAC.CAD_PES_ID_PESSOA = END2.CAD_PES_ID_PESSOA JOIN\n" +
                            "                                     TB_ASS_PAT_PACIEATEND PAT ON PAT.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE\n" +
                            "                                WHERE PAT.ATD_ATE_ID = " + idAtendimento.ToString() + ")";

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }

        public DataTable ListarInternacoesAnterioresPaciente(decimal idAtendimento)
        {
            string sqlString = "SELECT ASS_PAT.ATD_ATE_ID,\n" +
                                "       PES.CAD_PES_NM_PESSOA,\n" +
                                "       FNC_JUNTAR_DATA_HORA(ATD.ATD_ATE_DT_ATENDIMENTO, ATD.ATD_ATE_HR_ATENDIMENTO) DT_ATENDIMENTO,\n" +
                                "       (SELECT FNC_JUNTAR_DATA_HORA(INA.ATD_INA_DT_ALTA_ADM, INA.ATD_INA_HR_ALTA_ADM)\n" +
                                "          FROM TB_ATD_INA_INT_ALTA INA\n" +
                                "         WHERE INA.ATD_ATE_ID = ASS_PAT.ATD_ATE_ID) DT_ALTA\n" +
                                "  FROM TB_ASS_PAT_PACIEATEND ASS_PAT JOIN\n" +
                                "       TB_CAD_PAC_PACIENTE PAC ON PAC.CAD_PAC_ID_PACIENTE = ASS_PAT.CAD_PAC_ID_PACIENTE JOIN\n" +
                                "       TB_CAD_PES_PESSOA PES ON PES.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA JOIN\n" +
                                "       TB_ATD_ATE_ATENDIMENTO ATD ON ATD.ATD_ATE_ID = ASS_PAT.ATD_ATE_ID\n" +
                                "WHERE ASS_PAT.CAD_PAC_ID_PACIENTE IN\n" +
                                "      (SELECT PAT.CAD_PAC_ID_PACIENTE\n" +
                                "         FROM TB_ASS_PAT_PACIEATEND PAT\n" +
                                "        WHERE PAT.ATD_ATE_ID = " + idAtendimento + ") AND\n" +
                                "      ATD.ATD_ATE_ID < " + idAtendimento + " AND\n" +
                                "      ATD.ATD_ATE_TP_PACIENTE = 'I'\n" +
                                "ORDER BY 2,3 DESC,1 DESC";

            DataTable result = new DataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);
            return result;
        }

        public bool AnteriorControleConsumo(int idAtendimento)
        {
            DataTable result = new DataTable();
            string query = "SELECT IML.ATD_ATE_ID\n" +
                           "  FROM TB_ATD_IML_INT_MOV_LEITO IML JOIN\n" +
                           "       TB_CAD_QLE_QUARTO_LEITO QLE ON QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID JOIN\n" +
                           "       TB_CAD_SET_SETOR CSET ON CSET.CAD_SET_ID = QLE.CAD_SET_ID JOIN\n" +
                           "       TB_ATD_ATE_ATENDIMENTO ATD ON ATD.ATD_ATE_ID = IML.ATD_ATE_ID JOIN\n" +
                           "       TB_MTMD_MATMED_SETOR MS ON MS.CAD_SET_ID = QLE.CAD_SET_ID\n" +
                           "WHERE IML.ATD_IML_DT_SAIDA IS NULL AND\n" +
                           "      IML.ATD_IML_FL_STATUS = 'A' AND\n" +
                           "      QLE.CAD_SET_ID IN (SELECT DISTINCT C.CAD_SET_ID\n" +
                           "                           FROM TB_MTMD_MATMED_SETOR C JOIN\n" +
                           "                                TB_CAD_SET_SETOR SETOR ON C.CAD_SET_ID = SETOR.CAD_SET_ID\n" +
                           "                          WHERE C.CAD_UNI_ID_UNIDADE = 244 AND\n" +
                           "                                C.CAD_LAT_ID_LOCAL_ATENDIMENTO = 29 AND\n" +
                           "                                C.MTMD_CONTROLA_CONSUMO_PAC = 1) AND\n" +
                           "      FNC_JUNTAR_DATA_HORA(ATD.ATD_ATE_DT_ATENDIMENTO, ATD.ATD_ATE_HR_ATENDIMENTO) < MS.MTMD_CONTROLA_CONS_PAC_DATA AND\n" +
                           "      IML.ATD_ATE_ID = " + idAtendimento;            

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return result.Rows.Count > 0;
        }
    }
 }