using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
	public class EstoqueLocal : Control, IEstoqueLocal
	{
		private Model.EstoqueLocal entity = new Model.EstoqueLocal() ;

        /// <summary>
        /// Acerta o estoque local e contábil de acordo com a nova quantidade local
        /// </summary>        
        public void AcertarEstoqueProduto(EstoqueLocalDTO dto, bool inventarioRotativo)
        {
            entity.AcertarEstoqueProduto(dto, inventarioRotativo);
        }

        /// <summary>
        /// Listar todos os registros
        /// </summary>
		public EstoqueLocalDataTable Sel(EstoqueLocalDTO dto)
		{	
			return entity.Sel(dto);
		}

        public EstoqueLocalDataTable EstoqueOnLine(EstoqueLocalDTO dto)
        {
            return entity.EstoqueOnLine(dto);
        }        

        /// <summary>
        /// Retorna quantidade em estoque e lote do produto
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public EstoqueLocalDTO EstoqueLocalProduto(EstoqueLocalDTO dto)
        {
            // CHAMADA DE: Movimentacao.ConverteMatMedMovimento
            return entity.EstoqueLocalProduto(dto);            
        }
         
		///<summary>
		/// Insere um registro
		/// </summary>
		public EstoqueLocalDTO Ins(EstoqueLocalDTO dto)
		{
			entity.Ins(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Del(EstoqueLocalDTO dto)
		{
			entity.Del(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Upd(EstoqueLocalDTO dto)
		{
			entity.Upd(dto);
		}

        public void InativaEstoqueProduto(EstoqueLocalDTO dto)
        {
            entity.InativaEstoqueProduto(dto);   
        }

        /// <summary>
        /// Verifica se o estoque passado é centro de dispensação, se for Centro de dispensação retorna TRUE
        /// </summary>
        /// <returns></returns>
        public bool EstoqueCentroDispensacao(EstoqueLocalDTO dto)
        {
            return entity.EstoqueCentroDispensacao(dto);
        }

        public int EstoqueDeConsumo(EstoqueLocalDTO dto)
        {
            return entity.EstoqueDeConsumo(dto);
        }

        public DataTable ListarEstoqueMes(EstoqueLocalDTO dto, string strAnoMesDe, string strAnoMesAte)
        {
            return entity.ListarEstoqueMes(dto, strAnoMesDe, strAnoMesAte);
        }

        public EstoqueLocalDataTable ListarEstoqueLote(EstoqueLocalDTO dto)
        {
            return entity.ListarEstoqueLote(dto);
        }

        public MaterialMedicamentoDTO ObterSimilarProximoVencimento(MaterialMedicamentoDTO dtoMatMed)
        {
            return entity.ObterSimilarProximoVencimento(dtoMatMed);
        }

        public string KitMateriaisSaldoInsuficiente(RequisicaoDTO dto)
        {
            string retorno = null;
            EstoqueLocalDataTable dtb = entity.KitMateriaisSaldoInsuficiente(dto);
            foreach (DataRow row in dtb.Rows)
            {
                if (!string.IsNullOrEmpty(retorno)) retorno += ", ";
                retorno += row[EstoqueLocalDTO.FieldNames.DsProduto];
            }
            return retorno;
        }

        public string MedicamentosVencidos(EstoqueLocalDTO dto)
        {
            string retorno = null;
            EstoqueLocalDataTable dtb = entity.MedicamentosVencidos(dto);
            foreach (DataRow row in dtb.Rows)
            {
                if (!string.IsNullOrEmpty(retorno)) retorno += ", ";
                retorno += row[EstoqueLocalDTO.FieldNames.DsProduto];
            }
            return retorno;
        }
	}
}