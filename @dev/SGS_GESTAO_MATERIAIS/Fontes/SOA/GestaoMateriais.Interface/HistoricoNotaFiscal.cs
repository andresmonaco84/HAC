using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
	public interface IHistoricoNotaFiscal
	{
        System.Data.DataTable ObterFornecedoresNF(string nf, byte estoque);

        System.Data.DataTable ListarLoteValidade(HistoricoNotaFiscalDTO dto);

        decimal ObterCustoMedio(HistoricoNotaFiscalDataTable dtb);

		HistoricoNotaFiscalDataTable Sel(HistoricoNotaFiscalDTO dto);

		HistoricoNotaFiscalDTO Ins(HistoricoNotaFiscalDTO dto);

		void Del(HistoricoNotaFiscalDTO dto);
		
		void Upd(HistoricoNotaFiscalDTO dto);

        void AtualizarValidadeLote(HistoricoNotaFiscalDTO dto);

        void AtualizarNumeroLote(HistoricoNotaFiscalDTO dto);
	}
}