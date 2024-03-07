
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.Services.Seguranca.DTO;

namespace HospitalAnaCosta.Services.Seguranca.Model
{
	public partial class PerfilFuncionalidade : Entity
	{			
		/// <summary>
		/// Listar todos os registros
		/// </summary>
		public PerfilFuncionalidadeDataTable Listar(PerfilFuncionalidadeDTO dto)
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
			
			PerfilFuncionalidadeDataTable result = new PerfilFuncionalidadeDataTable();
            string query = "PRC_SEG_PFU_PERFIL_FUNC_R_L";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
		/// Listar o registro utilizando PK
		/// </summary>
		public PerfilFuncionalidadeDTO Pesquisar(PerfilFuncionalidadeDTO dto)
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
			
			PerfilFuncionalidadeDataTable result = new PerfilFuncionalidadeDataTable();
            string query = "PRC_SEG_PFU_PERFIL_FUNC_R_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			if (result.Rows.Count > 0)
				return result.TypedRow(0);
			else
				return null;
		}

		
		/// <summary>
		/// Exclui o registro
		/// </summary>        

		public void Excluir(PerfilFuncionalidadeDTO dto)
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

            string query = "PRC_SEG_PFU_PERFIL_FUNC_R_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
		/// Inclui o registro
		/// </summary>			
		public void Incluir(PerfilFuncionalidadeDTO dto)
		{
            string query = "PRC_SEG_PFU_PERFIL_FUNC_R_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			
			//Parametro pSEG_PER_ID_PERFIL
			param.Add(Connection.CreateParameter("pSEG_PER_ID_PERFIL", dto.IdtPerfil.DBValue, ParameterDirection.Input, dto.IdtPerfil.DbType));
			
			//Parametro pSEG_MOD_ID_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.IdtModulo.DBValue, ParameterDirection.Input, dto.IdtModulo.DbType));
			
			//Parametro pSEG_FUN_ID_FUNCIONALIDADE
			param.Add(Connection.CreateParameter("pSEG_FUN_ID_FUNCIONALIDADE", dto.IdtFuncionalidade.DBValue, ParameterDirection.Input, dto.IdtFuncionalidade.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						

		}	
	}
}
