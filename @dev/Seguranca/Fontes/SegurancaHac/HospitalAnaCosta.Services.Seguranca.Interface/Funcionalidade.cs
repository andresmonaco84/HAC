
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.Services.Seguranca.DTO;

namespace HospitalAnaCosta.Services.Seguranca.Interface
{
	public interface IFuncionalidade
	{
		FuncionalidadeDataTable Listar(FuncionalidadeDTO dto);

		FuncionalidadeDTO Incluir(FuncionalidadeDTO dto);

		void Excluir(FuncionalidadeDTO dto);
		
		void Alterar(FuncionalidadeDTO dto);
		
		FuncionalidadeDTO Pesquisar(FuncionalidadeDTO dto);

        FuncionalidadeDataTable ListarPorUsuarioUnidade(decimal idtUnidade, UsuarioDTO dtoUsuario, decimal idtModulo);

        FuncionalidadeDataTable ListarPorModulo(decimal idtModulo);

        FuncionalidadeDataTable ListarPorUsuario(UsuarioDTO dtoUsuario, decimal? idtModulo);
        
	}
}
