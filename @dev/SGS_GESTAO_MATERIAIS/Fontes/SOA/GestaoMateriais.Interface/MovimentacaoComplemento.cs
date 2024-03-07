
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
	public interface IMovimentacaoComplemento
	{
		MovimentacaoComplementoDataTable Sel(MovimentacaoComplementoDTO dto);

		MovimentacaoComplementoDTO Ins(MovimentacaoComplementoDTO dto);

		void Del(MovimentacaoComplementoDTO dto);
		
		void Upd(MovimentacaoComplementoDTO dto);
		
		MovimentacaoComplementoDTO SelChave(MovimentacaoComplementoDTO dto);

        /// <summary>
        /// Registra Divergencia
        /// </summary>
        /// <param name="dto"></param>
        void RegistrarDivergencia(MovimentacaoComplementoDTO dto, MovimentacaoDTO dtoMov);
	}
}
