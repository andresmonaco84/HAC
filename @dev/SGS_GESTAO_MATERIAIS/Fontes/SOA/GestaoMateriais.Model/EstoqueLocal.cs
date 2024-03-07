
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class EstoqueLocal : Entity
    {
        public void AcertarEstoqueProduto(EstoqueLocalDTO dto, bool inventarioRotativo)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pMTMD_MOV_QTDE
            param.Add(Connection.CreateParameter("pMTMD_ESTLOC_QTDE", dto.Qtde.DBValue, ParameterDirection.Input, dto.Qtde.DbType));

            //SEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));

            #endregion

            string query = "PRC_MTMD_MOV_ESTOQUE_ACERTO";
            if (inventarioRotativo)
            {
                query = "PRC_MTMD_MOV_INVENT_ROTATIVO";

                if (!dto.IdtLote.Value.IsNull)                    
                    param.Add(Connection.CreateParameter("pMTMD_LOTEST_ID", dto.IdtLote.DBValue, ParameterDirection.Input, dto.IdtLote.DbType));
            }

            //Executa o procedimento
            EstoqueLocalDataTable result = new EstoqueLocalDataTable();
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Listar todos os registros
        /// </summary>
        public EstoqueLocalDataTable Sel(EstoqueLocalDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            // Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pMTMD_ESTLOC_DATA
            // param.Add(Connection.CreateParameter("pMTMD_ESTLOC_DATA", dto.DataAtualizacao.DBValue, ParameterDirection.Input, dto.DataAtualizacao.DbType));

            //Parametro pMTMD_ESTLOC_QTDE
            // param.Add(Connection.CreateParameter("pMTMD_ESTLOC_QTDE", dto.Qtde.DBValue, ParameterDirection.Input, dto.Qtde.DbType));

            // Parametro pOrigem
            param.Add(Connection.CreateParameter("pOrigem", dto.Origem.DBValue, ParameterDirection.Input, dto.Origem.DbType));
            #endregion

            EstoqueLocalDataTable result = new EstoqueLocalDataTable();
            string query = "PRC_MTMD_ESTOQUE_LOCAL_PRODUTO";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }

        /// <summary>
        /// Carrega dados do estoque on Line
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public EstoqueLocalDataTable EstoqueOnLine(EstoqueLocalDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            // Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));


            #endregion

            EstoqueLocalDataTable result = new EstoqueLocalDataTable();
            string query = "PRC_MTMD_ESTOQUE_ON_LINE";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }

        /// <summary>
        /// Busca saldo do produto no estoque local, calculando produtos inteiros que foram fracionados
        /// </summary>
        /// <param name="dto"></param>
        public EstoqueLocalDTO EstoqueLocalProduto(EstoqueLocalDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            // Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            //Parametro pMTMD_LOTEST_ID
            param.Add(Connection.CreateParameter("pMTMD_LOTEST_ID", dto.IdtLote.DBValue, ParameterDirection.Input, dto.IdtLote.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            // Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            // Parametro pOrigem
            param.Add(Connection.CreateParameter("pOrigem", dto.Origem.DBValue, ParameterDirection.Input, dto.Origem.DbType));

            // não é uma sequence, retorna a quantidade no estoque consultado
            // param.Add(Connection.CreateParameterSequence());
            #endregion

            EstoqueLocalDataTable result = new EstoqueLocalDataTable();
            string query = "PRC_MTMD_ESTOQUE_LOCAL_PRODUTO";

            // Executa o Procedimento
            // Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);

            // dto.Qtde.Value = Int32.Parse(param["pNewIdt"].Value.ToString());
            // return result;
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            if (result.Rows.Count == 0) return new EstoqueLocalDTO();

            return result.TypedRow(0);
        }

        /// <summary>
        /// Exclui o registro
        /// </summary>        
        public void Del(EstoqueLocalDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            // Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            // Parametro pMTMD_LOTEST_ID
            param.Add(Connection.CreateParameter("pMTMD_LOTEST_ID", dto.IdtLote.DBValue, ParameterDirection.Input, dto.IdtLote.DbType));

            // Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));


            #endregion
            //Executa o procedimento

            string query = "PRC_MTMD_ESTLOC_ESTOQUE_LOCAL_D";

            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Altera o registro
        /// </summary>			
        public void Upd(EstoqueLocalDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            //Parametro pMTMD_LOTEST_ID
            param.Add(Connection.CreateParameter("pMTMD_LOTEST_ID", dto.IdtLote.DBValue, ParameterDirection.Input, dto.IdtLote.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pMTMD_ESTLOC_DATA
            param.Add(Connection.CreateParameter("pMTMD_ESTLOC_DATA", dto.DataAtualizacao.DBValue, ParameterDirection.Input, dto.DataAtualizacao.DbType));

            //Parametro pMTMD_ESTLOC_QTDE
            param.Add(Connection.CreateParameter("pMTMD_ESTLOC_QTDE", dto.Qtde.DBValue, ParameterDirection.Input, dto.Qtde.DbType));

            // Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));


            #endregion

            string query = "PRC_MTMD_ESTLOC_ESTOQUE_LOCAL_U";

            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Inclui o registro
        /// </summary>			
        public void Ins(EstoqueLocalDTO dto)
        {
            string query = "PRC_MTMD_ESTLOC_ESTOQUE_LOCAL_I";

            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();


            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            //Parametro pMTMD_LOTEST_ID
            param.Add(Connection.CreateParameter("pMTMD_LOTEST_ID", dto.IdtLote.DBValue, ParameterDirection.Input, dto.IdtLote.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pMTMD_ESTLOC_DATA
            param.Add(Connection.CreateParameter("pMTMD_ESTLOC_DATA", dto.DataAtualizacao.DBValue, ParameterDirection.Input, dto.DataAtualizacao.DbType));

            //Parametro pMTMD_ESTLOC_QTDE
            param.Add(Connection.CreateParameter("pMTMD_ESTLOC_QTDE", dto.Qtde.DBValue, ParameterDirection.Input, dto.Qtde.DbType));

            // Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));


            #endregion

            // Executa o Procedimento
            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);

        }

        public void InativaEstoqueProduto(EstoqueLocalDTO dto)
        {
            string query = "PRC_MTMD_ESTOQUE_LOCAL_INATIVA";

            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();


            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            // Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            //SEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));


            #endregion

            // Executa o Procedimento
            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);

        }

        /// <summary>
        /// Verifica se o estoque passado é centro de dispensação, se for Centro de dispensação retorna TRUE
        /// </summary>
        /// <returns></returns>
        public bool EstoqueCentroDispensacao(EstoqueLocalDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));


            //Parametro pRetorno
            param.Add(Connection.CreateParameter("pRetorno", null, ParameterDirection.Output, DbType.Decimal));

            #endregion

            string query = "PRC_MTMD_CENTRO_DISPENSACAO";

            try
            {
                //Executa o procedimento
                MovimentacaoDataTable result = new MovimentacaoDataTable();
                Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
            }
            catch (Exception ora)
            {
                throw new Exception(ora.Message);
            }
            return decimal.Parse(param["pRetorno"].Value.ToString()) == 1 ? true : false;

        }

        /// <summary>
        /// No caso de estoque compartilhado
        /// </summary>
        /// <returns></returns>
        public int EstoqueDeConsumo(EstoqueLocalDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            //Parametro pUNIDADE_ESTOQUE_CONSUMO
            param.Add(Connection.CreateParameter("pUNIDADE_ESTOQUE_CONSUMO", null, ParameterDirection.Output, dto.IdtUnidade.DbType));

            //Parametro pLOCAL_ESTOQUE_CONSUMO
            param.Add(Connection.CreateParameter("pLOCAL_ESTOQUE_CONSUMO", null, ParameterDirection.Output, dto.IdtLocal.DbType));

            //Parametro pSETOR_ESTOQUE_CONSUMO
            param.Add(Connection.CreateParameter("pSETOR_ESTOQUE_CONSUMO", null, ParameterDirection.Output, dto.IdtSetor.DbType));

            #endregion

            string query = "PRC_MTMD_ESTOQUE_DE_CONSUMO";

            try
            {
                //Executa o procedimento
                Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
            }
            catch (Exception ora)
            {
                throw new Exception(ora.Message);
            }
            return int.Parse(param["pSETOR_ESTOQUE_CONSUMO"].Value.ToString());
        }

        /// <summary>
        /// ListarEstoqueMes
        /// </summary>
        /// <param name="dto">EstoqueLocalDTO</param>
        /// <param name="strAnoMesDe">Formato AAAAMM</param>
        /// <param name="strAnoMesAte">Formato AAAAMM</param>
        /// <returns></returns>
        public DataTable ListarEstoqueMes(EstoqueLocalDTO dto, string strAnoMesDe, string strAnoMesAte)
        {
            string filtros = string.Empty;

            if (!dto.IdtSetor.Value.IsNull)
                filtros += " AND EST.CAD_SET_ID = " + dto.IdtSetor.Value.ToString() + "\n";

            string sqlString = "SELECT UNI.CAD_UNI_DS_UNIDADE UNIDADE,\n" +
                                "       SETOR.CAD_SET_DS_SETOR SETOR,\n" +
                                "       EST.CAD_MTMD_GRUPO_ID CODGRP,\n" +
                                "       GRUPO.CAD_MTMD_GRUPO_DESCRICAO GRUPO,\n" +
                                "       EST.CAD_MTMD_ID PRODUTO_ID,\n" +
                                "       PROD.CAD_MTMD_NOMEFANTASIA PRODUTO_DESCRICAO,\n" +
                                "       PROD.CAD_MTMD_UNID_VENDA_DS UNIDADE_PROD,\n" +
                                "       EST.MTMD_MOV_ANO || '/' || LPAD(EST.MTMD_MOV_MES,2,'0') ANO_MES,\n" +
                                "       EST.MTMD_SALDO_ATUAL SALDO_MES,\n" +
                                "       EST.MTMD_VALOR_ATUAL VALOR_MEDIO_MES\n" +
                                "FROM TB_MTMD_ESTOQUE_LOCAL_MES EST JOIN\n" +
                                "     TB_CAD_UNI_UNIDADE UNI ON UNI.CAD_UNI_ID_UNIDADE = EST.CAD_UNI_ID_UNIDADE JOIN\n" +
                                "     TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = EST.CAD_SET_ID JOIN\n" +
                                "     TB_CAD_MTMD_GRUPO GRUPO ON GRUPO.CAD_MTMD_GRUPO_ID = EST.CAD_MTMD_GRUPO_ID JOIN\n" +
                                "     TB_CAD_MTMD_MAT_MED PROD ON PROD.CAD_MTMD_ID = EST.CAD_MTMD_ID\n" +
                                "WHERE TO_NUMBER(EST.MTMD_MOV_ANO || LPAD(EST.MTMD_MOV_MES,2,'0')) >= " + strAnoMesDe + " AND\n" +
                                "      TO_NUMBER(EST.MTMD_MOV_ANO || LPAD(EST.MTMD_MOV_MES,2,'0')) <= " + strAnoMesAte + " AND\n" +
                                "      EST.CAD_MTMD_FILIAL_ID = " + dto.IdtFilial.Value + "\n" + filtros +
                                "ORDER BY UNI.CAD_UNI_DS_UNIDADE,SETOR.CAD_SET_DS_SETOR,PROD.CAD_MTMD_NOMEFANTASIA,\n" +
                                "         TO_NUMBER(EST.MTMD_MOV_ANO || LPAD(EST.MTMD_MOV_MES,2,'0'))";


            DataTable result = new DataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);
            return result;
        }

        public EstoqueLocalDataTable ListarEstoqueLote(EstoqueLocalDTO dto)
        {
            string filtros = string.Empty;
            if (!dto.IdtSetor.Value.IsNull)
            {
                EstoqueLocalDTO dtoEstoque = new EstoqueLocalDTO();
                dtoEstoque.IdtUnidade.Value = dto.IdtUnidade.Value;
                dtoEstoque.IdtLocal.Value = dto.IdtLocal.Value;
                dtoEstoque.IdtSetor.Value = dto.IdtSetor.Value;
                dtoEstoque.IdtFilial.Value = dto.IdtFilial.Value;
                dto.IdtSetor.Value = this.EstoqueDeConsumo(dtoEstoque);

                filtros += " AND ESTLOTE.CAD_SET_ID = " + dto.IdtSetor.Value.ToString() + "\n";
            }

            if (!dto.IdtFilial.Value.IsNull)
                filtros += " AND ESTLOTE.CAD_MTMD_FILIAL_ID = " + dto.IdtFilial.Value.ToString() + "\n";

            if (!dto.IdtProduto.Value.IsNull)
                filtros += " AND PRODUTO.CAD_MTMD_ID = " + dto.IdtProduto.Value.ToString() + "\n";

            if (!dto.CodLote.Value.IsNull)
                filtros += " AND ESTLOTE.MTMD_COD_LOTE = '" + dto.CodLote.Value.ToString() + "'\n";

            string sqlString = "SELECT  ESTLOTE.CAD_MTMD_FILIAL_ID,\n" +
                                "        ESTLOTE.CAD_SET_ID,\n" +
                                "        PRODUTO.CAD_MTMD_ID,\n" +
                                "        PRODUTO.CAD_MTMD_CODMNE,\n" +
                                "        PRODUTO.CAD_MTMD_PRIATI_ID,\n" +
                                "        FNC_MTMD_SOUNDALIKE(PRODUTO.CAD_MTMD_NOMEFANTASIA,PRODUTO.CAD_MTMD_GRUPO_ID) CAD_MTMD_NOMEFANTASIA,\n" +
                                "        PRODUTO.CAD_MTMD_UNID_VENDA_DS,\n" +
                                "        DECODE(PRODUTO.TIS_MED_CD_TABELAMEDICA, '95', 'MA', 96, 'ME') TIS_MED_CD_TABELAMEDICA,\n" +
                                "        PRODUTO.CAD_MTMD_FL_ATIVO,\n" +
                                "        PRODUTO.CAD_MTMD_FL_FRACIONA,\n" +
                                "        PRODUTO.CAD_MTMD_FL_BAIXA_AUTOMATICA,\n" +
                                "        PRODUTO.CAD_MTMD_GRUPO_ID,\n" +
                                "        PRODUTO.CAD_MTMD_FL_MAV,\n" +
                                "        PRODUTO.CAD_MTMD_ENDERECO_ALMOX_HAC,\n" +
                                "        ESTLOTE.MTMD_COD_LOTE,\n" +
                                "        ESTLOTE.MTMD_EST_QTDE MTMD_ESTLOC_QTDE_LOTE,\n" +
                                "        ESTLOTE.MTMD_DATA_ATUALIZADO MTMD_DATA_ATUAL_LOTE,\n" +
                                "        DECODE(ESTLOTE.CAD_MTMD_FILIAL_ID,4,'CE','HAC') ESTOQUE_FILIAL,\n" +
                                "        UNI.CAD_UNI_DS_UNIDADE,\n" +
                                "        SETOR.CAD_SET_DS_SETOR,\n" +
                                "        (SELECT NVL(LL.MTMD_NUM_LOTE_ALT, LL.MTMD_NUM_LOTE)\n" +
                                "           FROM TB_MTMD_LOTEST_LOTE_ESTOQUE LL\n" +
                                "          WHERE LL.CAD_MTMD_FILIAL_ID = 1 AND LL.MTMD_COD_LOTE = ESTLOTE.MTMD_COD_LOTE AND\n" +
                                "                LL.CAD_MTMD_ID   = ESTLOTE.CAD_MTMD_ID AND ROWNUM = 1) MTMD_NUM_LOTE,\n" +
                                "        (SELECT NVL(LL.MTMD_DT_VAL_ALT, LL.MTMD_DT_VALIDADE)\n" +
                                "           FROM TB_MTMD_LOTEST_LOTE_ESTOQUE LL\n" +
                                "          WHERE LL.CAD_MTMD_FILIAL_ID = 1 AND LL.MTMD_COD_LOTE = ESTLOTE.MTMD_COD_LOTE AND\n" +
                                "                LL.CAD_MTMD_ID   = ESTLOTE.CAD_MTMD_ID AND ROWNUM = 1) MTMD_DT_VALIDADE\n" +
                                " FROM TB_MTMD_ESTOQUE_LOTE ESTLOTE JOIN\n" +
                                "      TB_CAD_MTMD_MAT_MED PRODUTO ON PRODUTO.CAD_MTMD_ID = ESTLOTE.CAD_MTMD_ID JOIN\n" +
                                "      TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = ESTLOTE.CAD_SET_ID JOIN\n" +
                                "      TB_CAD_UNI_UNIDADE UNI ON UNI.CAD_UNI_ID_UNIDADE = SETOR.CAD_UNI_ID_UNIDADE\n" +
                                " WHERE PRODUTO.CAD_MTMD_GRUPO_ID = 1\n" + //Só medicamentos                                
                                "   AND NVL(PRODUTO.CAD_MTMD_FL_CONTROLA_LOTE,0) = 1\n" + filtros +
                //"   AND FNC_MTMD_CONTROLA_LOTE_COD(ESTLOTE.CAD_MTMD_ID, ESTLOTE.MTMD_COD_LOTE) = 1\n" + filtros +
                //"UNION\n" +
                //"SELECT  DISTINCT\n" +
                //"        ESTLOTE.CAD_MTMD_FILIAL_ID,\n" +
                //"        ESTLOTE.CAD_SET_ID,\n" +
                //"        PRODUTO.CAD_MTMD_ID,\n" +
                //"        PRODUTO.CAD_MTMD_CODMNE,\n" +
                //"        PRODUTO.CAD_MTMD_PRIATI_ID,\n" +
                //"        FNC_MTMD_SOUNDALIKE(PRODUTO.CAD_MTMD_NOMEFANTASIA,PRODUTO.CAD_MTMD_GRUPO_ID) CAD_MTMD_NOMEFANTASIA,\n" +
                //"        PRODUTO.CAD_MTMD_UNID_VENDA_DS,\n" +
                //"        DECODE(PRODUTO.TIS_MED_CD_TABELAMEDICA, '95', 'MA', 96, 'ME') TIS_MED_CD_TABELAMEDICA,\n" +
                //"        PRODUTO.CAD_MTMD_FL_ATIVO,\n" +
                //"        PRODUTO.CAD_MTMD_FL_FRACIONA,\n" +
                //"        PRODUTO.CAD_MTMD_FL_BAIXA_AUTOMATICA,\n" +
                //"        PRODUTO.CAD_MTMD_GRUPO_ID,\n" +
                //"        PRODUTO.CAD_MTMD_FL_MAV,\n" +
                //"        'SEM_LOTE' MTMD_COD_LOTE,\n" +
                //"        FNC_MTMD_EST_SEMLOTE_SETOR(PRODUTO.CAD_MTMD_ID,\n" +
                //"                                   SETOR.CAD_UNI_ID_UNIDADE,\n" +
                //"                                   SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" +
                //"                                   SETOR.CAD_SET_ID,\n" +
                //"                                   ESTLOTE.CAD_MTMD_FILIAL_ID) MTMD_ESTLOC_QTDE_LOTE,\n" +
                //"        NULL MTMD_DATA_ATUAL_LOTE,\n" +
                //"        DECODE(ESTLOTE.CAD_MTMD_FILIAL_ID,4,'CE','HAC') ESTOQUE_FILIAL,\n" +
                //"        UNI.CAD_UNI_DS_UNIDADE,\n" +
                //"        SETOR.CAD_SET_DS_SETOR,\n" +
                //"        NULL MTMD_NUM_LOTE,\n" +
                //"        NULL MTMD_DT_VALIDADE\n" +
                //" FROM TB_MTMD_ESTOQUE_LOTE ESTLOTE JOIN\n" +
                //"      TB_CAD_MTMD_MAT_MED PRODUTO ON PRODUTO.CAD_MTMD_ID = ESTLOTE.CAD_MTMD_ID JOIN\n" +
                //"      TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = ESTLOTE.CAD_SET_ID JOIN\n" +
                //"      TB_CAD_UNI_UNIDADE UNI ON UNI.CAD_UNI_ID_UNIDADE = SETOR.CAD_UNI_ID_UNIDADE\n" +
                //" WHERE PRODUTO.CAD_MTMD_GRUPO_ID = 1\n" + //Só medicamentos                                
                //"   AND NVL(PRODUTO.CAD_MTMD_FL_CONTROLA_LOTE,0) = 1\n" + filtros +
                                "ORDER BY CAD_MTMD_NOMEFANTASIA, MTMD_COD_LOTE, ESTOQUE_FILIAL, CAD_UNI_DS_UNIDADE, CAD_SET_DS_SETOR";

            EstoqueLocalDataTable result = new EstoqueLocalDataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);
            return result;
        }

        public MaterialMedicamentoDTO ObterSimilarProximoVencimento(MaterialMedicamentoDTO dtoMatMed)
        {
            string sqlString;
            if (!dtoMatMed.IdtPrincipioAtivo.Value.IsNull && dtoMatMed.IdtPrincipioAtivo.Value != 0)
            {
                sqlString = "SELECT CAD_MTMD_ID FROM\n" +
                            "(SELECT PRODUTO.CAD_MTMD_ID\n" +
                            "  FROM TB_MTMD_ESTOQUE_LOTE ESTLOTE JOIN\n" +
                            "  TB_CAD_MTMD_MAT_MED PRODUTO ON PRODUTO.CAD_MTMD_ID = ESTLOTE.CAD_MTMD_ID\n" +
                            "  WHERE ESTLOTE.CAD_MTMD_FILIAL_ID = 1\n" +
                            "    AND ESTLOTE.MTMD_EST_QTDE > 0\n" +
                            "    AND ESTLOTE.CAD_SET_ID IN (2592,2632)\n" + //Unit./Farm. Central
                            "    AND PRODUTO.CAD_MTMD_PRIATI_ID = " + dtoMatMed.IdtPrincipioAtivo.Value + "\n" +
                            "  ORDER BY (SELECT NVL(LL.MTMD_DT_VAL_ALT, LL.MTMD_DT_VALIDADE)\n" +
                            "             FROM TB_MTMD_LOTEST_LOTE_ESTOQUE LL\n" +
                            "             WHERE LL.CAD_MTMD_FILIAL_ID = 1 AND LL.MTMD_COD_LOTE = ESTLOTE.MTMD_COD_LOTE AND\n" +
                            "             LL.CAD_MTMD_ID = ESTLOTE.CAD_MTMD_ID AND ROWNUM = 1)) WHERE ROWNUM = 1";

                DataTable dtb = new DataTable();
                Connection.RecordSet(sqlString, dtb, CommandType.Text);

                if (dtb.Rows.Count > 0)
                {
                    MaterialMedicamentoDTO dtoRetorno = new MaterialMedicamentoDTO();
                    dtoRetorno.Idt.Value = dtb.Rows[0][0].ToString();

                    return new MaterialMedicamento().SelChave(dtoRetorno);
                }
                else
                {   //Se não achou, busca item com saldo mais baixo no Almox.
                    sqlString = "SELECT CAD_MTMD_ID FROM\n" +
                                "(SELECT PRODUTO.CAD_MTMD_ID\n" +
                                "  FROM TB_MTMD_ESTOQUE_LOTE ESTLOTE JOIN\n" +
                                "  TB_CAD_MTMD_MAT_MED PRODUTO ON PRODUTO.CAD_MTMD_ID = ESTLOTE.CAD_MTMD_ID\n" +
                                "  WHERE ESTLOTE.CAD_MTMD_FILIAL_ID = 1\n" +
                                "    AND ESTLOTE.MTMD_EST_QTDE > 0\n" +
                                "    AND ESTLOTE.CAD_SET_ID IN (29)\n" + //Almox. Central
                                "    AND PRODUTO.CAD_MTMD_PRIATI_ID = " + dtoMatMed.IdtPrincipioAtivo.Value + "\n" +
                                "  ORDER BY ESTLOTE.MTMD_EST_QTDE) WHERE ROWNUM = 1";

                    dtb = new DataTable();
                    Connection.RecordSet(sqlString, dtb, CommandType.Text);

                    if (dtb.Rows.Count > 0)
                    {
                        MaterialMedicamentoDTO dtoRetorno = new MaterialMedicamentoDTO();
                        dtoRetorno.Idt.Value = dtb.Rows[0][0].ToString();

                        return new MaterialMedicamento().SelChave(dtoRetorno);
                    }
                    else
                    {
                        MaterialMedicamentoDTO dtoRetorno = new MaterialMedicamentoDTO();
                        dtoRetorno.Idt.Value = dtoMatMed.Idt.Value;

                        return new MaterialMedicamento().SelChave(dtoRetorno);
                    }
                }
            }
            else
            {
                MaterialMedicamentoDTO dtoRetorno = new MaterialMedicamentoDTO();
                dtoRetorno.Idt.Value = dtoMatMed.Idt.Value;

                return new MaterialMedicamento().SelChave(dtoRetorno);
            }
        }

        public EstoqueLocalDataTable KitMateriaisSaldoInsuficiente(RequisicaoDTO dto)
        {
            string query = "SELECT DISTINCT KI.CAD_MTMD_KIT_ID,\n" +
                            "       KI.CAD_MTMD_ID, M.CAD_MTMD_NOMEFANTASIA, KI.CAD_MTMD_QTDE\n" +
                            "  FROM TB_CAD_MTMD_KIT_ITEM KI LEFT JOIN\n" +
                            "       TB_CAD_MTMD_MAT_MED M ON M.CAD_MTMD_ID = KI.CAD_MTMD_ID\n" +
                            "WHERE KI.CAD_MTMD_KIT_ID = @CAD_MTMD_KIT_ID\n" +
                            "  AND M.CAD_MTMD_GRUPO_ID != 1\n" +
                            "  AND NVL(FNC_MTMD_ESTOQUE_UNIDADE(KI.CAD_MTMD_ID,\n" +
                            "                               @CAD_UNI_ID_UNIDADE,\n" +
                            "                               @CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" +
                            "                               @CAD_SET_ID,\n" +
                            "                               1,\n" +
                            "                               NULL),0) < KI.CAD_MTMD_QTDE ORDER BY M.CAD_MTMD_NOMEFANTASIA";

            query = query.Replace("@CAD_UNI_ID_UNIDADE", dto.IdtUnidade.Value);
            query = query.Replace("@CAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.Value);
            query = query.Replace("@CAD_SET_ID", dto.IdtSetor.Value);
            query = query.Replace("@CAD_MTMD_KIT_ID", dto.IdKit.Value);

            EstoqueLocalDataTable result = new EstoqueLocalDataTable();
            Connection.RecordSet(query, result, CommandType.Text);
            return result;
        }

        public EstoqueLocalDataTable MedicamentosVencidos(EstoqueLocalDTO dto)
        {
            string query = "SELECT PROD.CAD_MTMD_ID, PROD.CAD_MTMD_NOMEFANTASIA, MTMD_NUM_LOTE, V.MTMD_DT_VALIDADE\n" +
                            "  FROM (SELECT ESTLOCAL.CAD_MTMD_ID,\n" +
                            "               (SELECT NVL(LL.MTMD_DT_VAL_ALT,  LL.MTMD_DT_VALIDADE)\n" +
                            "                       FROM TB_MTMD_LOTEST_LOTE_ESTOQUE LL\n" +
                            "                      WHERE LL.CAD_MTMD_FILIAL_ID = 1 AND LL.MTMD_COD_LOTE = ESTLOCAL.MTMD_COD_LOTE AND\n" +
                            "                            LL.CAD_MTMD_ID        = ESTLOCAL.CAD_MTMD_ID AND ROWNUM = 1) MTMD_DT_VALIDADE,\n" +
                            "                (SELECT NVL(LL.MTMD_NUM_LOTE_ALT,  LL.MTMD_NUM_LOTE)\n" +
                            "                   FROM TB_MTMD_LOTEST_LOTE_ESTOQUE LL\n" +
                            "                  WHERE LL.CAD_MTMD_FILIAL_ID = 1 AND LL.MTMD_COD_LOTE = ESTLOCAL.MTMD_COD_LOTE AND\n" +
                            "                        LL.CAD_MTMD_ID        = ESTLOCAL.CAD_MTMD_ID AND ROWNUM = 1) MTMD_NUM_LOTE\n" +
                            "           FROM TB_MTMD_ESTOQUE_LOTE ESTLOCAL\n" +
                            "           WHERE ESTLOCAL.CAD_SET_ID         = @CAD_SET_ID\n" +
                            "           AND   ESTLOCAL.CAD_MTMD_FILIAL_ID = @CAD_MTMD_FILIAL_ID\n" +
                            "           AND   ESTLOCAL.MTMD_EST_QTDE > 0) V JOIN\n" +
                            "        TB_CAD_MTMD_MAT_MED PROD ON PROD.CAD_MTMD_ID = V.CAD_MTMD_ID\n" +
                            "WHERE MTMD_DT_VALIDADE < TRUNC(SYSDATE)\n" +
                            "ORDER BY PROD.CAD_MTMD_NOMEFANTASIA, V.MTMD_DT_VALIDADE DESC";
            
            query = query.Replace("@CAD_SET_ID", dto.IdtSetor.Value);
            query = query.Replace("@CAD_MTMD_FILIAL_ID", dto.IdtFilial.Value);

            EstoqueLocalDataTable result = new EstoqueLocalDataTable();
            Connection.RecordSet(query, result, CommandType.Text);
            return result;
        }
    }
}