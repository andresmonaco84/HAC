
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.Services.Seguranca.DTO;
using HospitalAnaCosta.Services.Seguranca.Interface;

namespace HospitalAnaCosta.Services.Seguranca.Control
{
	public class Perfil : Control, IPerfil
	{
		private Model.Perfil entity = new Model.Perfil() ;

		/// <summary>
		/// Listar todos os registros
		/// </summary>
		public PerfilDataTable Listar(PerfilDTO dto)
		{	
			return entity.Listar(dto);
		}

		/// <summary>
		/// Obter pela chave
		/// </summary>
		public PerfilDTO Pesquisar(PerfilDTO dto)
		{	
			return entity.Pesquisar(dto);
		}
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public PerfilDTO Incluir(PerfilDTO dto)
		{
            PassportDTO dtoPassport = (PassportDTO)Credential;
            dto.DataAtualizacao.Value = DateTime.Now;
            dto.IdtUsuario.Value = dtoPassport.Usuario.Idt.Value;

			entity.Incluir(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Excluir(PerfilDTO dto)
		{
			entity.Excluir(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Alterar(PerfilDTO dto)
		{
            PassportDTO dtoPassport = (PassportDTO)Credential;
            dto.DataAtualizacao.Value = DateTime.Now;
            dto.IdtUsuario.Value = dtoPassport.Usuario.Idt.Value;
		
			entity.Alterar(dto);
		}
	}
}
