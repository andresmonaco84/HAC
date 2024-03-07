
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.Services.Seguranca.DTO;

namespace HospitalAnaCosta.Services.Seguranca.Interface
{
	public interface ILogErros
	{
		LogErrosDataTable Listar(LogErrosDTO dto);

		LogErrosDTO Incluir(LogErrosDTO dto);

		void Excluir(LogErrosDTO dto);
		
		void Alterar(LogErrosDTO dto);
		
		LogErrosDTO Pesquisar(LogErrosDTO dto);
	}
}
