using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
	public interface IHistoricoNFEstorno
	{
		HistoricoNFEstornoDataTable Listar(HistoricoNFEstornoDTO dto);

        HistoricoNFEstornoDTO Incluir(HistoricoNFEstornoDTO dto, int? qtdDevolucaoParcial, decimal? precoUnitario);		
	}
}