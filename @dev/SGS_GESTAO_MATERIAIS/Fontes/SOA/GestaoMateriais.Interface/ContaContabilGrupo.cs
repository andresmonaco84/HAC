
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
	public interface IContaContabilGrupo
	{
        ContaContabilGrupoDataTable Listar(ContaContabilGrupoDTO dto, byte trazerTodosGrupos);

		ContaContabilGrupoDTO Incluir(ContaContabilGrupoDTO dto);

		void Excluir(ContaContabilGrupoDTO dto);
		
		void Alterar(ContaContabilGrupoDTO dto);
		
		ContaContabilGrupoDTO Pesquisar(ContaContabilGrupoDTO dto);

        string ObterDescricaoContaRM(string conta);
	}
}
