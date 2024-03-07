
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.Services.Seguranca.DTO;

namespace HospitalAnaCosta.Services.Seguranca.Interface
{
	public interface IModulo
	{
		ModuloDataTable Listar(ModuloDTO dto);

		ModuloDTO Incluir(ModuloDTO dto);

		void Excluir(ModuloDTO dto);
		
		void Alterar(ModuloDTO dto);
		
		ModuloDTO Pesquisar(ModuloDTO dto);

        PassportDTO GetPassport();
	}
}
