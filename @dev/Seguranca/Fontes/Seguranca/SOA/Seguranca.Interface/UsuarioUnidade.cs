
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Seguranca.DTO;

namespace HospitalAnaCosta.SGS.Seguranca.Interface
{
	public interface IUsuarioUnidade
	{
        /// <summary>
        /// Obtem Unidades Relacionadas ao Usiário
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
		UsuarioUnidadeDataTable Sel(UsuarioUnidadeDTO dto);

		UsuarioUnidadeDTO Ins(UsuarioUnidadeDTO dto);

		void Del(UsuarioUnidadeDTO dto);
			
		UsuarioUnidadeDTO SelChave(UsuarioUnidadeDTO dto);
	}
}
