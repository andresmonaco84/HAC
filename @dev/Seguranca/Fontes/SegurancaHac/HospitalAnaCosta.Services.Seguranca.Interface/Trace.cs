
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.Services.Seguranca.DTO;

namespace HospitalAnaCosta.Services.Seguranca.Interface
{
	public interface ITrace
	{
		TraceDataTable Listar(TraceDTO dto);

		TraceDTO Incluir(TraceDTO dto);

		void Excluir(TraceDTO dto);
		
		void Alterar(TraceDTO dto);
		
		TraceDTO Pesquisar(TraceDTO dto);
	}
}
