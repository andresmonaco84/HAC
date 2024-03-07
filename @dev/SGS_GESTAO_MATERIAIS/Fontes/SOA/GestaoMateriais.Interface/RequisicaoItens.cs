
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
	public interface IRequisicaoItens
	{
		RequisicaoItensDataTable Sel(RequisicaoItensDTO dto);

        RequisicaoItensDataTable Sel(RequisicaoItensDTO dto, bool ordenarEndereco, bool ordenarEndereco2);

        RequisicaoItensDataTable SelOrdenadoKit(RequisicaoItensDTO dto);

		RequisicaoItensDTO Ins(RequisicaoItensDTO dto);

		void Del(RequisicaoItensDTO dto);
		
		void Upd(RequisicaoItensDTO dto);

        /// <summary>
        /// Retorna quantidade solicitada na requisição
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        RequisicaoItensDTO SelQtdeSolicitada(RequisicaoItensDTO dto);

        /// <summary>
        /// Busca item pendente
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        RequisicaoItensDataTable SelReqItensPendentes(RequisicaoDTO dto);

        RequisicaoItensDataTable SelReqItensPendentes(int idSetor);

        RequisicaoItensDataTable SelReqItensPendentesConsumoPac(int idAtendimento, int? idProduto, int? idSetor);

        RequisicaoItensDataTable SelPedidosReqItenPac(int? idAtendimento, int? idProduto, int? idPedido);

        RequisicaoItensDataTable SelPedidosReqItenPac(int? idAtendimento, int? idProduto, int? idPedido, int? statusPedido);

        /// <summary>
        /// Carrega itens para tela de dispensação que já tenha qtd fornecida
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        RequisicaoItensDataTable SelReqItensDispensacao(RequisicaoDTO dto);

        void InsReqItemDispensacao(RequisicaoItensDTO dto);

        void DelReqItemDispensacao(RequisicaoItensDTO dto);

        /// <summary>
        /// Neste método, caso calcularQtdForn = true,
        /// o campo QtdFornecida funciona como se fosse a Qtd. a ser Fornecida, 
        /// pois ele é calculado e não é o que vem do banco.
        /// </summary>        
        RequisicaoItensDataTable SelItensRequisicao(RequisicaoItensDTO dto, bool calcularQtdForn);

        RequisicaoItensDTO CalculaQtdFornecidaAlmoxarifado(RequisicaoItensDTO dto);

        RequisicaoItensDataTable CalculaQtdFornecidaAlmoxarifado(RequisicaoItensDataTable dtb);

        RequisicaoItensDTO ConverteMatMedRequisicao(MaterialMedicamentoDTO dto);

        int ObterQtdSolicitadaProdutoPaciente(MovimentacaoDTO dto, int idPrincipioAtivo);

        RequisicaoItensDataTable ListarItensBaixa(RequisicaoItensDTO dto);

        decimal? ObterNumPedidoPrescricaoPaciente(MovimentacaoDTO dto, int idPrincipioAtivo);

        decimal? ObterNumPedidoPendentePaciente(MovimentacaoDTO dto, int idPrincipioAtivo);

        decimal ObterQtdItemPedidaHoje(RequisicaoItensDTO dto, decimal idReqRef);

        System.Data.DataTable SelPendenciasConsumoPacSetores(int idAtendimento);

        bool ExistePendenciasConsumoPacienteParaAlta(int idAtendimento, bool acaoAlta);

        bool DevolverAlmoxarifado(RequisicaoDTO dtoRequisicao);

        bool TransferirPacienteSetor(RequisicaoDTO dtoRequisicao, int idSetorOrigem, out string mensagem);

        RequisicaoItensDataTable SelReqItensLotesPendentesConsumoPac(int idAtendimento, int idSetor);

        RequisicaoItensDataTable ListarPendenciasDispensacao(int? idPedido);

        RequisicaoItensDataTable ListarItensKit(int idPedido);

        RequisicaoItensDataTable ListarItensKit(int idPedido, int idProdutoRef);

        bool ExisteKitAssociadoPedidoAla(int idPedido);

        void InserirItemKit(int idPedido, int idProdutoRef, int? idKit, int? idProdutoKit, int qtdSolicitada);

        void AtualizarItemKit(int idPedido, int idProdutoRef, int? idKit, int? idProdutoKit, int qtdSolicitada);

        void ExcluirItensKit(int idPedido);

        System.Data.DataTable ObterIndiceDevolucaoPeriodo(RequisicaoDTO dto);

        System.Data.DataTable ListarDevolucoesPeriodo(RequisicaoDTO dto);

        void InsPedidoAutoControle(RequisicaoItensDTO dto);

        void UpdPedidoAutoControle(RequisicaoItensDTO dto, DateTime? novaDataHoraGeracao);

        void CancelarPedidoAutoControle(RequisicaoItensDTO dto);

        void CancelarPedidoAutoControle(RequisicaoItensDTO dto, bool reativar);

        void DelPedidoAutoControle(RequisicaoItensDTO dto);

        /// <summary>
        /// ListarPedidoAutoControle
        /// </summary>        
        /// <param name="tipoBusca">1 = TODOS
        ///                         2 = PENDENTES DE GERAÇÃO
        ///                         3 = JÁ GERADOS
        ///                         4 = PENDENTES DE GERAÇÃO JUNTO COM SUSPENSOS NA PRESCRIÇÃO DA INTERNAÇÃO
        ///                         5 = SUSPENSOS NA PRESCRIÇÃO DA INTERNAÇÃO
        /// </param>
        RequisicaoItensDataTable ListarPedidoAutoControle(RequisicaoItensDTO dtoItem, RequisicaoDTO dtoReq, byte tipoBusca);

        /// <summary>
        /// Retorna qtd. do kit específico ou sem kit algum
        /// </summary>
        int ObterQtdSolicitadaAssKit(int idPedido, int idProdutoRef, int? idKit, int? idProdutoKit);

        /// <summary>
        /// Retorna qtd. total com kit associado
        /// </summary>        
        int ObterQtdSolicitadaAssKit(int idPedido, int idProdutoRef);

        RequisicaoItensDataTable SelSugestaoItensRequisicao(RequisicaoDTO dtoReq, MaterialMedicamentoDTO dtoMatMed);

        DateTime ObterDataInicioAdmPacientePadrao(RequisicaoDTO dtoReq, out DateTime dataInicioEmissao);

        RequisicaoItensDataTable ListarItensPrescricaoInt(RequisicaoDTO dto, int? idPrescInt, string statusItens);

        RequisicaoItensDataTable ListarItensGeradosPrescricaoInt_SemPedidoGestao(RequisicaoItensDTO dto);

        void UpdStatusItemPrescricaoInt(int? idPrescInt, int? idPrescItem, int idUsuario, string statusItem);

        void UpdStatusPrescricaoInt(int idPrescInternacao, string status);

        string ObterTelefoneUsuarioMedicoInt(int idPrescItem);

        void CancelarProgramacaoItensPrescricao(System.Data.DataTable dtbReqItem);

        void InserirItensKitPedido(RequisicaoItensDTO dtoReqItem);

        int ObterQtdPedidoTotalGerarItem(int qtdHorasTotalGerar, int periodoGerarItem, int qtdPedidoGerar);
	}
}