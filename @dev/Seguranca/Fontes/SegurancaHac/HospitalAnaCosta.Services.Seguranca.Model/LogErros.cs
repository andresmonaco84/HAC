
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.Services.Seguranca.DTO;

namespace HospitalAnaCosta.Services.Seguranca.Model
{
	public partial class LogErros : Entity
	{			
		/// <summary>
		/// Listar todos os registros
		/// </summary>
		public LogErrosDataTable Listar(LogErrosDTO dto)
		{            
			#region "Parametros"
			DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
			param.Add(Connection.CreateParameterCursor());

			//Parametro pSEG_ERR_ID_ERRO
			param.Add(Connection.CreateParameter("pSEG_ERR_ID_ERRO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

			//Parametro pSEG_ERR_DT_ERRO
			param.Add(Connection.CreateParameter("pSEG_ERR_DT_ERRO", dto.Data.DBValue, ParameterDirection.Input, dto.Data.DbType));

			//Parametro pSEG_ERR_DS_URL_ERRO
			param.Add(Connection.CreateParameter("pSEG_ERR_DS_URL_ERRO", dto.URL.DBValue, ParameterDirection.Input, dto.URL.DbType));

			//Parametro pSEG_ERR_CD_CODIGO
			param.Add(Connection.CreateParameter("pSEG_ERR_CD_CODIGO", dto.Codigo.DBValue, ParameterDirection.Input, dto.Codigo.DbType));

			//Parametro pSEG_ERR_DS_ERRO
			param.Add(Connection.CreateParameter("pSEG_ERR_DS_ERRO", dto.Descricao.DBValue, ParameterDirection.Input, dto.Descricao.DbType));

			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));

			//Parametro pSEG_ERR_DS_STACK_TRACE
			param.Add(Connection.CreateParameter("pSEG_ERR_DS_STACK_TRACE", dto.StackTrace.DBValue, ParameterDirection.Input, dto.StackTrace.DbType));
			#endregion	
			
			LogErrosDataTable result = new LogErrosDataTable();
			string query = "PRC_SEG_ERR_ERROS_LOG_R_L";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
		/// Listar o registro utilizando PK
		/// </summary>
		public LogErrosDTO Pesquisar(LogErrosDTO dto)
		{            
			#region "Parametros"
			DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
			param.Add(Connection.CreateParameterCursor());
			
			// Parametro pSEG_ERR_ID_ERRO
			param.Add(Connection.CreateParameter("pSEG_ERR_ID_ERRO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			
			#endregion	
			
			LogErrosDataTable result = new LogErrosDataTable();
			string query = "PRC_SEG_ERR_ERROS_LOG_R_S";
			
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

		public void Excluir(LogErrosDTO dto)
		{
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pSEG_ERR_ID_ERRO
			param.Add(Connection.CreateParameter("pSEG_ERR_ID_ERRO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
		
		   #endregion				
			//Executa o procedimento
			
			string query = "PRC_SEG_ERR_ERROS_LOG_R_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
		/// Altera o registro
		/// </summary>			
		public void Alterar(LogErrosDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pSEG_ERR_ID_ERRO
			param.Add(Connection.CreateParameter("pSEG_ERR_ID_ERRO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pSEG_ERR_DT_ERRO
			param.Add(Connection.CreateParameter("pSEG_ERR_DT_ERRO", dto.Data.DBValue, ParameterDirection.Input, dto.Data.DbType));
			
			//Parametro pSEG_ERR_DS_URL_ERRO
			param.Add(Connection.CreateParameter("pSEG_ERR_DS_URL_ERRO", dto.URL.DBValue, ParameterDirection.Input, dto.URL.DbType));
			
			//Parametro pSEG_ERR_CD_CODIGO
			param.Add(Connection.CreateParameter("pSEG_ERR_CD_CODIGO", dto.Codigo.DBValue, ParameterDirection.Input, dto.Codigo.DbType));
			
			//Parametro pSEG_ERR_DS_ERRO
			param.Add(Connection.CreateParameter("pSEG_ERR_DS_ERRO", dto.Descricao.DBValue, ParameterDirection.Input, dto.Descricao.DbType));
			
			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));
			
			//Parametro pSEG_ERR_DS_STACK_TRACE
			param.Add(Connection.CreateParameter("pSEG_ERR_DS_STACK_TRACE", dto.StackTrace.DBValue, ParameterDirection.Input, dto.StackTrace.DbType));
			
			#endregion	

			string query = "PRC_SEG_ERR_ERROS_LOG_R_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
		/// Inclui o registro
		/// </summary>			
		public void Incluir(LogErrosDTO dto)
		{			
			string query = "PRC_SEG_ERR_ERROS_LOG_R_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro Sequence			
			param.Add(Connection.CreateParameterSequence());
			
			
			//Parametro pSEG_ERR_ID_ERRO
			param.Add(Connection.CreateParameter("pSEG_ERR_ID_ERRO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pSEG_ERR_DT_ERRO
			param.Add(Connection.CreateParameter("pSEG_ERR_DT_ERRO", dto.Data.DBValue, ParameterDirection.Input, dto.Data.DbType));
			
			//Parametro pSEG_ERR_DS_URL_ERRO
			param.Add(Connection.CreateParameter("pSEG_ERR_DS_URL_ERRO", dto.URL.DBValue, ParameterDirection.Input, dto.URL.DbType));
			
			//Parametro pSEG_ERR_CD_CODIGO
			param.Add(Connection.CreateParameter("pSEG_ERR_CD_CODIGO", dto.Codigo.DBValue, ParameterDirection.Input, dto.Codigo.DbType));
			
			//Parametro pSEG_ERR_DS_ERRO
			param.Add(Connection.CreateParameter("pSEG_ERR_DS_ERRO", dto.Descricao.DBValue, ParameterDirection.Input, dto.Descricao.DbType));
			
			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));
			
			//Parametro pSEG_ERR_DS_STACK_TRACE
			param.Add(Connection.CreateParameter("pSEG_ERR_DS_STACK_TRACE", dto.StackTrace.DBValue, ParameterDirection.Input, dto.StackTrace.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						
				
			//Recupera o valor da Sequence utilizado na procedure     
			
						
			   dto.Idt.Value = Int32.Parse(param["pNewIdt"].Value.ToString());
			

		}	
	}
}
