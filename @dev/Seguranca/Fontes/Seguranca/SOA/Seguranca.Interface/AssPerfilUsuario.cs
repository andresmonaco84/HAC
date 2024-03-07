
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Seguranca.DTO;

namespace HospitalAnaCosta.SGS.Seguranca.Interface
{
	public interface IAssPerfilUsuario
	{
		AssPerfilUsuarioDataTable Sel(AssPerfilUsuarioDTO dto);

		AssPerfilUsuarioDTO Ins(AssPerfilUsuarioDTO dto);

		void Del(AssPerfilUsuarioDTO dto);
		
		void Upd(AssPerfilUsuarioDTO dto);
		
		AssPerfilUsuarioDTO SelChave(AssPerfilUsuarioDTO dto);
	}
}
