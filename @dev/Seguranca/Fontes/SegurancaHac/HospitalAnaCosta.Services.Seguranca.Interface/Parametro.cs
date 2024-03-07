
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.Services.Seguranca.DTO;

namespace HospitalAnaCosta.Services.Seguranca.Interface
{
	public interface IParametro
	{
		ParametroDataTable Listar(ParametroDTO dto);

		ParametroDTO Incluir(ParametroDTO dto);

		void Excluir(ParametroDTO dto);
		
		void Alterar(ParametroDTO dto);
		
		ParametroDTO Pesquisar(ParametroDTO dto);
	}
}
