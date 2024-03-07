using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using System.Data;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
    public class Requisicao : Control, IRequisicao
    {
        private Model.Requisicao entity = new Model.Requisicao();

        /// <summary>
        /// Listar todos os registros
        /// </summary>
        public RequisicaoDataTable Sel(RequisicaoDTO dto, bool apenasComQtdSolicitada)
        {
            return entity.Sel(dto, apenasComQtdSolicitada);
        }

        public RequisicaoDataTable SelImpressaoCentroDispensacao(RequisicaoDTO dto, bool soAtdDomiciliar)
        {
            return entity.SelImpressaoCentroDispensacao(dto, soAtdDomiciliar);
        }

        /// <summary>
        /// Obter pela chave
        /// </summary>
        public RequisicaoDTO SelChave(RequisicaoDTO dto)
        {
            return entity.SelChave(dto);
        }

        /// <summary>
        /// Listar as útimas requisições de acordo com o tipo e status
        /// </summary>
        public RequisicaoDataTable SelUltimas(RequisicaoDTO dto, int qtdUltimas)
        {
            return entity.SelUltimas(dto, qtdUltimas);
        }

        /// <summary>
        /// Pesquisa requições que nao foram enviadas ao almoxarifado do Paciente
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public RequisicaoDataTable RequisicaoPaciente(RequisicaoDTO dto)
        {
            return entity.RequisicaoPaciente(dto);
        }

        public RequisicaoDataTable ListarPacienteKits(RequisicaoDTO dto)
        {
            return entity.ListarPacienteKits(dto);
        }

        public void DispensarRequisicao(RequisicaoDTO dto)
        {
            entity.DispensarRequisicao(dto);
        }

        /// <summary>
        /// Salva Requisicao.
        /// O parâmetro dtbItens refere-se a todos os itens referentes à requisição, independente se foi fornecido ou não o item na hora da dispensação.
        /// </summary>        
        public RequisicaoDTO Gravar(RequisicaoDTO dto, RequisicaoItensDataTable dtbItens)
        {
            RequisicaoItensDataTable dtbItensPendentes = null;
            return this.Gravar(dto, dtbItens, ref dtbItensPendentes);
        }

        /// <summary>
        /// Salva Requisicao.
        /// O parâmetro dtbItens refere-se a todos os itens referentes à requisição, independente se foi fornecido ou não o item na hora da dispensação.
        /// O parâmetro dtbItensPendentes, retorna os itens que não foram fornecidos ou os que não possuem estoque suficiente no Centro de Dispensação para serem liberados.
        /// </summary>       
        public RequisicaoDTO Gravar(RequisicaoDTO dto,
                                    RequisicaoItensDataTable dtbItens,
                                    ref RequisicaoItensDataTable dtbItensPendentes)
        {
            // SegurancaDTO dtoSeguranca = (SegurancaDTO)Credential;
            // seg.Login(dtoSeguranca);           

            RequisicaoItens requisicaoItens = new RequisicaoItens();
            RequisicaoDTO dtoReqPendente = null;

            try
            {
                // BeginTransaction();
                bool atualizarReq = false;
                bool enviarAlmox = false;

                if (dto.Idt.Value.IsNull)
                {
                    if (dto.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.FECHADA)
                    {
                        enviarAlmox = true;
                        atualizarReq = true;
                        dto.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.ABERTA;
                    }
                    dto = Ins(dto);
                }
                else
                {
                    atualizarReq = true;
                }

                #region Exclusão de itens
                DataTable dtbDeleted = dtbItens.GetChanges(DataRowState.Deleted);
                if (dtbDeleted != null)
                {
                    RequisicaoItensDTO dtoItens;
                    foreach (DataRow row in dtbDeleted.Rows)
                    {
                        if (!Convert.IsDBNull(row[DTO.RequisicaoItensDTO.FieldNames.Idt, DataRowVersion.Original]))
                        {
                            dtoItens = new RequisicaoItensDTO();
                            dtoItens.Idt.Value = Convert.ToInt64(row[RequisicaoItensDTO.FieldNames.Idt, DataRowVersion.Original]);
                            dtoItens.IdtProduto.Value = Convert.ToInt64(row[RequisicaoItensDTO.FieldNames.IdtProduto, DataRowVersion.Original]);
                            requisicaoItens.Del(dtoItens);

                            //dtoItens.IdUsuarioPedidoAutoCancelado.Value = dto.IdtUsuario.Value;
                            requisicaoItens.DelPedidoAutoControle(dtoItens);
                        }
                    }
                }
                #endregion

                //MaterialMedicamento MatMed = new MaterialMedicamento();
                MaterialMedicamentoDTO dtoMatMed = new MaterialMedicamentoDTO();
                RequisicaoItensDTO dtoReqItemPendente;
                PedidoPadraoDTO dtoPedidoPadrao;
                PedidoPadrao PedPad;

                foreach (DataRow row in dtbItens.Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        RequisicaoItensDTO dtoRequisicaoItem = (RequisicaoItensDTO)row;
                        Movimentacao Movimento = new Movimentacao();
                        RequisicaoItens ReqItens = new RequisicaoItens();

                        if (dto.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX)
                        {
                            bool gerarReqPendente = true;
                            if (dto.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.PADRAO &&
                                dtoRequisicaoItem.IdtPrincipioAtivo.Value != 0)
                            {
                                dtoMatMed = new MaterialMedicamentoDTO();
                                dtoPedidoPadrao = new PedidoPadraoDTO();
                                PedPad = new PedidoPadrao();

                                dtoPedidoPadrao.IdtUnidade = dto.IdtUnidade;
                                dtoPedidoPadrao.IdtSetor = dto.IdtSetor;
                                dtoPedidoPadrao.IdtLocal = dto.IdtLocal;
                                dtoPedidoPadrao.IdtFilial = dto.IdtFilial;
                                dtoPedidoPadrao.Status.Value = (byte)PedidoPadraoDTO.StatusPedidoPadrao.CONFIRMADO;
                                dtoMatMed.Idt.Value = dtoRequisicaoItem.IdtProduto.Value;
                                //Não adicionar na req. pendente quando for produto similar e não fizer parte do pedido padrão
                                gerarReqPendente = PedPad.ProdutoPadrao(dtoPedidoPadrao, dtoMatMed);
                            }

                            if (dtoRequisicaoItem.QtdSolicitada.Value == 0) continue;
                            if (dtoRequisicaoItem.QtdFornecida.Value.IsNull) dtoRequisicaoItem = ReqItens.CalculaQtdFornecidaAlmoxarifado(dtoRequisicaoItem);
                            if (dtoRequisicaoItem.QtdePadrao.Value.IsNull) dtoRequisicaoItem.QtdePadrao.Value = 0;

                            //Cria requisição pendente para produtos que não tenham qtd. suficiente no centro de dispensação,
                            //ou quando não foi fornecido os itens de acordo com a qts. solicitada e o estoque não esteja cheio quando padrão
                            if ((dtoRequisicaoItem.QtdFornecida.Value < dtoRequisicaoItem.QtdSolicitada.Value && dtoRequisicaoItem.EstoqueLocalQtde.Value < dtoRequisicaoItem.QtdePadrao.Value)
                                || (dtoRequisicaoItem.QtdFornecida.Value < dtoRequisicaoItem.QtdSolicitada.Value && dto.IdtTipoRequisicao.Value != (byte)RequisicaoDTO.TipoRequisicao.PADRAO)
                                || dtoRequisicaoItem.EstoqueCentDispQtde.Value < dtoRequisicaoItem.QtdFornecida.Value)
                            {
                                if (dtbItensPendentes == null) dtbItensPendentes = new RequisicaoItensDataTable();

                                if (dtoReqPendente == null)
                                {
                                    dtoReqPendente = new RequisicaoDTO();

                                    dtoReqPendente.IdtFilial = dto.IdtFilial;
                                    dtoReqPendente.IdtSetor = dto.IdtSetor;
                                    dtoReqPendente.IdtLocal = dto.IdtLocal;
                                    dtoReqPendente.IdtUnidade = dto.IdtUnidade;
                                    dtoReqPendente.TpAtendimento = dto.TpAtendimento;
                                    dtoReqPendente.IdtAtendimento = dto.IdtAtendimento;
                                    dtoReqPendente.IdtTipoRequisicao = dto.IdtTipoRequisicao;
                                    dtoReqPendente.IdtUsuario = dto.IdtUsuario;
                                    dtoReqPendente.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.ABERTA;
                                    dtoReqPendente.FlPendente.Value = (byte)RequisicaoDTO.Pendente.SIM;
                                    dtoReqPendente.IdtReqRef.Value = dto.Idt.Value;
                                }

                                dtoReqItemPendente = (RequisicaoItensDTO)row;
                                dtoReqItemPendente.Idt.Value = dtoReqPendente.Idt.Value;
                                dtoReqItemPendente.QtdFornecida.Value = 0;

                                if (dtoRequisicaoItem.EstoqueCentDispQtde.Value < dtoRequisicaoItem.QtdFornecida.Value)
                                {
                                    //Fornece a qtd. existente no centro de dispensação
                                    dtoRequisicaoItem.QtdFornecida.Value = dtoRequisicaoItem.EstoqueCentDispQtde.Value;
                                }

                                if (dto.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.PADRAO)
                                {
                                    string filtroMatMedPA = string.Format("{0} = {1}", RequisicaoItensDTO.FieldNames.IdtPrincipioAtivo, dtoRequisicaoItem.IdtPrincipioAtivo.Value);
                                    DataRow[] rowsReqItemPA = dtbItens.Select(filtroMatMedPA);
                                    int qtdTotalFornedidaSimilar = 0;

                                    foreach (DataRow rowItemPA in rowsReqItemPA)
                                    {
                                        qtdTotalFornedidaSimilar += ((int)((RequisicaoItensDTO)rowItemPA).QtdFornecida.Value);
                                    }

                                    dtoReqItemPendente.QtdSolicitada.Value = ((int)dtoRequisicaoItem.QtdePadrao.Value - ((int)dtoRequisicaoItem.EstoqueLocalPadraoQtde.Value + qtdTotalFornedidaSimilar));
                                }
                                else
                                {
                                    dtoReqItemPendente.QtdSolicitada.Value = (int)dtoRequisicaoItem.QtdSolicitada.Value - (int)dtoRequisicaoItem.QtdFornecida.Value;
                                }
                                if (dtoRequisicaoItem.QtdSolicitada.Value <= 0) continue;
                                if (gerarReqPendente) dtbItensPendentes.Add(dtoReqItemPendente);
                            }
                            if (dtoRequisicaoItem.QtdFornecida.Value == 0)
                            {
                                requisicaoItens.Upd(dtoRequisicaoItem);
                                continue;
                            }
                        }

                        // SO GRAVA QTDE FORNECIDA QUANDO FOR LIBERACAO DO ALMOXARIFADO
                        if (dto.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.ABERTA)
                        {
                            dtoRequisicaoItem.QtdFornecida.Value = 0;
                        }
                        if (dto.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.FECHADA)
                        {
                            dtoRequisicaoItem.QtdFornecida.Value = 0;
                        }

                        #region Insere / Atualiza Itens
                        if (row.RowState == DataRowState.Added)
                        {
                            dtoRequisicaoItem.Idt.Value = dto.Idt.Value;

                            if (dtoRequisicaoItem.QtdSolicitada.Value > 0 || !dtoRequisicaoItem.JustificativaCancelamento.Value.IsNull)
                            {
                                //if (dtoRequisicaoItem.JustificativaCancelamento.Value.IsNull && dto.Urgencia.Value != 1 && !dtoRequisicaoItem.HorasPeriodoDose.Value.IsNull && dtoRequisicaoItem.QtdSolicitada.Value == 0)
                                //{
                                //    RequisicaoItensDTO dtoItemVerifica = new RequisicaoItensDTO();
                                //    dtoItemVerifica.Idt.Value = dtoRequisicaoItem.Idt.Value;
                                //    dtoItemVerifica.IdtProduto.Value = dtoRequisicaoItem.IdtProduto.Value;
                                //    RequisicaoItensDataTable dtbItemVerifica = requisicaoItens.Sel(dtoItemVerifica);
                                //    if (dtbItemVerifica.Rows.Count == 0)
                                //        requisicaoItens.Ins(dtoRequisicaoItem);
                                //    else
                                //        continue;
                                //}
                                if (dtoRequisicaoItem.QtdSolicitada.Value > 0 || dto.Urgencia.Value == 1)
                                    requisicaoItens.Ins(dtoRequisicaoItem);
                                else if (!dtoRequisicaoItem.JustificativaCancelamento.Value.IsNull && dto.Urgencia.Value != 1 && !dtoRequisicaoItem.HorasPeriodoDose.Value.IsNull)
                                    requisicaoItens.Ins(dtoRequisicaoItem);                                
                                else //Se for justificativa de cancelamento de item imediato não insere zerado no pedido  origem
                                    continue;
                            }

                            if (!dtoRequisicaoItem.HorasPeriodoDose.Value.IsNull && dtoRequisicaoItem.HorasPeriodoDose.Value > 0)
                            {
                                if (!enviarAlmox && !dto.IdtAtendimento.Value.IsNull && dto.FlPendente.Value != 1 && dto.Urgencia.Value != 1)
                                {
                                    dtoRequisicaoItem.QtdPedidoGerar.Value = dtoRequisicaoItem.QtdSolicitada.Value;
                                    dtoRequisicaoItem.IdtUsuarioDispensacao.Value = dto.IdtUsuario.Value;
                                    requisicaoItens.InsPedidoAutoControle(dtoRequisicaoItem);
                                }
                            }
                        }
                        if (row.RowState == DataRowState.Modified)
                        {
                            requisicaoItens.Upd(dtoRequisicaoItem);

                            if (!dtoRequisicaoItem.HorasPeriodoDose.Value.IsNull && dtoRequisicaoItem.HorasPeriodoDose.Value > 0)
                            {
                                if (!enviarAlmox && !dto.IdtAtendimento.Value.IsNull && dto.FlPendente.Value != 1 && dto.Urgencia.Value != 1)
                                {
                                    dtoRequisicaoItem.QtdPedidoGerar.Value = dtoRequisicaoItem.QtdSolicitada.Value;
                                    dtoRequisicaoItem.IdtUsuarioDispensacao.Value = dto.IdtUsuario.Value;
                                    requisicaoItens.UpdPedidoAutoControle(dtoRequisicaoItem, null);
                                }
                            }
                        }
                        if (enviarAlmox || dto.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.FECHADA)
                        {
                            if (!dto.IdtAtendimento.Value.IsNull && !dtoRequisicaoItem.HorasPeriodoDose.Value.IsNull && dto.FlPendente.Value != 1 && dto.Urgencia.Value != 1)
                            {
                                if (dtoRequisicaoItem.HorasPeriodoDose.Value > 0 && dtoRequisicaoItem.QtdSolicitada.Value > 0)
                                {
                                    dtoRequisicaoItem.QtdPedidoGerar.Value = dtoRequisicaoItem.QtdSolicitada.Value;
                                    dtoRequisicaoItem.IdtUsuarioDispensacao.Value = dto.IdtUsuario.Value;
                                    this.GerarPedidoAutoControle(dto, dtoRequisicaoItem);
                                }
                            }
                            if (!dtoRequisicaoItem.IdPrescricaoItemInternacao.Value.IsNull)
                            {
                                requisicaoItens.UpdStatusItemPrescricaoInt(null,
                                                                           (int)dtoRequisicaoItem.IdPrescricaoItemInternacao.Value,
                                                                           (int)dto.IdtUsuario.Value,
                                                                           "GE");
                            }
                            new Model.RequisicaoItens().EnviarEmailProdutoAltoCusto(dtoRequisicaoItem);                                
                        }
                        #endregion

                        #region DISPENSADA
                        //#region RECEBIDA_UNIDADE (Realizar a transferência física do produto)
                        //if (dto.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.RECEBIDA_UNIDADE)
                        if (dto.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX)
                        {
                            MovimentacaoDTO dtoMovimento = new MovimentacaoDTO();
                            // unidade de entrada
                            dtoMovimento.IdtUnidade.Value = dto.IdtUnidade.Value;
                            dtoMovimento.IdtLocal.Value = dto.IdtLocal.Value;
                            dtoMovimento.IdtSetor.Value = dto.IdtSetor.Value;
                            // unidade baixa
                            SetorDTO dtoSetFarm;
                            dtoMovimento = Movimento.CentroDispensacao(dtoMovimento, out dtoSetFarm);
                            //
                            dtoMovimento.IdtFilial.Value = dto.IdtFilial.Value;
                            dtoMovimento.IdtProduto.Value = dtoRequisicaoItem.IdtProduto.Value;
                            dtoMovimento.IdtLote.Value = "";
                            dtoMovimento.Qtde.Value = dtoRequisicaoItem.QtdFornecida.Value;
                            dtoMovimento.IdtAtendimento.Value = dto.IdtAtendimento.Value;
                            dtoMovimento.TpAtendimento.Value = dto.TpAtendimento.Value;
                            dtoMovimento.IdtTipo.Value = (byte)MovimentacaoDTO.TipoMovimento.ENTRADA;
                            dtoMovimento.IdtTipoBaixa.Value = (byte)MovimentacaoDTO.TipoMovimento.SAIDA;
                            dtoMovimento.IdtRequisicao.Value = dto.Idt.Value;
                            if (dto.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO)
                            {
                                dtoMovimento.IdtSubTipo.Value = (byte)MovimentacaoDTO.SubTipoMovimento.ENTRADA_RESSUPRIMENTO_PERSONALIZADO;
                                dtoMovimento.IdtSubTipoBaixa.Value = (byte)MovimentacaoDTO.SubTipoMovimento.BAIXA_CENTRAL_PERSONALIZADO;
                            }
                            if (dto.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.PADRAO)
                            {
                                dtoMovimento.IdtSubTipo.Value = (byte)MovimentacaoDTO.SubTipoMovimento.ENTRADA_RESSUPRIMENTO_REQ_PADRAO;
                                dtoMovimento.IdtSubTipoBaixa.Value = (byte)MovimentacaoDTO.SubTipoMovimento.BAIXA_CENTRAL_REQ_PADRAO;
                            }
                            if (dto.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.IMPRESSOS_MAT_EXPEDIENTE)
                            {
                                dtoMovimento.IdtSubTipo.Value = (byte)MovimentacaoDTO.SubTipoMovimento.ENTRADA_RESSUPRIMENTO_REQ_AVULSA;
                                dtoMovimento.IdtSubTipoBaixa.Value = (byte)MovimentacaoDTO.SubTipoMovimento.BAIXA_CENTRAL_REQ_AVULSA;
                            }
                            if (dto.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.CARRINHO_EMERGENCIA)
                            {
                                dtoMovimento.IdtSubTipo.Value = (byte)MovimentacaoDTO.SubTipoMovimento.ENTRADA_RESSUPRIMENTO_CARRINHO_EMERGENCIA;
                                dtoMovimento.IdtSubTipoBaixa.Value = (byte)MovimentacaoDTO.SubTipoMovimento.BAIXA_RESSUPRIMENTO_CARRINHO_EMERGENCIA;
                            }
                            dtoMovimento.IdtUsuario.Value = dto.IdtUsuario.Value;

                            Movimento.TransfereEstoqueProduto(dtoMovimento);
                        }
                        #endregion

                    }   // NOT rowstate deleted                     
                }

                if (dto.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX &&
                    (dto.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.PADRAO ||
                     dto.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.CARRINHO_EMERGENCIA))
                {
                    PedidoPadraoDataTable dtbPedidoPadrao = new PedidoPadraoDataTable();
                    dtoPedidoPadrao = new PedidoPadraoDTO();
                    PedPad = new PedidoPadrao();

                    dtoPedidoPadrao.IdtUnidade = dto.IdtUnidade;
                    dtoPedidoPadrao.IdtSetor = dto.IdtSetor;
                    dtoPedidoPadrao.IdtLocal = dto.IdtLocal;
                    dtoPedidoPadrao.IdtFilial = dto.IdtFilial;

                    dtbPedidoPadrao = PedPad.Sel(dtoPedidoPadrao);

                    if (dtbPedidoPadrao.Rows.Count > 0)
                    {
                        dtoPedidoPadrao.Idt.Value = dtbPedidoPadrao.Rows[0][PedidoPadraoDTO.FieldNames.Idt].ToString();
                        PedPad.UpdDataDispensacao(dtoPedidoPadrao);
                    }
                }

                if (atualizarReq)
                {
                    if (enviarAlmox) dto.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.FECHADA;
                    Upd(dto);
                }

                if (dtbItensPendentes != null)
                {
                    if (dtoReqPendente != null && dtbItensPendentes.Rows.Count > 0)
                    {
                        if (dto.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO)
                        {
                            //Faz uma limpeza nos que possuem mais de um princípio ativo
                            string filtroMatMedPA;
                            DataRow[] rowsReqItemPA;
                            RequisicaoItensDTO dtoItemAux, dtoItemPA1, dtoItemPA2;
                            decimal qtdReqSimilar = 0, idProdutoOriginal = 0;
                            DataRow[] rowsItensPend = dtbItensPendentes.Select(string.Empty, RequisicaoItensDTO.FieldNames.IdtPrincipioAtivo); //Ordena por princípio ativo para a lógica dentro do looping abaixo dar certo

                            for (int nCount = 0; nCount < rowsItensPend.Length; nCount++)
                            {
                                dtoItemAux = (RequisicaoItensDTO)rowsItensPend[nCount];
                                if (dtoItemAux.IdtPrincipioAtivo.Value != 0)
                                {
                                    filtroMatMedPA = string.Format("{0} = {1}", RequisicaoItensDTO.FieldNames.IdtPrincipioAtivo, dtoItemAux.IdtPrincipioAtivo.Value);
                                    rowsReqItemPA = dtbItensPendentes.Select(filtroMatMedPA);

                                    if (rowsReqItemPA.Length > 1)
                                    {
                                        //Tem 2 similares
                                        dtoItemPA1 = (RequisicaoItensDTO)rowsReqItemPA[0];
                                        dtoItemPA2 = (RequisicaoItensDTO)rowsReqItemPA[1];

                                        if (dtoItemPA1.IdtProduto.Value.ToString() == dtoItemAux.IdtProduto.Value.ToString())
                                        {
                                            if (long.Parse(dtoItemPA1.QtdSolicitada.Value.ToString()) <= long.Parse(dtoItemPA2.QtdSolicitada.Value.ToString()))
                                            {
                                                //Deletar produto similar (não original da requisição)
                                                idProdutoOriginal = (decimal)dtoItemPA2.IdtProduto.Value; //dtoItemPA2 é o original
                                                qtdReqSimilar = (decimal)dtoItemAux.QtdSolicitada.Value;
                                                rowsItensPend[nCount].Delete();
                                            }
                                            else
                                            {
                                                qtdReqSimilar = 0;
                                            }
                                        }
                                        else if (dtoItemPA2.IdtProduto.Value.ToString() == dtoItemAux.IdtProduto.Value.ToString())
                                        {
                                            if (long.Parse(dtoItemPA2.QtdSolicitada.Value.ToString()) <= long.Parse(dtoItemPA1.QtdSolicitada.Value.ToString()))
                                            {
                                                //Deletar produto similar (não original da requisição)
                                                idProdutoOriginal = (decimal)dtoItemPA1.IdtProduto.Value; //dtoItemPA1 é o original
                                                qtdReqSimilar = (decimal)dtoItemAux.QtdSolicitada.Value;
                                                rowsItensPend[nCount].Delete();
                                            }
                                            else
                                            {
                                                qtdReqSimilar = 0;
                                            }
                                        }
                                        if (qtdReqSimilar > 0 && idProdutoOriginal > 0)
                                        {
                                            //Atualizar qtd. item original com a qtd. que tinha sido req. p/ o produto similar
                                            dtbItensPendentes.Select(string.Format("{0} = {1}", RequisicaoItensDTO.FieldNames.IdtProduto, idProdutoOriginal))[0][RequisicaoItensDTO.FieldNames.QtdSolicitada] = qtdReqSimilar;
                                            qtdReqSimilar = 0; idProdutoOriginal = 0;
                                        }
                                    }
                                }
                            }
                        }
                        DataView dvReqItemPend = new DataView(dtbItensPendentes, string.Format("{0} > 0", RequisicaoItensDTO.FieldNames.QtdSolicitada), string.Empty, DataViewRowState.Added);
                        if (dvReqItemPend.Count > 0)
                        {
                            //Gravar requisição pendente se houver
                            dtoReqPendente.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.ABERTA;
                            this.Gravar(dtoReqPendente, dtbItensPendentes);
                        }
                    }
                }

                // CommitTransaction();
            }
            catch (HacException ex)
            {
                throw new HacException(ex.Message);
            }
            catch (Exception ex)
            {
                // RollbackTransaction();
                //throw new HacException(" Erro, foi realizado RollBack da transação ", ex);
                throw new HacException(ex.Message, ex);
            }

            if (dtbItensPendentes == null) dtbItensPendentes = new RequisicaoItensDataTable();

            return dto;
        }

        private bool HorarioPadraoSetor(int qtdTotalHorasGerar, int horaInicio, int periodo, DateTime dataVerificar)
        {
            DateTime dataHoraInicioProcessoSetor = DateTime.Parse((DateTime.Now.Date.AddHours(-qtdTotalHorasGerar).ToString("dd/MM/yyyy") + " " + horaInicio.ToString().PadLeft(2, '0') + ":00"));
            DateTime dataHoraFimProcessoSetor = DateTime.Parse((DateTime.Now.Date.AddHours(+qtdTotalHorasGerar).ToString("dd/MM/yyyy") + " " + horaInicio.ToString().PadLeft(2, '0') + ":00"));

            for (DateTime contData = dataHoraInicioProcessoSetor; contData <= dataHoraFimProcessoSetor; contData = contData.AddHours(periodo))
            {
                if (contData == dataVerificar) return true;
                if (contData > dataVerificar) return false;
            }
            return false;
        }

        /// <summary>
        /// ObterQtdDosesTotalItemHorario
        /// </summary>
        /// <param name="dataHoraInicio">Hora Inicio Adm. Pac.</param>
        /// <param name="dataHoraFim">Hora Fim Adm. Pac.</param>
        /// <param name="dataEmissaoSetor">Data Ref. Emissao Setor</param>
        /// <param name="periodo">Periodo Adm. Item</param>
        /// <param name="qtdDose">Qtd. Dose Pedido</param>
        private int ObterQtdDosesTotalItemHorario(DateTime dataHoraInicio, DateTime dataHoraFim, DateTime dataEmissaoSetor, int periodo, int qtdDose, int horasMinimaParaAbastecimento)
        {
            int qtdeTotal = 0;
            for (DateTime contData = dataHoraInicio; contData <= dataHoraFim; contData = contData.AddHours(periodo))
            {
                if (contData < dataEmissaoSetor || contData < dataEmissaoSetor.AddHours(horasMinimaParaAbastecimento))
                    qtdeTotal += qtdDose;
                else
                    return qtdeTotal;
            }
            return qtdeTotal;
        }

        public DateTime DataInicioCorteDiaSeguintePrescricao(DateTime dataFimCorte, int periodoGerarSetor, int horasMinimaParaAbastecimento, out bool ultrapassouCorte)
        {
            DateTime dataAtual = DateTime.Now;
            DateTime dataAtualHoraCheia = DateTime.Parse(dataAtual.ToString("dd/MM/yyyy HH:00"));
            DateTime dataInicioCorte = dataAtual;
            for (DateTime contData = dataFimCorte; contData >= dataAtualHoraCheia.AddHours(1); contData = contData.AddHours(-periodoGerarSetor))
            {
                dataInicioCorte = contData;
            }
            //if (dataInicioCorte >= dataFimCorte || dataAtual >= dataFimCorte.AddHours(-(periodoGerarSetor + horasMinimaParaAbastecimento)))
            if (dataInicioCorte >= dataFimCorte || dataAtual >= dataFimCorte.AddHours(-(periodoGerarSetor)))
                ultrapassouCorte = true;
            else
                ultrapassouCorte = false;

            return dataInicioCorte;
        }        

        private void GerarPedidoAutoControle(RequisicaoDTO dtoPedido, RequisicaoItensDTO dtoItem)
        {
            RequisicaoItens reqItem = new RequisicaoItens();
            reqItem.DelPedidoAutoControle(dtoItem);

            RequisicaoDataTable dtbReq = this.ListarParamPedidoAuto(dtoPedido);
            dtbReq = (RequisicaoDataTable)new Utilitario().ValidarVigencia(DateTime.Now,
                                                                           RequisicaoDTO.FieldNames.SetorPedidoAutoDtHoraIniVigencia,
                                                                           RequisicaoDTO.FieldNames.SetorPedidoAutoDtHoraFimVigencia,
                                                                           dtbReq);
            if (dtbReq.Rows.Count > 0)
            {
                bool gerarPedidoTotalImediato = false;
                if (!dtbReq.TypedRow(0).SetorPedidoAutoFlTotalImediato.Value.IsNull)
                    gerarPedidoTotalImediato = (dtbReq.TypedRow(0).SetorPedidoAutoFlTotalImediato.Value == 1 ? true : false);
                
                if (gerarPedidoTotalImediato) return; //Não gerar individual para setores com geração total imediata

                int periodoGerarSetor = (int)dtbReq.TypedRow(0).SetorPedidoAutoHorasPeriodoDose.Value;
                int horaCorteSetor = (int)dtbReq.TypedRow(0).SetorPedidoAutoHoraInicioProcesso.Value;
                int horasMinimaParaAbastecimento = (int)dtbReq.TypedRow(0).SetorPedidoAutoHorasMinimaIniciar.Value;
                DateTime dataAtual = DateTime.Now;
                DateTime dataAtualHoraCheia = DateTime.Parse(dataAtual.ToString("dd/MM/yyyy HH:00"));
                DateTime? dataPrescricaoCriacao = null;
                DateTime dataInicioCorte; DateTime dataFimCorte; DateTime dataInicioEmissao;
                bool diaSeguintePrescricao = false;
                if (!dtoItem.IdPrescricaoInternacao.Value.IsNull)
                {
                    DataTable dtbPresc = this.ListarPrescricaoInt(new RequisicaoDTO(), (int)dtoItem.IdPrescricaoInternacao.Value, null, false);
                    if (dtbPresc.Rows.Count > 0)
                    {
                        dataPrescricaoCriacao = DateTime.Parse(dtbPresc.Rows[0]["DT_HORA_PRESCRICAO"].ToString());
                        if (dataAtual.Date == dataPrescricaoCriacao.Value.AddDays(1).Date)
                            diaSeguintePrescricao = true;
                        else if (dataPrescricaoCriacao.Value.Date <= dataAtual.AddDays(-2).Date)
                        {
                            dtoItem.QtdSolicitada.Value = 0;
                            dtoItem.JustificativaCancelamento.Value = "PRESCRIÇÃO FORA DO PRAZO.";
                            reqItem.Upd(dtoItem);
                            return; //Não gerar nada para prescrição de 2 dias atrás
                        }
                    }
                }
                if (diaSeguintePrescricao)
                {
                    bool ultrapassouCorte;
                    dataFimCorte = DateTime.Parse(dataAtual.Date.ToString("dd/MM/yyyy") + " " + horaCorteSetor.ToString().PadLeft(2, '0') + ":00");
                    dataInicioCorte = this.DataInicioCorteDiaSeguintePrescricao(dataFimCorte, periodoGerarSetor, horasMinimaParaAbastecimento, out ultrapassouCorte);
                    if (ultrapassouCorte)
                    {
                        dtoItem.QtdSolicitada.Value = 0;
                        dtoItem.JustificativaCancelamento.Value = "PRESCRIÇÃO ULTRAPASSOU LIMITE PARA PEDIDO DA DATA/HORA DE CORTE.";
                        reqItem.Upd(dtoItem);
                        return; //Não gerar nada se passou da última hora de corte
                    }

                    dataInicioEmissao = dataInicioCorte.AddHours(-horasMinimaParaAbastecimento);
                }
                else
                {
                    dataInicioCorte = reqItem.ObterDataInicioAdmPacientePadrao(dtbReq.TypedRow(0), out dataInicioEmissao);

                    if (dataInicioCorte.Date == dataAtual.Date)
                        dataFimCorte = DateTime.Parse(dataInicioCorte.AddDays(1).Date.ToString("dd/MM/yyyy") + " " + horaCorteSetor.ToString().PadLeft(2, '0') + ":00");
                    else
                        dataFimCorte = DateTime.Parse(dataAtual.AddDays(1).Date.ToString("dd/MM/yyyy") + " " + horaCorteSetor.ToString().PadLeft(2, '0') + ":00");

                    if (dataAtual > dataFimCorte)
                        dataFimCorte = dataFimCorte.AddHours(periodoGerarSetor);
                }
                DateTime dataFimEmissao = dataFimCorte.AddHours(-horasMinimaParaAbastecimento);
                int qtdHorasTotalGerar = (int)dataFimEmissao.Subtract(dataInicioEmissao).TotalHours;
                DateTime? dataHoraInicioProcessoSetor = dataInicioEmissao;
                if (dataHoraInicioProcessoSetor == null) return;
                if (dtoItem.QtdPedidoGerar.Value.IsNull && !dtoItem.QtdSolicitada.Value.IsNull) dtoItem.QtdPedidoGerar.Value = dtoItem.QtdSolicitada.Value;

                DateTime dataInicioAdmPac; DateTime? dataAdmPacAnterior = null;
                if (!dtoItem.DataHoraAdmPaciente.Value.IsNull)
                    dataInicioAdmPac = (DateTime)dtoItem.DataHoraAdmPaciente.Value;
                else
                    dataInicioAdmPac = dataHoraInicioProcessoSetor.Value.AddHours(horasMinimaParaAbastecimento);

                if (diaSeguintePrescricao && dataInicioAdmPac >= dataFimCorte)
                {
                    dataInicioAdmPac = dataFimEmissao;
                }

                if (dataInicioAdmPac < dataInicioCorte || dataInicioAdmPac < dataInicioEmissao)
                {
                    qtdHorasTotalGerar = (int)dataFimCorte.Subtract(dataInicioAdmPac).TotalHours;
                }

                int qtdPedido = (int)dtoItem.QtdPedidoGerar.Value;
                int periodoGerarItem = (int)dtoItem.HorasPeriodoDose.Value;
                int qtdPedidoTotalGeradosItem = 0; int qtdPedidoGerar = 0;
                int qtdPedidoTotalGerarItem = reqItem.ObterQtdPedidoTotalGerarItem(qtdHorasTotalGerar, periodoGerarItem, (int)dtoItem.QtdPedidoGerar.Value);
                int dosesTotalInicioCorte = 0;
                if (dataInicioAdmPac < dataInicioCorte || dataInicioAdmPac < dataInicioEmissao) //Neste caso tem que adiantar uma dose fora do processo automático
                {
                    dosesTotalInicioCorte = this.ObterQtdDosesTotalItemHorario(dataInicioAdmPac,
                                                                               dataInicioCorte,
                                                                               dataHoraInicioProcessoSetor.Value.AddHours(periodoGerarSetor),
                                                                               periodoGerarItem,
                                                                               qtdPedido,
                                                                               horasMinimaParaAbastecimento);
                    if (dosesTotalInicioCorte == qtdPedido)
                    {
                        dtoItem.DataHoraGerar.Value = dataAtual;
                        dtoItem.DataHoraAdmPaciente.Value = dataInicioAdmPac;
                        dtoItem.QtdPedidoGerar.Value = dosesTotalInicioCorte;

                        reqItem.InsPedidoAutoControle(dtoItem);

                        //dataInicioAdmPac = dataInicioAdmPac.AddHours(periodoGerarItem);
                        dataAdmPacAnterior = dataInicioAdmPac;

                        qtdPedidoTotalGeradosItem = dosesTotalInicioCorte;
                    }
                    else
                    {
                        for (DateTime contDataSetor = dataAtualHoraCheia; contDataSetor <= dataInicioEmissao; contDataSetor = contDataSetor.AddHours(periodoGerarSetor))
                        {
                            int dosesTotalHorario = this.ObterQtdDosesTotalItemHorario(dataInicioAdmPac,
                                                                                       dataInicioEmissao,
                                                                                       contDataSetor.AddHours(periodoGerarSetor),
                                                                                       periodoGerarItem,
                                                                                       qtdPedido,
                                                                                       horasMinimaParaAbastecimento);
                            if (dosesTotalHorario > qtdPedidoTotalGeradosItem)
                                qtdPedidoGerar = dosesTotalHorario - qtdPedidoTotalGeradosItem;
                            else
                                continue;

                            if (qtdPedidoGerar > qtdPedidoTotalGerarItem)
                                qtdPedidoGerar = qtdPedidoTotalGerarItem - qtdPedidoTotalGeradosItem;

                            qtdPedidoTotalGeradosItem += qtdPedidoGerar;

                            if (qtdPedidoGerar > 0)
                            {
                                dtoItem.DataHoraGerar.Value = contDataSetor;
                                if (dataAdmPacAnterior == null)
                                    dtoItem.DataHoraAdmPaciente.Value = dataInicioAdmPac;
                                else
                                    dtoItem.DataHoraAdmPaciente.Value = dataAdmPacAnterior.Value.AddHours(periodoGerarItem);

                                if (qtdPedidoGerar <= qtdPedido)
                                {
                                    dtoItem.QtdPedidoGerar.Value = qtdPedidoGerar;

                                    dataAdmPacAnterior = (DateTime)dtoItem.DataHoraAdmPaciente.Value;

                                    reqItem.InsPedidoAutoControle(dtoItem);
                                }
                                else
                                {
                                    //Quando acumular mais de 1 pedido, gerar um registro para cada hora de adm.
                                    int qtdPedidos = qtdPedidoGerar / qtdPedido;
                                    for (int cont = 1; cont <= qtdPedidos; cont++)
                                    {
                                        dtoItem.QtdPedidoGerar.Value = qtdPedido;

                                        if (cont > 1)
                                            dtoItem.DataHoraAdmPaciente.Value = dataAdmPacAnterior.Value.AddHours(periodoGerarItem);

                                        dataAdmPacAnterior = (DateTime)dtoItem.DataHoraAdmPaciente.Value;

                                        reqItem.InsPedidoAutoControle(dtoItem);
                                    }
                                }
                            }
                            else
                                break;

                            if (qtdPedidoTotalGeradosItem == dosesTotalHorario) break;
                        }
                    }
                }

                for (DateTime contDataSetor = dataHoraInicioProcessoSetor.Value; contDataSetor <= dataFimEmissao; contDataSetor = contDataSetor.AddHours(periodoGerarSetor))
                {
                    int dosesTotalHorario = this.ObterQtdDosesTotalItemHorario(dataInicioAdmPac,
                                                                               dataFimCorte,
                                                                               contDataSetor.AddHours(periodoGerarSetor),
                                                                               periodoGerarItem,
                                                                               qtdPedido,
                                                                               horasMinimaParaAbastecimento);
                    if (dosesTotalHorario > qtdPedidoTotalGeradosItem)
                        qtdPedidoGerar = dosesTotalHorario - qtdPedidoTotalGeradosItem;
                    else
                        continue;

                    if (qtdPedidoGerar > qtdPedidoTotalGerarItem)
                        qtdPedidoGerar = qtdPedidoTotalGerarItem - qtdPedidoTotalGeradosItem;

                    qtdPedidoTotalGeradosItem += qtdPedidoGerar;

                    if (qtdPedidoTotalGeradosItem > qtdPedidoTotalGerarItem)
                    {
                        qtdPedidoGerar = qtdPedidoTotalGeradosItem - qtdPedidoTotalGerarItem;
                        qtdPedidoTotalGeradosItem = qtdPedidoTotalGerarItem;
                    }

                    if (qtdPedidoGerar > 0)
                    {
                        dtoItem.DataHoraGerar.Value = contDataSetor;
                        if (dataAdmPacAnterior == null)
                            dtoItem.DataHoraAdmPaciente.Value = dataInicioAdmPac; //contDataSetor.AddHours(horasMinimaParaAbastecimento);
                        else
                            dtoItem.DataHoraAdmPaciente.Value = dataAdmPacAnterior.Value.AddHours(periodoGerarItem);

                        if (qtdPedidoGerar <= qtdPedido)
                        {
                            dtoItem.QtdPedidoGerar.Value = qtdPedidoGerar;

                            dataAdmPacAnterior = (DateTime)dtoItem.DataHoraAdmPaciente.Value;

                            if ((DateTime)dtoItem.DataHoraAdmPaciente.Value == dataFimCorte) break; //Não gerar se a última dose for no horário final de corte

                            reqItem.InsPedidoAutoControle(dtoItem);
                        }
                        else
                        {
                            //Quando acumular mais de 1 pedido, gerar um registro para cada hora de adm.
                            int qtdPedidos = qtdPedidoGerar / qtdPedido;
                            for (int cont = 1; cont <= qtdPedidos; cont++)
                            {
                                dtoItem.QtdPedidoGerar.Value = qtdPedido;

                                if (cont > 1)
                                    dtoItem.DataHoraAdmPaciente.Value = dataAdmPacAnterior.Value.AddHours(periodoGerarItem);

                                dataAdmPacAnterior = (DateTime)dtoItem.DataHoraAdmPaciente.Value;

                                if ((DateTime)dtoItem.DataHoraAdmPaciente.Value == dataFimCorte) break; //Não gerar se a última dose for no horário final de corte

                                reqItem.InsPedidoAutoControle(dtoItem);
                            }
                        }
                    }
                    else
                        break;

                    if (qtdPedidoTotalGeradosItem == qtdPedidoTotalGerarItem) break;
                }
                //Zerar item do Pedido Original
                dtoItem.QtdSolicitada.Value = 0;
                reqItem = new RequisicaoItens();
                reqItem.Upd(dtoItem);
                reqItem.AtualizarItemKit((int)dtoItem.Idt.Value,
                                         (int)dtoItem.IdtProduto.Value,
                                         null,
                                         null,
                                         (int)dtoItem.QtdSolicitada.Value);

                if (!dtoItem.IdPrescricaoItemInternacao.Value.IsNull)
                    reqItem.UpdStatusItemPrescricaoInt(null,
                                                       (int)dtoItem.IdPrescricaoItemInternacao.Value,
                                                       (int)dtoPedido.IdtUsuario.Value,
                                                       "GE");
            }
        }

        /// <summary>
        /// Só é usada para excluir requisições e movimentação e estoque em caso de erro no sistema
        /// </summary>
        /// <param name="dto"></param>
        private void EstornaRequisicao(RequisicaoDTO dto, RequisicaoItensDataTable dtbItens)
        {
            //this.Del(dto);
            //// se foi dispensado estorna movimentação também
            //if (dto.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX)
            //{
            //    MovimentacaoDTO dtoMovimento = new MovimentacaoDTO();
            //    // unidade de entrada
            //    dtoMovimento.IdtUnidade.Value = dto.IdtUnidade.Value;
            //    dtoMovimento.IdtLocal.Value = dto.IdtLocal.Value;
            //    dtoMovimento.IdtSetor.Value = dto.IdtSetor.Value;
            //    // unidade baixa
            //    dtoMovimento = Movimento.CentroDispensacao(dtoMovimento);
            //    //
            //    dtoMovimento.IdtFilial.Value = dto.IdtFilial.Value;
            //    dtoMovimento.IdtLote.Value = "";
            //    dtoMovimento.IdtInternado.Value = dto.NrInternacaoLegado.Value;
            //    dtoMovimento.IdtRequisicao.Value = dto.Idt.Value;
            //    Movimento.TransfereEstoqueProduto(dtoMovimento);
            //}
        }

        ///<summary>
        /// Insere um registro, retorna o ID da requisição 
        /// </summary>
        public RequisicaoDTO Ins(RequisicaoDTO dto)
        {
            // so grava quantidade fornecida quando status =2 ( liberado pelo almoxarifado )
            // COMMIT dentro da procedure, por ter retirado a "transaction"
            entity.Ins(dto);
            return dto;
        }

        ///<summary>
        /// Exclui o todos os registros inclusive os itens da requisição
        /// </summary>		
        public void Del(RequisicaoDTO dto)
        {
            entity.Del(dto);
        }

        ///<summary>
        /// Atualiza um registro
        /// </summary>		
        public void Upd(RequisicaoDTO dto)
        {
            // COMMIT dentro da procedure, por ter retirado a "transaction"
            entity.Upd(dto);
        }

        /// <summary>
        /// Transfere os itens(mat/med) do centro dispensação para setor da requisição.
        /// </summary>
        /// <param name="dtoRequisicao"></param>
        /// <param name="dtbReqItens"></param>
        public void Dispensar(RequisicaoDTO dtoRequisicao, RequisicaoItensDataTable dtbReqItens)
        {
            RequisicaoItens requisicaoItem = new RequisicaoItens();
            RequisicaoItensDTO dtoReqItem = new RequisicaoItensDTO();
            RequisicaoItensDataTable dtbItensPendentes = new RequisicaoItensDataTable();

            dtoReqItem.Idt.Value = dtoRequisicao.Idt.Value;

            dtbReqItens = requisicaoItem.SelItensRequisicao(dtoReqItem, true);

            dtoRequisicao.Status.Value = (int)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX;

            this.Gravar(dtoRequisicao, dtbReqItens, ref dtbItensPendentes);
        }

        public string RetornarStatus(RequisicaoDTO dtoRequisicao)
        {
            string retorno = string.Empty;
            switch ((byte)dtoRequisicao.Status.Value)
            {
                case (byte)RequisicaoDTO.StatusRequisicao.ABERTA:
                    if (dtoRequisicao.FlPendente.Value == (byte)RequisicaoDTO.Pendente.SIM)
                    {
                        retorno = "PENDENTE NO ALMOXARIFADO";
                    }
                    else
                    {
                        retorno = "EM EDIÇÃO";
                    }
                    break;
                case (byte)RequisicaoDTO.StatusRequisicao.CANCELADA:
                    retorno = "CANCELADO";
                    break;
                case (byte)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX:
                    retorno = "DISPENSADO DO ALMOXARIFADO";
                    break;
                case (byte)RequisicaoDTO.StatusRequisicao.FECHADA:
                    if (dtoRequisicao.FlPendente.Value == (byte)RequisicaoDTO.Pendente.SIM)
                    {
                        retorno += "PENDENTE NA FILA DE IMPRESSÃO";
                    }
                    else
                    {
                        retorno += "ENVIADO AO ALMOXARIFADO";
                    }
                    break;
                case (byte)RequisicaoDTO.StatusRequisicao.IMPRESSO:
                    if (dtoRequisicao.FlPendente.Value == (byte)RequisicaoDTO.Pendente.SIM)
                    {
                        retorno = "IMPRESSO / PENDENTE NA DISPENSAÇÃO";
                    }
                    else
                    {
                        //retorno = "LIBERADO PARA A DISPENSAÇÃO";
                        //retorno = "RECEBIDO PELO ALMOXARIFADO";
                        retorno = "IMPRESSO / NA DISPENSAÇÃO";
                    }
                    break;
                case (byte)RequisicaoDTO.StatusRequisicao.RECEBIDA_UNIDADE:
                    retorno = "DISPENSADO ALMOX. / RECEBIDO PELO SETOR";
                    //retorno = "DISPENSADO DO ALMOXARIFADO";
                    break;
                case (byte)RequisicaoDTO.StatusRequisicao.DEVOLVIDO_ENFERMAGEM:
                    retorno = "DEVOLVIDO PARA REENVIO / NA DISPENSAÇÃO";
                    break;
                case (byte)RequisicaoDTO.StatusRequisicao.TRANSFERIDO_PACIENTE:
                    retorno = "TRANSFERIDO PACIENTE SETOR";
                    break;
            }
            return retorno;
        }

        public void InsParamPedidoAuto(RequisicaoDTO dto)
        {
            entity.InsParamPedidoAuto(dto);
        }

        public void UpdParamPedidoAuto(RequisicaoDTO dto)
        {
            entity.UpdParamPedidoAuto(dto);
        }

        public void DelParamPedidoAuto(RequisicaoDTO dto)
        {
            entity.DelParamPedidoAuto(dto);
        }

        public RequisicaoDataTable ListarParamPedidoAuto(RequisicaoDTO dto)
        {
            return entity.ListarParamPedidoAuto(dto);
        }

        private void GerarPedidoAutomatico(RequisicaoItensDataTable dtbReqItem)
        {
            RequisicaoItens reqItem = new RequisicaoItens();
            RequisicaoDTO dtoReq = new RequisicaoDTO();
            RequisicaoItensDTO dtoReqItem = new RequisicaoItensDTO();
            RequisicaoItensDataTable dtbReqItemAux; RequisicaoItensDTO dtoReqItemAux;
            int idPedidoAnterior = 0; int idPedido = 0;

            foreach (DataRow rowReqItem in dtbReqItem.Rows)
            {
                idPedido = int.Parse(rowReqItem[RequisicaoItensDTO.FieldNames.Idt].ToString());
                dtoReq.IdtAtendimento.Value = rowReqItem[RequisicaoDTO.FieldNames.IdtAtendimento].ToString();

                if (idPedido != idPedidoAnterior)
                {
                    dtoReqItemAux = new RequisicaoItensDTO();
                    dtoReqItemAux.Idt.Value = idPedido;
                    dtoReqItemAux.DataHoraGerar.Value = rowReqItem[RequisicaoItensDTO.FieldNames.DataHoraGerar].ToString();
                    //dtoReqItemAux.DataHoraAdmPaciente.Value = rowReqItem[RequisicaoItensDTO.FieldNames.DataHoraAdmPaciente].ToString();
                    dtoReqItemAux.IdUsuarioPedidoAutoCancelado.Value = 1; //Passa o usuário para não trazer cancelados
                    dtbReqItemAux = reqItem.ListarPedidoAutoControle(dtoReqItemAux, new RequisicaoDTO(), 3);
                    //Confirma se não foi gerado por outro processo
                    if (dtbReqItemAux.Rows.Count > 0)
                    {
                        //idPedidoAnterior = int.Parse(rowReqItem[RequisicaoItensDTO.FieldNames.Idt].ToString());
                        continue;
                    }

                    dtoReq.Idt.Value = new Framework.DTO.TypeDecimal();
                    dtoReq.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.FECHADA;
                    dtoReq.FlPendente.Value = 0;
                    dtoReq.Urgencia.Value = 0;
                    dtoReq.IdtTipoRequisicao.Value = rowReqItem[RequisicaoDTO.FieldNames.IdtTipoRequisicao].ToString();
                    dtoReq.TpAtendimento.Value = rowReqItem[RequisicaoDTO.FieldNames.TpAtendimento].ToString();
                    dtoReq.IdtFilial.Value = rowReqItem[RequisicaoDTO.FieldNames.IdtFilial].ToString();
                    dtoReq.SetorFarmacia.Value = rowReqItem[RequisicaoDTO.FieldNames.SetorFarmacia].ToString();
                    dtoReq.IdtUsuario.Value = rowReqItem[RequisicaoDTO.FieldNames.IdtUsuarioRequisicao].ToString();                    

                    dtoReq.IdtUnidade.Value = rowReqItem[RequisicaoDTO.FieldNames.IdtUnidade].ToString();
                    dtoReq.IdtLocal.Value = rowReqItem[RequisicaoDTO.FieldNames.IdtLocal].ToString();
                    dtoReq.IdtSetor.Value = rowReqItem[RequisicaoDTO.FieldNames.IdtSetor].ToString();

                    if (!string.IsNullOrEmpty(rowReqItem[RequisicaoItensDTO.FieldNames.IdPrescricaoInternacao].ToString()))
                    {
                        RequisicaoDTO dtoReqPesquisa = new RequisicaoDTO();
                        dtoReqPesquisa.IdtAtendimento.Value = dtoReq.IdtAtendimento.Value;
                        DataTable dtbPresc = this.ListarPrescricaoInt(dtoReqPesquisa, int.Parse(rowReqItem[RequisicaoItensDTO.FieldNames.IdPrescricaoInternacao].ToString()), null, false);
                        if (dtbPresc.Rows.Count > 0) //Verificar se paciente não foi transferido de setor e alterar setor do Pedido se for o caso
                        {
                            int idSetorAtual = int.Parse(dtbPresc.Rows[0][RequisicaoDTO.FieldNames.IdtSetor].ToString());
                            if (idSetorAtual != (decimal)dtoReq.IdtSetor.Value)
                            {
                                dtoReq.IdtUnidade.Value = int.Parse(dtbPresc.Rows[0][RequisicaoDTO.FieldNames.IdtUnidade].ToString());
                                dtoReq.IdtLocal.Value = int.Parse(dtbPresc.Rows[0][RequisicaoDTO.FieldNames.IdtLocal].ToString());
                                dtoReq.IdtSetor.Value = idSetorAtual;
                            }
                        }
                    }

                    dtoReq = this.Ins(dtoReq);

                    //Marcar já todo o pedido evitando duplicação ao rodar simultaneamente de outra máquina
                    RequisicaoItensDTO dtoReqItemAtualizar = new RequisicaoItensDTO();
                    dtoReqItemAtualizar.Idt.Value = rowReqItem[RequisicaoItensDTO.FieldNames.Idt].ToString();
                    dtoReqItemAtualizar.DataHoraGerar.Value = rowReqItem[RequisicaoItensDTO.FieldNames.DataHoraGerar].ToString();
                    dtoReqItemAtualizar.IdtNovo.Value = dtoReq.Idt.Value;
                    new Model.RequisicaoItens().MarcarGeracaoPedidoAutomatico(dtoReqItemAtualizar);
                }
                idPedidoAnterior = int.Parse(rowReqItem[RequisicaoItensDTO.FieldNames.Idt].ToString());

                dtoReqItem.Idt.Value = dtoReq.Idt.Value;
                dtoReqItem.IdtProduto.Value = rowReqItem[RequisicaoItensDTO.FieldNames.IdtProduto].ToString();
                dtoReqItem.IdKitItem.Value = rowReqItem[RequisicaoItensDTO.FieldNames.IdKitItem].ToString();
                dtoReqItem.QtdKitItemMultiplica.Value = rowReqItem[RequisicaoItensDTO.FieldNames.QtdKitItemMultiplica].ToString();
                dtoReqItem.QtdSolicitada.Value = rowReqItem[RequisicaoItensDTO.FieldNames.QtdPedidoGerar].ToString();
                dtoReqItem.QtdFornecida.Value = 0;
                dtoReqItem.IdPrescricaoInternacao.Value = rowReqItem[RequisicaoItensDTO.FieldNames.IdPrescricaoInternacao].ToString();
                dtoReqItem.IdPrescricaoItemInternacao.Value = rowReqItem[RequisicaoItensDTO.FieldNames.IdPrescricaoItemInternacao].ToString();
                dtoReqItem.FlItemGeladeira.Value = new Framework.DTO.TypeDecimal();
                if (!string.IsNullOrEmpty(rowReqItem[RequisicaoItensDTO.FieldNames.FlItemGeladeira].ToString()))
                    dtoReqItem.FlItemGeladeira.Value = rowReqItem[RequisicaoItensDTO.FieldNames.FlItemGeladeira].ToString();

                RequisicaoItensDTO dtoReqItemVerifica = new RequisicaoItensDTO();
                dtoReqItemVerifica.Idt.Value = dtoReqItem.Idt.Value;
                dtoReqItemVerifica.IdtProduto.Value = dtoReqItem.IdtProduto.Value;
                RequisicaoItensDataTable dtbReqItemVerifica = reqItem.Sel(dtoReqItemVerifica);
                
                bool cancelarItemSCIH = false;
                dtoReqItem.IdPrescricao.Value = new Framework.DTO.TypeDecimal();
                if (int.Parse(rowReqItem[MaterialMedicamentoDTO.FieldNames.IdtSubGrupo].ToString()) == 981) //Para ANTIMICROBIANOS_RESTRITOS, buscar ID da Prescrição do Gestão e verificar se item ainda está ativo
                {
                    PrescricaoDTO dtoPrescGestao = new PrescricaoDTO();
                    dtoPrescGestao.IdMedicamentoPrescricaoMedica.Value = dtoReqItem.IdPrescricaoItemInternacao.Value;
                    PrescricaoDataTable dtbPrescGestao = new Prescricao().ListarItem(dtoPrescGestao, false);
                    if (dtbPrescGestao.Rows.Count > 0)
                    {
                        dtoPrescGestao = dtbPrescGestao.TypedRow(dtbPrescGestao.Rows.Count - 1);
                        dtoReqItem.IdPrescricao.Value = dtoPrescGestao.IdPrescricao.Value;
                    }
                    else
                    {   //Verificar se última prescrição do paciente não teve o mesmo item ou similar desautorizado pelo SCIH mesmo com outro ID de Prescrição do Gestão
                        dtoPrescGestao = new PrescricaoDTO();
                        dtoPrescGestao.IdAtendimento.Value = dtoReq.IdtAtendimento.Value;
                        dtoPrescGestao.IdProduto.Value = dtoReqItem.IdtProduto.Value;
                        dtbPrescGestao = new Prescricao().ListarItem(dtoPrescGestao, false);
                        if (dtbPrescGestao.Rows.Count > 0)
                        {
                            dtoPrescGestao = dtbPrescGestao.TypedRow(dtbPrescGestao.Rows.Count - 1);
                        }
                        else
                        {
                            MaterialMedicamentoDTO dtoMed = new MaterialMedicamentoDTO();
                            dtoMed.Idt.Value = dtoPrescGestao.IdProduto.Value;
                            dtoMed = new MaterialMedicamento().SelChave(dtoMed);
                            if (!dtoMed.IdtPrincipioAtivo.Value.IsNull && dtoMed.IdtPrincipioAtivo.Value != 0)
                            {
                                dtoPrescGestao = new PrescricaoDTO();
                                dtoPrescGestao.IdAtendimento.Value = dtoReq.IdtAtendimento.Value;
                                dtbPrescGestao = new Model.Prescricao().ListarItem(dtoPrescGestao, false, false, null, (int)dtoMed.IdtPrincipioAtivo.Value);
                                if (dtbPrescGestao.Rows.Count > 0)
                                    dtoPrescGestao = dtbPrescGestao.TypedRow(dtbPrescGestao.Rows.Count - 1);
                                else
                                    dtoPrescGestao = null;
                            }
                            else
                                dtoPrescGestao = null;
                        }
                    }
                    if (dtoPrescGestao != null)
                    {
                        //Verificar se item não foi desautorizado ou se passou da Data Limite                        
                        if (dtoPrescGestao.FlAutorizado.Value.IsNull) dtoPrescGestao.FlAutorizado.Value = 1;
                        if (dtoPrescGestao.FlAutorizado.Value == 0)
                            cancelarItemSCIH = true;
                        else if (!dtoPrescGestao.DataLimiteConsumo.Value.IsNull)
                        {
                            if (DateTime.Now.Date > (DateTime)dtoPrescGestao.DataLimiteConsumo.Value)
                                cancelarItemSCIH = true;
                        }

                        if (cancelarItemSCIH)
                        {
                            if (dtoPrescGestao.FlAutorizado.Value == 0) 
                                dtoReqItem.JustificativaCancelamento.Value = "Medicamento não autorizado pelo SCIH.";
                            else
                                dtoReqItem.JustificativaCancelamento.Value = "Medicamento ultrapassou Data Limite autorizada pelo SCIH.";

                            dtoReqItem.QtdSolicitada.Value = 0;
                            dtoReqItem.DoseAdministrar.Value = new Framework.DTO.TypeString();
                            dtoReqItem.DataHoraAdmPaciente.Value = new Framework.DTO.TypeDateTime();
                        }
                    }
                }

                if (dtbReqItemVerifica.Rows.Count == 0)
                    reqItem.Ins(dtoReqItem);
                else
                {
                    if (!cancelarItemSCIH) dtoReqItem.QtdSolicitada.Value = (int)dtbReqItemVerifica.TypedRow(0).QtdSolicitada.Value + (int)dtoReqItem.QtdSolicitada.Value;
                    reqItem.Upd(dtoReqItem);
                    reqItem.AtualizarItemKit((int)dtoReqItem.Idt.Value,
                                             (int)dtoReqItem.IdtProduto.Value,
                                             null,
                                             null,
                                             (int)dtoReqItem.QtdSolicitada.Value);
                }

                reqItem.InserirItensKitPedido(dtoReqItem);

                rowReqItem[RequisicaoItensDTO.FieldNames.IdtNovo] = dtoReq.Idt.Value;
                new Model.RequisicaoItens().MarcarGeracaoPedidoAutomatico((RequisicaoItensDTO)rowReqItem);

                RequisicaoDTO dtoReqPend = new RequisicaoDTO();
                RequisicaoItensDTO dtoReqItemPend = new RequisicaoItensDTO();
                dtoReqItemPend.IdUsuarioPedidoAutoCancelado.Value = 1; //Passa o usuário para não trazer cancelados
                dtoReqItemPend.IdPrescricaoInternacao.Value = rowReqItem[RequisicaoItensDTO.FieldNames.IdPrescricaoInternacao].ToString();
                RequisicaoItensDataTable dtbReqItemPendentesPrescricao = reqItem.ListarPedidoAutoControle(dtoReqItemPend, dtoReqPend, 2);
                //Se não tiver mais nada pendente de geração para a prescrição, alterar o status dela na internação para Dispensada
                if (dtbReqItemPendentesPrescricao.Rows.Count == 0)
                    reqItem.UpdStatusPrescricaoInt((int)dtoReqItemPend.IdPrescricaoInternacao.Value, "D");
            }
        }

        private int? ObterFarmaciaSetor(int idSetorAbastecido)
        {
            SetorDTO dtoSet = new SetorDTO();
            dtoSet.Idt.Value = idSetorAbastecido;
            dtoSet = new Setor().SelChave(dtoSet);
            if (!dtoSet.SetorFarmacia.Value.IsNull)
                return (int)dtoSet.SetorFarmacia.Value;

            return null;
        }

        /// <summary>
        /// Gera os Pedidos Programados até o horário atual
        /// </summary>
        public void GerarPedidoAutomaticos()
        {
            Model.MatMedSetorConfig matMedSetorConfig = new Model.MatMedSetorConfig();
            if (matMedSetorConfig.GerandoPedidosAutomaticosFarmacia()) return;

            try
            {
                //Flaga para evitar duplicação de processamento
                matMedSetorConfig.GerarPedidosAutomaticosFarmacia(true, false);

                Paciente Pac = new Paciente();
                RequisicaoItens reqItem = new RequisicaoItens();
                RequisicaoDTO dtoReq; RequisicaoItensDTO dtoReqItem;;
                DataTable dtbReq;
                RequisicaoItensDataTable dtbReqItem;
                DataTable dtPaciente;

                #region Buscar prescrições pendentes para gerar itens imediatos caso setor esteja parametrizado para que eles saiam automaticamente
                
                EstoqueLocal Estoque = new EstoqueLocal();                
                bool pacAlta = false;                
                dtoReq = new RequisicaoDTO();                
                dtoReq.DataRequisicao.Value = DateTime.Now.AddDays(-1); //trazer só até 1 dia atrás nas Pendências (eliminando casos de troca de setor)
                dtoReq.DataRequisicao2.Value = DateTime.Now;

                dtbReq = this.ListarPrescricaoInt(dtoReq, null, "PE", false);

                foreach (DataRow rowPrescricao in dtbReq.Rows)
                {
                    pacAlta = false;
                    dtPaciente = Pac.ObterPaciente(int.Parse(rowPrescricao[RequisicaoDTO.FieldNames.IdtAtendimento].ToString()));
                    if (dtPaciente.Rows.Count == 0 || !string.IsNullOrEmpty(dtPaciente.Rows[0]["DT_ALTA"].ToString()))
                        pacAlta = true;

                    if (!pacAlta)
                    {
                        RequisicaoDTO dtoPedidoSetorImediato = new RequisicaoDTO();
                        dtoPedidoSetorImediato.IdtSetor.Value = int.Parse(rowPrescricao[RequisicaoDTO.FieldNames.IdtSetor].ToString());
                        dtoPedidoSetorImediato.SetorPedidoAutoFlItensImediatos.Value = 1;
                        RequisicaoDataTable dtbSetoresGerarImediatos = this.ListarParamPedidoAuto(dtoPedidoSetorImediato);
                        dtbSetoresGerarImediatos = (RequisicaoDataTable)new Utilitario().ValidarVigencia(DateTime.Now,
                                                                                                         RequisicaoDTO.FieldNames.SetorPedidoAutoDtHoraIniVigencia,
                                                                                                         RequisicaoDTO.FieldNames.SetorPedidoAutoDtHoraFimVigencia,
                                                                                                         dtbSetoresGerarImediatos);
                        if (dtbSetoresGerarImediatos.Rows.Count > 0) //Verifica se setor tem parametrização de gerar imediato automaticamente
                        {
                            dtbReqItem = reqItem.ListarItensPrescricaoInt(new RequisicaoDTO(), int.Parse(rowPrescricao[RequisicaoItensDTO.FieldNames.IdPrescricaoInternacao].ToString()), "PE");

                            RequisicaoDTO dtoPedidoUrgente = null;
                            RequisicaoItensDTO dtoItemUrgente = null;
                            RequisicaoItensDataTable dtbItensUrgentes = null;

                            foreach (DataRow rowItem in dtbReqItem.Rows)
                            {
                                if (rowItem["FL_IMEDIATO"].ToString() == "S") //Se for item imediato e setor gerar esse pedido automaticamente, gerar o respectivo pedido
                                {
                                    MaterialMedicamentoDTO dtoMatMed = new MaterialMedicamentoDTO();
                                    dtoMatMed.Idt.Value = rowItem[MaterialMedicamentoDTO.FieldNames.Idt].ToString();
                                    dtoMatMed.IdtPrincipioAtivo.Value = rowItem[MaterialMedicamentoDTO.FieldNames.IdtPrincipioAtivo].ToString();
                                    dtoMatMed = Estoque.ObterSimilarProximoVencimento(dtoMatMed);

                                    //if ((int)dtoMatMed.IdtSubGrupo.Value != 981) //Não gerar para ANTIMICROBIANOS_RESTRITOS
                                    //{
                                    if (dtoPedidoUrgente == null)
                                    {
                                        dtoPedidoUrgente = new RequisicaoDTO(); dtbItensUrgentes = new RequisicaoItensDataTable();
                                        dtoPedidoUrgente.IdtAtendimento.Value = int.Parse(rowItem[RequisicaoDTO.FieldNames.IdtAtendimento].ToString());
                                        dtoPedidoUrgente.TpAtendimento.Value = "I";
                                        dtoPedidoUrgente.IdtUnidade.Value = int.Parse(rowItem[RequisicaoDTO.FieldNames.IdtUnidade].ToString());
                                        dtoPedidoUrgente.IdtLocal.Value = int.Parse(rowItem[RequisicaoDTO.FieldNames.IdtLocal].ToString());
                                        dtoPedidoUrgente.IdtSetor.Value = int.Parse(rowItem[RequisicaoDTO.FieldNames.IdtSetor].ToString());
                                        dtoPedidoUrgente.Urgencia.Value = 1;
                                        dtoPedidoUrgente.Status.Value = (int)RequisicaoDTO.StatusRequisicao.FECHADA;
                                        dtoPedidoUrgente.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
                                        dtoPedidoUrgente.IdtTipoRequisicao.Value = (byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO;
                                        int? idSetorFarmacia = this.ObterFarmaciaSetor((int)dtoPedidoUrgente.IdtSetor.Value);
                                        if (idSetorFarmacia != null) dtoPedidoUrgente.SetorFarmacia.Value = idSetorFarmacia;
                                        dtoPedidoUrgente.IdtUsuario.Value = 1;
                                    }
                                    dtoItemUrgente = (RequisicaoItensDTO)rowItem;
                                    dtoItemUrgente.IdtProduto.Value = dtoMatMed.Idt.Value;
                                    dtbItensUrgentes.Add(dtoItemUrgente);
                                    //}
                                }
                            }
                            if (dtoPedidoUrgente != null && dtbItensUrgentes != null && dtbItensUrgentes.Rows.Count > 0)
                                dtoPedidoUrgente = this.Gravar(dtoPedidoUrgente, dtbItensUrgentes);
                        }
                    }
                }

                #endregion

                dtoReq = new RequisicaoDTO();
                dtoReqItem = new RequisicaoItensDTO();

                dtoReqItem.IdUsuarioPedidoAutoCancelado.Value = 1; //Passa o usuário para não trazer cancelados

                dtoReq.DataRequisicao.Value = DateTime.Now.AddHours(-24);
                dtoReq.DataRequisicao2.Value = DateTime.Now.AddHours(36);

                //Cancelar programação de itens suspensos (caso não tenha gerado pedido ainda)
                RequisicaoItensDataTable dtbReqItemSuspensos = reqItem.ListarPedidoAutoControle(dtoReqItem, dtoReq, 5);
                reqItem.CancelarProgramacaoItensPrescricao(dtbReqItemSuspensos);

                dtbReqItem = reqItem.ListarPedidoAutoControle(dtoReqItem, dtoReq, 2);

                //Cancelar programação de pedidos de pacientes com alta (caso não tenha gerado pedido ainda)
                foreach (DataRow rowReqItem in dtbReqItem.Rows)
                {
                    dtPaciente = Pac.ObterPaciente(int.Parse(rowReqItem[RequisicaoDTO.FieldNames.IdtAtendimento].ToString()));
                    if (dtPaciente.Rows.Count == 0 || !string.IsNullOrEmpty(dtPaciente.Rows[0]["DT_ALTA"].ToString()))
                    {
                        RequisicaoItensDTO dtoReqItemCancela = new RequisicaoItensDTO();

                        dtoReqItemCancela.Idt.Value = rowReqItem[RequisicaoItensDTO.FieldNames.Idt].ToString();
                        dtoReqItemCancela.IdtProduto.Value = rowReqItem[RequisicaoItensDTO.FieldNames.IdtProduto].ToString();
                        dtoReqItemCancela.DataHoraGerar.Value = rowReqItem[RequisicaoItensDTO.FieldNames.DataHoraGerar].ToString();
                        dtoReqItemCancela.DataHoraAdmPaciente.Value = rowReqItem[RequisicaoItensDTO.FieldNames.DataHoraAdmPaciente].ToString();
                        dtoReqItemCancela.IdUsuarioPedidoAutoCancelado.Value = 1;

                        reqItem.CancelarPedidoAutoControle(dtoReqItemCancela);
                    }
                }

                dtoReq.DataRequisicao2.Value = DateTime.Now; //Buscar o que está pendente até a hora atual para gerar os pedidos
                dtbReqItem = reqItem.ListarPedidoAutoControle(dtoReqItem, dtoReq, 2);

                this.GerarPedidoAutomatico(dtbReqItem);

                matMedSetorConfig.GerarPedidosAutomaticosFarmacia(false, true);
            }
            catch (Exception ex)
            {
                matMedSetorConfig.GerarPedidosAutomaticosFarmacia(false, false);
            }
        }

        public DataTable ListarPrescricaoInt(RequisicaoDTO dto, int? idPrescInt, string statusItens, bool suspensas)
        {
            return entity.ListarPrescricaoInt(dto, idPrescInt, statusItens, suspensas);
        }

        public DataTable ListarPrescricaoIntHistorico(RequisicaoDTO dto, int? idPrescInt, bool suspensas)
        {
            return entity.ListarPrescricaoIntHistorico(dto, idPrescInt, suspensas);
        }

        public void UpdOBSPrescricaoInt(int idPrescInternacao, string observacao, int idUsuario, string categoria)
        {
            entity.UpdOBSPrescricaoInt(idPrescInternacao, observacao, idUsuario, categoria);
        }

        public void ReplicarPedidos(int idTpReq, int idSetor, DateTime dtInicio, DateTime dtFim, bool apenasFornecidos, bool farmacia, int idUsuario)
        {
            entity.ReplicarPedidos(idTpReq, idSetor, dtInicio, dtFim, apenasFornecidos, farmacia, idUsuario);
        }

        public void AtualizarPedidosPacientesTransferidosUTI()
        {
            Model.MatMedSetorConfig matMedSetorConfig = new Model.MatMedSetorConfig();
            DateTime? dtUltimoProcesso = matMedSetorConfig.DataUltimaGeracaoPedidosAutomaticosImediatoTransfPac();
            if (dtUltimoProcesso != null)
            {
                DateTime dtProximoProcessoLiberada = dtUltimoProcesso.Value.AddMinutes(5);
                if (DateTime.Now < dtProximoProcessoLiberada)
                    return;
            }
            
            if (matMedSetorConfig.GerandoPedidosAutomaticosImediatoTransfPac()) return;            

            try
            {
                //Flaga para evitar duplicação de processamento
                matMedSetorConfig.GerarPedidosAutomaticosImediatoTransfPac(true);

                Model.Paciente entPac = new Model.Paciente();
                DataTable dtbTransferenciasRecentesUTI = entPac.ListarTransferenciasRecentesUTI();

                if (dtbTransferenciasRecentesUTI.Rows.Count > 0)
                {
                    Model.RequisicaoItens reqItem = new Model.RequisicaoItens();

                    foreach (DataRow rowPacTransferido in dtbTransferenciasRecentesUTI.Rows)
                    {
                        RequisicaoItensDataTable dtbPedidoPendentePaciente = reqItem.ListarPedidoAutoPendenciasAgrupadas(decimal.Parse(rowPacTransferido[RequisicaoDTO.FieldNames.IdtAtendimento].ToString()),
                                                                                                                         decimal.Parse(rowPacTransferido["CAD_SET_ID_ATUAL"].ToString()));
                        //GERAR IMEDIATO COM TOTAIS DOS ITENS DO PACIENTE
                        if (dtbPedidoPendentePaciente.Rows.Count > 0)
                        {
                            RequisicaoDTO dtoReq = new RequisicaoDTO();

                            dtoReq.IdtAtendimento.Value = decimal.Parse(rowPacTransferido[RequisicaoDTO.FieldNames.IdtAtendimento].ToString());
                            dtoReq.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.FECHADA;
                            dtoReq.FlPendente.Value = 0;
                            dtoReq.Urgencia.Value = 1;
                            dtoReq.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
                            dtoReq.IdtTipoRequisicao.Value = (byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO;
                            dtoReq.TpAtendimento.Value = "I";
                            dtoReq.SetorFarmacia.Value = dtbPedidoPendentePaciente.Rows[0][RequisicaoDTO.FieldNames.SetorFarmacia].ToString();
                            dtoReq.IdtUsuario.Value = dtbPedidoPendentePaciente.Rows[0][RequisicaoDTO.FieldNames.IdtUsuarioRequisicao].ToString();

                            SetorDTO dtoSetor = new SetorDTO();
                            dtoSetor.Idt.Value = decimal.Parse(rowPacTransferido["CAD_SET_ID_ATUAL"].ToString());
                            dtoSetor = new Model.Setor().SelChave(dtoSetor);

                            dtoReq.IdtUnidade.Value = dtoSetor.IdtUnidade.Value;
                            dtoReq.IdtLocal.Value = dtoSetor.IdtLocalAtendimento.Value;
                            dtoReq.IdtSetor.Value = dtoSetor.Idt.Value;

                            dtoReq = this.Ins(dtoReq);

                            foreach (DataRow rowReqItem in dtbPedidoPendentePaciente.Rows)
                            {
                                RequisicaoItensDTO dtoReqItemVerifica = new RequisicaoItensDTO();
                                dtoReqItemVerifica.Idt.Value = dtoReq.Idt.Value;
                                dtoReqItemVerifica.IdtProduto.Value = rowReqItem[RequisicaoItensDTO.FieldNames.IdtProduto].ToString();
                                RequisicaoItensDataTable dtbReqItemVerifica = reqItem.Sel(dtoReqItemVerifica);

                                if (dtbReqItemVerifica.Rows.Count == 0)
                                {
                                    RequisicaoItensDTO dtoReqItem = new RequisicaoItensDTO();                                

                                    dtoReqItem.Idt.Value = dtoReq.Idt.Value;
                                    dtoReqItem.IdtProduto.Value = rowReqItem[RequisicaoItensDTO.FieldNames.IdtProduto].ToString();
                                    dtoReqItem.IdKitItem.Value = rowReqItem[RequisicaoItensDTO.FieldNames.IdKitItem].ToString();
                                    dtoReqItem.QtdKitItemMultiplica.Value = rowReqItem[RequisicaoItensDTO.FieldNames.QtdKitItemMultiplica].ToString();
                                    dtoReqItem.QtdSolicitada.Value = rowReqItem[RequisicaoItensDTO.FieldNames.QtdPedidoGerar].ToString();
                                    dtoReqItem.QtdFornecida.Value = 0;
                                    dtoReqItem.IdPrescricaoInternacao.Value = rowReqItem[RequisicaoItensDTO.FieldNames.IdPrescricaoInternacao].ToString();

                                    #region Verificar Prescrição do Gestão

                                    PrescricaoDTO dtoPrescGestao = new PrescricaoDTO();

                                    if (!dtoReqItem.IdPrescricaoInternacao.Value.IsNull)
                                    {
                                        dtoPrescGestao.IdPrescricaoMedica.Value = dtoReqItem.IdPrescricaoInternacao.Value;

                                        reqItem.UpdStatusItemPrescricaoInt((int)dtoReqItem.IdPrescricaoInternacao.Value,
                                                                            null,
                                                                            (int)dtoReq.IdtUsuario.Value,
                                                                            "GE");
                                    }
                                    else
                                        dtoPrescGestao.IdAtendimento.Value = dtoReq.IdtAtendimento.Value;

                                    dtoPrescGestao.IdProduto.Value = dtoReqItem.IdtProduto.Value;
                                    PrescricaoDataTable dtbPrescGestao = new Prescricao().ListarItem(dtoPrescGestao, true);

                                    if (dtbPrescGestao.Rows.Count > 0)
                                    {
                                        dtoPrescGestao = dtbPrescGestao.TypedRow(dtbPrescGestao.Rows.Count - 1);
                                        dtoReqItem.IdPrescricao.Value = dtoPrescGestao.IdPrescricao.Value;
                                    }
                                    #endregion

                                    reqItem.Ins(dtoReqItem);

                                    new RequisicaoItens().InserirItensKitPedido(dtoReqItem);
                                }                            
                            }                        

                            RequisicaoDTO dtoReqPedidoAutoControle = new RequisicaoDTO();
                            RequisicaoItensDTO dtoReqItemPedidoAutoControle = new RequisicaoItensDTO();
                            dtoReqPedidoAutoControle.IdtAtendimento.Value = dtoReq.IdtAtendimento.Value;
                            dtoReqItemPedidoAutoControle.IdUsuarioPedidoAutoCancelado.Value = 1; //Passa o usuário para não trazer cancelados
                            RequisicaoItensDataTable dtbPendenciasPac = reqItem.ListarPedidoAutoControle(dtoReqItemPedidoAutoControle, dtoReqPedidoAutoControle, 2);                        
                            //Cancelar programação de pedidos do paciente
                            foreach (DataRow rowReqItem in dtbPendenciasPac.Rows)
                            {
                                if (string.IsNullOrEmpty(rowReqItem[RequisicaoItensDTO.FieldNames.IdtNovo].ToString()))
                                {
                                    RequisicaoItensDTO dtoReqItemCancela = new RequisicaoItensDTO();

                                    dtoReqItemCancela.Idt.Value = rowReqItem[RequisicaoItensDTO.FieldNames.Idt].ToString();
                                    dtoReqItemCancela.IdtProduto.Value = rowReqItem[RequisicaoItensDTO.FieldNames.IdtProduto].ToString();
                                    dtoReqItemCancela.DataHoraGerar.Value = rowReqItem[RequisicaoItensDTO.FieldNames.DataHoraGerar].ToString();
                                    dtoReqItemCancela.DataHoraAdmPaciente.Value = rowReqItem[RequisicaoItensDTO.FieldNames.DataHoraAdmPaciente].ToString();
                                    dtoReqItemCancela.IdUsuarioPedidoAutoCancelado.Value = 1;

                                    reqItem.CancelarPedidoAutoControle(dtoReqItemCancela);
                                }
                            }
                        }
                    }
                }
                matMedSetorConfig.GerarPedidosAutomaticosImediatoTransfPac(false);
            }
            catch (Exception ex)
            {
                matMedSetorConfig.GerarPedidosAutomaticosImediatoTransfPac(false);
            }
        }
    }
}