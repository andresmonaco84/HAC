
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Seguranca.DTO;

namespace HospitalAnaCosta.SGS.Seguranca.Interface
{
	public interface IUnidadeLocalSetorUsuario
	{
		UnidadeLocalSetorUsuarioDataTable Sel(UnidadeLocalSetorUsuarioDTO dto);

		UnidadeLocalSetorUsuarioDTO Ins(UnidadeLocalSetorUsuarioDTO dto);

		void Del(UnidadeLocalSetorUsuarioDTO dto);
		
		void Upd(UnidadeLocalSetorUsuarioDTO dto);
		
		UnidadeLocalSetorUsuarioDTO SelChave(UnidadeLocalSetorUsuarioDTO dto);

        UnidadeLocalSetorUsuarioDataTable UsuarioPorSetor(UnidadeLocalSetorUsuarioDTO dto);

        UnidadeLocalSetorUsuarioDataTable AssociarSetorUsuario(UnidadeLocalSetorUsuarioDTO dto);

        System.Data.DataTable ObterAcessoUsuarioSetor(UnidadeLocalSetorUsuarioDTO dto);
	}
}
