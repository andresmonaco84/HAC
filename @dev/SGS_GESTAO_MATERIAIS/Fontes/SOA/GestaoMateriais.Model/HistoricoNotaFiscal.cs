
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class HistoricoNotaFiscal : Entity
    {
        public DataTable ObterFornecedoresNF(string nf, byte estoque)
        {
            DataTable result = new DataTable();
            string query =
            "SELECT DISTINCT H.IDMOV, H.DS_FORNECEDOR\n" +
            "  FROM TB_MTMD_HISTORICO_NOTA_FISCAL H\n" +
            " WHERE H.MTMD_NR_NOTA = '" + nf + 
             "' AND CAD_MTMD_FILIAL_ID = " + estoque + 
             " ORDER BY H.DS_FORNECEDOR";
            
            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }

        public DataTable ListarLoteValidade(HistoricoNotaFiscalDTO dto)
        {
            string filtros = string.Empty;
            DataTable result = new DataTable();

            if (!dto.IdtProduto.Value.IsNull)
                filtros += " AND LOTE.CAD_MTMD_ID = " + dto.IdtProduto.Value.ToString() + "\n";

            if (!dto.CodLote.Value.IsNull)
                filtros += " AND LOTE.MTMD_COD_LOTE = '" + dto.CodLote.Value + "'\n";

            if (!dto.NumLote.Value.IsNull)
                filtros += " AND NVL(LOTE.MTMD_NUM_LOTE_ALT, LOTE.MTMD_NUM_LOTE) = '" + dto.NumLote.Value + "'\n";

            if (!dto.IdtLote.Value.IsNull)
                filtros += " AND LOTE.MTMD_LOTEST_ID = " + dto.IdtLote.Value + "\n";

            if (!dto.DataPrcMedio.Value.IsNull && !dto.DataValidadeProduto.Value.IsNull)
            {
                filtros += "AND (NVL(LOTE.MTMD_DT_VAL_ALT, LOTE.MTMD_DT_VALIDADE) >= TO_DATE('" + DateTime.Parse(dto.DataPrcMedio.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')\n" +
                           "AND  NVL(LOTE.MTMD_DT_VAL_ALT, LOTE.MTMD_DT_VALIDADE) <= TO_DATE('" + DateTime.Parse(dto.DataValidadeProduto.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')) ";
            }

            string query = "SELECT PROD.CAD_MTMD_ID,\n" +
                            "       PROD.CAD_MTMD_CODMNE,\n" + 
                            "       PROD.CAD_MTMD_NOMEFANTASIA,\n" +
                            "       LOTE.MTMD_COD_LOTE,\n" +
                            "       NVL(LOTE.MTMD_NUM_LOTE_ALT, LOTE.MTMD_NUM_LOTE) MTMD_NUM_LOTE,\n" +
                            "       NVL(LOTE.MTMD_DT_VAL_ALT, LOTE.MTMD_DT_VALIDADE) MTMD_DT_VALIDADE,\n" + 
                            "       SUM(LOTE.MTMD_QTDE) MTMD_QTDE\n" + 
                            "FROM TB_MTMD_LOTEST_LOTE_ESTOQUE LOTE JOIN\n" + 
                            "     TB_CAD_MTMD_MAT_MED PROD ON PROD.CAD_MTMD_ID = LOTE.CAD_MTMD_ID\n" +
                            "WHERE PROD.CAD_MTMD_FL_ATIVO = 1 AND LOTE.CAD_MTMD_FILIAL_ID = 1 \n" + 
                            "AND PROD.CAD_MTMD_GRUPO_ID = 1\n" + filtros +                             
                            //"AND LOTE.MTMD_DT_VALIDADE IS NOT NULL\n" + 
                            "GROUP BY PROD.CAD_MTMD_ID,\n" + 
                            "         PROD.CAD_MTMD_CODMNE,\n" + 
                            "         PROD.CAD_MTMD_NOMEFANTASIA,\n" +
                            "         LOTE.MTMD_COD_LOTE,\n" +
                            "         NVL(LOTE.MTMD_NUM_LOTE_ALT, LOTE.MTMD_NUM_LOTE),\n" +
                            "         NVL(LOTE.MTMD_DT_VAL_ALT, LOTE.MTMD_DT_VALIDADE)\n" +
                            "ORDER BY NVL(LOTE.MTMD_DT_VAL_ALT, LOTE.MTMD_DT_VALIDADE), PROD.CAD_MTMD_NOMEFANTASIA";

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }

		/// <summary>
        /// Listar todos os registros
        /// </summary>
        public HistoricoNotaFiscalDataTable Sel(HistoricoNotaFiscalDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

			//Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

			//Parametro pCAD_MTMD_FILIAL_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

			//Parametro pMTMD_NR_NOTA
			param.Add(Connection.CreateParameter("pMTMD_NR_NOTA", dto.NrNota.DBValue, ParameterDirection.Input, dto.NrNota.DbType));
            			
			//Parametro pMTMD_DATA_PRC_MEDIO
			param.Add(Connection.CreateParameter("pMTMD_DATA_PRC_MEDIO", dto.DataPrcMedio.DBValue, ParameterDirection.Input, dto.DataPrcMedio.DbType));

            //Parametro pIDMOV
            param.Add(Connection.CreateParameter("pIDMOV", dto.IdMovRM.DBValue, ParameterDirection.Input, dto.IdMovRM.DbType));

            //Parametro pMTMD_LOTEST_ID
            param.Add(Connection.CreateParameter("pMTMD_LOTEST_ID", dto.IdtLote.DBValue, ParameterDirection.Input, dto.IdtLote.DbType));

            //Parametro pMTMD_COD_LOTE
            param.Add(Connection.CreateParameter("pMTMD_COD_LOTE", dto.CodLote.DBValue, ParameterDirection.Input, dto.CodLote.DbType));
			#endregion	
			
			HistoricoNotaFiscalDataTable result = new HistoricoNotaFiscalDataTable();
			string query = "PRC_MTMD_HIST_NOTA_FISCAL_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}		
		
		/// <summary>
        /// Exclui o registro
        /// </summary>        

		public void Del(HistoricoNotaFiscalDTO dto)
		{
  		    #region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pCAD_MTMD_FILIAL_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));
			
			// Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));
			
			// Parametro pMTMD_NR_NOTA
			param.Add(Connection.CreateParameter("pMTMD_NR_NOTA", dto.NrNota.DBValue, ParameterDirection.Input, dto.NrNota.DbType));
			
		
   	       #endregion				
			//Executa o procedimento
            
			string query = "PRC_MTMD_HIST_NOTA_FISCAL_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Altera o registro
        /// </summary>			
		public void Upd(HistoricoNotaFiscalDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));
			
			//Parametro pCAD_MTMD_FILIAL_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));
			
			//Parametro pMTMD_NR_NOTA
			param.Add(Connection.CreateParameter("pMTMD_NR_NOTA", dto.NrNota.DBValue, ParameterDirection.Input, dto.NrNota.DbType));
			
			//Parametro pMTMD_CUSTO_MEDIO
			param.Add(Connection.CreateParameter("pMTMD_CUSTO_MEDIO", dto.CustoMedio.DBValue, ParameterDirection.Input, dto.CustoMedio.DbType));
			
			//Parametro pMTMD_DATA_PRC_MEDIO
			param.Add(Connection.CreateParameter("pMTMD_DATA_PRC_MEDIO", dto.DataPrcMedio.DBValue, ParameterDirection.Input, dto.DataPrcMedio.DbType));
			
			//Parametro pMTMD_QTDE
			param.Add(Connection.CreateParameter("pMTMD_QTDE", dto.Qtde.DBValue, ParameterDirection.Input, dto.Qtde.DbType));
			
			//Parametro pMTMD_PRECO_UNITARIO
			param.Add(Connection.CreateParameter("pMTMD_PRECO_UNITARIO", dto.PrecoUnitario.DBValue, ParameterDirection.Input, dto.PrecoUnitario.DbType));
			
			#endregion	

			string query = "PRC_MTMD_HIST_NOTA_FISCAL_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Inclui o registro
        /// </summary>			
		public void Ins(HistoricoNotaFiscalDTO dto)
		{			
			string query = "PRC_MTMD_HIST_NOTA_FISCAL_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			
			//Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));
			
			//Parametro pCAD_MTMD_FILIAL_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));
			
			//Parametro pMTMD_NR_NOTA
			param.Add(Connection.CreateParameter("pMTMD_NR_NOTA", dto.NrNota.DBValue, ParameterDirection.Input, dto.NrNota.DbType));
			
			//Parametro pMTMD_CUSTO_MEDIO
			param.Add(Connection.CreateParameter("pMTMD_CUSTO_MEDIO", dto.CustoMedio.DBValue, ParameterDirection.Input, dto.CustoMedio.DbType));
			
			//Parametro pMTMD_DATA_PRC_MEDIO
			param.Add(Connection.CreateParameter("pMTMD_DATA_PRC_MEDIO", dto.DataPrcMedio.DBValue, ParameterDirection.Input, dto.DataPrcMedio.DbType));
			
			//Parametro pMTMD_QTDE
			param.Add(Connection.CreateParameter("pMTMD_QTDE", dto.Qtde.DBValue, ParameterDirection.Input, dto.Qtde.DbType));
			
			//Parametro pMTMD_PRECO_UNITARIO
			param.Add(Connection.CreateParameter("pMTMD_PRECO_UNITARIO", dto.PrecoUnitario.DBValue, ParameterDirection.Input, dto.PrecoUnitario.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						

		}

        public void AtualizarValidadeLote(HistoricoNotaFiscalDTO dto)
        {
            string queryExec =  "UPDATE TB_MTMD_LOTEST_LOTE_ESTOQUE SET " +
                                "       MTMD_DT_VAL_ALT = TO_DATE('" + DateTime.Parse(dto.DataValidadeProduto.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')" +
                                " WHERE CAD_MTMD_ID = " + dto.IdtProduto.Value +
                                "   AND MTMD_COD_LOTE = '" + dto.CodLote.Value + "'" +
                                "   AND CAD_MTMD_FILIAL_ID = " + dto.IdtFilial.Value;

            Connection.ExecuteCommand(queryExec);
        }

        public void AtualizarNumeroLote(HistoricoNotaFiscalDTO dto)
        {
            string queryExec = "UPDATE TB_MTMD_LOTEST_LOTE_ESTOQUE SET " +
                                "       MTMD_NUM_LOTE_ALT = '" + dto.NumLote.Value + "'" +
                                " WHERE CAD_MTMD_ID = " + dto.IdtProduto.Value +
                                "   AND MTMD_COD_LOTE = '" + dto.CodLote.Value + "'" +
                                "   AND CAD_MTMD_FILIAL_ID = " + dto.IdtFilial.Value;

            Connection.ExecuteCommand(queryExec);
        }
	}
}