
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.Services.Seguranca.DTO;

namespace HospitalAnaCosta.Services.Seguranca.Model
{
	public partial class Modulo : Entity
	{			
		/// <summary>
		/// Listar todos os registros
		/// </summary>
		public ModuloDataTable Listar(ModuloDTO dto)
		{            
			#region "Parametros"
			DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
			param.Add(Connection.CreateParameterCursor());

			//Parametro pSEG_MOD_ID_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

			//Parametro pSEG_MOD_NM_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_NM_MODULO", dto.Nome.DBValue, ParameterDirection.Input, dto.Nome.DbType));

			//Parametro pSEG_MOD_DS_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_DS_MODULO", dto.Descricao.DBValue, ParameterDirection.Input, dto.Descricao.DbType));

			//Parametro pSEG_MOD_CD_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_CD_MODULO", dto.Codigo.DBValue, ParameterDirection.Input, dto.Codigo.DbType));

			//Parametro pSEG_MOD_DS_SISTEMA
			param.Add(Connection.CreateParameter("pSEG_MOD_DS_SISTEMA", dto.Sistema.DBValue, ParameterDirection.Input, dto.Sistema.DbType));

			//Parametro pSEG_MOD_DS_VERSAO
			param.Add(Connection.CreateParameter("pSEG_MOD_DS_VERSAO", dto.Versao.DBValue, ParameterDirection.Input, dto.Versao.DbType));

			//Parametro pSEG_MOD_DT_VERSAO
			param.Add(Connection.CreateParameter("pSEG_MOD_DT_VERSAO", dto.DataVersao.DBValue, ParameterDirection.Input, dto.DataVersao.DbType));
			#endregion	
			
			ModuloDataTable result = new ModuloDataTable();
			string query = "PRC_SEG_MOD_MODULO_R_L";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
		/// Listar o registro utilizando PK
		/// </summary>
		public ModuloDTO Pesquisar(ModuloDTO dto)
		{            
			#region "Parametros"
			DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
			param.Add(Connection.CreateParameterCursor());
			
			// Parametro pSEG_MOD_ID_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			
			#endregion	
			
			ModuloDataTable result = new ModuloDataTable();
			string query = "PRC_SEG_MOD_MODULO_R_S";
			
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

		public void Excluir(ModuloDTO dto)
		{
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pSEG_MOD_ID_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
		
		   #endregion				
			//Executa o procedimento
			
			string query = "PRC_SEG_MOD_MODULO_R_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
		/// Altera o registro
		/// </summary>			
		public void Alterar(ModuloDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pSEG_MOD_ID_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pSEG_MOD_NM_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_NM_MODULO", dto.Nome.DBValue, ParameterDirection.Input, dto.Nome.DbType));
			
			//Parametro pSEG_MOD_DS_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_DS_MODULO", dto.Descricao.DBValue, ParameterDirection.Input, dto.Descricao.DbType));
			
			//Parametro pSEG_MOD_CD_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_CD_MODULO", dto.Codigo.DBValue, ParameterDirection.Input, dto.Codigo.DbType));
			
			//Parametro pSEG_MOD_DS_SISTEMA
			param.Add(Connection.CreateParameter("pSEG_MOD_DS_SISTEMA", dto.Sistema.DBValue, ParameterDirection.Input, dto.Sistema.DbType));
			
			//Parametro pSEG_MOD_DS_VERSAO
			param.Add(Connection.CreateParameter("pSEG_MOD_DS_VERSAO", dto.Versao.DBValue, ParameterDirection.Input, dto.Versao.DbType));
			
			//Parametro pSEG_MOD_DT_VERSAO
			param.Add(Connection.CreateParameter("pSEG_MOD_DT_VERSAO", dto.DataVersao.DBValue, ParameterDirection.Input, dto.DataVersao.DbType));
			
			#endregion	

			string query = "PRC_SEG_MOD_MODULO_R_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
		/// Inclui o registro
		/// </summary>			
		public void Incluir(ModuloDTO dto)
		{			
			string query = "PRC_SEG_MOD_MODULO_R_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro Sequence			
			param.Add(Connection.CreateParameterSequence());
			
			
			//Parametro pSEG_MOD_ID_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pSEG_MOD_NM_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_NM_MODULO", dto.Nome.DBValue, ParameterDirection.Input, dto.Nome.DbType));
			
			//Parametro pSEG_MOD_DS_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_DS_MODULO", dto.Descricao.DBValue, ParameterDirection.Input, dto.Descricao.DbType));
			
			//Parametro pSEG_MOD_CD_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_CD_MODULO", dto.Codigo.DBValue, ParameterDirection.Input, dto.Codigo.DbType));
			
			//Parametro pSEG_MOD_DS_SISTEMA
			param.Add(Connection.CreateParameter("pSEG_MOD_DS_SISTEMA", dto.Sistema.DBValue, ParameterDirection.Input, dto.Sistema.DbType));
			
			//Parametro pSEG_MOD_DS_VERSAO
			param.Add(Connection.CreateParameter("pSEG_MOD_DS_VERSAO", dto.Versao.DBValue, ParameterDirection.Input, dto.Versao.DbType));
			
			//Parametro pSEG_MOD_DT_VERSAO
			param.Add(Connection.CreateParameter("pSEG_MOD_DT_VERSAO", dto.DataVersao.DBValue, ParameterDirection.Input, dto.DataVersao.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						
				
			//Recupera o valor da Sequence utilizado na procedure     
			
						
			   dto.Idt.Value = Int32.Parse(param["pNewIdt"].Value.ToString());
			

		}	
	}
}
