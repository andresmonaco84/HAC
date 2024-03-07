
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.Services.Seguranca.DTO;
using HospitalAnaCosta.Services.Seguranca.Interface;

namespace HospitalAnaCosta.Services.Seguranca.Control
{
	public class LogErros : Control, ILogErros
	{
		private Model.LogErros entity = new Model.LogErros() ;

		/// <summary>
		/// Listar todos os registros
		/// </summary>
		public LogErrosDataTable Listar(LogErrosDTO dto)
		{	
			return entity.Listar(dto);
		}

		/// <summary>
		/// Obter pela chave
		/// </summary>
		public LogErrosDTO Pesquisar(LogErrosDTO dto)
		{	
			return entity.Pesquisar(dto);
		}
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public LogErrosDTO Incluir(LogErrosDTO dto)
		{
            PassportDTO dtoPassport = (PassportDTO)Credential;
            dto.Data.Value = DateTime.Now;
            dto.IdtUsuario.Value = dtoPassport.Usuario.Idt.Value;

			entity.Incluir(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Excluir(LogErrosDTO dto)
		{
			entity.Excluir(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Alterar(LogErrosDTO dto)
		{
            PassportDTO dtoPassport = (PassportDTO)Credential;
            dto.Data.Value = DateTime.Now;
            dto.IdtUsuario.Value = dtoPassport.Usuario.Idt.Value;
		
			entity.Alterar(dto);
		}
	}
}
