
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class Requisicao : Entity
    {
        /// <summary>
        /// Listar todos os registros
        /// </summary>
        public RequisicaoDataTable Sel(RequisicaoDTO dto, bool apenasComQtdSolicitada)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pMTMD_REQ_ID
            param.Add(Connection.CreateParameter("pMTMD_REQ_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pATD_ATE_ID
            param.Add(Connection.CreateParameter("pATD_ATE_ID", dto.IdtAtendimento.DBValue, ParameterDirection.Input, dto.IdtAtendimento.DbType));

            //Parametro pATD_ATE_TP_PACIENTE
            param.Add(Connection.CreateParameter("pATD_ATE_TP_PACIENTE", dto.TpAtendimento.DBValue, ParameterDirection.Input, dto.TpAtendimento.DbType));

            //Parametro pMTMD_REQ_FL_STATUS
            param.Add(Connection.CreateParameter("pMTMD_REQ_FL_STATUS", dto.Status.DBValue, ParameterDirection.Input, dto.Status.DbType));

            //Parametro pMTMD_REQ_DT_ULTIMA_ATUALIZACAO
            param.Add(Connection.CreateParameter("pMTMD_REQ_DT_ATUALIZACAO", dto.DataAtualizacao.DBValue, ParameterDirection.Input, dto.DataAtualizacao.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pMTM_TIPO_REQUISICAO
            param.Add(Connection.CreateParameter("pMTM_TIPO_REQUISICAO", dto.IdtTipoRequisicao.DBValue, ParameterDirection.Input, dto.IdtTipoRequisicao.DbType));

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            //Parametro pMTMD_FL_PENDENTE
            param.Add(Connection.CreateParameter("pMTMD_FL_PENDENTE", dto.FlPendente.DBValue, ParameterDirection.Input, dto.FlPendente.DbType));

            //Parametro pMTMD_DATA_REQUISICAO
            param.Add(Connection.CreateParameter("pMTMD_DATA_REQUISICAO", dto.DataRequisicao.DBValue, ParameterDirection.Input, dto.DataRequisicao.DbType));

            //Parametro pMTMD_DATA_REQUISICAO2
            param.Add(Connection.CreateParameter("pMTMD_DATA_REQUISICAO2", dto.DataRequisicao2.DBValue, ParameterDirection.Input, dto.DataRequisicao2.DbType));

            //Parametro pCOM_QTD_SOL
            if (apenasComQtdSolicitada) param.Add(Connection.CreateParameter("pCOM_QTD_SOL", 1, ParameterDirection.Input, DbType.Byte));

            #endregion

            RequisicaoDataTable result = new RequisicaoDataTable();
            string query = "PRC_MTMD_REQ_REQUISICAO_S";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }

        public RequisicaoDataTable SelImpressaoCentroDispensacao(RequisicaoDTO dto, bool soAtdDomiciliar)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pMTMD_REQ_FL_STATUS
            param.Add(Connection.CreateParameter("pMTMD_REQ_FL_STATUS", dto.Status.DBValue, ParameterDirection.Input, dto.Status.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pMTM_TIPO_REQUISICAO
            param.Add(Connection.CreateParameter("pMTM_TIPO_REQUISICAO", dto.IdtTipoRequisicao.DBValue, ParameterDirection.Input, dto.IdtTipoRequisicao.DbType));

            //Parametro pMTMD_FL_PENDENTE
            param.Add(Connection.CreateParameter("pMTMD_FL_PENDENTE", dto.FlPendente.DBValue, ParameterDirection.Input, dto.FlPendente.DbType));

            //Parametro pSO_ATD_DOMICILIAR
            param.Add(Connection.CreateParameter("pSO_ATD_DOMICILIAR", soAtdDomiciliar ? 1 : 0, ParameterDirection.Input, DbType.Byte));

            #endregion

            RequisicaoDataTable result = new RequisicaoDataTable();
            string query = "PRC_MTMD_REQ_REQUISICAO_IMP_S";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;

        }

        /// <summary>
        /// Listar o registro utilizando PK
        /// </summary>
        public RequisicaoDTO SelChave(RequisicaoDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            // Parametro pMTMD_REQ_ID
            param.Add(Connection.CreateParameter("pMTMD_REQ_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            #endregion

            RequisicaoDataTable result = new RequisicaoDataTable();
            string query = "PRC_MTMD_REQ_REQUISICAO_S";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            if (result.Rows.Count > 0)
            {
                return result.TypedRow(0);
            }
            else
            {
                return new RequisicaoDTO();
            }
        }

        /// <summary>
        /// Listar as útimas requisições de acordo com o tipo e status
        /// </summary>
        public RequisicaoDataTable SelUltimas(RequisicaoDTO dto, int qtdUltimas)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pMTMD_REQ_FL_STATUS
            param.Add(Connection.CreateParameter("pMTMD_REQ_FL_STATUS", dto.Status.DBValue, ParameterDirection.Input, dto.Status.DbType));

            //Parametro pMTM_TIPO_REQUISICAO
            param.Add(Connection.CreateParameter("pMTM_TIPO_REQUISICAO", dto.IdtTipoRequisicao.DBValue, ParameterDirection.Input, dto.IdtTipoRequisicao.DbType));

            //Parametro pMTMD_FL_PENDENTE
            param.Add(Connection.CreateParameter("pMTMD_FL_PENDENTE", dto.FlPendente.DBValue, ParameterDirection.Input, dto.FlPendente.DbType));

            //Parametro pQtdUltimas
            param.Add(Connection.CreateParameter("pQtdUltimas", qtdUltimas, ParameterDirection.Input, DbType.Int16));

            #endregion

            RequisicaoDataTable result = new RequisicaoDataTable();
            string query = "PRC_MTMD_REQ_REQ_ULTIMAS";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }

        /// <summary>
        /// Pesqusia requições do Paciente em Aberto 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public RequisicaoDataTable RequisicaoPaciente(RequisicaoDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pMTMD_REQ_ID
            // param.Add(Connection.CreateParameter("pMTMD_REQ_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pATD_ATE_ID
            param.Add(Connection.CreateParameter("pATD_ATE_ID", dto.IdtAtendimento.DBValue, ParameterDirection.Input, dto.IdtAtendimento.DbType));

            //Parametro pATD_ATE_TP_PACIENTE
            param.Add(Connection.CreateParameter("pATD_ATE_TP_PACIENTE", dto.TpAtendimento.DBValue, ParameterDirection.Input, dto.TpAtendimento.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            #endregion

            RequisicaoDataTable result = new RequisicaoDataTable();
            string query = "PRC_MTMD_REQ_REQUISICAO_PAC";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }

        public RequisicaoDataTable ListarPacienteKits(RequisicaoDTO dto)
        {
            string sqlString = string.Format("SELECT REQUISICAO.MTMD_REQ_ID,\n" +
                                            "       REQUISICAO.ATD_ATE_ID,\n" +
                                            "       REQUISICAO.ATD_ATE_TP_PACIENTE,\n" +
                                            "       REQUISICAO.MTMD_REQ_FL_STATUS,\n" +
                                            "       REQUISICAO.MTMD_REQ_DT_ATUALIZACAO,\n" +
                                            "       REQUISICAO.MTMD_DATA_REQUISICAO,\n" +
                                            "       REQUISICAO.MTM_TIPO_REQUISICAO,\n" +
                                            "       REQUISICAO.CAD_MTMD_KIT_ID,\n" +
                                            "       KIT.CAD_MTMD_KIT_DSC,\n" +
                                            "\n" +
                                            "       (SELECT SUM(I.MTMD_REQITEM_QTD_SOLICITADA)\n" +
                                            "          FROM TB_MTMD_REQUISICAO_ITEM I\n" +
                                            "         WHERE I.MTMD_REQ_ID = REQUISICAO.MTMD_REQ_ID) QTD_SOLICITADA,\n" +
                                            "\n" +
                                            "       ((SELECT SUM(I.MTMD_REQITEM_QTD_SOLICITADA) QTD_SOLICITADA\n" +
                                            "          FROM TB_MTMD_REQUISICAO_ITEM I\n" +
                                            "         WHERE I.MTMD_REQ_ID = REQUISICAO.MTMD_REQ_ID) -\n" +
                                            "       (SELECT SUM(I.MTMD_REQITEM_QTD_FORNECIDA) MTMD_REQITEM_QTD_FORNECIDA\n" +
                                            "          FROM TB_MTMD_REQUISICAO_ITEM I\n" +
                                            "         WHERE I.MTMD_REQ_ID = REQUISICAO.MTMD_REQ_ID)) QTD_PENDENTE\n" +
                //"       ((SELECT SUM(I.MTMD_REQITEM_QTD_SOLICITADA) QTD_SOLICITADA\n" + 
                //"          FROM TB_MTMD_REQUISICAO_ITEM I\n" + 
                //"         WHERE I.MTMD_REQ_ID = REQUISICAO.MTMD_REQ_ID) -\n" + 
                //"        (SELECT NVL(SUM(MOVIMENTACAO.MTMD_MOV_QTDE), 0) QTD_CONSUMO\n" + 
                //"          FROM TB_MTMD_MOV_MOVIMENTACAO MOVIMENTACAO\n" + 
                //"         WHERE MOVIMENTACAO.CAD_MTMD_TPMOV_ID = 2\n" + 
                //"           AND MOVIMENTACAO.CAD_MTMD_SUBTP_ID IN (11, 18, 24, 25)\n" + 
                //"           AND MOVIMENTACAO.MTMD_MOV_FL_ESTORNO = 0\n" + 
                //"           AND MOVIMENTACAO.ATD_ATE_ID = REQUISICAO.ATD_ATE_ID\n" + 
                //"           AND MOVIMENTACAO.CAD_SET_ID = REQUISICAO.CAD_SET_ID\n" + 
                //"           AND MOVIMENTACAO.MTMD_REQ_ID = REQUISICAO.MTMD_REQ_ID)) QTD_PENDENTE\n" + 
                                            "\n" +
                                            "FROM TB_MTMD_REQ_REQUISICAO REQUISICAO JOIN\n" +
                                            "     TB_CAD_MTMD_KIT KIT ON KIT.CAD_MTMD_KIT_ID = REQUISICAO.CAD_MTMD_KIT_ID\n" +
                                            "WHERE REQUISICAO.ATD_ATE_ID = {0}\n" +
                                            "  AND REQUISICAO.CAD_SET_ID = {1}\n" +
                                            "  AND REQUISICAO.MTMD_REQ_FL_STATUS IN (2,3,5) --FECHADA, DISPENSADA, IMPRESSA\n" +
                                            "  AND REQUISICAO.CAD_MTMD_KIT_ID IS NOT NULL\n" +
                                            "ORDER BY REQUISICAO.MTMD_DATA_REQUISICAO DESC",
                                            dto.IdtAtendimento.Value,
                                            dto.IdtSetor.Value);

            RequisicaoDataTable result = new RequisicaoDataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);

            return result;
        }

        /// <summary>
        /// Exclui o todos os registros inclusive os itens da requisição
        /// </summary>        
        public void Del(RequisicaoDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            // Parametro pMTMD_REQ_ID
            param.Add(Connection.CreateParameter("pMTMD_REQ_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            #endregion
            //Executa o procedimento

            string query = "PRC_MTMD_REQ_REQUISICAO_D";

            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Altera o registro
        /// </summary>			
        public void Upd(RequisicaoDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pMTMD_REQ_ID
            param.Add(Connection.CreateParameter("pMTMD_REQ_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pMTMD_REQ_FL_STATUS
            param.Add(Connection.CreateParameter("pMTMD_REQ_FL_STATUS", dto.Status.DBValue, ParameterDirection.Input, dto.Status.DbType));

            //SEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));

            //MTMD_REQ_ID_REF
            param.Add(Connection.CreateParameter("pMTMD_REQ_ID_REF", dto.IdtReqRef.DBValue, ParameterDirection.Input, dto.IdtReqRef.DbType));

            //Parametro pMTMD_REQ_FL_URGENCIA
            param.Add(Connection.CreateParameter("pMTMD_REQ_FL_URGENCIA", dto.Urgencia.DBValue, ParameterDirection.Input, dto.Urgencia.DbType));

            #endregion

            string query = "PRC_MTMD_REQ_REQUISICAO_U";

            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
        }


        public void DispensarRequisicao(RequisicaoDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pMTMD_REQ_ID
            param.Add(Connection.CreateParameter("pMTMD_REQ_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //SEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));

            #endregion

            string query = "PRC_MTMD_REQ_ITEM_DISPENSA";

            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);


        }

        /// <summary>
        /// Inclui o registro
        /// </summary>			
        public void Ins(RequisicaoDTO dto)
        {
            string query = "PRC_MTMD_REQ_REQUISICAO_I";

            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pATD_ATE_ID
            param.Add(Connection.CreateParameter("pATD_ATE_ID", dto.IdtAtendimento.DBValue, ParameterDirection.Input, dto.IdtAtendimento.DbType));

            //Parametro pATD_ATE_TP_PACIENTE
            param.Add(Connection.CreateParameter("pATD_ATE_TP_PACIENTE", dto.TpAtendimento.DBValue, ParameterDirection.Input, dto.TpAtendimento.DbType));

            //Parametro pMTMD_REQ_FL_STATUS
            param.Add(Connection.CreateParameter("pMTMD_REQ_FL_STATUS", dto.Status.DBValue, ParameterDirection.Input, dto.Status.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pMTMD_REQ_ID
            param.Add(Connection.CreateParameter("pMTM_TIPO_REQUISICAO", dto.IdtTipoRequisicao.DBValue, ParameterDirection.Input, dto.IdtTipoRequisicao.DbType));

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            //SEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));

            //Parametro pMTMD_FL_PENDENTE
            param.Add(Connection.CreateParameter("pMTMD_FL_PENDENTE", dto.FlPendente.DBValue, ParameterDirection.Input, dto.FlPendente.DbType));

            //Parametro pMTMD_REQ_ID_REF
            param.Add(Connection.CreateParameter("pMTMD_REQ_ID_REF", dto.IdtReqRef.DBValue, ParameterDirection.Input, dto.IdtReqRef.DbType));

            //Parametro pCAD_MTMD_KIT_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_KIT_ID", dto.IdKit.DBValue, ParameterDirection.Input, dto.IdKit.DbType));

            //Parametro pCAD_SET_SETOR_FARMACIA
            param.Add(Connection.CreateParameter("pCAD_SET_SETOR_FARMACIA", dto.SetorFarmacia.DBValue, ParameterDirection.Input, dto.SetorFarmacia.DbType));

            //Parametro pMTMD_REQ_FL_URGENCIA
            param.Add(Connection.CreateParameter("pMTMD_REQ_FL_URGENCIA", dto.Urgencia.DBValue, ParameterDirection.Input, dto.Urgencia.DbType));

            param.Add(Connection.CreateParameterSequence());

            #endregion

            // Executa o Procedimento
            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
            dto.Idt.Value = Int32.Parse(param["pNewIdt"].Value.ToString());
        }

        public void InsParamPedidoAuto(RequisicaoDTO dto)
        {
            string query;
            string dataFimVigencia = "NULL";
            if (!dto.SetorPedidoAutoDtHoraFimVigencia.Value.IsNull)
                dataFimVigencia = "TO_DATE('" + DateTime.Parse(dto.SetorPedidoAutoDtHoraFimVigencia.Value.ToString()).ToString("ddMMyyyy HHmm") + "','ddMMyyyy HH24MI')";

            query = string.Format("INSERT INTO TB_MTMD_REQUISICAO_AUTO_SETOR(CAD_SET_ID, RAS_DATA_HORA_INI_VIG, RAS_DATA_HORA_FIM_VIG, " +
                                                                             "RAS_HORA_INICIO_PROCESSO, RAS_QTD_HRS_TOTAL_GERAR, RAS_QTD_HRS_PERIODO_GERAR, RAS_QTD_HRS_MINIMA_INICIAR, " +
                                                                             "RAS_SEG_USU_ID_USUARIO, RAS_DT_ATUALIZACAO, RAS_FL_EXCLUIDO, RAS_FL_REQ_NAO_GERAR) " +
                                  "VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, SYSDATE, 0, {8})", dto.IdtSetor.Value,
                                                                                                  "TO_DATE('" + DateTime.Parse(dto.SetorPedidoAutoDtHoraIniVigencia.Value.ToString()).ToString("ddMMyyyy HHmm") + "','ddMMyyyy HH24MI')",
                                                                                                  dataFimVigencia,
                                                                                                  dto.SetorPedidoAutoHoraInicioProcesso.Value,
                                                                                                  dto.SetorPedidoAutoHorasTotaisGerar.Value,
                                                                                                  dto.SetorPedidoAutoHorasPeriodoDose.Value,
                                                                                                  dto.SetorPedidoAutoHorasMinimaIniciar.Value,
                                                                                                  dto.IdtUsuario.Value,
                                                                                                  dto.SetorPedidoAutoFlNaoGerar.Value);

            Connection.ExecuteCommand(query);
        }

        public void UpdParamPedidoAuto(RequisicaoDTO dto)
        {
            string query;
            string dataFimVigencia = "NULL";
            if (!dto.SetorPedidoAutoDtHoraFimVigencia.Value.IsNull)
                dataFimVigencia = "TO_DATE('" + DateTime.Parse(dto.SetorPedidoAutoDtHoraFimVigencia.Value.ToString()).ToString("ddMMyyyy HHmm") + "','ddMMyyyy HH24MI')";

            query = "UPDATE TB_MTMD_REQUISICAO_AUTO_SETOR SET " +
                        "   RAS_DATA_HORA_INI_VIG = " + "TO_DATE('" + DateTime.Parse(dto.SetorPedidoAutoDtHoraIniVigencia.Value.ToString()).ToString("ddMMyyyy HHmm") + "','ddMMyyyy HH24MI')" +
                        " , RAS_DATA_HORA_FIM_VIG = " + dataFimVigencia +
                        " , RAS_HORA_INICIO_PROCESSO = " + dto.SetorPedidoAutoHoraInicioProcesso.Value +
                        " , RAS_QTD_HRS_TOTAL_GERAR = " + dto.SetorPedidoAutoHorasTotaisGerar.Value +
                        " , RAS_QTD_HRS_PERIODO_GERAR = " + dto.SetorPedidoAutoHorasPeriodoDose.Value +
                        " , RAS_QTD_HRS_MINIMA_INICIAR = " + dto.SetorPedidoAutoHorasMinimaIniciar.Value +
                        " , RAS_SEG_USU_ID_USUARIO = " + dto.IdtUsuario.Value +
                        " , RAS_FL_REQ_NAO_GERAR = " + dto.SetorPedidoAutoFlNaoGerar.Value +
                        " , RAS_DT_ATUALIZACAO = SYSDATE" +
                    " WHERE CAD_SET_ID = " + dto.IdtSetor.Value +
                        " AND RAS_DATA_HORA_INI_VIG = TO_DATE('" + DateTime.Parse(dto.SetorPedidoAutoDtHoraIniVigencia.Value.ToString()).ToString("ddMMyyyy HHmm") + "','ddMMyyyy HH24MI')";

            Connection.ExecuteCommand(query);
        }

        public void DelParamPedidoAuto(RequisicaoDTO dto)
        {
            string query;
            query = "UPDATE TB_MTMD_REQUISICAO_AUTO_SETOR SET " +
                        "   RAS_FL_EXCLUIDO = 1\n" +
                        " , RAS_SEG_USU_ID_USUARIO = " + dto.IdtUsuario.Value +
                        " , RAS_DT_ATUALIZACAO = SYSDATE" +
                    " WHERE CAD_SET_ID = " + dto.IdtSetor.Value +
                        " AND RAS_DATA_HORA_INI_VIG = TO_DATE('" + DateTime.Parse(dto.SetorPedidoAutoDtHoraIniVigencia.Value.ToString()).ToString("ddMMyyyy HHmm") + "','ddMMyyyy HH24MI')";

            Connection.ExecuteCommand(query);
        }

        public RequisicaoDataTable ListarParamPedidoAuto(RequisicaoDTO dto)
        {
            string filtros = string.Empty;

            if (!dto.IdtSetor.Value.IsNull)
                filtros += " AND RAS.CAD_SET_ID = " + dto.IdtSetor.Value.ToString() + "\n";

            if (!dto.SetorPedidoAutoDtHoraIniVigencia.Value.IsNull)
                filtros += " AND RAS_DATA_HORA_INI_VIG = TO_DATE('" + DateTime.Parse(dto.SetorPedidoAutoDtHoraIniVigencia.Value.ToString()).ToString("ddMMyyyy HHmm") + "','ddMMyyyy HH24MI')\n";

            if (!dto.SetorPedidoAutoFlItensImediatos.Value.IsNull && dto.SetorPedidoAutoFlItensImediatos.Value == 1)
                filtros += " AND RAS.RAS_FL_IMEDIATO_AUTO = 1 \n";

            if (!dto.SetorPedidoAutoFlTotalImediato.Value.IsNull && dto.SetorPedidoAutoFlTotalImediato.Value == 1)
                filtros += " AND RAS.RAS_FL_REQ_TOTAL_IMEDIATO = 1 \n";

            string queryExec = string.Format("SELECT SETOR.CAD_SET_DS_SETOR,\n" +
                                                "       SETOR.CAD_UNI_ID_UNIDADE,\n" +
                                                "       SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" +
                                                "       RAS.CAD_SET_ID,\n" +
                                                "       RAS_DATA_HORA_INI_VIG,\n" +
                                                "       RAS_DATA_HORA_FIM_VIG,\n" +
                                                "       RAS_HORA_INICIO_PROCESSO,\n" +
                                                "       RAS_QTD_HRS_TOTAL_GERAR,\n" +
                                                "       RAS_QTD_HRS_PERIODO_GERAR,\n" +
                                                "       RAS_QTD_HRS_MINIMA_INICIAR,\n" +
                                                "       NVL(RAS_FL_IMEDIATO_AUTO,0) RAS_FL_IMEDIATO_AUTO,\n" +
                                                "       NVL(RAS_FL_REQ_TOTAL_IMEDIATO,0) RAS_FL_REQ_TOTAL_IMEDIATO,\n" +
                                                "       RAS_FL_REQ_NAO_GERAR,\n" +
                                                "       RAS_SEG_USU_ID_USUARIO,\n" +
                                                "       RAS_DT_ATUALIZACAO\n" +
                                                " FROM TB_MTMD_REQUISICAO_AUTO_SETOR RAS\n" +
                                                " JOIN TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = RAS.CAD_SET_ID\n" +
                                                "WHERE RAS_FL_EXCLUIDO = 0 {0} \n" +
                                                "ORDER BY SETOR.CAD_SET_DS_SETOR,RAS_DATA_HORA_INI_VIG DESC",
                                            filtros);

            RequisicaoDataTable result = new RequisicaoDataTable();
            Connection.RecordSet(queryExec, result, CommandType.Text);
            return result;
        }

        public DataTable ListarPrescricaoInt(RequisicaoDTO dto, int? idPrescInt, string statusItens, bool suspensas)
        {
            string filtros = string.Empty;

            if (!dto.IdtSetor.Value.IsNull)
                filtros += " AND SETOR.CAD_SET_ID = " + dto.IdtSetor.Value.ToString() + "\n";

            if (!dto.IdtAtendimento.Value.IsNull)
                filtros += " AND PRESC.ATD_ATE_ID = " + dto.IdtAtendimento.Value.ToString() + "\n";

            if (!string.IsNullOrEmpty(statusItens))
                filtros += " AND ITEM.ATD_MPM_FL_PEDIDO_EST = '" + statusItens + "'\n";

            if (idPrescInt != null)
                filtros += " AND PRESC.ATD_PME_ID = " + idPrescInt.Value.ToString() + "\n";

            if (!dto.DataRequisicao.Value.IsNull && !dto.DataRequisicao2.Value.IsNull)
                filtros += " AND PRESC.ATD_PME_DT_HR_CRIACAO BETWEEN TO_DATE('" + DateTime.Parse(dto.DataRequisicao.Value.ToString()).ToString("ddMMyyyy HHmm") + "','ddMMyyyy HH24MI') " +
                                                               " AND TO_DATE('" + DateTime.Parse(dto.DataRequisicao2.Value.ToString()).ToString("ddMMyyyy HHmm") + "','ddMMyyyy HH24MI')\n";
            string statusPrescricao = "'A','D'";
            if (suspensas) statusPrescricao = "'S'";

            string queryExec = string.Format("SELECT DISTINCT\n" +
                                            "       CAD_UNI_ID_UNIDADE,\n" +
                                            "       CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" +
                                            "       CAD_SET_ID,\n" +
                                            "       CAD_SET_DS_SETOR,\n" +
                                            "       QUARTO_LEITO,\n" +
                                            "       DT_HORA_ENTRADA,\n" +
                                            "       ID_PRESCRICAO_INT ATD_PME_ID,\n" +
                                            "       ID_PRESCRICAO_INT,\n" +
                                            "       ATD_PME_FL_STATUS,\n" +
                                            "       ATD_ATE_ID,\n" +
                                            "       NOME_PACIENTE,\n" +
                                            "       SEG_USU_ID_INTERV,\n" +
                                            "       SEG_USU_ID_INTERV_ANT,\n" +
                                            "       OBS_FARMACIA,\n" +
                                            "       CATEGORIA_INTERV,\n" +
                                            "       DS_JUSTIF,\n" +
                                            "       OBS_FARMAC_ANT,\n" +
                                            "       (SELECT COUNT(ATD_MPM_ID) FROM TB_ATD_MPM_MED_PRESC_MED\n" +
                                            "         WHERE ATD_PME_ID = ID_PRESCRICAO_INT AND ATD_MPM_TIPO NOT IN ('CND','DIC') AND\n" +
                                            "               ATD_MPM_FL_PEDIDO_EST = 'PE' AND CAD_MTMD_ID IS NOT NULL) QTD_ITENS_PENDENTES,\n" +
                                            "       (SELECT COUNT(ATD_MPM_ID) FROM TB_ATD_MPM_MED_PRESC_MED\n" +
                                            "         WHERE ATD_PME_ID = ID_PRESCRICAO_INT AND ATD_MPM_TIPO NOT IN ('CND','DIC') AND\n" +
                                            "               ATD_MPM_FL_PEDIDO_EST = 'PE' AND CAD_MTMD_ID IS NOT NULL AND ATD_MPM_FL_IMEDIATO = 'S') QTD_IMEDIATOS_PENDENTES,\n" +
                                            "       DT_HR_CRIACAO DT_HORA_PRESCRICAO\n" +
                                            "FROM (SELECT PRESC.ATD_PME_ID ID_PRESCRICAO_INT,\n" +
                                            "             SETOR.CAD_UNI_ID_UNIDADE,\n" +
                                            "             SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" +
                                            "             SETOR.CAD_SET_ID,\n" +
                                            "             SETOR.CAD_SET_DS_SETOR,\n" +
                                            "             SETOR_PRESCRICAO_INT.QUARTO_LEITO,\n" +
                                            "             SETOR_PRESCRICAO_INT.DT_HORA_ENTRADA,\n" +
                                            "             PRESC.ATD_ATE_ID,\n" +
                                            "             PRESC.ATD_PME_FL_STATUS,\n" +
                                            "             ITEM.ATD_MPM_NOME_PACIENTE NOME_PACIENTE,\n" +
                                            "             ITEM.ATD_MPM_FL_PEDIDO_EST STATUS_PRESCRICAO,\n" +
                                            "             PRESC.SEG_USU_ID_INTERV,\n" +
                                            "             PRESC.SEG_USU_ID_INTERV_ANT,\n" +
                                            "             PRESC.ATD_PME_DS_OBS_FARMACIA OBS_FARMACIA,\n" +
                                            "             PRESC.ATD_PME_CATEGORIA_INTERV CATEGORIA_INTERV,\n" +
                                            "             PRESC.ATD_PME_DS_JUSTIF DS_JUSTIF,\n" +
                                            "             PRESC.ATD_PME_DS_OBS_FARMAC_ANT OBS_FARMAC_ANT,\n" +
                                            "             PRESC.ATD_PME_DT_HR_CRIACAO DT_HR_CRIACAO\n" +
                                            "      FROM TB_ATD_MPM_MED_PRESC_MED ITEM JOIN\n" +
                                            "           TB_ATD_PME_PRESCRICAO_MEDICA PRESC ON PRESC.ATD_PME_ID = ITEM.ATD_PME_ID JOIN\n" +
                                            "           TB_CAD_MTMD_MAT_MED PROD ON PROD.CAD_MTMD_ID = ITEM.CAD_MTMD_ID JOIN\n" +
                                            "           (SELECT IML.ATD_ATE_ID, FNC_JUNTAR_DATA_HORA(IML.ATD_IML_DT_ENTRADA,IML.ATD_IML_HR_ENTRADA) DT_HORA_ENTRADA, QLE.CAD_SET_ID, QLE.CAD_QLE_NR_QUARTO || '/' || QLE.CAD_QLE_NR_LEITO QUARTO_LEITO\n" +
                                            "              FROM TB_ATD_IML_INT_MOV_LEITO IML\n" +
                                            "              JOIN TB_CAD_QLE_QUARTO_LEITO QLE ON QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID\n" +
                                            "              JOIN TB_ATD_ATE_ATENDIMENTO ATD ON ATD.ATD_ATE_ID = IML.ATD_ATE_ID\n" +
                                            "             WHERE IML.ATD_IML_FL_STATUS = 'A' AND (IML.ATD_IML_DT_SAIDA IS NULL OR IML.ATD_IML_DT_SAIDA >= SYSDATE-3)\n" +
                                            "               AND FNC_JUNTAR_DATA_HORA(IML.ATD_IML_DT_ENTRADA,IML.ATD_IML_HR_ENTRADA) =\n" +
                                            "                   (SELECT MAX(FNC_JUNTAR_DATA_HORA(IML2.ATD_IML_DT_ENTRADA, IML2.ATD_IML_HR_ENTRADA))\n" +
                                            "                      FROM TB_ATD_IML_INT_MOV_LEITO IML2\n" +
                                            "                     WHERE IML2.ATD_ATE_ID = ATD.ATD_ATE_ID AND IML2.ATD_IML_FL_STATUS = 'A')\n" +
                                            "              UNION\n" +
                                            "              SELECT IMS.ATD_ATE_ID, FNC_JUNTAR_DATA_HORA(IMS.ATD_IMS_DT_ENTRADA,IMS.ATD_IMS_HR_ENTRADA) DT_HORA_ENTRADA, IMS.CAD_SET_ID_SETOR, NULL QUARTO_LEITO\n" +
                                            "                FROM TB_ATD_IMS_INT_MOV_SETOR IMS\n" +
                                            "               WHERE IMS.ATD_IMS_FL_STATUS = 'A' AND IMS.CAD_SET_ID_SETOR IN (22,61)\n" +
                                            "                 AND IMS.ATD_IMS_DT_ENTRADA >= SYSDATE-2 AND IMS.ATD_IMS_DT_SAIDA IS NULL\n" +
                                            "             ) SETOR_PRESCRICAO_INT ON SETOR_PRESCRICAO_INT.ATD_ATE_ID = PRESC.ATD_ATE_ID LEFT JOIN\n" +
                                            "          TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = SETOR_PRESCRICAO_INT.CAD_SET_ID\n" +
                                            "      WHERE PRESC.ATD_PME_FL_STATUS IN (" + statusPrescricao + ") AND ITEM.ATD_MPM_TIPO NOT IN ('CND','DIC') {0} \n" +
                                            "        AND SETOR.CAD_SET_ID IN (SELECT RAS.CAD_SET_ID\n" +
                                            "                                   FROM TB_MTMD_REQUISICAO_AUTO_SETOR RAS\n" +
                                            "                                  WHERE RAS_FL_EXCLUIDO = 0 AND NVL(RAS_FL_REQ_NAO_GERAR,0) = 0 AND RAS.CAD_SET_ID = SETOR.CAD_SET_ID\n" +
                                            "                                    AND (RAS.RAS_DATA_HORA_INI_VIG < SYSDATE AND NVL(RAS.RAS_DATA_HORA_FIM_VIG,SYSDATE+1) > SYSDATE)) \n" +
                                            "      ) ORDER BY DT_HR_CRIACAO",
                                            filtros);

            DataTable result = new DataTable();
            Connection.RecordSet(queryExec, result, CommandType.Text);
            return result;
        }

        public DataTable ListarPrescricaoIntHistorico(RequisicaoDTO dto, int? idPrescInt, bool suspensas)
        {
            string filtros = string.Empty;
            string filtrosPedido = string.Empty;            

            if (!dto.IdtAtendimento.Value.IsNull)
            {
                filtros += " AND PRESC.ATD_ATE_ID = " + dto.IdtAtendimento.Value.ToString() + "\n";
                filtrosPedido += " AND R.ATD_ATE_ID = " + dto.IdtAtendimento.Value.ToString() + "\n";
            }

            if (idPrescInt != null)
            {
                filtros += " AND PRESC.ATD_PME_ID = " + idPrescInt.Value.ToString() + "\n";
                filtrosPedido += " AND I.ATD_PME_ID = " + idPrescInt.Value.ToString() + "\n";
            }

            if (!dto.IdtSetor.Value.IsNull)
            {
                filtros += " AND SETOR.CAD_SET_ID = " + dto.IdtSetor.Value.ToString() + "\n";
                filtrosPedido += " AND R.CAD_SET_ID = " + dto.IdtSetor.Value.ToString() + "\n";

                if (dto.IdtAtendimento.Value.IsNull && idPrescInt == null)
                {
                    filtros += " AND PRESC.ATD_PME_DT_HR_CRIACAO >= TRUNC(SYSDATE-60) \n";
                    filtrosPedido += " AND R.MTMD_DATA_REQUISICAO >= TRUNC(SYSDATE-60) \n";
                }
            }

            if (string.IsNullOrEmpty(filtros))
            {
                filtros += " AND PRESC.ATD_PME_DT_HR_CRIACAO >= TRUNC(SYSDATE-1) \n";
                filtrosPedido += " AND R.MTMD_DATA_REQUISICAO >= TRUNC(SYSDATE-1) \n";
            }

            string statusPrescricao = "'A','D','S'";
            if (suspensas) statusPrescricao = "'S'";

            string queryExec = string.Format("SELECT DISTINCT\n" +
                                            "       CAD_UNI_ID_UNIDADE,\n" +
                                            "       CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" +
                                            "       CAD_SET_ID,\n" +
                                            "       CAD_SET_DS_SETOR,\n" +
                                            "       ID_PRESCRICAO_INT ATD_PME_ID,\n" +
                                            "       ID_PRESCRICAO_INT,\n" +
                                            "       ATD_PME_FL_STATUS,\n" +
                                            "       ATD_ATE_ID,\n" +
                                            "       NOME_PACIENTE,\n" +
                                            "       SEG_USU_ID_INTERV,\n" +
                                            "       SEG_USU_ID_INTERV_ANT,\n" +
                                            "       OBS_FARMACIA,\n" +
                                            "       CATEGORIA_INTERV,\n" +
                                            "       DS_JUSTIF,\n" +
                                            "       OBS_FARMAC_ANT,\n" +
                                            "       (SELECT COUNT(ATD_MPM_ID) FROM TB_ATD_MPM_MED_PRESC_MED\n" +
                                            "         WHERE ATD_PME_ID = ID_PRESCRICAO_INT AND ATD_MPM_TIPO NOT IN ('CND','DIC') AND\n" +
                                            "               ATD_MPM_FL_PEDIDO_EST = 'PE' AND CAD_MTMD_ID IS NOT NULL) QTD_ITENS_PENDENTES,\n" +
                                            "       (SELECT COUNT(ATD_MPM_ID) FROM TB_ATD_MPM_MED_PRESC_MED\n" +
                                            "         WHERE ATD_PME_ID = ID_PRESCRICAO_INT AND ATD_MPM_TIPO NOT IN ('CND','DIC') AND\n" +
                                            "               ATD_MPM_FL_PEDIDO_EST = 'PE' AND CAD_MTMD_ID IS NOT NULL AND ATD_MPM_FL_IMEDIATO = 'S') QTD_IMEDIATOS_PENDENTES,\n" +
                                            "       DT_HR_CRIACAO DT_HORA_PRESCRICAO\n" +
                                            "FROM (SELECT PRESC.ATD_PME_ID ID_PRESCRICAO_INT,\n" +
                                            "             SETOR.CAD_UNI_ID_UNIDADE,\n" +
                                            "             SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" +
                                            "             SETOR.CAD_SET_ID,\n" +
                                            "             SETOR.CAD_SET_DS_SETOR,\n" +
                                            "             PRESC.ATD_ATE_ID,\n" +
                                            "             PRESC.ATD_PME_FL_STATUS,\n" +
                                            "             ITEM.ATD_MPM_NOME_PACIENTE NOME_PACIENTE,\n" +
                                            "             ITEM.ATD_MPM_FL_PEDIDO_EST STATUS_PRESCRICAO,\n" +
                                            "             PRESC.SEG_USU_ID_INTERV,\n" +
                                            "             PRESC.SEG_USU_ID_INTERV_ANT,\n" +
                                            "             PRESC.ATD_PME_DS_OBS_FARMACIA OBS_FARMACIA,\n" +
                                            "             PRESC.ATD_PME_CATEGORIA_INTERV CATEGORIA_INTERV,\n" +
                                            "             PRESC.ATD_PME_DS_JUSTIF DS_JUSTIF,\n" +
                                            "             PRESC.ATD_PME_DS_OBS_FARMAC_ANT OBS_FARMAC_ANT,\n" +
                                            "             PRESC.ATD_PME_DT_HR_CRIACAO DT_HR_CRIACAO\n" +
                                            "      FROM TB_ATD_MPM_MED_PRESC_MED ITEM JOIN\n" +
                                            "           TB_ATD_PME_PRESCRICAO_MEDICA PRESC ON PRESC.ATD_PME_ID = ITEM.ATD_PME_ID JOIN\n" +
                                            "           TB_CAD_MTMD_MAT_MED PROD ON PROD.CAD_MTMD_ID = ITEM.CAD_MTMD_ID JOIN\n" +
                                            "           (SELECT DISTINCT ATD_ATE_ID, CAD_SET_ID\n" +
                                            "              FROM TB_MTMD_REQ_REQUISICAO R JOIN\n" +
                                            "                   TB_MTMD_REQUISICAO_ITEM I ON I.MTMD_REQ_ID = R.MTMD_REQ_ID\n" +
                                            "             WHERE R.MTM_TIPO_REQUISICAO = 0 AND I.ATD_PME_ID IS NOT NULL {1} \n" +
                                            "             ) SETOR_PRESCRICAO_INT ON SETOR_PRESCRICAO_INT.ATD_ATE_ID = PRESC.ATD_ATE_ID LEFT JOIN\n" +
                                            "          TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = SETOR_PRESCRICAO_INT.CAD_SET_ID\n" +
                                            "      WHERE PRESC.ATD_PME_FL_STATUS IN (" + statusPrescricao + ") AND ITEM.ATD_MPM_TIPO NOT IN ('CND','DIC') AND ITEM.ATD_MPM_FL_PEDIDO_EST IN ('GE','SU') {0} \n" +
                                            "        AND SETOR.CAD_SET_ID IN (SELECT DISTINCT RAS.CAD_SET_ID\n" +
                                            "                                   FROM sgs.TB_MTMD_REQUISICAO_AUTO_SETOR RAS\n" +
                                            "                                  WHERE RAS.CAD_SET_ID = SETOR.CAD_SET_ID AND NVL(RAS_FL_REQ_NAO_GERAR,0) = 0)\n" +
                                            "      ) ORDER BY DT_HR_CRIACAO",
                                            filtros, filtrosPedido);

            DataTable result = new DataTable();
            Connection.RecordSet(queryExec, result, CommandType.Text);
            return result;
        }

        public void UpdOBSPrescricaoInt(int idPrescInternacao, string observacao, int idUsuario, string categoria)
        {
            string query;
            query = "UPDATE TB_ATD_PME_PRESCRICAO_MEDICA SET " +
                        "   ATD_PME_DS_OBS_FARMACIA = '" + observacao + "'" +
                        " , ATD_PME_CATEGORIA_INTERV = '" + categoria + "'" +
                        " , SEG_USU_ID_INTERV = " + idUsuario +
                    " WHERE ATD_PME_ID = " + idPrescInternacao;

            Connection.ExecuteCommand(query);
        }

        public void ReplicarPedidos(int idTpReq, int idSetor, DateTime dtInicio, DateTime dtFim, bool apenasFornecidos, bool farmacia, int idUsuario)
        {
            string strApenaFornecidos = "NULL";
            if (apenasFornecidos) strApenaFornecidos = "1";

            string strFarmacia = " R.CAD_SET_SETOR_FARMACIA IS NULL AND\n";
            if (farmacia) strFarmacia = " R.CAD_SET_SETOR_FARMACIA IS NOT NULL AND\n";

            string sqlString =  "DECLARE\n" +
                                "pNewIdt integer;\n" +
                                "BEGIN\n" +
                                "FOR X IN (SELECT * FROM TB_MTMD_REQ_REQUISICAO R\n" +
                                "           WHERE R.MTM_TIPO_REQUISICAO = " + idTpReq + " AND\n" +
                                "                 R.CAD_SET_ID = " + idSetor + " AND\n" + strFarmacia +
                                "                 TRUNC(R.MTMD_DATA_REQUISICAO) BETWEEN TO_DATE('" + dtInicio.ToString("ddMMyyyy") + "', 'ddMMyyyy')\n" +
                                "                                                   AND TO_DATE('" + dtFim.ToString("ddMMyyyy") + "', 'ddMMyyyy') AND\n" +
                                "                (" + strApenaFornecidos + " IS NULL OR (SELECT SUM(RI.MTMD_REQITEM_QTD_FORNECIDA)\n" +
                                "                                                          FROM TB_MTMD_REQUISICAO_ITEM RI\n" +
                                "                                                         WHERE RI.MTMD_REQ_ID = R.MTMD_REQ_ID) > 0)\n" +
                                "           ORDER BY R.MTMD_DATA_REQUISICAO\n" +
                                ") LOOP\n" +
                                "BEGIN\n" +
                                "  sgs.prc_mtmd_req_requisicao_i(X.ATD_ATE_ID,\n" +
                                "                                X.ATD_ATE_TP_PACIENTE,\n" +
                                "                                2, -- => :pmtmd_req_fl_status,\n" +
                                "                                X.CAD_SET_ID,\n" +
                                "                                X.CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" +
                                "                                X.CAD_UNI_ID_UNIDADE,\n" +
                                "                                X.MTM_TIPO_REQUISICAO,\n" +
                                "                                X.CAD_MTMD_FILIAL_ID,\n" +
                                "                                " + idUsuario + ",\n" +
                                "                                0, -- => :pmtmd_fl_pendente\n" +
                                "                                X.MTMD_REQ_ID, -- => :pmtmd_req_id_ref\n" +
                                "                                X.CAD_MTMD_KIT_ID,\n" +
                                "                                X.CAD_SET_SETOR_FARMACIA,\n" +
                                "                                0, -- => :pmtmd_req_fl_urgencia,\n" +
                                "                                pNewIdt);\n" +
                                "\n" +
                                "  FOR ITENS IN (SELECT * FROM TB_MTMD_REQUISICAO_ITEM ITEM\n" +
                                "                 WHERE ITEM.MTMD_REQ_ID = X.MTMD_REQ_ID AND\n" +
                                "                       MTMD_ID_ORIGINAL IS NULL\n" +
                                "  ) LOOP\n" +
                                "\n" +
                                "    sgs.prc_mtmd_requisicao_item_i(pNewIdt, --=> :pmtmd_req_id\n" +
                                "                                   ITENS.CAD_MTMD_ID,\n" +
                                "                                   ITENS.MTMD_REQITEM_QTD_SOLICITADA,\n" +
                                "                                   0, -- => :pmtmd_reqitem_qtd_fornecida\n" +
                                "                                   NULL, -- => :pmtmd_id_original\n" +
                                "                                   NULL, -- => :pcad_mtmd_prescricao_id\n" +
                                "                                   NULL, -- ITENS.CAD_MTMD_KIT_ID_ITEM,\n" +
                                "                                   NULL, -- ITENS.MTMD_QTD_KIT_MULTIPLICA,\n" +
                                "                                   NULL, -- => :patd_mpm_id\n" +
                                "                                   NULL, -- => :patd_pme_id\n" +
                                "                                   NULL, -- => :pmtmd_reqitem_cancel_just\n" +
                                "                                   NULL); -- => :pmtmd_req_via\n" +
                                "  END LOOP;\n" +
                                "\n" +
                                "END;\n" +
                                "END LOOP;\n" +
                                "END;";

            Connection.ExecuteCommand(sqlString);
        }
    }
}