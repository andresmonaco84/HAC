
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
	public interface IMatMedFuncionalidade
	{
		MatMedFuncionalidadeDataTable Sel(MatMedFuncionalidadeDTO dto);

		MatMedFuncionalidadeDTO Ins(MatMedFuncionalidadeDTO dto);

		void Del(MatMedFuncionalidadeDTO dto);
						
		MatMedFuncionalidadeDTO SelChave(MatMedFuncionalidadeDTO dto);

        void Atualizar(MatMedFuncionalidadeDTO dto);
	}
}