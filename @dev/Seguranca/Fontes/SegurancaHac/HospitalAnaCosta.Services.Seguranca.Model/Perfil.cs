
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.Services.Seguranca.DTO;

namespace HospitalAnaCosta.Services.Seguranca.Model
{
	public partial class Perfil : Entity
	{			
		/// <summary>
		/// Listar todos os registros
		/// </summary>
		public PerfilDataTable Listar(PerfilDTO dto)
		{            
			#region "Parametros"
			DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
			param.Add(Connection.CreateParameterCursor());

			//Parametro pSEG_PER_ID_PERFIL
			param.Add(Connection.CreateParameter("pSEG_PER_ID_PERFIL", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

			//Parametro pSEG_PER_NM_PERFIL
			param.Add(Connection.CreateParameter("pSEG_PER_NM_PERFIL", dto.Nome.DBValue, ParameterDirection.Input, dto.Nome.DbType));

			//Parametro pSEG_PER_FL_STATUS
			param.Add(Connection.CreateParameter("pSEG_PER_FL_STATUS", dto.FlagStatus.DBValue, ParameterDirection.Input, dto.FlagStatus.DbType));

			//Parametro pSEG_PER_DT_ULTIMA_ATUALIZACAO
			param.Add(Connection.CreateParameter("pSEG_PER_DT_ULTIMA_ATUALIZACAO", dto.DataAtualizacao.DBValue, ParameterDirection.Input, dto.DataAtualizacao.DbType));

			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));
			#endregion	
			
			PerfilDataTable result = new PerfilDataTable();
			string query = "PRC_SEG_PER_PERFIL_R_L";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
		/// Listar o registro utilizando PK
		/// </summary>
		public PerfilDTO Pesquisar(PerfilDTO dto)
		{            
			#region "Parametros"
			DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
			param.Add(Connection.CreateParameterCursor());
			
			// Parametro pSEG_PER_ID_PERFIL
			param.Add(Connection.CreateParameter("pSEG_PER_ID_PERFIL", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			
			#endregion	
			
			PerfilDataTable result = new PerfilDataTable();
			string query = "PRC_SEG_PER_PERFIL_R_S";
			
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

		public void Excluir(PerfilDTO dto)
		{
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pSEG_PER_ID_PERFIL
			param.Add(Connection.CreateParameter("pSEG_PER_ID_PERFIL", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
		
		   #endregion				
			//Executa o procedimento
			
			string query = "PRC_SEG_PER_PERFIL_R_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
		/// Altera o registro
		/// </summary>			
		public void Alterar(PerfilDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pSEG_PER_ID_PERFIL
			param.Add(Connection.CreateParameter("pSEG_PER_ID_PERFIL", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pSEG_PER_NM_PERFIL
			param.Add(Connection.CreateParameter("pSEG_PER_NM_PERFIL", dto.Nome.DBValue, ParameterDirection.Input, dto.Nome.DbType));
			
			//Parametro pSEG_PER_FL_STATUS
			param.Add(Connection.CreateParameter("pSEG_PER_FL_STATUS", dto.FlagStatus.DBValue, ParameterDirection.Input, dto.FlagStatus.DbType));
			
			//Parametro pSEG_PER_DT_ULTIMA_ATUALIZACAO
			param.Add(Connection.CreateParameter("pSEG_PER_DT_ULTIMA_ATUALIZACAO", dto.DataAtualizacao.DBValue, ParameterDirection.Input, dto.DataAtualizacao.DbType));
			
			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));
			
			#endregion	

			string query = "PRC_SEG_PER_PERFIL_R_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
		/// Inclui o registro
		/// </summary>			
		public void Incluir(PerfilDTO dto)
		{			
			string query = "PRC_SEG_PER_PERFIL_R_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro Sequence			
			param.Add(Connection.CreateParameterSequence());
			
			
			//Parametro pSEG_PER_ID_PERFIL
			param.Add(Connection.CreateParameter("pSEG_PER_ID_PERFIL", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pSEG_PER_NM_PERFIL
			param.Add(Connection.CreateParameter("pSEG_PER_NM_PERFIL", dto.Nome.DBValue, ParameterDirection.Input, dto.Nome.DbType));
			
			//Parametro pSEG_PER_FL_STATUS
			param.Add(Connection.CreateParameter("pSEG_PER_FL_STATUS", dto.FlagStatus.DBValue, ParameterDirection.Input, dto.FlagStatus.DbType));
			
			//Parametro pSEG_PER_DT_ULTIMA_ATUALIZACAO
			param.Add(Connection.CreateParameter("pSEG_PER_DT_ULTIMA_ATUALIZACAO", dto.DataAtualizacao.DBValue, ParameterDirection.Input, dto.DataAtualizacao.DbType));
			
			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						
				
			//Recupera o valor da Sequence utilizado na procedure     
			
						
			   dto.Idt.Value = Int32.Parse(param["pNewIdt"].Value.ToString());
			

		}	
	}
}
