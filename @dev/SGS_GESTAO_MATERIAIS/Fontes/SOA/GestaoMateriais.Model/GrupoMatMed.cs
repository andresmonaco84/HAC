
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class GrupoMatMed : Entity
    {			
		/// <summary>
        /// Listar todos os registros
        /// </summary>
        public GrupoMatMedDataTable Sel(GrupoMatMedDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

			//Parametro pCAD_MTMD_GRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

			//Parametro pCAD_MTMD_GRUPO_DESCRICAO
			param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_DESCRICAO", dto.DsGrupo.DBValue, ParameterDirection.Input, dto.DsGrupo.DbType));
			#endregion	
			
			GrupoMatMedDataTable result = new GrupoMatMedDataTable();
			string query = "PRC_CAD_MTMD_GRUPO_S";
			
            
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
        /// Listar o registro utilizando PK
        /// </summary>
        public GrupoMatMedDTO SelChave(GrupoMatMedDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());
			
			// Parametro pCAD_MTMD_GRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			
			#endregion	
			
			GrupoMatMedDataTable result = new GrupoMatMedDataTable();
			string query = "PRC_CAD_MTMD_GRUPO_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
   		    return result.TypedRow(0);
		}

		
		/// <summary>
        /// Exclui o registro
        /// </summary>        

		public void Del(GrupoMatMedDTO dto)
		{
  		    #region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pCAD_MTMD_GRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
		
   	       #endregion				
			//Executa o procedimento
            
			string query = "PRC_CAD_MTMD_GRUPO_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Altera o registro
        /// </summary>			
		public void Upd(GrupoMatMedDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pCAD_MTMD_GRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pCAD_MTMD_GRUPO_DESCRICAO
			param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_DESCRICAO", dto.DsGrupo.DBValue, ParameterDirection.Input, dto.DsGrupo.DbType));
			
			#endregion	

			string query = "PRC_CAD_MTMD_GRUPO_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Inclui o registro
        /// </summary>			
		public void Ins(GrupoMatMedDTO dto)
		{			
			string query = "PRC_CAD_MTMD_GRUPO_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			
			//Parametro pCAD_MTMD_GRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pCAD_MTMD_GRUPO_DESCRICAO
			param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_DESCRICAO", dto.DsGrupo.DBValue, ParameterDirection.Input, dto.DsGrupo.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						

		}	
	}
}
