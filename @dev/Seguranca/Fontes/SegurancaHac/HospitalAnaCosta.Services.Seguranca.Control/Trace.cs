
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.Services.Seguranca.DTO;
using HospitalAnaCosta.Services.Seguranca.Interface;

namespace HospitalAnaCosta.Services.Seguranca.Control
{
	public class Trace : Control, ITrace
	{
		private Model.Trace entity = new Model.Trace() ;

		/// <summary>
		/// Listar todos os registros
		/// </summary>
		public TraceDataTable Listar(TraceDTO dto)
		{	
			return entity.Listar(dto);
		}

		/// <summary>
		/// Obter pela chave
		/// </summary>
		public TraceDTO Pesquisar(TraceDTO dto)
		{	
			return entity.Pesquisar(dto);
		}
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public TraceDTO Incluir(TraceDTO dto)
		{
			//PassportVO passportVO = (PassportVO)Credential;
			//dto.IdtUsuario.Value = passportVO.Usuario.Idt;

			entity.Incluir(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Excluir(TraceDTO dto)
		{
			entity.Excluir(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Alterar(TraceDTO dto)
		{
			//PassportVO passportVO = (PassportVO)Credential;
			//dto.IdtUsuario.Value = passportVO.Usuario.Idt;
		
			entity.Alterar(dto);
		}
	}
}
