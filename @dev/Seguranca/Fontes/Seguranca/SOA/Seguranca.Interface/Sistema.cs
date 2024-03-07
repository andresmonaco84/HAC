
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Seguranca.DTO;

namespace HospitalAnaCosta.SGS.Seguranca.Interface
{
	public interface ISistema
	{
		SistemaDataTable Sel(SistemaDTO dto);

		SistemaDTO Ins(SistemaDTO dto);

		void Del(SistemaDTO dto);
		
		void Upd(SistemaDTO dto);
		
		SistemaDTO SelChave(SistemaDTO dto);
	}
}
