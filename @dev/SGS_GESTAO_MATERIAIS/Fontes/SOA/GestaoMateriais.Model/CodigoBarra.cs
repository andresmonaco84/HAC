
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
// using Oracle.DataAccess.Client;
using HospitalAnaCosta.Framework;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class CodigoBarra : Entity
    {
        public CodigoBarraDataTable SelMedicamentoSemNF(HistoricoNotaFiscalDTO dtoHNF, decimal idUsuario, decimal idSetorMov)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dtoHNF.IdtProduto.DBValue, ParameterDirection.Input, dtoHNF.IdtProduto.DbType));

            //Parametro pMTMD_NUM_LOTE
            param.Add(Connection.CreateParameter("pMTMD_NUM_LOTE", dtoHNF.NumLote.DBValue, ParameterDirection.Input, dtoHNF.NumLote.DbType));

            //Parametro pMTMD_DT_VALIDADE
            param.Add(Connection.CreateParameter("pMTMD_DT_VALIDADE", dtoHNF.DataValidadeProduto.DBValue, ParameterDirection.Input, dtoHNF.DataValidadeProduto.DbType));

            //Parametro pSEG_ID_USUARIO_IMPRESSAO
            param.Add(Connection.CreateParameter("pSEG_ID_USUARIO_IMPRESSAO", idUsuario, ParameterDirection.Input, DbType.Decimal));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", idSetorMov, ParameterDirection.Input, DbType.Decimal));

            //Parametro pMTMD_QTDE
            if (!dtoHNF.Qtde.Value.IsNull)
                param.Add(Connection.CreateParameter("pMTMD_QTDE", dtoHNF.Qtde.DBValue, ParameterDirection.Input, dtoHNF.Qtde.DbType));

            //Parametro pCAD_MTMD_SUBTP_ID
            if (!dtoHNF.TpMovimento.Value.IsNull)
                param.Add(Connection.CreateParameter("pCAD_MTMD_SUBTP_ID", dtoHNF.TpMovimento.DBValue, ParameterDirection.Input, new MovimentacaoDTO().IdtSubTipo.DbType));

            //Parametro pID_EMP_EMPRESTIMO
            if (!dtoHNF.IdtFilial.Value.IsNull)
                param.Add(Connection.CreateParameter("pID_EMP_EMPRESTIMO", dtoHNF.IdtFilial.DBValue, ParameterDirection.Input, dtoHNF.IdtFilial.DbType));
            #endregion

            CodigoBarraDataTable result = new CodigoBarraDataTable();
            string query = "PRC_ASS_MTMD_COD_BARRA_SEM_NF";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }

        /// <summary>
        /// Listar o cod. barra avulso
        /// </summary>
        public CodigoBarraDTO SelAvulso(CodigoBarraDTO dto, decimal idUsuario)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            //Parametro pSEG_ID_USUARIO_IMPRESSAO
            param.Add(Connection.CreateParameter("pSEG_ID_USUARIO_IMPRESSAO", idUsuario, ParameterDirection.Input, DbType.Decimal));
            #endregion

            CodigoBarraDataTable result = new CodigoBarraDataTable();
            string query = "PRC_ASS_MTMD_COD_BARRA_AVULSO";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result.TypedRow(0); 
        }

		/// <summary>
        /// Listar todos os registros
        /// </summary>
        public CodigoBarraDataTable Sel(CodigoBarraDTO dto, decimal? idUsuario)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

			//Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

			//Parametro pCAD_MTMD_FILIAL_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

			//Parametro pMTMD_LOTEST_ID
			param.Add(Connection.CreateParameter("pMTMD_LOTEST_ID", dto.IdtLote.DBValue, ParameterDirection.Input, dto.IdtLote.DbType));

			//Parametro pMTM_CD_BARRA
			param.Add(Connection.CreateParameter("pMTM_CD_BARRA", dto.CdBarra.DBValue, ParameterDirection.Input, dto.CdBarra.DbType));

            //Parametro pSEG_ID_USUARIO_IMPRESSAO
            if (idUsuario != null)
                param.Add(Connection.CreateParameter("pSEG_ID_USUARIO_IMPRESSAO", idUsuario.Value, ParameterDirection.Input, DbType.Decimal));
			#endregion	
			
			CodigoBarraDataTable result = new CodigoBarraDataTable();
			string query = "PRC_ASS_MTMD_CODIGO_BARRA_S";
			
			//Executa o procedimento 
            try
            {
                Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                // throw new HacException(ex.Errors[0].Message, ex);
                throw new HacException(ex.Message);
            }
			return result;
		}		
		
		/// <summary>
        /// Exclui o registro
        /// </summary>        
		public void Del(CodigoBarraDTO dto)
		{
  		    #region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            //Parametro pMTMD_LOTEST_ID
            param.Add(Connection.CreateParameter("pMTMD_LOTEST_ID", dto.IdtLote.DBValue, ParameterDirection.Input, dto.IdtLote.DbType));
		
   	        #endregion				
			//Executa o procedimento
            
			string query = "PRC_ASS_MTMD_CODIGO_BARRA_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Altera o registro
        /// </summary>			
		public void Upd(CodigoBarraDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));
			
			//Parametro pCAD_MTMD_FILIAL_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));
			
			//Parametro pMTMD_LOTEST_ID
			param.Add(Connection.CreateParameter("pMTMD_LOTEST_ID", dto.IdtLote.DBValue, ParameterDirection.Input, dto.IdtLote.DbType));
			
			//Parametro pMTM_CD_BARRA
			param.Add(Connection.CreateParameter("pMTM_CD_BARRA", dto.CdBarra.DBValue, ParameterDirection.Input, dto.CdBarra.DbType));
			
			#endregion	

			string query = "PRC_ASS_MTMD_CODIGO_BARRA_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Inclui o registro
        /// </summary>			
		public void Ins(CodigoBarraDTO dto)
		{			
			string query = "PRC_ASS_MTMD_CODIGO_BARRA_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			
			//Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));
			
			//Parametro pCAD_MTMD_FILIAL_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));
			
			//Parametro pMTMD_LOTEST_ID
			param.Add(Connection.CreateParameter("pMTMD_LOTEST_ID", dto.IdtLote.DBValue, ParameterDirection.Input, dto.IdtLote.DbType));
			
			//Parametro pMTM_CD_BARRA
			param.Add(Connection.CreateParameter("pMTM_CD_BARRA", dto.CdBarra.DBValue, ParameterDirection.Input, dto.CdBarra.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						

		}

        /// <summary>
        /// Caso não possua cod. barra, retorna próprio ID
        /// </summary>
        /// <param name="idFilial"></param>
        /// <param name="idProduto"></param>
        /// <returns></returns>
        public string ObterCodigo(decimal idFilial, decimal idProduto)
        {
            DataTable result = new DataTable();
            string sqlString = "SELECT MTM_CD_BARRA\n" +
                               "  FROM TB_ASS_MTMD_CODIGO_BARRA\n" +
                               "  WHERE ROWNUM = 1 AND CAD_MTMD_ID = " + idProduto.ToString() + " AND\n" +
                               "        CAD_MTMD_FILIAL_ID = " + idFilial.ToString();

            //Executa o procedimento
            Connection.RecordSet(sqlString, result, CommandType.Text);

            if (result.Rows.Count == 0)
                return idProduto.ToString();
            else
                return result.Rows[0][0].ToString();
        }
	}
}
