
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Seguranca.DTO;

namespace HospitalAnaCosta.SGS.Seguranca.Interface
{
	public interface IPerfil
	{
		PerfilDataTable Sel(PerfilDTO dto);

		PerfilDTO Ins(PerfilDTO dto);

		void Del(PerfilDTO dto);
		
		void Upd(PerfilDTO dto);
		
		PerfilDTO SelChave(PerfilDTO dto);

        PerfilDTO Gravar(PerfilDTO dto);

        // PerfilDataTable ObterPorModulo(PerfilDTO dto);

	}
}
