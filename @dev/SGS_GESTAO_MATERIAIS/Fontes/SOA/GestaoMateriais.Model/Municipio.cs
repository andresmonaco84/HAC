
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class Municipio : Entity
    {			
		/// <summary>
        /// Listar todos os registros
        /// </summary>
        public MunicipioDataTable Listar(MunicipioDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

			//Parametro pAUX_MUN_CD_IBGE
			param.Add(Connection.CreateParameter("pAUX_MUN_CD_IBGE", dto.CodigoIBGE.DBValue, ParameterDirection.Input, dto.CodigoIBGE.DbType));

			//Parametro pAUX_MUN_SG_UF
			param.Add(Connection.CreateParameter("pAUX_MUN_SG_UF", dto.SiglaUF.DBValue, ParameterDirection.Input, dto.SiglaUF.DbType));

			//Parametro pAUX_MUN_NM_MUNICIPIO
			param.Add(Connection.CreateParameter("pAUX_MUN_NM_MUNICIPIO", dto.NomeMunicipio.DBValue, ParameterDirection.Input, dto.NomeMunicipio.DbType));
			#endregion	
			
			MunicipioDataTable result = new MunicipioDataTable();
			string query = "PRC_AUX_MUN_MUNICIPIO_RMT_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
        /// Listar o registro utilizando PK
        /// </summary>
        public MunicipioDTO Pesquisar(MunicipioDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());
			
			// Parametro pAUX_MUN_CD_IBGE
			param.Add(Connection.CreateParameter("pAUX_MUN_CD_IBGE", dto.CodigoIBGE.DBValue, ParameterDirection.Input, dto.CodigoIBGE.DbType));
			
			
			#endregion	
			
			MunicipioDataTable result = new MunicipioDataTable();
			string query = "PRC_AUX_MUN_MUNICIPIO_RMT_SID";
			
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

		public void Excluir(MunicipioDTO dto)
		{
  		    #region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pAUX_MUN_CD_IBGE
			param.Add(Connection.CreateParameter("pAUX_MUN_CD_IBGE", dto.CodigoIBGE.DBValue, ParameterDirection.Input, dto.CodigoIBGE.DbType));
			
		
   	       #endregion				
			//Executa o procedimento
            
			string query = "PRC_AUX_MUN_MUNICIPIO_RMT_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Altera o registro
        /// </summary>			
		public void Alterar(MunicipioDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pAUX_MUN_CD_IBGE
			param.Add(Connection.CreateParameter("pAUX_MUN_CD_IBGE", dto.CodigoIBGE.DBValue, ParameterDirection.Input, dto.CodigoIBGE.DbType));
			
			//Parametro pAUX_MUN_SG_UF
			param.Add(Connection.CreateParameter("pAUX_MUN_SG_UF", dto.SiglaUF.DBValue, ParameterDirection.Input, dto.SiglaUF.DbType));
			
			//Parametro pAUX_MUN_NM_MUNICIPIO
			param.Add(Connection.CreateParameter("pAUX_MUN_NM_MUNICIPIO", dto.NomeMunicipio.DBValue, ParameterDirection.Input, dto.NomeMunicipio.DbType));
			
			#endregion	

			string query = "PRC_AUX_MUN_MUNICIPIO_RMT_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Inclui o registro
        /// </summary>			
		public void Incluir(MunicipioDTO dto)
		{			
			string query = "PRC_AUX_MUN_MUNICIPIO_RMT_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			
			//Parametro pAUX_MUN_CD_IBGE
			param.Add(Connection.CreateParameter("pAUX_MUN_CD_IBGE", dto.CodigoIBGE.DBValue, ParameterDirection.Input, dto.CodigoIBGE.DbType));
			
			//Parametro pAUX_MUN_SG_UF
			param.Add(Connection.CreateParameter("pAUX_MUN_SG_UF", dto.SiglaUF.DBValue, ParameterDirection.Input, dto.SiglaUF.DbType));
			
			//Parametro pAUX_MUN_NM_MUNICIPIO
			param.Add(Connection.CreateParameter("pAUX_MUN_NM_MUNICIPIO", dto.NomeMunicipio.DBValue, ParameterDirection.Input, dto.NomeMunicipio.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						

		}	
	}
}
