
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class LocalEstoque : Entity
    {			
		/// <summary>
        /// Listar todos os registros
        /// </summary>
        public LocalEstoqueDataTable Sel(LocalEstoqueDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

			//Parametro pMTMD_ID_TP_CCUSTO
            param.Add(Connection.CreateParameter("pMTMD_ID_TP_CCUSTO", dto.IdtLocalEstoque.DBValue, ParameterDirection.Input, dto.IdtLocalEstoque.DbType));

			//Parametro pMTMD_DS_TP_CCUSTO
			param.Add(Connection.CreateParameter("pMTMD_DS_TP_CCUSTO", dto.DsLocalEstoque.DBValue, ParameterDirection.Input, dto.DsLocalEstoque.DbType));

			//Parametro pCAD_UNI_ID_UNIDADE
			param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

			//Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
			param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

			//Parametro pCAD_SET_ID
			param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pMTMD_MCCUSTO_ATIVO
            param.Add(Connection.CreateParameter("pMTMD_MCCUSTO_ATIVO", dto.Ativo.DBValue, ParameterDirection.Input, dto.Ativo.DbType));
            
            //Parametro 
            param.Add(Connection.CreateParameter("pMTMD_TIPO_MOV_ENTRADA", dto.TpMovimentacaoEntrada.DBValue, ParameterDirection.Input, dto.TpMovimentacaoEntrada.DbType));


			#endregion	
			
            LocalEstoqueDataTable result = new LocalEstoqueDataTable();
			string query = "PRC_MTMD_MOV_CCUSTO_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
        /// Listar o registro utilizando PK
        /// </summary>
        public LocalEstoqueDTO SelChave(LocalEstoqueDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());
			
			// Parametro pMTMD_ID_TP_CCUSTO
			param.Add(Connection.CreateParameter("pMTMD_ID_TP_CCUSTO", dto.IdtLocalEstoque.DBValue, ParameterDirection.Input, dto.IdtLocalEstoque.DbType));
			
			
			#endregion	
			
            LocalEstoqueDataTable result = new LocalEstoqueDataTable();
			string query = "PRC_MTMD_MOV_CCUSTO_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
   		    return result.TypedRow(0);
		}

		
		/// <summary>
        /// Exclui o registro
        /// </summary>        

        public void Del(LocalEstoqueDTO dto)
		{
  		    #region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pMTMD_ID_TP_CCUSTO
			param.Add(Connection.CreateParameter("pMTMD_ID_TP_CCUSTO", dto.IdtLocalEstoque.DBValue, ParameterDirection.Input, dto.IdtLocalEstoque.DbType));
			
		
   	       #endregion				
			//Executa o procedimento
            
			string query = "PRC_MTMD_MOV_CCUSTO_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Altera o registro
        /// </summary>			
        public void Upd(LocalEstoqueDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pMTMD_ID_TP_CCUSTO
			param.Add(Connection.CreateParameter("pMTMD_ID_TP_CCUSTO", dto.IdtLocalEstoque.DBValue, ParameterDirection.Input, dto.IdtLocalEstoque.DbType));
			
			//Parametro pMTMD_DS_TP_CCUSTO
			param.Add(Connection.CreateParameter("pMTMD_DS_TP_CCUSTO", dto.DsLocalEstoque.DBValue, ParameterDirection.Input, dto.DsLocalEstoque.DbType));
			
			//Parametro pCAD_UNI_ID_UNIDADE
			param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));
			
			//Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
			param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));
			
			//Parametro pCAD_SET_ID
			param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pMTMD_MCCUSTO_ATIVO
            param.Add(Connection.CreateParameter("pMTMD_MCCUSTO_ATIVO", dto.Ativo.DBValue, ParameterDirection.Input, dto.Ativo.DbType));

            //Parametro 
            param.Add(Connection.CreateParameter("pMTMD_TIPO_MOV_ENTRADA", dto.TpMovimentacaoEntrada.DBValue, ParameterDirection.Input, dto.TpMovimentacaoEntrada.DbType));


			#endregion	

			string query = "PRC_MTMD_MOV_CCUSTO_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Inclui o registro
        /// </summary>			
        public void Ins(LocalEstoqueDTO dto)
		{			
			string query = "PRC_MTMD_MOV_CCUSTO_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
						
			//Parametro pMTMD_DS_TP_CCUSTO
			param.Add(Connection.CreateParameter("pMTMD_DS_TP_CCUSTO", dto.DsLocalEstoque.DBValue, ParameterDirection.Input, dto.DsLocalEstoque.DbType));
			
			//Parametro pCAD_UNI_ID_UNIDADE
			param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));
			
			//Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
			param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));
			
			//Parametro pCAD_SET_ID
			param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pMTMD_MCCUSTO_ATIVO
            param.Add(Connection.CreateParameter("pMTMD_MCCUSTO_ATIVO", dto.Ativo.DBValue, ParameterDirection.Input, dto.Ativo.DbType));

            //Parametro 
            param.Add(Connection.CreateParameter("pMTMD_TIPO_MOV_ENTRADA", dto.TpMovimentacaoEntrada.DBValue, ParameterDirection.Input, dto.TpMovimentacaoEntrada.DbType));


            param.Add(Connection.CreateParameterSequence());
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
            dto.IdtLocalEstoque.Value = Int32.Parse(param["pNewIdt"].Value.ToString());

		}

        public LocalEstoqueDataTable EstoqueUsuario(LocalEstoqueDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pMTMD_ID_TP_CCUSTO  É O ID DO USUARIO TEM QUE ARRUMAR
            param.Add(Connection.CreateParameter("pMTMD_ID_TP_CCUSTO", dto.IdtLocalEstoque.DBValue, ParameterDirection.Input, dto.IdtLocalEstoque.DbType));


            #endregion

            LocalEstoqueDataTable result = new LocalEstoqueDataTable();
            string query = "PRC_MTMD_MOV_CUSTO_USUARIO_S";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }
	}
}
