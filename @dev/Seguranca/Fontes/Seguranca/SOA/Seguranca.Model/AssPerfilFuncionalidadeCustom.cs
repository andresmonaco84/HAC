
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.Seguranca.DTO;

namespace HospitalAnaCosta.SGS.Seguranca.Model
{
    public partial class AssPerfilFuncionalidade : Entity
    {			
		/// <summary>
        /// Listar todos os registros
        /// </summary>
        public DataTable ListarUsuarioSistemaUnidadeModuloPerfilFuncionalidade(int? idtUsuario, int? idtSistema, int? idtUnidade, int? idtModulo, int? idtPerfil, int? idtFuncionalidade)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());


            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", idtUsuario, ParameterDirection.Input, DbType.Int32));

            //Parametro pSEG_ID_SISTEMA
            param.Add(Connection.CreateParameter("pSEG_ID_SISTEMA", idtSistema, ParameterDirection.Input, DbType.Int32));

            //Parametro pSEG_PER_ID_PERFIL
            param.Add(Connection.CreateParameter("pSEG_PER_ID_PERFIL", idtPerfil, ParameterDirection.Input, DbType.Int32));

            //Parametro pSEG_MOD_ID_MODULO
            param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", idtModulo, ParameterDirection.Input, DbType.Int32));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", idtUnidade, ParameterDirection.Input, DbType.Int32));

            //Parametro pSEG_FUN_ID_FUNCIONALIDADE
            param.Add(Connection.CreateParameter("pSEG_FUN_ID_FUNCIONALIDADE", idtFuncionalidade, ParameterDirection.Input, DbType.Int32));

            #endregion

            DataTable result = new DataTable();
            string query = "PRC_SEG_PFU_PEU_S";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }
	}
}
