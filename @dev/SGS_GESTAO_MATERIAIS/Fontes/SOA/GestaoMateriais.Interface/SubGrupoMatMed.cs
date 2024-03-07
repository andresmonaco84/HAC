
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
	public interface ISubGrupoMatMed
	{
		SubGrupoMatMedDataTable Sel(SubGrupoMatMedDTO dto);

		SubGrupoMatMedDTO Ins(SubGrupoMatMedDTO dto);

		void Del(SubGrupoMatMedDTO dto);
		
		void Upd(SubGrupoMatMedDTO dto);
		
		SubGrupoMatMedDTO SelChave(SubGrupoMatMedDTO dto);
	}
}
