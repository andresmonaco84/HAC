
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
	public interface IMotivoPerda
	{
        MotivoPerdaDataTable Sel(MotivoPerdaDTO dto, string flTipoDevolucao);

		MotivoPerdaDTO Ins(MotivoPerdaDTO dto);

		void Del(MotivoPerdaDTO dto);
		
		void Upd(MotivoPerdaDTO dto);
		
		MotivoPerdaDTO SelChave(MotivoPerdaDTO dto);
	}
}
