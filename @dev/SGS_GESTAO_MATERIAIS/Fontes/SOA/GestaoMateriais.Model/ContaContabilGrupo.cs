
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
	public partial class ContaContabilGrupo : Entity
	{			
		/// <summary>
		/// Listar todos os registros
		/// </summary>
		public ContaContabilGrupoDataTable Listar(ContaContabilGrupoDTO dto, byte trazerTodosGrupos)
		{            
			#region "Parametros"
			DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
			param.Add(Connection.CreateParameterCursor());

			//Parametro pCAD_MTMD_TIPO_MOV
			param.Add(Connection.CreateParameter("pCAD_MTMD_TIPO_MOV", dto.TipoMov.DBValue, ParameterDirection.Input, dto.TipoMov.DbType));

			//Parametro pCAD_MTMD_GRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.IdGrupo.DBValue, ParameterDirection.Input, dto.IdGrupo.DbType));

			//Parametro pCAD_MTMD_DT_INI_VIG
			param.Add(Connection.CreateParameter("pCAD_MTMD_DT_INI_VIG", dto.DataIni.DBValue, ParameterDirection.Input, dto.DataIni.DbType));

			//Parametro pCAD_MTMD_DT_FIM_VIG
			param.Add(Connection.CreateParameter("pCAD_MTMD_DT_FIM_VIG", dto.DataFim.DBValue, ParameterDirection.Input, dto.DataFim.DbType));

			//Parametro pCAD_MTMD_COD_COLIGADA
			param.Add(Connection.CreateParameter("pCAD_MTMD_COD_COLIGADA", dto.CodColigada.DBValue, ParameterDirection.Input, dto.CodColigada.DbType));

			//Parametro pCAD_SET_ID
			param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdSetor.DBValue, ParameterDirection.Input, dto.IdSetor.DbType));

			//Parametro pCAD_COD_CONTA_CRED
			param.Add(Connection.CreateParameter("pCAD_COD_CONTA_CRED", dto.ContaCredito.DBValue, ParameterDirection.Input, dto.ContaCredito.DbType));

			//Parametro pCAD_COD_CONTA_CRED_DESCRICAO
			param.Add(Connection.CreateParameter("pCAD_COD_CONTA_CRED_DESCRICAO", dto.ContaCreditoDescricao.DBValue, ParameterDirection.Input, dto.ContaCreditoDescricao.DbType));

			//Parametro pCAD_COD_CONTA_DEB
			param.Add(Connection.CreateParameter("pCAD_COD_CONTA_DEB", dto.ContaDebito.DBValue, ParameterDirection.Input, dto.ContaDebito.DbType));

			//Parametro pCAD_COD_CONTA_DEB_DESCRICAO
			param.Add(Connection.CreateParameter("pCAD_COD_CONTA_DEB_DESCRICAO", dto.ContaDebitoDescricao.DBValue, ParameterDirection.Input, dto.ContaDebitoDescricao.DbType));

			//Parametro pSEG_DT_ATUALIZACAO
			param.Add(Connection.CreateParameter("pSEG_DT_ATUALIZACAO", dto.DataAtualizacao.DBValue, ParameterDirection.Input, dto.DataAtualizacao.DbType));

			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdUsuario.DBValue, ParameterDirection.Input, dto.IdUsuario.DbType));

            //Parametro pTRAZER_TODOS_GRUPOS
            param.Add(Connection.CreateParameter("pTRAZER_TODOS_GRUPOS", trazerTodosGrupos, ParameterDirection.Input, DbType.Byte));
			#endregion	
			
			ContaContabilGrupoDataTable result = new ContaContabilGrupoDataTable();
			string query = "PRC_CAD_MTMD_CCONTAB_GRUPO_L";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
		/// Listar o registro utilizando PK
		/// </summary>
		public ContaContabilGrupoDTO Pesquisar(ContaContabilGrupoDTO dto)
		{            
			#region "Parametros"
			DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
			param.Add(Connection.CreateParameterCursor());
			
			// Parametro pCAD_MTMD_COD_COLIGADA
			param.Add(Connection.CreateParameter("pCAD_MTMD_COD_COLIGADA", dto.CodColigada.DBValue, ParameterDirection.Input, dto.CodColigada.DbType));
			
			// Parametro pCAD_MTMD_DT_INI_VIG
			param.Add(Connection.CreateParameter("pCAD_MTMD_DT_INI_VIG", dto.DataIni.DBValue, ParameterDirection.Input, dto.DataIni.DbType));
			
			// Parametro pCAD_MTMD_GRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.IdGrupo.DBValue, ParameterDirection.Input, dto.IdGrupo.DbType));
			
			// Parametro pCAD_MTMD_TIPO_MOV
			param.Add(Connection.CreateParameter("pCAD_MTMD_TIPO_MOV", dto.TipoMov.DBValue, ParameterDirection.Input, dto.TipoMov.DbType));
			
			// Parametro pCAD_SET_ID
			param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdSetor.DBValue, ParameterDirection.Input, dto.IdSetor.DbType));
			
			
			#endregion	
			
			ContaContabilGrupoDataTable result = new ContaContabilGrupoDataTable();
			string query = "PRC_CAD_MTMD_CCONTAB_GRUPO_S";
			
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

		public void Excluir(ContaContabilGrupoDTO dto)
		{
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pCAD_MTMD_COD_COLIGADA
			param.Add(Connection.CreateParameter("pCAD_MTMD_COD_COLIGADA", dto.CodColigada.DBValue, ParameterDirection.Input, dto.CodColigada.DbType));
			
			// Parametro pCAD_MTMD_DT_INI_VIG
			param.Add(Connection.CreateParameter("pCAD_MTMD_DT_INI_VIG", dto.DataIni.DBValue, ParameterDirection.Input, dto.DataIni.DbType));
			
			// Parametro pCAD_MTMD_GRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.IdGrupo.DBValue, ParameterDirection.Input, dto.IdGrupo.DbType));
			
			// Parametro pCAD_MTMD_TIPO_MOV
			param.Add(Connection.CreateParameter("pCAD_MTMD_TIPO_MOV", dto.TipoMov.DBValue, ParameterDirection.Input, dto.TipoMov.DbType));
			
			// Parametro pCAD_SET_ID
			param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdSetor.DBValue, ParameterDirection.Input, dto.IdSetor.DbType));
			
		
		   #endregion				
			//Executa o procedimento
			
			string query = "PRC_CAD_MTMD_CCONTAB_GRUPO_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
		/// Altera o registro
		/// </summary>			
		public void Alterar(ContaContabilGrupoDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pCAD_MTMD_TIPO_MOV
			param.Add(Connection.CreateParameter("pCAD_MTMD_TIPO_MOV", dto.TipoMov.DBValue, ParameterDirection.Input, dto.TipoMov.DbType));
			
			//Parametro pCAD_MTMD_GRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.IdGrupo.DBValue, ParameterDirection.Input, dto.IdGrupo.DbType));
			
			//Parametro pCAD_MTMD_DT_INI_VIG
			param.Add(Connection.CreateParameter("pCAD_MTMD_DT_INI_VIG", dto.DataIni.DBValue, ParameterDirection.Input, dto.DataIni.DbType));
			
			//Parametro pCAD_MTMD_DT_FIM_VIG
			param.Add(Connection.CreateParameter("pCAD_MTMD_DT_FIM_VIG", dto.DataFim.DBValue, ParameterDirection.Input, dto.DataFim.DbType));
			
			//Parametro pCAD_MTMD_COD_COLIGADA
			param.Add(Connection.CreateParameter("pCAD_MTMD_COD_COLIGADA", dto.CodColigada.DBValue, ParameterDirection.Input, dto.CodColigada.DbType));
			
			//Parametro pCAD_SET_ID
			param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdSetor.DBValue, ParameterDirection.Input, dto.IdSetor.DbType));
			
			//Parametro pCAD_COD_CONTA_CRED
			param.Add(Connection.CreateParameter("pCAD_COD_CONTA_CRED", dto.ContaCredito.DBValue, ParameterDirection.Input, dto.ContaCredito.DbType));
			
			//Parametro pCAD_COD_CONTA_CRED_DESCRICAO
			param.Add(Connection.CreateParameter("pCAD_COD_CONTA_CRED_DESCRICAO", dto.ContaCreditoDescricao.DBValue, ParameterDirection.Input, dto.ContaCreditoDescricao.DbType));
			
			//Parametro pCAD_COD_CONTA_DEB
			param.Add(Connection.CreateParameter("pCAD_COD_CONTA_DEB", dto.ContaDebito.DBValue, ParameterDirection.Input, dto.ContaDebito.DbType));
			
			//Parametro pCAD_COD_CONTA_DEB_DESCRICAO
			param.Add(Connection.CreateParameter("pCAD_COD_CONTA_DEB_DESCRICAO", dto.ContaDebitoDescricao.DBValue, ParameterDirection.Input, dto.ContaDebitoDescricao.DbType));
			
			//Parametro pSEG_DT_ATUALIZACAO
			param.Add(Connection.CreateParameter("pSEG_DT_ATUALIZACAO", dto.DataAtualizacao.DBValue, ParameterDirection.Input, dto.DataAtualizacao.DbType));
			
			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdUsuario.DBValue, ParameterDirection.Input, dto.IdUsuario.DbType));
			
			#endregion	

			string query = "PRC_CAD_MTMD_CCONTAB_GRUPO_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
		/// Inclui o registro
		/// </summary>			
		public void Incluir(ContaContabilGrupoDTO dto)
		{			
			string query = "PRC_CAD_MTMD_CCONTAB_GRUPO_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			
			//Parametro pCAD_MTMD_TIPO_MOV
			param.Add(Connection.CreateParameter("pCAD_MTMD_TIPO_MOV", dto.TipoMov.DBValue, ParameterDirection.Input, dto.TipoMov.DbType));
			
			//Parametro pCAD_MTMD_GRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.IdGrupo.DBValue, ParameterDirection.Input, dto.IdGrupo.DbType));
			
			//Parametro pCAD_MTMD_DT_INI_VIG
			param.Add(Connection.CreateParameter("pCAD_MTMD_DT_INI_VIG", dto.DataIni.DBValue, ParameterDirection.Input, dto.DataIni.DbType));
			
			//Parametro pCAD_MTMD_DT_FIM_VIG
			param.Add(Connection.CreateParameter("pCAD_MTMD_DT_FIM_VIG", dto.DataFim.DBValue, ParameterDirection.Input, dto.DataFim.DbType));
			
			//Parametro pCAD_MTMD_COD_COLIGADA
			param.Add(Connection.CreateParameter("pCAD_MTMD_COD_COLIGADA", dto.CodColigada.DBValue, ParameterDirection.Input, dto.CodColigada.DbType));
			
			//Parametro pCAD_SET_ID
			param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdSetor.DBValue, ParameterDirection.Input, dto.IdSetor.DbType));
			
			//Parametro pCAD_COD_CONTA_CRED
			param.Add(Connection.CreateParameter("pCAD_COD_CONTA_CRED", dto.ContaCredito.DBValue, ParameterDirection.Input, dto.ContaCredito.DbType));
			
			//Parametro pCAD_COD_CONTA_CRED_DESCRICAO
			param.Add(Connection.CreateParameter("pCAD_COD_CONTA_CRED_DESCRICAO", dto.ContaCreditoDescricao.DBValue, ParameterDirection.Input, dto.ContaCreditoDescricao.DbType));
			
			//Parametro pCAD_COD_CONTA_DEB
			param.Add(Connection.CreateParameter("pCAD_COD_CONTA_DEB", dto.ContaDebito.DBValue, ParameterDirection.Input, dto.ContaDebito.DbType));
			
			//Parametro pCAD_COD_CONTA_DEB_DESCRICAO
			param.Add(Connection.CreateParameter("pCAD_COD_CONTA_DEB_DESCRICAO", dto.ContaDebitoDescricao.DBValue, ParameterDirection.Input, dto.ContaDebitoDescricao.DbType));
			
			//Parametro pSEG_DT_ATUALIZACAO
			param.Add(Connection.CreateParameter("pSEG_DT_ATUALIZACAO", dto.DataAtualizacao.DBValue, ParameterDirection.Input, dto.DataAtualizacao.DbType));
			
			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdUsuario.DBValue, ParameterDirection.Input, dto.IdUsuario.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);				

		}

        public DataTable ObterContaRM(string conta)
        {
            DataTable result = new DataTable();
            string query = "SELECT CODCONTA,\n" +
                                  "DESCRICAO\n" +
                             "FROM CCONTA@RMDB\n" +
                            "WHERE CODCOLIGADA = 1 AND\n" +
                                  "CODCONTA = '" + conta + "'";

            //Se não for produção, não usar dblink RM
            if (Connection.ConnectionString.ToUpper().IndexOf("DESENV") > -1 ||
                Connection.ConnectionString.ToUpper().IndexOf("SGSDEV") > -1 ||
                Connection.ConnectionString.ToUpper().IndexOf("SGS2") > -1)
            {
                query = query.Replace("CCONTA@RMDB", "RM.CCONTA");                
            }

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }
	}
}