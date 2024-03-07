
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
	public interface IRequisicao
	{
        RequisicaoDataTable Sel(RequisicaoDTO dto, bool apenasComQtdSolicitada);


        RequisicaoDataTable SelImpressaoCentroDispensacao(RequisicaoDTO dto, bool soAtdDomiciliar);


        RequisicaoDTO Ins(RequisicaoDTO dto);

		void Del(RequisicaoDTO dto);
		
		void Upd(RequisicaoDTO dto);

        void DispensarRequisicao(RequisicaoDTO dto);

		RequisicaoDTO SelChave(RequisicaoDTO dto);

        RequisicaoDataTable RequisicaoPaciente(RequisicaoDTO dto);

        RequisicaoDataTable ListarPacienteKits(RequisicaoDTO dto);

        /// <summary>
        /// Listar as �timas requisi��es de acordo com o tipo e status
        /// </summary>
        RequisicaoDataTable SelUltimas(RequisicaoDTO dto, int qtdUltimas);

        /// <summary>
        /// Salva Requisicao.
        /// O par�metro dtbItens refere-se a todos os itens referentes � requisi��o, independente se foi fornecido ou n�o o item na hora da dispensa��o.
        /// </summary>    
        RequisicaoDTO Gravar(RequisicaoDTO dto, RequisicaoItensDataTable dtbItens);

        /// <summary>
        /// Salva Requisicao.
        /// O par�metro dtbItens refere-se a todos os itens referentes � requisi��o, independente se foi fornecido ou n�o o item na hora da dispensa��o.
        /// O par�metro dtbItensPendentes, retorna os itens que n�o foram fornecidos ou os que n�o possuem estoque suficiente no Centro de Dispensa��o para serem liberados.
        /// </summary>
        RequisicaoDTO Gravar(RequisicaoDTO dto, RequisicaoItensDataTable dtbItens, ref RequisicaoItensDataTable dtbItensPendentes);

        /// <summary>
        /// Transfere os itens(mat/med) do centro dispensa��o para setor da requisi��o.
        /// </summary>
        /// <param name="dtoRequisicao"></param>
        /// <param name="dtbReqItens"></param>
        void Dispensar(RequisicaoDTO dtoRequisicao, RequisicaoItensDataTable dtbReqItens);

        string RetornarStatus(RequisicaoDTO dtoRequisicao);

        void InsParamPedidoAuto(RequisicaoDTO dto);

        void UpdParamPedidoAuto(RequisicaoDTO dto);

        void DelParamPedidoAuto(RequisicaoDTO dto);

        RequisicaoDataTable ListarParamPedidoAuto(RequisicaoDTO dto);

        /// <summary>
        /// Gera os Pedidos Programados at� o hor�rio atual
        /// </summary>
        void GerarPedidoAutomaticos();

        System.Data.DataTable ListarPrescricaoInt(RequisicaoDTO dto, int? idPrescInt, string statusItens, bool suspensas);

        System.Data.DataTable ListarPrescricaoIntHistorico(RequisicaoDTO dto, int? idPrescInt, bool suspensas);

        DateTime DataInicioCorteDiaSeguintePrescricao(DateTime dataFimCorte, int periodoGerarSetor, int horasMinimaParaAbastecimento, out bool ultrapassouCorte);

        void UpdOBSPrescricaoInt(int idPrescInternacao, string observacao, int idUsuario, string categoria);

        void ReplicarPedidos(int idTpReq, int idSetor, DateTime dtInicio, DateTime dtFim, bool apenasFornecidos, bool farmacia, int idUsuario);

        void AtualizarPedidosPacientesTransferidosUTI();
	}
}