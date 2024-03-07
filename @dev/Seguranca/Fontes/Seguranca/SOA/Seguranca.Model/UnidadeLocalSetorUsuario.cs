using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.Seguranca.DTO;

namespace HospitalAnaCosta.SGS.Seguranca.Model
{
    public partial class UnidadeLocalSetorUsuario : Entity
    {			
		/// <summary>
        /// Retorna Setores que Usuário tem acesso
        /// </summary>
        public UnidadeLocalSetorUsuarioDataTable Sel(UnidadeLocalSetorUsuarioDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

			//Parametro pASS_ULS_ID
			//param.Add(Connection.CreateParameter("pASS_ULS_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));

			//Parametro pCAD_UNI_ID_UNIDADE
			param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

			//Parametro pCAD_SET_ID
			//param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

			//Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
			param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocalAtendimento.DBValue, ParameterDirection.Input, dto.IdtLocalAtendimento.DbType));

			//Parametro pASS_ULS_FL_STATUS
			param.Add(Connection.CreateParameter("pASS_ULS_FL_STATUS", dto.FlagStatus.DBValue, ParameterDirection.Input, dto.FlagStatus.DbType));

			//Parametro pASS_DT_ULTIMA_ATUALIZACAO
			// param.Add(Connection.CreateParameter("pASS_DT_ULTIMA_ATUALIZACAO", dto.DataUltimaAtualizacao.DBValue, ParameterDirection.Input, dto.DataUltimaAtualizacao.DbType));

			//Parametro pASS_ULS_ID_USUARIO
			// param.Add(Connection.CreateParameter("pASS_ULS_ID_USUARIO", dto.IdtUsuarioAtualizadoPor.DBValue, ParameterDirection.Input, dto.IdtUsuarioAtualizadoPor.DbType));
			#endregion	
			
			UnidadeLocalSetorUsuarioDataTable result = new UnidadeLocalSetorUsuarioDataTable();
            string query = "PRC_MTMD_USU_SETOR_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
        /// Listar o registro utilizando PK
        /// </summary>
        public UnidadeLocalSetorUsuarioDTO SelChave(UnidadeLocalSetorUsuarioDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());
			
			// Parametro pASS_ULS_ID
			param.Add(Connection.CreateParameter("pASS_ULS_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			
			#endregion	
			
			UnidadeLocalSetorUsuarioDataTable result = new UnidadeLocalSetorUsuarioDataTable();
			string query = "PRC_ASS_ULS_UNID_LOC_SET_USU_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
   		    return result.TypedRow(0);
		}

		
		/// <summary>
        /// Exclui o registro
        /// </summary>        

		public void Del(UnidadeLocalSetorUsuarioDTO dto)
		{
  		    #region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pASS_ULS_ID
			// param.Add(Connection.CreateParameter("pASS_ULS_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocalAtendimento.DBValue, ParameterDirection.Input, dto.IdtLocalAtendimento.DbType));
		
		
   	       #endregion				
			//Executa o procedimento

            string query = "PRC_MTMD_USU_SETOR_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Altera o registro
        /// </summary>			
		public void Upd(UnidadeLocalSetorUsuarioDTO dto)
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

			string query = "PRC_ASS_ULS_UNID_LOC_SET_USU_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Inclui o registro
        /// </summary>			
		public void Ins(UnidadeLocalSetorUsuarioDTO dto)
		{			
			string query = "PRC_ASS_ULS_UNID_LOC_SET_USU_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();						
			
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
						
			//Parametro pASS_ULS_ID_USUARIO
			param.Add(Connection.CreateParameter("pASS_ULS_ID_USUARIO", dto.IdtUsuarioAtualizadoPor.DBValue, ParameterDirection.Input, dto.IdtUsuarioAtualizadoPor.DbType));

            param.Add(Connection.CreateParameterSequence());
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);					
		}

        /// <summary>
        /// Obtem usuários com acesso ao estoque
        /// </summary>
        /// <param name="dto"></param>
        public UnidadeLocalSetorUsuarioDataTable UsuarioPorSetor(UnidadeLocalSetorUsuarioDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocalAtendimento.DBValue, ParameterDirection.Input, dto.IdtLocalAtendimento.DbType));

            #endregion

            UnidadeLocalSetorUsuarioDataTable result = new UnidadeLocalSetorUsuarioDataTable();
            string query = "PRC_MTMD_USU_SETOR_ESTOQUE";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;

        }

        /// <summary>
        /// Retorna Listagem de todos os setores marcando os que ja estão associados ao usuário
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public UnidadeLocalSetorUsuarioDataTable AssociarSetorUsuario(UnidadeLocalSetorUsuarioDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocalAtendimento.DBValue, ParameterDirection.Input, dto.IdtLocalAtendimento.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));

            #endregion

            UnidadeLocalSetorUsuarioDataTable result = new UnidadeLocalSetorUsuarioDataTable();
            string query = "PRC_MTMD_USU_SETOR_ASS";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;

        }

        public DataTable ObterAcessoUsuarioSetor(UnidadeLocalSetorUsuarioDTO dto)
        {
            DataTable result = new DataTable();            
            string query =  "SELECT SETOR.CAD_SET_ID,\n" +
                            "       SETOR.CAD_SET_CD_SETOR,\n" + 
                            "       SETOR.CAD_SET_DS_SETOR\n" + 
                            "FROM TB_ASS_ULS_UNID_LOC_SET_USU  ASS,\n" + 
                            "     TB_CAD_SET_SETOR             SETOR\n" +
                            "WHERE ASS.seg_usu_id_usuario             = " + dto.IdtUsuario.Value.ToString() + "\n" +
                            "AND   ASS.CAD_SET_ID                     = " + dto.IdtSetor.Value.ToString() + "\n" + 
                            "AND   ASS.ass_uls_fl_status              = 'A'\n" + 
                            "AND   SETOR.cad_set_id                   = ASS.cad_set_id\n" + 
                            "AND   SETOR.cad_uni_id_unidade           = ASS.cad_uni_id_unidade\n" + 
                            "AND   SETOR.cad_lat_id_local_atendimento = ASS.cad_lat_id_local_atendimento";            

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);
            
            return result;
        }

	}
}