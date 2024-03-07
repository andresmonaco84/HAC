using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.Seguranca.DTO;

namespace HospitalAnaCosta.SGS.Seguranca.Model
{
    public partial class UsuarioFuncionalidade : Entity
    {

        /// <summary>
        /// Obtém todas as funcionalidades, de todos os perfis, a que um usuário tem acesso.
        /// </summary>
        /// <param name="dtoSistema">Apenas informar o valor da propriedade Idt.</param>
        /// <param name="dtoAssPerfilUsuario">Somente as seguintes propriedades devem estar preenchidas: IdtModulo, IdtUnidade, IdtUsuario</param>
        /// <returns>Todas as funcionalidades a que o usuário tem acesso.</returns>
        public UsuarioFuncionalidadeDTO Obter(UsuarioFuncionalidadeDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pSEG_MOD_ID_MODULO
            param.Add(Connection.CreateParameter("pSEG_MOD_ID_MODULO", dto.IdtModulo.DBValue, ParameterDirection.Input, dto.IdtModulo.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_FUN_DS_NOME_PAGINA", dto.NmPagina.DBValue, ParameterDirection.Input, dto.NmPagina.DbType));


            #endregion

            UsuarioFuncionalidadeDataTable result = new UsuarioFuncionalidadeDataTable();
            string query = "PRC_SEG_USR_FUNCIONALIDADES";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
            //if (result.Rows.Count > 1)
            //{
            //    throw new Exception("Retornou mais que 1 item para pesquisa de funcionalidade");
            //}
            if (result.Rows.Count == 0)
            {
                return null;
            }
            return result.TypedRow(0);
        }

    }
}
