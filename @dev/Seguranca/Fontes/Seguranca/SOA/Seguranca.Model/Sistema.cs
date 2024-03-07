
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.Seguranca.DTO;

namespace HospitalAnaCosta.SGS.Seguranca.Model
{
    public partial class Sistema : Entity
    {			
		/// <summary>
        /// Listar todos os registros
        /// </summary>
        public SistemaDataTable Sel(SistemaDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

			//Parametro pSEG_ID_SISTEMA
			param.Add(Connection.CreateParameter("pSEG_ID_SISTEMA", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

			//Parametro pSEG_NM_SISTEMA
			param.Add(Connection.CreateParameter("pSEG_NM_SISTEMA", dto.NmSistema.DBValue, ParameterDirection.Input, dto.NmSistema.DbType));
			#endregion	
			
			SistemaDataTable result = new SistemaDataTable();
			string query = "PRC_SEG_SISTEMA_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
        /// Listar o registro utilizando PK
        /// </summary>
        public SistemaDTO SelChave(SistemaDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());
			
			// Parametro pSEG_ID_SISTEMA
			param.Add(Connection.CreateParameter("pSEG_ID_SISTEMA", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			
			#endregion	
			
			SistemaDataTable result = new SistemaDataTable();
			string query = "PRC_SEG_SISTEMA_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
   		    return result.TypedRow(0);
		}

		
		/// <summary>
        /// Exclui o registro
        /// </summary>        

		public void Del(SistemaDTO dto)
		{
  		    #region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pSEG_ID_SISTEMA
			param.Add(Connection.CreateParameter("pSEG_ID_SISTEMA", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
		
   	       #endregion				
			//Executa o procedimento
            
			string query = "PRC_SEG_SISTEMA_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Altera o registro
        /// </summary>			
		public void Upd(SistemaDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pSEG_ID_SISTEMA
			param.Add(Connection.CreateParameter("pSEG_ID_SISTEMA", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pSEG_NM_SISTEMA
			param.Add(Connection.CreateParameter("pSEG_NM_SISTEMA", dto.NmSistema.DBValue, ParameterDirection.Input, dto.NmSistema.DbType));
			
			#endregion	

			string query = "PRC_SEG_SISTEMA_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Inclui o registro
        /// </summary>			
		public void Ins(SistemaDTO dto)
		{			
			string query = "PRC_SEG_SISTEMA_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			
			//Parametro pSEG_ID_SISTEMA
			param.Add(Connection.CreateParameter("pSEG_ID_SISTEMA", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pSEG_NM_SISTEMA
			param.Add(Connection.CreateParameter("pSEG_NM_SISTEMA", dto.NmSistema.DBValue, ParameterDirection.Input, dto.NmSistema.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						

		}	
	}
}
