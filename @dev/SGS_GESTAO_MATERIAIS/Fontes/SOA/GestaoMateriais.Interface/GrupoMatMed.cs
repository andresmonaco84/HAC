
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
	public interface IGrupoMatMed
	{
		GrupoMatMedDataTable Sel(GrupoMatMedDTO dto);

		GrupoMatMedDTO Ins(GrupoMatMedDTO dto);

		void Del(GrupoMatMedDTO dto);
		
		void Upd(GrupoMatMedDTO dto);
		
		GrupoMatMedDTO SelChave(GrupoMatMedDTO dto);
	}
}
