
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
	public class HistoricoNotaFiscal : Control, IHistoricoNotaFiscal
	{
		private Model.HistoricoNotaFiscal entity = new Model.HistoricoNotaFiscal();

        public DataTable ObterFornecedoresNF(string nf, byte estoque)
        {
            return entity.ObterFornecedoresNF(nf, estoque);
        }

        public DataTable ListarLoteValidade(HistoricoNotaFiscalDTO dto)
        {
            return entity.ListarLoteValidade(dto);
        }

        public decimal ObterCustoMedio(HistoricoNotaFiscalDataTable dtb)
        {
            decimal custoMedio = 0;

            if (dtb.Rows.Count > 0)
            {
                foreach (DataRow row in dtb.Rows)
                {
                    if (row[HistoricoNotaFiscalDTO.FieldNames.CustoMedio] != null)
                    {
                        custoMedio += decimal.Parse(row[HistoricoNotaFiscalDTO.FieldNames.CustoMedio].ToString());
                    }
                }
                custoMedio = custoMedio / dtb.Rows.Count;
            }            

            return custoMedio;
        }
        
        /// <summary>
        /// Listar todos os registros
        /// </summary>
		public HistoricoNotaFiscalDataTable Sel(HistoricoNotaFiscalDTO dto)
		{	
			return entity.Sel(dto);
		}        
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public HistoricoNotaFiscalDTO Ins(HistoricoNotaFiscalDTO dto)
		{
			entity.Ins(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Del(HistoricoNotaFiscalDTO dto)
		{
			entity.Del(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Upd(HistoricoNotaFiscalDTO dto)
		{
			entity.Upd(dto);
		}

        public void AtualizarValidadeLote(HistoricoNotaFiscalDTO dto)
        {
            entity.AtualizarValidadeLote(dto);
        }

        public void AtualizarNumeroLote(HistoricoNotaFiscalDTO dto)
        {
            entity.AtualizarNumeroLote(dto);
        }
	}
}