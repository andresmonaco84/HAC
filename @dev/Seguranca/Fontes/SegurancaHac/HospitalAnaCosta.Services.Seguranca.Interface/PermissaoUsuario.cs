
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.Services.Seguranca.DTO;

namespace HospitalAnaCosta.Services.Seguranca.Interface
{
	public interface IPermissaoUsuario
	{
		PermissaoUsuarioDataTable Listar(PermissaoUsuarioDTO dto);

		PermissaoUsuarioDTO Incluir(PermissaoUsuarioDTO dto);

		void Excluir(PermissaoUsuarioDTO dto);
		
		PermissaoUsuarioDTO Pesquisar(PermissaoUsuarioDTO dto);
	}
}
