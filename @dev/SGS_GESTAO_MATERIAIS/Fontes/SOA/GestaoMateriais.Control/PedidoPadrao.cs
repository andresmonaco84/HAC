using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using System.Data;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
	public class PedidoPadrao : Control, IPedidoPadrao
	{
		private Model.PedidoPadrao entity = new Model.PedidoPadrao() ;

        /// <summary>
        /// Listar todos os registros
        /// </summary>
		public PedidoPadraoDataTable Sel(PedidoPadraoDTO dto)
		{	
			return entity.Sel(dto);
		}

        public PedidoPadraoDataTable GeraImpressaoPedidoPadrao(PedidoPadraoDTO dto)
        {
            return entity.GeraImpressaoPedidoPadrao(dto);
        }

        /// <summary>
        /// Obter pela chave
        /// </summary>
		public PedidoPadraoDTO SelChave(PedidoPadraoDTO dto)
		{	
			return entity.SelChave(dto);
		}
		
		/// <summary>
		/// Insere um registro
		/// </summary>
		public PedidoPadraoDTO Ins(PedidoPadraoDTO dto)
		{            
			entity.Ins(dto);
			return dto;
		}

        public void Gravar(PedidoPadraoDTO dto, PedidoPadraoItensDataTable dtb)
        {            
            try
            {
                // BeginTransaction();

                if (dto.Idt.Value.IsNull)
                {
                    dto = Ins(dto);
                }
                else
                {
                    Upd(dto);
                }

                PedidoPadraoItensDTO dtoItem;

                foreach (DataRow row in dtb.Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        dtoItem = (PedidoPadraoItensDTO)row;

                        dtoItem.Idt = dto.Idt;

                        if (row.RowState == DataRowState.Added)
                        {
                            this.InsItem(dtoItem);
                        }
                        if (row.RowState == DataRowState.Modified)
                        {
                            this.UpdItem(dtoItem);
                        }
                    }
                    else
                    {
                        if (!Convert.IsDBNull(row[PedidoPadraoItensDTO.FieldNames.Idt, DataRowVersion.Original]))
                        {
                            dtoItem = new PedidoPadraoItensDTO();

                            dtoItem.Idt.Value = Convert.ToInt64(row[PedidoPadraoItensDTO.FieldNames.Idt, DataRowVersion.Original]);
                            dtoItem.IdtProduto.Value = Convert.ToInt64(row[PedidoPadraoItensDTO.FieldNames.IdtProduto, DataRowVersion.Original]);
                            this.DelItem(dtoItem);
                        }                        
                    }
                }

                // CommitTransaction();
            }
            catch (Exception ex)
            {
                // RollbackTransaction();
                //throw new HacException(" Erro, foi realizado RollBack da transação ", ex);
                throw new HacException(ex.Message, ex);
            }            
        }

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Del(PedidoPadraoDTO dto)
		{
			entity.Del(dto);
		}
		
		/// <summary>
		/// Atualiza um registro
		/// </summary>		
		public void Upd(PedidoPadraoDTO dto)
		{            
			entity.Upd(dto);
		}

        /// <summary>
        /// Altera a data da última dispensação
        /// </summary>		
        public void UpdDataDispensacao(PedidoPadraoDTO dto)
        {
            entity.UpdDataDispensacao(dto);
        }

        /// <summary>
        /// Altera a data da última requisição referente a este pedido padrão
        /// </summary>		
        public void UpdDataUltRequisicao(PedidoPadraoDTO dto)
        {
            entity.UpdDataUltRequisicao(dto);
        }

        /// <summary>
        /// Converte dtoMatMed para dtoPedidoPadrao
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public PedidoPadraoItensDTO ConverteMatMedPedidoPadrao(MaterialMedicamentoDTO dto)
        {
            PedidoPadraoItensDTO dtoPedidoPadraoItens = new PedidoPadraoItensDTO();
            if (dto != null)
            {
                // ATENÇÃO SEMPRE USAR O NOME FANTASIA PARA DAR DISPLAY

                dtoPedidoPadraoItens.IdtProduto.Value = dto.Idt.Value;
                dtoPedidoPadraoItens.DsProduto.Value = dto.NomeFantasia.Value;
                dtoPedidoPadraoItens.IdtPrincipioAtivo.Value = dto.IdtPrincipioAtivo.Value;
            }
            return dtoPedidoPadraoItens;
        }

        public RequisicaoItensDataTable ConvertePadraoRequisicaoItens(PedidoPadraoItensDataTable dtb)
        {
            RequisicaoItensDataTable Itensdtb = new RequisicaoItensDataTable();
            foreach (DataRow row in dtb.Rows)
            {
                RequisicaoItensDTO dtoRequisicaoItens  = new RequisicaoItensDTO();
                PedidoPadraoItensDTO dtoPadraoItens = (PedidoPadraoItensDTO)row;
                dtoRequisicaoItens.IdtProduto.Value = dtoPadraoItens.IdtProduto.Value;
                
                if (dtoPadraoItens.EstoqueLocalQtde.Value.IsNull)
                {
                    dtoRequisicaoItens.QtdSolicitada.Value = dtoPadraoItens.Qtde.Value;
                }
                else
                {
                    if (this.VerificaPercentual(dtoPadraoItens))
                    {
                        dtoRequisicaoItens.QtdSolicitada.Value = dtoPadraoItens.Qtde.Value - dtoPadraoItens.EstoqueLocalQtde.Value;
                    }
                    else
                    {
                        dtoRequisicaoItens.QtdSolicitada.Value = 0;
                    }
                }
                if (decimal.Parse(dtoRequisicaoItens.QtdSolicitada.Value.ToString()) > 0) Itensdtb.Add(dtoRequisicaoItens);
            }
            return Itensdtb;
        }
        /*
        /// <summary>
        /// Gera requisições de Pedido Padrão.
        /// Se dispensarDireto = true, depois que gerar as requisições, já dispensa o produto para os respectivos destinos.
        /// </summary>
        /// <param name="dtb"></param>
        /// <param name="dispensarDireto"></param>
        public void GeraRequisicao(PedidoPadraoDataTable dtb, bool dispensarDireto)
        {
            PedidoPadraoDTO dtoPedPadrao;
            
            foreach (DataRow row in dtb.Rows)
            {
                dtoPedPadrao = (PedidoPadraoDTO)row;
                this.GeraRequisicao(dtoPedPadrao, this.SelItens(dtoPedPadrao), dispensarDireto);
            }
        }

        /// <summary>
        /// Gera requisições de Pedido Padrão.
        /// Se dispensarDireto = true, depois que gerar as requisições, já dispensa o produto para os respectivos destinos,
        /// pulando o processo de impressão.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="dtbPedPadraoItens"></param>
        /// <param name="dispensarDireto"></param>
        public void GeraRequisicao(PedidoPadraoDTO dto, PedidoPadraoItensDataTable dtbPedPadraoItens, bool dispensarDireto)
        {
            RequisicaoDTO dtoRequisicao = new RequisicaoDTO();
            Requisicao requisicao = new Requisicao();

            dtoRequisicao.IdtFilial.Value = dto.IdtFilial.Value;
            dtoRequisicao.IdtUnidade.Value = dto.IdtUnidade.Value;
            dtoRequisicao.IdtLocal.Value = dto.IdtLocal.Value;
            dtoRequisicao.IdtSetor.Value = dto.IdtSetor.Value;
            dtoRequisicao.IdtTipoRequisicao.Value = (int)RequisicaoDTO.TipoRequisicao.PADRAO;
            dtoRequisicao.Status.Value = (int)RequisicaoDTO.StatusRequisicao.FECHADA;
            dtoRequisicao.IdtUsuario.Value = dto.IdtUsuario.Value;

            RequisicaoItensDataTable dtbReqItens = this.ConvertePadraoRequisicaoItens(dtbPedPadraoItens);

            dtoRequisicao = requisicao.Gravar(dtoRequisicao, dtbReqItens);

            this.UpdDataUltRequisicao(dto);

            dtbReqItens.AcceptChanges();

            if (dispensarDireto) requisicao.Dispensar(dtoRequisicao, dtbReqItens);
        }
        */

        public void GeraRequisicao(PedidoPadraoDTO dto, string tabelaMedica, int? idSetorFarmacia)
        {
            entity.GeraRequisicao(dto, tabelaMedica, idSetorFarmacia);
        }

        /// <summary>
        /// Retorna itens do Pedido Padrão
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public PedidoPadraoItensDataTable SelItens(PedidoPadraoDTO dto)
        {
            return entity.SelItens(dto);
        }

        /// <summary>
        /// Retorna itens do Pedido Padrão
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public PedidoPadraoItensDataTable SelItens(PedidoPadraoItensDTO dto)
        {
            return entity.SelItens(dto);
        }

        ///<summary>
        /// Insere um item
        /// </summary>
        public PedidoPadraoItensDTO InsItem(PedidoPadraoItensDTO dto)
        {
            entity.InsItem(dto);
            return dto;
        }

        ///<summary>
        /// Apaga um item
        /// </summary>		
        public void DelItem(PedidoPadraoItensDTO dto)
        {
            entity.DelItem(dto);
        }

        ///<summary>
        /// Atualiza um item
        /// </summary>		
        public void UpdItem(PedidoPadraoItensDTO dto)
        {
            entity.UpdItem(dto);
        }

        /// <summary>
        /// Verifica se o produto pertence ao pedido padrao referente a filial e ao setor
        /// </summary>
        public bool ProdutoPadrao(PedidoPadraoDTO dtoPedidoPadrao, MaterialMedicamentoDTO dtoMatMed)
        {
            PedidoPadraoItensDTO dtoPedPadItem = null;
            return this.ProdutoPadrao(dtoPedidoPadrao, dtoMatMed, ref dtoPedPadItem, false);
        }

        /// <summary>
        /// Verifica se o produto pertence ao pedido padrao referente a filial e ao setor
        /// Se verificarPA = true, verifica também produto com o mesmo princípio ativo no pedido padrão 
        /// </summary>
        public bool ProdutoPadrao(PedidoPadraoDTO dtoPedidoPadrao, MaterialMedicamentoDTO dtoMatMed, bool verificarPA)
        {
            PedidoPadraoItensDTO dtoPedPadItem = null;
            return this.ProdutoPadrao(dtoPedidoPadrao, dtoMatMed, ref dtoPedPadItem, verificarPA);
        }

        /// <summary>
        /// Verifica se o produto pertence ao pedido padrao referente a filial e ao setor.
        /// Retorna por referência o dto do item, no caso deste método retornar true.
        /// Se verificarPA = true, verifica também produto com o mesmo princípio ativo no pedido padrão 
        /// </summary>
        public bool ProdutoPadrao(PedidoPadraoDTO dtoPedidoPadrao, MaterialMedicamentoDTO dtoMatMed, ref PedidoPadraoItensDTO dtoPedPadItem, bool verificarPA)
        {
            if (dtoPedidoPadrao.IdtFilial.Value != (byte)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA)
            {
                if (dtoMatMed.Tabelamedica.Value == ((int)MaterialMedicamentoDTO.TipoMatMed.MATERIAL).ToString() ||
                    dtoMatMed.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.SIM)
                {
                    //Sempre quando for material ou o produto for fracionado, a filial será HAC
                    dtoPedidoPadrao.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
                }
            }

            PedidoPadraoDataTable dtbPedidoPadrao = this.Sel(dtoPedidoPadrao);
            PedidoPadraoItensDataTable dtbPedidoPadraoItens;            

            if (dtbPedidoPadrao.Rows.Count > 0)
            {
                PedidoPadraoItensDTO dtoPedPadItemAux = new PedidoPadraoItensDTO();

                dtoPedidoPadrao = (PedidoPadraoDTO)dtbPedidoPadrao.Rows[0];
                dtoPedPadItemAux.Idt.Value = dtoPedidoPadrao.Idt.Value;

                if (verificarPA && dtoMatMed.IdtPrincipioAtivo.Value != 0)
                {
                    dtoPedPadItemAux.IdtPrincipioAtivo.Value = dtoMatMed.IdtPrincipioAtivo.Value;
                }
                else
                {                    
                    dtoPedPadItemAux.IdtProduto.Value = dtoMatMed.Idt.Value;                    
                }

                dtbPedidoPadraoItens = this.SelItens(dtoPedPadItemAux);

                if (dtbPedidoPadraoItens.Rows.Count > 0)
                {
                    dtoPedPadItem = dtbPedidoPadraoItens.TypedRow(0);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Caso o produto pertença ao pedido padrao referente a filial e ao setor, valida se existe um estoque mínimo
        /// para requisições personalizadas. Caso existir este estoque mínimo, não liberar o produto na hora da requisição. 
        /// </summary>        
        public bool LiberarProdutoPadraoReqPersonalizadaEstMin(PedidoPadraoDTO dtoPedidoPadrao, MaterialMedicamentoDTO dtoMatMed, ref PedidoPadraoItensDTO dtoPedPadItem)
        {
            if (this.ProdutoPadrao(dtoPedidoPadrao, dtoMatMed, ref dtoPedPadItem, false))
            {
                if (!dtoPedPadItem.PontoRessuprimento.Value.IsNull)
                {
                    decimal qtdPadrao = decimal.Parse(dtoPedPadItem.Qtde.Value);
                    decimal qtdEstoqueLocal = decimal.Parse(dtoPedPadItem.EstoqueLocalQtde.Value);
                    decimal percEstoqueMin = decimal.Parse(dtoPedPadItem.PontoRessuprimento.Value);
                    decimal percEstoqueLocal = (100 * qtdEstoqueLocal) / qtdPadrao;

                    if (percEstoqueMin <= percEstoqueLocal) return false;
                }                 
            }

            return true;
        }

        /// <summary>
        /// verifica percentual de consumo, se estiver igual ou menor que o indicado no pedido padrão deve ser reabastecido
        /// </summary>
        /// <param name="dtoPedPadItem"></param>
        /// <returns></returns>
        public bool VerificaPercentual(PedidoPadraoItensDTO dtoPedPadItem)
        {
            if (!dtoPedPadItem.PontoRessuprimento.Value.IsNull)
            {
                decimal qtdPadrao = decimal.Parse(dtoPedPadItem.Qtde.Value);
                decimal qtdEstoqueLocal = decimal.Parse(dtoPedPadItem.EstoqueLocalQtde.Value);
                decimal percEstoqueMin = decimal.Parse(dtoPedPadItem.PontoRessuprimento.Value);
                decimal percEstoqueLocal = (100 * qtdEstoqueLocal) / qtdPadrao;

                if (percEstoqueMin >= percEstoqueLocal) return true;
            }
            return false;
        }


        public PedidoPadraoItensDataTable ListarItemRessuprir(PedidoPadraoDTO dto)
        {
            return entity.ListarItemRessuprir(dto);
        }
	}
}