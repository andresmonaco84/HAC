
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.Services.Seguranca.DTO;

namespace HospitalAnaCosta.Services.Seguranca.Interface
{
	public interface IPerfil
	{
		PerfilDataTable Listar(PerfilDTO dto);

		PerfilDTO Incluir(PerfilDTO dto);

		void Excluir(PerfilDTO dto);
		
		void Alterar(PerfilDTO dto);
		
		PerfilDTO Pesquisar(PerfilDTO dto);
	}
}
