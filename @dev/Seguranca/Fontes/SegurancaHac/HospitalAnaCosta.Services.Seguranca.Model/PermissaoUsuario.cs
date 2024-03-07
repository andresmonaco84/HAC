
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.Services.Seguranca.DTO;

namespace HospitalAnaCosta.Services.Seguranca.Model
{
	public partial class PermissaoUsuario : Entity
	{			
		/// <summary>
		/// Listar todos os registros
		/// </summary>
		public PermissaoUsuarioDataTable Listar(PermissaoUsuarioDTO dto)
		{            
			#region "Parametros"
			DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
			param.Add(Connection.CreateParameterCursor());

			//Parametro pSEG_PER_ID_PERFIL
			param.Add(Connection.CreateParameter("pSEG_PER_ID_PERFIL", dto.IdtPerfil.DBValue, ParameterDirection.Input, dto.IdtPerfil.DbType));

			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));

			//Parametro pCAD_UNI_ID_UNIDADE
			param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

			//Parametro pSEG_MOD_ID_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.IdtModulo.DBValue, ParameterDirection.Input, dto.IdtModulo.DbType));
			#endregion	
			
			PermissaoUsuarioDataTable result = new PermissaoUsuarioDataTable();
			string query = "PRC_SEG_PEU_PERMISSAO_USU_R_L";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
		/// Listar o registro utilizando PK
		/// </summary>
		public PermissaoUsuarioDTO Pesquisar(PermissaoUsuarioDTO dto)
		{            
			#region "Parametros"
			DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
			param.Add(Connection.CreateParameterCursor());
			
			// Parametro pCAD_UNI_ID_UNIDADE
			param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));
			
			// Parametro pSEG_MOD_ID_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.IdtModulo.DBValue, ParameterDirection.Input, dto.IdtModulo.DbType));
			
			// Parametro pSEG_PER_ID_PERFIL
			param.Add(Connection.CreateParameter("pSEG_PER_ID_PERFIL", dto.IdtPerfil.DBValue, ParameterDirection.Input, dto.IdtPerfil.DbType));
			
			// Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));
			
			
			#endregion	
			
			PermissaoUsuarioDataTable result = new PermissaoUsuarioDataTable();
			string query = "PRC_SEG_PEU_PERMISSAO_USU_R_S";
			
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

		public void Excluir(PermissaoUsuarioDTO dto)
		{
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pCAD_UNI_ID_UNIDADE
			param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));
			
			// Parametro pSEG_MOD_ID_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.IdtModulo.DBValue, ParameterDirection.Input, dto.IdtModulo.DbType));
			
			// Parametro pSEG_PER_ID_PERFIL
			param.Add(Connection.CreateParameter("pSEG_PER_ID_PERFIL", dto.IdtPerfil.DBValue, ParameterDirection.Input, dto.IdtPerfil.DbType));
			
			// Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));
			
		
		   #endregion				
			//Executa o procedimento
			
			string query = "PRC_SEG_PEU_PERMISSAO_USU_R_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
		/// Inclui o registro
		/// </summary>			
		public void Incluir(PermissaoUsuarioDTO dto)
		{			
			string query = "PRC_SEG_PEU_PERMISSAO_USU_R_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			
			//Parametro pSEG_PER_ID_PERFIL
			param.Add(Connection.CreateParameter("pSEG_PER_ID_PERFIL", dto.IdtPerfil.DBValue, ParameterDirection.Input, dto.IdtPerfil.DbType));
			
			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));
			
			//Parametro pCAD_UNI_ID_UNIDADE
			param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));
			
			//Parametro pSEG_MOD_ID_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.IdtModulo.DBValue, ParameterDirection.Input, dto.IdtModulo.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						

		}	
	}
}
