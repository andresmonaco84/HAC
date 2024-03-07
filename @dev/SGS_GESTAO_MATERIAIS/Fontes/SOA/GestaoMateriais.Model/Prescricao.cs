using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class Prescricao : Entity
    {
        public PrescricaoDTO Gravar(PrescricaoDTO dto)
        {
            string query;
            if (dto.IdPrescricao.Value.IsNull)
            {
                DataTable dtNewID = new DataTable();
                string queryID = "SELECT SEQ_MTMD_PRESCRICAO.NEXTVAL FROM DUAL";

                //Executa o procedimento
                Connection.RecordSet(queryID, dtNewID, CommandType.Text);
                dto.IdPrescricao.Value = dtNewID.Rows[0][0].ToString();

                query = string.Format("INSERT INTO TB_CAD_MTMD_PRESCRICAO(CAD_MTMD_PRESCRICAO_ID, ATD_ATE_ID, CAD_MTMD_CRM, CAD_MTMD_PRESCRICAO_STATUS, SEG_USU_ID_INCLUSAO, " +
                                      "CAD_MTMD_DT_INCLUSAO, CAD_PSO_SG_UF_CONSELHO, CAD_MTMD_PRC_PESO, CAD_MTMD_PRC_CREATININA, CAD_MTMD_PRC_PROCEDENCIA_PAC, ATD_PME_ID) " +
                                      "VALUES ({0}, {1}, '{2}', {3}, {4}, SYSDATE, '{5}', {6}, '{7}', {8}, {9})", dto.IdPrescricao.Value,
                                                                                                            dto.IdAtendimento.Value,
                                                                                                            dto.CRM.Value,
                                                                                                            dto.Status.Value,
                                                                                                            dto.IdUsuarioAlteracao.Value,
                                                                                                            dto.UFConselhoProfissional.Value,
                                                                                                            dto.Peso.Value.IsNull ? "NULL" : dto.Peso.Value.ToString(),
                                                                                                            dto.Creatinina.Value,
                                                                                                            dto.ProcedenciaPaciente.Value,
                                                                                                            dto.IdPrescricaoMedica.Value.IsNull ? "NULL" : dto.IdPrescricaoMedica.Value.ToString());
            }
            else
            {
                if (dto.Status.Value == 0)
                {
                    query = "UPDATE TB_CAD_MTMD_PRESCRICAO SET " +
                            "   CAD_MTMD_PRESCRICAO_STATUS = " + dto.Status.Value +
                            " , SEG_USU_ID_INATIVA = " + dto.IdUsuarioAlteracao.Value +
                            " , CAD_MTMD_DT_INATIVA = SYSDATE" +
                            " WHERE CAD_MTMD_PRESCRICAO_ID = " + dto.IdPrescricao.Value;
                }
                else
                {
                    query = "UPDATE TB_CAD_MTMD_PRESCRICAO SET " +
                            "   CAD_MTMD_PRESCRICAO_STATUS = " + dto.Status.Value +
                            " , CAD_MTMD_CRM = " + dto.CRM.Value +
                            " , CAD_PSO_SG_UF_CONSELHO = '" + dto.UFConselhoProfissional.Value + "'" +
                            " , CAD_MTMD_PRC_PROCEDENCIA_PAC = " + dto.ProcedenciaPaciente.Value +
                            " , CAD_MTMD_PRC_PESO = " + (dto.Peso.Value.IsNull ? "NULL" : dto.Peso.Value.ToString()) +
                            " , CAD_MTMD_PRC_CREATININA = '" + dto.Creatinina.Value + "'" +
                            " , SEG_USU_ID_ALTERACAO = " + dto.IdUsuarioAlteracao.Value +
                            " , CAD_MTMD_DT_ALTERACAO = SYSDATE" +
                            " WHERE CAD_MTMD_PRESCRICAO_ID = " + dto.IdPrescricao.Value;
                }
            }
            Connection.ExecuteCommand(query);
            return dto;
        }
        
        public void GravarInformacoesExtras(PrescricaoDTO dto)
        {
            string dataAssinatura = "NULL";
            if (!dto.DataAssinaturaSCIH.Value.IsNull)
                dataAssinatura = "TO_DATE('" + DateTime.Parse(dto.DataAssinaturaSCIH.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')";
            string queryExec = "UPDATE TB_CAD_MTMD_PRESCRICAO SET " +
                            "   CAD_MTMD_PRC_INTERNADO_UTI = " + (dto.FlInternadoUTI.Value.IsNull ? "0" : dto.FlInternadoUTI.Value.ToString()) +
                            " , CAD_MTMD_PRC_VENTILA_MECANICA = " + (dto.FlVentilaMecanica.Value.IsNull ? "0" : dto.FlVentilaMecanica.Value.ToString()) +
                            " , CAD_MTMD_PRC_CIRURGIA = '" + dto.CirurgiaDsc.Value + "'" +
                            " , CAD_MTMD_PRC_ACESSO_VASCULAR = '" + dto.AcessoVascularDsc.Value + "'" +
                            " , CAD_MTMD_PRC_SONDA_VESICAL = '" + dto.SondaVesicalDsc.Value + "'" +
                            " , CAD_MTMD_PRC_OUTROS = '" + dto.OutrosDsc.Value + "'" +
                            //" , CAD_MTMD_PRC_PESO = " + dto.Peso.Value +
                            //" , CAD_MTMD_PRC_CREATININA = '" + dto.Creatinina.Value + "'" +
                            //" , CAD_MTMD_PRC_PROCEDENCIA_PAC = " + dto.ProcedenciaPaciente.Value +
                            " , CAD_MTMD_DT_ASSINATURA_SCIH = " + dataAssinatura +
                            " , CAD_MTMD_PRC_INF_COMPL = '" + dto.InformacoesComplementares.Value + "'" +
                            " , SEG_USU_ID_ALTERACAO = " + dto.IdUsuarioAlteracao.Value +
                            " , CAD_MTMD_DT_ALTERACAO = SYSDATE" +
                            " WHERE CAD_MTMD_PRESCRICAO_ID = " + dto.IdPrescricao.Value;

            Connection.ExecuteCommand(queryExec);
        }

        /// <summary>
        /// Inativa item
        /// </summary>        
        public void ExcluirItem(PrescricaoDTO dto)
        {
            string queryExec = "UPDATE TB_CAD_MTMD_PRESCRICAO_ITEM SET " +
                                   "   CAD_MTMD_PRC_ITEM_STATUS = 0" +
                                   " , SEG_USU_ID_INATIVA = " + dto.IdUsuarioAlteracao.Value +
                                   " , CAD_MTMD_DT_INATIVA = SYSDATE" +
                               " WHERE CAD_MTMD_PRC_ITEM_STATUS = 1" +
                                 " AND CAD_MTMD_PRESCRICAO_ID = " + dto.IdPrescricao.Value +
                                 " AND CAD_MTMD_ID = " + dto.IdProduto.Value;

            Connection.ExecuteCommand(queryExec);
        }

        public void GravarItem(PrescricaoDTO dto)
        {
            if (!dto.IdPrescricao.Value.IsNull)
            {
                PrescricaoDTO dtoItem = new PrescricaoDTO();
                dtoItem.IdPrescricao.Value = dto.IdPrescricao.Value;
                dtoItem.IdProduto.Value = dto.IdProduto.Value;
                PrescricaoDataTable dtb = this.ListarItem(dtoItem, false);                
                if (dtb.Rows.Count > 0) //Atualizar qtd. dispensada caso tenha dispensação em andamento
                    dto.QtdDispensada.Value = dtb.TypedRow(0).QtdDispensada.Value;
                
                if (dto.QtdDispensada.Value.IsNull) dto.QtdDispensada.Value = 0;

                //Inativa anterior para manter log antes de inserir 
                this.ExcluirItem(dto);

                string dtGravar = "SYSDATE";
                if (dtoItem.IdMedicamentoPrescricaoMedica.Value.IsNull)
                    dtGravar = "SYSDATE-0.016"; //Colocar inclusão com minutos atrás para sempre trazer na query do Sistema de Estoque

                //string dataParecer = "NULL";
                //if (!dto.ParecerData.Value.IsNull)
                //    dataParecer = "TO_DATE('" + DateTime.Parse(dto.ParecerData.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')";

                string query = string.Format("INSERT INTO TB_CAD_MTMD_PRESCRICAO_ITEM(CAD_MTMD_PRESCRICAO_ID, CAD_MTMD_ID, CAD_MTMD_PRC_QTDE_TOTAL, CAD_MTMD_PRC_QTDE_DISP, " + 
                                                                                     "CAD_MTMD_PRC_QTDE_DIA, CAD_MTMD_DT_INICIO_CONS, CAD_MTMD_DT_FIM_CONS, CAD_MTMD_PRC_OBS, " +
                                                                                     "CAD_MTMD_PRC_ITEM_STATUS, SEG_USU_ID_INCLUSAO, CAD_MTMD_DT_INCLUSAO, CAD_MTMD_PRC_VIA, " + 
                                                                                     "SEG_USU_ID_ALTERACAO, CAD_MTMD_DT_ALTERACAO, " +
                                                                                     "ATD_PME_ID, ATD_MPM_ID) " +
                                                                              "VALUES({0}, {1}, {2}, {3}, {4}, {5}, {6}, '{7}', 1, {8}, " + dtGravar + ", '{9}', {8}, " + dtGravar + ", {10}, {11})", 
                                                                                      dto.IdPrescricao.Value,
                                                                                      dto.IdProduto.Value,
                                                                                      dto.QtdTotal.Value,
                                                                                      dto.QtdDispensada.Value,
                                                                                      dto.QtdDia.Value,
                                                                                      "TO_DATE('" + DateTime.Parse(dto.DataInicioConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')",
                                                                                      "TO_DATE('" + DateTime.Parse(dto.DataLimiteConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')",
                                                                                      dto.ObservacaoItem.Value,
                                                                                      dto.IdUsuarioAlteracao.Value,
                                                                                      dto.Via.Value,
                                                                                      dto.IdPrescricaoMedica.Value.IsNull ? "NULL" : dto.IdPrescricaoMedica.Value.ToString(),
                                                                                      dto.IdMedicamentoPrescricaoMedica.Value.IsNull ? "NULL" : dto.IdMedicamentoPrescricaoMedica.Value.ToString());

                Connection.ExecuteCommand(query);
            }
        }

        public void GravarParecerSCIH(PrescricaoDTO dto)
        {
            string dataParecer = "NULL";
            if (!dto.ParecerData.Value.IsNull)
                dataParecer = "TO_DATE('" + DateTime.Parse(dto.ParecerData.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')";
            string queryExec = "UPDATE TB_CAD_MTMD_PRESCRICAO_ITEM SET " +
                                   "   CAD_MTMD_PRC_AUTORIZADO = " + dto.FlAutorizado.Value +
                                   " , CAD_PRO_ID_PROF_SCIH = " + ((dto.IdProfissionalSCIH.Value.ToString() == string.Empty) ? "NULL" : dto.IdProfissionalSCIH.Value.ToString()) +
                                   " , CAD_MTMD_PRC_PARECER_DATA = " + dataParecer +
                                   " , CAD_MTMD_PRC_PARECER_SCIH = '" + dto.ParecerSCIH.Value + "'" +
                                   " , SEG_USU_ID_ALTERACAO = " + dto.IdUsuarioAlteracao.Value +
                                   " , CAD_MTMD_DT_ALTERACAO = SYSDATE" +
                               " WHERE CAD_MTMD_PRC_ITEM_STATUS = 1" +
                                 " AND CAD_MTMD_PRESCRICAO_ID = " + dto.IdPrescricao.Value +
                                 " AND CAD_MTMD_ID = " + dto.IdProduto.Value;

            Connection.ExecuteCommand(queryExec);
        }

        public void GravarCultura(PrescricaoDTO dto)
        {
            string queryExec;
            if (dto.CulturaSequencial.Value.IsNull)
            {
                DataTable dtSeq = new DataTable();
                queryExec = "SELECT NVL(MAX(CULT.CAD_MTMD_CULTURA_SEQ),0)+1\n" +
                            "  FROM TB_CAD_MTMD_PRESCRICAO_CULTURA CULT\n" + 
                            " WHERE CULT.CAD_MTMD_PRESCRICAO_ID = " + dto.IdPrescricao.Value;
                
                Connection.RecordSet(queryExec, dtSeq, CommandType.Text);                
                
                dto.CulturaSequencial.Value = dtSeq.Rows[0][0].ToString();

                queryExec = string.Format("INSERT INTO TB_CAD_MTMD_PRESCRICAO_CULTURA(CAD_MTMD_PRESCRICAO_ID, CAD_MTMD_CULTURA_SEQ, cad_mtmd_data_cultura, " +
                                            "cad_mtmd_material, cad_mtmd_microorganismo, cad_mtmd_sensibilidade_mic) " +
                                            "VALUES ({0}, {1}, {2}, '{3}', '{4}', '{5}')", dto.IdPrescricao.Value,
                                                                                        dto.CulturaSequencial.Value,
                                                                                        "TO_DATE('" + DateTime.Parse(dto.DataCultura.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')",
                                                                                        dto.Material.Value,
                                                                                        dto.Microorganismo.Value,
                                                                                        dto.SensibilidadeMIC.Value);
            }
            else
            {
                queryExec = "UPDATE TB_CAD_MTMD_PRESCRICAO_CULTURA SET " +
                                   "   cad_mtmd_data_cultura = TO_DATE('" + DateTime.Parse(dto.DataCultura.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')" +
                                   " , cad_mtmd_material = '" + dto.Material.Value + "'" +
                                   " , cad_mtmd_microorganismo = '" + dto.Microorganismo.Value + "'" +
                                   " , cad_mtmd_sensibilidade_mic = '" + dto.SensibilidadeMIC.Value + "'" +
                               " WHERE CAD_MTMD_PRESCRICAO_ID = " + dto.IdPrescricao.Value +
                                 " AND CAD_MTMD_CULTURA_SEQ = " + dto.CulturaSequencial.Value;
            }
            
            Connection.ExecuteCommand(queryExec);
        }

        public void ExcluirCultura(PrescricaoDTO dto)
        {
            string queryExec = "DELETE TB_CAD_MTMD_PRESCRICAO_CULTURA\n" +
                                "WHERE CAD_MTMD_PRESCRICAO_ID = " + dto.IdPrescricao.Value +
                                "  AND CAD_MTMD_CULTURA_SEQ = " + dto.CulturaSequencial.Value;
            Connection.ExecuteCommand(queryExec);
        }

        public PrescricaoDataTable ListarCultura(PrescricaoDTO dto)
        {
            string queryExec;

            if (dto.IdPrescricaoMedica.Value.IsNull)
            {
                queryExec = "SELECT CULT.CAD_MTMD_PRESCRICAO_ID,\n" +
                                "       CULT.CAD_MTMD_CULTURA_SEQ,\n" +
                                "       CULT.CAD_MTMD_DATA_CULTURA,\n" +
                                "       CULT.CAD_MTMD_MATERIAL,\n" +
                                "       CULT.CAD_MTMD_MICROORGANISMO,\n" +
                                "       CULT.CAD_MTMD_SENSIBILIDADE_MIC\n" +
                                " FROM TB_CAD_MTMD_PRESCRICAO_CULTURA CULT\n" +
                                "WHERE CULT.CAD_MTMD_PRESCRICAO_ID = " + dto.IdPrescricao.Value;
            }
            else
            {
                queryExec = "SELECT CULT.CAD_MTMD_PRESCRICAO_ID,\n" +
                            "        CULT.CAD_MTMD_CULTURA_SEQ,\n" +
                            "        CULT.CAD_MTMD_DATA_CULTURA,\n" +
                            "        CULT.CAD_MTMD_MATERIAL,\n" +
                            "        CULT.CAD_MTMD_MICROORGANISMO,\n" +
                            "        CULT.CAD_MTMD_SENSIBILIDADE_MIC\n" +
                            "FROM TB_CAD_MTMD_PRESCRICAO_CULTURA CULT\n" +
                            "     JOIN TB_CAD_MTMD_PRESCRICAO PRESC ON PRESC.CAD_MTMD_PRESCRICAO_ID = CULT.CAD_MTMD_PRESCRICAO_ID\n" +
                            "WHERE PRESC.ATD_ATE_ID = " + dto.IdAtendimento.Value;
            }

            PrescricaoDataTable result = new PrescricaoDataTable();
            Connection.RecordSet(queryExec, result, CommandType.Text);
            return result;
        }

        public void AssociarDoencaDiagnostico(PrescricaoDTO dto)
        {
            string queryExec = string.Format("INSERT INTO TB_CAD_MTMD_PRESCRICAO_DODI(CAD_MTMD_PRESCRICAO_ID, cad_mtmd_dodi_id) " +
                                             "VALUES ({0}, {1})", dto.IdPrescricao.Value,
                                                                  dto.IdDoencaDiagnostico.Value);
            Connection.ExecuteCommand(queryExec);
        }

        public void DesassociarDoencaDiagnostico(PrescricaoDTO dto)
        {
            string queryExec = "DELETE TB_CAD_MTMD_PRESCRICAO_DODI\n" +
                                "WHERE CAD_MTMD_PRESCRICAO_ID = " + dto.IdPrescricao.Value +
                                "  AND CAD_MTMD_DODI_ID = " + dto.IdDoencaDiagnostico.Value;
            Connection.ExecuteCommand(queryExec);
        }

        public PrescricaoDataTable ListarDoencaDiagnostico(PrescricaoDTO dto, DoencaDiagnosticoDTO dtoDoDi)
        {
            string filtros = string.Empty;

            if (!dto.IdPrescricao.Value.IsNull && dto.IdPrescricaoMedica.Value.IsNull)
                filtros += " AND PRCDODI.CAD_MTMD_PRESCRICAO_ID = " + dto.IdPrescricao.Value.ToString() + "\n";
            else
                filtros += " AND PRESC.ATD_ATE_ID = " + dto.IdAtendimento.Value.ToString() + "\n";

            if (!dto.IdDoencaDiagnostico.Value.IsNull)
                filtros += " AND PRCDODI.CAD_MTMD_DODI_ID = " + dto.IdDoencaDiagnostico.Value.ToString() + "\n";

            string queryExec = "SELECT PRCDODI.CAD_MTMD_PRESCRICAO_ID,\n" +
                                "       PRCDODI.CAD_MTMD_DODI_ID,\n" +
                                "       DODI.CAD_MTMD_DODI_DSC\n" +
                                "  FROM TB_CAD_MTMD_PRESCRICAO_DODI PRCDODI JOIN\n" +
                                "       TB_CAD_MTMD_DOENCA_DIAGNOSTICO DODI ON DODI.CAD_MTMD_DODI_ID = PRCDODI.CAD_MTMD_DODI_ID\n" +
                                "       JOIN TB_CAD_MTMD_PRESCRICAO PRESC ON PRESC.CAD_MTMD_PRESCRICAO_ID = PRCDODI.CAD_MTMD_PRESCRICAO_ID\n" +
                                "WHERE DODI.CAD_MTMD_DODI_TIPO = '" + dtoDoDi.Tipo.Value + "' \n" + filtros +
                                "ORDER BY DODI.CAD_MTMD_DODI_DSC";

            PrescricaoDataTable result = new PrescricaoDataTable();
            Connection.RecordSet(queryExec, result, CommandType.Text);
            return result;
        }

        public PrescricaoDataTable ListarItem(PrescricaoDTO dto, bool pendencias)
        {
            return this.ListarItem(dto, pendencias, false, null, null);
        }

        public PrescricaoDataTable ListarItem(PrescricaoDTO dto, bool pendencias, bool trazerSetorPaciente, PacienteDTO dtoPaciente, int? idPrincipioAtivo)
        {
            string filtros = string.Empty;
            string setorPacienteTb = string.Empty, setorPacienteCampos = string.Empty;

            if (!dto.IdPrescricao.Value.IsNull)
                filtros += " AND PRC.CAD_MTMD_PRESCRICAO_ID = " + dto.IdPrescricao.Value.ToString() + "\n";

            if (pendencias && dto.Status.Value.IsNull)
                filtros += " AND PRC.CAD_MTMD_PRESCRICAO_STATUS = 1\n";
            else if (!dto.Status.Value.IsNull)
                filtros += " AND PRC.CAD_MTMD_PRESCRICAO_STATUS = " + dto.Status.Value.ToString() + "\n";

            if (!dto.IdAtendimento.Value.IsNull)
                filtros += " AND PRC.ATD_ATE_ID = " + dto.IdAtendimento.Value.ToString() + "\n";

            if (!dto.IdProduto.Value.IsNull)
                filtros += " AND ITEM.CAD_MTMD_ID = " + dto.IdProduto.Value.ToString() + "\n";

            if (!dto.DataInicioConsumo.Value.IsNull)
                filtros += " AND NVL(ITEM.CAD_MTMD_DT_INICIO_CONS,SYSDATE-15) >= TO_DATE('" + DateTime.Parse(dto.DataInicioConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')\n";

            if (!dto.DataLimiteConsumo.Value.IsNull)
                filtros += " AND NVL(ITEM.CAD_MTMD_DT_FIM_CONS,SYSDATE+15) <= TO_DATE('" + DateTime.Parse(dto.DataLimiteConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')\n";

            if (pendencias)
                filtros += " AND (NVL(ITEM.CAD_MTMD_PRC_QTDE_TOTAL,0)-NVL(ITEM.CAD_MTMD_PRC_QTDE_DISP,0)) > 0 \n";

            if (!dto.IdPrescricaoMedica.Value.IsNull)
                filtros += " AND PRC.ATD_PME_ID = " + dto.IdPrescricaoMedica.Value.ToString() + "\n";

            if (!dto.IdMedicamentoPrescricaoMedica.Value.IsNull)
                filtros += " AND ITEM.ATD_MPM_ID = " + dto.IdMedicamentoPrescricaoMedica.Value.ToString() + "\n";

            if (idPrincipioAtivo != null)
                filtros += " AND PROD.CAD_MTMD_PRIATI_ID = " + idPrincipioAtivo.Value.ToString() + "\n";

            if (!dto.FlAutorizado.Value.IsNull)
            {
                if (dto.FlAutorizado.Value == 2) //2 = Traz todos que não foram checados
                    filtros += " AND ITEM.CAD_MTMD_PRC_AUTORIZADO IS NULL AND PRC.ATD_PME_ID IS NOT NULL AND NVL(ITEM.CAD_MTMD_DT_INCLUSAO,TRUNC(SYSDATE)) > TRUNC(SYSDATE-15) \n";
                else
                    filtros += " AND ITEM.CAD_MTMD_PRC_AUTORIZADO = " + dto.FlAutorizado.Value.ToString() + " AND PRC.ATD_PME_ID IS NOT NULL \n";
            }

            if (trazerSetorPaciente)
            {
                if (dtoPaciente != null)
                {
                    if (!dtoPaciente.IdtSetor.Value.IsNull)
                        filtros += " AND SETOR.CAD_SET_ID = " + dtoPaciente.IdtSetor.Value.ToString() + "\n";

                    if (!dtoPaciente.NmPaciente.Value.IsNull)
                        filtros += " AND (SELECT PES.CAD_PES_NM_PESSOA\n" +
                                        "   FROM TB_ASS_PAT_PACIEATEND PAT JOIN\n" +
                                        "        TB_CAD_PAC_PACIENTE   PAC ON PAC.CAD_PAC_ID_PACIENTE = PAT.CAD_PAC_ID_PACIENTE JOIN\n" +
                                        "        TB_CAD_PES_PESSOA     PES ON PES.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA\n" +
                                        "  WHERE PAT.ATD_ATE_ID = PRC.ATD_ATE_ID and rownum = 1) LIKE '" + dtoPaciente.NmPaciente.Value + "%' \n";
                }

                setorPacienteCampos = ",SETOR.CAD_SET_ID,\n" +
                                      " SETOR.CAD_SET_DS_SETOR,\n" +
                                      "(SELECT PES.CAD_PES_NM_PESSOA\n" +
                                      "   FROM TB_ASS_PAT_PACIEATEND PAT JOIN\n" +
                                      "        TB_CAD_PAC_PACIENTE   PAC ON PAC.CAD_PAC_ID_PACIENTE = PAT.CAD_PAC_ID_PACIENTE JOIN\n" +
                                      "        TB_CAD_PES_PESSOA     PES ON PES.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA\n" +
                                      "  WHERE PAT.ATD_ATE_ID = PRC.ATD_ATE_ID and rownum = 1) CAD_PES_NM_PESSOA\n";

                setorPacienteTb = "LEFT JOIN (SELECT IML.ATD_ATE_ID, QLE.CAD_SET_ID\n" +
                            "              FROM TB_ATD_IML_INT_MOV_LEITO IML\n" +
                            "              JOIN TB_CAD_QLE_QUARTO_LEITO QLE ON QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID\n" +
                            "              JOIN TB_ATD_ATE_ATENDIMENTO ATD ON ATD.ATD_ATE_ID = IML.ATD_ATE_ID\n" +
                            "             WHERE FNC_JUNTAR_DATA_HORA(IML.ATD_IML_DT_ENTRADA,IML.ATD_IML_HR_ENTRADA) =\n" +
                            "                   (SELECT MAX(FNC_JUNTAR_DATA_HORA(IML2.ATD_IML_DT_ENTRADA, IML2.ATD_IML_HR_ENTRADA))\n" +
                            "                      FROM TB_ATD_IML_INT_MOV_LEITO IML2\n" +
                            "                     WHERE IML2.ATD_ATE_ID = ATD.ATD_ATE_ID AND IML2.ATD_IML_FL_STATUS = 'A')) SETOR_PRESCRICAO ON SETOR_PRESCRICAO.ATD_ATE_ID = PRC.ATD_ATE_ID LEFT JOIN\n" +
                            "           TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = SETOR_PRESCRICAO.CAD_SET_ID\n";
            }

            string sqlString = string.Format("SELECT PRC.CAD_MTMD_PRESCRICAO_ID,\n" +
                                            "       PRC.ATD_ATE_ID,\n" + 
                                            "       PRC.CAD_MTMD_CRM,\n" + 
                                            "       PRC.CAD_MTMD_PRESCRICAO_STATUS,\n" +
                                            "       PRC.CAD_MTMD_DT_INCLUSAO,\n" + 
                                            "       PRC.SEG_USU_ID_INCLUSAO,\n" + 
                                            "       PRC.CAD_MTMD_PRC_INTERNADO_UTI,\n" + 
                                            "       PRC.CAD_MTMD_PRC_VENTILA_MECANICA,\n" + 
                                            "       PRC.CAD_MTMD_PRC_CIRURGIA,\n" + 
                                            "       PRC.CAD_MTMD_PRC_ACESSO_VASCULAR,\n" + 
                                            "       PRC.CAD_MTMD_PRC_SONDA_VESICAL,\n" + 
                                            "       PRC.CAD_MTMD_PRC_OUTROS,\n" + 
                                            "       PRC.CAD_MTMD_PRC_PESO,\n" + 
                                            "       PRC.CAD_MTMD_PRC_CREATININA,\n" + 
                                            "       PRC.CAD_MTMD_PRC_PROCEDENCIA_PAC,\n" + 
                                            "       PRC.CAD_MTMD_DT_ASSINATURA_SCIH,\n" + 
                                            "       PRC.CAD_PSO_SG_UF_CONSELHO,\n" + 
                                            "       PRC.CAD_MTMD_PRC_INF_COMPL,\n" + 
                                            "       PRC.SEG_USU_ID_ALTERACAO,\n" + 
                                            "       PRC.CAD_MTMD_DT_ALTERACAO,\n" +
                                            "       PRC.FL_INTERNACAO_PREVIA,\n" +
                                            "       PRC.CAD_MTMD_PRC_ATM_PREVIO,\n" + 
                                            "       ITEM.CAD_MTMD_ID,\n" + 
                                            "       (NVL(ITEM.CAD_MTMD_PRC_QTDE_TOTAL,0)-\n" + 
                                            "       NVL(ITEM.CAD_MTMD_PRC_QTDE_DISP,0)) QTDE_PENDENTE,\n" + 
                                            "       NVL(ITEM.CAD_MTMD_PRC_QTDE_TOTAL,0) CAD_MTMD_PRC_QTDE_TOTAL,\n" + 
                                            "       NVL(ITEM.CAD_MTMD_PRC_QTDE_DISP,0) CAD_MTMD_PRC_QTDE_DISP,\n" + 
                                            "       NVL(ITEM.CAD_MTMD_PRC_QTDE_DIA,0) CAD_MTMD_PRC_QTDE_DIA,\n" + 
                                            "       ITEM.CAD_MTMD_DT_INICIO_CONS,\n" + 
                                            "       ITEM.CAD_MTMD_DT_FIM_CONS,\n" + 
                                            "       ITEM.CAD_MTMD_PRC_OBS,\n" + 
                                            "       ITEM.CAD_MTMD_PRC_ITEM_STATUS,\n" +
                                            "       ITEM.CAD_MTMD_PRC_VIA,\n" +
                                            "       ITEM.CAD_MTMD_PRC_AUTORIZADO,\n" +
                                            "       DECODE(ITEM.CAD_MTMD_PRC_AUTORIZADO,1,'SIM',0,'NAO','--') AUTORIZADO,\n" +
                                            "       ITEM.CAD_MTMD_PRC_PARECER_SCIH,\n" +
                                            "       ITEM.CAD_MTMD_PRC_PARECER_DATA,\n" +
                                            "       ITEM.CAD_PRO_ID_PROF_SCIH,\n" +
                                            "       ITEM.SEG_USU_ID_ALTERACAO SEG_USU_ID_ALTERACAO_ITEM,\n" +
                                            "       ITEM.CAD_MTMD_DT_ALTERACAO CAD_MTMD_DT_ALTERACAO_ITEM,\n" +
                                            "       ITEM.ATD_MPM_ID,\n" +
                                            "       CASE WHEN ITEM.CAD_MTMD_DT_FIM_CONS < ITEM.CAD_MTMD_DT_INICIO_CONS AND\n" +
                                            "           (ITEM.CAD_MTMD_DT_INCLUSAO - SYSDATE) < -0.015 THEN 0\n" +
                                            "       ELSE 1 END COMPLETO," +
                                            "       PROD.CAD_MTMD_PRIATI_ID,\n" +
                                            "       FNC_MTMD_SOUNDALIKE(PROD.CAD_MTMD_NOMEFANTASIA,PROD.CAD_MTMD_GRUPO_ID) CAD_MTMD_NOMEFANTASIA,\n" +                                            
                                            "       PRC.ATD_PME_ID  \n" + 
                                            setorPacienteCampos +
                                            "FROM TB_CAD_MTMD_PRESCRICAO_ITEM ITEM RIGHT JOIN\n" + 
                                            "     TB_CAD_MTMD_MAT_MED PROD ON PROD.CAD_MTMD_ID = ITEM.CAD_MTMD_ID RIGHT JOIN\n" + 
                                            "     TB_CAD_MTMD_PRESCRICAO PRC ON PRC.CAD_MTMD_PRESCRICAO_ID = ITEM.CAD_MTMD_PRESCRICAO_ID\n" +
                                            setorPacienteTb +
                                            "WHERE NVL(ITEM.CAD_MTMD_PRC_ITEM_STATUS,1)=1 {0} AND ITEM.CAD_MTMD_DT_INCLUSAO < SYSDATE-0.008 \n" +
                                            "ORDER BY ITEM.CAD_MTMD_DT_FIM_CONS, ITEM.CAD_MTMD_DT_INICIO_CONS, PRC.ATD_ATE_ID, PRC.CAD_MTMD_PRESCRICAO_ID",
                                            filtros);

            PrescricaoDataTable result = new PrescricaoDataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);

            return result;
        }

        public PrescricaoDataTable ListarItensPrescricoesAnterioresPaciente(PrescricaoDTO dto)
        {
           string queryExec = "SELECT DISTINCT\n" +
                                "       PRC.ATD_ATE_ID,\n" +
                                "       ITEM.CAD_MTMD_DT_INCLUSAO,\n" +
                                "       PRC.CAD_MTMD_PRESCRICAO_ID,\n" +
                                "       MM.CAD_MTMD_NOMEFANTASIA\n" +
                                "FROM SGS.TB_CAD_MTMD_PRESCRICAO_ITEM ITEM JOIN\n" +
                                "     SGS.TB_CAD_MTMD_PRESCRICAO PRC ON ITEM.CAD_MTMD_PRESCRICAO_ID = PRC.CAD_MTMD_PRESCRICAO_ID JOIN\n" +
                                "     SGS.TB_CAD_MTMD_MAT_MED MM ON MM.CAD_MTMD_ID = ITEM.CAD_MTMD_ID\n" +
                                "WHERE PRC.ATD_ATE_ID IN (SELECT ASS_PAT.ATD_ATE_ID\n" +
                                "                            FROM TB_ASS_PAT_PACIEATEND ASS_PAT\n" +
                                "                          WHERE ASS_PAT.CAD_PAC_ID_PACIENTE IN\n" +
                                "                                (SELECT PAT.CAD_PAC_ID_PACIENTE\n" +
                                "                                   FROM TB_ASS_PAT_PACIEATEND PAT\n" +
                                "                                  WHERE PAT.ATD_ATE_ID = " + dto.IdAtendimento.Value + "))\n" +
                                "AND ITEM.CAD_MTMD_PRC_ITEM_STATUS = 1\n" +
                                "AND ITEM.CAD_MTMD_PRC_QTDE_DISP > 0 AND PRC.CAD_MTMD_DT_INCLUSAO < TRUNC(SYSDATE)\n" +
                                //"AND ITEM.CAD_MTMD_PRESCRICAO_ID < " + (dto.IdPrescricao.Value.IsNull ? 9999999999 : dto.IdPrescricao.Value) + "\n" +
                                "ORDER BY ITEM.CAD_MTMD_DT_INCLUSAO DESC";

            PrescricaoDataTable result = new PrescricaoDataTable();
            Connection.RecordSet(queryExec, result, CommandType.Text);
            return result;
        }

        public DataTable ListarProfissionalCorpoClinico(string numConselho, string ufConselho, string codConselho, decimal? idProfissional)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());
            
            //Parametro pCAD_PRO_CD_COD_PRO
            //param.Add(Connection.CreateParameter("pCAD_PRO_CD_COD_PRO", dto.CodigoProfissional.DBValue, ParameterDirection.Input, dto.CodigoProfissional.DbType));

            //Parametro pCAD_PRO_NR_CONSELHO
            param.Add(Connection.CreateParameter("pCAD_PRO_NR_CONSELHO", numConselho, ParameterDirection.Input, DbType.String));

            //Parametro pCAD_PRO_SG_UF_CONSELHO
            param.Add(Connection.CreateParameter("pCAD_PRO_SG_UF_CONSELHO", ufConselho, ParameterDirection.Input, DbType.String));
                        
            //Parametro pTIS_CPR_CD_CONSELHOPROF
            param.Add(Connection.CreateParameter("pTIS_CPR_CD_CONSELHOPROF", codConselho, ParameterDirection.Input, DbType.String));

            //Parametro pCAD_PRO_FL_ATIVO_OK
            param.Add(Connection.CreateParameter("pCAD_PRO_FL_ATIVO_OK", "S", ParameterDirection.Input, DbType.String));

            //Parametro pCAD_PRO_ID_PROFISSIONAL
            if (idProfissional!= null) param.Add(Connection.CreateParameter("pCAD_PRO_ID_PROFISSIONAL", idProfissional.Value, ParameterDirection.Input, DbType.Decimal));
            
            #endregion

            DataTable result = new DataTable();
            string query = "PRC_CAD_PROFISSIONAL_RMT_S";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }

        public DataTable ListarProfissionalSolicitante(string numConselho, string ufConselho, string codConselho)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            // Parametro pCAD_PSO_CD_CONSELHO
            param.Add(Connection.CreateParameter("pCAD_PSO_CD_CONSELHO", numConselho, ParameterDirection.Input, DbType.String));

            // Parametro pCAD_PSO_SG_UF_CONSELHO
            param.Add(Connection.CreateParameter("pCAD_PSO_SG_UF_CONSELHO", ufConselho, ParameterDirection.Input, DbType.String));

            // Parametro pTIS_CPR_CD_CONSELHOPROF
            param.Add(Connection.CreateParameter("pTIS_CPR_CD_CONSELHOPROF", codConselho, ParameterDirection.Input, DbType.String));

            #endregion

            DataTable result = new DataTable();
            string query = "PRC_CAD_PSO_PROF_SOLIC_RMT_SID";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }

        public DataTable ListarPacientesSetor(PrescricaoDTO dto, decimal? idUnidade, decimal? idLocal, decimal? idSetor, int? idadeDe, int? idadeAte, char? sexo)
        {
            string filtros = string.Empty;

            if (!dto.IdAtendimento.Value.IsNull)
                filtros += " PAC_PRC.ATENDIMENTO = " + dto.IdAtendimento.Value.ToString() + "\n";

            if (idUnidade != null)
            {
                if (!string.IsNullOrEmpty(filtros)) filtros += " AND";
                filtros += " PAC_PRC.CAD_UNI_ID_UNIDADE = " + idUnidade.Value.ToString() + "\n";
            }

            if (idLocal != null)
            {
                if (!string.IsNullOrEmpty(filtros)) filtros += " AND";
                filtros += " PAC_PRC.CAD_LAT_ID_LOCAL_ATENDIMENTO = " + idLocal.Value.ToString() + "\n";
            }

            if (idSetor != null)
            {
                if (!string.IsNullOrEmpty(filtros)) filtros += " AND";
                filtros += " PAC_PRC.CAD_SET_ID = " + idSetor.Value.ToString() + "\n";
            }

            if (idadeDe != null && idadeAte == null)
                idadeAte = 140;
            else if (idadeDe == null && idadeAte != null)
                idadeDe = 0;

            if (idadeDe != null && idadeAte != null)
            {
                if (!string.IsNullOrEmpty(filtros)) filtros += " AND";
                filtros += " (PAC_PRC.IDADE >= " + idadeDe.Value.ToString() + " AND PAC_PRC.IDADE <= " + idadeAte.Value.ToString() + ")\n";
            }

            if (sexo != null)
            {
                if (!string.IsNullOrEmpty(filtros)) filtros += " AND";
                filtros += " PAC_PRC.SEXO = '" + sexo.Value.ToString() + "'\n";
            }

            if (!string.IsNullOrEmpty(filtros))
                filtros = " WHERE " + filtros;

            string sqlString = "SELECT * FROM\n" +
                                "(SELECT DISTINCT\n" +
                                "       PES.CAD_PES_NM_PESSOA PACIENTE,\n" +
                                "       PRC.ATD_ATE_ID ATENDIMENTO,\n" +
                                "       DECODE(ATD.ATD_ATE_TP_PACIENTE,'I','INTERNO','EXTERNO') TIPO_PAC,\n" +
                                "       TO_CHAR(PES.CAD_PES_DT_NASCIMENTO,'dd/MM/yyyy') DT_NASCIMENTO,\n" +
                                "       CASE\n" +
                                "         WHEN TO_NUMBER(TO_CHAR(SYSDATE,'MMDD'))>TO_NUMBER(TO_CHAR(PES.CAD_PES_DT_NASCIMENTO,'MMDD')) THEN\n" +
                                "           TO_NUMBER(TO_CHAR(SYSDATE,'YYYY'))-TO_NUMBER(TO_CHAR(PES.CAD_PES_DT_NASCIMENTO,'YYYY'))\n" +
                                "         ELSE\n" +
                                "           TO_NUMBER(TO_CHAR(SYSDATE,'YYYY'))-TO_NUMBER(TO_CHAR(PES.CAD_PES_DT_NASCIMENTO,'YYYY'))-1\n" +
                                "       END IDADE,\n" +
                                "       PES.CAD_PES_TP_SEXO SEXO,\n" +
                                "       UNI.CAD_UNI_ID_UNIDADE,\n" +
                                "       UNI.CAD_UNI_DS_RESUMIDA UNIDADE,\n" +
                                "       SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" +
                                "       SETOR.CAD_SET_ID,\n" +
                                "       SETOR.CAD_SET_CD_SETOR SETOR,\n" +
                                //"       --SETOR.CAD_SET_DS_SETOR,\n" +
                                "       TO_CHAR(IML.ATD_IML_DT_ENTRADA,'dd/MM/yyyy') DT_ENTRADA_PAC,\n" +
                                "       TO_CHAR(IML.ATD_IML_DT_SAIDA,'dd/MM/yyyy') DT_SAIDA_PAC\n" +
                                " FROM TB_CAD_MTMD_PRESCRICAO PRC JOIN\n" +
                                "      TB_ATD_IML_INT_MOV_LEITO IML ON IML.ATD_ATE_ID = PRC.ATD_ATE_ID JOIN\n" +
                                "      TB_CAD_QLE_QUARTO_LEITO QLE ON QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID JOIN\n" +
                                "      TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = QLE.CAD_SET_ID JOIN\n" +
                                "      TB_CAD_UNI_UNIDADE UNI ON UNI.CAD_UNI_ID_UNIDADE = SETOR.CAD_UNI_ID_UNIDADE JOIN\n" +
                                "      TB_ASS_PAT_PACIEATEND PAT ON PAT.ATD_ATE_ID = PRC.ATD_ATE_ID JOIN\n" +
                                "      TB_CAD_PAC_PACIENTE PAC ON PAC.CAD_PAC_ID_PACIENTE = PAT.CAD_PAC_ID_PACIENTE JOIN\n" +
                                "      TB_CAD_PES_PESSOA PES ON PES.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA JOIN\n" +
                                "      TB_ATD_ATE_ATENDIMENTO ATD ON ATD.ATD_ATE_ID = PRC.ATD_ATE_ID\n" +
                                "WHERE PRC.CAD_MTMD_PRESCRICAO_STATUS = 1\n" +
                                "  AND (PRC.CAD_MTMD_DT_INCLUSAO >= TO_DATE('" + DateTime.Parse(dto.DataInicioConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')\n" +
                                "  AND  PRC.CAD_MTMD_DT_INCLUSAO <= TO_DATE('" + DateTime.Parse(dto.DataLimiteConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy'))\n" +
                                "UNION\n" +
                                "SELECT DISTINCT\n" +
                                "       PES.CAD_PES_NM_PESSOA PACIENTE,\n" +
                                "       PRC.ATD_ATE_ID ATENDIMENTO,\n" +
                                "       DECODE(ATD.ATD_ATE_TP_PACIENTE,'I','INTERNO','EXTERNO') TIPO_PAC,\n" +
                                "       TO_CHAR(PES.CAD_PES_DT_NASCIMENTO,'dd/MM/yyyy') DT_NASCIMENTO,\n" +
                                "       CASE\n" +
                                "         WHEN TO_NUMBER(TO_CHAR(SYSDATE,'MMDD'))>TO_NUMBER(TO_CHAR(PES.CAD_PES_DT_NASCIMENTO,'MMDD')) THEN\n" +
                                "           TO_NUMBER(TO_CHAR(SYSDATE,'YYYY'))-TO_NUMBER(TO_CHAR(PES.CAD_PES_DT_NASCIMENTO,'YYYY'))\n" +
                                "         ELSE\n" +
                                "           TO_NUMBER(TO_CHAR(SYSDATE,'YYYY'))-TO_NUMBER(TO_CHAR(PES.CAD_PES_DT_NASCIMENTO,'YYYY'))-1\n" +
                                "       END IDADE,\n" +
                                "       PES.CAD_PES_TP_SEXO SEXO,\n" +
                                "       UNI.CAD_UNI_ID_UNIDADE,\n" +
                                "       UNI.CAD_UNI_DS_RESUMIDA UNIDADE,\n" +
                                "       SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" +
                                "       SETOR.CAD_SET_ID,\n" +
                                "       SETOR.CAD_SET_CD_SETOR SETOR,\n" +
                                //"       --SETOR.CAD_SET_DS_SETOR,\n" +
                                "       TO_CHAR(IMS.ATD_IMS_DT_ENTRADA,'dd/MM/yyyy') DT_ENTRADA_PAC,\n" +
                                "       TO_CHAR(IMS.ATD_IMS_DT_SAIDA,'dd/MM/yyyy') DT_SAIDA_PAC\n" +
                                " FROM TB_CAD_MTMD_PRESCRICAO PRC JOIN\n" +
                                "      TB_ATD_IMS_INT_MOV_SETOR IMS ON IMS.ATD_ATE_ID = PRC.ATD_ATE_ID JOIN\n" +
                                "      TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = IMS.CAD_SET_ID_SETOR JOIN\n" +
                                "      TB_CAD_UNI_UNIDADE UNI ON UNI.CAD_UNI_ID_UNIDADE = SETOR.CAD_UNI_ID_UNIDADE JOIN\n" +
                                "      TB_ASS_PAT_PACIEATEND PAT ON PAT.ATD_ATE_ID = PRC.ATD_ATE_ID JOIN\n" +
                                "      TB_CAD_PAC_PACIENTE PAC ON PAC.CAD_PAC_ID_PACIENTE = PAT.CAD_PAC_ID_PACIENTE JOIN\n" +
                                "      TB_CAD_PES_PESSOA PES ON PES.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA JOIN\n" +
                                "      TB_ATD_ATE_ATENDIMENTO ATD ON ATD.ATD_ATE_ID = PRC.ATD_ATE_ID\n" +
                                "WHERE PRC.CAD_MTMD_PRESCRICAO_STATUS = 1\n" +
                                "  AND SETOR.CAD_SET_CD_SETOR != 'ADM'\n" +
                                "  AND (PRC.CAD_MTMD_DT_INCLUSAO >= TO_DATE('" + DateTime.Parse(dto.DataInicioConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')\n" +
                                "  AND  PRC.CAD_MTMD_DT_INCLUSAO <= TO_DATE('" + DateTime.Parse(dto.DataLimiteConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy'))\n" +
                                "UNION\n" +
                                "SELECT DISTINCT\n" +
                                "       PES.CAD_PES_NM_PESSOA PACIENTE,\n" +
                                "       PRC.ATD_ATE_ID ATENDIMENTO,\n" +
                                "       DECODE(ATD.ATD_ATE_TP_PACIENTE,'I','INTERNO','EXTERNO') TIPO_PAC,\n" +
                                "       TO_CHAR(PES.CAD_PES_DT_NASCIMENTO,'dd/MM/yyyy') DT_NASCIMENTO,\n" +
                                "       CASE\n" +
                                "         WHEN TO_NUMBER(TO_CHAR(SYSDATE,'MMDD'))>TO_NUMBER(TO_CHAR(PES.CAD_PES_DT_NASCIMENTO,'MMDD')) THEN\n" +
                                "           TO_NUMBER(TO_CHAR(SYSDATE,'YYYY'))-TO_NUMBER(TO_CHAR(PES.CAD_PES_DT_NASCIMENTO,'YYYY'))\n" +
                                "         ELSE\n" +
                                "           TO_NUMBER(TO_CHAR(SYSDATE,'YYYY'))-TO_NUMBER(TO_CHAR(PES.CAD_PES_DT_NASCIMENTO,'YYYY'))-1\n" +
                                "       END IDADE,\n" +
                                "       PES.CAD_PES_TP_SEXO SEXO,\n" +
                                "       UNI.CAD_UNI_ID_UNIDADE,\n" +
                                "       UNI.CAD_UNI_DS_RESUMIDA UNIDADE,\n" +
                                "       SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" +
                                "       SETOR.CAD_SET_ID,\n" +
                                "       SETOR.CAD_SET_CD_SETOR SETOR,\n" +
                                //"       --SETOR.CAD_SET_DS_SETOR,\n" +
                                "       TO_CHAR(ATD.ATD_ATE_DT_ATENDIMENTO,'dd/MM/yyyy') DT_ENTRADA_PAC,\n" +
                                "       TO_CHAR(ATD.ATD_ATE_DT_ATENDIMENTO,'dd/MM/yyyy') DT_SAIDA_PAC\n" +
                                " FROM TB_CAD_MTMD_PRESCRICAO PRC JOIN\n" +
                                "      TB_ATD_ATE_ATENDIMENTO ATD ON ATD.ATD_ATE_ID = PRC.ATD_ATE_ID JOIN\n" +
                                "      TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = ATD.CAD_SET_ID JOIN\n" +
                                "      TB_CAD_UNI_UNIDADE UNI ON UNI.CAD_UNI_ID_UNIDADE = SETOR.CAD_UNI_ID_UNIDADE JOIN\n" +
                                "      TB_ASS_PAT_PACIEATEND PAT ON PAT.ATD_ATE_ID = PRC.ATD_ATE_ID JOIN\n" +
                                "      TB_CAD_PAC_PACIENTE PAC ON PAC.CAD_PAC_ID_PACIENTE = PAT.CAD_PAC_ID_PACIENTE JOIN\n" +
                                "      TB_CAD_PES_PESSOA PES ON PES.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA\n" +
                                "WHERE PRC.CAD_MTMD_PRESCRICAO_STATUS = 1\n" +
                                "  AND ATD.ATD_ATE_TP_PACIENTE != 'I'\n" +
                                "  AND (PRC.CAD_MTMD_DT_INCLUSAO >= TO_DATE('" + DateTime.Parse(dto.DataInicioConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')\n" +
                                "  AND  PRC.CAD_MTMD_DT_INCLUSAO <= TO_DATE('" + DateTime.Parse(dto.DataLimiteConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy'))) PAC_PRC" +
                                filtros + " ORDER BY PACIENTE, TO_DATE(DT_ENTRADA_PAC,'dd/MM/yyyy'), TO_DATE(DT_SAIDA_PAC,'dd/MM/yyyy')";

            DataTable result = new DataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);
            return result;
        }

        public DataTable ListarPacientesClinico(PrescricaoDTO dto, DoencaDiagnosticoDTO dtoDoDi, bool? comCultura)
        {
            string filtros = string.Empty;

            if (!dto.IdAtendimento.Value.IsNull)
                filtros += " AND PRC.ATD_ATE_ID = " + dto.IdAtendimento.Value.ToString() + "\n";

            if (!dto.ProcedenciaPaciente.Value.IsNull)
                filtros += " AND PRC.CAD_MTMD_PRC_PROCEDENCIA_PAC = " + dto.ProcedenciaPaciente.Value.ToString() + "\n";

            if (dtoDoDi != null && !dtoDoDi.Tipo.Value.IsNull)
                filtros += " AND DODI.CAD_MTMD_DODI_TIPO = '" + dtoDoDi.Tipo.Value + "'\n";

            if (!dto.IdDoencaDiagnostico.Value.IsNull)
                filtros += " AND PRC_DODI.CAD_MTMD_DODI_ID = " + dto.IdDoencaDiagnostico.Value.ToString() + "\n";

            if (comCultura != null)
            {
                if (comCultura.Value)
                    filtros += " AND PRC_CULT.CAD_MTMD_DATA_CULTURA IS NOT NULL\n";
                else
                    filtros += " AND PRC_CULT.CAD_MTMD_DATA_CULTURA IS NULL\n";
            }

            string sqlString = "SELECT PES.CAD_PES_NM_PESSOA PACIENTE,\n" +
                                "       PAT.ATD_ATE_ID ATENDIMENTO,\n" +
                                "       PRC.CAD_MTMD_PRC_PROCEDENCIA_PAC,\n" +
                                "       DECODE(PRC.CAD_MTMD_PRC_PROCEDENCIA_PAC,1,'INTERNADO',\n" +
                                "                                               2,'INSTITUICAO DE IDOSOS',\n" +
                                "                                               3,'OUTRO HOSPITAL',\n" +
                                "                                               4,'CASA') PROCEDENCIA_PAC_DSC,\n" +
                                "       DODI.CAD_MTMD_DODI_ID,\n" +
                                "       DECODE(DODI.CAD_MTMD_DODI_TIPO,'DO','DOENCA','DI','DIAGNOSTICO') DESCRICAO_TIPO,\n" +
                                "       DODI.CAD_MTMD_DODI_DSC DESCRICAO,\n" +
                                "       PRC_CULT.CAD_MTMD_DATA_CULTURA DATA_CULTURA,\n" +
                                "       PRC_CULT.CAD_MTMD_MATERIAL MATERIAL,\n" +
                                "       PRC_CULT.CAD_MTMD_MICROORGANISMO MICROORGANISMO,\n" +
                                "       PRC_CULT.CAD_MTMD_SENSIBILIDADE_MIC SENSIBILIDADE_MIC\n" +
                                "  FROM TB_CAD_MTMD_PRESCRICAO PRC JOIN\n" +
                                "       TB_ASS_PAT_PACIEATEND PAT ON PAT.ATD_ATE_ID = PRC.ATD_ATE_ID JOIN\n" +
                                "       TB_CAD_PAC_PACIENTE PAC ON PAC.CAD_PAC_ID_PACIENTE = PAT.CAD_PAC_ID_PACIENTE JOIN\n" +
                                "       TB_CAD_PES_PESSOA PES ON PES.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA LEFT JOIN\n" +
                                "       TB_CAD_MTMD_PRESCRICAO_DODI PRC_DODI ON PRC_DODI.CAD_MTMD_PRESCRICAO_ID = PRC.CAD_MTMD_PRESCRICAO_ID LEFT JOIN\n" +
                                "       TB_CAD_MTMD_DOENCA_DIAGNOSTICO DODI ON DODI.CAD_MTMD_DODI_ID = PRC_DODI.CAD_MTMD_DODI_ID LEFT JOIN\n" +
                                "       TB_CAD_MTMD_PRESCRICAO_CULTURA PRC_CULT ON PRC_CULT.CAD_MTMD_PRESCRICAO_ID = PRC.CAD_MTMD_PRESCRICAO_ID\n" +
                                "  WHERE PRC.CAD_MTMD_PRESCRICAO_STATUS = 1\n" +
                                "    AND (PRC.CAD_MTMD_DT_INCLUSAO >= TO_DATE('" + DateTime.Parse(dto.DataInicioConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')\n" +
                                "    AND  PRC.CAD_MTMD_DT_INCLUSAO <= TO_DATE('" + DateTime.Parse(dto.DataLimiteConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')) " +
                                filtros + " ORDER BY PES.CAD_PES_NM_PESSOA, PAT.ATD_ATE_ID, DODI.CAD_MTMD_DODI_TIPO, PRC_CULT.CAD_MTMD_DATA_CULTURA";

            DataTable result = new DataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);
            return result;
        }

        public DataTable ListarMedicamentosEstatisticaAnalitico(PrescricaoDTO dto, bool? comModificacao, int? qtdDiasDe, int? qtdDiasAte)
        {
            string filtros = string.Empty;

            if (!dto.IdProduto.Value.IsNull)
                filtros += " AND ITEM.CAD_MTMD_ID = " + dto.IdProduto.Value.ToString() + "\n";

            if (!dto.FlAutorizado.Value.IsNull)
                filtros += " AND ITEM.CAD_MTMD_PRC_AUTORIZADO = " + dto.FlAutorizado.Value.ToString() + "\n";                        

            if (qtdDiasDe != null && qtdDiasAte == null)
                qtdDiasAte = 180;
            else if (qtdDiasDe == null && qtdDiasAte != null)
                qtdDiasDe = 0;

            if (qtdDiasDe != null && qtdDiasAte != null)
                filtros += " AND ((ITEM.CAD_MTMD_DT_FIM_CONS-ITEM.CAD_MTMD_DT_INICIO_CONS) >= " + qtdDiasDe.Value.ToString() +
                           " AND  (ITEM.CAD_MTMD_DT_FIM_CONS-ITEM.CAD_MTMD_DT_INICIO_CONS) <= " + qtdDiasAte.Value.ToString() + ")\n";

            if (comModificacao != null)
            {
                filtros += "AND DECODE((SELECT COUNT(I.CAD_MTMD_ID)\n" +
                     "                    FROM TB_CAD_MTMD_PRESCRICAO_ITEM I\n" +
                     "                   WHERE I.CAD_MTMD_PRESCRICAO_ID = ITEM.CAD_MTMD_PRESCRICAO_ID AND\n" +
                     "                         I.CAD_MTMD_ID = ITEM.CAD_MTMD_ID AND\n" +
                     "                         I.CAD_MTMD_PRC_ITEM_STATUS = 0 AND\n" +
                     "                         I.CAD_MTMD_PRC_QTDE_TOTAL != ITEM.CAD_MTMD_PRC_QTDE_TOTAL),0,'N','S') = '" + (comModificacao.Value ? "S" : "N") + "'";
            }

            string sqlString = "SELECT MED.CAD_MTMD_ID ID_MED,\n" +
                               "       MED.CAD_MTMD_NOMEFANTASIA MEDICAMENTO,\n" +
                               "       ITEM.CAD_MTMD_PRESCRICAO_ID ID_PRESCRICAO,\n" +
                               "       (ITEM.CAD_MTMD_DT_FIM_CONS-ITEM.CAD_MTMD_DT_INICIO_CONS) QTD_DIAS_PRESCRITOS,\n" +
                               "       DECODE((SELECT COUNT(I.CAD_MTMD_ID)\n" +
                               "                FROM TB_CAD_MTMD_PRESCRICAO_ITEM I\n" +
                               "                WHERE I.CAD_MTMD_PRESCRICAO_ID = ITEM.CAD_MTMD_PRESCRICAO_ID AND\n" +
                               "                      I.CAD_MTMD_ID = ITEM.CAD_MTMD_ID AND\n" +
                               "                      I.CAD_MTMD_PRC_ITEM_STATUS = 0 AND\n" +
                               "                      I.CAD_MTMD_PRC_QTDE_TOTAL != ITEM.CAD_MTMD_PRC_QTDE_TOTAL),0,'NAO','SIM') COM_MODIFICACAO,\n" +
                               "       DECODE(ITEM.CAD_MTMD_PRC_AUTORIZADO,1,'SIM',0,'NAO') AUTORIZADO\n" +
                               "FROM TB_CAD_MTMD_PRESCRICAO_ITEM ITEM JOIN TB_CAD_MTMD_PRESCRICAO PRC ON PRC.CAD_MTMD_PRESCRICAO_ID = ITEM.CAD_MTMD_PRESCRICAO_ID JOIN\n" +
                               "     TB_CAD_MTMD_MAT_MED MED ON MED.CAD_MTMD_ID = ITEM.CAD_MTMD_ID\n" +
                               "WHERE ITEM.CAD_MTMD_PRC_ITEM_STATUS = 1 AND PRC.CAD_MTMD_PRESCRICAO_STATUS = 1\n" +
                               "    AND (ITEM.CAD_MTMD_DT_INICIO_CONS >= TO_DATE('" + DateTime.Parse(dto.DataInicioConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')\n" +
                               "    AND  ITEM.CAD_MTMD_DT_INICIO_CONS <= TO_DATE('" + DateTime.Parse(dto.DataLimiteConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')) " +
                               filtros + " ORDER BY MED.CAD_MTMD_NOMEFANTASIA";

            DataTable result = new DataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);
            return result;
        }

        public DataTable ListarMedicamentosEstatisticaPercentual(PrescricaoDTO dto)
        {
            string sqlString = "SELECT DISTINCT\n" +
                                "       MED.CAD_MTMD_ID ID_MED,\n" +
                                "       MED.CAD_MTMD_NOMEFANTASIA MEDICAMENTO,\n" +
                                "       (SELECT COUNT(M.CAD_MTMD_ID)\n" +
                                "        FROM TB_CAD_MTMD_PRESCRICAO_ITEM I JOIN TB_CAD_MTMD_PRESCRICAO PRC ON PRC.CAD_MTMD_PRESCRICAO_ID = I.CAD_MTMD_PRESCRICAO_ID JOIN\n" +
                                "             TB_CAD_MTMD_MAT_MED M ON M.CAD_MTMD_ID = I.CAD_MTMD_ID\n" +
                                "        WHERE I.CAD_MTMD_PRC_ITEM_STATUS = 1 AND PRC.CAD_MTMD_PRESCRICAO_STATUS = 1\n" +
                                "              AND (I.CAD_MTMD_DT_INICIO_CONS >= TO_DATE('" + DateTime.Parse(dto.DataInicioConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')\n" +
                                "              AND  I.CAD_MTMD_DT_INICIO_CONS <= TO_DATE('" + DateTime.Parse(dto.DataLimiteConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy'))\n" +
                                "              AND  I.CAD_MTMD_ID = ITEM.CAD_MTMD_ID) QTD_TOTAL_REGISTROS_PERIODO,\n" +
                                "       ROUND(100*(SELECT COUNT(M.CAD_MTMD_ID)\n" +
                                "                    FROM TB_CAD_MTMD_PRESCRICAO_ITEM I JOIN TB_CAD_MTMD_PRESCRICAO PRC ON PRC.CAD_MTMD_PRESCRICAO_ID = I.CAD_MTMD_PRESCRICAO_ID JOIN\n" +
                                "                         TB_CAD_MTMD_MAT_MED M ON M.CAD_MTMD_ID = I.CAD_MTMD_ID\n" +
                                "                    WHERE I.CAD_MTMD_PRC_ITEM_STATUS = 1 AND PRC.CAD_MTMD_PRESCRICAO_STATUS = 1\n" +
                                "                      AND (I.CAD_MTMD_DT_INICIO_CONS >= TO_DATE('" + DateTime.Parse(dto.DataInicioConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')\n" +
                                "                      AND  I.CAD_MTMD_DT_INICIO_CONS <= TO_DATE('" + DateTime.Parse(dto.DataLimiteConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy'))\n" +
                                "                      AND  I.CAD_MTMD_PRC_AUTORIZADO IS NULL \n" +
                                "                      AND  I.CAD_MTMD_ID = ITEM.CAD_MTMD_ID)/\n" +
                                "                   (SELECT COUNT(M.CAD_MTMD_ID)\n" +
                                "                    FROM TB_CAD_MTMD_PRESCRICAO_ITEM I JOIN TB_CAD_MTMD_PRESCRICAO PRC ON PRC.CAD_MTMD_PRESCRICAO_ID = I.CAD_MTMD_PRESCRICAO_ID JOIN\n" +
                                "                         TB_CAD_MTMD_MAT_MED M ON M.CAD_MTMD_ID = I.CAD_MTMD_ID\n" +
                                "                    WHERE I.CAD_MTMD_PRC_ITEM_STATUS = 1 AND PRC.CAD_MTMD_PRESCRICAO_STATUS = 1\n" +
                                "                      AND (I.CAD_MTMD_DT_INICIO_CONS >= TO_DATE('" + DateTime.Parse(dto.DataInicioConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')\n" +
                                "                      AND  I.CAD_MTMD_DT_INICIO_CONS <= TO_DATE('" + DateTime.Parse(dto.DataLimiteConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy'))\n" +
                                "                      AND  I.CAD_MTMD_ID = ITEM.CAD_MTMD_ID)) PERC_QTD_SEM_INF_AUTORIZACAO,\n" +
                                "       ROUND(100*(SELECT COUNT(M.CAD_MTMD_ID)\n" +
                                "                    FROM TB_CAD_MTMD_PRESCRICAO_ITEM I JOIN TB_CAD_MTMD_PRESCRICAO PRC ON PRC.CAD_MTMD_PRESCRICAO_ID = I.CAD_MTMD_PRESCRICAO_ID JOIN\n" +
                                "                         TB_CAD_MTMD_MAT_MED M ON M.CAD_MTMD_ID = I.CAD_MTMD_ID\n" +
                                "                    WHERE I.CAD_MTMD_PRC_ITEM_STATUS = 1 AND PRC.CAD_MTMD_PRESCRICAO_STATUS = 1\n" +
                                "                      AND (I.CAD_MTMD_DT_INICIO_CONS >= TO_DATE('" + DateTime.Parse(dto.DataInicioConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')\n" +
                                "                      AND  I.CAD_MTMD_DT_INICIO_CONS <= TO_DATE('" + DateTime.Parse(dto.DataLimiteConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy'))\n" +
                                "                      AND  I.CAD_MTMD_PRC_AUTORIZADO = 1 \n" +
                                "                      AND  I.CAD_MTMD_ID = ITEM.CAD_MTMD_ID)/\n" +
                                "                   (SELECT COUNT(M.CAD_MTMD_ID)\n" +
                                "                    FROM TB_CAD_MTMD_PRESCRICAO_ITEM I JOIN TB_CAD_MTMD_PRESCRICAO PRC ON PRC.CAD_MTMD_PRESCRICAO_ID = I.CAD_MTMD_PRESCRICAO_ID JOIN\n" +
                                "                         TB_CAD_MTMD_MAT_MED M ON M.CAD_MTMD_ID = I.CAD_MTMD_ID\n" +
                                "                    WHERE I.CAD_MTMD_PRC_ITEM_STATUS = 1 AND PRC.CAD_MTMD_PRESCRICAO_STATUS = 1\n" +
                                "                      AND (I.CAD_MTMD_DT_INICIO_CONS >= TO_DATE('" + DateTime.Parse(dto.DataInicioConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')\n" +
                                "                      AND  I.CAD_MTMD_DT_INICIO_CONS <= TO_DATE('" + DateTime.Parse(dto.DataLimiteConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy'))\n" +
                                "                      AND  I.CAD_MTMD_ID = ITEM.CAD_MTMD_ID)) PERC_QTD_AUTORIZADOS,\n" +
                                "       ROUND(100*(SELECT COUNT(M.CAD_MTMD_ID)\n" +
                                "                    FROM TB_CAD_MTMD_PRESCRICAO_ITEM I JOIN TB_CAD_MTMD_PRESCRICAO PRC ON PRC.CAD_MTMD_PRESCRICAO_ID = I.CAD_MTMD_PRESCRICAO_ID JOIN\n" +
                                "                         TB_CAD_MTMD_MAT_MED M ON M.CAD_MTMD_ID = I.CAD_MTMD_ID\n" +
                                "                    WHERE I.CAD_MTMD_PRC_ITEM_STATUS = 1 AND PRC.CAD_MTMD_PRESCRICAO_STATUS = 1\n" +
                                "                      AND (I.CAD_MTMD_DT_INICIO_CONS >= TO_DATE('" + DateTime.Parse(dto.DataInicioConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')\n" +
                                "                      AND  I.CAD_MTMD_DT_INICIO_CONS <= TO_DATE('" + DateTime.Parse(dto.DataLimiteConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy'))\n" +
                                "                      AND  I.CAD_MTMD_PRC_AUTORIZADO = 0 \n" +
                                "                      AND  I.CAD_MTMD_ID = ITEM.CAD_MTMD_ID)/\n" +
                                "                   (SELECT COUNT(M.CAD_MTMD_ID)\n" +
                                "                    FROM TB_CAD_MTMD_PRESCRICAO_ITEM I JOIN TB_CAD_MTMD_PRESCRICAO PRC ON PRC.CAD_MTMD_PRESCRICAO_ID = I.CAD_MTMD_PRESCRICAO_ID JOIN\n" +
                                "                         TB_CAD_MTMD_MAT_MED M ON M.CAD_MTMD_ID = I.CAD_MTMD_ID\n" +
                                "                    WHERE I.CAD_MTMD_PRC_ITEM_STATUS = 1 AND PRC.CAD_MTMD_PRESCRICAO_STATUS = 1\n" +
                                "                      AND (I.CAD_MTMD_DT_INICIO_CONS >= TO_DATE('" + DateTime.Parse(dto.DataInicioConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')\n" +
                                "                      AND  I.CAD_MTMD_DT_INICIO_CONS <= TO_DATE('" + DateTime.Parse(dto.DataLimiteConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy'))\n" +
                                "                      AND  I.CAD_MTMD_ID = ITEM.CAD_MTMD_ID)) PERC_QTD_NAO_AUTORIZADOS,\n" +
                                "       ROUND(100*(SELECT COUNT(I.CAD_MTMD_ID)\n" +
                                "                    FROM TB_CAD_MTMD_PRESCRICAO_ITEM I JOIN TB_CAD_MTMD_PRESCRICAO PRC ON PRC.CAD_MTMD_PRESCRICAO_ID = I.CAD_MTMD_PRESCRICAO_ID\n" +
                                "                    WHERE I.CAD_MTMD_PRC_ITEM_STATUS = 1 AND PRC.CAD_MTMD_PRESCRICAO_STATUS = 1\n" +
                                "                      AND (I.CAD_MTMD_DT_INICIO_CONS >= TO_DATE('" + DateTime.Parse(dto.DataInicioConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')\n" +
                                "                      AND  I.CAD_MTMD_DT_INICIO_CONS <= TO_DATE('" + DateTime.Parse(dto.DataLimiteConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy'))\n" +
                                "                      AND  I.CAD_MTMD_ID = ITEM.CAD_MTMD_ID \n" +
                                "                      AND ((SELECT COUNT(I2.CAD_MTMD_ID)\n" +
                                "                              FROM TB_CAD_MTMD_PRESCRICAO_ITEM I2\n" +
                                "                              WHERE I2.CAD_MTMD_PRESCRICAO_ID = I.CAD_MTMD_PRESCRICAO_ID AND\n" +
                                "                                    I2.CAD_MTMD_ID = I.CAD_MTMD_ID AND\n" +
                                "                                    I2.CAD_MTMD_PRC_ITEM_STATUS = 0 AND\n" +
                                "                                    I2.CAD_MTMD_PRC_QTDE_TOTAL != I.CAD_MTMD_PRC_QTDE_TOTAL)>0))/\n" +
                                "                   (SELECT COUNT(M.CAD_MTMD_ID)\n" +
                                "                    FROM TB_CAD_MTMD_PRESCRICAO_ITEM I JOIN TB_CAD_MTMD_PRESCRICAO PRC ON PRC.CAD_MTMD_PRESCRICAO_ID = I.CAD_MTMD_PRESCRICAO_ID JOIN\n" +
                                "                         TB_CAD_MTMD_MAT_MED M ON M.CAD_MTMD_ID = I.CAD_MTMD_ID\n" +
                                "                    WHERE I.CAD_MTMD_PRC_ITEM_STATUS = 1 AND PRC.CAD_MTMD_PRESCRICAO_STATUS = 1\n" +
                                "                      AND (I.CAD_MTMD_DT_INICIO_CONS >= TO_DATE('" + DateTime.Parse(dto.DataInicioConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')\n" +
                                "                      AND  I.CAD_MTMD_DT_INICIO_CONS <= TO_DATE('" + DateTime.Parse(dto.DataLimiteConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy'))\n" +
                                "                      AND  I.CAD_MTMD_ID = ITEM.CAD_MTMD_ID)) PERC_MODIFICADOS\n" +
                                "FROM TB_CAD_MTMD_PRESCRICAO_ITEM ITEM JOIN TB_CAD_MTMD_PRESCRICAO PRC ON PRC.CAD_MTMD_PRESCRICAO_ID = ITEM.CAD_MTMD_PRESCRICAO_ID JOIN\n" +
                                "     TB_CAD_MTMD_MAT_MED MED ON MED.CAD_MTMD_ID = ITEM.CAD_MTMD_ID\n" +
                                "WHERE ITEM.CAD_MTMD_PRC_ITEM_STATUS = 1 AND PRC.CAD_MTMD_PRESCRICAO_STATUS = 1\n" +
                                "    AND (ITEM.CAD_MTMD_DT_INICIO_CONS >= TO_DATE('" + DateTime.Parse(dto.DataInicioConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')\n" +
                                "    AND  ITEM.CAD_MTMD_DT_INICIO_CONS <= TO_DATE('" + DateTime.Parse(dto.DataLimiteConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')) " +
                                " ORDER BY MED.CAD_MTMD_NOMEFANTASIA";        

            DataTable result = new DataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);
            return result;
        }

        public DataTable ListarFormulariosCompletos(PrescricaoDTO dto)
        {
            string sqlString = "SELECT  TO_CHAR(TO_DATE('" + DateTime.Parse(dto.DataInicioConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy'),'dd/MM/yyyy') PERIODO_DATA_INICIO,\n" +
                                "       TO_CHAR(TO_DATE('" + DateTime.Parse(dto.DataLimiteConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy'),'dd/MM/yyyy') PERIODO_DATA_FIM,\n" +
                                "       QTD_TOTAL_PRESCRICOES_PERIODO,\n" +
                                "       (SELECT COUNT(PRC.CAD_MTMD_PRESCRICAO_ID) QTD_PRESCRICOES\n" +
                                "          FROM TB_CAD_MTMD_PRESCRICAO PRC\n" +
                                "          WHERE PRC.CAD_MTMD_PRESCRICAO_STATUS = 1 \n" +
                                "           AND (PRC.CAD_MTMD_DT_INCLUSAO >= TO_DATE('" + DateTime.Parse(dto.DataInicioConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')\n" +
                                "           AND  PRC.CAD_MTMD_DT_INCLUSAO <= TO_DATE('" + DateTime.Parse(dto.DataLimiteConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')) " +
                                "           AND  PRC.CAD_MTMD_PRC_PESO IS NOT NULL AND\n" +
                                "                PRC.CAD_MTMD_PRC_CREATININA IS NOT NULL AND\n" +
                                "                PRC.CAD_MTMD_DT_ASSINATURA_SCIH IS NOT NULL AND\n" +
                                "                (PRC.CAD_MTMD_PRC_INTERNADO_UTI IS NOT NULL OR\n" +
                                "                 PRC.CAD_MTMD_PRC_VENTILA_MECANICA IS NOT NULL OR\n" +
                                "                 PRC.CAD_MTMD_PRC_CIRURGIA IS NOT NULL OR\n" +
                                "                 PRC.CAD_MTMD_PRC_ACESSO_VASCULAR IS NOT NULL OR\n" +
                                "                 PRC.CAD_MTMD_PRC_SONDA_VESICAL IS NOT NULL OR\n" +
                                "                 PRC.CAD_MTMD_PRC_OUTROS IS NOT NULL) AND\n" +
                                "                 (SELECT COUNT(*) FROM TB_CAD_MTMD_PRESCRICAO_CULTURA CULT\n" +
                                "                   WHERE CULT.CAD_MTMD_PRESCRICAO_ID = PRC.CAD_MTMD_PRESCRICAO_ID) > 0 AND\n" +
                                "                 (SELECT COUNT(*) FROM TB_CAD_MTMD_PRESCRICAO_DODI DODI\n" +
                                "                   WHERE DODI.CAD_MTMD_PRESCRICAO_ID = PRC.CAD_MTMD_PRESCRICAO_ID) > 0) QTD_COMPLETAS,\n" +
                                "       (SELECT COUNT(PRC.CAD_MTMD_PRESCRICAO_ID) QTD_PRESCRICOES\n" +
                                "          FROM TB_CAD_MTMD_PRESCRICAO PRC\n" +
                                "          WHERE PRC.CAD_MTMD_PRESCRICAO_STATUS = 1 \n" +
                                "            AND (PRC.CAD_MTMD_DT_INCLUSAO >= TO_DATE('" + DateTime.Parse(dto.DataInicioConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')\n" +
                                "            AND  PRC.CAD_MTMD_DT_INCLUSAO <= TO_DATE('" + DateTime.Parse(dto.DataLimiteConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')) " +
                                "            AND NOT\n" +
                                "                (PRC.CAD_MTMD_PRC_PESO IS NOT NULL AND\n" +
                                "                 PRC.CAD_MTMD_PRC_CREATININA IS NOT NULL AND\n" +
                                "                 PRC.CAD_MTMD_DT_ASSINATURA_SCIH IS NOT NULL AND\n" +
                                "                (PRC.CAD_MTMD_PRC_INTERNADO_UTI IS NOT NULL OR\n" +
                                "                 PRC.CAD_MTMD_PRC_VENTILA_MECANICA IS NOT NULL OR\n" +
                                "                 PRC.CAD_MTMD_PRC_CIRURGIA IS NOT NULL OR\n" +
                                "                 PRC.CAD_MTMD_PRC_ACESSO_VASCULAR IS NOT NULL OR\n" +
                                "                 PRC.CAD_MTMD_PRC_SONDA_VESICAL IS NOT NULL OR\n" +
                                "                 PRC.CAD_MTMD_PRC_OUTROS IS NOT NULL) AND\n" +
                                "                 (SELECT COUNT(*) FROM TB_CAD_MTMD_PRESCRICAO_CULTURA CULT\n" +
                                "                   WHERE CULT.CAD_MTMD_PRESCRICAO_ID = PRC.CAD_MTMD_PRESCRICAO_ID) > 0 AND\n" +
                                "                 (SELECT COUNT(*) FROM TB_CAD_MTMD_PRESCRICAO_DODI DODI\n" +
                                "                   WHERE DODI.CAD_MTMD_PRESCRICAO_ID = PRC.CAD_MTMD_PRESCRICAO_ID) > 0)) QTD_INCOMPLETAS\n" +
                                "FROM\n" +
                                "(SELECT COUNT(PRC.CAD_MTMD_PRESCRICAO_ID) QTD_TOTAL_PRESCRICOES_PERIODO\n" +
                                "  FROM TB_CAD_MTMD_PRESCRICAO PRC\n" +
                                "  WHERE PRC.CAD_MTMD_PRESCRICAO_STATUS = 1 \n" +
                                "    AND (PRC.CAD_MTMD_DT_INCLUSAO >= TO_DATE('" + DateTime.Parse(dto.DataInicioConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')\n" +
                                "    AND  PRC.CAD_MTMD_DT_INCLUSAO <= TO_DATE('" + DateTime.Parse(dto.DataLimiteConsumo.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy'))) ";

            DataTable result = new DataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);
            return result;
        }

        public DataTable ListarDataAtualizacaoItemPrescricao(decimal idtPrescricao)
        {
            string sqlString = string.Format(@"SELECT DATA_ATUALIZACAO,IDUSUARIOATUALIZACAO,USU.SEG_USU_DS_LOGIN LOGINUSUARIOATUALIZACAO,USU.SEG_USU_DS_NOME USUARIOATUALIZACAO FROM " +
            "(SELECT DISTINCT DPM.ATD_DPM_DT_ULT_ATUALIZ DATA_ATUALIZACAO,DPM.ATD_DPM_ID_USU_ULT_ATUALIZ IDUSUARIOATUALIZACAO FROM SGS.TB_ATD_DPM_DIETA_PRESC_MED DPM WHERE DPM.ATD_PME_ID =  {0}" +
            "  UNION SELECT DISTINCT MPM.ATD_MPM_DT_ULT_ATUALIZ DATA_ATUALIZACAO, MPM.ATD_MPM_ID_USU_ULT_ATUALIZ IDUSUARIOATUALIZACAO FROM SGS.TB_ATD_MPM_MED_PRESC_MED MPM WHERE MPM.ATD_PME_ID =  {0}" +
            "  UNION SELECT DISTINCT EPM.ATD_EPM_DT_ULT_ATUALIZ DATA_ATUALIZACAO, EPM.ATD_EPM_ID_USU_ULT_ATUALIZ IDUSUARIOATUALIZACAO FROM SGS.TB_ATD_EPM_EXAME_PRESC_MED EPM WHERE EPM.ATD_PME_ID =  {0}" +
            "  UNION SELECT DISTINCT CPM.ATD_CPM_DT_ULT_ATUALIZ DATA_ATUALIZACAO, CPM.ATD_CPM_ID_USU_ULT_ATUALIZ IDUSUARIOATUALIZACAO FROM SGS.TB_ATD_CPM_CUID_ESP_PRESC_MED CPM WHERE CPM.ATD_PME_ID = {0}" +
            "  )  JOIN SGS.TB_SEG_USU_USUARIO USU ON USU.SEG_USU_ID_USUARIO = IDUSUARIOATUALIZACAO " +
            " ORDER BY DATA_ATUALIZACAO DESC", idtPrescricao);

            DataTable result = new DataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);
            return result;
        }
    }
}