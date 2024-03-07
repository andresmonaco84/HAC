
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.Services.Seguranca.DTO;

namespace HospitalAnaCosta.Services.Seguranca.Interface
{
	public interface IModuloPerfil
	{
		ModuloPerfilDataTable Listar(ModuloPerfilDTO dto);

		ModuloPerfilDTO Incluir(ModuloPerfilDTO dto);

		void Excluir(ModuloPerfilDTO dto);
		
		ModuloPerfilDTO Pesquisar(ModuloPerfilDTO dto);
	}
}
