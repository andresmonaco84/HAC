
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.Services.Seguranca.DTO;

namespace HospitalAnaCosta.Services.Seguranca.Model
{
	public partial class Trace : Entity
	{			
		/// <summary>
		/// Listar todos os registros
		/// </summary>
		public TraceDataTable Listar(TraceDTO dto)
		{            
			#region "Parametros"
			DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
			param.Add(Connection.CreateParameterCursor());

			//Parametro pSEG_TRA_ID_TRACE
			param.Add(Connection.CreateParameter("pSEG_TRA_ID_TRACE", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

			//Parametro pSEG_TRA_DT_TRACE
			param.Add(Connection.CreateParameter("pSEG_TRA_DT_TRACE", dto.Data.DBValue, ParameterDirection.Input, dto.Data.DbType));

			//Parametro pSEG_TRA_NR_IP
			param.Add(Connection.CreateParameter("pSEG_TRA_NR_IP", dto.IP.DBValue, ParameterDirection.Input, dto.IP.DbType));

			//Parametro pSEG_TRA_DS_URL
			param.Add(Connection.CreateParameter("pSEG_TRA_DS_URL", dto.URL.DBValue, ParameterDirection.Input, dto.URL.DbType));

			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));
			#endregion	
			
			TraceDataTable result = new TraceDataTable();
			string query = "PRC_SEG_TRA_TRACE_R_L";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
		/// Listar o registro utilizando PK
		/// </summary>
		public TraceDTO Pesquisar(TraceDTO dto)
		{            
			#region "Parametros"
			DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
			param.Add(Connection.CreateParameterCursor());
			
			// Parametro pSEG_TRA_ID_TRACE
			param.Add(Connection.CreateParameter("pSEG_TRA_ID_TRACE", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			
			#endregion	
			
			TraceDataTable result = new TraceDataTable();
			string query = "PRC_SEG_TRA_TRACE_R_S";
			
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

		public void Excluir(TraceDTO dto)
		{
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pSEG_TRA_ID_TRACE
			param.Add(Connection.CreateParameter("pSEG_TRA_ID_TRACE", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
		
		   #endregion				
			//Executa o procedimento
			
			string query = "PRC_SEG_TRA_TRACE_R_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
		/// Altera o registro
		/// </summary>			
		public void Alterar(TraceDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pSEG_TRA_ID_TRACE
			param.Add(Connection.CreateParameter("pSEG_TRA_ID_TRACE", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pSEG_TRA_DT_TRACE
			param.Add(Connection.CreateParameter("pSEG_TRA_DT_TRACE", dto.Data.DBValue, ParameterDirection.Input, dto.Data.DbType));
			
			//Parametro pSEG_TRA_NR_IP
			param.Add(Connection.CreateParameter("pSEG_TRA_NR_IP", dto.IP.DBValue, ParameterDirection.Input, dto.IP.DbType));
			
			//Parametro pSEG_TRA_DS_URL
			param.Add(Connection.CreateParameter("pSEG_TRA_DS_URL", dto.URL.DBValue, ParameterDirection.Input, dto.URL.DbType));
			
			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));
			
			#endregion	

			string query = "PRC_SEG_TRA_TRACE_R_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
		/// Inclui o registro
		/// </summary>			
		public void Incluir(TraceDTO dto)
		{			
			string query = "PRC_SEG_TRA_TRACE_R_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro Sequence			
			param.Add(Connection.CreateParameterSequence());
			
			
			//Parametro pSEG_TRA_ID_TRACE
			param.Add(Connection.CreateParameter("pSEG_TRA_ID_TRACE", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pSEG_TRA_DT_TRACE
			param.Add(Connection.CreateParameter("pSEG_TRA_DT_TRACE", dto.Data.DBValue, ParameterDirection.Input, dto.Data.DbType));
			
			//Parametro pSEG_TRA_NR_IP
			param.Add(Connection.CreateParameter("pSEG_TRA_NR_IP", dto.IP.DBValue, ParameterDirection.Input, dto.IP.DbType));
			
			//Parametro pSEG_TRA_DS_URL
			param.Add(Connection.CreateParameter("pSEG_TRA_DS_URL", dto.URL.DBValue, ParameterDirection.Input, dto.URL.DbType));
			
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
