
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.Services.Seguranca.DTO;
using HospitalAnaCosta.Services.Seguranca.Interface;

namespace HospitalAnaCosta.Services.Seguranca.Control
{
	public class ModuloPerfil : Control, IModuloPerfil
	{
		private Model.ModuloPerfil entity = new Model.ModuloPerfil() ;

		/// <summary>
		/// Listar todos os registros
		/// </summary>
		public ModuloPerfilDataTable Listar(ModuloPerfilDTO dto)
		{	
			return entity.Listar(dto);
		}

		/// <summary>
		/// Obter pela chave
		/// </summary>
		public ModuloPerfilDTO Pesquisar(ModuloPerfilDTO dto)
		{	
			return entity.Pesquisar(dto);
		}
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public ModuloPerfilDTO Incluir(ModuloPerfilDTO dto)
		{
			//PassportVO passportVO = (PassportVO)Credential;
			//dto.IdtUsuario.Value = passportVO.Usuario.Idt;

			entity.Incluir(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Excluir(ModuloPerfilDTO dto)
		{
			entity.Excluir(dto);
		}
		
	}
}
