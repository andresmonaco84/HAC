
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class MotivoPerda : Entity
    {			
		/// <summary>
        /// Listar todos os registros
		/// </summary>		
		/// <param name="flTipoDevolucao">Null, 0 ou 1</param>		
        public MotivoPerdaDataTable Sel(MotivoPerdaDTO dto, string flTipoDevolucao)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

			//Parametro pMTMD_ID_MOTIVO
            param.Add(Connection.CreateParameter("pMTMD_ID_MOTIVO", dto.idtMotivo.DBValue, ParameterDirection.Input, dto.idtMotivo.DbType));

			//Parametro pMTMD_DS_MOTIVO
			param.Add(Connection.CreateParameter("pMTMD_DS_MOTIVO", dto.DsMotivo.DBValue, ParameterDirection.Input, dto.DsMotivo.DbType));

			//Parametro pMTMD_FL_OBRIGA_OBS
			param.Add(Connection.CreateParameter("pMTMD_FL_OBRIGA_OBS", dto.FlObrigaObs.DBValue, ParameterDirection.Input, dto.FlObrigaObs.DbType));

            if (!string.IsNullOrEmpty(flTipoDevolucao))
                param.Add(Connection.CreateParameter("pMTMD_FL_DEVOLUCAO", flTipoDevolucao, ParameterDirection.Input, dto.FlObrigaObs.DbType));

			#endregion	
			
			MotivoPerdaDataTable result = new MotivoPerdaDataTable();
			string query = "PRC_MTMD_MOTIVO_PERDA_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
        /// Listar o registro utilizando PK
        /// </summary>
        public MotivoPerdaDTO SelChave(MotivoPerdaDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());
			
			
			#endregion	
			
			MotivoPerdaDataTable result = new MotivoPerdaDataTable();
			string query = "PRC_MTMD_MOTIVO_PERDA_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
   		    return result.TypedRow(0);
		}

		
		/// <summary>
        /// Exclui o registro
        /// </summary>        

		public void Del(MotivoPerdaDTO dto)
		{
  		    #region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
		
   	       #endregion				
			//Executa o procedimento
            
			string query = "PRC_MTMD_MOTIVO_PERDA_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Altera o registro
        /// </summary>			
		public void Upd(MotivoPerdaDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pMTMD_ID_MOTIVO
            param.Add(Connection.CreateParameter("pMTMD_ID_MOTIVO", dto.idtMotivo.DBValue, ParameterDirection.Input, dto.idtMotivo.DbType));
			
			//Parametro pMTMD_DS_MOTIVO
			param.Add(Connection.CreateParameter("pMTMD_DS_MOTIVO", dto.DsMotivo.DBValue, ParameterDirection.Input, dto.DsMotivo.DbType));
			
			//Parametro pMTMD_FL_OBRIGA_OBS
			param.Add(Connection.CreateParameter("pMTMD_FL_OBRIGA_OBS", dto.FlObrigaObs.DBValue, ParameterDirection.Input, dto.FlObrigaObs.DbType));
			
			#endregion	

			string query = "PRC_MTMD_MOTIVO_PERDA_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Inclui o registro
        /// </summary>			
		public void Ins(MotivoPerdaDTO dto)
		{			
			string query = "PRC_MTMD_MOTIVO_PERDA_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			
			//Parametro pMTMD_ID_MOTIVO
            param.Add(Connection.CreateParameter("pMTMD_ID_MOTIVO", dto.idtMotivo.DBValue, ParameterDirection.Input, dto.idtMotivo.DbType));
			
			//Parametro pMTMD_DS_MOTIVO
			param.Add(Connection.CreateParameter("pMTMD_DS_MOTIVO", dto.DsMotivo.DBValue, ParameterDirection.Input, dto.DsMotivo.DbType));
			
			//Parametro pMTMD_FL_OBRIGA_OBS
			param.Add(Connection.CreateParameter("pMTMD_FL_OBRIGA_OBS", dto.FlObrigaObs.DBValue, ParameterDirection.Input, dto.FlObrigaObs.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						

		}	
	}
}
