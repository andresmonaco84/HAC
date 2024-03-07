
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.Services.Seguranca.DTO;

namespace HospitalAnaCosta.Services.Seguranca.Model
{
	public partial class Parametro : Entity
	{			
		/// <summary>
		/// Listar todos os registros
		/// </summary>
		public ParametroDataTable Listar(ParametroDTO dto)
		{            
			#region "Parametros"
			DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
			param.Add(Connection.CreateParameterCursor());

			//Parametro pSEG_PAR_CD
			param.Add(Connection.CreateParameter("pSEG_PAR_CD", dto.Codigo.DBValue, ParameterDirection.Input, dto.Codigo.DbType));

			//Parametro pSEG_PAR_NM_PARAMETRO
			param.Add(Connection.CreateParameter("pSEG_PAR_NM_PARAMETRO", dto.Nome.DBValue, ParameterDirection.Input, dto.Nome.DbType));

			//Parametro pSEG_PAR_VL_PARAMETRO
			param.Add(Connection.CreateParameter("pSEG_PAR_VL_PARAMETRO", dto.Valor.DBValue, ParameterDirection.Input, dto.Valor.DbType));
			#endregion	
			
			ParametroDataTable result = new ParametroDataTable();
			string query = "PRC_SEG_PAR_PARAMETRO_R_L";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
		/// Listar o registro utilizando PK
		/// </summary>
		public ParametroDTO Pesquisar(ParametroDTO dto)
		{            
			#region "Parametros"
			DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
			param.Add(Connection.CreateParameterCursor());
			
			// Parametro pSEG_PAR_CD
			param.Add(Connection.CreateParameter("pSEG_PAR_CD", dto.Codigo.DBValue, ParameterDirection.Input, dto.Codigo.DbType));
			
			
			#endregion	
			
			ParametroDataTable result = new ParametroDataTable();
			string query = "PRC_SEG_PAR_PARAMETRO_R_S";
			
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

		public void Excluir(ParametroDTO dto)
		{
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pSEG_PAR_CD
			param.Add(Connection.CreateParameter("pSEG_PAR_CD", dto.Codigo.DBValue, ParameterDirection.Input, dto.Codigo.DbType));
			
		
		   #endregion				
			//Executa o procedimento
			
			string query = "PRC_SEG_PAR_PARAMETRO_R_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
		/// Altera o registro
		/// </summary>			
		public void Alterar(ParametroDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pSEG_PAR_CD
			param.Add(Connection.CreateParameter("pSEG_PAR_CD", dto.Codigo.DBValue, ParameterDirection.Input, dto.Codigo.DbType));
			
			//Parametro pSEG_PAR_NM_PARAMETRO
			param.Add(Connection.CreateParameter("pSEG_PAR_NM_PARAMETRO", dto.Nome.DBValue, ParameterDirection.Input, dto.Nome.DbType));
			
			//Parametro pSEG_PAR_VL_PARAMETRO
			param.Add(Connection.CreateParameter("pSEG_PAR_VL_PARAMETRO", dto.Valor.DBValue, ParameterDirection.Input, dto.Valor.DbType));
			
			#endregion	

			string query = "PRC_SEG_PAR_PARAMETRO_R_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
		/// Inclui o registro
		/// </summary>			
		public void Incluir(ParametroDTO dto)
		{			
			string query = "PRC_SEG_PAR_PARAMETRO_R_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			
			//Parametro pSEG_PAR_CD
			param.Add(Connection.CreateParameter("pSEG_PAR_CD", dto.Codigo.DBValue, ParameterDirection.Input, dto.Codigo.DbType));
			
			//Parametro pSEG_PAR_NM_PARAMETRO
			param.Add(Connection.CreateParameter("pSEG_PAR_NM_PARAMETRO", dto.Nome.DBValue, ParameterDirection.Input, dto.Nome.DbType));
			
			//Parametro pSEG_PAR_VL_PARAMETRO
			param.Add(Connection.CreateParameter("pSEG_PAR_VL_PARAMETRO", dto.Valor.DBValue, ParameterDirection.Input, dto.Valor.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						

		}	
	}
}
