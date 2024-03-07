using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Seguranca.Interface;
using System.Data;


namespace HospitalAnaCosta.SGS.Seguranca.Control
{
    public class UsuarioFuncionalidade : Control, IUsuarioFuncionalidade
    {
        private Model.UsuarioFuncionalidade entity = new Model.UsuarioFuncionalidade();

        /// <summary>
        /// Obtém todas as funcionalidades, de todos os perfis, a que um usuário tem acesso.
        /// </summary>
        /// <param name="dtoSistema">Apenas informar o valor da propriedade Idt.</param>
        /// <param name="dtoAssPerfilUsuario">Somente as seguintes propriedades devem estar preenchidas: IdtModulo, IdtUnidade, IdtUsuario</param>
        /// <returns>Todas as funcionalidades a que o usuário tem acesso.</returns>
        public UsuarioFuncionalidadeDTO Obter(UsuarioFuncionalidadeDTO dto)
        {
            return entity.Obter(dto);
        }

    }
}
