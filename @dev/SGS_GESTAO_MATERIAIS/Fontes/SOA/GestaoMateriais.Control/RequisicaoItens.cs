using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using System.Data;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
	public class RequisicaoItens : Control, IRequisicaoItens
	{
		private Model.RequisicaoItens entity = new Model.RequisicaoItens() ;

        /// <summary>
        /// Listar todos os registros
        /// </summary>
		public RequisicaoItensDataTable Sel(RequisicaoItensDTO dto)
		{	
			return entity.Sel(dto);
		}

        public RequisicaoItensDataTable Sel(RequisicaoItensDTO dto, bool ordenarEndereco, bool ordenarEndereco2)
        {
            return entity.Sel(dto, ordenarEndereco, ordenarEndereco2);
        }

        public RequisicaoItensDataTable SelOrdenadoKit(RequisicaoItensDTO dto)
        {
            return entity.SelOrdenadoKit(dto);
        }

        /// <summary>
        /// Retorna Lista de itens pendentes
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public RequisicaoItensDataTable SelReqItensPendentes(RequisicaoDTO dto)
        {
            return entity.SelReqItensPendentes(dto);
        }

        public RequisicaoItensDataTable SelReqItensPendentes(int idSetor)
        {
            return entity.SelReqItensPendentes(idSetor);
        }

        /// <summary>
        /// Retorna Qtde solicitada do produto Original da requisição ou do similar
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public RequisicaoItensDTO SelQtdeSolicitada(RequisicaoItensDTO dto)
        {
            return entity.SelQtdeSolicitada(dto);
        }

        /// <summary>
        /// Carrega itens para tela de dispensação que já tenha qtd fornecida
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public RequisicaoItensDataTable SelReqItensDispensacao(RequisicaoDTO dto)
        {
            return entity.SelReqItensDispensacao(dto);
        }

        public void InsReqItemDispensacao(RequisicaoItensDTO dto)
        {
            entity.InsReqItemDispensacao(dto);
        }

        public void DelReqItemDispensacao(RequisicaoItensDTO dto)
        {
            entity.DelReqItemDispensacao(dto);
        }

        /// <summary>
        /// Neste método, caso calcularQtdForn = true,
        /// o campo QtdFornecida funciona como se fosse a Qtd. a ser Fornecida, 
        /// pois ele é calculado e não é o que vem do banco.
        /// </summary>        
        public RequisicaoItensDataTable SelItensRequisicao(RequisicaoItensDTO dto, bool calcularQtdForn)
		{
            RequisicaoItensDataTable dtb = entity.SelItensRequisicao(dto);
            if (calcularQtdForn) dtb = this.CalculaQtdFornecidaAlmoxarifado(dtb);
            return dtb;
		}

        public RequisicaoItensDataTable SelSugestaoItensRequisicao(RequisicaoDTO dtoReq, MaterialMedicamentoDTO dtoMatMed)
        {
            return entity.SelSugestaoItensRequisicao(dtoReq, dtoMatMed);
        }
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public RequisicaoItensDTO Ins(RequisicaoItensDTO dto)
		{
			entity.Ins(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro, Só é Utilizada para excluir itens por linha
        /// para excluir todas as linhas usar o metodo da Requisição
		/// </summary>		
		public void Del(RequisicaoItensDTO dto)
		{
			entity.Del(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Upd(RequisicaoItensDTO dto)
		{		
			entity.Upd(dto);
		}

        /// <summary>
        /// Baseada no Estoque local, calcula qtde a ser fornecida
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public RequisicaoItensDTO CalculaQtdFornecidaAlmoxarifado(RequisicaoItensDTO dto)
        {
            dto.QtdFornecida.Value = 0;
            if (dto.EstoqueLocalQtde.Value.IsNull) dto.EstoqueLocalQtde.Value = 0;
            if (dto.QtdePadrao.Value.IsNull) dto.QtdePadrao.Value = 0;
            if (!dto.QtdSolicitada.Value.IsNull)
            {
                if (dto.QtdSolicitada.Value >= dto.EstoqueLocalQtde.Value)
                {
                    dto.QtdFornecida.Value = dto.QtdSolicitada.Value - dto.EstoqueLocalQtde.Value;
                }
                if ( dto.QtdePadrao.Value > 0 )
                {
                    if (dto.QtdFornecida.Value > dto.QtdePadrao.Value)
                    {
                        dto.QtdFornecida.Value = (dto.QtdePadrao.Value - dto.EstoqueLocalQtde.Value);
                    }
                }
            }                        
            return dto;
        }

        /// <summary>
        /// Baseada no Estoque local, calcula qtde a ser fornecida por item da requisição
        /// </summary>
        /// <param name="dtb"></param>
        /// <returns></returns>
        public RequisicaoItensDataTable CalculaQtdFornecidaAlmoxarifado(RequisicaoItensDataTable dtb)
        {
            RequisicaoItensDTO dto = null;
            foreach (DataRow row in dtb.Rows)
            {
                dto = (RequisicaoItensDTO)row;
                dto = this.CalculaQtdFornecidaAlmoxarifado(dto);
                row[RequisicaoItensDTO.FieldNames.QtdFornecida] = dto.QtdFornecida.Value;                
            }            
            return dtb;
        }

        /// <summary>
        /// Converte DTO MatMed para DTO Requisição Itens
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public RequisicaoItensDTO ConverteMatMedRequisicao(MaterialMedicamentoDTO dto)
        {
            RequisicaoItensDTO dtoRequisicaoItens = new RequisicaoItensDTO();
            if (dto != null)
            {
                // ATENÇÃO SEMPRE USAR O NOME FANTASIA PARA DAR DISPLAY
                dtoRequisicaoItens.IdtProduto.Value = dto.Idt.Value;
                dtoRequisicaoItens.DsProduto.Value = dto.NomeFantasia.Value;
                dtoRequisicaoItens.UnidadeCompra.Value = dto.UnidadeCompra.Value;
                dtoRequisicaoItens.UnidadeControle.Value = dto.UnidadeControle.Value;
                dtoRequisicaoItens.UnidadeVenda.Value = dto.UnidadeVenda.Value;
                dtoRequisicaoItens.DsUnidadeVenda.Value = dto.DsUnidadeVenda.Value;
                dtoRequisicaoItens.IdtPrincipioAtivo.Value = dto.IdtPrincipioAtivo.Value;
                if (dtoRequisicaoItens.FlItemGeladeira.Value.IsNull) dtoRequisicaoItens.FlItemGeladeira.Value = dto.FlItemGeladeira.Value;
            }
            return dtoRequisicaoItens;
        }

        public int ObterQtdSolicitadaProdutoPaciente(MovimentacaoDTO dto, int idPrincipioAtivo)
        {
            return int.Parse(entity.ObterQtdSolicitadaProdutoPaciente(dto, idPrincipioAtivo).Rows[0][0].ToString());
        }

        public bool ExistePendenciasConsumoPacienteParaAlta(int idAtendimento, bool acaoAlta)
        {
            return false;
            DataTable dtbReq = SelPendenciasConsumoPacSetores(idAtendimento);
            MatMedSetorConfigDTO dtoSetorConfig = null;
            Paciente pac = new Paciente();
            PacienteDTO dtoPac;
            foreach (DataRow row in dtbReq.Rows)
            {
                if (dtoSetorConfig == null) dtoSetorConfig = new MatMedSetorConfigDTO();
                dtoSetorConfig.IdtUnidade.Value = row[RequisicaoDTO.FieldNames.IdtUnidade].ToString();
                dtoSetorConfig.IdtLocal.Value = row[RequisicaoDTO.FieldNames.IdtLocal].ToString();
                dtoSetorConfig.Idtsetor.Value = row[RequisicaoDTO.FieldNames.IdtSetor].ToString();

                if (pac.ControlaConsumoPacienteSetor(idAtendimento, dtoSetorConfig))
                {
                    if (acaoAlta) return true;
                    //No caso de transferencia do paciente, verificar só as pendências do setor atual
                    dtoPac = new PacienteDTO();
                    dtoPac.Idt.Value = idAtendimento;
                    dtoPac.IdtUnidade.Value = decimal.Parse(row[RequisicaoDTO.FieldNames.IdtUnidade].ToString());
                    dtoPac.IdtLocalAtendimento.Value = decimal.Parse(row[RequisicaoDTO.FieldNames.IdtLocal].ToString());
                    dtoPac.IdtSetor.Value = decimal.Parse(row[RequisicaoDTO.FieldNames.IdtSetor].ToString());
                    dtoPac = pac.SelChave(dtoPac);
                    if (dtoPac != null && dtoPac.DtTransf.Value.IsNull)
                        return true;
                }
            }            
            return false;
            //return entity.SelReqItensPendentesConsumoPac(idAtendimento, null, null).Rows.Count > 0;
        }

        public DataTable SelPendenciasConsumoPacSetores(int idAtendimento)
        {
            return entity.SelPendenciasConsumoPacSetores(idAtendimento);
        }

        public RequisicaoItensDataTable SelReqItensPendentesConsumoPac(int idAtendimento, int? idProduto, int? idSetor)
        {
            return entity.SelReqItensPendentesConsumoPac(idAtendimento, idProduto, idSetor);
        }

        public RequisicaoItensDataTable SelPedidosReqItenPac(int? idAtendimento, int? idProduto, int? idPedido)
        {
            return entity.SelPedidosReqItenPac(idAtendimento, idProduto, idPedido);
        }

        public RequisicaoItensDataTable SelPedidosReqItenPac(int? idAtendimento, int? idProduto, int? idPedido, int? statusPedido)
        {
            return entity.SelPedidosReqItenPac(idAtendimento, idProduto, idPedido, statusPedido);
        }

        public RequisicaoItensDataTable ListarItensBaixa(RequisicaoItensDTO dto)
        {
            return entity.ListarItensBaixa(dto);
        }

        public decimal? ObterNumPedidoPrescricaoPaciente(MovimentacaoDTO dto, int idPrincipioAtivo)
        {
            return entity.ObterNumPedidoPrescricaoPaciente(dto, idPrincipioAtivo);
        }

        public decimal? ObterNumPedidoPendentePaciente(MovimentacaoDTO dto, int idPrincipioAtivo)
        {
            return entity.ObterNumPedidoPendentePaciente(dto, idPrincipioAtivo);
        }

        public decimal ObterQtdItemPedidaHoje(RequisicaoItensDTO dto, decimal idReqRef)
        {
            RequisicaoItensDataTable dtbReqItem = this.Sel(dto);
            int qtdPedidaHoje = 0;
            foreach (DataRow row in dtbReqItem.Rows)
            {
                if (int.Parse(row[RequisicaoItensDTO.FieldNames.Idt].ToString()) != idReqRef)
                {
                    if (!string.IsNullOrEmpty(row["MTMD_REQ_DATA"].ToString()))
                    {
                        if (DateTime.Parse(row["MTMD_REQ_DATA"].ToString()).Date == DateTime.Now.Date ||
                            (string.IsNullOrEmpty(row["MTMD_DATA_REQUISICAO"].ToString()) || DateTime.Parse(row["MTMD_DATA_REQUISICAO"].ToString()).Date == DateTime.Now.Date))
                            qtdPedidaHoje += int.Parse(row[RequisicaoItensDTO.FieldNames.QtdSolicitada].ToString());
                    }
                }
            }
            return qtdPedidaHoje;
        }

        public bool DevolverAlmoxarifado(RequisicaoDTO dtoRequisicao)
        {
            int idUsuarioMov = (int)dtoRequisicao.IdtUsuario.Value;
            RequisicaoDTO dtoReqAtualizar = new RequisicaoDTO();
            dtoReqAtualizar.Idt.Value = dtoRequisicao.Idt.Value;
            dtoReqAtualizar = new Requisicao().SelChave(dtoReqAtualizar);
            dtoRequisicao = dtoReqAtualizar;

            if (dtoRequisicao.Status.Value != (byte)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX)
                throw new HacException(" Pedido tem que estar com o Status DISPENSADO DO ALMOXARIFADO ");

            RequisicaoItensDTO dtoReqItem = new RequisicaoItensDTO();
            dtoReqItem.Idt = dtoRequisicao.Idt;
            RequisicaoItensDataTable dtbReqItem = this.Sel(dtoReqItem);

            if (dtbReqItem.Select(string.Format("{0} > 0", RequisicaoItensDTO.FieldNames.QtdFornecida)).Length > 0)
            {
                if (entity.SelPedidosReqItenPac(null, null, (int)dtoRequisicao.Idt.Value, 
                                                (int)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX).Select(string.Format("MTMD_ESTLOC_QTDE < {0}", 
                                                                                                             RequisicaoItensDTO.FieldNames.QtdFornecida)).Length > 0)
                    throw new HacException("Existem item(ns) com saldo insuficiente em estoque para devolução, favor verificar");

                #region OUTRA OPCAO ESTUDADA PARA BUSCAR CENTRO DE DISP.
                //dtoMovCentroDisp.IdtAtendimento.Value = dtoRequisicao.IdtAtendimento.Value;
                //dtoMovCentroDisp.IdtFilial.Value = dtoRequisicao.IdtFilial.Value;
                //dtoMovCentroDisp.IdtRequisicao.Value = dtoRequisicao.Idt.Value;    
                //dtoMovCentroDisp.IdtProduto.Value = dtbReqItem.Select(string.Format("{0} > 0", RequisicaoItensDTO.FieldNames.QtdFornecida))[0][RequisicaoItensDTO.FieldNames.IdtProduto].ToString();
                //dtoMovCentroDisp.IdtTipo.Value = (int)MovimentacaoDTO.TipoMovimento.SAIDA;
                //dtoMovCentroDisp.IdtSubTipo.Value = (int)MovimentacaoDTO.SubTipoMovimento.BAIXA_CENTRAL_PERSONALIZADO;
                //dtoMovCentroDisp = mov.Sel(dtoMovCentroDisp, false).TypedRow(0); //Nao utilizada por buscar apenas ultimos 30 dias e ser menos performatica
                #endregion

                Movimentacao mov = new Movimentacao();                
                MovimentacaoDTO dtoMovimento;
                MovimentacaoDTO dtoMovCentroDisp = new MovimentacaoDTO();                
                DataTable dtbMovEntradaCentroDisp;
                dtoMovCentroDisp.IdtSetor = dtoRequisicao.IdtSetor;
                SetorDTO dtoSetFarm;
                dtoMovCentroDisp = mov.CentroDispensacao(dtoMovCentroDisp, out dtoSetFarm);
                if (!dtoRequisicao.SetorFarmacia.Value.IsNull &&
                    dtoRequisicao.SetorFarmacia.Value.ToString() == dtoSetFarm.Idt.Value.ToString())
                {
                    dtoMovCentroDisp.IdtUnidadeBaixa.Value = dtoSetFarm.IdtUnidade.Value;
                    dtoMovCentroDisp.IdtLocalBaixa.Value = dtoSetFarm.IdtLocalAtendimento.Value;
                    dtoMovCentroDisp.IdtSetorBaixa.Value = dtoSetFarm.Idt.Value;
                }

                try
                {
                    foreach (DataRow row in dtbReqItem.Select(string.Format("{0} > 0", RequisicaoItensDTO.FieldNames.QtdFornecida)))
                    {
                        dtoMovimento = new MovimentacaoDTO();

                        // setor de baixa
                        dtoMovimento.IdtUnidadeBaixa.Value = dtoRequisicao.IdtUnidade.Value;
                        dtoMovimento.IdtLocalBaixa.Value = dtoRequisicao.IdtLocal.Value;
                        dtoMovimento.IdtSetorBaixa.Value = dtoRequisicao.IdtSetor.Value;

                        // setor de entrada
                        dtoMovimento.IdtUnidade.Value = dtoMovCentroDisp.IdtUnidadeBaixa.Value;
                        dtoMovimento.IdtLocal.Value = dtoMovCentroDisp.IdtLocalBaixa.Value;
                        dtoMovimento.IdtSetor.Value = dtoMovCentroDisp.IdtSetorBaixa.Value;

                        dtoMovimento.IdtFilial.Value = dtoRequisicao.IdtFilial.Value;
                        dtoMovimento.IdtRequisicao.Value = dtoRequisicao.Idt.Value;
                        dtoMovimento.IdtAtendimento.Value = dtoRequisicao.IdtAtendimento.Value;

                        dtoMovimento.IdtProduto.Value = row[RequisicaoItensDTO.FieldNames.IdtProduto].ToString();
                        //dtoMovimento.Qtde.Value = row[RequisicaoItensDTO.FieldNames.QtdFornecida].ToString();
                        dtoMovimento.IdtTipo.Value = (byte)MovimentacaoDTO.TipoMovimento.ENTRADA;
                        dtoMovimento.IdtTipoBaixa.Value = (byte)MovimentacaoDTO.TipoMovimento.SAIDA;
                        dtoMovimento.IdtSubTipo.Value = (byte)MovimentacaoDTO.SubTipoMovimento.TRANSFERENCIA_ENTRADA;
                        dtoMovimento.IdtSubTipoBaixa.Value = (byte)MovimentacaoDTO.SubTipoMovimento.TRANSFERENCIA_SAIDA;
                        dtoMovimento.IdtUsuario.Value = idUsuarioMov;

                        dtbMovEntradaCentroDisp = mov.ObterEntradasCentroDispPedido(dtoMovimento);

                        foreach (DataRow rowMov in dtbMovEntradaCentroDisp.Rows)
                        {
                            dtoMovimento.Idt.Value = new Framework.DTO.TypeDecimal();
                            dtoMovimento.IdtLote.Value = rowMov[MovimentacaoDTO.FieldNames.IdtLote].ToString();
                            int qtdDevolvida = int.Parse(rowMov["MTMD_MOV_QTDE_DEV"].ToString());              
                            dtoMovimento.Qtde.Value = int.Parse(rowMov[MovimentacaoDTO.FieldNames.Qtde].ToString()) - qtdDevolvida;

                            mov.TransfereEstoqueProduto(dtoMovimento);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new HacException(ex.Message, ex);
                }
            }
            else
                throw new HacException(" Nenhum item a ser devolvido ");

            return true;
        }

        public bool TransferirPacienteSetor(RequisicaoDTO dtoRequisicaoNova, int idSetorOrigem, out string mensagem)
        {
            mensagem = string.Empty;
            Movimentacao Movimento = new Movimentacao(); MovimentacaoDTO dtoMovimento;
            Requisicao Requisicao = new Requisicao(); RequisicaoItensDTO dtoReqItem;
            RequisicaoItensDataTable dtbReqItemTransf = this.SelReqItensLotesPendentesConsumoPac((int)dtoRequisicaoNova.IdtAtendimento.Value, idSetorOrigem);
            RequisicaoItensDataTable dtbPendenciaConsumo, dtbReqItemNova = null;
            DataTable dtbItemLoteTransf = null;
            int idLote, qtdEstoque, qtdConsumoSetorDestino, qtdPendente, qtdTransferir, qtdDevolvida, qtdForn = 0, qtdTransferidaLote = 0;

            //Varredura dos itens para validação de saldo e criação de um novo pedido referente ao setor de destino
            foreach (DataRow row in dtbReqItemTransf.Rows)
            {
                if (dtbItemLoteTransf == null)
                { 
                    dtbItemLoteTransf = new DataTable();
                    dtbItemLoteTransf.Columns.Add(RequisicaoItensDTO.FieldNames.IdtProduto);
                    dtbItemLoteTransf.Columns.Add(RequisicaoItensDTO.FieldNames.IdtLote);
                    dtbItemLoteTransf.Columns.Add(RequisicaoItensDTO.FieldNames.QtdFornecida);
                }
                dtbPendenciaConsumo = this.SelReqItensPendentesConsumoPac((int)dtoRequisicaoNova.IdtAtendimento.Value, int.Parse(row[RequisicaoItensDTO.FieldNames.IdtProduto].ToString()), null);
                qtdPendente = 0; qtdEstoque = 0;
                if (dtbPendenciaConsumo.Rows.Count > 0)
                    qtdPendente = int.Parse(dtbPendenciaConsumo.Rows[0]["QTD_PENDENTE"].ToString());

                qtdEstoque = int.Parse(row["SALDO_SETOR"].ToString());
                idLote = int.Parse(row[RequisicaoItensDTO.FieldNames.IdtLote].ToString());

                #region Atualiza Qtd. Fornecida Abatendo Qtd. Devolvida
                dtoMovimento = new MovimentacaoDTO();
                dtoMovimento.IdtFilial.Value = (decimal)FilialMatMedDTO.Filial.HAC;
                dtoMovimento.IdtRequisicao.Value = int.Parse(row[RequisicaoItensDTO.FieldNames.Idt].ToString());
                dtoMovimento.IdtProduto.Value = decimal.Parse(row[RequisicaoItensDTO.FieldNames.IdtProduto].ToString());
                DataTable dtbLoteDev = new DataView(Movimento.ObterEntradasCentroDispPedido(dtoMovimento),
                                                    idLote == 0 ? "MTMD_LOTEST_ID IS NULL OR MTMD_LOTEST_ID = 0" : string.Format("MTMD_LOTEST_ID = {0}", idLote),
                                                    string.Empty,
                                                    DataViewRowState.CurrentRows).ToTable();
                qtdDevolvida = 0;
                if (dtbLoteDev.Rows.Count > 0)
                {
                    qtdDevolvida = int.Parse(dtbLoteDev.Rows[0]["MTMD_MOV_QTDE_DEV"].ToString());
                    qtdForn = int.Parse(dtbLoteDev.Rows[0][MovimentacaoDTO.FieldNames.Qtde].ToString()) - qtdDevolvida;
                }
                #endregion

                if (qtdForn > qtdPendente)
                    qtdTransferir = qtdPendente;
                else
                    qtdTransferir = qtdForn;

                DataRow[] rowsReqItemLote = dtbItemLoteTransf.Select(string.Format("{0} = {1} AND {2} = {3}", RequisicaoItensDTO.FieldNames.IdtProduto, int.Parse(row[RequisicaoItensDTO.FieldNames.IdtProduto].ToString()),
                                                                                                              RequisicaoItensDTO.FieldNames.IdtLote, idLote));
                if (rowsReqItemLote.Length > 0)
                    qtdTransferidaLote = int.Parse(rowsReqItemLote[0][RequisicaoItensDTO.FieldNames.QtdFornecida].ToString());
                else
                    qtdTransferidaLote = 0;

                if ((qtdTransferir + qtdTransferidaLote) > qtdEstoque)
                {
                    mensagem = "Saldo insuficiente em estoque do item ID " + row[RequisicaoItensDTO.FieldNames.IdtProduto].ToString() + ", favor eliminar esta pendência unitariamente para depois usar esta funcionalidade!";
                    return false;
                }

                if (qtdTransferir > 0)
                {
                    if (dtbReqItemNova == null)
                        dtbReqItemNova = new RequisicaoItensDataTable();

                    DataRow[] rowsReqItem = dtbReqItemNova.Select(string.Format("{0} = {1}", RequisicaoItensDTO.FieldNames.IdtProduto,
                                                                                             int.Parse(row[RequisicaoItensDTO.FieldNames.IdtProduto].ToString())));                    
                    if (rowsReqItem.Length > 0)
                    {   
                        rowsReqItem[0][RequisicaoItensDTO.FieldNames.QtdSolicitada] = int.Parse(rowsReqItem[0][RequisicaoItensDTO.FieldNames.QtdSolicitada].ToString()) + qtdTransferir;
                        rowsReqItem[0][RequisicaoItensDTO.FieldNames.QtdFornecida] = rowsReqItem[0][RequisicaoItensDTO.FieldNames.QtdSolicitada];
                    }
                    else
                    {
                        qtdConsumoSetorDestino = 0;

                        #region Verificar se paciente já tinha consumo no setor de destino (caso volte ao setor) para criar nova pendência do item de acordo com o consumo
                        dtoMovimento.IdtSetor.Value = dtoRequisicaoNova.IdtSetor.Value;
                        dtoMovimento.IdtAtendimento.Value = dtoRequisicaoNova.IdtAtendimento.Value;
                        MaterialMedicamentoDTO dtoMatMed = new MaterialMedicamentoDTO();
                        dtoMatMed.Idt.Value = dtoMovimento.IdtProduto.Value;
                        DataTable dtbMov = Movimento.ObterQtdProdutoBaixaPacSetor(dtoMovimento, (int)(new MaterialMedicamento().SelChave(dtoMatMed).IdtPrincipioAtivo.Value));
                        //Pode retornar até 2 linhas, caso produto com movimento fracionado
                        if (dtbMov.Rows.Count > 0)
                        {
                            if (dtbMov.Rows[0]["MOV_TIPO"].ToString() == "I") qtdConsumoSetorDestino = int.Parse(dtbMov.Rows[0]["QTD_CONSUMO"].ToString());
                            if (dtbMov.Rows.Count > 1)
                                if (dtbMov.Rows[1]["MOV_TIPO"].ToString() == "I") qtdConsumoSetorDestino = int.Parse(dtbMov.Rows[1]["QTD_CONSUMO"].ToString());
                        }
                        #endregion  

                        dtoReqItem = new RequisicaoItensDTO();
                        dtoReqItem.IdtProduto.Value = int.Parse(row[RequisicaoItensDTO.FieldNames.IdtProduto].ToString());
                        dtoReqItem.QtdFornecida.Value = dtoReqItem.QtdSolicitada.Value = qtdConsumoSetorDestino + qtdTransferir;
                        if (!string.IsNullOrEmpty(row[RequisicaoItensDTO.FieldNames.IdPrescricao].ToString()))
                            dtoReqItem.IdPrescricao.Value = int.Parse(row[RequisicaoItensDTO.FieldNames.IdPrescricao].ToString());
                        dtbReqItemNova.Add(dtoReqItem);
                    }

                    row["QTD_TRANSFERIR"] = qtdTransferir;
                    
                    if (rowsReqItemLote.Length > 0)
                        rowsReqItemLote[0][RequisicaoItensDTO.FieldNames.QtdFornecida] = int.Parse(rowsReqItemLote[0][RequisicaoItensDTO.FieldNames.QtdFornecida].ToString()) + qtdTransferir;
                    else
                    {
                        DataRow rowItemLote = dtbItemLoteTransf.NewRow();
                        rowItemLote[RequisicaoItensDTO.FieldNames.IdtProduto] = int.Parse(row[RequisicaoItensDTO.FieldNames.IdtProduto].ToString());
                        rowItemLote[RequisicaoItensDTO.FieldNames.IdtLote] = idLote;
                        rowItemLote[RequisicaoItensDTO.FieldNames.QtdFornecida] = qtdTransferir;
                        dtbItemLoteTransf.Rows.Add(rowItemLote);
                    }
                }
            }

            try
            {
                BeginTransaction();

                //Inserir o Pedido
                dtoRequisicaoNova = Requisicao.Gravar(dtoRequisicaoNova, dtbReqItemNova);
                RequisicaoDTO dtoReqTransf;

                //Varredura dos itens para efetuar a transferência
                foreach (DataRow rowTransf in dtbReqItemTransf.Rows)
                {
                    if (int.Parse(rowTransf["QTD_TRANSFERIR"].ToString()) > 0)
                    {
                        dtoMovimento = new MovimentacaoDTO();

                        // unidade de baixa
                        dtoMovimento.IdtUnidadeBaixa.Value = rowTransf[RequisicaoDTO.FieldNames.IdtUnidade].ToString();
                        dtoMovimento.IdtLocalBaixa.Value = rowTransf[RequisicaoDTO.FieldNames.IdtLocal].ToString();
                        dtoMovimento.IdtSetorBaixa.Value = rowTransf[RequisicaoDTO.FieldNames.IdtSetor].ToString();

                        // unidade de entrada
                        dtoMovimento.IdtUnidade.Value = dtoRequisicaoNova.IdtUnidade.Value;
                        dtoMovimento.IdtLocal.Value = dtoRequisicaoNova.IdtLocal.Value;
                        dtoMovimento.IdtSetor.Value = dtoRequisicaoNova.IdtSetor.Value;

                        dtoMovimento.IdtFilial.Value = (decimal)FilialMatMedDTO.Filial.HAC;
                        dtoMovimento.IdtRequisicao.Value = dtoRequisicaoNova.Idt.Value;
                        dtoMovimento.IdtAtendimento.Value = dtoRequisicaoNova.IdtAtendimento.Value;

                        dtoMovimento.IdtProduto.Value = int.Parse(rowTransf[RequisicaoItensDTO.FieldNames.IdtProduto].ToString());
                        idLote = int.Parse(rowTransf[RequisicaoItensDTO.FieldNames.IdtLote].ToString());
                        if (idLote != 0) dtoMovimento.IdtLote.Value = idLote;
                        dtoMovimento.Qtde.Value = int.Parse(rowTransf["QTD_TRANSFERIR"].ToString());
                        dtoMovimento.IdtTipo.Value = (byte)MovimentacaoDTO.TipoMovimento.ENTRADA;
                        dtoMovimento.IdtTipoBaixa.Value = (byte)MovimentacaoDTO.TipoMovimento.SAIDA;
                        dtoMovimento.IdtSubTipo.Value = (int)MovimentacaoDTO.SubTipoMovimento.TRANSFERENCIA_ENTRADA_PACIENTE;
                        dtoMovimento.IdtSubTipoBaixa.Value = (int)MovimentacaoDTO.SubTipoMovimento.TRANSFERENCIA_SAIDA_PACIENTE;
                        dtoMovimento.IdtUsuario.Value = dtoRequisicaoNova.IdtUsuario.Value;

                        Movimento.TransfereEstoqueProduto(dtoMovimento);

                        dtoReqTransf = new RequisicaoDTO();
                        dtoReqTransf.Idt.Value = rowTransf[RequisicaoDTO.FieldNames.Idt].ToString();
                        dtoReqTransf.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.TRANSFERIDO_PACIENTE;
                        dtoReqTransf.IdtReqRef.Value = dtoRequisicaoNova.Idt.Value;                        
                        dtoReqTransf.IdtUsuario.Value = dtoRequisicaoNova.IdtUsuario.Value;
                        Requisicao.Upd(dtoReqTransf);
                    }
                }

                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                mensagem = "Erro ao transferir item, favor comunicar ao administrador do Sistema!!! Descrição Erro: " + ex.Message;
                return false;
            }

            return true;
        }

        public RequisicaoItensDataTable SelReqItensLotesPendentesConsumoPac(int idAtendimento, int idSetor)
        {
            return entity.SelReqItensLotesPendentesConsumoPac(idAtendimento, idSetor);
        }

        public RequisicaoItensDataTable ListarPendenciasDispensacao(int? idPedido)
        {
            return entity.ListarPendenciasDispensacao(idPedido);
        }

        public RequisicaoItensDataTable ListarItensKit(int idPedido)
        {
            return entity.ListarItensKit(idPedido);
        }

        public RequisicaoItensDataTable ListarItensKit(int idPedido, int idProdutoRef)
        {
            return entity.ListarItensKit(idPedido, idProdutoRef);
        }

        public bool ExisteKitAssociadoPedidoAla(int idPedido)
        {
            return entity.ExisteKitAssociadoPedidoAla(idPedido);
        }

        public void InserirItemKit(int idPedido, int idProdutoRef, int? idKit, int? idProdutoKit, int qtdSolicitada)
        {
            entity.InserirItemKit(idPedido, idProdutoRef, idKit, idProdutoKit, qtdSolicitada);
        }

        public void AtualizarItemKit(int idPedido, int idProdutoRef, int? idKit, int? idProdutoKit, int qtdSolicitada)
        {
            entity.AtualizarItemKit(idPedido, idProdutoRef, idKit, idProdutoKit, qtdSolicitada);
        }

        public void ExcluirItensKit(int idPedido)
        {
            entity.ExcluirItensKit(idPedido);
        }

        public DataTable ObterIndiceDevolucaoPeriodo(RequisicaoDTO dto)
        {
            return entity.ObterIndiceDevolucaoPeriodo(dto);
        }

        public DataTable ListarDevolucoesPeriodo(RequisicaoDTO dto)
        {
            return entity.ListarDevolucoesPeriodo(dto);
        }

        public void InsPedidoAutoControle(RequisicaoItensDTO dto)
        {
            entity.InsPedidoAutoControle(dto);
        }

        public void UpdPedidoAutoControle(RequisicaoItensDTO dto, DateTime? novaDataHoraGeracao)
        {
            entity.UpdPedidoAutoControle(dto, novaDataHoraGeracao);
        }

        public void CancelarPedidoAutoControle(RequisicaoItensDTO dto)
        {
            entity.CancelarPedidoAutoControle(dto);
        }

        public void CancelarPedidoAutoControle(RequisicaoItensDTO dto, bool reativar)
        {
            entity.CancelarPedidoAutoControle(dto, reativar);
        }

        public void DelPedidoAutoControle(RequisicaoItensDTO dto)
        {
            entity.DelPedidoAutoControle(dto);
        }

        /// <summary>
        /// ListarPedidoAutoControle
        /// </summary>        
        /// <param name="tipoBusca">1 = TODOS
        ///                         2 = PENDENTES DE GERAÇÃO
        ///                         3 = JÁ GERADOS
        ///                         4 = PENDENTES DE GERAÇÃO JUNTO COM SUSPENSOS NA PRESCRIÇÃO DA INTERNAÇÃO
        ///                         5 = SUSPENSOS NA PRESCRIÇÃO DA INTERNAÇÃO
        /// </param>
        public RequisicaoItensDataTable ListarPedidoAutoControle(RequisicaoItensDTO dtoItem, RequisicaoDTO dtoReq, byte tipoBusca)
        {
            return entity.ListarPedidoAutoControle(dtoItem, dtoReq, tipoBusca);
        }

        /// <summary>
        /// Retorna qtd. do kit específico ou sem kit algum
        /// </summary>        
        public int ObterQtdSolicitadaAssKit(int idPedido, int idProdutoRef, int? idKit, int? idProdutoKit)
        {
            RequisicaoItensDataTable dtbRI = new RequisicaoItens().ListarItensKit(idPedido, idProdutoRef);
            foreach (DataRow rowItem in dtbRI.Rows)
            {
                if (idKit != null && idProdutoKit != null)
                {
                    if (rowItem["CAD_MTMD_KIT_ID_ITEM"].ToString() == idKit.Value.ToString() &&
                        rowItem["CAD_MTMD_ID_KIT"].ToString() == idProdutoKit.Value.ToString())
                    {
                        return int.Parse(rowItem[RequisicaoItensDTO.FieldNames.QtdSolicitada].ToString());
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(rowItem["CAD_MTMD_KIT_ID_ITEM"].ToString()) &&
                        string.IsNullOrEmpty(rowItem["CAD_MTMD_ID_KIT"].ToString()))
                    {
                        return int.Parse(rowItem[RequisicaoItensDTO.FieldNames.QtdSolicitada].ToString());
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// Retorna qtd. total com kit associado
        /// </summary>        
        public int ObterQtdSolicitadaAssKit(int idPedido, int idProdutoRef)
        {
            int retorno = 0;
            RequisicaoItensDataTable dtbRI = new RequisicaoItens().ListarItensKit(idPedido, idProdutoRef);
            foreach (DataRow rowItem in dtbRI.Rows)
            {
                if (!string.IsNullOrEmpty(rowItem["CAD_MTMD_KIT_ID_ITEM"].ToString()) &&
                    !string.IsNullOrEmpty(rowItem["CAD_MTMD_ID_KIT"].ToString()))
                {
                    retorno += int.Parse(rowItem[RequisicaoItensDTO.FieldNames.QtdSolicitada].ToString());
                }
            }
            return retorno;
        }

        public DateTime ObterDataInicioAdmPacientePadrao(RequisicaoDTO dtoReq, out DateTime dataInicioEmissao)
        {
            int horaCorteSetor = (int)dtoReq.SetorPedidoAutoHoraInicioProcesso.Value;
            int periodoGerarSetor = (int)dtoReq.SetorPedidoAutoHorasPeriodoDose.Value;            
            int horasMinimaParaAbastecimento = (int)dtoReq.SetorPedidoAutoHorasMinimaIniciar.Value;
            DateTime dataAtual = DateTime.Now;
            DateTime dataInicioCorte = DateTime.Parse(dataAtual.Date.ToString("dd/MM/yyyy") + " " + horaCorteSetor.ToString().PadLeft(2, '0') + ":00");

            if (dataAtual > dataInicioCorte)
                dataInicioCorte = dataInicioCorte.AddHours(periodoGerarSetor);

            dataInicioEmissao = dataInicioCorte.AddHours(-horasMinimaParaAbastecimento);
            if (dataAtual > dataInicioEmissao)
            {
                dataInicioEmissao = dataInicioEmissao.AddHours(periodoGerarSetor);
                dataInicioCorte = dataInicioEmissao.AddHours(horasMinimaParaAbastecimento);
            }
            
            return dataInicioCorte;
        }

        public RequisicaoItensDataTable ListarItensPrescricaoInt(RequisicaoDTO dto, int? idPrescInt, string statusItens)
        {
            return entity.ListarItensPrescricaoInt(dto, idPrescInt, statusItens);
        }

        public RequisicaoItensDataTable ListarItensGeradosPrescricaoInt_SemPedidoGestao(RequisicaoItensDTO dto)
        {
            return entity.ListarItensGeradosPrescricaoInt_SemPedidoGestao(dto);
        }

        public void UpdStatusItemPrescricaoInt(int? idPrescInt, int? idPrescItem, int idUsuario, string statusItem)
        {
            entity.UpdStatusItemPrescricaoInt(idPrescInt, idPrescItem, idUsuario, statusItem);
        }

        public void UpdStatusPrescricaoInt(int idPrescInternacao, string status)
        {
            entity.UpdStatusPrescricaoInt(idPrescInternacao, status);
        }

        public string ObterTelefoneUsuarioMedicoInt(int idPrescItem)
        {
            return entity.ObterTelefoneUsuarioMedicoInt(idPrescItem);
        }

        public void CancelarProgramacaoItensPrescricao(DataTable dtbReqItem)
        {
            foreach (DataRow rowProgramado in dtbReqItem.Rows)
            {
                if (string.IsNullOrEmpty(rowProgramado[RequisicaoItensDTO.FieldNames.IdtNovo].ToString()))
                {
                    RequisicaoItensDTO dtoReqItemCancela = new RequisicaoItensDTO();

                    dtoReqItemCancela.Idt.Value = rowProgramado[RequisicaoItensDTO.FieldNames.Idt].ToString();
                    dtoReqItemCancela.IdtProduto.Value = rowProgramado[RequisicaoItensDTO.FieldNames.IdtProduto].ToString();
                    dtoReqItemCancela.DataHoraGerar.Value = rowProgramado[RequisicaoItensDTO.FieldNames.DataHoraGerar].ToString();
                    dtoReqItemCancela.DataHoraAdmPaciente.Value = rowProgramado[RequisicaoItensDTO.FieldNames.DataHoraAdmPaciente].ToString();
                    dtoReqItemCancela.IdUsuarioPedidoAutoCancelado.Value = 1;

                    this.CancelarPedidoAutoControle(dtoReqItemCancela);
                }
            }
        }        

        public void InserirItensKitPedido(RequisicaoItensDTO dtoReqItem)
        {
            RequisicaoItens reqItem = new RequisicaoItens();
            Kit kit = new Kit();            

            if (!string.IsNullOrEmpty(dtoReqItem.IdKitItem.Value.ToString()))
            {
                KitDTO dtoKit = new KitDTO();
                dtoKit.IdKit.Value = dtoReqItem.IdKitItem.Value.ToString();
                DataTable dtbKitItens = kit.ListarItem(dtoKit);
                byte qtdMultiplica = 1;
                if (!string.IsNullOrEmpty(dtoReqItem.QtdKitItemMultiplica.Value.ToString()))
                    qtdMultiplica = byte.Parse(dtoReqItem.QtdKitItemMultiplica.Value.ToString());

                foreach (DataRow rowKitItem in dtbKitItens.Rows)
                {
                    int qtdKit = (int.Parse(rowKitItem[KitDTO.FieldNames.QtdeItem].ToString()) * qtdMultiplica);
                    RequisicaoItensDTO dtoReqItemNovo = new RequisicaoItensDTO();

                    dtoReqItemNovo.Idt.Value = dtoReqItem.Idt.Value;
                    dtoReqItemNovo.IdtProduto.Value = rowKitItem[KitDTO.FieldNames.IdProduto].ToString();
                    dtoReqItemNovo.QtdSolicitada.Value = qtdKit;
                    dtoReqItemNovo.QtdFornecida.Value = 0;

                    RequisicaoItensDTO dtoReqItemVerifica = new RequisicaoItensDTO();
                    dtoReqItemVerifica = new RequisicaoItensDTO();
                    dtoReqItemVerifica.Idt.Value = dtoReqItem.Idt.Value;
                    dtoReqItemVerifica.IdtProduto.Value = dtoReqItemNovo.IdtProduto.Value;
                    RequisicaoItensDataTable dtbReqItemVerifica = reqItem.Sel(dtoReqItemVerifica);

                    if (dtbReqItemVerifica.Rows.Count == 0)
                        reqItem.Ins(dtoReqItemNovo);
                    else
                    {
                        dtoReqItemNovo.QtdSolicitada.Value = (int)dtbReqItemVerifica.TypedRow(0).QtdSolicitada.Value + (int)dtoReqItemNovo.QtdSolicitada.Value;
                        qtdKit = (int)dtoReqItemNovo.QtdSolicitada.Value;
                        reqItem.Upd(dtoReqItemNovo);
                    }

                    reqItem.AtualizarItemKit((int)dtoReqItemNovo.Idt.Value,
                                             (int)dtoReqItemNovo.IdtProduto.Value,
                                             (int)dtoReqItem.IdKitItem.Value,
                                             (int)dtoReqItem.IdtProduto.Value,
                                             qtdKit);

                    int qtdTotalSolAss = reqItem.ObterQtdSolicitadaAssKit((int)dtoReqItemNovo.Idt.Value,
                                                                          (int)dtoReqItemNovo.IdtProduto.Value,
                                                                          null,
                                                                          null);
                    int difQtdKit = (qtdTotalSolAss - (int)dtoReqItemNovo.QtdSolicitada.Value);

                    if (difQtdKit <= 0)
                        reqItem.AtualizarItemKit((int)dtoReqItemNovo.Idt.Value,
                                                 (int)dtoReqItemNovo.IdtProduto.Value,
                                                 null,
                                                 null,
                                                 0);
                    else
                        reqItem.AtualizarItemKit((int)dtoReqItemNovo.Idt.Value,
                                                 (int)dtoReqItemNovo.IdtProduto.Value,
                                                 null,
                                                 null,
                                                 difQtdKit);
                }
            }
        }

        public int ObterQtdPedidoTotalGerarItem(int qtdHorasTotalGerar, int periodoGerarItem, int qtdPedidoGerar)
        {
            double dblQtdPedidoTotalGerarItem = (double)qtdHorasTotalGerar / (double)periodoGerarItem;
            dblQtdPedidoTotalGerarItem = Math.Ceiling(dblQtdPedidoTotalGerarItem);
            int qtdPedidoTotalGerarItem = (int)dblQtdPedidoTotalGerarItem;
            qtdPedidoTotalGerarItem = qtdPedidoTotalGerarItem * qtdPedidoGerar; //Qtd. total do item a gerar
            return qtdPedidoTotalGerarItem;
        }
	}
}