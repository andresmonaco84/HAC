using System.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class LocalAtendimento : Entity
    {			
		/// <summary>
        /// Listar todos os registros
        /// </summary>
        public LocalAtendimentoDataTable Sel(LocalAtendimentoDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

			//Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
			param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

			//Parametro pCAD_LAT_DS_LOCAL_ATENDIMENTO
			param.Add(Connection.CreateParameter("pCAD_LAT_DS_LOCAL_ATENDIMENTO", dto.DsLocalAtendimento.DBValue, ParameterDirection.Input, dto.DsLocalAtendimento.DbType));

			//Parametro pCAD_LAT_FL_ATIVO_OK
			param.Add(Connection.CreateParameter("pCAD_LAT_FL_ATIVO_OK", dto.AtivoOK.DBValue, ParameterDirection.Input, dto.AtivoOK.DbType));

			//Parametro pCAD_LAT_DT_ULTIMA_ATUALIZACAO
			param.Add(Connection.CreateParameter("pCAD_LAT_DT_ULTIMA_ATUALIZACAO", dto.DtAtualizacao.DBValue, ParameterDirection.Input, dto.DtAtualizacao.DbType));

			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));

			//Parametro pCAD_LAT_CD_LOCAL_ATENDIMENTO
			param.Add(Connection.CreateParameter("pCAD_LAT_CD_LOCAL_ATENDIMENTO", dto.CdLocalAtendimento.DBValue, ParameterDirection.Input, dto.CdLocalAtendimento.DbType));
			#endregion	
			
			LocalAtendimentoDataTable result = new LocalAtendimentoDataTable();
			string query = "PRC_CAD_LOCAL_ATENDIMENTO_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

        /// <summary>
        /// Listar Locais de Atendimento que possuam associações ATIVAS com as Unidades
        /// </summary>
        public LocalAtendimentoDataTable SelPorUnidade(LocalAtendimentoDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pCAD_LAT_FL_ATIVO_OK
            param.Add(Connection.CreateParameter("pCAD_LAT_FL_ATIVO_OK", dto.AtivoOK.DBValue, ParameterDirection.Input, dto.AtivoOK.DbType));

            #endregion

            LocalAtendimentoDataTable result = new LocalAtendimentoDataTable();
            string query = "PRC_CAD_LOCAL_UNIDADE_S";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }
		/// <summary>
        /// Listar o registro utilizando PK
        /// </summary>
        public LocalAtendimentoDTO SelChave(LocalAtendimentoDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());
			
			// Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
			param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			
			#endregion	
			
			LocalAtendimentoDataTable result = new LocalAtendimentoDataTable();
			string query = "PRC_CAD_LOCAL_ATENDIMENTO_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
   		    return result.TypedRow(0);
		}

		
		/// <summary>
        /// Exclui o registro
        /// </summary>        

		public void Del(LocalAtendimentoDTO dto)
		{
  		    #region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
			param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
		
   	       #endregion				
			//Executa o procedimento
            
			string query = "PRC_CAD_LOCAL_ATENDIMENTO_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Altera o registro
        /// </summary>			
		public void Upd(LocalAtendimentoDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
			param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pCAD_LAT_DS_LOCAL_ATENDIMENTO
			param.Add(Connection.CreateParameter("pCAD_LAT_DS_LOCAL_ATENDIMENTO", dto.DsLocalAtendimento.DBValue, ParameterDirection.Input, dto.DsLocalAtendimento.DbType));
			
			//Parametro pCAD_LAT_FL_ATIVO_OK
			param.Add(Connection.CreateParameter("pCAD_LAT_FL_ATIVO_OK", dto.AtivoOK.DBValue, ParameterDirection.Input, dto.AtivoOK.DbType));
			
			//Parametro pCAD_LAT_DT_ULTIMA_ATUALIZACAO
			param.Add(Connection.CreateParameter("pCAD_LAT_DT_ULTIMA_ATUALIZACAO", dto.DtAtualizacao.DBValue, ParameterDirection.Input, dto.DtAtualizacao.DbType));
			
			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));
			
			//Parametro pCAD_LAT_CD_LOCAL_ATENDIMENTO
			param.Add(Connection.CreateParameter("pCAD_LAT_CD_LOCAL_ATENDIMENTO", dto.CdLocalAtendimento.DBValue, ParameterDirection.Input, dto.CdLocalAtendimento.DbType));
			
			#endregion	

			string query = "PRC_CAD_LOCAL_ATENDIMENTO_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Inclui o registro
        /// </summary>			
		public void Ins(LocalAtendimentoDTO dto)
		{			
			string query = "PRC_CAD_LOCAL_ATENDIMENTO_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			
			//Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
			param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pCAD_LAT_DS_LOCAL_ATENDIMENTO
			param.Add(Connection.CreateParameter("pCAD_LAT_DS_LOCAL_ATENDIMENTO", dto.DsLocalAtendimento.DBValue, ParameterDirection.Input, dto.DsLocalAtendimento.DbType));
			
			//Parametro pCAD_LAT_FL_ATIVO_OK
			param.Add(Connection.CreateParameter("pCAD_LAT_FL_ATIVO_OK", dto.AtivoOK.DBValue, ParameterDirection.Input, dto.AtivoOK.DbType));
			
			//Parametro pCAD_LAT_DT_ULTIMA_ATUALIZACAO
			param.Add(Connection.CreateParameter("pCAD_LAT_DT_ULTIMA_ATUALIZACAO", dto.DtAtualizacao.DBValue, ParameterDirection.Input, dto.DtAtualizacao.DbType));
			
			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));
			
			//Parametro pCAD_LAT_CD_LOCAL_ATENDIMENTO
			param.Add(Connection.CreateParameter("pCAD_LAT_CD_LOCAL_ATENDIMENTO", dto.CdLocalAtendimento.DBValue, ParameterDirection.Input, dto.CdLocalAtendimento.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						

		}	
	}
}
