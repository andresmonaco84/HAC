using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.Services.CadastroFaturamento.DTO;
using HospitalAnaCosta.SGS.Cadastro.Control;
using HospitalAnaCosta.Services.CalculoFaturamento.Control;
//TODO: Implementar a conexão com o serviço, hoje está usando direto da DLL, isso não garante estar usando a última versão

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
    public class Movimentacao : Control, IMovimentacao
    {
        private Setor Setor = new Setor();

        private Model.Movimentacao entity = new Model.Movimentacao();

        public DataTable SelMovArquivoContHeader(MovimentacaoMensalDTO dto)
        {
            return entity.SelMovArquivoContHeader(dto);
        }

        public DataTable SelMovArquivoCont(MovimentacaoMensalDTO dto)
        {
            return entity.SelMovArquivoCont(dto);
        }

        /// <summary>
        /// Listar todos os registros
        /// </summary>
        public MovimentacaoDataTable Sel(MovimentacaoDTO dto, bool consumoPaciente)
        {
            //MovimentacaoDataTable dtb = entity.Sel(dto, consumoPaciente);
            //foreach (DataRow row in dtb.Rows)
            //{
            //    dto = (MovimentacaoDTO)row;
            //    // SE PRODUTO É FRACIONADO MAS FOI CONSUMIDO COMO INTEIRO NÃO MOSTRA (/UNIDADE DE VENDA) NA TELA
            //    if (dto.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.SIM && 
            //        ( dto.IdtSubTipo.Value == (byte)MovimentacaoDTO.SubTipoMovimento.MOVIMENTACAO_FRACIONADA ||
            //          dto.IdtSubTipo.Value == (byte)MovimentacaoDTO.SubTipoMovimento.BAIXA_FRACIONADA_NAO_FATURADA ))
            //    {
            //        row[MovimentacaoDTO.FieldNames.DsQtdeConsumo] = string.Format("{0}/{1}", Convert.ToString(row[MovimentacaoDTO.FieldNames.Qtde]), dto.UnidadeVenda.Value.ToString());
            //    }
            //    else
            //    {
            //        row[MovimentacaoDTO.FieldNames.DsQtdeConsumo] = string.Format("{0}", Convert.ToString(row[MovimentacaoDTO.FieldNames.Qtde]));
            //    }
            //}
            //return dtb;
            return entity.Sel(dto, consumoPaciente);
        }

        /// <summary>
        /// Obter pela chave
        /// </summary>
        public MovimentacaoDTO SelChave(MovimentacaoDTO dto)
        {
            return entity.SelChave(dto);

        }

        /// <summary>
        /// Seleciona movimentos que possuem itens de requisição com divergência no abastecimento do estoque
        /// </summary>
        public MovimentacaoDataTable SelDivergencias(MovimentacaoDTO dto)
        {
            return entity.SelDivergencias(dto);
        }

        ///<summary>
        /// Insere um registro
        /// </summary>
        public void Ins(MovimentacaoDTO dto)
        {
            entity.Ins(dto);
        }

        ///<summary>
        /// Apaga um registro
        /// </summary>		
        public void Del(MovimentacaoDTO dto)
        {
            entity.Del(dto);
        }

        ///<summary>
        /// Atualiza um registro
        /// </summary>		
        public void Upd(MovimentacaoDTO dto)
        {
            entity.Upd(dto);
        }

        public MovimentacaoDTO EntradaProduto(MovimentacaoDTO dto)
        {
            dto = entity.EntradaProduto(dto);

            if (dto.IdtSubTipo.Value == (byte)MovimentacaoDTO.SubTipoMovimento.DEVOLUCAO_SETOR_SEM_PEDIDO && !dto.idtMotivo.Value.IsNull)
            {
                // se for movimentação de registro de perda, adiciona complemento
                MovimentacaoComplemento Complemento = new MovimentacaoComplemento();
                MovimentacaoComplementoDTO dtoComplemento = new MovimentacaoComplementoDTO();
                dtoComplemento.Idt.Value = dto.Idt.Value;
                dtoComplemento.Obs.Value = dto.Obs.Value;
                dtoComplemento.idtMotivo.Value = dto.idtMotivo.Value;
                dtoComplemento.UsuarioRelatado.Value = dto.UsuarioRelatado.Value;
                Complemento.Ins(dtoComplemento);
            }

            return dto;
        }

        /// <summary>
        /// Realiza Transferencia entre estoques
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public MovimentacaoDTO TransfereEstoqueProduto(MovimentacaoDTO dto)
        {
            return entity.TransfereEstoqueProduto(dto);
        }

        public MovimentacaoDTO EnviaProdutoFaturamento(MovimentacaoDTO dtoMovimento, MaterialMedicamentoDTO dtoMatMed, int? idSetorFatura)
        {
            dtoMovimento = this.ConverteMatMedMovimento(dtoMatMed, dtoMovimento);

            if (!dtoMovimento.TpFracao.Value.IsNull)
            {
                dtoMovimento.QtdConvertida.Value = dtoMovimento.Qtde.Value.ToString();
                dtoMovimento.Qtde.Value = entity.ConverterQtdFracaoGotas(dtoMovimento);
                dtoMovimento.DsQtdeConsumo.Value = dtoMovimento.Qtde.Value.ToString() + '/' + dtoMatMed.UnidadeVenda.Value.ToString();
            }

            entity.Ins(dtoMovimento);

            if (!dtoMovimento.Idt.Value.IsNull)
            {
                try
                {
                    this.FaturarProduto(dtoMovimento, dtoMatMed, idSetorFatura);
                }
                catch (Exception ex)
                {                    
                    throw new Exception(ex.Message.Replace("#pac_nao_encontrado", string.Empty));
                }
            }
            return dtoMovimento;
        }

        /// <summary>
        /// Baixa produto do estoque da unidade.
        /// Caso dtoMovimento possua Cod. Barra, busca o produto pelo códido de barra.
        /// Se não, o parâmetro dtoMatMed tem que ser diferente de null. 
        /// </summary>                
        public MovimentacaoDTO MovimentaEstoqueProduto(MovimentacaoDTO dtoMovimento, MaterialMedicamentoDTO dtoMatMed, int? idSetorFatura)
        {
            if (dtoMatMed.FlFracionado.Value.IsNull) dtoMatMed.FlFracionado.Value = 0;
            if (dtoMatMed.FlFracionado.Value == 1 &&
                (!dtoMovimento.FlFracionado.Value.IsNull && dtoMovimento.FlFracionado.Value == 1))
            {
                int qtdMinima = new Model.MaterialMedicamento().QtdMinima(dtoMatMed);
                if (qtdMinima != 0 && dtoMovimento.Qtde.Value < qtdMinima)             
                    throw new HacException("Qtd. do consumo fracionado deste item tem que ser no mínimo " + qtdMinima.ToString());             
            }

            // this.MovimentaEstoqueProduto(new MovimentacaoDataTable(), dtoMovimento, dtoMatMed);
            dtoMovimento = this.ConverteMatMedMovimento(dtoMatMed, dtoMovimento);
            dtoMovimento = entity.MovimentaEstoqueProduto(dtoMovimento);
            #region OLD
            //if (dtoMovimento.IdtSubTipo.Value.ToString() != ((int)MovimentacaoDTO.SubTipoMovimento.BAIXA_CONSUMO_NAO_FATURADO_SETOR).ToString() &&
            //    dtoMovimento.IdtSubTipo.Value.ToString() != ((int)MovimentacaoDTO.SubTipoMovimento.BAIXA_FRACIONADA_NAO_FATURADA).ToString())
            //{
            //    //Descomentar a chamada deste método quando entrar o novo sistema de faturamento em produção e
            //    //comentar chamada da proc PRC_MTMD_MOV_FATURAR_ONLINE na PRC_MTMD_MOV_ESTOQUE_BAIXA
            //    if (!dtoMovimento.Idt.Value.IsNull) this.FaturarProduto(dtoMovimento, dtoMatMed);
            //}
            #endregion            
            if (!dtoMovimento.Idt.Value.IsNull && !dtoMovimento.IdtAtendimento.Value.IsNull)
            {                
                try
                {
                    this.FaturarProduto(dtoMovimento, dtoMatMed, idSetorFatura);
                }
                catch (Exception ex)
                {
                    this.EstornarMovimentoConsumoPaciente(dtoMovimento);
                    throw new Exception(ex.Message.Replace("#pac_nao_encontrado", string.Empty));
                }                
            }

            if (dtoMovimento.IdtTipo.Value == (byte)MovimentacaoDTO.TipoMovimento.SAIDA &&
                (dtoMovimento.IdtSubTipo.Value == (byte)MovimentacaoDTO.SubTipoMovimento.BAIXA_PERDA_QUEBRA || dtoMovimento.IdtSubTipo.Value == (byte)MovimentacaoDTO.SubTipoMovimento.DEVOLUCAO_CONSIGNADO_FORNECEDOR))
            {
                // se for movimentação de registro de perda, adiciona complemento
                MovimentacaoComplemento Complemento = new MovimentacaoComplemento();
                MovimentacaoComplementoDTO dtoComplemento = new MovimentacaoComplementoDTO();
                dtoComplemento.Idt.Value = dtoMovimento.Idt.Value;
                dtoComplemento.Obs.Value = dtoMovimento.Obs.Value;
                dtoComplemento.idtMotivo.Value = dtoMovimento.idtMotivo.Value;
                dtoComplemento.UsuarioRelatado.Value = dtoMovimento.UsuarioRelatado.Value;
                Complemento.Ins(dtoComplemento);
            }

            return dtoMovimento;
        }

        /// <summary>
        /// Baixa produto do estoque da unidade e envia para faturamento.
        /// Caso dtoMovimento possua Cod. Barra, busca o produto pelo códido de barra.
        /// Se não, o parâmetro dtoMatMed tem que ser diferente de null. 
        /// </summary>                
        private MovimentacaoDataTable MovimentaEstoqueProduto(MovimentacaoDataTable dtbMovimento, MovimentacaoDTO dtoMovimento, MaterialMedicamentoDTO dtoMatMed)
        {
            // NAO ESTA MAIS EM USO ############################################

            // CHAMADA DE
            // FrmconsumoPaciente
            try
            {
                #region Retirado, Informação vem da tela
                //if (!dtoMovimento.CdBarra.Value.IsNull)
                //{
                //    MaterialMedicamento MatMed = new MaterialMedicamento();
                //    CodigoBarraDTO dtoCodigoBarra = new CodigoBarraDTO();

                //    dtoCodigoBarra.CdBarra.Value = dtoMovimento.CdBarra.Value;
                //    dtoCodigoBarra.IdtFilial.Value = dtoMovimento.IdtFilial.Value;
                //    // BUSCA TODAS AS INFORMAÇÕES DO PRODUTO PELO CODIGO DE BARRA
                //    dtoMatMed = MatMed.BuscaCodigoBarra(dtoCodigoBarra);
                //}
                #endregion

                if (dtoMatMed == null)
                {
                    throw new HacException(" Material/medicamento não identificado ");
                }

                #region retirado
                //if (dtoMovimento.IdtTipo.Value != (byte)MovimentacaoDTO.TipoMovimento.SAIDA && dtoMovimento.IdtSubTipo.Value != (byte)MovimentacaoDTO.SubTipoMovimento.BAIXA_PERDA_QUEBRA)
                //{
                //    if (dtoMatMed.IdtFilial.Value != (byte)FilialMatMedDTO.Filial.AMBOS)
                //    {
                //        string msgMatIndisponivelPlano = " Este material/medicamento não está disponível para o plano deste paciente ";

                //        if (dtoMovimento.IdtFilial.Value == (byte)FilialMatMedDTO.Filial.HAC)
                //        {
                //            if (dtoMatMed.IdtFilial.Value != (byte)FilialMatMedDTO.Filial.HAC)
                //            {
                //                throw new HacException(msgMatIndisponivelPlano);
                //            }
                //        }
                //        else
                //        {
                //            if (dtoMatMed.IdtFilial.Value != (byte)FilialMatMedDTO.Filial.ACS)
                //            {
                //                throw new HacException(msgMatIndisponivelPlano);
                //            }
                //        }
                //    }
                //}                
                #endregion

                dtoMovimento.FlFinalizado.Value = (byte)MovimentacaoDTO.StatusMovimento.FECHADO;

                // BUSCA INFORMAÇÕES SOBRE PRODUTO, INCLUSIVE ESTOQUE
                dtoMovimento = this.ConverteMatMedMovimento(dtoMatMed, dtoMovimento);
                // bool existeEstoque = true;

                // VERIFICA SE FRACIONAMENTO FOI TROCADO NA TELA ( USUARIO TEM A OPÇÃO DE CONSUMIR FRACIONADO COMO INTEIRO )
                if (!dtoMovimento.FlFracionado.Value.IsNull)
                    dtoMatMed.FlFracionado.Value = dtoMovimento.FlFracionado.Value;
                #region Retirado Qtde em estoque testada no procedure
                //if (dtoMovimento.EstoqueLocal.Value <= 0 || dtoMovimento.EstoqueLocal.Value.IsNull)
                //{
                //    existeEstoque = false;
                //}
                //else if (dtoMovimento.EstoqueLocal.Value < dtoMovimento.Qtde.Value &&
                //         dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.NAO)
                //{
                //    existeEstoque = false;
                //}

                //if (!existeEstoque) throw new HacException(" Não existe estoque para realizar essa transação ");
                #endregion

                // Realiza movimento no estoque ====================================
                dtoMovimento = entity.MovimentaEstoqueProduto(dtoMovimento);
                // =================================================================

                if (dtoMovimento.IdtTipo.Value == (byte)MovimentacaoDTO.TipoMovimento.SAIDA && dtoMovimento.IdtSubTipo.Value == (byte)MovimentacaoDTO.SubTipoMovimento.BAIXA_PERDA_QUEBRA)
                {
                    // se for movimentação de registro de perda, adiciona complemento
                    MovimentacaoComplemento Complemento = new MovimentacaoComplemento();
                    MovimentacaoComplementoDTO dtoComplemento = new MovimentacaoComplementoDTO();
                    dtoComplemento.Idt.Value = dtoMovimento.Idt.Value;
                    dtoComplemento.Obs.Value = dtoMovimento.Obs.Value;
                    dtoComplemento.UsuarioRelatado.Value = dtoMovimento.UsuarioRelatado.Value;
                    Complemento.Ins(dtoComplemento);
                }


                return dtbMovimento;
            }
            catch (HacException ex)
            {
                throw new HacException(ex.Message);
            }
            catch (Exception ex)
            {
                // RollbackTransaction();
                // throw new HacException(" Erro, foi realizado RollBack da transação ", ex);
                throw new HacException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Verifica e executa o processo de faturamento do produto consumido pelo paciente
        /// </summary>        
        public void FaturarProduto(MovimentacaoDTO dtoMovimento, MaterialMedicamentoDTO dtoMatMed, int? idSetorFatura)
        {
            if (dtoMatMed.FlFaturado.Value.IsNull) dtoMatMed.FlFaturado.Value = (byte)MaterialMedicamentoDTO.Faturado.NAO;
            if ((dtoMovimento.IdtSetor.Value == 2252) || //Sempre mandar faturar para ATENDIMENTO DOMICILIAR
                (dtoMatMed.FlBaixaAutomatica.Value == (byte)MaterialMedicamentoDTO.BaixaAutomatica.NAO &&
                 dtoMatMed.FlFaturado.Value == (byte)MaterialMedicamentoDTO.Faturado.SIM))
            {
                string tipoEmpresa = dtoMovimento.TipoEmpresa.Value;

                dtoMovimento = this.SelChave(dtoMovimento);

                if (idSetorFatura != null && idSetorFatura.Value > 0)
                    dtoMovimento.IdtSetor.Value = idSetorFatura;

                if (dtoMovimento.IdtSetor.Value == 2913) //FARMACIA QUIMIOTERAPIA
                {
                    dtoMovimento.IdtUnidade.Value = 248; //AMB. SANTOS AMAZONAS
                    dtoMovimento.IdtLocal.Value = 27; //AMBULATORIO
                    dtoMovimento.IdtSetor.Value = 159; //QUIMIOTERAPIA
                }

                if (dtoMovimento.SubTipoMovFaturado.Value == (byte)MovimentacaoDTO.SubTipoMovimentoFaturado.SIM)
                {
                    //Pega o TipoEmpresa (HAC ou ACS) vindo da tela
                    dtoMovimento.TipoEmpresa.Value = tipoEmpresa;

                    if (dtoMovimento.IdtSubTipo.Value != (byte)MovimentacaoDTO.SubTipoMovimento.INFO_ENVIO_FATURAMENTO)
                    {
                        if (dtoMovimento.IdtSubTipo.Value == (byte)MovimentacaoDTO.SubTipoMovimento.MOVIMENTACAO_FRACIONADA_CARRINHO_EMERGENCIA ||
                            dtoMovimento.IdtSubTipo.Value == (byte)MovimentacaoDTO.SubTipoMovimento.MOVIMENTACAO_FRACIONADA)
                            dtoMovimento.FlFracionado.Value = (byte)MaterialMedicamentoDTO.Fracionado.SIM;
                        else
                            dtoMovimento.FlFracionado.Value = (byte)MaterialMedicamentoDTO.Fracionado.NAO;
                    }

                    try
                    {
                        //Execução da rotina de faturamento
                        CalculoProduto busCalculoProduto = new CalculoProduto();
                        ContaConsumoItemDTO dtoContaConsumoItem = busCalculoProduto.ProcessarFaturamentoMatMed(dtoMatMed, dtoMovimento);

                        if (!dtoContaConsumoItem.IdtContaConsumoItem.Value.IsNull)
                        {
                            dtoMovimento.SequenciaConsumoFaturamento.Value = dtoContaConsumoItem.IdtContaConsumoItem.Value;
                            entity.ProcessarRotinaPosFaturamento(dtoMovimento);
                        }
                        else
                        {
                            //throw new HacException(string.Format("Houve um erro não tratado referente ao faturamento. Contate algum administrador do sistema. Anote o Código do Movimento: ", dtoMovimento.Idt.Value.ToString()));
                            Log log = new Log();
                            log.Gravar("Houve um erro não tratado referente ao faturamento de mat/med, e não foi possível enviar o produto para fatura.", "GestaoMateriais/Faturamento", "GestaoMateriais.Control.Movimentacao", "FaturarProduto", dtoMovimento.IdtAtendimento.Value.ToString(), string.Empty, string.Empty, dtoMatMed.CodMne.Value, dtoMovimento.IdtUsuario.Value);
                        }
                    }
                    catch (Exception ex)
                    {
                        //Não gravar log quando paciente estiver em pre-cadastro ou atendimento for cancelado
                        if (ex.Message.IndexOf("#pac_nao_encontrado") > -1) throw new Exception(ex.Message);
                        
                        Log log = new Log();
                        log.Gravar(ex.Message, "GestaoMateriais/Faturamento", "GestaoMateriais.Control.Movimentacao", "FaturarProduto", dtoMovimento.IdtAtendimento.Value.ToString(), string.Empty, string.Empty, dtoMatMed.CodMne.Value, dtoMovimento.IdtUsuario.Value);
                    }                    
                }
            }            
        }

        /// <summary>
        /// Baixa produto do estoque da unidade.
        /// Caso dtoMovimento possua Cod. Barra, busca o produto pelo códido de barra.
        /// Se não, o parâmetro dtoMatMed tem que ser diferente de null. 
        /// </summary>                
        public void DistribuiDespesaCentroCusto(MovimentacaoDTO dto)
        {
            entity.DistribuiDespesaCentroCusto(dto);
        }

        public MovimentacaoDataTable HistoricoDespesaCentroCusto(MovimentacaoDTO dto)
        {
            return entity.HistoricoDespesaCentroCusto(dto);
        }

        public MovimentacaoDataTable HistoricoDespesaCentroCustoSintetico(MovimentacaoDTO dto)
        {
            return entity.HistoricoDespesaCentroCustoSintetico(dto);
        }

        public MovimentacaoDataTable HistoricoDespesaCentroCustoPacientes(MovimentacaoDTO dto)
        {
            return entity.HistoricoDespesaCentroCustoPacientes(dto);
        }

        /// <summary>
        /// Converte DTO MatMed Para DTO Movimentação e Busca saldo em estoque do produto
        /// </summary>
        /// <param name="dtoMatMed"></param>
        /// <param name="dtoMovimento"></param>
        /// <returns></returns>
        public MovimentacaoDTO ConverteMatMedMovimento(MaterialMedicamentoDTO dtoMatMed, MovimentacaoDTO dtoMovimento)
        {
            EstoqueLocalDTO dtoEstoque = new EstoqueLocalDTO();
            EstoqueLocal Estoque = new EstoqueLocal();
            /*
            if (dtoMovimento == null)
                dtoMovimento = new MovimentacaoDTO();
            */
            dtoMovimento.IdtProduto.Value = dtoMatMed.Idt.Value;
            dtoMovimento.DsProduto.Value = dtoMatMed.NomeFantasia.Value;
            if (!dtoMatMed.IdtLote.Value.IsNull && (decimal)dtoMatMed.IdtLote.Value != 0)
                dtoMovimento.IdtLote.Value = dtoMatMed.IdtLote.Value;
            // busca saldo da unidade
            dtoEstoque.IdtProduto.Value = dtoMovimento.IdtProduto.Value;
            dtoEstoque.IdtUnidade.Value = dtoMovimento.IdtUnidade.Value;
            dtoEstoque.IdtLocal.Value = dtoMovimento.IdtLocal.Value;
            dtoEstoque.IdtSetor.Value = dtoMovimento.IdtSetor.Value;
            //dtoEstoque.IdtLote.Value = dtoMovimento.IdtLote.Value;
            dtoEstoque.IdtFilial.Value = dtoMovimento.IdtFilial.Value;
            // S A L D O
            dtoEstoque = Estoque.EstoqueLocalProduto(dtoEstoque);
            //
            dtoMovimento.EstoqueLocal.Value = dtoEstoque.Qtde.Value;
            //dtoMovimento.IdtLote.Value = dtoEstoque.IdtLote.Value;
            dtoMovimento.QtdeLote.Value = dtoEstoque.QtdeLote.Value;
            dtoMovimento.EstoqueLocalFracionado.Value = dtoEstoque.QtdeFracionada.Value;
            dtoMovimento.DsUnidadeVenda.Value = dtoMatMed.DsUnidadeVenda.Value;
            dtoMovimento.DataMovimento.Value = DateTime.Now;
            if (dtoMovimento.Qtde.Value.IsNull)
            {
                if (!dtoMatMed.UnidadeConsumo.Value.IsNull)
                    dtoMovimento.Qtde.Value = dtoMatMed.UnidadeConsumo.Value;
                else
                    dtoMovimento.Qtde.Value = 1;
            }

            if (dtoMovimento.DsQtdeConsumo.Value.IsNull)
                dtoMovimento.DsQtdeConsumo.Value = dtoMovimento.Qtde.Value.ToString();

            if (dtoMovimento.FlFracionado.Value == (int)MaterialMedicamentoDTO.Fracionado.SIM)
                dtoMovimento.DsQtdeConsumo.Value = dtoMovimento.DsQtdeConsumo.Value + '/' + dtoMatMed.UnidadeVenda.Value.ToString();

            return dtoMovimento;

        }

        /// <summary>
        /// Busca Centro de dispensacao da unidade que esta requisitando material
        /// AINDA ESTÁ EM USO ???? 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public MovimentacaoDTO CentroDispensacao(MovimentacaoDTO dto, out SetorDTO dtoSetorFarmacia)
        {
            SetorDTO dtoSetor = new SetorDTO();

            dtoSetor.Idt = dto.IdtSetor;

            dtoSetor = Setor.SelChave(dtoSetor);
            dtoSetorFarmacia = null;
            if (!dtoSetor.SetorFarmacia.Value.IsNull)
            {
                dtoSetorFarmacia = new SetorDTO();
                dtoSetorFarmacia.Idt.Value = dtoSetor.SetorFarmacia.Value;
                dtoSetorFarmacia = Setor.SelChave(dtoSetorFarmacia);
            }            

            if (!dtoSetor.UnidadeAlmoxarifado.Value.IsNull && !dtoSetor.LocalAlmoxarifado.Value.IsNull && !dtoSetor.SetorAlmoxarifado.Value.IsNull)
            {
                dto.IdtUnidadeBaixa.Value = dtoSetor.UnidadeAlmoxarifado.Value;
                dto.IdtLocalBaixa.Value = dtoSetor.LocalAlmoxarifado.Value;
                dto.IdtSetorBaixa.Value = dtoSetor.SetorAlmoxarifado.Value;
            }
            else
            {
                dtoSetor = Setor.SelAlmoxarifadoCentral();

                if (dtoSetor != null)
                {
                    dto.IdtUnidadeBaixa.Value = dtoSetor.IdtUnidade.Value;
                    dto.IdtLocalBaixa.Value = dtoSetor.IdtLocalAtendimento.Value;
                    dto.IdtSetorBaixa.Value = dtoSetor.Idt.Value;
                }
            }

            return dto;
        }

        /// <summary>
        /// Estorna (exclui) o consumo realizado pelo paciente.
        /// Este processo devolve o produto ao estoque, sendo o processo inverso da baixa,
        /// mas isto não poderá acontecer se o produto já estiver sido faturado.
        /// Provavelmente isto deverá acontecer apenas quando a enfermeira perceber 
        /// que errou na realização de uma baixa de um paciente.
        /// </summary>      
        public void EstornarMovimentoConsumoPaciente(MovimentacaoDTO dto)
        {
            entity.EstornarMovimentoConsumoPaciente(dto);
            this.EstornarMovimentoFaturamento(dto);                      
        }

        public void EstornarMovimentoFaturamento(MovimentacaoDTO dto)
        {
            try
            {
                //BeginTransaction();

                ContaConsumoItemDTO dtoContaConsumoItem = new ContaConsumoItemDTO();

                if (dto.SequenciaConsumoFaturamento.Value.IsNull) dto = entity.ObterSequenciaConsumoFaturamento(dto);
                if (!dto.SequenciaConsumoFaturamento.Value.IsNull)
                {
                    dtoContaConsumoItem.IdtContaConsumoItem.Value = dto.SequenciaConsumoFaturamento.Value;
                    new CalculoProduto().EstornarItemFaturado(dtoContaConsumoItem);
                }

                //if (new CalculoProduto().EstornarItemFaturado(dtoContaConsumoItem))
                //    entity.ProcessarRotinaPosFaturamentoEstorno(dto);                     

                //CommitTransaction();
            }
            catch (Exception ex)
            {
                //RollbackTransaction();
                Log log = new Log();
                log.Gravar(ex.Message, "GestaoMateriais/Faturamento", "GestaoMateriais.Control.Movimentacao", "EstornarMovimentoConsumoPaciente", dto.IdtAtendimento.Value.ToString(), string.Empty, string.Empty, string.Empty, dto.IdtUsuarioEstorno.Value);
            }  
        }

        public void EstornarMovimentoConsumoPacienteFaturado(MovimentacaoDTO dto)
        {
            entity.EstornarMovimentoConsumoPaciente(dto);
        }

        public bool PermitirEstornoConsumoItem(ref MovimentacaoDTO dto)
        {
            ContaConsumoItemDTO dtoContaConsumoItem = new ContaConsumoItemDTO();

            if (dto.SequenciaConsumoFaturamento.Value.IsNull) dto = entity.ObterSequenciaConsumoFaturamento(dto);
            if (!dto.SequenciaConsumoFaturamento.Value.IsNull)
            {
                dtoContaConsumoItem.IdtContaConsumoItem.Value = dto.SequenciaConsumoFaturamento.Value;
                return !(new EmissaoConta().ConsumoItemParcelaFaturada(dtoContaConsumoItem));
            }                

            return true;
        }

        /*
        /// <summary>
        /// Estorna o produto da movimentação do paciente e retorna a quantidade movimentada ao estoque
        /// que enviou ( Almox central ou Satélite )
        /// </summary>      
        public void EstornarMovimentoCentroCirurgico(MovimentacaoDTO dto)
        {
            entity.EstornarMovimentoCentroCirurgico(dto);
        }
        */

        /*
        /// <summary>
        /// Verifica se um mat/med pode ser incluído na conta do paciente         
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>true se o mat/med não pode ser incluído. Caso contrário, retorna false.</returns>
        public bool VerificarFaturamentoInc(MovimentacaoDTO dto)
        {
            return entity.VerificarFaturamentoInc(dto);
        }

        /// <summary>
        /// Verifica se um mat/med pode ser excluído da conta do paciente         
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>true se o mat/med não pode ser excluído. Caso contrário, retorna false.</returns>
        public bool VerificarFaturamentoExc(MovimentacaoDTO dto)
        {
            return entity.VerificarFaturamentoExc(dto);
        }
        */

        public bool PermiteConsumo(MovimentacaoDTO dto)
        {
            return true;
            //Comentado depois que desativou a interface com o legado, pois esta verificação era feita apenas nas tabelas do legado
            //return entity.PermiteConsumo(dto);
        }

        public MovimentacaoDataTable ListaMovimentacao(MovimentacaoDTO dto)
        {
            return entity.ListaMovimentacao(dto);
        }

        public bool TemParcelaFaturamento(decimal atendimento, DateTime? dtParcela)
        {
            return entity.TemParcelaFaturamento(atendimento, dtParcela);
        }

        public int ReprocessarContaFaturamentoMatMed(MovimentacaoDTO dto, bool duplicarFaturamento)
        {
            MovimentacaoDTO dtoMov;            
            MovimentacaoDataTable dtbMovFaturar = this.HistoricoConsumoPaciente(dto);
            MovimentacaoDataTable dtbMovFaturar2 = this.HistoricoEnvioFaturamentoPaciente(dto);
            foreach (DataRow row in dtbMovFaturar2.Rows)
            {
                dtbMovFaturar.Add((MovimentacaoDTO)row);
            }

            if (!duplicarFaturamento)
            {
                foreach (DataRow row in dtbMovFaturar.Rows)
                {
                    dtoMov = (MovimentacaoDTO)row;
                    if (!dtoMov.SequenciaConsumoFaturamento.Value.IsNull)
                    {
                        entity.RotinaExclusaoFaturamento((int)dtoMov.SequenciaConsumoFaturamento.Value);
                    }
                }
            }
            else
                entity.ExcluirAssFatMov(dto);

            return RegerarContaFaturamento(dto);
        }

        /// <summary>
        /// Reenvia itens p/ a geração da comanda de mat/med
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>retorna qtd. de itens gerados</returns>
        public int RegerarContaFaturamento(MovimentacaoDTO dto)
        {
            int retorno = 0;
            DateTime dataFat; string horaFat;
            CalculoProduto busCalculoProduto = new CalculoProduto();
            MaterialMedicamento busMatMed = new MaterialMedicamento();
            Paciente busPac = new Paciente();
            MovimentacaoDTO dtoMov;
            ContaConsumoItemDTO dtoContaConsumoItem;
            MaterialMedicamentoDTO dtoMatMed = new MaterialMedicamentoDTO();
            MovimentacaoDataTable dtbMovFaturar = this.HistoricoConsumoPaciente(dto);
            MovimentacaoDataTable dtbMovFaturar2 = this.HistoricoEnvioFaturamentoPaciente(dto);
            foreach (DataRow row in dtbMovFaturar2.Rows)
            {
                dtbMovFaturar.Add((MovimentacaoDTO)row);
            }
            foreach (DataRow row in dtbMovFaturar.Rows)
            {
                dtoMov = (MovimentacaoDTO)row;
                //Só executa, se não gerou faturamento no SGS ainda
                //if (dtoMov.SequenciaConsumoFaturamento.Value.IsNull && dtoMov.IdtSetor.Value.ToString() != "61")
                if (dtoMov.SequenciaConsumoFaturamento.Value.IsNull)
                {
                    if (dtoMov.DtFaturamento.Value.IsNull)
                    {
                        busPac.ObterDataHoraAlta(dto, out dataFat, out horaFat);
                        dtoMov.DtFaturamento.Value = dataFat;
                        dtoMov.HrFaturamento.Value = horaFat;
                    }                    

                    if (dtoMov.IdtSubTipo.Value == (byte)MovimentacaoDTO.SubTipoMovimento.MOVIMENTACAO_FRACIONADA ||
                        dtoMov.IdtSubTipo.Value == (byte)MovimentacaoDTO.SubTipoMovimento.MOVIMENTACAO_FRACIONADA_CARRINHO_EMERGENCIA ||
                        dtoMov.IdtSubTipo.Value == (byte)MovimentacaoDTO.SubTipoMovimento.BAIXA_FRACIONADA_NAO_FATURADA)
                    {
                        dtoMov.FlFracionado.Value = (byte)MaterialMedicamentoDTO.Fracionado.SIM;
                    }
                    else
                    {
                        dtoMov.FlFracionado.Value = (byte)MaterialMedicamentoDTO.Fracionado.NAO;
                    }

                    dtoMatMed.Idt.Value = dtoMov.IdtProduto.Value;
                    dtoMatMed = busMatMed.SelChave(dtoMatMed);

                    if (dtoMatMed.FlFracionado.Value.IsNull) dtoMatMed.FlFracionado.Value = (byte)MaterialMedicamentoDTO.Fracionado.NAO;
                    if (dtoMov.IdtSubTipo.Value == (byte)MovimentacaoDTO.SubTipoMovimento.INFO_ENVIO_FATURAMENTO && dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.SIM)
                    {                        
                        dtoMov.Qtde.Value = dtoMov.Qtde.Value / dtoMatMed.UnidadeVenda.Value;
                    }

                    try
                    {
                        //Execução da rotina de faturamento
                        dtoMov.IdtUsuario.Value = dto.IdtUsuario.Value;
                        dtoContaConsumoItem = busCalculoProduto.ProcessarFaturamentoMatMed(dtoMatMed, dtoMov);

                        if (!dtoContaConsumoItem.IdtContaConsumoItem.Value.IsNull)
                        {
                            dtoMov.SequenciaConsumoFaturamento.Value = dtoContaConsumoItem.IdtContaConsumoItem.Value;                            
                            if (dtoMov.IdtSetor.Value.ToString() == "61") //Centro cirúrgico
                            {
                                entity.ProcessarRotinaPosFaturamentoCCirurgico(dtoMov);
                            }
                            else
                            {
                                entity.ProcessarRotinaPosFaturamento(dtoMov);
                            } 
                            retorno += 1;
                        }
                        else
                        {
                            //throw new HacException(string.Format("Houve um erro não tratado referente ao faturamento. Contate algum administrador do sistema. Anote o Código do Movimento: ", dtoMovimento.Idt.Value.ToString()));
                            Log log = new Log();
                            log.Gravar("Houve um erro não tratado referente ao faturamento de mat/med, e não foi possível enviar o produto para fatura.", "GestaoMateriais/Faturamento", "GestaoMateriais.Control.Movimentacao", "RegerarContaFaturamento", dtoMov.IdtAtendimento.Value.ToString(), string.Empty, string.Empty, dtoMatMed.CodMne.Value, dto.IdtUsuario.Value);
                        }
                    }
                    catch (Exception ex)
                    {
                        Log log = new Log();
                        log.Gravar(ex.Message, "GestaoMateriais/Faturamento", "GestaoMateriais.Control.Movimentacao", "RegerarContaFaturamento", dtoMov.IdtAtendimento.Value.ToString(), string.Empty, string.Empty, dtoMatMed.CodMne.Value, dto.IdtUsuario.Value);
                    }
                }
            }
            return retorno;
        }

        public MovimentacaoDataTable HistoricoConsumoAtendimentosPeriodo(MovimentacaoDTO dto, decimal? idtConvenio)
        {
            return entity.HistoricoConsumoAtendimentosPeriodo(dto, idtConvenio);
        }

        public void SalvaMovimentoCentroCirurgico(MovimentacaoDTO dto)
        {
            //bool sgsFaturado = false; //QUANDO DESATIVAR O LEGADO, NAO PRECISARÁ MAIS DESTA VARIÁVEL

            DateTime dataFat; string horaFat;
            CalculoProduto busCalculoProduto = new CalculoProduto();
            MaterialMedicamento busMatMed = new MaterialMedicamento();
            Paciente busPac = new Paciente();
            MovimentacaoDTO dtoMov;
            ContaConsumoItemDTO dtoContaConsumoItem;
            MaterialMedicamentoDTO dtoMatMed = new MaterialMedicamentoDTO();
            MovimentacaoDataTable dtbMovFaturar = entity.ListaMovimentacaoCCirurgicoFaturar(dto);
            foreach (DataRow row in dtbMovFaturar.Rows)
            {
                dtoMov = (MovimentacaoDTO)row;
                //Só executa, se não gerou faturamento no SGS ainda (pois pode ter dado erro apenas no legado)
                if (dtoMov.SequenciaConsumoFaturamento.Value.IsNull)
                {
                    busPac.ObterDataHoraAlta(dto, out dataFat, out horaFat);
                    dtoMov.DtFaturamento.Value = dataFat;
                    dtoMov.HrFaturamento.Value = horaFat;

                    if (dtoMov.IdtSubTipo.Value == (byte)MovimentacaoDTO.SubTipoMovimento.BAIXA_FRACIONADA_NAO_FATURADA)
                    {
                        dtoMov.FlFracionado.Value = (byte)MaterialMedicamentoDTO.Fracionado.SIM;
                    }
                    else
                    {
                        dtoMov.FlFracionado.Value = (byte)MaterialMedicamentoDTO.Fracionado.NAO;
                    }

                    dtoMatMed.Idt.Value = dtoMov.IdtProduto.Value;
                    dtoMatMed = busMatMed.SelChave(dtoMatMed);

                    try
                    {
                        //Execução da rotina de faturamento
                        dtoMov.IdtUsuario.Value = dto.IdtUsuario.Value;
                        dtoContaConsumoItem = busCalculoProduto.ProcessarFaturamentoMatMed(dtoMatMed, dtoMov);

                        if (!dtoContaConsumoItem.IdtContaConsumoItem.Value.IsNull)
                        {
                            dtoMov.SequenciaConsumoFaturamento.Value = dtoContaConsumoItem.IdtContaConsumoItem.Value;
                            entity.ProcessarRotinaPosFaturamentoCCirurgico(dtoMov);
                            //sgsFaturado = true;
                        }
                        else
                        {
                            //throw new HacException(string.Format("Houve um erro não tratado referente ao faturamento. Contate algum administrador do sistema. Anote o Código do Movimento: ", dtoMovimento.Idt.Value.ToString()));
                            Log log = new Log();
                            log.Gravar("Houve um erro não tratado referente ao faturamento de mat/med, e não foi possível enviar o produto para fatura.", "GestaoMateriais/Faturamento", "GestaoMateriais.Control.Movimentacao", "SalvaMovimentoCentroCirurgico", dtoMov.IdtAtendimento.Value.ToString(), string.Empty, string.Empty, dtoMatMed.CodMne.Value, dto.IdtUsuario.Value);
                        }
                    }
                    catch (Exception ex)
                    {
                        //Não gravar log quando paciente estiver em pre-cadastro ou atendimento for cancelado
                        if (ex.Message.IndexOf("#pac_nao_encontrado") > -1)
                        {
                            throw new Exception(ex.Message.Replace("#pac_nao_encontrado", string.Empty));
                            break;
                        }

                        Log log = new Log();
                        log.Gravar(ex.Message, "GestaoMateriais/Faturamento", "GestaoMateriais.Control.Movimentacao", "SalvaMovimentoCentroCirurgico", dtoMov.IdtAtendimento.Value.ToString(), string.Empty, string.Empty, dtoMatMed.CodMne.Value, dto.IdtUsuario.Value);
                    }
                }
            }         

            #region Legado Desativado
            //========================================================================================================================
            //OBS. QUANDO DESATIVAR A CHAMADA DO LEGADO ABAIXO, DEVERÁ SER DESCOMENTADA ROTINA NA PROC 'PRC_MTMD_MOV_POS_FATURA_CCIR'
            //========================================================================================================================

            //Legado
            //try
            //{
            //    entity.SalvaMovimentoCentroCirurgico(dto);
            //}
            //catch (Exception ex)
            //{
            //    if (sgsFaturado)
            //    {
            //        Log log = new Log();
            //        log.Gravar("Houve erro no faturamento do Legado, porém no SGS teve itens faturados corretamente. Erro: " + ex.Message, "GestaoMateriais/Faturamento", "GestaoMateriais.Control.Movimentacao", "SalvaMovimentoCentroCirurgico", dto.IdtAtendimento.Value, string.Empty, string.Empty, string.Empty, dto.IdtUsuario.Value);
            //    }
            //    throw new Exception(ex.Message, ex);
            //}
            #endregion
        }

        public void EstornaDespesaCCusto(MovimentacaoDTO dto)
        {
            entity.EstornaDespesaCCusto(dto);
        }

        public MovimentacaoDataTable PendenciaCCirurgico(MovimentacaoDTO dto)
        {
            return entity.PendenciaCCirurgico(dto);
        }

        /// <summary>
        /// Verifica Consumo de Materiais e Medicamentos para o paciente.
        /// Nr. Atendimento ( Obrigatório )
        /// Unidade/Local?Setor ( Opcional )
        /// </summary>
        /// <param name="dto">MovimentacaoDTO</param>
        /// <returns>Boolean</returns>
        public bool VerificaConsumo(MovimentacaoDTO dto)
        {
            return entity.VerificaConsumo(dto);
        }

        ///// <summary>
        ///// Verifica Consumo de Materiais e Medicamentos para o paciente.
        ///// Nr. Atendimento ( Obrigatório )
        ///// </summary>
        ///// <param name="dto">MovimentacaoDTO</param>
        ///// <returns>Boolean</returns>
        //public bool VerificaConsumoCentroCirurgico(MovimentacaoDTO dto)
        //{
        //    return entity.VerificaConsumoCentroCirurgico(dto);
        //}

        public MovimentacaoDataTable HistoricoEnvioFaturamentoPaciente(MovimentacaoDTO dto)
        {
            return entity.HistoricoEnvioFaturamentoPaciente(dto);
        }

        /// <summary>
        /// Retorna Itens consumidos para o paciente
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>DataTable</returns>
        public MovimentacaoDataTable HistoricoConsumoPaciente(MovimentacaoDTO dto)
        {
            return entity.HistoricoConsumoPaciente(dto);
        }

        /// <summary>
        /// Retorna toda movimentação do produto no setor, parametros Obrigatórios:
        /// IdtProduto, IdtUnidade, IdtLocal, IdtSetor, IdtFilial, DtMovimetnacao
        /// DtMovimentacao é a data de inicio da pesquisa.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public MovimentacaoDataTable HistoricoProdutoSetor(MovimentacaoDTO dto)
        {
            return entity.HistoricoProdutoSetor(dto);
        }

        /// <summary>
        /// Realiza a Dispensação, Baixa e consumo para o paciente de Produtos para o Centro Cirurgico
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public MovimentacaoDTO DispensacaoKitCCirurgico(MovimentacaoDTO dtoMovimento, MaterialMedicamentoDTO dtoMatMed)
        {

            dtoMovimento = ConverteMatMedMovimento(dtoMatMed, dtoMovimento);
            dtoMovimento = entity.DispensacaoKitCCirurgico(dtoMovimento);

            return dtoMovimento;
            // return entity.DispensacaoKitCCirurgico(dto);
        }

        public void ImportaInventario(MovimentacaoDTO dto, int? idGrupo)
        {
            entity.ImportaInventario(dto, idGrupo);
        }

        public void ImportaInventarioMed(MovimentacaoDTO dto, int? idGrupo)
        {
            entity.ImportaInventarioMed(dto, idGrupo);
        }

        public void TransferirAtendimento(decimal idAtd_De, decimal idAtd_Para)
        {
            entity.TransferirAtendimento(idAtd_De, idAtd_Para);
        }

        public void GerarDadosRelatorioInfMatMed(byte mes, int ano, bool processarFechaEstoque, bool processarReceita, int idUsuario)
        {
            entity.GerarDadosRelatorioInfMatMed(mes, ano, processarFechaEstoque, processarReceita, idUsuario);
        }

        public void LiberarAtendimento(decimal atendimento, decimal status, decimal idUsuario)
        {
            entity.LiberarAtendimento(atendimento, status, idUsuario);
        }

        public void AtualizarAtendimentoLiberado(decimal atendimento, decimal status)
        {
            entity.AtualizarAtendimentoLiberado(atendimento, status);
        }

        public DataTable AtendimentosLiberados()
        {
            return entity.AtendimentosLiberados();
        }

        public DataTable ObterQtdProdutoBaixaPacSetor(MovimentacaoDTO dto, int idPrincipioAtivo)
        {
            return entity.ObterQtdProdutoBaixaPacSetor(dto, idPrincipioAtivo);
        }

        public DataTable ObterItensPendentesProtocolo(MovimentacaoDTO dto)
        {
            return entity.ObterItensPendentesProtocolo(dto);
        }

        public DataTable ObterProtocolosPaciente(MovimentacaoDTO dto, decimal? idProtocolo)
        {
            return entity.ObterProtocolosPaciente(dto, idProtocolo);
        }

        public int ObterNovoNumProtocolo()
        {
            DataTable dtb = entity.ObterUltimoProtocolo();
            if (dtb.Rows.Count > 0)
                return int.Parse(dtb.Rows[0][0].ToString()) + 1;
            else
                return 1;
        }

        public void AtualizarProtocolo(decimal idProtocolo, decimal idMovimento)
        {
            entity.AtualizarProtocolo(idProtocolo, idMovimento);
        }

        public void AtualizarKit(decimal idKit, decimal idMovimento)
        {
            entity.AtualizarKit(idKit, idMovimento);
        }

        public decimal ObterSaidasMensalSetor(MovimentacaoDTO dto)
        {
            return entity.ObterSaidasMensalSetor(dto);
        }

        public decimal ObterQtdLoteDispensado(MovimentacaoDTO dto)
        {
            return entity.ObterQtdLoteDispensado(dto);
        }

        public MovimentacaoDataTable RastrearLoteProduto(MovimentacaoDTO dto)
        {
            return entity.RastrearLoteProduto(dto);
        }

        public DataTable ObterEntradasCentroDispPedido(MovimentacaoDTO dto)
        {
            return entity.ObterEntradasCentroDispPedido(dto);
        }

        public MovimentacaoDataTable ObterCentroDispMovimentoPedido(MovimentacaoDTO dto)
        {
            return entity.ObterCentroDispMovimentoPedido(dto);
        }

        public decimal ObterIdMovimentoBaixaAutoDispensaPaciente(MovimentacaoDTO dto)
        {
            return entity.ObterIdMovimentoBaixaAutoDispensaPaciente(dto);
        }

        public decimal ObterIdMovimentoEnvioFaturamento(MovimentacaoDTO dto)
        {
            return entity.ObterIdMovimentoEnvioFaturamento(dto);
        }

        public KitDataTable ObterKitsConsumidosPaciente(MovimentacaoDTO dto)
        {
            return entity.ObterKitsConsumidosPaciente(dto);
        }

        public void MarcarEstornoMovimento(decimal idMovimento)
        {
            entity.MarcarEstornoMovimento(idMovimento);
        }

        public DataTable ObterSaidasCentroDispPedidoAnalitico(MovimentacaoDTO dto, bool blnUtiCompartilhada, bool blnFarmCentroCirurgico)
        {
            return entity.ObterSaidasCentroDispPedidoAnalitico(dto, blnUtiCompartilhada, blnFarmCentroCirurgico);
        }

        public DataTable ObterEntradasPedidoProduto(MovimentacaoDTO dto)
        {
            return entity.ObterEntradasPedidoProduto(dto);
        }

        public void AtualizarEmpresaEmprestimo(decimal idEmpresa, decimal idMovimento)
        {
            entity.AtualizarEmpresaEmprestimo(idEmpresa, idMovimento);
        }

        public System.Data.DataTable RelatorioConsumoGrupoMercado(string periodo)
        {
            return entity.RelatorioConsumoGrupoMercado(periodo);
        }

        public int ConverterQtdFracaoGotas(MovimentacaoDTO dto)
        {
            return entity.ConverterQtdFracaoGotas(dto);
        }

        public void TransferirEstoque(MovimentacaoDTO dto)
        {
            try
            {
                entity.TransferirEstoqueMedicamentos(dto);
            }
            catch (HacException ex)
            {
                throw new HacException("ERRO MEDICAMENTO: " + ex.Message);
            }

            try
            {
                entity.TransferirEstoqueMateriais(dto);
            }
            catch (HacException ex)
            {
                throw new HacException("ERRO MATERIAL: " + ex.Message);
            }
        }

        public bool ContaSalvaFaturamento(decimal atendimento)
        {
            return entity.ContaSalvaFaturamento(atendimento);
        }
    }
}