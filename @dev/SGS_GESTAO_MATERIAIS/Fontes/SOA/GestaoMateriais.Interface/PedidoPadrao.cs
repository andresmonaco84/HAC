
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
        /// Listar Pedidos para gerar requisi��o do pedido padr�o
        /// </summary>
        PedidoPadraoDataTable GeraImpressaoPedidoPadrao(PedidoPadraoDTO dto);


		PedidoPadraoDTO SelChave(PedidoPadraoDTO dto);

        PedidoPadraoItensDTO ConverteMatMedPedidoPadrao(MaterialMedicamentoDTO dto);
        /*
        /// <summary>
        /// Se dispensarDireto = true, depois que gerar as requisi��es, j� dispensa o produto para os respectivos destinos,
        /// pulando o processo de impress�o.
        /// </summary>
        /// <param name="dtb"></param>
        /// <param name="dispensarDireto"></param>
        void GeraRequisicao(PedidoPadraoDataTable dtb, bool dispensarDireto);

        /// <summary>
        /// Se dispensarDireto = true, depois que gerar as requisi��es, j� dispensa o produto para os respectivos destinos,
        /// pulando o processo de impress�o.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="dtbPedPadraoItens"></param>
        /// <param name="dispensarDireto"></param>
        void GeraRequisicao(PedidoPadraoDTO dto, PedidoPadraoItensDataTable dtbPadrao, bool dispensarDireto);        
        */

        void GeraRequisicao(PedidoPadraoDTO dto, string tabelaMedica, int? idSetorFarmacia);
   
        RequisicaoItensDataTable ConvertePadraoRequisicaoItens(PedidoPadraoItensDataTable dtb);

        /// <summary>
        /// Altera a data da �ltima dispensa��o
        /// </summary>        
        void UpdDataDispensacao(PedidoPadraoDTO dto);

        /// <summary>
        /// Altera a data da �ltima requisi��o referente a este pedido padr�o
        /// </summary>
        void UpdDataUltRequisicao(PedidoPadraoDTO dto);

        /// <summary>
        /// Verifica se o produto pertence ao pedido padrao referente a filial e ao setor
        /// </summary>
        bool ProdutoPadrao(PedidoPadraoDTO dtoPedidoPadrao, MaterialMedicamentoDTO dtoMatMed);

        /// <summary>
        /// Verifica se o produto pertence ao pedido padrao referente a filial e ao setor
        /// Se verificarPA = true, verifica tamb�m produto com o mesmo princ�pio ativo no pedido padr�o 
        /// </summary>
        bool ProdutoPadrao(PedidoPadraoDTO dtoPedidoPadrao, MaterialMedicamentoDTO dtoMatMed, bool verificarPA);

        /// <summary>
        /// Verifica se o produto pertence ao pedido padrao referente a filial e ao setor.
        /// Retorna por refer�ncia o dto do item, no caso deste m�todo retornar true.
        /// Se verificarPA = true, verifica tamb�m produto com o mesmo princ�pio ativo no pedido padr�o 
        /// </summary>
        bool ProdutoPadrao(PedidoPadraoDTO dtoPedidoPadrao, MaterialMedicamentoDTO dtoMatMed, ref PedidoPadraoItensDTO dtoPedPadItem, bool verificarPA);

        /// <summary>
        /// Caso o produto perten�a ao pedido padrao referente a filial e ao setor, valida se existe um estoque m�nimo
        /// para requisi��es personalizadas. Caso existir este estoque m�nimo, n�o liberar o produto na hora da requisi��o. 
        /// </summary> 
        bool LiberarProdutoPadraoReqPersonalizadaEstMin(PedidoPadraoDTO dtoPedidoPadrao, MaterialMedicamentoDTO dtoMatMed, ref PedidoPadraoItensDTO dtoPedPadItem);

        PedidoPadraoItensDataTable ListarItemRessuprir(PedidoPadraoDTO dto);
	}
}
