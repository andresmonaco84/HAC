
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.Services.Seguranca.DTO;

namespace HospitalAnaCosta.Services.Seguranca.Model
{
	public partial class UnidadeLocalSetorUsuario : Entity
	{			
		/// <summary>
		/// Listar todos os registros
		/// </summary>
		public UnidadeLocalSetorUsuarioDataTable Listar(UnidadeLocalSetorUsuarioDTO dto)
		{            
			#region "Parametros"
			DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
			param.Add(Connection.CreateParameterCursor());

			//Parametro pASS_ULS_ID
			param.Add(Connection.CreateParameter("pASS_ULS_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));

			//Parametro pCAD_UNI_ID_UNIDADE
			param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

			//Parametro pCAD_SET_ID
			param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

			//Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
			param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocalAtendimento.DBValue, ParameterDirection.Input, dto.IdtLocalAtendimento.DbType));

			//Parametro pASS_ULS_FL_STATUS
			param.Add(Connection.CreateParameter("pASS_ULS_FL_STATUS", dto.FlagStatus.DBValue, ParameterDirection.Input, dto.FlagStatus.DbType));

			//Parametro pASS_DT_ULTIMA_ATUALIZACAO
			param.Add(Connection.CreateParameter("pASS_DT_ULTIMA_ATUALIZACAO", dto.DataUltimaAtualizacao.DBValue, ParameterDirection.Input, dto.DataUltimaAtualizacao.DbType));

			//Parametro pASS_ULS_ID_USUARIO
			param.Add(Connection.CreateParameter("pASS_ULS_ID_USUARIO", dto.IdtUsuarioAtualizadoPor.DBValue, ParameterDirection.Input, dto.IdtUsuarioAtualizadoPor.DbType));
			#endregion	
			
			UnidadeLocalSetorUsuarioDataTable result = new UnidadeLocalSetorUsuarioDataTable();
			string query = "PRC_ASS_ULS_UN_LO_SE_USU_R_L";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
		/// Listar o registro utilizando PK
		/// </summary>
		public UnidadeLocalSetorUsuarioDTO Pesquisar(UnidadeLocalSetorUsuarioDTO dto)
		{            
			#region "Parametros"
			DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
			param.Add(Connection.CreateParameterCursor());
			
			// Parametro pASS_ULS_ID
			param.Add(Connection.CreateParameter("pASS_ULS_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			
			#endregion	
			
			UnidadeLocalSetorUsuarioDataTable result = new UnidadeLocalSetorUsuarioDataTable();
			string query = "PRC_ASS_ULS_UN_LO_SE_USU_R_S";
			
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

		public void Excluir(UnidadeLocalSetorUsuarioDTO dto)
		{
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pASS_ULS_ID
			param.Add(Connection.CreateParameter("pASS_ULS_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
		
		   #endregion				
			//Executa o procedimento
			
			string query = "PRC_ASS_ULS_UN_LO_SE_USU_R_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
		/// Altera o registro
		/// </summary>			
		public void Alterar(UnidadeLocalSetorUsuarioDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pASS_ULS_ID
			param.Add(Connection.CreateParameter("pASS_ULS_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));
			
			//Parametro pCAD_UNI_ID_UNIDADE
			param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));
			
			//Parametro pCAD_SET_ID
			param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));
			
			//Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
			param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocalAtendimento.DBValue, ParameterDirection.Input, dto.IdtLocalAtendimento.DbType));
			
			//Parametro pASS_ULS_FL_STATUS
			param.Add(Connection.CreateParameter("pASS_ULS_FL_STATUS", dto.FlagStatus.DBValue, ParameterDirection.Input, dto.FlagStatus.DbType));
			
			//Parametro pASS_DT_ULTIMA_ATUALIZACAO
			param.Add(Connection.CreateParameter("pASS_DT_ULTIMA_ATUALIZACAO", dto.DataUltimaAtualizacao.DBValue, ParameterDirection.Input, dto.DataUltimaAtualizacao.DbType));
			
			//Parametro pASS_ULS_ID_USUARIO
			param.Add(Connection.CreateParameter("pASS_ULS_ID_USUARIO", dto.IdtUsuarioAtualizadoPor.DBValue, ParameterDirection.Input, dto.IdtUsuarioAtualizadoPor.DbType));
			
			#endregion	

			string query = "PRC_ASS_ULS_UN_LO_SE_USU_R_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
		/// Inclui o registro
		/// </summary>			
		public void Incluir(UnidadeLocalSetorUsuarioDTO dto)
		{			
			string query = "PRC_ASS_ULS_UN_LO_SE_USU_R_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro Sequence			
			param.Add(Connection.CreateParameterSequence());
			
			
			//Parametro pASS_ULS_ID
			param.Add(Connection.CreateParameter("pASS_ULS_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));
			
			//Parametro pCAD_UNI_ID_UNIDADE
			param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));
			
			//Parametro pCAD_SET_ID
			param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));
			
			//Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
			param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocalAtendimento.DBValue, ParameterDirection.Input, dto.IdtLocalAtendimento.DbType));
			
			//Parametro pASS_ULS_FL_STATUS
			param.Add(Connection.CreateParameter("pASS_ULS_FL_STATUS", dto.FlagStatus.DBValue, ParameterDirection.Input, dto.FlagStatus.DbType));
			
			//Parametro pASS_DT_ULTIMA_ATUALIZACAO
			param.Add(Connection.CreateParameter("pASS_DT_ULTIMA_ATUALIZACAO", dto.DataUltimaAtualizacao.DBValue, ParameterDirection.Input, dto.DataUltimaAtualizacao.DbType));
			
			//Parametro pASS_ULS_ID_USUARIO
			param.Add(Connection.CreateParameter("pASS_ULS_ID_USUARIO", dto.IdtUsuarioAtualizadoPor.DBValue, ParameterDirection.Input, dto.IdtUsuarioAtualizadoPor.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						
				
			//Recupera o valor da Sequence utilizado na procedure     
			
						
			   dto.Idt.Value = Int32.Parse(param["pNewIdt"].Value.ToString());
			

		}	
	}
}
