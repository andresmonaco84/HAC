using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Seguranca.DTO;

namespace HospitalAnaCosta.SGS.Seguranca.Interface
{
	public interface IModulo
	{
		ModuloDataTable Sel(ModuloDTO dto);

		ModuloDTO Ins(ModuloDTO dto);

		void Del(ModuloDTO dto);
		
		void Upd(ModuloDTO dto);
		
		ModuloDTO SelChave(ModuloDTO dto);
	}
}
