
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class TipoFracao : Entity
    {			
		/// <summary>
        /// Listar todos os registros
        /// </summary>
        public TipoFracaoDataTable Sel(TipoFracaoDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

			//Parametro pMTMD_TP_FRACAO_ID
			param.Add(Connection.CreateParameter("pMTMD_TP_FRACAO_ID", dto.IdtTpFracao.DBValue, ParameterDirection.Input, dto.IdtTpFracao.DbType));

			//Parametro pMTMD_DS_TP_FRACAO
			param.Add(Connection.CreateParameter("pMTMD_DS_TP_FRACAO", dto.DsTpFracao.DBValue, ParameterDirection.Input, dto.DsTpFracao.DbType));
			#endregion	
			
			TipoFracaoDataTable result = new TipoFracaoDataTable();
			string query = "PRC_MTMD_TIPO_FRACAO_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
        /// Listar o registro utilizando PK
        /// </summary>
        public TipoFracaoDTO SelChave(TipoFracaoDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());
			
			// Parametro pMTMD_TP_FRACAO_ID
			param.Add(Connection.CreateParameter("pMTMD_TP_FRACAO_ID", dto.IdtTpFracao.DBValue, ParameterDirection.Input, dto.IdtTpFracao.DbType));
			
			
			#endregion	
			
			TipoFracaoDataTable result = new TipoFracaoDataTable();
			string query = "PRC_MTMD_TIPO_FRACAO_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
   		    return result.TypedRow(0);
		}

		
		/// <summary>
        /// Exclui o registro
        /// </summary>        

		public void Del(TipoFracaoDTO dto)
		{
  		    #region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pMTMD_TP_FRACAO_ID
			param.Add(Connection.CreateParameter("pMTMD_TP_FRACAO_ID", dto.IdtTpFracao.DBValue, ParameterDirection.Input, dto.IdtTpFracao.DbType));
			
		
   	       #endregion				
			//Executa o procedimento
            
			string query = "PRC_MTMD_TIPO_FRACAO_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Altera o registro
        /// </summary>			
		public void Upd(TipoFracaoDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pMTMD_TP_FRACAO_ID
			param.Add(Connection.CreateParameter("pMTMD_TP_FRACAO_ID", dto.IdtTpFracao.DBValue, ParameterDirection.Input, dto.IdtTpFracao.DbType));
			
			//Parametro pMTMD_DS_TP_FRACAO
			param.Add(Connection.CreateParameter("pMTMD_DS_TP_FRACAO", dto.DsTpFracao.DBValue, ParameterDirection.Input, dto.DsTpFracao.DbType));
			
			#endregion	

			string query = "PRC_MTMD_TIPO_FRACAO_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Inclui o registro
        /// </summary>			
		public void Ins(TipoFracaoDTO dto)
		{			
			string query = "PRC_MTMD_TIPO_FRACAO_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			
			//Parametro pMTMD_TP_FRACAO_ID
			param.Add(Connection.CreateParameter("pMTMD_TP_FRACAO_ID", dto.IdtTpFracao.DBValue, ParameterDirection.Input, dto.IdtTpFracao.DbType));
			
			//Parametro pMTMD_DS_TP_FRACAO
			param.Add(Connection.CreateParameter("pMTMD_DS_TP_FRACAO", dto.DsTpFracao.DBValue, ParameterDirection.Input, dto.DsTpFracao.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						

		}


        public TipoFracaoDTO ConverteFracao(TipoFracaoDTO dto)
        {

            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pMTMD_TP_FRACAO_ID
            param.Add(Connection.CreateParameter("pMTMD_TP_FRACAO_ID", dto.IdtTpFracao.DBValue, ParameterDirection.Input, dto.IdtTpFracao.DbType));

            //Parametro pMTMD_DS_TP_FRACAO
            param.Add(Connection.CreateParameter("pMTMD_MOV_QTDE", dto.QtdeConsumida.DBValue, ParameterDirection.Input, dto.QtdeConsumida.DbType));
            #endregion	

			
            TipoFracaoDataTable result = new TipoFracaoDataTable();
            string query = "PRC_CAD_MTMD_CONVERTE_FRACAO_S";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result.TypedRow(0);


        }
	}
}
