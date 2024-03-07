
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class MatMedFuncionalidade : Entity
    {			
		/// <summary>
        /// Listar todos os registros
        /// </summary>
        public MatMedFuncionalidadeDataTable Sel(MatMedFuncionalidadeDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

			//Parametro pSEG_FUN_ID_FUNCIONALIDADE
			param.Add(Connection.CreateParameter("pSEG_FUN_ID_FUNCIONALIDADE", dto.IdFuncionalidade.DBValue, ParameterDirection.Input, dto.IdFuncionalidade.DbType));

			//Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdProduto.DBValue, ParameterDirection.Input, dto.IdProduto.DbType));

			//Parametro pMTMD_DT_ATUALIZACAO
			param.Add(Connection.CreateParameter("pMTMD_DT_ATUALIZACAO", dto.DataAtualizacao.DBValue, ParameterDirection.Input, dto.DataAtualizacao.DbType));

			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdUsuario.DBValue, ParameterDirection.Input, dto.IdUsuario.DbType));

            //Parametro pCAD_MTMD_NOMEFANTASIA
            param.Add(Connection.CreateParameter("pCAD_MTMD_NOMEFANTASIA", dto.NomeFantasia.DBValue, ParameterDirection.Input, dto.NomeFantasia.DbType));
			#endregion	
			
			MatMedFuncionalidadeDataTable result = new MatMedFuncionalidadeDataTable();
			string query = "PRC_MTMD_MATMED_FUNC_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
        /// Listar o registro utilizando PK
        /// </summary>
        public MatMedFuncionalidadeDTO SelChave(MatMedFuncionalidadeDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());
			
			// Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdProduto.DBValue, ParameterDirection.Input, dto.IdProduto.DbType));
			
			// Parametro pSEG_FUN_ID_FUNCIONALIDADE
			param.Add(Connection.CreateParameter("pSEG_FUN_ID_FUNCIONALIDADE", dto.IdFuncionalidade.DBValue, ParameterDirection.Input, dto.IdFuncionalidade.DbType));
			
			
			#endregion	
			
			MatMedFuncionalidadeDataTable result = new MatMedFuncionalidadeDataTable();
			string query = "PRC_MTMD_MATMED_FUNC_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
   		    return result.TypedRow(0);
		}
		
		/// <summary>
        /// Exclui o registro
        /// </summary>        
		public void Del(MatMedFuncionalidadeDTO dto)
		{
  		    #region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdProduto.DBValue, ParameterDirection.Input, dto.IdProduto.DbType));
			
			// Parametro pSEG_FUN_ID_FUNCIONALIDADE
			param.Add(Connection.CreateParameter("pSEG_FUN_ID_FUNCIONALIDADE", dto.IdFuncionalidade.DBValue, ParameterDirection.Input, dto.IdFuncionalidade.DbType));
			
		
   	       #endregion				
			//Executa o procedimento
            
			string query = "PRC_MTMD_MATMED_FUNC_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
						
		/// <summary>
        /// Inclui o registro
        /// </summary>			
		public void Ins(MatMedFuncionalidadeDTO dto)
		{			
			string query = "PRC_MTMD_MATMED_FUNC_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			
			//Parametro pSEG_FUN_ID_FUNCIONALIDADE
			param.Add(Connection.CreateParameter("pSEG_FUN_ID_FUNCIONALIDADE", dto.IdFuncionalidade.DBValue, ParameterDirection.Input, dto.IdFuncionalidade.DbType));
			
			//Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdProduto.DBValue, ParameterDirection.Input, dto.IdProduto.DbType));			
			
			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdUsuario.DBValue, ParameterDirection.Input, dto.IdUsuario.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						

		}

        public void Atualizar(MatMedFuncionalidadeDTO dto)
        {
            DataTable result = new DataTable();
            string query = "UPDATE TB_MTMD_MATMED_FUNC SET QTDE_MAXIMA_PEDIDO = " + (dto.QtdeMaximaPedido.Value.IsNull ? "NULL" : dto.QtdeMaximaPedido.Value.ToString())
                         + ", MTMD_DT_ATUALIZACAO = SYSDATE " 
                         + ", SEG_USU_ID_USUARIO = " + dto.IdUsuario.Value
                         + " WHERE SEG_FUN_ID_FUNCIONALIDADE = " + dto.IdFuncionalidade.Value
                         + " AND   CAD_MTMD_ID = " + dto.IdProduto.Value;

            Connection.ExecuteCommand(query);
        }
	}
}