
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using System.Data;

namespace HospitalAnaCosta.SGS.Seguranca.Interface
{
	public interface IAssPerfilFuncionalidade
	{
		AssPerfilFuncionalidadeDataTable Sel(AssPerfilFuncionalidadeDTO dto);

		AssPerfilFuncionalidadeDTO Ins(AssPerfilFuncionalidadeDTO dto);

		void Del(AssPerfilFuncionalidadeDTO dto);
		
		void Upd(AssPerfilFuncionalidadeDTO dto);
		
		AssPerfilFuncionalidadeDTO SelChave(AssPerfilFuncionalidadeDTO dto);

        DataTable ListarUsuarioSistemaUnidadeModuloPerfilFuncionalidade(int? idtUsuario, int? idtSistema, int? idtUnidade, int? idtModulo, int? idtPerfil, int? idtFuncionalidade);
        
	}
}
