using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.Services.BeneficiarioACS.DTO;
using HospitalAnaCosta.Services.BeneficiarioACS.Interface;

namespace HospitalAnaCosta.Services.BeneficiarioACS.Control
{
	public class BenefHomeCare : Control, IBenefHomeCare
	{
		private Model.BenefHomeCare entity = new Model.BenefHomeCare() ;

        /// <summary>
        /// Listar todos os registros
        /// </summary>
		public BenefHomeCareDataTable Sel(BenefHomeCareDTO dto)
		{	
			return entity.Sel(dto);
		}

        /// <summary>
        /// Obter pela chave
        /// </summary>
		public BenefHomeCareDTO SelChave(BenefHomeCareDTO dto)
		{	
			return entity.SelChave(dto);
		}

        /// <summary>
        /// Listar o registro de endereço do sgs a ser incluido no homecare
        /// </summary>
        public BenefHomeCareDTO SelEnderecoIncluir(BenefHomeCareDTO dto)
        {
            return entity.SelEnderecoIncluir(dto);
        }
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public BenefHomeCareDTO Ins(BenefHomeCareDTO dto)
		{
			entity.Ins(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Del(BenefHomeCareDTO dto)
		{
			entity.Del(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Upd(BenefHomeCareDTO dto)
		{
			entity.Upd(dto);
		}

        public void Gravar(BenefHomeCareDTO dto)
        {
            if (dto.CodigoHomeCare.Value.IsNull)
            {
                this.Ins(dto);
            }
            else
            {
                this.Upd(dto);
            }
        }
	}
}