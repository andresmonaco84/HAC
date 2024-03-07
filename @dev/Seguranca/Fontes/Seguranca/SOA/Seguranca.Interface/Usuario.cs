
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using System.Data;

namespace HospitalAnaCosta.SGS.Seguranca.Interface
{
	public interface IUsuario
	{
		UsuarioDataTable Sel(UsuarioDTO dto);

        DataTable buscaPorNome(UsuarioDTO dto);

		UsuarioDTO Ins(UsuarioDTO dto);

		void Del(UsuarioDTO dto);
		
		void Upd(UsuarioDTO dto);
		
		UsuarioDTO SelChave(UsuarioDTO dto);

        UsuarioDTO Gravar(UsuarioDTO dto);

        void AtribuirSenhaPadrao(UsuarioDTO dto);

        string GeraToken(string usuario, bool recuperar, bool alterar);
	}
}