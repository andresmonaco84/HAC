
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.Seguranca.DTO;

namespace HospitalAnaCosta.SGS.Seguranca.Model
{
    public partial class AssPerfilFuncionalidade : Entity
    {			
		/// <summary>
        /// Listar todos os registros
        /// </summary>
        public AssPerfilFuncionalidadeDataTable Sel(AssPerfilFuncionalidadeDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

			//Parametro pSEG_PER_ID_PERFIL
			param.Add(Connection.CreateParameter("pSEG_PER_ID_PERFIL", dto.IdtPerfil.DBValue, ParameterDirection.Input, dto.IdtPerfil.DbType));

			//Parametro pSEG_MOD_ID_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.IdtModulo.DBValue, ParameterDirection.Input, dto.IdtModulo.DbType));

			//Parametro pSEG_FUN_ID_FUNCIONALIDADE
			param.Add(Connection.CreateParameter("pSEG_FUN_ID_FUNCIONALIDADE", dto.IdtFuncionalidade.DBValue, ParameterDirection.Input, dto.IdtFuncionalidade.DbType));
			#endregion	
			
			AssPerfilFuncionalidadeDataTable result = new AssPerfilFuncionalidadeDataTable();
			string query = "PRC_SEG_PERFIL_FUNCIONALID_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
        /// Listar o registro utilizando PK
        /// </summary>
        public AssPerfilFuncionalidadeDTO SelChave(AssPerfilFuncionalidadeDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());
			
			// Parametro pSEG_FUN_ID_FUNCIONALIDADE
			param.Add(Connection.CreateParameter("pSEG_FUN_ID_FUNCIONALIDADE", dto.IdtFuncionalidade.DBValue, ParameterDirection.Input, dto.IdtFuncionalidade.DbType));
			
			// Parametro pSEG_MOD_ID_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.IdtModulo.DBValue, ParameterDirection.Input, dto.IdtModulo.DbType));
			
			// Parametro pSEG_PER_ID_PERFIL
			param.Add(Connection.CreateParameter("pSEG_PER_ID_PERFIL", dto.IdtPerfil.DBValue, ParameterDirection.Input, dto.IdtPerfil.DbType));
			
			
			#endregion	
			
			AssPerfilFuncionalidadeDataTable result = new AssPerfilFuncionalidadeDataTable();
			string query = "PRC_SEG_PERFIL_FUNCIONALID_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
   		    return result.TypedRow(0);
		}

		
		/// <summary>
        /// Exclui o registro
        /// </summary>        

		public void Del(AssPerfilFuncionalidadeDTO dto)
		{
  		    #region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pSEG_FUN_ID_FUNCIONALIDADE
			param.Add(Connection.CreateParameter("pSEG_FUN_ID_FUNCIONALIDADE", dto.IdtFuncionalidade.DBValue, ParameterDirection.Input, dto.IdtFuncionalidade.DbType));
			
			// Parametro pSEG_MOD_ID_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.IdtModulo.DBValue, ParameterDirection.Input, dto.IdtModulo.DbType));
			
			// Parametro pSEG_PER_ID_PERFIL
			param.Add(Connection.CreateParameter("pSEG_PER_ID_PERFIL", dto.IdtPerfil.DBValue, ParameterDirection.Input, dto.IdtPerfil.DbType));
			
		
   	       #endregion				
			//Executa o procedimento
            
			string query = "PRC_SEG_PERFIL_FUNCIONALID_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Altera o registro
        /// </summary>			
		public void Upd(AssPerfilFuncionalidadeDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pSEG_PER_ID_PERFIL
			param.Add(Connection.CreateParameter("pSEG_PER_ID_PERFIL", dto.IdtPerfil.DBValue, ParameterDirection.Input, dto.IdtPerfil.DbType));
			
			//Parametro pSEG_MOD_ID_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.IdtModulo.DBValue, ParameterDirection.Input, dto.IdtModulo.DbType));
			
			//Parametro pSEG_FUN_ID_FUNCIONALIDADE
			param.Add(Connection.CreateParameter("pSEG_FUN_ID_FUNCIONALIDADE", dto.IdtFuncionalidade.DBValue, ParameterDirection.Input, dto.IdtFuncionalidade.DbType));
			
			#endregion	

			string query = "PRC_SEG_PERFIL_FUNCIONALID_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Inclui o registro
        /// </summary>			
		public void Ins(AssPerfilFuncionalidadeDTO dto)
		{			
			string query = "PRC_SEG_PERFIL_FUNCIONALID_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			
			//Parametro pSEG_PER_ID_PERFIL
			param.Add(Connection.CreateParameter("pSEG_PER_ID_PERFIL", dto.IdtPerfil.DBValue, ParameterDirection.Input, dto.IdtPerfil.DbType));
			
			//Parametro pSEG_MOD_ID_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.IdtModulo.DBValue, ParameterDirection.Input, dto.IdtModulo.DbType));
			
			//Parametro pSEG_FUN_ID_FUNCIONALIDADE
			param.Add(Connection.CreateParameter("pSEG_FUN_ID_FUNCIONALIDADE", dto.IdtFuncionalidade.DBValue, ParameterDirection.Input, dto.IdtFuncionalidade.DbType));
            

            // FiltraAssociados fl_associados FL_ASSOCIADOS nodeFiltraAssociados
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						

		}	
	}
}
