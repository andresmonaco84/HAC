
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
        /// Lista as Funcionalidades pertencentes aos Perfis (Ativos) associados ao 
        /// Usuário logado em uma determinada Unidade (Ativa).
        /// </summary>
        /// <param name="idtUnidade"></param>
        /// <param name="dtoUsuario"></param>
        /// <returns>DataTable de funcionalidades permitidas ao usuário</returns>
        public FuncionalidadeDataTable ListarPorUsuarioUnidade(decimal idtUnidade, UsuarioDTO dtoUsuario, decimal idtModulo)
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
            param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", idtModulo, ParameterDirection.Input, DbType.Decimal));

            #endregion

            FuncionalidadeDataTable result = new FuncionalidadeDataTable();
            string query = "PRC_SEG_FUN_FUNC_POR_USU_R_S";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }

        public FuncionalidadeDataTable ListarPorUsuario(UsuarioDTO dtoUsuario, decimal? idtModulo)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

           

            //Parametro pSEG_USU_DS_NOME
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dtoUsuario.Idt.DBValue, ParameterDirection.Input, dtoUsuario.Idt.DbType));

            //Parametro pSEG_USU_DS_NOME
            if(idtModulo != null)
            param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", idtModulo, ParameterDirection.Input, DbType.Decimal));

            #endregion

            FuncionalidadeDataTable result = new FuncionalidadeDataTable();
            string query = "PRC_SEG_FUN_FUNC_USU_R_S";

            //Executa o procedimento
            try
            {
                Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                
                throw;
            }
            

            return result;
        }

    }
}