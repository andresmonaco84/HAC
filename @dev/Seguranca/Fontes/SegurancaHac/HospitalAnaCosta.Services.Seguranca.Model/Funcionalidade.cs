
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.Services.Seguranca.DTO;

namespace HospitalAnaCosta.Services.Seguranca.Model
{
	public partial class Funcionalidade : Entity
	{			
		/// <summary>
		/// Listar todos os registros
		/// </summary>
		public FuncionalidadeDataTable Listar(FuncionalidadeDTO dto)
		{            
			#region "Parametros"
			DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
			param.Add(Connection.CreateParameterCursor());

			//Parametro pSEG_FUN_ID_FUNCIONALIDADE
			param.Add(Connection.CreateParameter("pSEG_FUN_ID_FUNCIONALIDADE", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

			//Parametro pSEG_FUN_DS_DESCRICAO
			param.Add(Connection.CreateParameter("pSEG_FUN_DS_DESCRICAO", dto.Descricao.DBValue, ParameterDirection.Input, dto.Descricao.DbType));

			//Parametro pSEG_FUN_FL_ITEM_MENU_OK
			param.Add(Connection.CreateParameter("pSEG_FUN_FL_ITEM_MENU_OK", dto.FlagItemMenu.DBValue, ParameterDirection.Input, dto.FlagItemMenu.DbType));

			//Parametro pSEG_FUN_ID_FUNCIONALIDADE_PAI
			param.Add(Connection.CreateParameter("pSEG_FUN_ID_FUNCIONALIDADE_PAI", dto.IdtFuncionalidadePai.DBValue, ParameterDirection.Input, dto.IdtFuncionalidadePai.DbType));

			//Parametro pSEG_FUN_DS_NOME_PAGINA
			param.Add(Connection.CreateParameter("pSEG_FUN_DS_NOME_PAGINA", dto.NomePagina.DBValue, ParameterDirection.Input, dto.NomePagina.DbType));

			//Parametro pSEG_FUN_NM_NOME
			param.Add(Connection.CreateParameter("pSEG_FUN_NM_NOME", dto.Nome.DBValue, ParameterDirection.Input, dto.Nome.DbType));

			//Parametro pSEG_MOD_ID_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.IdtModulo.DBValue, ParameterDirection.Input, dto.IdtModulo.DbType));
			#endregion	
			
			FuncionalidadeDataTable result = new FuncionalidadeDataTable();
			string query = "PRC_SEG_FUN_FUNCIONALID_R_L";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
		/// Listar o registro utilizando PK
		/// </summary>
		public FuncionalidadeDTO Pesquisar(FuncionalidadeDTO dto)
		{            
			#region "Parametros"
			DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
			param.Add(Connection.CreateParameterCursor());
			
			// Parametro pSEG_FUN_ID_FUNCIONALIDADE
			param.Add(Connection.CreateParameter("pSEG_FUN_ID_FUNCIONALIDADE", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			
			#endregion	
			
			FuncionalidadeDataTable result = new FuncionalidadeDataTable();
			string query = "PRC_SEG_FUN_FUNCIONALID_R_S";
			
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

		public void Excluir(FuncionalidadeDTO dto)
		{
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pSEG_FUN_ID_FUNCIONALIDADE
			param.Add(Connection.CreateParameter("pSEG_FUN_ID_FUNCIONALIDADE", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
		
		   #endregion				
			//Executa o procedimento
			
			string query = "PRC_SEG_FUN_FUNCIONALID_R_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
		/// Altera o registro
		/// </summary>			
		public void Alterar(FuncionalidadeDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pSEG_FUN_ID_FUNCIONALIDADE
			param.Add(Connection.CreateParameter("pSEG_FUN_ID_FUNCIONALIDADE", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pSEG_FUN_DS_DESCRICAO
			param.Add(Connection.CreateParameter("pSEG_FUN_DS_DESCRICAO", dto.Descricao.DBValue, ParameterDirection.Input, dto.Descricao.DbType));
			
			//Parametro pSEG_FUN_FL_ITEM_MENU_OK
			param.Add(Connection.CreateParameter("pSEG_FUN_FL_ITEM_MENU_OK", dto.FlagItemMenu.DBValue, ParameterDirection.Input, dto.FlagItemMenu.DbType));
			
			//Parametro pSEG_FUN_ID_FUNCIONALIDADE_PAI
			param.Add(Connection.CreateParameter("pSEG_FUN_ID_FUNCIONALIDADE_PAI", dto.IdtFuncionalidadePai.DBValue, ParameterDirection.Input, dto.IdtFuncionalidadePai.DbType));
			
			//Parametro pSEG_FUN_DS_NOME_PAGINA
			param.Add(Connection.CreateParameter("pSEG_FUN_DS_NOME_PAGINA", dto.NomePagina.DBValue, ParameterDirection.Input, dto.NomePagina.DbType));
			
			//Parametro pSEG_FUN_NM_NOME
			param.Add(Connection.CreateParameter("pSEG_FUN_NM_NOME", dto.Nome.DBValue, ParameterDirection.Input, dto.Nome.DbType));
			
			//Parametro pSEG_MOD_ID_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.IdtModulo.DBValue, ParameterDirection.Input, dto.IdtModulo.DbType));
			
			#endregion	

			string query = "PRC_SEG_FUN_FUNCIONALID_R_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
		/// Inclui o registro
		/// </summary>			
		public void Incluir(FuncionalidadeDTO dto)
		{			
			string query = "PRC_SEG_FUN_FUNCIONALID_R_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro Sequence			
			param.Add(Connection.CreateParameterSequence());
			
			
			//Parametro pSEG_FUN_ID_FUNCIONALIDADE
			param.Add(Connection.CreateParameter("pSEG_FUN_ID_FUNCIONALIDADE", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pSEG_FUN_DS_DESCRICAO
			param.Add(Connection.CreateParameter("pSEG_FUN_DS_DESCRICAO", dto.Descricao.DBValue, ParameterDirection.Input, dto.Descricao.DbType));
			
			//Parametro pSEG_FUN_FL_ITEM_MENU_OK
			param.Add(Connection.CreateParameter("pSEG_FUN_FL_ITEM_MENU_OK", dto.FlagItemMenu.DBValue, ParameterDirection.Input, dto.FlagItemMenu.DbType));
			
			//Parametro pSEG_FUN_ID_FUNCIONALIDADE_PAI
			param.Add(Connection.CreateParameter("pSEG_FUN_ID_FUNCIONALIDADE_PAI", dto.IdtFuncionalidadePai.DBValue, ParameterDirection.Input, dto.IdtFuncionalidadePai.DbType));
			
			//Parametro pSEG_FUN_DS_NOME_PAGINA
			param.Add(Connection.CreateParameter("pSEG_FUN_DS_NOME_PAGINA", dto.NomePagina.DBValue, ParameterDirection.Input, dto.NomePagina.DbType));
			
			//Parametro pSEG_FUN_NM_NOME
			param.Add(Connection.CreateParameter("pSEG_FUN_NM_NOME", dto.Nome.DBValue, ParameterDirection.Input, dto.Nome.DbType));
			
			//Parametro pSEG_MOD_ID_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.IdtModulo.DBValue, ParameterDirection.Input, dto.IdtModulo.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						
				
			//Recupera o valor da Sequence utilizado na procedure     
			
						
			   dto.Idt.Value = Int32.Parse(param["pNewIdt"].Value.ToString());
			

		}

        /// <summary>
        /// Lista as Funcionalidades pertencentes aos Perfis (Ativos) associados ao 
        /// Usuário logado em uma determinada Unidade (Ativa).
        /// </summary>
        /// <param name="idtUnidade"></param>
        /// <param name="dtoUsuario"></param>
        /// <returns>DataTable de funcionalidades permitidas ao usuário</returns>
        public FuncionalidadeDataTable ListarPorUsuarioUnidade(decimal idtUnidade, UsuarioDTO dtoUsuario)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", idtUnidade, ParameterDirection.Input, DbType.Decimal));

            //Parametro pSEG_USU_DS_NOME
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dtoUsuario.Idt.DBValue, ParameterDirection.Input, dtoUsuario.Idt.DbType));

            //Parametro pSEG_USU_DS_NOME
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dtoUsuario.Idt.DBValue, ParameterDirection.Input, dtoUsuario.Idt.DbType));

            #endregion

            FuncionalidadeDataTable result = new FuncionalidadeDataTable();
            string query = "PRC_SEG_FUN_FUNC_POR_USU_R_S";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }



        /// <summary>
        /// Lista as Funcionalidades existentes para um determinado Módulo e que tiver os módulos forem nulos
        /// </summary>
        /// <param name="idtUnidade"></param>
        /// <param name="dtoUsuario"></param>
        /// <returns>DataTable de funcionalidades permitidas ao usuário</returns>
        public FuncionalidadeDataTable ListarPorModulo(decimal idtModulo)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", idtModulo, ParameterDirection.Input, DbType.Decimal));

            #endregion

            FuncionalidadeDataTable result = new FuncionalidadeDataTable();
            string query = "PRC_SEG_FUN_FUNC_POR_MOD_R_S";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }
        


	}
}
