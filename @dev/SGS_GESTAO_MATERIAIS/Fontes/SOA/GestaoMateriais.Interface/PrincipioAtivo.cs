
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
	public interface IPrincipioAtivo
	{
		PrincipioAtivoDataTable Sel(PrincipioAtivoDTO dto);

		PrincipioAtivoDTO Ins(PrincipioAtivoDTO dto);

		//void Del(PrincipioAtivoDTO dto);
		
		void Upd(PrincipioAtivoDTO dto);        

        PrincipioAtivoDataTable Grava(PrincipioAtivoDataTable dtbl);
		
		PrincipioAtivoDTO SelChave(PrincipioAtivoDTO dto);

        MaterialMedicamentoDataTable SelMatMed(PrincipioAtivoDTO dto, MaterialMedicamentoDTO dtoMatMed);

        // void InsMatMed(MaterialMedicamentoDTO dto);

        // void DelMatMed(MaterialMedicamentoDTO dto);

        MaterialMedicamentoDataTable GravaSimilares(MaterialMedicamentoDataTable dtbl);
	}
}
