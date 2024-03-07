
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using System.Data.OracleClient;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class RequisicaoItens : Entity
    {

        private OracleError trataErro = new OracleError();
		/// <summary>
        /// Listar todos os registros
        /// </summary>
        public RequisicaoItensDataTable Sel(RequisicaoItensDTO dto)
        {            
			return this.Sel(dto, false, false);
		}

        public RequisicaoItensDataTable Sel(RequisicaoItensDTO dto, bool ordenarEndereco, bool ordenarEndereco2)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pMTMD_REQ_ID
            param.Add(Connection.CreateParameter("pMTMD_REQ_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            //Parametro pCAD_MTMD_PRESCRICAO_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_PRESCRICAO_ID", dto.IdPrescricao.DBValue, ParameterDirection.Input, dto.IdPrescricao.DbType));

            //Parametro pATD_PME_ID
            param.Add(Connection.CreateParameter("pATD_PME_ID", dto.IdPrescricaoInternacao.DBValue, ParameterDirection.Input, dto.IdPrescricaoInternacao.DbType));

            //Parametro pATD_MPM_ID
            param.Add(Connection.CreateParameter("pATD_MPM_ID", dto.IdPrescricaoItemInternacao.DBValue, ParameterDirection.Input, dto.IdPrescricaoItemInternacao.DbType));

            if (ordenarEndereco)
                param.Add(Connection.CreateParameter("pORDENAR_ENDERECO", 1, ParameterDirection.Input, DbType.Int16));
            else if (ordenarEndereco2)
                param.Add(Connection.CreateParameter("pORDENAR_ENDERECO_02", 1, ParameterDirection.Input, DbType.Int16));

            #endregion

            RequisicaoItensDataTable result = new RequisicaoItensDataTable();
            string query = "PRC_MTMD_REQUISICAO_ITEM_S";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }

        public RequisicaoItensDataTable SelOrdenadoKit(RequisicaoItensDTO dto)
        {
            string filtros = string.Empty;

            if (!dto.Idt.Value.IsNull)
                filtros += " ITEM.MTMD_REQ_ID = " + dto.Idt.Value + "\n";
            else
                return null; //Para obrigar passar Pedido

            if (!dto.IdtProduto.Value.IsNull)
                filtros += " AND ITEM.CAD_MTMD_ID = " + dto.IdtProduto.Value + "\n";

            if (!dto.IdPrescricao.Value.IsNull)
                filtros += " AND ITEM.CAD_MTMD_PRESCRICAO_ID = " + dto.IdPrescricao.Value + "\n";

            string sqlString = "SELECT ITEM.MTMD_REQ_ID,\n" +
                                "       ITEM.CAD_MTMD_ID,\n" +
                                "       RIK.MTMD_REQITEM_QTD_SOLICITADA,\n" +
                                "       ITEM.MTMD_REQITEM_QTD_FORNECIDA,\n" +
                                "       FNC_MTMD_SOUNDALIKE(PRODUTO.CAD_MTMD_NOMEFANTASIA,PRODUTO.CAD_MTMD_GRUPO_ID) CAD_MTMD_NOMEFANTASIA,\n" +
                                "       PRODUTO.CAD_MTMD_UNID_VENDA_DS,\n" +
                                "       FNC_MTMD_PRINCIPIO_ATIVO (ITEM.CAD_MTMD_ID) CAD_MTMD_PRIATI_ID,\n" +
                                "       NVL(PRODUTO_PAI.CAD_MTMD_SUBGRUPO_ID,PRODUTO.CAD_MTMD_SUBGRUPO_ID) CAD_MTMD_SUBGRUPO_ID,\n" +
                                "       ITEM.CAD_MTMD_PRESCRICAO_ID,\n" +
                                "       ITEM.MTMD_REQ_DATA,\n" +
                                "       ITEM.MTMD_REQ_VIA,\n" +
                                "       ITEM.MTMD_FL_GELADEIRA,\n" +
                                "       REQ.ATD_ATE_ID,\n" +
                                "       REQ.MTMD_REQ_FL_STATUS,\n" +
                                "       REQ.MTMD_DATA_REQUISICAO,\n" +
                                "       REQ.MTMD_DATA_DISPENSACAO,\n" +
                                "       USU_REQUISICAO.SEG_USU_DS_NOME DS_USUARIO_REQUISICAO,\n" +
                                "       NVL(PRODUTO_PAI.CAD_MTMD_FL_MAV,PRODUTO.CAD_MTMD_FL_MAV) CAD_MTMD_FL_MAV,\n" +
                                "       NVL(PRODUTO_PAI.CAD_MTMD_GRUPO_ID,PRODUTO.CAD_MTMD_GRUPO_ID) CAD_MTMD_GRUPO_ID,\n" +
                                "       PRODUTO.CAD_MTMD_ENDERECO_ALMOX_HAC,\n" +
                                "       PRODUTO.CAD_MTMD_ENDERECO_ALMOX_ACS,\n" +
                                "       REQ.CAD_SET_SETOR_FARMACIA,\n" +
                                "       NVL(RIK.CAD_MTMD_KIT_ID_ITEM, ITEM.CAD_MTMD_KIT_ID_ITEM) CAD_MTMD_KIT_ID_ITEM,\n" +
                                "       KIT.CAD_MTMD_KIT_DSC,\n" +
                                "       NVL(PRODUTO_PAI.CAD_MTMD_NOMEFANTASIA,PRODUTO.CAD_MTMD_NOMEFANTASIA) PRODUTO_PAI_KIT\n" +
                                "FROM TB_MTMD_REQUISICAO_ITEM_KIT RIK JOIN\n" +
                                "     TB_MTMD_REQ_REQUISICAO  REQ ON REQ.MTMD_REQ_ID = RIK.MTMD_REQ_ID JOIN\n" +
                                "     TB_MTMD_REQUISICAO_ITEM ITEM ON ITEM.MTMD_REQ_ID = RIK.MTMD_REQ_ID AND ITEM.CAD_MTMD_ID = RIK.CAD_MTMD_ID_REF JOIN\n" +
                                "     TB_CAD_MTMD_MAT_MED PRODUTO ON PRODUTO.CAD_MTMD_ID = RIK.CAD_MTMD_ID_REF LEFT JOIN\n" +
                                "     TB_CAD_MTMD_MAT_MED PRODUTO_PAI ON PRODUTO_PAI.CAD_MTMD_ID = RIK.CAD_MTMD_ID_KIT LEFT JOIN\n" +
                                "     TB_CAD_MTMD_KIT KIT ON KIT.CAD_MTMD_KIT_ID = NVL(RIK.CAD_MTMD_KIT_ID_ITEM, ITEM.CAD_MTMD_KIT_ID_ITEM) LEFT JOIN\n" +
                                "     TB_SEG_USU_USUARIO USU_REQUISICAO ON USU_REQUISICAO.SEG_USU_ID_USUARIO = REQ.MTMD_ID_USUARIO_REQUISICAO\n" +
                                "WHERE \n" + filtros +
                                "ORDER BY NVL(PRODUTO_PAI.CAD_MTMD_NOMEFANTASIA,PRODUTO.CAD_MTMD_NOMEFANTASIA),\n" +
                                "         ITEM.CAD_MTMD_KIT_ID_ITEM, PRODUTO.TIS_MED_CD_TABELAMEDICA DESC,\n" +
                                "         PRODUTO.CAD_MTMD_ENDERECO_ALMOX_ACS, PRODUTO.CAD_MTMD_NOMEFANTASIA";

            RequisicaoItensDataTable result = new RequisicaoItensDataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);

            return result;
        }

        /// <summary>
        /// Retorna quantidade solicitada na requisição
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public RequisicaoItensDTO SelQtdeSolicitada(RequisicaoItensDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            // param.Add(Connection.CreateParameterCursor());
            param.Add(Connection.CreateParameterSequence());

            //Parametro pMTMD_REQ_ID
            param.Add(Connection.CreateParameter("pMTMD_REQ_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            //Parametro 
            param.Add(Connection.CreateParameter("pCAD_MTMD_PRIATI_ID", dto.IdtPrincipioAtivo.DBValue, ParameterDirection.Input, dto.IdtPrincipioAtivo.DbType));


            #endregion

            RequisicaoItensDataTable result = new RequisicaoItensDataTable();
            string query = "PRC_MTMD_REQ_ITEM_QTDE";

            //Executa o procedimento
            /*
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
            if (result.Rows.Count > 0)
            {
                return result.TypedRow(0);
            }
            else
            {
                return null;
            }
            */
            try
            {
                Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
                dto.QtdSolicitada.Value = Int32.Parse(param["pNewIdt"].Value.ToString());
                return dto;
            }
            catch (OracleException ex)
            {
                // ex.Number
                throw new Exception(string.Format("{0} CÓDIGO RETORNADO: {1} ", ex.Message, ex.Code));

            }
        }

        /// <summary>
        /// Busca item pendente
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public RequisicaoItensDataTable SelReqItensPendentes(RequisicaoDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            // Parametro pMTMD_REQ_ID
            param.Add(Connection.CreateParameter("pMTMD_REQ_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            // Parametro pATD_ATE_ID
            param.Add(Connection.CreateParameter("pATD_ATE_ID", dto.IdtAtendimento.DBValue, ParameterDirection.Input, dto.IdtAtendimento.DbType));

            #endregion

            RequisicaoItensDataTable result = new RequisicaoItensDataTable();
            string query = "PRC_MTMD_REQ_ITEM_PENDENTE";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;

        }

        public RequisicaoItensDataTable SelReqItensPendentes(int idSetor)
        {
            RequisicaoItensDataTable result = new RequisicaoItensDataTable();
            string query = 
            "SELECT REQUISICAO.ATD_ATE_ID,\n" +
            "       REQUISICAO.MTMD_REQ_ID,\n" + 
            "       SUM((DECODE( ITEM.MTMD_ID_ORIGINAL, NULL,\n" + 
            "               (ITEM.MTMD_REQITEM_QTD_SOLICITADA -\n" + 
            "                FNC_MTMD_REQ_SOMA_SIMILAR( ITEM.CAD_MTMD_ID,\n" + 
            "                                            ITEM.MTMD_REQ_ID,\n" + 
            "                                            FNC_MTMD_PRINCIPIO_ATIVO (ITEM.CAD_MTMD_ID))),\n" + 
            "               ITEM.MTMD_REQITEM_QTD_SOLICITADA\n" + 
            "             ) -\n" + 
            "       ITEM.MTMD_REQITEM_QTD_FORNECIDA)) QTD_PENDENTE\n" + 
            "      FROM TB_MTMD_REQUISICAO_ITEM       ITEM,\n" + 
            "           TB_MTMD_REQ_REQUISICAO        REQUISICAO\n" + 
            "      WHERE REQUISICAO.MTM_TIPO_REQUISICAO = 0 --PERSONALIZADO\n" + 
            "      AND   REQUISICAO.MTMD_REQ_FL_STATUS NOT IN (0,1,3,6)--CANCELADA, ABERTA EM DIGITAC?O e DISPENSADA\n" + 
            "      AND   REQUISICAO.CAD_SET_ID    = " + idSetor.ToString() + "\n" + 
            "      AND   REQUISICAO.MTMD_REQ_ID   = ITEM.MTMD_REQ_ID\n" + 
            "      AND   (ITEM.MTMD_REQITEM_QTD_FORNECIDA +\n" + 
            "             FNC_MTMD_REQ_SOMA_SIMILAR ( ITEM.CAD_MTMD_ID,\n" + 
            "                                         ITEM.MTMD_REQ_ID,\n" + 
            "                                         FNC_MTMD_PRINCIPIO_ATIVO (ITEM.CAD_MTMD_ID))) !=\n" + 
            "                                        (DECODE( ITEM.MTMD_ID_ORIGINAL, NULL,\n" + 
            "                                                 -- SE FOR ITEM ORIGINAL RETORNA QTD SOLICITADA\n" + 
            "                                                 ITEM.MTMD_REQITEM_QTD_SOLICITADA ,\n" + 
            "                                                 -- SE FOR ITEM SIMILAR E QTDE SOLICITADA + SOMA DE\n" + 
            "                                                 -- OUTROS ITENS SE EXISTIR\n" + 
            "                                                (ITEM.MTMD_REQITEM_QTD_SOLICITADA +\n" + 
            "                                                  FNC_MTMD_REQ_SOMA_SIMILAR( ITEM.CAD_MTMD_ID,\n" + 
            "                                                                             ITEM.MTMD_REQ_ID,\n" + 
            "                                                                             FNC_MTMD_PRINCIPIO_ATIVO (ITEM.CAD_MTMD_ID))\n" + 
            "                                                )))\n" + 
            "      GROUP BY REQUISICAO.ATD_ATE_ID, REQUISICAO.MTMD_REQ_ID\n" + 
            "      ORDER BY REQUISICAO.ATD_ATE_ID, REQUISICAO.MTMD_REQ_ID";

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }

        public RequisicaoItensDataTable SelReqItensPendentesConsumoPac(int idAtendimento, int? idProduto, int? idSetor)
        {
            if (idProduto == null) idProduto = 0;
            if (idSetor == null) idSetor = 0;
            RequisicaoItensDataTable result = new RequisicaoItensDataTable();
            string query = "SELECT CAD_MTMD_ID,\n" +
                            "      CAD_MTMD_NOMEFANTASIA,\n" +
                            "      CAD_MTMD_FL_MAV,\n" +
                            "      QTD_FORNECIDA,\n" +
                            "      QTD_CONSUMO,\n" +
                            "      QTD_FORNECIDA-QTD_CONSUMO QTD_PENDENTE,\n" +
                            "      CAD_SET_CD_SETOR,\n" +
                            "      CAD_SET_DS_SETOR\n" +
                            "FROM\n" +
                            "(SELECT ITEM.CAD_MTMD_ID,\n" +
                            "        PRODUTO.CAD_MTMD_NOMEFANTASIA,\n" +
                            "        PRODUTO.CAD_MTMD_FL_MAV, SETOR.CAD_SET_CD_SETOR, SETOR.CAD_SET_DS_SETOR,\n" +
                            "        NVL((SELECT SUM(IT.MTMD_REQITEM_QTD_FORNECIDA)\n" +
                            "             FROM TB_MTMD_REQUISICAO_ITEM IT JOIN\n" +
                            "                  TB_MTMD_REQ_REQUISICAO REQ ON REQ.MTMD_REQ_ID = IT.MTMD_REQ_ID JOIN\n" +
                            "                  TB_CAD_MTMD_MAT_MED PROD ON PROD.CAD_MTMD_ID = IT.CAD_MTMD_ID\n" +
                            "             WHERE REQ.MTMD_REQ_FL_STATUS IN (4)\n" +
                            "             AND   REQ.CAD_SET_ID = REQUISICAO.CAD_SET_ID\n" +
                            "             AND   REQ.ATD_ATE_ID = REQUISICAO.ATD_ATE_ID\n" +
                            "             AND  (PROD.CAD_MTMD_ID = ITEM.CAD_MTMD_ID OR (PROD.CAD_MTMD_PRIATI_ID <> 0 AND PROD.CAD_MTMD_PRIATI_ID = PRODUTO.CAD_MTMD_PRIATI_ID))),0) QTD_FORNECIDA,\n" +
                            "       NVL((SELECT SUM(MOVIMENTACAO.MTMD_MOV_QTDE) QTD_CONSUMO\n" +
                            "              FROM TB_MTMD_MOV_MOVIMENTACAO MOVIMENTACAO JOIN\n" +
                            "                   TB_CAD_MTMD_MAT_MED PRODUTO2 ON PRODUTO2.CAD_MTMD_ID = MOVIMENTACAO.CAD_MTMD_ID LEFT JOIN\n" +
                            "                   TB_MTMD_REQ_REQUISICAO REQ ON REQ.MTMD_REQ_ID = MOVIMENTACAO.MTMD_REQ_ID\n" +
                            "              WHERE MOVIMENTACAO.CAD_MTMD_TPMOV_ID = 2\n" +
                            "                AND MOVIMENTACAO.CAD_MTMD_SUBTP_ID IN (11,60)\n" +
                            "                AND MOVIMENTACAO.CAD_MTMD_FILIAL_ID = 1\n" +
                            "                AND MOVIMENTACAO.CAD_SET_ID = REQUISICAO.CAD_SET_ID\n" +
                            "                AND MOVIMENTACAO.MTMD_MOV_FL_ESTORNO = 0\n" +
                            "                AND REQ.CAD_MTMD_KIT_ID IS NULL\n" +
                            "                AND PRODUTO2.CAD_MTMD_FL_FRACIONA = 0\n" +
                            "                AND (PRODUTO2.CAD_MTMD_ID = ITEM.CAD_MTMD_ID OR (PRODUTO2.CAD_MTMD_PRIATI_ID <> 0 AND PRODUTO2.CAD_MTMD_PRIATI_ID = PRODUTO.CAD_MTMD_PRIATI_ID))\n" +
                            "                AND MOVIMENTACAO.ATD_ATE_ID = REQUISICAO.ATD_ATE_ID),0) QTD_CONSUMO\n" +
                            "      FROM TB_MTMD_REQUISICAO_ITEM       ITEM,\n" +
                            "           TB_MTMD_REQ_REQUISICAO        REQUISICAO,\n" +
                            "           TB_CAD_MTMD_MAT_MED           PRODUTO,\n" +
                            "           TB_CAD_SET_SETOR              SETOR\n" +
                            "      WHERE REQUISICAO.MTMD_REQ_FL_STATUS IN (4)\n" +
                            "      AND   REQUISICAO.CAD_MTMD_FILIAL_ID = 1\n" +
                            "      AND   REQUISICAO.CAD_MTMD_KIT_ID IS NULL\n" +
                            "      AND   REQUISICAO.ATD_ATE_ID    = " + idAtendimento.ToString() + "\n" +
                            "      AND   (" + idProduto.Value.ToString() + " = 0 OR ITEM.CAD_MTMD_ID = " + idProduto.Value.ToString() + ")\n" +
                            "      AND   (" + idSetor.Value.ToString() + " = 0 OR REQUISICAO.CAD_SET_ID = " + idSetor.Value.ToString() + ")\n" +
                            "      AND   PRODUTO.CAD_MTMD_FL_FRACIONA = 0\n" +
                            "      AND   ITEM.MTMD_REQITEM_QTD_FORNECIDA > 0\n" +
                            "      AND   REQUISICAO.MTMD_REQ_ID   = ITEM.MTMD_REQ_ID\n" +
                            "      AND   PRODUTO.CAD_MTMD_ID      = ITEM.CAD_MTMD_ID\n" +
                            "      AND   SETOR.CAD_SET_ID         = REQUISICAO.CAD_SET_ID\n" +
                            "GROUP BY ITEM.CAD_MTMD_ID,PRODUTO.CAD_MTMD_NOMEFANTASIA,PRODUTO.CAD_MTMD_PRIATI_ID,PRODUTO.CAD_MTMD_FL_MAV,REQUISICAO.ATD_ATE_ID,REQUISICAO.CAD_SET_ID,SETOR.CAD_SET_CD_SETOR,SETOR.CAD_SET_DS_SETOR\n" +
                            "ORDER BY PRODUTO.CAD_MTMD_NOMEFANTASIA)\n" +
                            "WHERE QTD_CONSUMO < QTD_FORNECIDA";

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }

        public DataTable SelPendenciasConsumoPacSetores(int idAtendimento)
        {
            DataTable result = new DataTable();
            string query = "SELECT DISTINCT PEDIDOS.CAD_UNI_ID_UNIDADE, PEDIDOS.CAD_LAT_ID_LOCAL_ATENDIMENTO, PEDIDOS.CAD_SET_ID, SETOR.CAD_SET_DS_SETOR\n" +
                            "FROM\n" +
                            "(SELECT ITEM.CAD_MTMD_ID,\n" +
                            "        PRODUTO.CAD_MTMD_NOMEFANTASIA,\n" +
                            "        REQUISICAO.CAD_UNI_ID_UNIDADE,REQUISICAO.CAD_LAT_ID_LOCAL_ATENDIMENTO,REQUISICAO.CAD_SET_ID,\n" +
                            "        NVL((SELECT SUM(IT.MTMD_REQITEM_QTD_FORNECIDA)\n" +
                            "             FROM TB_MTMD_REQUISICAO_ITEM IT JOIN\n" + 
                            "                  TB_MTMD_REQ_REQUISICAO REQ ON REQ.MTMD_REQ_ID = IT.MTMD_REQ_ID JOIN\n" + 
                            "                  TB_CAD_MTMD_MAT_MED PROD ON PROD.CAD_MTMD_ID = IT.CAD_MTMD_ID\n" + 
                            "             WHERE REQ.MTMD_REQ_FL_STATUS IN (4)\n" + 
                            "             AND   REQ.CAD_SET_ID = REQUISICAO.CAD_SET_ID\n" + 
                            "             AND   REQ.ATD_ATE_ID = REQUISICAO.ATD_ATE_ID\n" +
                            "             AND  (PROD.CAD_MTMD_ID = ITEM.CAD_MTMD_ID OR (PROD.CAD_MTMD_PRIATI_ID <> 0 AND PROD.CAD_MTMD_PRIATI_ID = PRODUTO.CAD_MTMD_PRIATI_ID))),0) QTD_FORNECIDA,\n" +
                            "       NVL((SELECT SUM(MOVIMENTACAO.MTMD_MOV_QTDE) QTD_CONSUMO\n" +
                            "              FROM TB_MTMD_MOV_MOVIMENTACAO MOVIMENTACAO JOIN\n" +
                            "                   TB_CAD_MTMD_MAT_MED PRODUTO2 ON PRODUTO2.CAD_MTMD_ID = MOVIMENTACAO.CAD_MTMD_ID LEFT JOIN\n" +
                            "                   TB_MTMD_REQ_REQUISICAO REQ ON REQ.MTMD_REQ_ID = MOVIMENTACAO.MTMD_REQ_ID\n" +
                            "              WHERE MOVIMENTACAO.CAD_MTMD_TPMOV_ID = 2\n" +
                            "                AND MOVIMENTACAO.CAD_MTMD_SUBTP_ID IN (11,60)\n" +
                            "                AND MOVIMENTACAO.CAD_MTMD_FILIAL_ID = 1\n" +
                            "                AND MOVIMENTACAO.CAD_SET_ID = REQUISICAO.CAD_SET_ID\n" +
                            "                AND MOVIMENTACAO.MTMD_MOV_FL_ESTORNO = 0\n" +
                            "                AND REQ.CAD_MTMD_KIT_ID IS NULL\n" +
                            "                AND PRODUTO2.CAD_MTMD_FL_FRACIONA = 0\n" +
                            "                AND (PRODUTO2.CAD_MTMD_ID = ITEM.CAD_MTMD_ID OR (PRODUTO2.CAD_MTMD_PRIATI_ID <> 0 AND PRODUTO2.CAD_MTMD_PRIATI_ID = PRODUTO.CAD_MTMD_PRIATI_ID))\n" +
                            "                AND MOVIMENTACAO.ATD_ATE_ID = REQUISICAO.ATD_ATE_ID),0) QTD_CONSUMO\n" +
                            "      FROM TB_MTMD_REQUISICAO_ITEM       ITEM,\n" +
                            "           TB_MTMD_REQ_REQUISICAO        REQUISICAO,\n" +
                            "           TB_CAD_MTMD_MAT_MED           PRODUTO\n" +
                            "      WHERE REQUISICAO.MTMD_REQ_FL_STATUS IN (4)\n" +
                            "      AND   REQUISICAO.CAD_MTMD_FILIAL_ID = 1\n" +
                            "      AND   REQUISICAO.CAD_MTMD_KIT_ID IS NULL\n" +
                            "      AND   REQUISICAO.ATD_ATE_ID    = " + idAtendimento.ToString() + "\n" +                            
                            "      AND   PRODUTO.CAD_MTMD_FL_FRACIONA = 0\n" +
                            "      AND   ITEM.MTMD_REQITEM_QTD_FORNECIDA > 0\n" +
                            "      AND   REQUISICAO.MTMD_REQ_ID   = ITEM.MTMD_REQ_ID\n" +
                            "      AND   PRODUTO.CAD_MTMD_ID      = ITEM.CAD_MTMD_ID\n" +
                            "GROUP BY REQUISICAO.CAD_UNI_ID_UNIDADE,REQUISICAO.CAD_LAT_ID_LOCAL_ATENDIMENTO,REQUISICAO.CAD_SET_ID,\n" +
                            "         ITEM.CAD_MTMD_ID,PRODUTO.CAD_MTMD_NOMEFANTASIA,PRODUTO.CAD_MTMD_PRIATI_ID,PRODUTO.CAD_MTMD_FL_MAV,REQUISICAO.ATD_ATE_ID\n" +
                            "ORDER BY PRODUTO.CAD_MTMD_NOMEFANTASIA) PEDIDOS JOIN TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = PEDIDOS.CAD_SET_ID\n" +
                            "WHERE PEDIDOS.QTD_CONSUMO < PEDIDOS.QTD_FORNECIDA";

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }

        public RequisicaoItensDataTable SelPedidosReqItenPac(int? idAtendimento, int? idProduto, int? idPedido)
        {
            return this.SelPedidosReqItenPac(idAtendimento, idProduto, idPedido, null);
        }

        public RequisicaoItensDataTable SelPedidosReqItenPac(int? idAtendimento, int? idProduto, int? idPedido, int? statusPedido)
        {
            if (statusPedido == null) statusPedido = (int)RequisicaoDTO.StatusRequisicao.RECEBIDA_UNIDADE;
            if (idAtendimento == null) idAtendimento = 0;
            if (idProduto == null) idProduto = 0;
            if (idPedido == null) idPedido = 0;
            RequisicaoItensDataTable result = new RequisicaoItensDataTable();
            string query = "SELECT SETOR.CAD_SET_DS_SETOR,SETOR.CAD_SET_ID,SETOR.CAD_UNI_ID_UNIDADE,SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" +
                            "       ITEM.MTMD_REQ_ID,REQUISICAO.ATD_ATE_ID,\n" +
                            "       FNC_MTMD_ESTOQUE_UNIDADE(ITEM.CAD_MTMD_ID,\n" +
                            "                                REQUISICAO.CAD_UNI_ID_UNIDADE,\n" +
                            "                                REQUISICAO.CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" +
                            "                                REQUISICAO.CAD_SET_ID,\n" +
                            "                                REQUISICAO.CAD_MTMD_FILIAL_ID,NULL) MTMD_ESTLOC_QTDE,\n" +
                            "       ITEM.MTMD_REQITEM_QTD_FORNECIDA\n" +
                            "FROM TB_MTMD_REQUISICAO_ITEM       ITEM,\n" +
                            "     TB_MTMD_REQ_REQUISICAO        REQUISICAO,\n" +
                            "     TB_CAD_MTMD_MAT_MED           PRODUTO,\n" +
                            "     TB_CAD_SET_SETOR              SETOR\n" +
                            "WHERE REQUISICAO.MTMD_REQ_FL_STATUS IN (" + statusPedido + ")\n" +
                            "AND   REQUISICAO.CAD_MTMD_KIT_ID IS NULL\n" +
                            "AND   REQUISICAO.CAD_MTMD_FILIAL_ID = 1\n" +
                            "AND   REQUISICAO.MTMD_REQ_ID   = ITEM.MTMD_REQ_ID\n" +
                            "AND   PRODUTO.CAD_MTMD_ID      = ITEM.CAD_MTMD_ID\n" +
                            "AND   SETOR.CAD_SET_ID         = REQUISICAO.CAD_SET_ID\n" +            
                            "AND   (" + idAtendimento.Value.ToString() + " = 0 OR REQUISICAO.ATD_ATE_ID = " + idAtendimento.Value.ToString() + ")\n" +
                            "AND   (" + idProduto.Value.ToString() + " = 0 OR ITEM.CAD_MTMD_ID = " + idProduto.Value.ToString() + ")\n" +
                            "AND   (" + idPedido.Value.ToString() + " = 0 OR ITEM.MTMD_REQ_ID = " + idPedido.Value.ToString() + ")\n" +
                            "ORDER BY SETOR.CAD_SET_DS_SETOR,ITEM.MTMD_REQ_ID DESC";

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }        

        public RequisicaoItensDataTable SelReqItensLotesPendentesConsumoPac(int idAtendimento, int idSetor)
        {
            RequisicaoItensDataTable result = new RequisicaoItensDataTable();
            string query = "SELECT PENDENCIAS.CAD_MTMD_ID,\n" +
                        "       PENDENCIAS.CAD_MTMD_NOMEFANTASIA,\n" +
                        "       PENDENCIAS.QTD_FORNECIDA QTD_FORNECIDA_TOTAL,\n" +
                        "       PENDENCIAS.QTD_CONSUMO QTD_CONSUMO_TOTAL,\n" +
                        "       PENDENCIAS.QTD_FORNECIDA-PENDENCIAS.QTD_CONSUMO QTD_PENDENTE,\n" +
                        "       PENDENCIAS.CAD_UNI_ID_UNIDADE,\n" +
                        "       PENDENCIAS.CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" +
                        "       PENDENCIAS.CAD_SET_ID,\n" +
                        "       PENDENCIAS.CAD_SET_CD_SETOR,\n" +
                        "       PENDENCIAS.CAD_SET_DS_SETOR,\n" +
                        "       PENDENCIAS.CAD_MTMD_PRESCRICAO_ID,\n" +
                        "       PEDIDOS.MTMD_REQ_ID,\n" +
                        "       PEDIDOS.QTD_FORNECIDA,\n" +
                        "       PEDIDOS.MTMD_COD_LOTE,\n" +
                        "       NVL(PEDIDOS.MTMD_LOTEST_ID,0) MTMD_LOTEST_ID,\n" +
                        "       CASE\n" +
                        "         WHEN (PEDIDOS.QTD_FORNECIDA > (PENDENCIAS.QTD_FORNECIDA-PENDENCIAS.QTD_CONSUMO)) THEN\n" +
                        "            PENDENCIAS.QTD_FORNECIDA-PENDENCIAS.QTD_CONSUMO\n" +
                        "         ELSE\n" +
                        "            PEDIDOS.QTD_FORNECIDA\n" +
                        "       END QTD_TRANSFERIR,\n" + 
                        "       CASE\n" +
                        "         WHEN PENDENCIAS.CAD_MTMD_GRUPO_ID = 1 AND PEDIDOS.MTMD_COD_LOTE != 'SEM_LOTE' THEN\n" +
                        "             SGS.FNC_MTMD_ESTOQUE_LOTE_SETOR(PENDENCIAS.CAD_MTMD_ID,\n" +
                        "                                             PENDENCIAS.CAD_UNI_ID_UNIDADE,\n" +
                        "                                             PENDENCIAS.CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" +
                        "                                             PENDENCIAS.CAD_SET_ID,\n" +
                        "                                             1,\n" +
                        "                                             PEDIDOS.MTMD_LOTEST_ID,\n" +
                        "                                             NULL,\n" +
                        "                                             1)\n" +
                        "         WHEN PENDENCIAS.CAD_MTMD_GRUPO_ID = 1 AND PEDIDOS.MTMD_COD_LOTE = 'SEM_LOTE' THEN\n" +
                        "             SGS.FNC_MTMD_EST_SEMLOTE_SETOR(PENDENCIAS.CAD_MTMD_ID,\n" +
                        "                                            PENDENCIAS.CAD_UNI_ID_UNIDADE,\n" +
                        "                                            PENDENCIAS.CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" +
                        "                                            PENDENCIAS.CAD_SET_ID,\n" +
                        "                                            1)\n" +
                        "          ELSE\n" +
                        "             SGS.FNC_MTMD_ESTOQUE_UNIDADE(PENDENCIAS.CAD_MTMD_ID,\n" +
                        "                                          PENDENCIAS.CAD_UNI_ID_UNIDADE,\n" +
                        "                                          PENDENCIAS.CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" +
                        "                                          PENDENCIAS.CAD_SET_ID,\n" +
                        "                                          1,\n" +
                        "                                          NULL)\n" +
                        "       END SALDO_SETOR\n" +
                        "FROM (SELECT ITEM.CAD_MTMD_ID,\n" +
                        "             PRODUTO.CAD_MTMD_NOMEFANTASIA,\n" +
                        "             PRODUTO.CAD_MTMD_FL_MAV,PRODUTO.CAD_MTMD_GRUPO_ID,ITEM.CAD_MTMD_PRESCRICAO_ID,\n" +
                        "             REQUISICAO.CAD_UNI_ID_UNIDADE,REQUISICAO.CAD_LAT_ID_LOCAL_ATENDIMENTO,REQUISICAO.CAD_SET_ID,SETOR.CAD_SET_CD_SETOR,SETOR.CAD_SET_DS_SETOR,\n" +
                        "             NVL((SELECT SUM(IT.MTMD_REQITEM_QTD_FORNECIDA)\n" +
                        "                    FROM TB_MTMD_REQUISICAO_ITEM IT JOIN\n" +
                        "                         TB_MTMD_REQ_REQUISICAO REQ ON REQ.MTMD_REQ_ID = IT.MTMD_REQ_ID JOIN\n" +
                        "                         TB_CAD_MTMD_MAT_MED PROD ON PROD.CAD_MTMD_ID = IT.CAD_MTMD_ID\n" +
                        "                   WHERE REQ.MTMD_REQ_FL_STATUS IN (4)\n" +
                        "                   AND   REQ.CAD_SET_ID = REQUISICAO.CAD_SET_ID\n" +
                        "                   AND   REQ.ATD_ATE_ID = REQUISICAO.ATD_ATE_ID\n" +
                        "                   AND  (PROD.CAD_MTMD_ID = ITEM.CAD_MTMD_ID OR (PROD.CAD_MTMD_PRIATI_ID <> 0 AND PROD.CAD_MTMD_PRIATI_ID = PRODUTO.CAD_MTMD_PRIATI_ID))),0) QTD_FORNECIDA,\n" +
                        "             NVL((SELECT SUM(MOVIMENTACAO.MTMD_MOV_QTDE) QTD_CONSUMO\n" +
                        "                    FROM TB_MTMD_MOV_MOVIMENTACAO MOVIMENTACAO JOIN\n" +
                        "                         TB_CAD_MTMD_MAT_MED PRODUTO2 ON PRODUTO2.CAD_MTMD_ID = MOVIMENTACAO.CAD_MTMD_ID LEFT JOIN\n" +
                        "                         TB_MTMD_REQ_REQUISICAO REQ ON REQ.MTMD_REQ_ID = MOVIMENTACAO.MTMD_REQ_ID\n" +
                        "                    WHERE MOVIMENTACAO.CAD_MTMD_TPMOV_ID = 2\n" +
                        "                      AND MOVIMENTACAO.CAD_MTMD_SUBTP_ID IN (11,60)\n" +
                        "                      AND MOVIMENTACAO.CAD_MTMD_FILIAL_ID = 1\n" +
                        "                      AND MOVIMENTACAO.CAD_SET_ID = REQUISICAO.CAD_SET_ID\n" +
                        "                      AND MOVIMENTACAO.MTMD_MOV_FL_ESTORNO = 0\n" +
                        "                      AND REQ.CAD_MTMD_KIT_ID IS NULL\n" +
                        "                      AND PRODUTO2.CAD_MTMD_FL_FRACIONA = 0\n" +
                        "                      AND (PRODUTO2.CAD_MTMD_ID = ITEM.CAD_MTMD_ID OR (PRODUTO2.CAD_MTMD_PRIATI_ID <> 0 AND PRODUTO2.CAD_MTMD_PRIATI_ID = PRODUTO.CAD_MTMD_PRIATI_ID))\n" +
                        "                      AND MOVIMENTACAO.ATD_ATE_ID = REQUISICAO.ATD_ATE_ID),0) QTD_CONSUMO\n" +
                        "          FROM TB_MTMD_REQUISICAO_ITEM       ITEM,\n" +
                        "               TB_MTMD_REQ_REQUISICAO        REQUISICAO,\n" +
                        "               TB_CAD_MTMD_MAT_MED           PRODUTO,\n" +
                        "               TB_CAD_SET_SETOR              SETOR\n" +
                        "          WHERE REQUISICAO.MTMD_REQ_FL_STATUS IN (4)\n" +
                        "          AND   REQUISICAO.CAD_MTMD_FILIAL_ID = 1\n" +
                        "          AND   REQUISICAO.CAD_MTMD_KIT_ID IS NULL\n" +
                        "          AND   REQUISICAO.ATD_ATE_ID    = @ATD_ATE_ID\n" +
                        "          AND   REQUISICAO.CAD_SET_ID = @CAD_SET_ID\n" +
                        "          AND   PRODUTO.CAD_MTMD_FL_FRACIONA = 0\n" +
                        "          AND   ITEM.MTMD_REQITEM_QTD_FORNECIDA > 0\n" +
                        "          AND   REQUISICAO.MTMD_REQ_ID   = ITEM.MTMD_REQ_ID\n" +
                        "          AND   PRODUTO.CAD_MTMD_ID      = ITEM.CAD_MTMD_ID\n" +
                        "          AND   SETOR.CAD_SET_ID         = REQUISICAO.CAD_SET_ID\n" +
                        "      GROUP BY ITEM.CAD_MTMD_ID,PRODUTO.CAD_MTMD_NOMEFANTASIA,PRODUTO.CAD_MTMD_PRIATI_ID,PRODUTO.CAD_MTMD_FL_MAV,PRODUTO.CAD_MTMD_GRUPO_ID,REQUISICAO.ATD_ATE_ID,\n" +
                        "               REQUISICAO.CAD_UNI_ID_UNIDADE,REQUISICAO.CAD_LAT_ID_LOCAL_ATENDIMENTO,REQUISICAO.CAD_SET_ID,SETOR.CAD_SET_CD_SETOR,SETOR.CAD_SET_DS_SETOR,ITEM.CAD_MTMD_PRESCRICAO_ID) PENDENCIAS\n" +
                        "JOIN (SELECT MOV.CAD_MTMD_ID,\n" +
                        "             MOV.MTMD_REQ_ID,\n" +
                        "             MOV.MTMD_LOTEST_ID,\n" +
                        "             NVL(MOV.MTMD_COD_LOTE,'SEM_LOTE') MTMD_COD_LOTE,\n" +
                        "             NVL(SUM(MOV.MTMD_MOV_QTDE),0) QTD_FORNECIDA\n" +
                        "      FROM TB_MTMD_MOV_MOVIMENTACAO MOV JOIN\n" +
                        "           TB_MTMD_REQ_REQUISICAO REQ ON REQ.MTMD_REQ_ID = MOV.MTMD_REQ_ID JOIN\n" +
                        "           TB_MTMD_REQUISICAO_ITEM REQ_ITEM ON REQ_ITEM.MTMD_REQ_ID = REQ.MTMD_REQ_ID AND\n" +
                        "                                               REQ_ITEM.CAD_MTMD_ID = MOV.CAD_MTMD_ID\n" +
                        "      WHERE MOV.CAD_MTMD_FILIAL_ID = 1 AND\n" +
                        "            MOV.ATD_ATE_ID = @ATD_ATE_ID AND\n" +
                        "            REQ.CAD_SET_ID = @CAD_SET_ID AND\n" +
                        "            REQ.MTMD_REQ_FL_STATUS IN (4) AND\n" +
                        "            REQ.CAD_MTMD_KIT_ID IS NULL AND\n" +
                        "            MOV.CAD_MTMD_TPMOV_ID = 1 AND\n" +
                        "            MOV.CAD_MTMD_SUBTP_ID IN (58,4,7,9) AND --Entradas de dispensacao/transf. pac.\n" +
                        "            MOV.MTMD_MOV_FL_ESTORNO = 0 AND\n" +
                        "            REQ_ITEM.MTMD_REQITEM_QTD_FORNECIDA > 0\n" +
                        "      GROUP BY MOV.MTMD_REQ_ID, MOV.CAD_MTMD_ID, MOV.MTMD_LOTEST_ID, MOV.MTMD_COD_LOTE) PEDIDOS ON PEDIDOS.CAD_MTMD_ID = PENDENCIAS.CAD_MTMD_ID\n" +
                        "WHERE PENDENCIAS.QTD_CONSUMO < PENDENCIAS.QTD_FORNECIDA\n" +
                        "ORDER BY PENDENCIAS.CAD_MTMD_NOMEFANTASIA,PEDIDOS.MTMD_REQ_ID DESC";

            query = query.Replace("@ATD_ATE_ID", idAtendimento.ToString());
            query = query.Replace("@CAD_SET_ID", idSetor.ToString());

            Connection.RecordSet(query, result, CommandType.Text);
            return result;
        }

        /// <summary>
        /// Carrega itens para tela de dispensação que já tenha qtd fornecida
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public RequisicaoItensDataTable SelReqItensDispensacao(RequisicaoDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            // Parametro pMTMD_REQ_ID
            param.Add(Connection.CreateParameter("pMTMD_REQ_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            #endregion

            RequisicaoItensDataTable result = new RequisicaoItensDataTable();
            string query = "PRC_MTMD_REQ_ITEM_DISP_S";

            try
            {
                //Executa o procedimento
                Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

                return result;
            }
            catch (OracleException ex)
            {
                // ex.Number
                throw new Exception(string.Format("{0} CÓDIGO RETORNADO: {1} ", ex.Message, ex.Code));
            }
        }

        /// <summary>
        /// Adiciona ou encrementa qtde do item na requisição
        /// </summary>
        /// <param name="dto"></param>
        public void InsReqItemDispensacao(RequisicaoItensDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pMTMD_REQ_ID
            param.Add(Connection.CreateParameter("pMTMD_REQ_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            //Parametro 
            param.Add(Connection.CreateParameter("pCAD_MTMD_PRIATI_ID", dto.IdtPrincipioAtivo.DBValue, ParameterDirection.Input, dto.IdtPrincipioAtivo.DbType));

            //Parametro 
            param.Add(Connection.CreateParameter("pMTMD_REQITEM_QTD_FORNECIDA", dto.QtdFornecida.DBValue, ParameterDirection.Input, dto.QtdFornecida.DbType));

            //Parametro 
            param.Add(Connection.CreateParameter("pMTMD_ID_USUARIO_DISPENSACAO", dto.IdtUsuarioDispensacao.DBValue, ParameterDirection.Input, dto.IdtUsuarioDispensacao.DbType));

            //Parametro pMTMD_LOTEST_ID
            param.Add(Connection.CreateParameter("pMTMD_LOTEST_ID", dto.IdtLote.DBValue, ParameterDirection.Input, dto.IdtLote.DbType));
            #endregion

            RequisicaoItensDataTable result = new RequisicaoItensDataTable();
            string query = "PRC_MTMD_REQ_ITEM_DISP_I";

            //Executa o procedimento
            try
            {
                Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
            }
            catch (OracleException ora)
            {
                throw new Exception(trataErro.RetornaMsg(ora, null, query));
            }


        }

        /// <summary>
        /// NOVA: Deleta item da dispensação
        /// </summary>
        /// <param name="dto"></param>
        public void DelReqItemDispensacao(RequisicaoItensDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pMTMD_REQ_ID
            param.Add(Connection.CreateParameter("pMTMD_REQ_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            //Parametro 
            // param.Add(Connection.CreateParameter("pMTMD_REQITEM_QTD_FORNECIDA", dto.QtdFornecida.DBValue, ParameterDirection.Input, dto.QtdFornecida.DbType));

            //Parametro 
            param.Add(Connection.CreateParameter("pMTMD_ID_USUARIO_DISPENSACAO", dto.IdtUsuarioDispensacao.DBValue, ParameterDirection.Input, dto.IdtUsuarioDispensacao.DbType));

            //Parametro pMTMD_LOTEST_ID
            param.Add(Connection.CreateParameter("pMTMD_LOTEST_ID", dto.IdtLote.DBValue, ParameterDirection.Input, dto.IdtLote.DbType));
            #endregion

            RequisicaoItensDataTable result = new RequisicaoItensDataTable();
            string query = "PRC_MTMD_REQ_ITEM_DISP_D";

            //Executa o procedimento
            // Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);

            // return result.TypedRow(0);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public RequisicaoItensDataTable SelItensRequisicao(RequisicaoItensDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());
			
			// Parametro pCAD_MTMD_ID
			// param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));
			
			// Parametro pMTMD_REQ_ID
			param.Add(Connection.CreateParameter("pMTMD_REQ_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			
			#endregion	
			
			RequisicaoItensDataTable result = new RequisicaoItensDataTable();
			string query = "PRC_MTMD_REQUISICAO_ITEM_SID";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
   		    return result;
		}

		/// <summary>
        /// Exclui o registro
        /// </summary>        
		public void Del(RequisicaoItensDTO dto)
		{
  		    #region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));
			
			// Parametro pMTMD_REQ_ID
			param.Add(Connection.CreateParameter("pMTMD_REQ_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
		
   	       #endregion				
			//Executa o procedimento
            
			string query = "PRC_MTMD_REQUISICAO_ITEM_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Altera o registro
        /// </summary>			
		public void Upd(RequisicaoItensDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pMTMD_REQ_ID
			param.Add(Connection.CreateParameter("pMTMD_REQ_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));
			
			//Parametro pMTMD_REQITEM_QTD_SOLICITADA
			param.Add(Connection.CreateParameter("pMTMD_REQITEM_QTD_SOLICITADA", dto.QtdSolicitada.DBValue, ParameterDirection.Input, dto.QtdSolicitada.DbType));
			
			//Parametro pMTMD_REQITEM_QTD_FORNECIDA
			param.Add(Connection.CreateParameter("pMTMD_REQITEM_QTD_FORNECIDA", dto.QtdFornecida.DBValue, ParameterDirection.Input, dto.QtdFornecida.DbType));

            //Parametro pCAD_MTMD_KIT_ID_ITEM
            param.Add(Connection.CreateParameter("pCAD_MTMD_KIT_ID_ITEM", dto.IdKitItem.DBValue, ParameterDirection.Input, dto.IdKitItem.DbType));

            //Parametro pMTMD_REQITEM_CANCEL_JUST
            param.Add(Connection.CreateParameter("pMTMD_REQITEM_CANCEL_JUST", dto.JustificativaCancelamento.DBValue, ParameterDirection.Input, dto.JustificativaCancelamento.DbType));
			
			#endregion	

			string query = "PRC_MTMD_REQUISICAO_ITEM_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Inclui o registro
        /// </summary>			
		public void Ins(RequisicaoItensDTO dto)
		{			
			string query = "PRC_MTMD_REQUISICAO_ITEM_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			
			//Parametro pMTMD_REQ_ID
			param.Add(Connection.CreateParameter("pMTMD_REQ_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));
			
			//Parametro pMTMD_REQITEM_QTD_SOLICITADA
			param.Add(Connection.CreateParameter("pMTMD_REQITEM_QTD_SOLICITADA", dto.QtdSolicitada.DBValue, ParameterDirection.Input, dto.QtdSolicitada.DbType));
			
			//Parametro pMTMD_REQITEM_QTD_FORNECIDA
			param.Add(Connection.CreateParameter("pMTMD_REQITEM_QTD_FORNECIDA", dto.QtdFornecida.DBValue, ParameterDirection.Input, dto.QtdFornecida.DbType));

            //Parametro pCAD_MTMD_PRESCRICAO_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_PRESCRICAO_ID", dto.IdPrescricao.DBValue, ParameterDirection.Input, dto.IdPrescricao.DbType));

            //Parametro pCAD_MTMD_KIT_ID_ITEM
            param.Add(Connection.CreateParameter("pCAD_MTMD_KIT_ID_ITEM", dto.IdKitItem.DBValue, ParameterDirection.Input, dto.IdKitItem.DbType));

            //Parametro pMTMD_QTD_KIT_MULTIPLICA
            param.Add(Connection.CreateParameter("pMTMD_QTD_KIT_MULTIPLICA", dto.QtdKitItemMultiplica.DBValue, ParameterDirection.Input, dto.QtdKitItemMultiplica.DbType));

            //Parametro pATD_MPM_ID
            param.Add(Connection.CreateParameter("pATD_MPM_ID", dto.IdPrescricaoItemInternacao.DBValue, ParameterDirection.Input, dto.IdPrescricaoItemInternacao.DbType));

            //Parametro pATD_PME_ID
            param.Add(Connection.CreateParameter("pATD_PME_ID", dto.IdPrescricaoInternacao.DBValue, ParameterDirection.Input, dto.IdPrescricaoInternacao.DbType));

            //Parametro pMTMD_REQITEM_CANCEL_JUST
            param.Add(Connection.CreateParameter("pMTMD_REQITEM_CANCEL_JUST", dto.JustificativaCancelamento.DBValue, ParameterDirection.Input, dto.JustificativaCancelamento.DbType));

            //Parametro pMTMD_FL_GELADEIRA
            param.Add(Connection.CreateParameter("pMTMD_FL_GELADEIRA", dto.FlItemGeladeira.DBValue, ParameterDirection.Input, dto.FlItemGeladeira.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						

		}

        public void EnviarEmailProdutoAltoCusto(RequisicaoItensDTO dto)
        {
            string query = "PRC_MTMD_EMAIL_ALTO_CUSTO";

            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pMTMD_REQ_ID
            param.Add(Connection.CreateParameter("pMTMD_REQ_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            //Parametro pMTMD_REQITEM_QTD_SOLICITADA
            if (dto.QtdSolicitada.Value > 0)
                param.Add(Connection.CreateParameter("pMTMD_REQITEM_QTD_SOLICITADA", dto.QtdSolicitada.DBValue, ParameterDirection.Input, dto.QtdSolicitada.DbType));
            else if (dto.QtdPedidoGerar.Value > 0)
                param.Add(Connection.CreateParameter("pMTMD_REQITEM_QTD_SOLICITADA", dto.QtdPedidoGerar.DBValue, ParameterDirection.Input, dto.QtdPedidoGerar.DbType));
            else
                return;

            #endregion

            try
            {
                // Executa o Procedimento
                Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
            }
            catch
            {
                //Dar continuidade mesmo se não conseguir enviar o e-mail
            }
            
        }

        public DataTable ObterQtdSolicitadaProdutoPaciente(MovimentacaoDTO dto, int idPrincipioAtivo)
        {
            if (dto.IdtSetor.Value.IsNull) dto.IdtSetor.Value = 0;
            DataTable result = new DataTable();
            string query =
            "SELECT NVL(SUM(DECODE( ITEM.MTMD_ID_ORIGINAL, NULL,\n" +
            "                 (ITEM.MTMD_REQITEM_QTD_SOLICITADA -\n" +
            "                 \tFNC_MTMD_REQ_SOMA_SIMILAR(ITEM.CAD_MTMD_ID, ITEM.MTMD_REQ_ID, FNC_MTMD_PRINCIPIO_ATIVO (ITEM.CAD_MTMD_ID))),\n" +
            "                 ITEM.MTMD_REQITEM_QTD_SOLICITADA\n" +
            "               )),0) QTD_SOLICITADA\n" +
            "      FROM TB_MTMD_REQUISICAO_ITEM       ITEM,\n" +
            "           TB_MTMD_REQ_REQUISICAO        REQUISICAO,\n" +
            "           TB_CAD_MTMD_MAT_MED           PRODUTO\n" +
            "      WHERE REQUISICAO.MTMD_DATA_REQUISICAO >= TO_DATE('10062015 1430','DDMMYYYY HH24MI') AND REQUISICAO.MTM_TIPO_REQUISICAO = 0\n" + //10/06/2015 foi a data da implantação da nova tela de Consumo das UTIs, e ficou provisoriamente hardcode para levar em conta apenas os pedidos após esta data, para a verificação Qtd. Pedida x Baixas dar certo (= ao ObterQtdProdutoBaixaPacSetor)
            "      AND   REQUISICAO.MTMD_REQ_FL_STATUS NOT IN (0,1,6)\n" +
            "      AND   REQUISICAO.CAD_MTMD_KIT_ID IS NULL\n" +
            "      AND   REQUISICAO.ATD_ATE_ID    = " + dto.IdtAtendimento.Value.ToString() + "\n" +
            //"      AND   REQUISICAO.CAD_SET_ID    = " + dto.IdtSetor.Value.ToString() + "\n" +
            "      AND   ((" + dto.IdtSetor.Value + " != 0 AND REQUISICAO.CAD_SET_ID = " + dto.IdtSetor.Value + ") OR (" + dto.IdtSetor.Value + " = 0 AND REQUISICAO.CAD_SET_ID = REQUISICAO.CAD_SET_ID))\n" +
            "      AND   (ITEM.CAD_MTMD_ID = " + dto.IdtProduto.Value.ToString() + " OR (PRODUTO.CAD_MTMD_PRIATI_ID <> 0 AND PRODUTO.CAD_MTMD_PRIATI_ID = " + idPrincipioAtivo.ToString() + "))\n" +            
            "      AND   REQUISICAO.MTMD_REQ_ID   = ITEM.MTMD_REQ_ID\n" +
            "      AND   PRODUTO.CAD_MTMD_ID      = ITEM.CAD_MTMD_ID";
            
            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }

        public RequisicaoItensDataTable ListarItensBaixa(RequisicaoItensDTO dto)
        {
            string filtros = " ITEM.MTMD_REQ_ID = " + dto.Idt.Value.ToString() + "\n";

            if (!dto.IdtProduto.Value.IsNull)
                filtros += " AND ITEM.CAD_MTMD_ID = " + dto.IdtProduto.Value.ToString() + "\n";

            string sqlString = string.Format("SELECT ITEM.CAD_MTMD_ID,\n" +
                                            "       FNC_MTMD_SOUNDALIKE(PROD.CAD_MTMD_NOMEFANTASIA,PROD.CAD_MTMD_GRUPO_ID) CAD_MTMD_NOMEFANTASIA,\n" + 
                                            "       FNC_MTMD_ESTOQUE_UNIDADE(ITEM.CAD_MTMD_ID,\n" + 
                                            "                                REQ.CAD_UNI_ID_UNIDADE,\n" + 
                                            "                                REQ.CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" + 
                                            "                                REQ.CAD_SET_ID,\n" + 
                                            "                                REQ.CAD_MTMD_FILIAL_ID,\n" + 
                                            "                                NULL) MTMD_ESTLOC_QTDE,\n" + 
                                            "       ITEM.MTMD_REQITEM_QTD_SOLICITADA,\n" +
                                            "       ITEM.MTMD_REQITEM_QTD_FORNECIDA,\n" +
                                            "       PROD.CAD_MTMD_FL_MAV\n" + 
                                            //"       (SELECT NVL(SUM(MOV.MTMD_MOV_QTDE), 0)\n" + 
                                            //"          FROM TB_MTMD_MOV_MOVIMENTACAO MOV\n" + 
                                            //"         WHERE MOV.CAD_MTMD_ID = ITEM.CAD_MTMD_ID AND\n" + 
                                            //"               MOV.MTMD_REQ_ID = ITEM.MTMD_REQ_ID AND\n" + 
                                            //"               MOV.CAD_MTMD_TPMOV_ID = 2 AND\n" + 
                                            //"               MOV.CAD_MTMD_SUBTP_ID IN (11, 18, 24, 25) AND\n" + 
                                            //"               MOV.MTMD_MOV_FL_ESTORNO = 0) MTMD_REQITEM_QTD_FORNECIDA\n" + 
                                            "FROM TB_MTMD_REQUISICAO_ITEM ITEM JOIN\n" + 
                                            "     TB_MTMD_REQ_REQUISICAO REQ ON REQ.MTMD_REQ_ID = ITEM.MTMD_REQ_ID JOIN\n" + 
                                            "     TB_CAD_MTMD_MAT_MED PROD ON PROD.CAD_MTMD_ID = ITEM.CAD_MTMD_ID\n" +
                                            "WHERE {0} \n" +
                                            "ORDER BY PROD.CAD_MTMD_NOMEFANTASIA",
                                            filtros);

            RequisicaoItensDataTable result = new RequisicaoItensDataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);

            return result;
        }

        public decimal? ObterNumPedidoPrescricaoPaciente(MovimentacaoDTO dto, int idPrincipioAtivo)
        {
            DataTable result = new DataTable();
            string query =
            "SELECT ITEM.MTMD_REQ_ID, ITEM.CAD_MTMD_ID, NVL(ITEM.CAD_MTMD_PRESCRICAO_ID,0) CAD_MTMD_PRESCRICAO_ID, NVL(ITEM.MTMD_ID_ORIGINAL,0) MTMD_ID_ORIGINAL, ITEM.MTMD_REQITEM_QTD_SOLICITADA\n" +
            "      FROM TB_MTMD_REQUISICAO_ITEM       ITEM,\n" +
            "           TB_MTMD_REQ_REQUISICAO        REQUISICAO,\n" +
            "           TB_CAD_MTMD_MAT_MED           PRODUTO\n" +
            "      WHERE REQUISICAO.MTMD_REQ_FL_STATUS NOT IN (0,1,3,6)\n" +            
            "      AND   REQUISICAO.ATD_ATE_ID    = " + dto.IdtAtendimento.Value.ToString() + "\n" +
            "      AND   REQUISICAO.CAD_SET_ID    = " + dto.IdtSetor.Value.ToString() + "\n" +
            "      AND   (ITEM.CAD_MTMD_ID = " + dto.IdtProduto.Value.ToString() + " OR (PRODUTO.CAD_MTMD_PRIATI_ID <> 0 AND PRODUTO.CAD_MTMD_PRIATI_ID = " + idPrincipioAtivo.ToString() + "))\n" +
            "      AND   ITEM.CAD_MTMD_PRESCRICAO_ID IS NOT NULL\n" +
            "      AND   REQUISICAO.CAD_MTMD_KIT_ID IS NULL\n" +
            "      AND   ITEM.MTMD_REQITEM_QTD_SOLICITADA > NVL(ITEM.MTMD_REQITEM_QTD_FORNECIDA,0)\n" +
            "      AND   REQUISICAO.MTMD_REQ_ID   = ITEM.MTMD_REQ_ID\n" +
            "      AND   PRODUTO.CAD_MTMD_ID      = ITEM.CAD_MTMD_ID\n" +
            "ORDER BY ITEM.MTMD_REQ_ID DESC";

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            //if (result.Rows.Count == 1 && result.Rows[0]["MTMD_REQ_ID"].ToString() != "0")
            //    return decimal.Parse(result.Rows[0]["MTMD_REQ_ID"].ToString());

            foreach (DataRow row in result.Rows)
            {
                PrescricaoDTO dtoItemPrescricao;
                PrescricaoDataTable dtbPresc;
                Prescricao prescricao = new Prescricao(); ;
                if (row["CAD_MTMD_PRESCRICAO_ID"].ToString() != "0" && row["MTMD_ID_ORIGINAL"].ToString() == "0")//Nao comparar com similar
                {
                    dtoItemPrescricao = new PrescricaoDTO();
                    dtoItemPrescricao.IdPrescricao.Value = decimal.Parse(row["CAD_MTMD_PRESCRICAO_ID"].ToString());
                    dtoItemPrescricao.IdProduto.Value = decimal.Parse(row["CAD_MTMD_ID"].ToString());
                    dtbPresc = prescricao.ListarItem(dtoItemPrescricao, true);
                    if (dtbPresc.Rows.Count > 0)
                    {
                        if (DateTime.Parse(dtbPresc.Rows[0][PrescricaoDTO.FieldNames.DataLimiteConsumo].ToString()).Date >= DateTime.Today.Date)
                            return decimal.Parse(row["MTMD_REQ_ID"].ToString());
                    }
                }
            }

            //Se não achou, procurar com Data Limite vencida
            foreach (DataRow row in result.Rows)
            {
                PrescricaoDTO dtoItemPrescricao;
                PrescricaoDataTable dtbPresc;
                Prescricao prescricao = new Prescricao(); ;
                if (row["CAD_MTMD_PRESCRICAO_ID"].ToString() != "0" && row["MTMD_ID_ORIGINAL"].ToString() == "0")//Nao comparar com similar
                {
                    dtoItemPrescricao = new PrescricaoDTO();
                    dtoItemPrescricao.IdPrescricao.Value = decimal.Parse(row["CAD_MTMD_PRESCRICAO_ID"].ToString());
                    dtoItemPrescricao.IdProduto.Value = decimal.Parse(row["CAD_MTMD_ID"].ToString());
                    dtbPresc = prescricao.ListarItem(dtoItemPrescricao, true);
                    if (dtbPresc.Rows.Count > 0)
                    {
                        if (DateTime.Parse(dtbPresc.Rows[0][PrescricaoDTO.FieldNames.DataLimiteConsumo].ToString()).Date < DateTime.Today.Date)
                            return decimal.Parse(row["MTMD_REQ_ID"].ToString());
                    }
                }
            }

            return null;
        }

        public decimal? ObterNumPedidoPendentePaciente(MovimentacaoDTO dto, int idPrincipioAtivo)
        {
            DataTable result = new DataTable();
            string query =
            "SELECT ITEM.MTMD_REQ_ID, ITEM.CAD_MTMD_ID, NVL(ITEM.MTMD_ID_ORIGINAL,0) MTMD_ID_ORIGINAL, ITEM.MTMD_REQITEM_QTD_SOLICITADA, NVL(ITEM.MTMD_REQITEM_QTD_FORNECIDA,0) MTMD_REQITEM_QTD_FORNECIDA\n" +
            "      FROM TB_MTMD_REQUISICAO_ITEM       ITEM,\n" +
            "           TB_MTMD_REQ_REQUISICAO        REQUISICAO,\n" +
            "           TB_CAD_MTMD_MAT_MED           PRODUTO\n" +
            "      WHERE REQUISICAO.MTMD_REQ_FL_STATUS NOT IN (0,1,3,6)\n" +
            "      AND   REQUISICAO.CAD_MTMD_KIT_ID IS NULL\n" +
            "      AND   REQUISICAO.ATD_ATE_ID    = " + dto.IdtAtendimento.Value.ToString() + "\n" +
            "      AND   REQUISICAO.CAD_SET_ID    = " + dto.IdtSetor.Value.ToString() + "\n" +
            "      AND   (ITEM.CAD_MTMD_ID = " + dto.IdtProduto.Value.ToString() + " OR (PRODUTO.CAD_MTMD_PRIATI_ID <> 0 AND PRODUTO.CAD_MTMD_PRIATI_ID = " + idPrincipioAtivo.ToString() + "))\n" +
            "      AND   ITEM.MTMD_REQITEM_QTD_SOLICITADA > NVL(ITEM.MTMD_REQITEM_QTD_FORNECIDA,0)\n" +
            "      AND   NVL(ITEM.MTMD_ID_ORIGINAL,0) = 0\n" +
            "      AND   REQUISICAO.MTMD_REQ_ID   = ITEM.MTMD_REQ_ID\n" +
            "      AND   PRODUTO.CAD_MTMD_ID      = ITEM.CAD_MTMD_ID\n" +
            "ORDER BY ITEM.MTMD_REQ_ID";

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            if (result.Rows.Count > 0) 
                return decimal.Parse(result.Rows[0]["MTMD_REQ_ID"].ToString());
            
            //foreach (DataRow row in result.Rows)
            //{
            //    if ((int.Parse(row["MTMD_REQITEM_QTD_SOLICITADA"].ToString()) > int.Parse(row["MTMD_REQITEM_QTD_FORNECIDA"].ToString())) &&
            //        row["MTMD_ID_ORIGINAL"].ToString() == "0") //Nao comparar com similar
            //        return decimal.Parse(row["MTMD_REQ_ID"].ToString());
            //}

            return null;
        }

        public RequisicaoItensDataTable ListarPendenciasDispensacao(int? idPedido)
        {
            string filtros = string.Empty;

            if (idPedido != null)
                filtros += " AND R.MTMD_REQ_ID = " + idPedido.ToString() + "\n";

            string sqlString = "SELECT R.MTMD_REQ_ID,\n" +
                                "       R.MTMD_DATA_REQUISICAO,\n" +
                                "       U.CAD_UNI_DS_RESUMIDA || ' / ' || S.CAD_SET_DS_SETOR CAD_SET_DS_SETOR,\n" +
                                "       I.CAD_MTMD_ID,\n" +
                                "       M.CAD_MTMD_NOMEFANTASIA,\n" +
                                "       I.MTMD_REQITEM_QTD_FORNECIDA\n" +
                                "  FROM TB_MTMD_REQUISICAO_ITEM I JOIN\n" +
                                "       TB_MTMD_REQ_REQUISICAO R ON R.MTMD_REQ_ID = I.MTMD_REQ_ID JOIN\n" +
                                "       TB_CAD_MTMD_MAT_MED M ON M.CAD_MTMD_ID = I.CAD_MTMD_ID JOIN\n" +
                                "       TB_CAD_SET_SETOR S ON S.CAD_SET_ID = R.CAD_SET_ID JOIN\n" +
                                "       TB_CAD_UNI_UNIDADE U ON U.CAD_UNI_ID_UNIDADE = S.CAD_UNI_ID_UNIDADE\n" +
                                " WHERE I.MTMD_REQ_DATA >= sysdate-180\n" +
                                "  AND R.MTMD_REQ_FL_STATUS IN (5)\n" +
                                "  AND R.CAD_SET_ID NOT IN (2252,200,201,2652)\n" +
                                "  AND I.MTMD_REQITEM_QTD_FORNECIDA > 0\n" + filtros +
                                "ORDER BY 2,3,5";

            RequisicaoItensDataTable result = new RequisicaoItensDataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);

            return result;
        }

        public RequisicaoItensDataTable ListarItensKit(int idPedido)
        {
            string sqlString = "SELECT ITEM.MTMD_REQ_ID, ITEM.CAD_MTMD_ID,\n" +
                                "       SGS.FNC_MTMD_SOUNDALIKE(PRODUTO.CAD_MTMD_NOMEFANTASIA,PRODUTO.CAD_MTMD_GRUPO_ID) MEDICAMENTO,\n" +
                                "       KIT.CAD_MTMD_KIT_ID,\n" +
                                "       KIT.CAD_MTMD_KIT_DSC KIT_REF,\n" +
                                "       ITEM_KIT.CAD_MTMD_ID CAD_MTMD_ID_KIT,\n" +
                                "       ITEM_KIT.CAD_MTMD_NOMEFANTASIA ITEM_KIT,\n" +
                                "       KIT_ITEM.CAD_MTMD_QTDE * ITEM.MTMD_REQITEM_QTD_SOLICITADA QTD_KIT\n" +
                                "    FROM TB_MTMD_REQUISICAO_ITEM ITEM JOIN\n" +
                                "         TB_MTMD_REQ_REQUISICAO REQ ON REQ.MTMD_REQ_ID = ITEM.MTMD_REQ_ID JOIN\n" +
                                "         TB_CAD_MTMD_MAT_MED PRODUTO ON PRODUTO.CAD_MTMD_ID = ITEM.CAD_MTMD_ID JOIN\n" +
                                "         TB_CAD_MTMD_KIT_ITEM KIT_ITEM ON KIT_ITEM.CAD_MTMD_KIT_ID = ITEM.CAD_MTMD_KIT_ID_ITEM JOIN\n" +
                                "         TB_CAD_MTMD_MAT_MED ITEM_KIT ON ITEM_KIT.CAD_MTMD_ID = KIT_ITEM.CAD_MTMD_ID JOIN\n" +
                                "         TB_CAD_MTMD_KIT KIT ON KIT.CAD_MTMD_KIT_ID = KIT_ITEM.CAD_MTMD_KIT_ID\n" +
                                "    WHERE ITEM.MTMD_REQ_ID = " + idPedido.ToString() + " AND\n" +
                                "          ITEM_KIT.CAD_MTMD_ID IN (SELECT CAD_MTMD_ID FROM TB_MTMD_REQUISICAO_ITEM WHERE MTMD_REQ_ID = ITEM.MTMD_REQ_ID)\n" +
                                "ORDER BY PRODUTO.CAD_MTMD_NOMEFANTASIA, KIT.CAD_MTMD_KIT_DSC, ITEM_KIT.CAD_MTMD_NOMEFANTASIA";

            RequisicaoItensDataTable result = new RequisicaoItensDataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);

            return result;
        }

        public RequisicaoItensDataTable ListarItensKit(int idPedido, int idProdutoRef)
        {
            string sqlString = "SELECT * FROM TB_MTMD_REQUISICAO_ITEM_KIT " +
                               " WHERE MTMD_REQ_ID = " + idPedido.ToString() +
                               "   AND CAD_MTMD_ID_REF = " + idProdutoRef.ToString();

            RequisicaoItensDataTable result = new RequisicaoItensDataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);
            return result;
        }

        public bool ExisteKitAssociadoPedidoAla(int idPedido)
        {
            string sqlString = "SELECT RIK.CAD_MTMD_ID_REF\n" +
                               "  FROM TB_MTMD_REQUISICAO_ITEM_KIT RIK\n" +
                               " WHERE RIK.CAD_MTMD_ID_KIT IS NULL AND RIK.MTMD_REQ_ID = " + idPedido.ToString() + "\n" +
                               "   AND RIK.CAD_MTMD_ID_REF IN (SELECT DISTINCT CAD_MTMD_ID_KIT\n" +
                               "                                 FROM TB_MTMD_REQUISICAO_ITEM_KIT\n" +
                               "                                WHERE CAD_MTMD_ID_KIT IS NOT NULL AND MTMD_REQ_ID = RIK.MTMD_REQ_ID)";
            RequisicaoItensDataTable result = new RequisicaoItensDataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);
            return result.Rows.Count > 0;
        }

        public void InserirItemKit(int idPedido, int idProdutoRef, int? idKit, int? idProdutoKit, int qtdSolicitada)
        {
            DataTable result = new DataTable();
            string strIdKit = idKit == null ? "NULL" : idKit.Value.ToString();
            string strIdProdutoKit = idProdutoKit == null ? "NULL" : idProdutoKit.Value.ToString();

            string sqlString = "INSERT INTO TB_MTMD_REQUISICAO_ITEM_KIT\n" +
                                "        (MTMD_REQ_ID,\n" +
                                "         CAD_MTMD_ID_REF,\n" +
                                "         CAD_MTMD_KIT_ID_ITEM,\n" +
                                "         CAD_MTMD_ID_KIT,\n" +
                                "         MTMD_REQITEM_QTD_SOLICITADA)\n" +
                                "        VALUES\n" +
                                "        (" + idPedido + ",\n" +
                                "         " + idProdutoRef + ",\n" +
                                "         " + strIdKit + ",\n" +
                                "         " + strIdProdutoKit + ",\n" +
                                "         " + qtdSolicitada + ")";
            
            Connection.ExecuteCommand(sqlString);
        }

        public void AtualizarItemKit(int idPedido, int idProdutoRef, int? idKit, int? idProdutoKit, int qtdSolicitada)
        {
            DataTable result = new DataTable();
            string sqlString;
            string strIdKit = idKit == null ? "0" : idKit.Value.ToString();
            string strIdProdutoKit = idProdutoKit == null ? "0" : idProdutoKit.Value.ToString();

            sqlString = "DELETE TB_MTMD_REQUISICAO_ITEM_KIT \n" +
                        "       WHERE MTMD_REQ_ID = " + idPedido + "\n" +
                        "       AND   CAD_MTMD_ID_REF = " + idProdutoRef + "\n" +
                        "       AND   NVL(CAD_MTMD_KIT_ID_ITEM,0) = " + strIdKit + "\n" +
                        "       AND   NVL(CAD_MTMD_ID_KIT,0) = " + strIdProdutoKit;

            Connection.ExecuteCommand(sqlString);

            if (qtdSolicitada > 0)
            {
                //sqlString = "UPDATE TB_MTMD_REQUISICAO_ITEM_KIT SET\n" +
                //        "       MTMD_REQITEM_QTD_SOLICITADA = " + qtdSolicitada + "\n" +
                //        "       WHERE MTMD_REQ_ID = " + idPedido + "\n" +
                //        "       AND   CAD_MTMD_ID_REF = " + idProdutoRef + "\n" +
                //        "       AND   NVL(CAD_MTMD_KIT_ID_ITEM,0) = " + strIdKit + "\n" +
                //        "       AND   NVL(CAD_MTMD_ID_KIT,0) = " + strIdProdutoKit;

                this.InserirItemKit(idPedido, idProdutoRef, idKit, idProdutoKit, qtdSolicitada);                
            }
        }

        public void ExcluirItensKit(int idPedido)
        {
            DataTable result = new DataTable();
            string sqlString = "DELETE TB_MTMD_REQUISICAO_ITEM_KIT \n" +
                        "       WHERE CAD_MTMD_ID_KIT IS NOT NULL AND MTMD_REQ_ID = " + idPedido;

            Connection.ExecuteCommand(sqlString);
        }

        public DataTable ObterIndiceDevolucaoPeriodo(RequisicaoDTO dto)
        {
            string filtros = string.Empty;
            DataTable result = new DataTable();

            if (!dto.DataRequisicao.Value.IsNull && !dto.DataRequisicao2.Value.IsNull)
            {
                filtros += " AND (REQ.MTMD_DATA_REQUISICAO >= TO_DATE('" + DateTime.Parse(dto.DataRequisicao.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy') " +
                           " AND  REQ.MTMD_DATA_REQUISICAO <= TO_DATE('" + DateTime.Parse(dto.DataRequisicao2.Value.ToString()).ToString("ddMMyyyy") + " 235959','ddMMyyyy HH24MISS'))\n";

                string query = "SELECT QTD_TOTAL_FORNECIDA,\n" +
                           "           QTD_DEVOLVIDA,\n" +
                           "           DECODE(QTD_TOTAL_FORNECIDA, 0, 0, ROUND((QTD_DEVOLVIDA/QTD_TOTAL_FORNECIDA)*100,2)) INDICE_DEVOLUCAO\n" +
                           "      FROM (SELECT (SELECT NVL(SUM(RI.MTMD_REQITEM_QTD_FORNECIDA+NVL(RI.MTMD_REQITEM_QTD_DEVOLVIDA,0)),0)\n" +
                           "                      FROM TB_MTMD_REQUISICAO_ITEM RI JOIN\n" +
                           "                           TB_MTMD_REQ_REQUISICAO REQ ON REQ.MTMD_REQ_ID = RI.MTMD_REQ_ID\n" +
                           "                     WHERE REQ.CAD_MTMD_FILIAL_ID = 1\n" +
                           "                     AND REQ.MTM_TIPO_REQUISICAO = 0 AND REQ.ATD_ATE_ID IS NOT NULL\n" +
                           "                     AND REQ.MTMD_REQ_FL_STATUS IN (3,4,8)\n" + filtros + ") QTD_TOTAL_FORNECIDA,\n" +
                           "                   (SELECT SUM(RI.MTMD_REQITEM_QTD_DEVOLVIDA)\n" +
                           "                      FROM TB_MTMD_REQUISICAO_ITEM RI JOIN\n" +
                           "                           TB_MTMD_REQ_REQUISICAO REQ ON REQ.MTMD_REQ_ID = RI.MTMD_REQ_ID\n" +
                           "                     WHERE REQ.CAD_MTMD_FILIAL_ID = 1\n" +
                           "                     AND REQ.MTM_TIPO_REQUISICAO = 0 AND REQ.ATD_ATE_ID IS NOT NULL\n" +
                           "                     AND REQ.MTMD_REQ_FL_STATUS IN (3,4,8)\n" + filtros +
                           "                     AND RI.MTMD_REQITEM_DATA_DEVOLUCAO >= REQ.MTMD_DATA_DISPENSACAO\n" +
                           "                     AND NVL(RI.MTMD_REQITEM_QTD_DEVOLVIDA,0) > 0) QTD_DEVOLVIDA\n" +
                           "    FROM DUAL)";

                //Executa o procedimento
                Connection.RecordSet(query, result, CommandType.Text);

                return result;
            }
            else
                return null;            
        }

        public DataTable ListarDevolucoesPeriodo(RequisicaoDTO dto)
        {
            string filtros = string.Empty;
            DataTable result = new DataTable();

            if (!dto.DataRequisicao.Value.IsNull && !dto.DataRequisicao2.Value.IsNull)
            {
                filtros += " AND (REQ.MTMD_DATA_REQUISICAO >= TO_DATE('" + DateTime.Parse(dto.DataRequisicao.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy') " +
                           " AND  REQ.MTMD_DATA_REQUISICAO <= TO_DATE('" + DateTime.Parse(dto.DataRequisicao2.Value.ToString()).ToString("ddMMyyyy") + " 235959','ddMMyyyy HH24MISS'))\n";

                string query = "SELECT  SETOR.CAD_SET_DS_SETOR SETOR,\n" +
                                "       PROD.CAD_MTMD_GRUPO_ID GRUPO_ID,\n" +
                                "       RI.CAD_MTMD_ID PRODUTO_ID,\n" +
                                "       PROD.CAD_MTMD_NOMEFANTASIA PRODUTO,\n" +
                                "       RI.MTMD_REQ_ID PEDIDO,\n" +
                                "       RI.MTMD_REQITEM_QTD_SOLICITADA QTD_SOLICITADA,\n" +
                                "       RI.MTMD_REQITEM_QTD_FORNECIDA+NVL(RI.MTMD_REQITEM_QTD_DEVOLVIDA,0) QTD_FORNECIDA,\n" +
                                "       RI.MTMD_REQITEM_QTD_DEVOLVIDA QTD_DEVOLVIDA,\n" +
                                "       REQ.MTMD_DATA_REQUISICAO DATA_PEDIDO,\n" +
                                "       REQ.MTMD_DATA_DISPENSACAO DATA_DISPENSACAO,\n" +
                                "       RI.MTMD_REQITEM_DATA_DEVOLUCAO DATA_DEVOLUCAO,\n" +
                                "       ROUND((RI.MTMD_REQITEM_DATA_DEVOLUCAO-REQ.MTMD_DATA_DISPENSACAO)*24,2) QTD_HORAS_DEV\n" +
                                "  FROM TB_MTMD_REQUISICAO_ITEM RI JOIN\n" +
                                "       TB_MTMD_REQ_REQUISICAO REQ ON REQ.MTMD_REQ_ID = RI.MTMD_REQ_ID JOIN\n" +
                                "       TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = REQ.CAD_SET_ID JOIN\n" +
                                "       TB_CAD_MTMD_MAT_MED PROD ON PROD.CAD_MTMD_ID = RI.CAD_MTMD_ID\n" +
                                " WHERE REQ.CAD_MTMD_FILIAL_ID = 1\n" +
                                "   AND REQ.MTM_TIPO_REQUISICAO = 0 AND REQ.ATD_ATE_ID IS NOT NULL\n" +
                                "   AND REQ.MTMD_REQ_FL_STATUS IN (3,4,8)\n" + filtros +                                
                                "   AND RI.MTMD_REQITEM_DATA_DEVOLUCAO >= REQ.MTMD_DATA_DISPENSACAO\n" +
                                "   AND NVL(RI.MTMD_REQITEM_QTD_DEVOLVIDA,0) > 0\n" +
                                "ORDER BY SETOR.CAD_SET_DS_SETOR,\n" +
                                "         PROD.CAD_MTMD_GRUPO_ID,\n" +
                                "         PROD.CAD_MTMD_NOMEFANTASIA,\n" +
                                "         REQ.MTMD_DATA_DISPENSACAO\n";

                //Executa o procedimento
                Connection.RecordSet(query, result, CommandType.Text);

                return result;
            }
            else
                return null;
        }

        public void InsPedidoAutoControle(RequisicaoItensDTO dto)
        {
            string query;
            string dataHoraGerar = "NULL";
            if (!dto.DataHoraGerar.Value.IsNull)
                dataHoraGerar = "TO_DATE('" + DateTime.Parse(dto.DataHoraGerar.Value.ToString()).ToString("ddMMyyyy HHmm") + "','ddMMyyyy HH24MI')";
            string dataHoraAdmPac = "NULL";
            if (!dto.DataHoraAdmPaciente.Value.IsNull)
                dataHoraAdmPac = "TO_DATE('" + DateTime.Parse(dto.DataHoraAdmPaciente.Value.ToString()).ToString("ddMMyyyy HHmm") + "','ddMMyyyy HH24MI')";

            query = string.Format("INSERT INTO TB_MTMD_REQUISICAO_ITEM_AUTO(MTMD_REQ_ID, CAD_MTMD_ID, RIA_QTD_HRS_PERIODO_DOSE, " +
                                                                            "RIA_DATA_HORA_GERAR, RIA_DATA_HORA_ADM_PAC, RIA_QTD_PEDIDO, " +
                                                                            "RIA_SEG_USU_ID_USUARIO, RIA_DT_ATUALIZACAO) " +
                                  "VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, SYSDATE)", dto.Idt.Value,
                                                                                        dto.IdtProduto.Value,
                                                                                        dto.HorasPeriodoDose.Value,
                                                                                        dataHoraGerar,
                                                                                        dataHoraAdmPac,
                                                                                        dto.QtdPedidoGerar.Value,
                                                                                        dto.IdtUsuarioDispensacao.Value);
            Connection.ExecuteCommand(query);
        }

        public void UpdPedidoAutoControle(RequisicaoItensDTO dto, DateTime? novaDataHoraGeracao)
        {
            string query;
            string dataHoraGerar = "NULL";
            string dataHoraGeracaoAtualizar = dataHoraGerar;
            if (!dto.DataHoraGerar.Value.IsNull)
                dataHoraGerar = "TO_DATE('" + DateTime.Parse(dto.DataHoraGerar.Value.ToString()).ToString("ddMMyyyy HHmm") + "','ddMMyyyy HH24MI')";

            if (novaDataHoraGeracao != null)
                dataHoraGeracaoAtualizar = "TO_DATE('" + novaDataHoraGeracao.Value.ToString("ddMMyyyy HHmm") + "','ddMMyyyy HH24MI')";
            else
                dataHoraGeracaoAtualizar = dataHoraGerar;

            query = "UPDATE TB_MTMD_REQUISICAO_ITEM_AUTO SET " +
                        "   RIA_DATA_HORA_GERAR = " + dataHoraGeracaoAtualizar +
                        " , RIA_QTD_PEDIDO = " + dto.QtdPedidoGerar.Value +
                        " , RIA_SEG_USU_ID_USUARIO = " + dto.IdtUsuarioDispensacao.Value +
                        " , RIA_DT_ATUALIZACAO = SYSDATE" +
                    " WHERE MTMD_REQ_ID = " + dto.Idt.Value +
                      " AND CAD_MTMD_ID = " + dto.IdtProduto.Value;
            
            if (!dto.DataHoraGerar.Value.IsNull)
                query += " AND RIA_DATA_HORA_GERAR = " + dataHoraGerar;
            else
                query += " AND RIA_DATA_HORA_GERAR IS NULL ";

            if (!dto.DataHoraAdmPaciente.Value.IsNull)
                query += " AND RIA_DATA_HORA_ADM_PAC = " + "TO_DATE('" + DateTime.Parse(dto.DataHoraAdmPaciente.Value.ToString()).ToString("ddMMyyyy HHmm") + "','ddMMyyyy HH24MI')";                

            Connection.ExecuteCommand(query);
        }

        public void MarcarGeracaoPedidoAutomatico(RequisicaoItensDTO dto)
        {
            string query;
            string filtro = string.Empty;
            if (!dto.IdtProduto.Value.IsNull) filtro = " AND CAD_MTMD_ID = " + dto.IdtProduto.Value;

            query = "UPDATE TB_MTMD_REQUISICAO_ITEM_AUTO SET " +
                        "   MTMD_REQ_ID_NOVO = " + dto.IdtNovo.Value +
                    " WHERE RIA_SEG_ID_USUARIO_CANCELADO IS NULL AND MTMD_REQ_ID = " + dto.Idt.Value + filtro +
                      " AND RIA_DATA_HORA_GERAR = " + "TO_DATE('" + DateTime.Parse(dto.DataHoraGerar.Value.ToString()).ToString("ddMMyyyy HHmm") + "','ddMMyyyy HH24MI')";
            
            Connection.ExecuteCommand(query);
        }

        public void CancelarPedidoAutoControle(RequisicaoItensDTO dto)
        {
            this.CancelarPedidoAutoControle(dto, false);
        }

        public void CancelarPedidoAutoControle(RequisicaoItensDTO dto, bool reativar)
        {
            string query;
            string dataHoraGerar = "NULL";
            string dataHoraAdmPac = "NULL";
            string usuarioCancelado = "   RIA_SEG_ID_USUARIO_CANCELADO = " + dto.IdUsuarioPedidoAutoCancelado.Value;
            if (reativar)
                usuarioCancelado = "   RIA_SEG_ID_USUARIO_CANCELADO = NULL ";

            if (!dto.DataHoraGerar.Value.IsNull)
                dataHoraGerar = "TO_DATE('" + DateTime.Parse(dto.DataHoraGerar.Value.ToString()).ToString("ddMMyyyy HHmm") + "','ddMMyyyy HH24MI')";
            if (!dto.DataHoraAdmPaciente.Value.IsNull)
                dataHoraAdmPac = "TO_DATE('" + DateTime.Parse(dto.DataHoraAdmPaciente.Value.ToString()).ToString("ddMMyyyy HHmm") + "','ddMMyyyy HH24MI')";

            query = "UPDATE TB_MTMD_REQUISICAO_ITEM_AUTO SET " +
                        usuarioCancelado +
                        " , RIA_DT_ATUALIZACAO = SYSDATE" +
                    " WHERE MTMD_REQ_ID = " + dto.Idt.Value +
                      " AND CAD_MTMD_ID = " + dto.IdtProduto.Value;

            if (!dto.DataHoraGerar.Value.IsNull)
                query += " AND RIA_DATA_HORA_GERAR = " + dataHoraGerar;
            else
                query += " AND RIA_DATA_HORA_GERAR IS NULL ";

            if (!dto.DataHoraAdmPaciente.Value.IsNull)
                query += " AND RIA_DATA_HORA_ADM_PAC = " + dataHoraAdmPac;
            else
                query += " AND RIA_DATA_HORA_ADM_PAC IS NULL ";

            Connection.ExecuteCommand(query);
        }

        public void DelPedidoAutoControle(RequisicaoItensDTO dto)
        {
            string query;            

            query = "DELETE TB_MTMD_REQUISICAO_ITEM_AUTO " +                        
                    " WHERE MTMD_REQ_ID = " + dto.Idt.Value +
                      " AND CAD_MTMD_ID = " + dto.IdtProduto.Value;

            Connection.ExecuteCommand(query);
        }

        /// <summary>
        /// ListarPedidoAutoControle
        /// </summary>        
        /// <param name="tipoBusca">1 = TODOS
        ///                         2 = PENDENTES DE GERAÇÃO
        ///                         3 = JÁ GERADOS
        ///                         4 = PENDENTES DE GERAÇÃO JUNTO COM SUSPENSOS NA PRESCRIÇÃO DA INTERNAÇÃO
        ///                         5 = SUSPENSOS NA PRESCRIÇÃO DA INTERNAÇÃO
        /// </param>
        public RequisicaoItensDataTable ListarPedidoAutoControle(RequisicaoItensDTO dtoItem, RequisicaoDTO dtoReq, byte tipoBusca)
        {
            if (tipoBusca != 1 && tipoBusca != 2 && tipoBusca != 3 && tipoBusca != 4 && tipoBusca != 5) return null;

            string filtros = string.Empty;            

            if (!dtoReq.IdtAtendimento.Value.IsNull)
                filtros += " AND REQ.ATD_ATE_ID = " + dtoReq.IdtAtendimento.Value.ToString() + "\n";

            if (!dtoReq.IdtSetor.Value.IsNull)
                filtros += " AND REQ.CAD_SET_ID = " + dtoReq.IdtSetor.Value.ToString() + "\n";

            if (!dtoItem.IdPrescricaoItemInternacao.Value.IsNull)
                filtros += " AND RI.ATD_MPM_ID = " + dtoItem.IdPrescricaoItemInternacao.Value.ToString() + "\n";

            if (!dtoItem.IdPrescricaoInternacao.Value.IsNull)
                filtros += " AND RI.ATD_PME_ID = " + dtoItem.IdPrescricaoInternacao.Value.ToString() + "\n";

            if (!dtoItem.IdtProduto.Value.IsNull)
                filtros += " AND RIA.CAD_MTMD_ID = " + dtoItem.IdtProduto.Value.ToString() + "\n";

            if (!dtoItem.Idt.Value.IsNull)
                filtros += " AND RIA.MTMD_REQ_ID = " + dtoItem.Idt.Value.ToString() + "\n";

            if (!dtoItem.IdtNovo.Value.IsNull)
                filtros += " AND RIA.MTMD_REQ_ID_NOVO = " + dtoItem.IdtNovo.Value.ToString() + "\n";

            if (!dtoItem.IdUsuarioPedidoAutoCancelado.Value.IsNull) //Se passar o usuário, não trazer cancelados
                filtros += " AND RIA.RIA_SEG_ID_USUARIO_CANCELADO IS NULL \n";

            if (!dtoItem.DataHoraAdmPaciente.Value.IsNull)
                filtros += " AND RIA.RIA_DATA_HORA_ADM_PAC = " + "TO_DATE('" + DateTime.Parse(dtoItem.DataHoraAdmPaciente.Value.ToString()).ToString("ddMMyyyy HHmm") + "','ddMMyyyy HH24MI')" + "\n";            

            if (!dtoItem.DataHoraGerar.Value.IsNull)
                filtros += " AND RIA.RIA_DATA_HORA_GERAR = " + "TO_DATE('" + DateTime.Parse(dtoItem.DataHoraGerar.Value.ToString()).ToString("ddMMyyyy HHmm") + "','ddMMyyyy HH24MI')" + "\n";

            if (tipoBusca == 3 && dtoReq.DataRequisicao.Value.IsNull && dtoItem.DataHoraGerar.Value.IsNull && dtoReq.IdtAtendimento.Value.IsNull && dtoItem.Idt.Value.IsNull)
                dtoReq.DataRequisicao.Value = DateTime.Now.AddDays(-10).Date; //trazer só até 10 dias

            if (!dtoReq.DataRequisicao.Value.IsNull) //Só trazer registros a partir desta data quando informada
                filtros += " AND RIA.RIA_DATA_HORA_GERAR >= " + "TO_DATE('" + DateTime.Parse(dtoReq.DataRequisicao.Value.ToString()).ToString("ddMMyyyy HHmm") + "','ddMMyyyy HH24MI')" + "\n";

            if (!dtoReq.DataRequisicao2.Value.IsNull) //Só trazer registros com data menor que esta quando informada
                filtros += " AND RIA.RIA_DATA_HORA_GERAR <= " + "TO_DATE('" + DateTime.Parse(dtoReq.DataRequisicao2.Value.ToString()).ToString("ddMMyyyy HHmm") + "','ddMMyyyy HH24MI')" + "\n";

            switch (tipoBusca)
            {                
                case 2:
                    filtros += " AND RIA.MTMD_REQ_ID_NOVO IS NULL AND NVL(MPM.ATD_MPM_FL_PEDIDO_EST,'GE') NOT IN ('SU','PE') \n";
                    break;
                case 3:
                    filtros += " AND RIA.MTMD_REQ_ID_NOVO IS NOT NULL \n";
                    break;
                case 4:
                    filtros += " AND RIA.MTMD_REQ_ID_NOVO IS NULL  \n";
                    break;
                case 5:
                    filtros += " AND MPM.ATD_MPM_FL_PEDIDO_EST = 'SU' AND RIA.MTMD_REQ_ID_NOVO IS NULL \n";
                    break;
            }

            if (tipoBusca == 2 || tipoBusca == 4)
                filtros += " AND NVL(MPM.ATD_MPM_FL_PEDIDO_EST,'GE') IN ('PE','GE','SU') \n";

            string sqlString = "SELECT RIA.MTMD_REQ_ID,\n" +
                                "       RIA.CAD_MTMD_ID,\n" +
                                "       RIA.RIA_QTD_HRS_PERIODO_DOSE,\n" +
                                "       RIA.RIA_DATA_HORA_GERAR,\n" +
                                "       RIA.RIA_DATA_HORA_ADM_PAC,\n" +
                                "       RIA.RIA_QTD_PEDIDO,\n" +
                                "       RIA.MTMD_REQ_ID_NOVO,\n" +
                                "       RIA.RIA_SEG_ID_USUARIO_CANCELADO,\n" +
                                "       RIA.RIA_DT_ATUALIZACAO,\n" +
                                "       RIA.RIA_SEG_USU_ID_USUARIO,\n" +
                                "       RI.MTMD_REQITEM_QTD_SOLICITADA,\n" +
                                "       RI.CAD_MTMD_KIT_ID_ITEM,\n" +
                                "       RI.MTMD_QTD_KIT_MULTIPLICA,\n" +
                                "       REQ.CAD_MTMD_FILIAL_ID,\n" +
                                "       REQ.CAD_SET_SETOR_FARMACIA,\n" +
                                "       REQ.MTM_TIPO_REQUISICAO,\n" +
                                "       REQ.ATD_ATE_ID,\n" +
                                "       REQ.ATD_ATE_TP_PACIENTE,\n" +
                                "       REQ.CAD_UNI_ID_UNIDADE,\n" +
                                "       REQ.CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" +
                                "       REQ.CAD_SET_ID,\n" +
                                "       REQ.MTMD_ID_USUARIO_REQUISICAO,\n" +
                                "       SETOR.CAD_SET_DS_SETOR,\n" +
                                "       PROD.CAD_MTMD_NOMEFANTASIA,\n" +
                                "       PROD.CAD_MTMD_GRUPO_ID,\n" +
                                "       PROD.CAD_MTMD_SUBGRUPO_ID,\n" +
                                "       RI.MTMD_FL_GELADEIRA,\n" +
                                "       RI.ATD_MPM_ID,\n" +
                                "       RI.ATD_PME_ID,\n" +
                                "       MPM.ATD_MPM_FL_PEDIDO_EST\n" +
                            "  FROM TB_MTMD_REQUISICAO_ITEM_AUTO RIA JOIN\n" +
                            "       TB_MTMD_REQUISICAO_ITEM RI ON RI.MTMD_REQ_ID = RIA.MTMD_REQ_ID AND RI.CAD_MTMD_ID = RIA.CAD_MTMD_ID JOIN\n" +
                            "       TB_MTMD_REQ_REQUISICAO REQ ON REQ.MTMD_REQ_ID = RIA.MTMD_REQ_ID JOIN\n" +
                            "       TB_CAD_MTMD_MAT_MED PROD ON PROD.CAD_MTMD_ID = RIA.CAD_MTMD_ID JOIN\n" +
                            "       TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = REQ.CAD_SET_ID LEFT JOIN\n" +
                            "       TB_ATD_MPM_MED_PRESC_MED MPM ON MPM.ATD_MPM_ID = RI.ATD_MPM_ID \n" +
                            " WHERE RIA.RIA_DATA_HORA_GERAR IS NOT NULL\n" + filtros +
                            "ORDER BY RIA.RIA_DATA_HORA_GERAR, REQ.ATD_ATE_ID, RIA.MTMD_REQ_ID, SETOR.CAD_SET_DS_SETOR, PROD.CAD_MTMD_NOMEFANTASIA, RIA.RIA_DATA_HORA_ADM_PAC";

            RequisicaoItensDataTable result = new RequisicaoItensDataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);

            return result;
        }

        public RequisicaoItensDataTable ListarPedidoAutoPendenciasAgrupadas(decimal idAtendimento, decimal? idSetorDif)
        {
            string sqlString = "SELECT R.CAD_SET_SETOR_FARMACIA, R.MTMD_ID_USUARIO_REQUISICAO, RI.CAD_MTMD_ID, I.CAD_MTMD_KIT_ID_ITEM, ATD_PME_ID,\n" +
                                "       SUM(I.MTMD_QTD_KIT_MULTIPLICA) MTMD_QTD_KIT_MULTIPLICA,\n" +
                                "       SUM(RI.RIA_QTD_PEDIDO) RIA_QTD_PEDIDO\n" +
                                "FROM SGS.TB_MTMD_REQUISICAO_ITEM_AUTO RI JOIN\n" +
                                "     SGS.TB_MTMD_REQ_REQUISICAO R ON R.MTMD_REQ_ID = RI.MTMD_REQ_ID JOIN\n" +
                                "     SGS.TB_MTMD_REQUISICAO_ITEM I ON I.MTMD_REQ_ID = R.MTMD_REQ_ID AND I.CAD_MTMD_ID = RI.CAD_MTMD_ID\n" +
                                "WHERE RI.MTMD_REQ_ID_NOVO IS NULL AND RI.RIA_SEG_ID_USUARIO_CANCELADO IS NULL AND RI.RIA_DATA_HORA_GERAR >= SYSDATE-1\n" +
                                "  #CAD_SET_ID_DIF" +
                                "  AND R.ATD_ATE_ID = #ATD_ATE_ID\n" +
                                "GROUP BY R.CAD_SET_SETOR_FARMACIA, RI.CAD_MTMD_ID, I.CAD_MTMD_KIT_ID_ITEM, R.MTMD_ID_USUARIO_REQUISICAO, ATD_PME_ID";

            sqlString = sqlString.Replace("#ATD_ATE_ID", idAtendimento.ToString());

            if (idSetorDif != null)
                sqlString = sqlString.Replace("#CAD_SET_ID_DIF", "AND R.CAD_SET_ID != " + idSetorDif.Value + "\n");
            else
                sqlString = sqlString.Replace("#CAD_SET_ID_DIF", string.Empty);

            RequisicaoItensDataTable result = new RequisicaoItensDataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);

            return result;
        }

        public RequisicaoItensDataTable SelSugestaoItensRequisicao(RequisicaoDTO dtoReq, MaterialMedicamentoDTO dtoMatMed)
        {
            string filtros = " AND REQUISICAO.CAD_SET_ID = " + dtoReq.IdtSetor.Value.ToString() + "\n";
            filtros += " AND REQUISICAO.MTMD_DATA_REQUISICAO >= " + "TO_DATE('" + DateTime.Parse(dtoReq.DataRequisicao.Value.ToString()).ToString("ddMMyyyy HHmm") + "','ddMMyyyy HH24MI')" + "\n";

            if (dtoMatMed != null && !dtoMatMed.IdtGrupo.Value.IsNull && dtoMatMed.IdtGrupo.Value != 0)
            {
                if (dtoMatMed.IdtGrupo.Value == 1) //Ou traz só medicamentos, ou tudo que é diferente de medicamentos
                    filtros += " AND PRODUTO.CAD_MTMD_GRUPO_ID = " + dtoMatMed.IdtGrupo.Value.ToString() + "\n";
                else
                    filtros += " AND PRODUTO.CAD_MTMD_GRUPO_ID != 1 \n";
            }

            string sqlString = "SELECT 0 MTMD_REQ_ID,\n" +
                            "       ITEM.CAD_MTMD_ID,\n" +
                            "       TRUNC(AVG(ITEM.MTMD_REQITEM_QTD_SOLICITADA)) MTMD_REQITEM_QTD_SOLICITADA,\n" +
                            "       0 MTMD_REQITEM_QTD_FORNECIDA,\n" +
                            "       FNC_MTMD_SOUNDALIKE(PRODUTO.CAD_MTMD_NOMEFANTASIA,PRODUTO.CAD_MTMD_GRUPO_ID) CAD_MTMD_NOMEFANTASIA,\n" +
                            "       PRODUTO.CAD_MTMD_UNIDADE_VENDA,\n" +
                            "       PRODUTO.CAD_MTMD_UNIDADE_CONTROLE,\n" +
                            "       PRODUTO.CAD_MTMD_UNID_VENDA_DS,\n" +
                            "       PRODUTO.CAD_MTMD_PRIATI_ID,\n" +
                            "       PRODUTO.CAD_MTMD_FL_MAV,\n" +
                            "       PRODUTO.CAD_MTMD_GRUPO_ID\n" +
                            "  FROM TB_MTMD_REQUISICAO_ITEM ITEM JOIN\n" +
                            "       TB_MTMD_REQ_REQUISICAO  REQUISICAO ON REQUISICAO.MTMD_REQ_ID = ITEM.MTMD_REQ_ID JOIN\n" +
                            "       TB_CAD_MTMD_MAT_MED     PRODUTO    ON PRODUTO.CAD_MTMD_ID    = ITEM.CAD_MTMD_ID\n" +
                            " WHERE REQUISICAO.CAD_MTMD_FILIAL_ID = 1\n" + filtros +                            
                            "GROUP BY ITEM.CAD_MTMD_ID,\n" +
                            "         PRODUTO.CAD_MTMD_NOMEFANTASIA,\n" +
                            "         PRODUTO.CAD_MTMD_UNIDADE_VENDA,\n" +
                            "         PRODUTO.CAD_MTMD_UNIDADE_CONTROLE,\n" +
                            "         PRODUTO.CAD_MTMD_UNID_VENDA_DS,\n" +
                            "         PRODUTO.CAD_MTMD_PRIATI_ID,\n" +
                            "         PRODUTO.CAD_MTMD_FL_MAV,\n" +
                            "         PRODUTO.CAD_MTMD_GRUPO_ID\n" +
                            "HAVING TRUNC(AVG(ITEM.MTMD_REQITEM_QTD_SOLICITADA)) > 0\n" +
                            "ORDER BY PRODUTO.CAD_MTMD_GRUPO_ID, PRODUTO.CAD_MTMD_NOMEFANTASIA";

            RequisicaoItensDataTable result = new RequisicaoItensDataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);

            return result;
        }

        public RequisicaoItensDataTable ListarItensPrescricaoInt(RequisicaoDTO dto, int? idPrescInt, string statusItens)
        {
            string filtros = string.Empty;
            string strOrdenacaoExtra = string.Empty;
            string strOrdenacaoExtra2 = string.Empty;
            string strOrdenacaoExtra3 = string.Empty;
            string strFiltroSetorUnion1 = string.Empty;
            string strFiltroSetorUnion2 = string.Empty;

            if (!dto.IdtSetor.Value.IsNull)
            {
                filtros += " AND SETOR.CAD_SET_ID = " + dto.IdtSetor.Value.ToString() + "\n";
                strFiltroSetorUnion1 += " AND QLE.CAD_SET_ID = " + dto.IdtSetor.Value.ToString() + "\n";
                strFiltroSetorUnion2 += " AND IMS.CAD_SET_ID_SETOR = " + dto.IdtSetor.Value.ToString() + "\n";
            }

            if (!dto.IdtAtendimento.Value.IsNull)
                filtros += " AND PRESC.ATD_ATE_ID = " + dto.IdtAtendimento.Value.ToString() + "\n";

            if (!dto.Urgencia.Value.IsNull)
            {
                if (dto.Urgencia.Value == 1)
                    filtros += " AND NVL(ITEM.ATD_MPM_FL_IMEDIATO,'N') = 'S' \n";
                else
                    filtros += " AND NVL(ITEM.ATD_MPM_FL_IMEDIATO,'N') = 'N' \n";
            }

            if (!string.IsNullOrEmpty(statusItens))
                filtros += " AND ITEM.ATD_MPM_FL_PEDIDO_EST = '" + statusItens + "'\n";
            else
                filtros += " AND ITEM.ATD_MPM_FL_PEDIDO_EST IN ('PE','GE','SU')\n";

            if (idPrescInt != null)
            {
                filtros += " AND PRESC.ATD_PME_ID = " + idPrescInt.Value.ToString() + "\n";

                strOrdenacaoExtra = ", CASE WHEN (ITEM.ATD_MPM_TIPO IN ('DIE') AND (ITEM.ATD_MPM_STATUS IS NULL OR (ITEM.ATD_MPM_STATUS != 'S' and ITEM.ATD_MPM_STATUS != 'F' )))  THEN 1\n" +
                                    "             WHEN ITEM.ATD_MPM_TIPO IN ('DIE') THEN 2\n" +
                                    "             WHEN (ITEM.ATD_MPM_TIPO IN ('MED','DIL') AND (ITEM.ATD_MPM_STATUS IS NULL OR (ITEM.ATD_MPM_STATUS != 'S' and ITEM.ATD_MPM_STATUS != 'F' )))  THEN 3\n" +
                                    "             WHEN ITEM.ATD_MPM_TIPO IN ('MED','DIL') THEN 4\n" +
                                    "END ORDEM \n";


                strOrdenacaoExtra2 = "LEFT JOIN (SELECT ID, DT, ROWNUM LINHA, QUEBRA\n" +
                                     "                 FROM (SELECT ID, DT, VIA,QUEBRA\n" +
                                     "                         FROM (SELECT 1 ORDEM, MPM.ATD_MPM_ID ID, MPM.ATD_MPM_DT_HORA_CRIACAO DT,NVL(MPM.ATD_MPM_ID_PAI,MPM.ATD_MPM_ID) QUEBRA, TO_NUMBER(DECODE(MPM.ATD_MPM_CD_VIA,'19',-10,'20',-9,'13',-8,'25',-7,NULL,99,MPM.ATD_MPM_CD_VIA)) VIA\n" +
                                     "                                 FROM TB_ATD_MPM_MED_PRESC_MED MPM WHERE MPM.ATD_PME_ID = " + idPrescInt.Value.ToString() + " AND MPM.ATD_MPM_TIPO IN ('DIE')\n" +
                                     "               UNION\n" +
                                     "               SELECT 2 ordem, MPM.ATD_MPM_ID  ID, MPM.ATD_MPM_DT_HORA_CRIACAO DT,NVL(MPM.ATD_MPM_ID_PAI,MPM.ATD_MPM_ID) QUEBRA, TO_NUMBER(DECODE(MPM.ATD_MPM_CD_VIA,'19',-10,'20',-9,'13',-8,'25',-7,NULL,99,MPM.ATD_MPM_CD_VIA)) VIA\n" +
                                     "                 FROM TB_ATD_MPM_MED_PRESC_MED MPM WHERE MPM.ATD_PME_ID = " + idPrescInt.Value.ToString() + " AND MPM.ATD_MPM_TIPO IN ('DIL','MED')\n" +
                                     "              ) ORDER BY ORDEM,VIA, DT ASC)) LINHA ON LINHA.ID = ITEM.ATD_MPM_ID \n";

                strOrdenacaoExtra3 = "ORDEM, LINHA.LINHA,";
            }

            if (!dto.DataRequisicao.Value.IsNull && !dto.DataRequisicao2.Value.IsNull)
                filtros += " AND PRESC.ATD_PME_DT_HR_CRIACAO BETWEEN TO_DATE('" + DateTime.Parse(dto.DataRequisicao.Value.ToString()).ToString("ddMMyyyy HHmm") + "','ddMMyyyy HH24MI') " +
                                                               " AND TO_DATE('" + DateTime.Parse(dto.DataRequisicao2.Value.ToString()).ToString("ddMMyyyy HHmm") + "','ddMMyyyy HH24MI')\n";

            string queryExec = string.Format("SELECT PRESC.ATD_PME_ID, ITEM.ATD_MPM_ID,\n" +
                                            "       SETOR.CAD_UNI_ID_UNIDADE, SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO, SETOR.CAD_SET_ID,\n" +
                                            "       SETOR.CAD_SET_DS_SETOR,\n" +
                                            "       PRESC.ATD_ATE_ID,\n" +
                                            "       ITEM.ATD_MPM_NOME_PACIENTE NOME_PACIENTE,\n" +
                                            "       ITEM.CAD_MTMD_ID,\n" +
                                            "       PROD.CAD_MTMD_PRIATI_SAL_DSC,\n" +
                                            "       PROD.CAD_MTMD_FORMA_FARMACEUTICA,\n" +
                                            "       PROD.CAD_MTMD_DOSAGEM_PADRONIZADA,\n" +
                                            "       PROD.CAD_MTMD_PRIATI_ID,\n" +
                                            "       PROD.CAD_MTMD_GRUPO_ID,\n" +
                                            "       PROD.CAD_MTMD_SUBGRUPO_ID,\n" +
                                            "       PROD.CAD_MTMD_FL_GELADEIRA MTMD_FL_GELADEIRA,\n" +
                                            "       PRESC.ATD_PME_FL_STATUS,\n" +
                                            "       PRESC.ATD_PME_DT_HR_CRIACAO DT_HORA_PRESCRICAO,\n" +
                                            "       ITEM.ATD_MPM_QT_PEDIDO MTMD_REQITEM_QTD_SOLICITADA,\n" +
                                            "       ITEM.ATD_MPM_DOSE_ADM DOSE_ADM,\n" +
                                            "       ITEM.ATD_MPM_DS_INTERVALO RIA_QTD_HRS_PERIODO_DOSE,\n" +
                                            "       ITEM.ATD_MPM_DT_HORA_REALIZ HORA_ADM_PAC,\n" +
                                            "       ITEM.ATD_MPM_FL_IMEDIATO FL_IMEDIATO,\n" +
                                            "       ITEM.ATD_MPM_DILUENTE ATD_MPM_DILUENTE,\n" +
                                            "       ITEM.ATD_MPM_DS_OBSERVACAO DS_OBSERVACAO,\n" +
                                            "       ITEM.ATD_MPM_TIPO,\n" +
                                            "       ITEM.ATD_MPM_FL_PEDIDO_EST STATUS_PRESCRICAO_ITEM,\n" +
                                            "       CASE\n" +
                                            "         WHEN ITEM.ATD_MPM_FL_PEDIDO_EST = 'PE' THEN\n" +
                                            "           'PENDENTE'\n" +
                                            "         WHEN ITEM.ATD_MPM_FL_PEDIDO_EST = 'GE' THEN\n" +
                                            "           'GERADO'\n" +
                                            "         WHEN ITEM.ATD_MPM_FL_PEDIDO_EST = 'SU' THEN\n" +
                                            "           'SUSPENSO'\n" +
                                            "       END STATUS_PRESCRICAO_ITEM_DSC\n {1} " +
                                            "FROM TB_ATD_MPM_MED_PRESC_MED ITEM JOIN\n" +
                                            "     TB_ATD_PME_PRESCRICAO_MEDICA PRESC ON PRESC.ATD_PME_ID = ITEM.ATD_PME_ID JOIN\n" +
                                            "     TB_CAD_MTMD_MAT_MED PROD ON PROD.CAD_MTMD_ID = ITEM.CAD_MTMD_ID JOIN\n" +
                                            "     (SELECT IML.ATD_ATE_ID, QLE.CAD_SET_ID\n" +
                                            "        FROM TB_ATD_IML_INT_MOV_LEITO IML\n" +
                                            "        JOIN TB_CAD_QLE_QUARTO_LEITO QLE ON QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID\n" +
                                            "        JOIN TB_ATD_ATE_ATENDIMENTO ATD ON ATD.ATD_ATE_ID = IML.ATD_ATE_ID\n" +
                                            "       WHERE FNC_JUNTAR_DATA_HORA(IML.ATD_IML_DT_ENTRADA,IML.ATD_IML_HR_ENTRADA) =\n" +
                                            "             (SELECT MAX(FNC_JUNTAR_DATA_HORA(IML2.ATD_IML_DT_ENTRADA, IML2.ATD_IML_HR_ENTRADA))\n" +
                                            "                FROM TB_ATD_IML_INT_MOV_LEITO IML2\n" +
                                            "                WHERE IML2.ATD_ATE_ID = ATD.ATD_ATE_ID AND IML2.ATD_IML_FL_STATUS = 'A') {4}\n" +
                                            "              UNION\n" +
                                            "        SELECT IMS.ATD_ATE_ID, IMS.CAD_SET_ID_SETOR\n" +
                                            "          FROM TB_ATD_IMS_INT_MOV_SETOR IMS\n" +
                                            "         WHERE IMS.ATD_IMS_FL_STATUS = 'A' AND IMS.CAD_SET_ID_SETOR IN (22,61) {5}\n" +
                                            "           AND IMS.ATD_IMS_DT_ENTRADA >= SYSDATE-2 AND IMS.ATD_IMS_DT_SAIDA IS NULL\n" +
                                            "       ) SETOR_PRESCRICAO_INT ON SETOR_PRESCRICAO_INT.ATD_ATE_ID = PRESC.ATD_ATE_ID LEFT JOIN\n" +
                                            "    TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = SETOR_PRESCRICAO_INT.CAD_SET_ID\n {2} " +
                                            "WHERE ITEM.CAD_MTMD_ID IS NOT NULL AND ATD_MPM_TIPO NOT IN ('CND','DIC') {0} \n" + //CND = Condicional / DIC = Diluente Condicional (não gerar)
                                            "ORDER BY SETOR.CAD_SET_DS_SETOR, PRESC.ATD_ATE_ID, {3} PROD.CAD_MTMD_PRIATI_SAL_DSC, PROD.CAD_MTMD_FORMA_FARMACEUTICA, PROD.CAD_MTMD_DOSAGEM_PADRONIZADA",
                                            filtros, strOrdenacaoExtra, strOrdenacaoExtra2, strOrdenacaoExtra3, strFiltroSetorUnion1, strFiltroSetorUnion2);

            RequisicaoItensDataTable result = new RequisicaoItensDataTable();
            Connection.RecordSet(queryExec, result, CommandType.Text);
            return result;
        }

        //public RequisicaoItensDataTable ListarItensPendentesPrescricaoInt(RequisicaoItensDTO dto)
        //{
        //    string filtros = " AND MPM.ATD_PME_ID = " + dto.IdPrescricaoInternacao.Value.ToString() + "\n";

        //    string queryExec = string.Format("SELECT MPM.ATD_MPM_ID\n" +
        //                                        "FROM TB_ATD_MPM_MED_PRESC_MED MPM\n" +
        //                                        "WHERE MPM.CAD_MTMD_ID IS NOT NULL AND MPM.ATD_MPM_TIPO NOT IN ('CND','DIC')\n" +
        //                                        "  AND NVL(MPM.ATD_MPM_FL_PEDIDO_EST,'GE') IN ('PE')\n" +
        //                                        "  {0} \n",
        //                                     filtros);

        //    RequisicaoItensDataTable result = new RequisicaoItensDataTable();
        //    Connection.RecordSet(queryExec, result, CommandType.Text);
        //    return result;
        //}

        public RequisicaoItensDataTable ListarItensGeradosPrescricaoInt_SemPedidoGestao(RequisicaoItensDTO dto)
        {
            string filtros = " AND MPM.ATD_PME_ID = " + dto.IdPrescricaoInternacao.Value.ToString() + "\n";

            string queryExec = string.Format("SELECT MPM.ATD_MPM_DS_MEDICAMENTO || ' -> QTD: ' || SUM(MPM.ATD_MPM_QT_PEDIDO) ITEM\n" +
                                                "FROM TB_ATD_MPM_MED_PRESC_MED MPM\n" +
                                                "WHERE MPM.CAD_MTMD_ID IS NOT NULL AND MPM.ATD_MPM_TIPO NOT IN ('CND','DIC')\n" +                                                
                                                "  AND MPM.ATD_MPM_FL_PEDIDO_EST = 'GE'\n" +
                                                "  {0} \n" +
                                                "  AND MPM.ATD_MPM_ID NOT IN (SELECT ATD_MPM_ID FROM TB_MTMD_REQUISICAO_ITEM I WHERE I.ATD_MPM_ID = MPM.ATD_MPM_ID)\n" +
                                                "GROUP BY MPM.ATD_MPM_DS_MEDICAMENTO\n" +
                                                "ORDER BY MPM.ATD_MPM_DS_MEDICAMENTO",
                                            filtros);

            RequisicaoItensDataTable result = new RequisicaoItensDataTable();
            Connection.RecordSet(queryExec, result, CommandType.Text);
            return result;
        }

        public void UpdStatusItemPrescricaoInt(int? idPrescInternacao, int? idPrescItem, int idUsuario, string statusItem)
        {
            string query;
            if (idPrescItem != null)
            {
                query = "UPDATE TB_ATD_MPM_MED_PRESC_MED SET " +
                            "   ATD_MPM_FL_PEDIDO_EST = '" + statusItem + "'" +
                            //" , ATD_MPM_ID_USU_ULT_ATUALIZ = " + idUsuario +
                            " , ATD_MPM_DT_ULT_ATUALIZ = SYSDATE" +
                        " WHERE ATD_MPM_ID = " + idPrescItem.Value;
            }
            else
            {
                if (statusItem == "GE")
                {
                    query = "UPDATE TB_ATD_MPM_MED_PRESC_MED SET " +
                                "   ATD_MPM_FL_PEDIDO_EST = '" + statusItem + "'" +
                                //" , ATD_MPM_ID_USU_ULT_ATUALIZ = " + idUsuario +
                                " , ATD_MPM_DT_ULT_ATUALIZ = SYSDATE" +
                            " WHERE ATD_MPM_FL_PEDIDO_EST = 'PE' AND ATD_PME_ID = " + idPrescInternacao.Value;
                }
                else
                {
                    query = "UPDATE TB_ATD_MPM_MED_PRESC_MED SET " +
                                "   ATD_MPM_FL_PEDIDO_EST = '" + statusItem + "'" +
                                //" , ATD_MPM_ID_USU_ULT_ATUALIZ = " + idUsuario +
                                " , ATD_MPM_DT_ULT_ATUALIZ = SYSDATE" +
                            " WHERE ATD_PME_ID = " + idPrescInternacao.Value;
                }
            }

            Connection.ExecuteCommand(query);
        }

        public void UpdStatusPrescricaoInt(int idPrescInternacao, string status)
        {
            string query;
            query = "UPDATE TB_ATD_PME_PRESCRICAO_MEDICA SET " +
                        "   ATD_PME_FL_STATUS = '" + status + "'" +
                        " , ATD_PME_DT_ULT_ATUALIZ = SYSDATE" +
                    " WHERE ATD_PME_ID = " + idPrescInternacao;

            Connection.ExecuteCommand(query);
        }

        public string ObterTelefoneUsuarioMedicoInt(int idPrescItem)
        {
            DataTable result = new DataTable();
            //Busca último usuário que alterou a MPM
            string sqlString = "SELECT SUBSTR(USU.SEG_USU_DS_LOGIN, 4, LENGTH(USU.SEG_USU_DS_LOGIN)-3)\n" + //CRM pega do Login do Médico sem os 3 primeiros caracteres
                               "  FROM TB_ATD_MPM_MED_PRESC_MED MPM JOIN\n" +
                               "       TB_SEG_USU_USUARIO USU ON USU.SEG_USU_ID_USUARIO = MPM.ATD_MPM_ID_USU_ULT_ATUALIZ\n" +
                               " WHERE MPM.ATD_MPM_ID = " + idPrescItem;
            result = new DataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);

            if (result.Rows.Count > 0)
            {
                string crm = result.Rows[0][0].ToString();
                //Busca telefone pelo CRM do médico
                sqlString = "SELECT T.CAD_TEL_NR_NUM_TEL\n" +
                            "  FROM TB_CAD_TEL_TELEFONE T\n" +
                            " WHERE T.AUX_TTE_CD_TP_TEL_END = 8\n" +
                            "   AND T.CAD_PES_ID_PESSOA IN (SELECT P.CAD_PES_ID_PESSOA\n" +
                            "                                FROM TB_CAD_PRO_PROFISSIONAL P\n" +
                            "                                WHERE P.CAD_PRO_NR_CONSELHO = '" + crm.Trim() + "'\n" +
                            "                                AND P.CAD_PRO_SG_UF_CONSELHO = 'SP'\n" +
                            "                                AND P.TIS_CPR_CD_CONSELHOPROF = 'CRM')";
                result = new DataTable();
                Connection.RecordSet(sqlString, result, CommandType.Text);

                if (result.Rows.Count > 0)
                    return result.Rows[0][0].ToString();
                else
                    return null;
            }
            else
                return null;
        }
	}
}