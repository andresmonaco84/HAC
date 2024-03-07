
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
	public interface ICodigoBarra
	{
        CodigoBarraDataTable SelMedicamentoSemNF(HistoricoNotaFiscalDTO dtoHNF, decimal idUsuario, decimal idSetorMov);

        CodigoBarraDTO SelAvulso(CodigoBarraDTO dto, decimal idUsuario);

        CodigoBarraDataTable Sel(CodigoBarraDTO dto, decimal? idUsuario);

		CodigoBarraDTO Ins(CodigoBarraDTO dto);

		void Del(CodigoBarraDTO dto);
		
		void Upd(CodigoBarraDTO dto);		

        bool Existe(CodigoBarraDTO dto);

        void Gravar(CodigoBarraDTO dto);

        /// <summary>
        /// Caso não possua cod. barra, retorna próprio ID
        /// </summary>
        /// <param name="idFilial"></param>
        /// <param name="idProduto"></param>
        /// <returns></returns>
        string ObterCodigo(decimal idFilial, decimal idProduto);
	}
}
