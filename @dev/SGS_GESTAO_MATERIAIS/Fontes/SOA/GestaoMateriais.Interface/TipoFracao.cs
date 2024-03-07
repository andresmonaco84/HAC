
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
	public interface ITipoFracao
	{
		TipoFracaoDataTable Sel(TipoFracaoDTO dto);

		TipoFracaoDTO Ins(TipoFracaoDTO dto);

		void Del(TipoFracaoDTO dto);
		
		void Upd(TipoFracaoDTO dto);
		
		TipoFracaoDTO SelChave(TipoFracaoDTO dto);

        TipoFracaoDTO ConverteFracao(TipoFracaoDTO dto);
	}
}
