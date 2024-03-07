using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Seguranca.Forms;
using HospitalAnaCosta.SGS.Componentes;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmLiberacaoAlmox_old : FrmBase
    {
        public FrmLiberacaoAlmox_old()
        {
            InitializeComponent();
        }
        
        
        private const int _qtdMinimaMaterialParaDigitar = 20;

        #region OBJETOS SERVIÇO

        // Atendimento
        private HospitalAnaCosta.SGS.GestaoMateriais.DTO.PacienteDTO dtoAtendimento;
        private IPaciente _atendimento;
        private IPaciente Atendimento
        {
            get { return _atendimento != null ? _atendimento : _atendimento = (IPaciente)Global.Common.GetObject(typeof(IPaciente)); }
        }
        // Requisição
        private RequisicaoDTO dtoRequisicao;
        private IRequisicao _requisicao;
        private IRequisicao Requisicao
        {
            get { return _requisicao != null ? _requisicao : _requisicao = (IRequisicao)Global.Common.GetObject( typeof(IRequisicao)); }
        }

        // Itens Requisição
        private RequisicaoItensDTO dtoReqItem;
        private RequisicaoItensDataTable dtbReqItem;
        private RequisicaoItensDataTable dtbReqItemDispensado;
        private IRequisicaoItens _ReqItem;
        private IRequisicaoItens ReqItem
        {
            get { return _ReqItem != null ? _ReqItem : _ReqItem = (IRequisicaoItens)Global.Common.GetObject( typeof(IRequisicaoItens)); }
        }

        // MatMed
        private MaterialMedicamentoDTO dtoMatMed;
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject( typeof(IMaterialMedicamento)); }
        }

        // Estoque        
        private IEstoqueLocal _estoque;
        private IEstoqueLocal Estoque
        {
            get { return _estoque != null ? _estoque : _estoque = (IEstoqueLocal)Global.Common.GetObject( typeof(IEstoqueLocal)); }
        }

        // Movimentos        
        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject( typeof(IMovimentacao)); }
        }

        #endregion

        #region FUNÇÕES

        private void ConfiguraItensDTG()
        {
            dtgMatMed.AutoGenerateColumns = false;
            dtgMatMed.Columns["colReqItemIdt"].DataPropertyName = RequisicaoItensDTO.FieldNames.Idt;
            dtgMatMed.Columns["colMatMedIdt"].DataPropertyName = RequisicaoItensDTO.FieldNames.IdtProduto;
            dtgMatMed.Columns["colDsProd"].DataPropertyName = RequisicaoItensDTO.FieldNames.DsProduto;
            dtgMatMed.Columns["colDsUnidadeVenda"].DataPropertyName = RequisicaoItensDTO.FieldNames.DsUnidadeVenda;
            dtgMatMed.Columns["colUnidadeMedidaItem"].DataPropertyName = RequisicaoItensDTO.FieldNames.UnidadeCompra;
            dtgMatMed.Columns["colQtde"].DataPropertyName = RequisicaoItensDTO.FieldNames.QtdSolicitada;
            dtgMatMed.Columns["colQtde"].DefaultCellStyle.Format = "N0";
            dtgMatMed.Columns["colQtdeFornecida"].DataPropertyName = RequisicaoItensDTO.FieldNames.QtdFornecida;
            dtgMatMed.Columns["colQtdeFornecida"].DefaultCellStyle.Format = "N0";
            dtgMatMed.Columns["colQtdePadrao"].DataPropertyName = RequisicaoItensDTO.FieldNames.QtdePadrao;
            dtgMatMed.Columns["colQtdePadrao"].DefaultCellStyle.Format = "N0";
            dtgMatMed.Columns["colEstoqueLocal"].DataPropertyName = RequisicaoItensDTO.FieldNames.EstoqueLocalQtde;
            dtgMatMed.Columns["colEstoqueLocal"].DefaultCellStyle.Format = "N0";
            dtgMatMed.Columns["colQtdCentDisp"].DataPropertyName = RequisicaoItensDTO.FieldNames.EstoqueCentDispQtde;
            dtgMatMed.Columns["colQtdCentDisp"].DefaultCellStyle.Format = "N0";
        }

        private EstoqueLocalDTO PopularQtdsEstoqueDTO(bool centroDispReq)
        {
            EstoqueLocalDTO dtoEstoque = new EstoqueLocalDTO();

            if (centroDispReq)
            {
                MovimentacaoDTO dtoMovimento = new MovimentacaoDTO();
                dtoMovimento.IdtSetor.Value = dtoRequisicao.IdtSetor.Value;
                // dtoMovimento = Movimento.CentroDispensacao(dtoMovimento);

                dtoEstoque.IdtUnidade.Value = dtoMovimento.IdtUnidadeBaixa.Value;
                dtoEstoque.IdtLocal.Value = dtoMovimento.IdtLocalBaixa.Value;
                dtoEstoque.IdtSetor.Value = dtoMovimento.IdtSetorBaixa.Value;
            }
            else
            {
                dtoEstoque.IdtUnidade.Value = dtoRequisicao.IdtUnidade.Value;
                dtoEstoque.IdtLocal.Value = dtoRequisicao.IdtLocal.Value;
                dtoEstoque.IdtSetor.Value = dtoRequisicao.IdtSetor.Value;
            }

            dtoEstoque.IdtFilial.Value = dtoRequisicao.IdtFilial.Value;
            dtoEstoque.IdtProduto.Value = dtoMatMed.Idt.Value;

            dtoEstoque = Estoque.EstoqueLocalProduto(dtoEstoque);

            return dtoEstoque;
        }

        private bool ValidarDispensada()
        {
            RequisicaoDTO dtoRequisicaoAux = new RequisicaoDTO();

            dtoRequisicaoAux.Idt.Value = dtoRequisicao.Idt.Value;
            dtoRequisicaoAux = Requisicao.SelChave(dtoRequisicaoAux);

            if (dtoRequisicaoAux.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX ||
                dtoRequisicaoAux.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.RECEBIDA_UNIDADE)
            {
                MessageBox.Show("Esta requisição já foi dispensada por outro processo", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.ZerarObjetos();
                tsHac.Controla(Evento.eCancelar);
                return false;
            }
            return true;
        }

        private void AdicionarItemDispensa()
        {
            if (!ValidarDispensada()) return;
            CodigoBarraDTO dtoCodigoBarra = new CodigoBarraDTO();

            dtoCodigoBarra.CdBarra.Value = txtIdProduto.Text;
            dtoCodigoBarra.IdtFilial.Value = dtoRequisicao.IdtFilial.Value;
            // BUSCA TODAS AS INFORMAÇÕES DO PRODUTO PELO CODIGO DE BARRA
            dtoMatMed = MatMed.BuscaCodigoBarra(dtoCodigoBarra);

            txtIdProduto.Text = string.Empty;
            txtIdProduto.Focus();

            if (dtoMatMed == null)
            {
                MessageBox.Show("Material/medicamento não identificado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string filtroMatMed = string.Format("{0} = {1}", RequisicaoItensDTO.FieldNames.IdtProduto, dtoMatMed.Idt.Value);
            string filtroMatMedPA = string.Format("{0} = {1}", RequisicaoItensDTO.FieldNames.IdtPrincipioAtivo, dtoMatMed.IdtPrincipioAtivo.Value);
            DataRow[] rowsReqItem = dtbReqItem.Select(filtroMatMed);
            DataRow[] rowsReqItemPA = dtbReqItem.Select(filtroMatMedPA);
            bool similar = false; //similar a algum medicamento da requisição ou não quando TipoRequisicao = PADRAO
            EstoqueLocalDTO dtoEstoque;

            if (dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.PADRAO ||
                dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.PERSONALISADA)
            {
                if (rowsReqItem.Length == 0 && dtoMatMed.IdtPrincipioAtivo.Value != 0)
                {                    
                    //Se tem 1 ou mais registros com este princípio ativo, e caiu nesta condição, é porque ele é um similar 
                    //não existente nesta requisição e está liberado para ser adicionado nela
                    if (rowsReqItemPA.Length >= 1)
                    {
                        if (dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.PERSONALISADA &&
                            rowsReqItemPA.Length == 2)
                        {
                            MessageBox.Show("Já tem um similar a este item adicionado nesta dispensa", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        similar = true;

                        RequisicaoItensDTO dtoItemSimilarOriginal = (RequisicaoItensDTO)rowsReqItemPA[0];
                        RequisicaoItensDTO dtoItemSimilarAdicionar = new RequisicaoItensDTO();

                        dtoItemSimilarAdicionar.Idt.Value = dtoRequisicao.Idt.Value;
                        dtoItemSimilarAdicionar.IdtProduto.Value = dtoMatMed.Idt.Value;
                        dtoItemSimilarAdicionar.IdtPrincipioAtivo.Value = dtoMatMed.IdtPrincipioAtivo.Value;
                        dtoItemSimilarAdicionar.UnidadeCompra.Value = dtoMatMed.UnidadeCompra.Value;
                        dtoItemSimilarAdicionar.UnidadeVenda.Value = dtoMatMed.UnidadeVenda.Value;
                        dtoItemSimilarAdicionar.UnidadeControle.Value = dtoMatMed.UnidadeControle.Value;
                        dtoItemSimilarAdicionar.DsProduto.Value = dtoMatMed.NomeFantasia.Value;
                        dtoItemSimilarAdicionar.DsUnidadeVenda.Value = dtoMatMed.DsUnidadeVenda.Value;
                        dtoItemSimilarAdicionar.QtdSolicitada.Value = dtoItemSimilarOriginal.QtdSolicitada.Value;
                        dtoItemSimilarAdicionar.QtdePadrao.Value = dtoItemSimilarOriginal.QtdePadrao.Value;

                        dtoEstoque = PopularQtdsEstoqueDTO(true);

                        if (dtoEstoque.Qtde.Value.IsNull) dtoEstoque.Qtde.Value = 0;
                        dtoItemSimilarAdicionar.EstoqueCentDispQtde.Value = dtoEstoque.Qtde.Value;

                        if (dtoItemSimilarAdicionar.EstoqueCentDispQtde.Value == 0)
                        {
                            MessageBox.Show("Produto similar com qtd. insuficiente no centro de dispensação", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        dtoEstoque = PopularQtdsEstoqueDTO(false);

                        if (dtoEstoque.Qtde.Value.IsNull) dtoEstoque.Qtde.Value = 0;
                        dtoItemSimilarAdicionar.EstoqueLocalQtde.Value = dtoEstoque.Qtde.Value;

                        //Inserir item similar na requisição
                        dtbReqItem.Add(dtoItemSimilarAdicionar);
                        dtbReqItem.AcceptChanges();
                        //Insere no banco item similar
                        dtoItemSimilarAdicionar.QtdFornecida.Value = 1;
                        ReqItem.Ins(dtoItemSimilarAdicionar);

                        //Se não há estoque do item original e há estoque suficiente do seu similar, exclui o original da requisição
                        //if (dtoItemSimilarOriginal.EstoqueCentDispQtde.Value == 0 && 
                        //    dtoItemSimilarAdicionar.EstoqueCentDispQtde.Value > dtoItemSimilarOriginal.QtdSolicitada.Value)
                        //{
                        //    rowsReqItemPA[0].Delete();
                        //}

                        //Atualiza variável já com o novo registro adicionado
                        rowsReqItem = dtbReqItem.Select(filtroMatMed);
                    }
                }
            }

            if (!similar && rowsReqItem.Length == 0)
            {
                MessageBox.Show("Material/medicamento não existente nesta requisição", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dtbReqItemDispensado == null) dtbReqItemDispensado = new RequisicaoItensDataTable();

            DataRow[] rowsReqItemDispensado = dtbReqItemDispensado.Select(filtroMatMed);
            int qtdForn = 0;

            //Atualiza itens já dispensados listados no grid
            if (rowsReqItemDispensado.Length == 0)
            {
                dtoReqItem = (RequisicaoItensDTO)rowsReqItem[0];

                if (dtoMatMed.Tabelamedica.Value == ((int)MaterialMedicamentoDTO.TipoMatMed.MATERIAL).ToString() &&
                    dtoReqItem.QtdSolicitada.Value > _qtdMinimaMaterialParaDigitar)
                {
                    qtdForn = DigitarQtde();
                }
                else
                {
                    qtdForn = 1;
                }

                //Atualiza qtd. do estoque do centro de dispensação do item
                dtoEstoque = PopularQtdsEstoqueDTO(true);

                if (dtoEstoque.Qtde.Value.IsNull) dtoEstoque.Qtde.Value = 0;
                dtoReqItem.EstoqueCentDispQtde.Value = dtoEstoque.Qtde.Value;
                rowsReqItem[0][RequisicaoItensDTO.FieldNames.EstoqueCentDispQtde] = dtoEstoque.Qtde.Value;

                //Atualiza qtd. local do item
                dtoEstoque = PopularQtdsEstoqueDTO(false);

                if (dtoEstoque.Qtde.Value.IsNull) dtoEstoque.Qtde.Value = 0;
                dtoReqItem.EstoqueLocalQtde.Value = dtoEstoque.Qtde.Value;
                rowsReqItem[0][RequisicaoItensDTO.FieldNames.EstoqueLocalQtde] = dtoEstoque.Qtde.Value;
            }
            else
            {
                dtoReqItem = (RequisicaoItensDTO)rowsReqItemDispensado[0];
                qtdForn = int.Parse(rowsReqItemDispensado[0][RequisicaoItensDTO.FieldNames.QtdFornecida].ToString());

                if (dtoMatMed.Tabelamedica.Value == ((int)MaterialMedicamentoDTO.TipoMatMed.MATERIAL).ToString() &&
                    dtoReqItem.QtdSolicitada.Value > _qtdMinimaMaterialParaDigitar)
                {
                    qtdForn = qtdForn + DigitarQtde();
                }
                else
                {
                    qtdForn += 1;
                }

                //Atualiza qtd. do estoque do centro de dispensação do item
                dtoEstoque = PopularQtdsEstoqueDTO(true);

                if (dtoEstoque.Qtde.Value.IsNull) dtoEstoque.Qtde.Value = 0;
                dtoReqItem.EstoqueCentDispQtde.Value = dtoEstoque.Qtde.Value;
                rowsReqItem[0][RequisicaoItensDTO.FieldNames.EstoqueCentDispQtde] = dtoEstoque.Qtde.Value;
                rowsReqItemDispensado[0][RequisicaoItensDTO.FieldNames.EstoqueCentDispQtde] = dtoEstoque.Qtde.Value;

                //Atualiza qtd. local do item
                dtoEstoque = PopularQtdsEstoqueDTO(false);

                if (dtoEstoque.Qtde.Value.IsNull) dtoEstoque.Qtde.Value = 0;
                dtoReqItem.EstoqueLocalQtde.Value = dtoEstoque.Qtde.Value;
                rowsReqItem[0][RequisicaoItensDTO.FieldNames.EstoqueLocalQtde] = dtoEstoque.Qtde.Value;
                rowsReqItemDispensado[0][RequisicaoItensDTO.FieldNames.EstoqueLocalQtde] = dtoEstoque.Qtde.Value;
            }

            if (qtdForn == 0) return;

            if (qtdForn > dtoReqItem.QtdSolicitada.Value)
            {
                MessageBox.Show("Produto não liberado para a dispensação, pois a Qtd. Fornecida não pode ser maior que a Qtd. Requisitada", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.PADRAO)
            {
                if (dtoReqItem.QtdePadrao.Value.IsNull)
                {
                    RequisicaoItensDTO dtoItemPA;
                    //Item similar que não consta no pedido padrão, e está com valores vindos do banco (ou seja, é a primeira vez que está passando este item)
                    foreach (DataRow row in rowsReqItemPA)
                    {
                        dtoItemPA = (RequisicaoItensDTO)row;
                        if (dtoItemPA.IdtProduto.Value.ToString() != dtoReqItem.IdtProduto.Value.ToString())
                        {
                            dtoReqItem.QtdePadrao.Value = dtoItemPA.QtdePadrao.Value;
                            break;
                        }
                    }
                }

                if ((qtdForn + (int)dtoReqItem.EstoqueLocalQtde.Value) > (int)dtoReqItem.QtdePadrao.Value)
                {
                    MessageBox.Show("Produto não liberado para a dispensação, pois a soma da Qtd. Fornecida com a Qtd. Local não pode ultrapassar a Qtd. Padrão do Setor", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    if (dtoReqItem.IdtPrincipioAtivo.Value != 0)
                    {
                        //Quando tiver similares, validar qtd solicitada e qtd padrão de todos eles
                        if (rowsReqItemPA.Length > 1)
                        {
                            int qtdTotalFornedida = 0;

                            foreach (DataRow row in rowsReqItemPA)
                            {
                                qtdTotalFornedida += ((int)((RequisicaoItensDTO)row).QtdFornecida.Value);
                            }

                            if (qtdTotalFornedida == (int)dtoReqItem.QtdSolicitada.Value)
                            {
                                MessageBox.Show("Produto não liberado para a dispensação, pois a soma de Qtd. Fornecida com os seus similares não pode ser maior que a Qtd. Requisitada", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                            if (qtdTotalFornedida == (int)dtoReqItem.QtdePadrao.Value)
                            {
                                MessageBox.Show("Produto não liberado para a dispensação, pois a soma de Qtd. Fornecida com os seus similares não pode ultrapassar a Qtd. Padrão do Setor", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                    }                    
                }
            }
            else if (dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.PERSONALISADA)
            {
                if (dtoReqItem.IdtPrincipioAtivo.Value != 0)
                {
                    //Quando tiver similares, validar qtd solicitada de todos eles
                    if (rowsReqItemPA.Length > 1)
                    {
                        int qtdTotalFornedida = 0;

                        foreach (DataRow row in rowsReqItemPA)
                        {
                            qtdTotalFornedida += ((int)((RequisicaoItensDTO)row).QtdFornecida.Value);
                        }

                        if (qtdTotalFornedida == (int)dtoReqItem.QtdSolicitada.Value)
                        {
                            MessageBox.Show("Produto não liberado para a dispensação, pois a soma de Qtd. Fornecida com os seus similares não pode ser maior que a Qtd. Requisitada", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    } 
                }                               
            }

            DataRow rowDisp;
            // Atualiza Qtd. Fornecida do grid, e coloca o item como 1° da lista
            if (rowsReqItemDispensado.Length == 0)
            {
                dtoReqItem.QtdFornecida.Value = qtdForn;

                rowDisp = dtbReqItemDispensado.NewRow();

                for (int index = 0; index <= ((DataRow)dtoReqItem).ItemArray.Length - 1; index++)
                {
                    rowDisp[index] = ((DataRow)dtoReqItem)[index];
                }
            }
            else
            {
                rowsReqItemDispensado[0][RequisicaoItensDTO.FieldNames.QtdFornecida] = qtdForn;

                rowDisp = dtbReqItemDispensado.NewRow();

                for (int index = 0; index <= rowsReqItemDispensado[0].ItemArray.Length - 1; index++)
                {
                    rowDisp[index] = rowsReqItemDispensado[0][index];
                }

                // Remove item para forçar recolocação dele como 1° da lista
                dtbReqItemDispensado.Rows.Remove(rowsReqItemDispensado[0]);
            }

            dtbReqItemDispensado.Rows.InsertAt(rowDisp, 0);
            dtgMatMed.DataSource = dtbReqItemDispensado;

            // Atualiza a Qtd. Fornecida de todos os itens da requisição que está em memória e será enviada ao salvar a dispensação
            rowsReqItem[0][RequisicaoItensDTO.FieldNames.QtdFornecida] = qtdForn;

            if (dtoReqItem.EstoqueCentDispQtde.Value < qtdForn)
            {
                MessageBox.Show("Qtd. insuficiente no centro de dispensação. Se este processo for salvo, será gerada uma requisição pendente ", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            dtbReqItem.AcceptChanges();
            dtbReqItemDispensado.AcceptChanges();

            //Atualiza Qtd. No banco
            dtoReqItem.QtdFornecida.Value = qtdForn;
            ReqItem.Upd(dtoReqItem);
            
            dtgMatMed.Rows[0].DefaultCellStyle.BackColor = Color.Yellow;            
        }

        private int DigitarQtde()
        {
            MovimentacaoDTO dtoMov = new MovimentacaoDTO();

            dtoMov.DsProduto.Value = dtoReqItem.DsProduto.Value;
            dtoMov.EstoqueLocal.Value = dtoReqItem.EstoqueLocalQtde.Value;

            dtoMov = FrmQtdMatMed.DigitaQtde(dtoMov);

            if (dtoMov == null) dtoMov = new MovimentacaoDTO();
            if (dtoMov.Qtde.Value.IsNull) dtoMov.Qtde.Value = 0;

            return (int)dtoMov.Qtde.Value;
        }

        private void CarregarRequisicao()
        {
            dtoRequisicao = new RequisicaoDTO();

            dtoRequisicao.Idt.Value = this.ObterReqIdCodBarra();
            dtoRequisicao = Requisicao.SelChave(dtoRequisicao);

            if (dtoRequisicao.Idt.Value.IsNull)
            {
                MessageBox.Show("Requisição não identificada", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdRequisicao.Text = string.Empty;
                txtIdRequisicao.Focus();
                return;
            }

            if (dtoRequisicao.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX ||
                dtoRequisicao.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.RECEBIDA_UNIDADE)
            {
                MessageBox.Show("Esta requisição já foi dispensada", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdRequisicao.Text = string.Empty;
                txtIdRequisicao.Focus();
                return;
            }
            else if (dtoRequisicao.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.CANCELADA)
            {
                MessageBox.Show("Esta requisição foi cancelada", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdRequisicao.Text = string.Empty;
                txtIdRequisicao.Focus();
                return;
            }
            else if (dtoRequisicao.Status.Value != (byte)RequisicaoDTO.StatusRequisicao.IMPRESSO)
            {
                MessageBox.Show("Esta requisição não está liberada para a dispensação, pois ainda não foi impressa", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdRequisicao.Text = string.Empty;
                txtIdRequisicao.Focus();
                return;
            }

            if (dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.PERSONALISADA)
            {
                dtoAtendimento = new HospitalAnaCosta.SGS.GestaoMateriais.DTO.PacienteDTO();
                dtoAtendimento.IdtUnidade = dtoRequisicao.IdtUnidade;
                dtoAtendimento.IdtLocalAtendimento = dtoRequisicao.IdtLocal;
                dtoAtendimento.IdtSetor = dtoRequisicao.IdtSetor;
                dtoAtendimento.Idt = dtoRequisicao.IdtAtendimento;
                //Verifica se o paciente ainda está internado para poder liberar o mat/med
                if (Atendimento.Sel(dtoAtendimento).Rows.Count == 0)
                {
                    dtoRequisicao.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.CANCELADA;
                    Requisicao.Upd(dtoRequisicao);
                    MessageBox.Show("Esta requisição personalizada foi cancelada, pois o paciente já teve alta", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtIdRequisicao.Text = string.Empty;
                    txtIdRequisicao.Focus();
                    return;
                }
            }

            //Carrega todos os itens da requisição em memória, os quais serão enviados na hora de salvar a dispensação
            dtoReqItem = new RequisicaoItensDTO();
            dtoReqItem.Idt = dtoRequisicao.Idt;
            dtbReqItem = ReqItem.SelItensRequisicao(dtoReqItem, true);

            dtbReqItemDispensado = ReqItem.SelItensRequisicao(dtoReqItem, false);

            RequisicaoItensDTO dtoItemAux, dtoItemPA;
            string filtroMatMedPA;
            DataRow[] rowsReqItemPA;
            for (int nCount = 0; nCount < dtbReqItemDispensado.Rows.Count; nCount++)
            {
                dtoItemAux = (RequisicaoItensDTO)dtbReqItemDispensado.Rows[nCount];
                if (long.Parse(dtoItemAux.QtdFornecida.Value.ToString()) == 0)
                {
                    //Deleta porque só mostra na tela itens que já possui qtd. fornecida
                    dtbReqItemDispensado.Rows[nCount].Delete();

                    //Zera a qtd. fornecida deste item que será atualizada de acordo com que o usuário for passando o cod. de barra do produto a dispensar
                    dtbReqItem.Rows[nCount][RequisicaoItensDTO.FieldNames.QtdFornecida] = 0;
                }
                else
                {   //Iguala a qtd. fornecida deste item que será atualizada de acordo com que o usuário for passando o cod. de barra do produto a dispensar
                    dtbReqItem.Rows[nCount][RequisicaoItensDTO.FieldNames.QtdFornecida] = dtoItemAux.QtdFornecida.Value;

                    if (dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.PADRAO ||
                        dtoRequisicao.IdtTipoRequisicao.Value == (byte)RequisicaoDTO.TipoRequisicao.PERSONALISADA)
                    {
                        if (dtoItemAux.QtdePadrao.Value.IsNull)
                        {
                            filtroMatMedPA = string.Format("{0} = {1}", RequisicaoItensDTO.FieldNames.IdtPrincipioAtivo, dtoItemAux.IdtPrincipioAtivo.Value);
                            rowsReqItemPA = dtbReqItem.Select(filtroMatMedPA);

                            //Item similar que não consta no pedido padrão, e está com valores vindos do banco
                            foreach (DataRow row in rowsReqItemPA)
                            {
                                dtoItemPA = (RequisicaoItensDTO)row;
                                if (dtoItemPA.IdtProduto.Value.ToString() != dtoItemAux.IdtProduto.Value.ToString())
                                {
                                    dtbReqItemDispensado.Rows[nCount][RequisicaoItensDTO.FieldNames.QtdePadrao] = dtoItemPA.QtdePadrao.Value;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            dtbReqItem.AcceptChanges();
            dtbReqItemDispensado.AcceptChanges();
            dtgMatMed.DataSource = dtbReqItemDispensado;
                        
            this.PreencherTipoRequisicao();
            txtFilial.Text = dtoRequisicao.IdtFilial.Value == (byte)FilialMatMedDTO.Filial.ACS ? "ACS" : "HAC";
            if (!dtoRequisicao.DataRequisicao.Value.IsNull) txtData.Text = ((DateTime)dtoRequisicao.DataRequisicao.Value).ToString("dd/MM/yyyy à\\s HH:mm:ss");
            txtUnidade.Text = dtoRequisicao.DsUnidade.Value;
            txtLocal.Text = dtoRequisicao.DsLocal.Value;
            txtSetor.Text = dtoRequisicao.DsSetor.Value;

            tsHac.Controla(Evento.eEditar);
            txtIdRequisicao.Text = dtoRequisicao.Idt.Value;
            txtIdRequisicao.Enabled = false;
            txtIdProduto.Enabled = true;
            txtIdProduto.Focus();
        }

        /// <summary>
        /// Retira o último caractere que é apenas de controle na geração do cod. de barra
        /// </summary>
        /// <returns></returns>
        private long ObterReqIdCodBarra()
        {
            if (txtIdRequisicao.Text.Length <= 1) return 0;
            return long.Parse(txtIdRequisicao.Text.Substring(0, txtIdRequisicao.Text.Length - 1));
        }

        private void ZerarObjetos()
        {
            dtgMatMed.DataSource = null;
            dtbReqItem = null;
            dtbReqItemDispensado = null;
            dtoRequisicao = null;
            dtoReqItem = null;
            dtoMatMed = null;
            dtoAtendimento = null;
            txtIdProduto.Enabled = false;
        }

        private void PreencherTipoRequisicao()
        {
            switch ((byte)dtoRequisicao.IdtTipoRequisicao.Value)
            {
                case (byte)RequisicaoDTO.TipoRequisicao.PERSONALISADA:
                    txtTipo.Text = "PERSONALIZADA";
                    break;
                case (byte)RequisicaoDTO.TipoRequisicao.PADRAO:
                    txtTipo.Text = "PADRÃO";
                    break;
                case (byte)RequisicaoDTO.TipoRequisicao.AVULSO:
                    txtTipo.Text = "IMPRESSOS E MAT. DE EXPEDIENTE";
                    break;
                case (byte)RequisicaoDTO.TipoRequisicao.CARRINHO_EMERGENCIA:
                    txtTipo.Text = "CARRINHO DE EMERGÊNCIA";
                    break;
            }
        }

        private void Imprimir()
        {
            this.Cursor = Cursors.WaitCursor;

            dtoRequisicao = new RequisicaoDTO();

            dtoRequisicao.Idt.Value = txtReqNum.Text;

            try
            {
                Impressao.ImpBematech imp = new HospitalAnaCosta.SGS.GestaoMateriais.Impressao.ImpBematech();
                RequisicaoDataTable dtbRequisicao = Requisicao.Sel(dtoRequisicao);

                if (dtbRequisicao.Rows.Count > 0)
                {
                    dtoRequisicao = dtbRequisicao.TypedRow(0);

                    if (dtoRequisicao.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX ||
                        dtoRequisicao.Status.Value == (byte)RequisicaoDTO.StatusRequisicao.RECEBIDA_UNIDADE)
                    {
                        imp.ImprimirRequisicao(dtoRequisicao, true);

                        MessageBox.Show("Processo finalizado com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Pedido não pode ser impresso, pois ainda não foi dispensado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Pedido não encontrado para ser impresso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
        }

        #endregion

        #region EVENTOS

        private void FrmLiberacaoAlmox_Load(object sender, EventArgs e)
        {
            this.ConfiguraItensDTG();
        }

        private bool tsHac_SalvarClick(object sender)
        {
            if (MessageBox.Show("Deseja realmente dispensar os itens listados ?",
                                "Gestão de Materiais e Medicamentos",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (!ValidarDispensada()) return false;
                    FrmPrincipal.dtoSeguranca = FrmLogin.Logar(true);
                    if (FrmPrincipal.dtoSeguranca != null)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        dtoRequisicao.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.DISPENSADA_ALMOX;
                        dtoRequisicao.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                        dtoRequisicao = Requisicao.Gravar(dtoRequisicao, dtbReqItem);
                        //this.ZerarObjetos();
                        txtIdProduto.Enabled = false;
                        MessageBox.Show("Requisição dispensada com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        txtIdProduto.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
            return false;
        }

        private bool tsHac_NovoClick(object sender)
        {
            tsHac.Controla(Evento.eNovo);
            this.ZerarObjetos();
            txtIdRequisicao.Focus();
            return false;
        }

        private bool tsHac_CancelarClick(object sender)
        {
            this.ZerarObjetos();
            return true;
        }

        private void txtIdRequisicao_Validating(object sender, CancelEventArgs e)
        {
            if (txtIdRequisicao.Text != string.Empty)
            {
                this.Cursor = Cursors.WaitCursor;
                this.CarregarRequisicao();
                this.Cursor = Cursors.Default;
            } 
        }

        private void txtIdProduto_Validating(object sender, CancelEventArgs e)
        {
            if (dtbReqItem != null && txtIdProduto.Text != string.Empty)
            {
                this.Cursor = Cursors.WaitCursor;
                this.AdicionarItemDispensa();
                this.Cursor = Cursors.Default;
            }                
        }

        private void btnImpReqNum_Click(object sender, EventArgs e)
        {
            if (txtReqNum.Text == string.Empty)
            {
                MessageBox.Show("N° Pedido deve ser preenchido", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtReqNum.Focus();
                return;
            }
            if (MessageBox.Show(string.Format("Deseja realmente imprimir o Pedido N° {0} ?", txtReqNum.Text), "Gestão de Materiais e Medicamentos",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Imprimir();
            }
        }

        private void dtgMatMed_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgMatMed.Columns[e.ColumnIndex].Name == "colDeletar")
            {
                if (MessageBox.Show("Deseja deletar este item da lista de dispensa ?",
                                     "Gestão de Materiais e Medicamentos",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {                    
                    for (int nCount = 0; nCount < dtbReqItem.Rows.Count; nCount++)
                    {
                        if (dtbReqItem.Rows[nCount].RowState != DataRowState.Deleted)
                        {
                            if (dtbReqItem.Rows[nCount][RequisicaoItensDTO.FieldNames.IdtProduto].ToString() == dtgMatMed.Rows[e.RowIndex].Cells["colMatMedIdt"].Value.ToString())
                            {
                                RequisicaoItensDTO dtoReqItemAux = (RequisicaoItensDTO)dtbReqItem.Rows[nCount];
                                //Atualiza banco com qtd. fornecida zerada
                                dtoReqItemAux.QtdFornecida.Value = 0;
                                ReqItem.Upd(dtoReqItemAux);
                                //Atualiza na lista c/ todos os itens em memória a qtd. fornecida zerada p/ este item
                                dtbReqItem.Rows[nCount][RequisicaoItensDTO.FieldNames.QtdFornecida] = 0;
                                dtbReqItem.AcceptChanges();
                                break;
                            }
                        }
                    }
                    for (int nCount = 0; nCount < dtbReqItemDispensado.Rows.Count; nCount++)
                    {
                        if (dtbReqItemDispensado.Rows[nCount].RowState != DataRowState.Deleted)
                        {
                            if (dtbReqItemDispensado.Rows[nCount][RequisicaoItensDTO.FieldNames.IdtProduto].ToString() == dtgMatMed.Rows[e.RowIndex].Cells["colMatMedIdt"].Value.ToString())
                            {   //Remove do grid que lista os itens já dispensados
                                dtbReqItemDispensado.Rows[nCount].Delete();
                                dtbReqItemDispensado.AcceptChanges();
                                break;
                            }
                        }
                    }
                }                
            }
            txtIdProduto.Focus();
        }

        #endregion        
    }
}