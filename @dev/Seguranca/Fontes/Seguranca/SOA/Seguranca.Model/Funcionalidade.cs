
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.Seguranca.DTO;

namespace HospitalAnaCosta.SGS.Seguranca.Model
{
    public partial class Funcionalidade : Entity
    {			
		/// <summary>
        /// Listar todos os registros
        /// </summary>
        public FuncionalidadeDataTable Sel(FuncionalidadeDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

			//Parametro pSEG_FUN_ID_FUNCIONALIDADE
			param.Add(Connection.CreateParameter("pSEG_FUN_ID_FUNCIONALIDADE", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

			//Parametro pSEG_FUN_DS_DESCRICAO
			param.Add(Connection.CreateParameter("pSEG_FUN_DS_DESCRICAO", dto.DsFuncionalidade.DBValue, ParameterDirection.Input, dto.DsFuncionalidade.DbType));

			//Parametro pSEG_FUN_FL_ITEM_MENU_OK
			param.Add(Connection.CreateParameter("pSEG_FUN_FL_ITEM_MENU_OK", dto.FlItemMenu.DBValue, ParameterDirection.Input, dto.FlItemMenu.DbType));

			//Parametro pSEG_FUN_ID_FUNCIONALIDADE_PAI
			param.Add(Connection.CreateParameter("pSEG_FUN_ID_FUNCIONALIDADE_PAI", dto.IdtFuncionalidadePai.DBValue, ParameterDirection.Input, dto.IdtFuncionalidadePai.DbType));

			//Parametro pSEG_FUN_DS_NOME_PAGINA
			param.Add(Connection.CreateParameter("pSEG_FUN_DS_NOME_PAGINA", dto.NmPagina.DBValue, ParameterDirection.Input, dto.NmPagina.DbType));

			//Parametro pSEG_FUN_NM_NOME
			param.Add(Connection.CreateParameter("pSEG_FUN_NM_NOME", dto.NmFuncionalidade.DBValue, ParameterDirection.Input, dto.NmFuncionalidade.DbType));

			//Parametro pSEG_MOD_ID_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.IdtModulo.DBValue, ParameterDirection.Input, dto.IdtModulo.DbType));

            //Parametro pSEG_ID_SISTEMA
            // param.Add(Connection.CreateParameter("pSEG_ID_SISTEMA", dto.IdtSistema.DBValue, ParameterDirection.Input, dto.IdtSistema.DbType));

            param.Add(Connection.CreateParameter("pFL_ASSOCIADOS", dto.FiltraAssociados.DBValue, ParameterDirection.Input, dto.FiltraAssociados.DbType));

            param.Add(Connection.CreateParameter("pSEG_PER_ID_PERFIL", dto.IdtPerfil.DBValue, ParameterDirection.Input, dto.IdtPerfil.DbType));

			#endregion	
			
			FuncionalidadeDataTable result = new FuncionalidadeDataTable();
			string query = "PRC_SEG_FUNCIONALIDADE_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}


		/// <summary>
        /// Listar o registro utilizando PK
        /// </summary>
        public FuncionalidadeDTO SelChave(FuncionalidadeDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());
			
			// Parametro pSEG_FUN_ID_FUNCIONALIDADE
			param.Add(Connection.CreateParameter("pSEG_FUN_ID_FUNCIONALIDADE", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			
			#endregion	
			
			FuncionalidadeDataTable result = new FuncionalidadeDataTable();
			string query = "PRC_SEG_FUNCIONALIDADE_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
   		    return result.TypedRow(0);
		}

		
		/// <summary>
        /// Exclui o registro
        /// </summary>        

		public void Del(FuncionalidadeDTO dto)
		{
  		    #region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pSEG_FUN_ID_FUNCIONALIDADE
			param.Add(Connection.CreateParameter("pSEG_FUN_ID_FUNCIONALIDADE", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
		
   	       #endregion				
			//Executa o procedimento
            
			string query = "PRC_SEG_FUNCIONALIDADE_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Altera o registro
        /// </summary>			
		public void Upd(FuncionalidadeDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pSEG_FUN_ID_FUNCIONALIDADE
			param.Add(Connection.CreateParameter("pSEG_FUN_ID_FUNCIONALIDADE", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pSEG_FUN_DS_DESCRICAO
			param.Add(Connection.CreateParameter("pSEG_FUN_DS_DESCRICAO", dto.DsFuncionalidade.DBValue, ParameterDirection.Input, dto.DsFuncionalidade.DbType));
			
			//Parametro pSEG_FUN_FL_ITEM_MENU_OK
			param.Add(Connection.CreateParameter("pSEG_FUN_FL_ITEM_MENU_OK", dto.FlItemMenu.DBValue, ParameterDirection.Input, dto.FlItemMenu.DbType));
			
			//Parametro pSEG_FUN_ID_FUNCIONALIDADE_PAI
			param.Add(Connection.CreateParameter("pSEG_FUN_ID_FUNCIONALIDADE_PAI", dto.IdtFuncionalidadePai.DBValue, ParameterDirection.Input, dto.IdtFuncionalidadePai.DbType));
			
			//Parametro pSEG_FUN_DS_NOME_PAGINA
			param.Add(Connection.CreateParameter("pSEG_FUN_DS_NOME_PAGINA", dto.NmPagina.DBValue, ParameterDirection.Input, dto.NmPagina.DbType));
			
			//Parametro pSEG_FUN_NM_NOME
			param.Add(Connection.CreateParameter("pSEG_FUN_NM_NOME", dto.NmFuncionalidade.DBValue, ParameterDirection.Input, dto.NmFuncionalidade.DbType));
			
			//Parametro pSEG_MOD_ID_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.IdtModulo.DBValue, ParameterDirection.Input, dto.IdtModulo.DbType));

            //Parametro pSEG_ID_SISTEMA
            // param.Add(Connection.CreateParameter("pSEG_ID_SISTEMA", dto.IdtSistema.DBValue, ParameterDirection.Input, dto.IdtSistema.DbType));

			
			#endregion	

			string query = "PRC_SEG_FUNCIONALIDADE_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Inclui o registro
        /// </summary>			
		public void Ins(FuncionalidadeDTO dto)
		{			
			string query = "PRC_SEG_FUNCIONALIDADE_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			
			//Parametro pSEG_FUN_ID_FUNCIONALIDADE
			param.Add(Connection.CreateParameter("pSEG_FUN_ID_FUNCIONALIDADE", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pSEG_FUN_DS_DESCRICAO
			param.Add(Connection.CreateParameter("pSEG_FUN_DS_DESCRICAO", dto.DsFuncionalidade.DBValue, ParameterDirection.Input, dto.DsFuncionalidade.DbType));
			
			//Parametro pSEG_FUN_FL_ITEM_MENU_OK
			param.Add(Connection.CreateParameter("pSEG_FUN_FL_ITEM_MENU_OK", dto.FlItemMenu.DBValue, ParameterDirection.Input, dto.FlItemMenu.DbType));
			
			//Parametro pSEG_FUN_ID_FUNCIONALIDADE_PAI
			param.Add(Connection.CreateParameter("pSEG_FUN_ID_FUNCIONALIDADE_PAI", dto.IdtFuncionalidadePai.DBValue, ParameterDirection.Input, dto.IdtFuncionalidadePai.DbType));
			
			//Parametro pSEG_FUN_DS_NOME_PAGINA
			param.Add(Connection.CreateParameter("pSEG_FUN_DS_NOME_PAGINA", dto.NmPagina.DBValue, ParameterDirection.Input, dto.NmPagina.DbType));
			
			//Parametro pSEG_FUN_NM_NOME
			param.Add(Connection.CreateParameter("pSEG_FUN_NM_NOME", dto.NmFuncionalidade.DBValue, ParameterDirection.Input, dto.NmFuncionalidade.DbType));
			
			//Parametro pSEG_MOD_ID_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.IdtModulo.DBValue, ParameterDirection.Input, dto.IdtModulo.DbType));

            //Parametro pSEG_ID_SISTEMA
            // param.Add(Connection.CreateParameter("pSEG_ID_SISTEMA", dto.IdtSistema.DBValue, ParameterDirection.Input, dto.IdtSistema.DbType));



            param.Add(Connection.CreateParameterSequence());
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
            dto.Idt.Value = Int32.Parse(param["pNewIdt"].Value.ToString());		

		}	
	}
}
