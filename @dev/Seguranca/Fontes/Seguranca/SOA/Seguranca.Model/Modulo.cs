
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.Seguranca.DTO;

namespace HospitalAnaCosta.SGS.Seguranca.Model
{
	public partial class Modulo : Entity
	{			
		/// <summary>
		/// Listar todos os registros
		/// </summary>
		public ModuloDataTable Sel(ModuloDTO dto)
		{            
			#region "Parametros"
			DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
			param.Add(Connection.CreateParameterCursor());

			//Parametro pSEG_MOD_ID_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

			//Parametro pSEG_MOD_NM_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_NM_MODULO", dto.NmModulo.DBValue, ParameterDirection.Input, dto.NmModulo.DbType));

			//Parametro pSEG_MOD_DS_MODULO
			// param.Add(Connection.CreateParameter("pSEG_MOD_DS_MODULO", dto.DsModulo.DBValue, ParameterDirection.Input, dto.DsModulo.DbType));

			//Parametro pSEG_MOD_CD_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_CD_MODULO", dto.CdModulo.DBValue, ParameterDirection.Input, dto.CdModulo.DbType));

			//Parametro pSEG_MOD_DS_SISTEMA
			// param.Add(Connection.CreateParameter("pSEG_MOD_DS_SISTEMA", dto.DsSistema.DBValue, ParameterDirection.Input, dto.DsSistema.DbType));

			//Parametro pSEG_MOD_DS_VERSAO
			// param.Add(Connection.CreateParameter("pSEG_MOD_DS_VERSAO", dto.DsVersao.DBValue, ParameterDirection.Input, dto.DsVersao.DbType));

			//Parametro pSEG_MOD_DT_VERSAO
			// param.Add(Connection.CreateParameter("pSEG_MOD_DT_VERSAO", dto.DtVersao.DBValue, ParameterDirection.Input, dto.DtVersao.DbType));
			#endregion	
			
			ModuloDataTable result = new ModuloDataTable();
			string query = "PRC_SEG_MOD_MODULO_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
		/// Listar o registro utilizando PK
		/// </summary>
		public ModuloDTO SelChave(ModuloDTO dto)
		{            
			#region "Parametros"
			DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
			param.Add(Connection.CreateParameterCursor());
			
			// Parametro pSEG_MOD_ID_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			
			#endregion	
			
			ModuloDataTable result = new ModuloDataTable();
			string query = "PRC_SEG_MOD_MODULO_S";
			
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

		public void Del(ModuloDTO dto)
		{
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pSEG_MOD_ID_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
		
		   #endregion				
			//Executa o procedimento
			
			string query = "PRC_SEG_MOD_MODULO_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
		/// Altera o registro
		/// </summary>			
		public void Upd(ModuloDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pSEG_MOD_ID_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pSEG_MOD_NM_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_NM_MODULO", dto.NmModulo.DBValue, ParameterDirection.Input, dto.NmModulo.DbType));
			
			//Parametro pSEG_MOD_DS_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_DS_MODULO", dto.DsModulo.DBValue, ParameterDirection.Input, dto.DsModulo.DbType));
			
			//Parametro pSEG_MOD_CD_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_CD_MODULO", dto.CdModulo.DBValue, ParameterDirection.Input, dto.CdModulo.DbType));
			
			//Parametro pSEG_MOD_DS_SISTEMA
			param.Add(Connection.CreateParameter("pSEG_MOD_DS_SISTEMA", dto.DsSistema.DBValue, ParameterDirection.Input, dto.DsSistema.DbType));
			
			//Parametro pSEG_MOD_DS_VERSAO
			param.Add(Connection.CreateParameter("pSEG_MOD_DS_VERSAO", dto.DsVersao.DBValue, ParameterDirection.Input, dto.DsVersao.DbType));
			
			//Parametro pSEG_MOD_DT_VERSAO
			param.Add(Connection.CreateParameter("pSEG_MOD_DT_VERSAO", dto.DtVersao.DBValue, ParameterDirection.Input, dto.DtVersao.DbType));
			
			#endregion	

			string query = "PRC_SEG_MOD_MODULO_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
		/// Inclui o registro
		/// </summary>			
		public void Ins(ModuloDTO dto)
		{			
			string query = "PRC_SEG_MOD_MODULO_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro Sequence			
			param.Add(Connection.CreateParameterSequence());
			
			
			//Parametro pSEG_MOD_ID_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pSEG_MOD_NM_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_NM_MODULO", dto.NmModulo.DBValue, ParameterDirection.Input, dto.NmModulo.DbType));
			
			//Parametro pSEG_MOD_DS_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_DS_MODULO", dto.DsModulo.DBValue, ParameterDirection.Input, dto.DsModulo.DbType));
			
			//Parametro pSEG_MOD_CD_MODULO
			param.Add(Connection.CreateParameter("pSEG_MOD_CD_MODULO", dto.CdModulo.DBValue, ParameterDirection.Input, dto.CdModulo.DbType));
			
			//Parametro pSEG_MOD_DS_SISTEMA
			param.Add(Connection.CreateParameter("pSEG_MOD_DS_SISTEMA", dto.DsSistema.DBValue, ParameterDirection.Input, dto.DsSistema.DbType));
			
			//Parametro pSEG_MOD_DS_VERSAO
			param.Add(Connection.CreateParameter("pSEG_MOD_DS_VERSAO", dto.DsVersao.DBValue, ParameterDirection.Input, dto.DsVersao.DbType));
			
			//Parametro pSEG_MOD_DT_VERSAO
			param.Add(Connection.CreateParameter("pSEG_MOD_DT_VERSAO", dto.DtVersao.DBValue, ParameterDirection.Input, dto.DtVersao.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						
				
			//Recupera o valor da Sequence utilizado na procedure     
			
						
			   dto.Idt.Value = Int32.Parse(param["pNewIdt"].Value.ToString());
			

		}	
	}
}
