
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class SubGrupoMatMed : Entity
    {			
		/// <summary>
        /// Listar todos os registros
        /// </summary>
        public SubGrupoMatMedDataTable Sel(SubGrupoMatMedDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

			//Parametro pCAD_MTMD_SUBGRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_SUBGRUPO_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

			//Parametro pCAD_MTMD_GRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.IdtGrupo.DBValue, ParameterDirection.Input, dto.IdtGrupo.DbType));

			//Parametro pCAD_MTMD_SUBGRUPO_DESCRICAO
			param.Add(Connection.CreateParameter("pCAD_MTMD_SUBGRUPO_DESCRICAO", dto.DsSubGrupo.DBValue, ParameterDirection.Input, dto.DsSubGrupo.DbType));
			#endregion	
			
			SubGrupoMatMedDataTable result = new SubGrupoMatMedDataTable();
			string query = "PRC_CAD_MTMD_SUBGRUPO_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
        /// Listar o registro utilizando PK
        /// </summary>
        public SubGrupoMatMedDTO SelChave(SubGrupoMatMedDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());
			
			// Parametro pCAD_MTMD_GRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.IdtGrupo.DBValue, ParameterDirection.Input, dto.IdtGrupo.DbType));
			
			// Parametro pCAD_MTMD_SUBGRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_SUBGRUPO_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			
			#endregion	
			
			SubGrupoMatMedDataTable result = new SubGrupoMatMedDataTable();
			string query = "PRC_CAD_MTMD_SUBGRUPO_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
   		    return result.TypedRow(0);
		}

		
		/// <summary>
        /// Exclui o registro
        /// </summary>        

		public void Del(SubGrupoMatMedDTO dto)
		{
  		    #region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pCAD_MTMD_GRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.IdtGrupo.DBValue, ParameterDirection.Input, dto.IdtGrupo.DbType));
			
			// Parametro pCAD_MTMD_SUBGRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_SUBGRUPO_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
		
   	       #endregion				
			//Executa o procedimento
            
			string query = "PRC_CAD_MTMD_SUBGRUPO_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Altera o registro
        /// </summary>			
		public void Upd(SubGrupoMatMedDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pCAD_MTMD_SUBGRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_SUBGRUPO_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pCAD_MTMD_GRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.IdtGrupo.DBValue, ParameterDirection.Input, dto.IdtGrupo.DbType));
			
			//Parametro pCAD_MTMD_SUBGRUPO_DESCRICAO
			param.Add(Connection.CreateParameter("pCAD_MTMD_SUBGRUPO_DESCRICAO", dto.DsSubGrupo.DBValue, ParameterDirection.Input, dto.DsSubGrupo.DbType));
			
			#endregion	

			string query = "PRC_CAD_MTMD_SUBGRUPO_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Inclui o registro
        /// </summary>			
		public void Ins(SubGrupoMatMedDTO dto)
		{			
			string query = "PRC_CAD_MTMD_SUBGRUPO_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			
			//Parametro pCAD_MTMD_SUBGRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_SUBGRUPO_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pCAD_MTMD_GRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.IdtGrupo.DBValue, ParameterDirection.Input, dto.IdtGrupo.DbType));
			
			//Parametro pCAD_MTMD_SUBGRUPO_DESCRICAO
			param.Add(Connection.CreateParameter("pCAD_MTMD_SUBGRUPO_DESCRICAO", dto.DsSubGrupo.DBValue, ParameterDirection.Input, dto.DsSubGrupo.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						

		}	
	}
}
