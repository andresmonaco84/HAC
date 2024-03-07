
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.Services.Seguranca.DTO;

namespace HospitalAnaCosta.Services.Seguranca.Interface
{
	public interface IUnidadeLocalSetorUsuario
	{
		UnidadeLocalSetorUsuarioDataTable Listar(UnidadeLocalSetorUsuarioDTO dto);

		UnidadeLocalSetorUsuarioDTO Incluir(UnidadeLocalSetorUsuarioDTO dto);

		void Excluir(UnidadeLocalSetorUsuarioDTO dto);
		
		void Alterar(UnidadeLocalSetorUsuarioDTO dto);
		
		UnidadeLocalSetorUsuarioDTO Pesquisar(UnidadeLocalSetorUsuarioDTO dto);
	}
}
