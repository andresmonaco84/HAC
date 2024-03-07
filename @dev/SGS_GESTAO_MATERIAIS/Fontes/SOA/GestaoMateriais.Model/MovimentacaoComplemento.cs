
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class MovimentacaoComplemento : Entity
    {			
		/// <summary>
        /// Listar todos os registros
        /// </summary>
        public MovimentacaoComplementoDataTable Sel(MovimentacaoComplementoDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

			//Parametro pMTMD_MOV_ID
			param.Add(Connection.CreateParameter("pMTMD_MOV_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

			//Parametro pMTMD_MOV_OBS
			param.Add(Connection.CreateParameter("pMTMD_MOV_OBS", dto.Obs.DBValue, ParameterDirection.Input, dto.Obs.DbType));

			//Parametro pMTMD_MOV_USU_RELATADO
			param.Add(Connection.CreateParameter("pMTMD_MOV_USU_RELATADO", dto.UsuarioRelatado.DBValue, ParameterDirection.Input, dto.UsuarioRelatado.DbType));

            //Parametro pMTMD_ID_TP_CCUSTO
            param.Add(Connection.CreateParameter("pMTMD_ID_TP_CCUSTO", dto.IdtLocalEstoque.DBValue, ParameterDirection.Input, dto.IdtLocalEstoque.DbType));

			#endregion	
			
			MovimentacaoComplementoDataTable result = new MovimentacaoComplementoDataTable();
			string query = "PRC_MTMD_MOV_COMPLEMENTO_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
        /// Listar o registro utilizando PK
        /// </summary>
        public MovimentacaoComplementoDTO SelChave(MovimentacaoComplementoDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());
			
			// Parametro pMTMD_MOV_ID
			param.Add(Connection.CreateParameter("pMTMD_MOV_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			
			#endregion	
			
			MovimentacaoComplementoDataTable result = new MovimentacaoComplementoDataTable();
			string query = "PRC_MTMD_MOV_COMPLEMENTO_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
   		    return result.TypedRow(0);
		}

        /// <summary>
        /// Registra Divergencia
        /// </summary>
        /// <param name="dto"></param>
        public void RegistrarDivergencia(MovimentacaoComplementoDTO dto, MovimentacaoDTO dtoMov)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pMTMD_MOV_ID
            param.Add(Connection.CreateParameter("pMTMD_MOV_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pMTMD_MOV_OBS
            param.Add(Connection.CreateParameter("pMTMD_MOV_OBS", dto.Obs.DBValue, ParameterDirection.Input, dto.Obs.DbType));

            //Parametro pMTMD_MOV_USU_RELATADO
            param.Add(Connection.CreateParameter("pMTMD_MOV_USU_RELATADO", dto.UsuarioRelatado.DBValue, ParameterDirection.Input, dto.UsuarioRelatado.DbType));

            //Parametro pMTMD_MOV_FL_FINALIZADO
            param.Add(Connection.CreateParameter("pMTMD_MOV_FL_FINALIZADO", dtoMov.FlFinalizado.DBValue, ParameterDirection.Input, dtoMov.FlFinalizado.DbType));

            #endregion

            string query = "PRC_MTMD_MOV_REG_DIVERGENCIA";

            //Executa o procedimento
            MovimentacaoDataTable result = new MovimentacaoDataTable();
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
        }
		
		/// <summary>
        /// Exclui o registro
        /// </summary>        
		public void Del(MovimentacaoComplementoDTO dto)
		{
  		    #region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pMTMD_MOV_ID
			param.Add(Connection.CreateParameter("pMTMD_MOV_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
		
   	       #endregion				
			//Executa o procedimento
            
			string query = "PRC_MTMD_MOV_COMPLEMENTO_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Altera o registro
        /// </summary>			
		public void Upd(MovimentacaoComplementoDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pMTMD_MOV_ID
			param.Add(Connection.CreateParameter("pMTMD_MOV_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pMTMD_MOV_OBS
			param.Add(Connection.CreateParameter("pMTMD_MOV_OBS", dto.Obs.DBValue, ParameterDirection.Input, dto.Obs.DbType));
			
			//Parametro pMTMD_MOV_USU_RELATADO
			param.Add(Connection.CreateParameter("pMTMD_MOV_USU_RELATADO", dto.UsuarioRelatado.DBValue, ParameterDirection.Input, dto.UsuarioRelatado.DbType));

            //Parametro pMTMD_ID_TP_CCUSTO
            param.Add(Connection.CreateParameter("pMTMD_ID_TP_CCUSTO", dto.IdtLocalEstoque.DBValue, ParameterDirection.Input, dto.IdtLocalEstoque.DbType));
			
			#endregion	

			string query = "PRC_MTMD_MOV_COMPLEMENTO_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Inclui o registro
        /// </summary>			
		public void Ins(MovimentacaoComplementoDTO dto)
		{			
			string query = "PRC_MTMD_MOV_COMPLEMENTO_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			
			//Parametro pMTMD_MOV_ID
			param.Add(Connection.CreateParameter("pMTMD_MOV_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pMTMD_MOV_OBS
			param.Add(Connection.CreateParameter("pMTMD_MOV_OBS", dto.Obs.DBValue, ParameterDirection.Input, dto.Obs.DbType));
			
			//Parametro pMTMD_MOV_USU_RELATADO
			param.Add(Connection.CreateParameter("pMTMD_MOV_USU_RELATADO", dto.UsuarioRelatado.DBValue, ParameterDirection.Input, dto.UsuarioRelatado.DbType));

            //Parametro pMTMD_ID_TP_CCUSTO
            param.Add(Connection.CreateParameter("pMTMD_ID_TP_CCUSTO", dto.IdtLocalEstoque.DBValue, ParameterDirection.Input, dto.IdtLocalEstoque.DbType));

            //Parametro 
            param.Add(Connection.CreateParameter("pMTMD_ID_MOTIVO", dto.idtMotivo.DBValue, ParameterDirection.Input, dto.idtMotivo.DbType));

			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						

		}	
	}
}
