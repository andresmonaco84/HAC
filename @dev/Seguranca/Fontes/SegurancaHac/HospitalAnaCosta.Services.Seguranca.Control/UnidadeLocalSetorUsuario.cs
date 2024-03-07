
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.Services.Seguranca.DTO;
using HospitalAnaCosta.Services.Seguranca.Interface;

namespace HospitalAnaCosta.Services.Seguranca.Control
{
	public class UnidadeLocalSetorUsuario : Control, IUnidadeLocalSetorUsuario
	{
		private Model.UnidadeLocalSetorUsuario entity = new Model.UnidadeLocalSetorUsuario() ;

		/// <summary>
		/// Listar todos os registros
		/// </summary>
		public UnidadeLocalSetorUsuarioDataTable Listar(UnidadeLocalSetorUsuarioDTO dto)
		{
			return entity.Listar(dto);
		}

		/// <summary>
		/// Obter pela chave
		/// </summary>
		public UnidadeLocalSetorUsuarioDTO Pesquisar(UnidadeLocalSetorUsuarioDTO dto)
		{	
			return entity.Pesquisar(dto);
		}
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public UnidadeLocalSetorUsuarioDTO Incluir(UnidadeLocalSetorUsuarioDTO dto)
		{
            PassportDTO dtoPassport = (PassportDTO)Credential;
            dto.DataUltimaAtualizacao.Value = DateTime.Now;
            dto.IdtUsuarioAtualizadoPor.Value = dtoPassport.Usuario.Idt.Value;
            
			entity.Incluir(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Excluir(UnidadeLocalSetorUsuarioDTO dto)
		{
			entity.Excluir(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Alterar(UnidadeLocalSetorUsuarioDTO dto)
		{
            PassportDTO dtoPassport = (PassportDTO)Credential;
            dto.DataUltimaAtualizacao.Value = DateTime.Now;
            dto.IdtUsuarioAtualizadoPor.Value = dtoPassport.Usuario.Idt.Value;
		
			entity.Alterar(dto);
		}
	}
}
