
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Seguranca.DTO;

namespace HospitalAnaCosta.SGS.Seguranca.Interface
{
	public interface IFuncionalidade
	{
		FuncionalidadeDataTable Sel(FuncionalidadeDTO dto);

		FuncionalidadeDTO Ins(FuncionalidadeDTO dto);

		void Del(FuncionalidadeDTO dto);
		
		void Upd(FuncionalidadeDTO dto);
		
		FuncionalidadeDTO SelChave(FuncionalidadeDTO dto);

        FuncionalidadeDTO Gravar(FuncionalidadeDTO dto);
	}
}
