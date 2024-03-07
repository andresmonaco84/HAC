using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Seguranca.DTO;

namespace HospitalAnaCosta.SGS.Seguranca.Interface
{
	public interface IModuloPerfil
	{
		ModuloPerfilDataTable Listar(ModuloPerfilDTO dto);

		ModuloPerfilDTO Incluir(ModuloPerfilDTO dto);

		void Excluir(ModuloPerfilDTO dto);
		
		void Alterar(ModuloPerfilDTO dto);
		
		ModuloPerfilDTO Pesquisar(ModuloPerfilDTO dto);
	}
}
