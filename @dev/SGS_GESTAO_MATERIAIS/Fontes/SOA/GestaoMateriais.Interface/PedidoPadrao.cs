
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
	public interface IPedidoPadrao
	{
		PedidoPadraoDataTable Sel(PedidoPadraoDTO dto);

        PedidoPadraoItensDataTable SelItens(PedidoPadraoDTO dto);

        PedidoPadraoItensDataTable SelItens(PedidoPadraoItensDTO dto);

		PedidoPadraoDTO Ins(PedidoPadraoDTO dto);

        void Gravar(PedidoPadraoDTO dto, PedidoPadraoItensDataTable dtb);

		void Del(PedidoPadraoDTO dto);
		
		void Upd(PedidoPadraoDTO dto);

        /// <summary>
        /// Listar Pedidos para gerar requisição do pedido padrão
        /// </summary>
        PedidoPadraoDataTable GeraImpressaoPedidoPadrao(PedidoPadraoDTO dto);


		PedidoPadraoDTO SelChave(PedidoPadraoDTO dto);

        PedidoPadraoItensDTO ConverteMatMedPedidoPadrao(MaterialMedicamentoDTO dto);
        /*
        /// <summary>
        /// Se dispensarDireto = true, depois que gerar as requisições, já dispensa o produto para os respectivos destinos,
        /// pulando o processo de impressão.
        /// </summary>
        /// <param name="dtb"></param>
        /// <param name="dispensarDireto"></param>
        void GeraRequisicao(PedidoPadraoDataTable dtb, bool dispensarDireto);

        /// <summary>
        /// Se dispensarDireto = true, depois que gerar as requisições, já dispensa o produto para os respectivos destinos,
        /// pulando o processo de impressão.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="dtbPedPadraoItens"></param>
        /// <param name="dispensarDireto"></param>
        void GeraRequisicao(PedidoPadraoDTO dto, PedidoPadraoItensDataTable dtbPadrao, bool dispensarDireto);        
        */

        void GeraRequisicao(PedidoPadraoDTO dto, string tabelaMedica, int? idSetorFarmacia);
   
        RequisicaoItensDataTable ConvertePadraoRequisicaoItens(PedidoPadraoItensDataTable dtb);

        /// <summary>
        /// Altera a data da última dispensação
        /// </summary>        
        void UpdDataDispensacao(PedidoPadraoDTO dto);

        /// <summary>
        /// Altera a data da última requisição referente a este pedido padrão
        /// </summary>
        void UpdDataUltRequisicao(PedidoPadraoDTO dto);

        /// <summary>
        /// Verifica se o produto pertence ao pedido padrao referente a filial e ao setor
        /// </summary>
        bool ProdutoPadrao(PedidoPadraoDTO dtoPedidoPadrao, MaterialMedicamentoDTO dtoMatMed);

        /// <summary>
        /// Verifica se o produto pertence ao pedido padrao referente a filial e ao setor
        /// Se verificarPA = true, verifica também produto com o mesmo princípio ativo no pedido padrão 
        /// </summary>
        bool ProdutoPadrao(PedidoPadraoDTO dtoPedidoPadrao, MaterialMedicamentoDTO dtoMatMed, bool verificarPA);

        /// <summary>
        /// Verifica se o produto pertence ao pedido padrao referente a filial e ao setor.
        /// Retorna por referência o dto do item, no caso deste método retornar true.
        /// Se verificarPA = true, verifica também produto com o mesmo princípio ativo no pedido padrão 
        /// </summary>
        bool ProdutoPadrao(PedidoPadraoDTO dtoPedidoPadrao, MaterialMedicamentoDTO dtoMatMed, ref PedidoPadraoItensDTO dtoPedPadItem, bool verificarPA);

        /// <summary>
        /// Caso o produto pertença ao pedido padrao referente a filial e ao setor, valida se existe um estoque mínimo
        /// para requisições personalizadas. Caso existir este estoque mínimo, não liberar o produto na hora da requisição. 
        /// </summary> 
        bool LiberarProdutoPadraoReqPersonalizadaEstMin(PedidoPadraoDTO dtoPedidoPadrao, MaterialMedicamentoDTO dtoMatMed, ref PedidoPadraoItensDTO dtoPedPadItem);

        PedidoPadraoItensDataTable ListarItemRessuprir(PedidoPadraoDTO dto);
	}
}
