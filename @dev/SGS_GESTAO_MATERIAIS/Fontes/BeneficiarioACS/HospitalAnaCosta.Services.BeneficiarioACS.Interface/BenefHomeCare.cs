using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.Services.BeneficiarioACS.DTO;

namespace HospitalAnaCosta.Services.BeneficiarioACS.Interface
{
	public interface IBenefHomeCare
	{
		BenefHomeCareDataTable Sel(BenefHomeCareDTO dto);

		BenefHomeCareDTO Ins(BenefHomeCareDTO dto);

        /// <summary>
        /// Listar o registro de endereço do sgs a ser incluido no homecare
        /// </summary>
        BenefHomeCareDTO SelEnderecoIncluir(BenefHomeCareDTO dto);

		void Del(BenefHomeCareDTO dto);
		
		void Upd(BenefHomeCareDTO dto);
		
		BenefHomeCareDTO SelChave(BenefHomeCareDTO dto);

        void Gravar(BenefHomeCareDTO dto);
	}
}
