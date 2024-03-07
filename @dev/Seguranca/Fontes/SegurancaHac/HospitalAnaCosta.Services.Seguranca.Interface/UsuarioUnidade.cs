
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.Services.Seguranca.DTO;

namespace HospitalAnaCosta.Services.Seguranca.Interface
{
	public interface IUsuarioUnidade
	{
		UsuarioUnidadeDataTable Listar(UsuarioUnidadeDTO dto);

		UsuarioUnidadeDTO Incluir(UsuarioUnidadeDTO dto);

		void Excluir(UsuarioUnidadeDTO dto);
		
		UsuarioUnidadeDTO Pesquisar(UsuarioUnidadeDTO dto);
	}
}
