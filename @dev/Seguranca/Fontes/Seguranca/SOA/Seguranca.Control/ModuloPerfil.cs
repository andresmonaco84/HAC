
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Seguranca.Interface;

namespace HospitalAnaCosta.SGS.Seguranca.Control
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
			//PassportDTO passportVO = (PassportDTO)Credential;
            //dto.DataUltimaAtualizacao.Value = DateTime.Now;
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
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Alterar(ModuloPerfilDTO dto)
		{
			//PassportDTO passportVO = (PassportDTO)Credential;
            //dto.DataUltimaAtualizacao.Value = DateTime.Now;
			//dto.IdtUsuario.Value = passportVO.Usuario.Idt;
		
			entity.Alterar(dto);
		}
	}
}
