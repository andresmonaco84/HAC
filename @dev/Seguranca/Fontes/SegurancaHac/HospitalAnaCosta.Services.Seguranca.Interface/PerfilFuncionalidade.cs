
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.Services.Seguranca.DTO;

namespace HospitalAnaCosta.Services.Seguranca.Interface
{
	public interface IPerfilFuncionalidade
	{
		PerfilFuncionalidadeDataTable Listar(PerfilFuncionalidadeDTO dto);

		PerfilFuncionalidadeDTO Incluir(PerfilFuncionalidadeDTO dto);

		void Excluir(PerfilFuncionalidadeDTO dto);
		
		PerfilFuncionalidadeDTO Pesquisar(PerfilFuncionalidadeDTO dto);
	}
}
