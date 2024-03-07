
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.Seguranca.DTO;

namespace HospitalAnaCosta.SGS.Seguranca.Model
{
    public partial class Perfil : Entity
    {			
		/// <summary>
        /// Listar todos os registros
        /// </summary>
        public PerfilDataTable Sel(PerfilDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

			//Parametro pSEG_PER_ID_PERFIL
			param.Add(Connection.CreateParameter("pSEG_PER_ID_PERFIL", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

			//Parametro pSEG_PER_NM_PERFIL
			param.Add(Connection.CreateParameter("pSEG_PER_NM_PERFIL", dto.NmPerfil.DBValue, ParameterDirection.Input, dto.NmPerfil.DbType));

			//Parametro pSEG_PER_FL_STATUS
			param.Add(Connection.CreateParameter("pSEG_PER_FL_STATUS", dto.FlStatus.DBValue, ParameterDirection.Input, dto.FlStatus.DbType));

            //Parametro pSEG_MOD_ID_MODULO
            param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.IdtModulo.DBValue, ParameterDirection.Input, dto.IdtModulo.DbType));
			#endregion	
			
			PerfilDataTable result = new PerfilDataTable();
			string query = "PRC_SEG_PERFIL_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
        /// Listar o registro utilizando PK
        /// </summary>
        public PerfilDTO SelChave(PerfilDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());
			
			// Parametro pSEG_PER_ID_PERFIL
			param.Add(Connection.CreateParameter("pSEG_PER_ID_PERFIL", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			
			#endregion	
			
			PerfilDataTable result = new PerfilDataTable();
			string query = "PRC_SEG_PERFIL_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
   		    return result.TypedRow(0);
		}

		
		/// <summary>
        /// Exclui o registro
        /// </summary>        

		public void Del(PerfilDTO dto)
		{
  		    #region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pSEG_PER_ID_PERFIL
			param.Add(Connection.CreateParameter("pSEG_PER_ID_PERFIL", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
		
   	       #endregion				
			//Executa o procedimento
            
			string query = "PRC_SEG_PERFIL_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Altera o registro
        /// </summary>			
		public void Upd(PerfilDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pSEG_PER_ID_PERFIL
			param.Add(Connection.CreateParameter("pSEG_PER_ID_PERFIL", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pSEG_PER_NM_PERFIL
			param.Add(Connection.CreateParameter("pSEG_PER_NM_PERFIL", dto.NmPerfil.DBValue, ParameterDirection.Input, dto.NmPerfil.DbType));
			
			//Parametro pSEG_PER_FL_STATUS
			param.Add(Connection.CreateParameter("pSEG_PER_FL_STATUS", dto.FlStatus.DBValue, ParameterDirection.Input, dto.FlStatus.DbType));
			
			//Parametro pSEG_PER_DT_ULTIMA_ATUALIZACAO
			param.Add(Connection.CreateParameter("pSEG_PER_DT_ULTIMA_ATUALIZACAO", dto.DtAtualizacao.DBValue, ParameterDirection.Input, dto.DtAtualizacao.DbType));
			
			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));
			
			//Parametro pSEG_ID_SISTEMA
			// param.Add(Connection.CreateParameter("pSEG_ID_SISTEMA", dto.IdtSistema.DBValue, ParameterDirection.Input, dto.IdtSistema.DbType));

            //Parametro pSEG_MOD_ID_MODULO
            param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.IdtModulo.DBValue, ParameterDirection.Input, dto.IdtModulo.DbType));

			#endregion	

			string query = "PRC_SEG_PERFIL_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Inclui o registro
        /// </summary>			
		public void Ins(PerfilDTO dto)
		{			
			string query = "PRC_SEG_PERFIL_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			
			//Parametro pSEG_PER_ID_PERFIL
			param.Add(Connection.CreateParameter("pSEG_PER_ID_PERFIL", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pSEG_PER_NM_PERFIL
			param.Add(Connection.CreateParameter("pSEG_PER_NM_PERFIL", dto.NmPerfil.DBValue, ParameterDirection.Input, dto.NmPerfil.DbType));
			
			//Parametro pSEG_PER_FL_STATUS
			param.Add(Connection.CreateParameter("pSEG_PER_FL_STATUS", dto.FlStatus.DBValue, ParameterDirection.Input, dto.FlStatus.DbType));
			
			//Parametro pSEG_PER_DT_ULTIMA_ATUALIZACAO
			param.Add(Connection.CreateParameter("pSEG_PER_DT_ULTIMA_ATUALIZACAO", dto.DtAtualizacao.DBValue, ParameterDirection.Input, dto.DtAtualizacao.DbType));
			
			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));
			
			//Parametro pSEG_ID_SISTEMA
			// param.Add(Connection.CreateParameter("pSEG_ID_SISTEMA", dto.IdtSistema.DBValue, ParameterDirection.Input, dto.IdtSistema.DbType));

            //Parametro pSEG_MOD_ID_MODULO
            param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.IdtModulo.DBValue, ParameterDirection.Input, dto.IdtModulo.DbType));


            param.Add(Connection.CreateParameterSequence());

			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);

            dto.Idt.Value = Int32.Parse(param["pNewIdt"].Value.ToString());		

		}

        /* JÁ E USADO O MODULO COMO FILTRO NA (SEL) */
        //public PerfilDataTable ObterPorModulo(PerfilDTO dto)
        //{
        //    #region "Parametros"
        //    DbParameterCollection param = Connection.CreateDataParameterCollection();

        //    //Parametro Cursor
        //    param.Add(Connection.CreateParameterCursor());

        //    //Parametro pSEG_MOD_ID_MODULO
        //    param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.IdtModulo.DBValue, ParameterDirection.Input, dto.IdtModulo.DbType));
        //    #endregion

        //    PerfilDataTable result = new PerfilDataTable();
        //    string query = "PRC_SEG_PER_PERFIL_MOD_ASS_S";

        //    //Executa o procedimento
        //    Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

        //    return result;

        //}

	}
}
