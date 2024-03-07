using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
	public interface IMatMedSimilar
	{
		MatMedSimilarDataTable Sel(MatMedSimilarDTO dto);

        MatMedSimilarDataTable ListarSimilares(MatMedSimilarDTO dto, MaterialMedicamentoDTO dtoMatMed);

		MatMedSimilarDTO Ins(MatMedSimilarDTO dto);

		void Del(MatMedSimilarDTO dto);

        void Grava(MatMedSimilarDataTable dtbl, ref MatMedSimilarDTO dtoSimilar);
	}
}