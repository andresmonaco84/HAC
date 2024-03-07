
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
	public interface IEstoqueLocal
	{
        /// <summary>
        /// Acerta o estoque local e contábil de acordo com a nova quantidade local
        /// </summary>
        void AcertarEstoqueProduto(EstoqueLocalDTO dto, bool inventarioRotativo);

		EstoqueLocalDataTable Sel(EstoqueLocalDTO dto);


        EstoqueLocalDataTable EstoqueOnLine(EstoqueLocalDTO dto);

		EstoqueLocalDTO Ins(EstoqueLocalDTO dto);

		void Del(EstoqueLocalDTO dto);
		
		void Upd(EstoqueLocalDTO dto);		
		
        EstoqueLocalDTO EstoqueLocalProduto(EstoqueLocalDTO dto);

        void InativaEstoqueProduto(EstoqueLocalDTO dto);

        /// <summary>
        /// Verifica se o estoque passado é centro de dispensação, se for Centro de dispensação retorna TRUE
        /// </summary>
        /// <returns></returns>
        bool EstoqueCentroDispensacao(EstoqueLocalDTO dto);

        int EstoqueDeConsumo(EstoqueLocalDTO dto);

        System.Data.DataTable ListarEstoqueMes(EstoqueLocalDTO dto, string strAnoMesDe, string strAnoMesAte);

        EstoqueLocalDataTable ListarEstoqueLote(EstoqueLocalDTO dto);

        MaterialMedicamentoDTO ObterSimilarProximoVencimento(MaterialMedicamentoDTO dtoMatMed);

        string KitMateriaisSaldoInsuficiente(RequisicaoDTO dto);

        string MedicamentosVencidos(EstoqueLocalDTO dto);
	}
}