using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
// using HospitalAnaCosta.SGS.Cadastro.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
	public interface IMovimentacao
	{
        System.Data.DataTable SelMovArquivoContHeader(MovimentacaoMensalDTO dto);

        System.Data.DataTable SelMovArquivoCont(MovimentacaoMensalDTO dto);

        MovimentacaoDataTable Sel(MovimentacaoDTO dto, bool consumoPaciente);

        MovimentacaoDataTable SelDivergencias(MovimentacaoDTO dto);

        void DistribuiDespesaCentroCusto(MovimentacaoDTO dto);

        MovimentacaoDataTable HistoricoDespesaCentroCusto(MovimentacaoDTO dto);

        MovimentacaoDataTable HistoricoDespesaCentroCustoSintetico(MovimentacaoDTO dto);

        MovimentacaoDataTable HistoricoDespesaCentroCustoPacientes(MovimentacaoDTO dto);

        void EstornaDespesaCCusto(MovimentacaoDTO dto);

		void Ins(MovimentacaoDTO dto);

		void Del(MovimentacaoDTO dto);
		 
		void Upd(MovimentacaoDTO dto);
		
		MovimentacaoDTO SelChave(MovimentacaoDTO dto);

        MovimentacaoDTO ConverteMatMedMovimento(MaterialMedicamentoDTO dtoMatMed, MovimentacaoDTO dtoMovimento);

        MovimentacaoDTO EnviaProdutoFaturamento(MovimentacaoDTO dtoMovimento, MaterialMedicamentoDTO dtoMatMed, int? idSetorFatura);

        MovimentacaoDTO EntradaProduto(MovimentacaoDTO dto);

        /// <summary>
        /// Baixa produto do estoque da unidade.
        /// Caso dtoMovimento possua Cod. Barra, busca o produto pelo códido de barra.
        /// Se não, o parâmetro dtoMatMed tem que ser diferente de null. 
        /// </summary>                
        MovimentacaoDTO MovimentaEstoqueProduto(MovimentacaoDTO dtoMovimento, MaterialMedicamentoDTO dtoMatMed, int? idSetorFatura);

        /// <summary>
        /// Baixa produto do estoque da unidade e envia para faturamento.
        /// Caso dtoMovimento possua Cod. Barra, busca o produto pelo códido de barra.
        /// Se não, o parâmetro dtoMatMed tem que ser diferente de null. 
        /// </summary>   
        // MovimentacaoDataTable MovimentaEstoqueProduto(MovimentacaoDataTable dtbMovimento, MovimentacaoDTO dtoMovimento, MaterialMedicamentoDTO dtoMatMed);

        MovimentacaoDTO TransfereEstoqueProduto(MovimentacaoDTO dto);

        MovimentacaoDTO CentroDispensacao(MovimentacaoDTO dto, out SetorDTO dtoSetorFarmacia);

        /// <summary>
        /// Estorna (exclui) o consumo realizado pelo paciente.
        /// Este processo devolve o produto ao estoque, sendo o processo inverso da baixa,
        /// mas isto não poderá acontecer se o produto já estiver sido faturado.
        /// Provavelmente isto deverá acontecer apenas quando a enfermeira perceber 
        /// que errou na realização de uma baixa de um paciente.
        /// </summary>
        void EstornarMovimentoConsumoPaciente(MovimentacaoDTO dto);

        void EstornarMovimentoConsumoPacienteFaturado(MovimentacaoDTO dto);

        void EstornarMovimentoFaturamento(MovimentacaoDTO dto);

        // bool VerificarFaturamentoInc(MovimentacaoDTO dto);

        // bool VerificarFaturamentoExc(MovimentacaoDTO dto);

        /// <summary>
        /// Verifica se conta ainda esta aberta para consumo, não faturada
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool PermiteConsumo(MovimentacaoDTO dto);


        // void MovimentaEstoqueOutraUnidade(MovimentacaoDTO dtoMovimento, MaterialMedicamentoDTO dtoMatMed);

        MovimentacaoDataTable ListaMovimentacao(MovimentacaoDTO dto);

        /// <summary>
        /// Estorna movimento de produto para paciente e retorna quantidade ao estoque de origem ( Almox Central ou Satélite )
        /// </summary>
        /// <param name="dto"></param>
        // void EstornarMovimentoCentroCirurgico(MovimentacaoDTO dto);

        void SalvaMovimentoCentroCirurgico(MovimentacaoDTO dto);

        int RegerarContaFaturamento(MovimentacaoDTO dto);

        bool PermitirEstornoConsumoItem(ref MovimentacaoDTO dto);

        MovimentacaoDataTable PendenciaCCirurgico(MovimentacaoDTO dto);

        ///// <summary>
        ///// Verifica Consumo de Materiais e Medicamentos para o paciente.
        ///// Nr. Atendimento ( Obrigatório )
        ///// </summary>
        ///// <param name="dto">MovimentacaoDTO</param>
        ///// <returns>Boolean</returns>
        //bool VerificaConsumoCentroCirurgico(MovimentacaoDTO dto);

        bool VerificaConsumo(MovimentacaoDTO dto);

        MovimentacaoDataTable HistoricoEnvioFaturamentoPaciente(MovimentacaoDTO dto);

        /// <summary>
        /// Retorna Itens consumidos para o paciente
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>DataTable</returns>
        MovimentacaoDataTable HistoricoConsumoPaciente(MovimentacaoDTO dto);

        /// <summary>
        /// Retorna toda movimentação do produto no setor, parametros Obrigatórios:
        /// IdtProduto, IdtUnidade, IdtLocal, IdtSetor, IdtFilial, DtMovimetnacao
        /// DtMovimentacao é a data de inicio da pesquisa.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        MovimentacaoDataTable HistoricoProdutoSetor(MovimentacaoDTO dto);

        MovimentacaoDataTable HistoricoConsumoAtendimentosPeriodo(MovimentacaoDTO dto, decimal? idtConvenio);

        /// <summary>
        /// Realiza a Dispensação, Baixa e consumo para o paciente de Produtos para o Centro Cirurgico
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        MovimentacaoDTO DispensacaoKitCCirurgico(MovimentacaoDTO dto, MaterialMedicamentoDTO dtoMatMed);

        void ImportaInventario(MovimentacaoDTO dto, int? idGrupo);

        void ImportaInventarioMed(MovimentacaoDTO dto, int? idGrupo);

        void TransferirAtendimento(decimal idAtd_De, decimal idAtd_Para);

        void GerarDadosRelatorioInfMatMed(byte mes, int ano, bool processarFechaEstoque, bool processarReceita, int idUsuario);

        void LiberarAtendimento(decimal atendimento, decimal status, decimal idUsuario);

        void AtualizarAtendimentoLiberado(decimal atendimento, decimal status);

        System.Data.DataTable AtendimentosLiberados();

        System.Data.DataTable ObterQtdProdutoBaixaPacSetor(MovimentacaoDTO dto, int idPrincipioAtivo);

        System.Data.DataTable ObterItensPendentesProtocolo(MovimentacaoDTO dto);

        System.Data.DataTable ObterProtocolosPaciente(MovimentacaoDTO dto, decimal? idProtocolo);

        int ObterNovoNumProtocolo();

        void AtualizarProtocolo(decimal idProtocolo, decimal idMovimento);

        void AtualizarKit(decimal idKit, decimal idMovimento);

        decimal ObterSaidasMensalSetor(MovimentacaoDTO dto);

        decimal ObterQtdLoteDispensado(MovimentacaoDTO dto);

        System.Data.DataTable ObterEntradasCentroDispPedido(MovimentacaoDTO dto);        

        MovimentacaoDataTable RastrearLoteProduto(MovimentacaoDTO dto);

        System.Data.DataTable ObterSaidasCentroDispPedidoAnalitico(MovimentacaoDTO dto, bool blnUtiCompartilhada, bool blnFarmCentroCirurgico);

        System.Data.DataTable ObterEntradasPedidoProduto(MovimentacaoDTO dto);

        KitDataTable ObterKitsConsumidosPaciente(MovimentacaoDTO dto);

        MovimentacaoDataTable ObterCentroDispMovimentoPedido(MovimentacaoDTO dto);

        decimal ObterIdMovimentoBaixaAutoDispensaPaciente(MovimentacaoDTO dto);

        decimal ObterIdMovimentoEnvioFaturamento(MovimentacaoDTO dto);

        void MarcarEstornoMovimento(decimal idMovimento);

        bool TemParcelaFaturamento(decimal atendimento, DateTime? dtParcela);

        int ReprocessarContaFaturamentoMatMed(MovimentacaoDTO dto, bool duplicarFaturamento);

        void AtualizarEmpresaEmprestimo(decimal idEmpresa, decimal idMovimento);

        System.Data.DataTable RelatorioConsumoGrupoMercado(string periodo);

        int ConverterQtdFracaoGotas(MovimentacaoDTO dto);

        void TransferirEstoque(MovimentacaoDTO dto);

        bool ContaSalvaFaturamento(decimal atendimento);
	}
}