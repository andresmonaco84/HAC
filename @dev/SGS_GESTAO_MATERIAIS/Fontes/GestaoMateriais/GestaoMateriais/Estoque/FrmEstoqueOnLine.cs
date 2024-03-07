using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao;
using HospitalAnaCosta.SGS.GestaoMateriais.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.Relatorio;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Estoque
{
    public partial class FrmEstoqueOnLine : FrmGestao
    {
        public FrmEstoqueOnLine()
        {
            InitializeComponent();
        }

        string TextoPesquisado;
        int selecionada;
        CurrencyManager _CM;
        int LinhaAtual = 0;
        // private FrmImportaInventario frmimp;
        Generico Acesso = new Generico();
        // private FrmPrincipal Acesso = new FrmPrincipal();

        #region OBJETOS SERVIÇO

        private IMatMedSetorConfig _matMedConfig;
        private IMatMedSetorConfig MatMedSetorConfig
        {
            get { return _matMedConfig != null ? _matMedConfig : _matMedConfig = (IMatMedSetorConfig)Global.Common.GetObject(typeof(IMatMedSetorConfig)); }
        }

        // Estoque        
        private IEstoqueLocal _estoque;
        private IEstoqueLocal Estoque
        {
            get { return _estoque != null ? _estoque : _estoque = (IEstoqueLocal)Global.Common.GetObject( typeof(IEstoqueLocal)); }
        }
        private EstoqueLocalDTO dtoEstoque;
        private EstoqueLocalDataTable dtbEstoque;

        private ISetor _setor;
        private ISetor Setor
        {
            get { return _setor != null ? _setor : _setor = (ISetor)Global.Common.GetObject(typeof(ISetor)); }
        }

        // GrupoMatMed        
        private IGrupoMatMed _grupoMatMed;
        private IGrupoMatMed GrupoMatMed
        {
            get { return _grupoMatMed != null ? _grupoMatMed : _grupoMatMed = (IGrupoMatMed)Global.Common.GetObject(typeof(IGrupoMatMed)); }
        }

        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        Generico gen = new Generico();

        #endregion

        #region MÉTODOS
                      
        private void CarregaItens()
        {
            dtgMatMed.Columns[colEnderecoAlmox.Name].Visible = false;
            mnuEstoqueOnLine.Enabled = chkPriAti.Checked = false;
            if (cmbGrupo.SelectedIndex > 0) cmbGrupo.SelectedIndex = 0;
            txtPesquisa.Text = string.Empty;            
            if (cmbUnidade.SelectedIndex == -1 || cmbLocal.SelectedIndex == -1 || cmbSetor.SelectedIndex == -1)
            {
                rbHac.Checked = false;
                rbAcs.Checked = false;
                rbCE.Checked = false;
                rbConsig.Checked = false;
                //chkMateriais.Checked = false;
                //chkMedicamentos.Checked = false;
                chkPriAti.Checked = false;               

                MessageBox.Show("Selecione Unidade/Local/Setor Para Pesquisa", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                dtgMatMed.DataSource = null;
                ConfiguraEstoqueDTO();
                dtbEstoque = Estoque.EstoqueOnLine(dtoEstoque);
                lblTotalProdutos.Text = dtbEstoque.Rows.Count.ToString();
                dtgMatMed.DataSource = dtbEstoque;
                if (dtgMatMed.Rows.Count > 0)
                    mnuEstoqueOnLine.Enabled = true;
                //chkMateriais.Checked = true;
                //chkMedicamentos.Checked = true;
                chkPriAti.Checked = false;
                this.Cursor = Cursors.Default;
                try
                {
                    if (Acesso.VerificaAcessoFuncionalidade("cmbUnidade"))
                    {
                        lblOculto.Text = string.Format("{0}/{1}/{2}", cmbUnidade.SelectedValue.ToString(), cmbLocal.SelectedValue.ToString(), cmbSetor.SelectedValue.ToString());
                    }
                    else
                    {
                        lblOculto.Text = string.Empty;
                    }
                    if (int.Parse(cmbSetor.SelectedValue.ToString()) == 29) //Almox. Central
                        dtgMatMed.Columns[colEnderecoAlmox.Name].Visible = true;

                    //if (Acesso.VerificaAcessoFuncionalidade("Inventario"))
                    //{
                    //    btnInventario.Visible = true;
                    //}
                    // verifica estoque compartilhado
                    SetorEstoqueConsumoDTO dtoEstoqueConsumo = new SetorEstoqueConsumoDTO();
                    dtoEstoqueConsumo.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                    dtoEstoqueConsumo.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                    dtoEstoqueConsumo.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                    dtoEstoqueConsumo.IdtFilial.Value = gen.RetornaFilial(rbHac, rbAcs, rbCE, rbConsig);

                    if (gen.CarregaEstoqueConsumo(dtoEstoqueConsumo).Rows.Count > 0)
                    {
                        tsHac.Items["lblEstComp"].Text = "Esta Unidade Consome do estoque outra Unidade";
                        tsHac.Items["lblEstComp"].Visible = true;

                    }
                    else if (gen.VerificaEstoqueCompartilhado(dtoEstoqueConsumo).Rows.Count > 0)
                    {
                        // alguém consome deste estoque
                        tsHac.Items["lblEstComp"].Text = "Outra(s) Unidade(s) Consome(m) deste estoque";
                        tsHac.Items["lblEstComp"].Visible = true;
                    }
                    else
                    {
                        tsHac.Items["lblEstComp"].Visible = false;
                    }
                }
                catch
                {
                    MessageBox.Show("erro Buscando Estoque Compartilhado", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                // esta unidade consome de ourtro estoque
             }
        }

        /// <summary>
        /// Configura Colunas do Data Grid baseado nos campos do dto
        /// </summary>
        private void ConfiguraDTG()
        {
            dtgMatMed.AutoGenerateColumns = false;
            
            dtgMatMed.Columns["colIdtProduto"].DataPropertyName = EstoqueLocalDTO.FieldNames.IdtProduto;
            dtgMatMed.Columns["colIdtProduto"].ToolTipText = string.Empty;
            dtgMatMed.Columns["colIdtProduto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

            dtgMatMed.Columns["colDsProduto"].DataPropertyName = EstoqueLocalDTO.FieldNames.DsProduto;
            dtgMatMed.Columns["colDsProduto"].ToolTipText = string.Empty;


            dtgMatMed.Columns["colQtdePadrao"].DataPropertyName = EstoqueLocalDTO.FieldNames.QtdePadrao;            
            dtgMatMed.Columns["colQtdePadrao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgMatMed.Columns["colQtdePadrao"].DefaultCellStyle.Format = "N0";            

            dtgMatMed.Columns["colFornecido"].DataPropertyName = EstoqueLocalDTO.FieldNames.SaldoMovimentacao;
            dtgMatMed.Columns["colFornecido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgMatMed.Columns["colFornecido"].DefaultCellStyle.Format = "N0";

            dtgMatMed.Columns["colQtdeEstoque"].DataPropertyName = EstoqueLocalDTO.FieldNames.Qtde;
            dtgMatMed.Columns["colQtdeEstoque"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgMatMed.Columns["colQtdeEstoque"].DefaultCellStyle.Format = "N0";

            //dtgMatMed.Columns["colOutros"].DataPropertyName = EstoqueLocalDTO.FieldNames.OutrosConsumos;
            //dtgMatMed.Columns["colOutros"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            //dtgMatMed.Columns["colOutros"].DefaultCellStyle.Format = "N0";

            dtgMatMed.Columns["colConsumido"].DataPropertyName = EstoqueLocalDTO.FieldNames.Consumido;
            dtgMatMed.Columns["colConsumido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgMatMed.Columns["colConsumido"].DefaultCellStyle.Format = "N0";

            dtgMatMed.Columns["colPercentual"].DataPropertyName = EstoqueLocalDTO.FieldNames.Percentual;
            dtgMatMed.Columns["colPercentual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

            dtgMatMed.Columns["colFlFracionado"].DataPropertyName = EstoqueLocalDTO.FieldNames.FlFracionado;
            dtgMatMed.Columns["colTpMatMed"].DataPropertyName = EstoqueLocalDTO.FieldNames.Tabelamedica;
            dtgMatMed.Columns[colMAV.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia;

            dtgMatMed.Columns["colDtFornecimento"].DataPropertyName = EstoqueLocalDTO.FieldNames.DataFornecimento;
            dtgMatMed.Columns["colDtFornecimento"].DefaultCellStyle.Format = "dd/MM/yyyy à\\s HH:mm:ss";

            dtgMatMed.Columns["colPercRessuprimento"].DataPropertyName = EstoqueLocalDTO.FieldNames.PontoRessuprimento;

            dtgMatMed.Columns["colBaixaAutomatica"].DataPropertyName = EstoqueLocalDTO.FieldNames.BaixaAutomatica;
            dtgMatMed.Columns["colMtmdIdOriginal"].DataPropertyName = EstoqueLocalDTO.FieldNames.IdtProdutoOriginal;
            dtgMatMed.Columns["colDsProdutoOriginal"].DataPropertyName = EstoqueLocalDTO.FieldNames.DsProdutoOriginal;

            dtgMatMed.Columns["colPriAti"].DataPropertyName = EstoqueLocalDTO.FieldNames.IdtPrincipioAtivo;

            dtgMatMed.Columns["colInteiroFracionado"].DataPropertyName = EstoqueLocalDTO.FieldNames.QtdeFracionada;
            dtgMatMed.Columns["colInteiroFracionado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgMatMed.Columns["colInteiroFracionado"].DefaultCellStyle.Format = "N0";

            dtgMatMed.Columns["colFaturado"].DataPropertyName = EstoqueLocalDTO.FieldNames.FlFaturado;
            dtgMatMed.Columns["colFlAtivo"].DataPropertyName = EstoqueLocalDTO.FieldNames.FlAtivo;
            dtgMatMed.Columns["colIdGrupo"].DataPropertyName = MaterialMedicamentoDTO.FieldNames.IdtGrupo;

            dtgMatMed.Columns[colEnderecoAlmox.Name].DataPropertyName = "CAD_MTMD_ENDERECO_ALMOX_HAC";
            
            // dtgMatMed.Columns["colPercentual"].DefaultCellStyle.Format = "P02";
        }

        private decimal RetornaFilial()
        {
            decimal retorno = 0;
            if (rbHac.Checked)
            {
                retorno = (decimal)FilialMatMedDTO.Filial.HAC;
            }
            else if (rbAcs.Checked)
            {
                retorno = (decimal)FilialMatMedDTO.Filial.ACS;
            }
            else if (rbCE.Checked)
            {
                retorno = (decimal)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
            }
            else if (rbConsig.Checked)
            {
                retorno = (decimal)FilialMatMedDTO.Filial.CONSIGNADO;
            }
            return retorno;

        }

        private void ConfiguraEstoqueDTO()
        {
            dtoEstoque = new EstoqueLocalDTO();

            dtoEstoque.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoEstoque.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoEstoque.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoEstoque.IdtFilial.Value = RetornaFilial();
            /*
            if (rbHac.Checked)
            {
                dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
            }
            else if (rbAcs.Checked)
            {
                dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.ACS;
            }
            else if (rbCE.Checked)
            {
                dtoEstoque.IdtFilial.Value = (int)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
            }
             * */
            dtoEstoque.Origem.Value = 1;
        }

        private void Limpar()
        {
            lblTotalProdutos.Text = "0";
            lblOculto.Text = string.Empty;
            tsHac.Items["lblEstComp"].Visible = false;
            btnInventario.Visible = false;
        }

        private void VerificaEstoqueUnificado()
        {
            int? setorCarrEmergPai = Acesso.SetorCarrinhoEmergencia(int.Parse(cmbSetor.SelectedValue.ToString()));
            if (setorCarrEmergPai != null)
            {
                this.ConfigurarControles(grbFilial.Controls, false);
                rbCE.Checked = true;
                return;
            }
            else
            {
                this.ConfigurarControles(grbFilial.Controls, true);
                rbCE.Checked = false;
            }
            MatMedSetorConfigDTO dtoCfg = new MatMedSetorConfigDTO();
            dtoCfg.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoCfg.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoCfg.Idtsetor.Value = cmbSetor.SelectedValue.ToString();
            dtoCfg = MatMedSetorConfig.SetorCfg(dtoCfg);
            if (dtoCfg.EstoqueUnificadoHAC.Value.IsNull) dtoCfg.EstoqueUnificadoHAC.Value = 0;
            if (dtoCfg.EstoqueUnificadoHAC.Value == 1)
            {
                //rbCE.Text = "EU";
                this.Cursor = Cursors.WaitCursor;
                //rbCE.Checked = true;
                rbHac.Checked = true;
                this.Cursor = Cursors.Default;
                //grbFilial.Visible = false;
                //lblEstoqueUnificado.Text = "ESTOQUE ÚNICO HAC";
                lblEstoqueUnificado.Text = string.Empty;
            }
            else
            {
                rbCE.Text = "CE";
                rbCE.Checked = false;
                grbFilial.Visible = true;
                lblEstoqueUnificado.Text = string.Empty;
            }
        }

        /// <summary>
        /// Retorna se este estoque é abastecido por entrada de NF do RM
        /// </summary>
        /// <returns></returns>
        private bool EstoqueEntradaNF()
        {
            return true; //Tiago pediu para liberar para todos os setores

            if (int.Parse(cmbSetor.SelectedValue.ToString()) == 29) return true; //Almox. Central
            SetorDTO dtoSetor = new SetorDTO();
            dtoSetor.Idt.Value = cmbSetor.SelectedValue.ToString();
            string setor = Setor.SelChave(dtoSetor).Descricao.ToString();
            if (setor.IndexOf("UNITAR") > -1) return true;
            if (setor.IndexOf("FARM") > -1) return true;

            LocalEstoqueDTO dtoEstoqueMovimentacao = new LocalEstoqueDTO();
            LocalEstoqueDataTable dtbEstoqueMovimentacao = new LocalEstoqueDataTable();
            dtoEstoqueMovimentacao.IdtLocalEstoque.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
            dtbEstoqueMovimentacao = EstoqueMovimentacao.EstoqueUsuario(dtoEstoqueMovimentacao);            
            if (dtbEstoqueMovimentacao.Select(string.Format("{0}={1} AND {2}<>'0'", LocalEstoqueDTO.FieldNames.IdtSetor, 
                                                                                    cmbSetor.SelectedValue,
                                                                                    LocalEstoqueDTO.FieldNames.TpMovimentacaoEntrada)).Length > 0)
                return true;

            return false;
        }

        /// <summary>
        /// Retrona Linha selecionada do grid ou -1 se nenhuma estiver selecionadada
        /// </summary>
        /// <returns></returns>
        private int LinhaSelecionada()
        {
            int selecionada = -1;
            for (int i = 0; i < dtgMatMed.Rows.Count; i++)
            {
                if (dtgMatMed.Rows[i].Selected)
                {
                    selecionada = i;
                    break;
                }
            }
            return selecionada;
        }

        private void FiltraDtg()
        {
            if (dtgMatMed.Rows.Count > 0)
            {
                //chkPriAti.Checked = false;
                this.Cursor = Cursors.WaitCursor;
                //CurrencyManager cm = (CurrencyManager)BindingContext[dtgMatMed.DataSource];
                CurrencyManager CM = CriaManager();
                CM.EndCurrentEdit();
                CM.ResumeBinding();
                CM.SuspendBinding();
                LinhaAtual = 0; // zera posição da ultima pesquisa realizada
                TextoPesquisado = string.Empty;
                txtPesquisa.Text = string.Empty;

                // PROCURA PRIMEIRA LINHA VISIVEL
                //for (int x = 0; x < dtgMatMed.Rows.Count; x++)
                //{
                //    if (dtgMatMed.Rows[x].Visible)
                //    {
                //        dtgMatMed.FirstDisplayedScrollingRowIndex = x;
                //        CM.Position = x;
                //        break;
                //    }
                //}
                dtgMatMed.ClearSelection();
                lblTotalProdutos.Text = "0";
                int contador = 0;                
                for (int i = 0; i < dtgMatMed.Rows.Count; i++)
                {
                    //if (dtgMatMed.Rows[i].Cells["colTpMatMed"].Value.ToString() == "ME")
                    //{
                    //    dtgMatMed.Rows[i].Selected = false;
                    //    dtgMatMed.Rows[i].Visible = chkMedicamentos.Checked;
                    //    if (chkMedicamentos.Checked)
                    //        contador++;

                    //}
                    //if (dtgMatMed.Rows[i].Cells["colTpMatMed"].Value.ToString() == "MA")
                    //{
                    //    dtgMatMed.Rows[i].Selected = false;
                    //    dtgMatMed.Rows[i].Visible = chkMateriais.Checked;
                    //    if (chkMateriais.Checked)
                    //        contador++;
                    //}
                    dtgMatMed.Rows[i].Selected = false;
                    if (cmbGrupo.SelectedIndex > 0)
                    {
                        if (dtgMatMed.Rows[i].Cells["colIdGrupo"].Value.ToString() == cmbGrupo.SelectedValue.ToString())
                        {
                            dtgMatMed.Rows[i].Visible = true;
                            contador++;
                        }
                        else
                            dtgMatMed.Rows[i].Visible = false;
                    }
                    else
                    {
                        dtgMatMed.Rows[i].Visible = true;
                        contador++;
                    }
                }
                lblTotalProdutos.Text = contador.ToString();                
                //txtPesquisa.Text = string.Empty;
                //selecionada = 0;
                //dtgMatMed.Rows[selecionada].Selected = true;
                this.Cursor = Cursors.Default;
            }
        }

        private bool ValidarPeriodo()
        {
            if (txtDtIni.Text == string.Empty)
            {
                MessageBox.Show("Digite a Data Início", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDtIni.Focus();
                return false;
            }
            if (txtDtFim.Text == string.Empty)
            {
                MessageBox.Show("Digite a Data Fim", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDtFim.Focus();
                return false;
            }
            try
            {
                if (Convert.ToDateTime(txtDtFim.Text).Date < Convert.ToDateTime(txtDtIni.Text).Date)
                {
                    MessageBox.Show("A Data Fim deve ser maior ou igual à Data Início.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDtFim.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Data inválida.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (((chkSaldos.Checked && chkTodosSetores.Checked) || (!chkSaldos.Checked && !chkAgruparMes.Checked && chkTodosSetores.Checked)) && 
                 Convert.ToDateTime(txtDtFim.Text).Date > Convert.ToDateTime(txtDtIni.Text).Date.AddMonths(1).Date)
            {
                MessageBox.Show("Período não pode ser superior a 1 mês para esta opção de agrupamento.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDtFim.Focus();
                return false;
            }
            else if (!chkSaldos.Checked && chkAgruparMes.Checked && chkTodosSetores.Checked && 
                     Convert.ToDateTime(txtDtFim.Text).Date > Convert.ToDateTime(txtDtIni.Text).Date.AddMonths(3).Date)
            {
                MessageBox.Show("Período não pode ser superior a 3 meses para esta opção de agrupamento.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDtFim.Focus();
                return false;
            }
            else if (Convert.ToDateTime(txtDtFim.Text).Date > Convert.ToDateTime(txtDtIni.Text).Date.AddMonths(6).Date)
            {
                MessageBox.Show("Período não pode ser superior a 6 meses.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDtFim.Focus();
                return false;
            }
            return true;
        }

        #endregion

        #region EVENTOS

        private void FrmEstoqueOnLine_Load(object sender, EventArgs e)
        {
            cmbSetor.ComEstoque = false;
            cmbUnidade.Carregaunidade();
            // chkPriAti.Enabled = false;
            Generico.ConfiguraCombos(cmbUnidade,cmbLocal,cmbSetor,FrmPrincipal.dtoSeguranca);
            ConfiguraDTG();
            VerificaEstoqueUnificado();            
            tsCompra.Visible = tsPlanilha.Visible = false;
            if (Acesso.VerificaAcessoFuncionalidade("FrmRelatorios") && cmbSetor.Enabled && EstoqueEntradaNF()) tsCompra.Visible = true;
            if (Acesso.VerificaAcessoFuncionalidade("PlanilhaMovimentos"))          
                tsPlanilha.Visible = true;
            mnuEstoqueOnLine.Items["mnuItemIR"].Visible = Acesso.VerificaAcessoFuncionalidade("FrmAnaliseEstoqueCustos");            
            mnuEstoqueOnLine.Items["mnuTransfere"].Visible = Acesso.VerificaAcessoFuncionalidade("FrmTransfMatMed");
            mnuEstoqueOnLine.Items[mnuItemImp.Name].Visible = gen.VerificaAcessoFuncionalidade("FrmImpCodBarra");
            mnuEstoqueOnLine.Items["mnuAcerto"].Visible = false; //Acesso.VerificaAcessoFuncionalidade("FrmAcertoEstoque");
            mnuEstoqueOnLine.Items["mnuExcluirItem"].Visible = false; //Acesso.VerificaAcessoFuncionalidade("ExcluiProdutoEstoque");                        
            dtgMatMed.ContextMenuStrip = mnuEstoqueOnLine;

            DataTable dtGrupo = GrupoMatMed.Sel(new GrupoMatMedDTO());
            DataRow rowSel = dtGrupo.NewRow();
            rowSel[0] = -1; rowSel[1] = "<< NENHUM GRUPO SELECIONADO >>";
            dtGrupo.Rows.InsertAt(rowSel, 0);
            cmbGrupo.DataSource = dtGrupo;            
            //cmbGrupo.IniciaLista();            
        }

        private void rbHac_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHac.Checked)
                CarregaItens();
        }

        private void rbAcs_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAcs.Checked )
                CarregaItens();
        }

        private void rbCE_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCE.Checked )
                CarregaItens();
        }

        private void rbConsig_CheckedChanged(object sender, EventArgs e)
        {
            if (rbConsig.Checked)
                CarregaItens();
        }

        private void rbHac_Click(object sender, EventArgs e)
        {
            // CarregaItens();
        }

        private void rbAcs_Click(object sender, EventArgs e)
        {
            // CarregaItens();
        }

        private void rbCE_Click(object sender, EventArgs e)
        {
            // CarregaItens();
            if (rbCE.Checked)
            {
                this.Cursor = Cursors.WaitCursor;

                string strMsgSetoresCE = gen.SetoresCE_MessageBox(int.Parse(cmbSetor.SelectedValue.ToString()));

                if (!string.IsNullOrEmpty(strMsgSetoresCE))
                    MessageBox.Show(strMsgSetoresCE.ToString(), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Cursor = Cursors.Default;
            }
        }        

        private void rbConsig_Click(object sender, EventArgs e)
        {

        }

        private void cmbGrupo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FiltraDtg();
            chkPriAti.Checked = false;
        }

        private void dtgMatMed_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // e.CellStyle.BackColor = Color.LightBlue;
            dtgMatMed.Rows[e.RowIndex].Cells["colDsProduto"].ToolTipText = ".";
            
            if (dtbEstoque != null)
            {
                if (dtbEstoque.Rows.Count > 0 && dtbEstoque.Rows.Count == dtgMatMed.Rows.Count)
                {
                    // primeiro verifica se está ativo
                    if (dtgMatMed.Rows[e.RowIndex].Cells["colFlAtivo"].Value.ToString() == "0")
                    {
                        e.CellStyle.BackColor = Color.LightBlue;
                        e.CellStyle.ForeColor = Color.Gray;
                        e.CellStyle.SelectionForeColor = Color.Gray;
                        dtgMatMed.Rows[e.RowIndex].Cells["colDsProduto"].ToolTipText = "Este Produto está Inativo";
                    }
                    else
                    {
                        #region "SO PRODUTOS DO ESTOQUE PADRÃO"
                        if (!string.IsNullOrEmpty(dtgMatMed.Rows[e.RowIndex].Cells["colQtdePadrao"].Value.ToString()) && Convert.ToDecimal(dtgMatMed.Rows[e.RowIndex].Cells["colQtdePadrao"].Value.ToString()) > 0)
                        {
                            decimal saldo;
                            // É PRODUTO PADRÃO
                            e.CellStyle.BackColor = Color.White;
                            string padrao = dtgMatMed.Rows[e.RowIndex].Cells["colQtdePadrao"].Value.ToString();
                            string fornecido = dtgMatMed.Rows[e.RowIndex].Cells["colFornecido"].Value.ToString();
                            string consumo = dtgMatMed.Rows[e.RowIndex].Cells["colConsumido"].Value.ToString();
                            // string outrosConsumo = dtgMatMed.Rows[e.RowIndex].Cells["colOutros"].Value.ToString();
                            if (dtgMatMed.Rows[e.RowIndex].Cells["colQtdeEstoque"].Value.ToString() == string.Empty)
                                saldo = 0;
                            else
                                saldo = decimal.Parse(dtgMatMed.Rows[e.RowIndex].Cells["colQtdeEstoque"].Value.ToString());
                            if (string.IsNullOrEmpty(fornecido)) fornecido = "0";
                            if (!string.IsNullOrEmpty(consumo)) //|| !string.IsNullOrEmpty(outrosConsumo))
                            {
                                if (string.IsNullOrEmpty(consumo)) consumo = "0";
                                decimal calculoRef = decimal.Parse(fornecido); //Variável calculoRef pode ser pelo fornecido, ou padrao, quando fornecido for 0
                                if (decimal.Parse(fornecido) == 0) calculoRef = decimal.Parse(padrao);
                                decimal calculo = calculoRef - decimal.Parse(consumo); // -decimal.Parse(outrosConsumo);
                                //Quando cálculo referente aos consumos não bater com saldo, a fonte do saldo ficará vermelha
                                if (calculo != saldo)
                                {
                                    dtgMatMed.Rows[e.RowIndex].Cells["colQtdeEstoque"].Style.ForeColor = Color.DarkRed;
                                    dtgMatMed.Rows[e.RowIndex].Cells["colQtdeEstoque"].Style.SelectionForeColor = Color.DarkRed;
                                }
                            }
                            else
                            {
                                //Se não tiver nenhum consumo, e saldo for maior que o padrão, a fonte do saldo ficará vermelha
                                if (saldo > decimal.Parse(padrao))
                                {
                                    dtgMatMed.Rows[e.RowIndex].Cells["colQtdeEstoque"].Style.ForeColor = Color.DarkRed;
                                    dtgMatMed.Rows[e.RowIndex].Cells["colQtdeEstoque"].Style.SelectionForeColor = Color.DarkRed;
                                }
                            }
                            if (decimal.Parse(fornecido) > 0 && fornecido != padrao)
                            {
                                //Se qtd. fornecida for diferente da padrão, a fonte da qtd. fornecida ficará vermelha
                                dtgMatMed.Rows[e.RowIndex].Cells["colFornecido"].Style.ForeColor = Color.DarkRed;
                                dtgMatMed.Rows[e.RowIndex].Cells["colFornecido"].Style.SelectionForeColor = Color.DarkRed;
                            }
                            if (!string.IsNullOrEmpty(dtgMatMed.Rows[e.RowIndex].Cells["colPercentual"].Value.ToString()))
                            {
                                decimal percentual = decimal.Parse(dtgMatMed.Rows[e.RowIndex].Cells["colPercentual"].Value.ToString());
                                decimal Ressuprimento = 0;
                                if (dtgMatMed.Rows[e.RowIndex].Cells["colPercRessuprimento"].Value.ToString() != string.Empty)
                                {
                                    Ressuprimento = decimal.Parse(dtgMatMed.Rows[e.RowIndex].Cells["colPercRessuprimento"].Value.ToString());

                                }
                                if (percentual >= Ressuprimento && percentual <= 79)
                                {
                                    if (dtgMatMed.Columns[e.ColumnIndex].Name == "colPercentual")
                                    {
                                        e.CellStyle.BackColor = Color.Yellow;
                                        e.CellStyle.SelectionForeColor = Color.Yellow;
                                    }
                                }
                                if (percentual >= 80 && percentual <= 99)
                                {
                                    if (dtgMatMed.Columns[e.ColumnIndex].Name == "colPercentual")
                                    {
                                        e.CellStyle.BackColor = Color.Orange;
                                        e.CellStyle.SelectionForeColor = Color.Orange;
                                    }
                                }
                                if (percentual == 100)
                                {
                                    if (dtgMatMed.Columns[e.ColumnIndex].Name == "colPercentual")
                                    {
                                        e.CellStyle.BackColor = Color.Red;
                                        e.CellStyle.SelectionForeColor = Color.Red;
                                    }
                                }
                            }
                            if (dtgMatMed.Columns[e.ColumnIndex].Name == "colQtdePadrao") e.CellStyle.BackColor = Color.LightGray;
                            if (dtgMatMed.Columns[e.ColumnIndex].Name == "colQtdeEstoque") e.CellStyle.BackColor = Color.LightGray;
                        }
                        else
                        {
                            // NÃO É PRODUTO PADRÃO
                            e.CellStyle.BackColor = Color.LightBlue;
                        }
                        #endregion
                    }
                    #region "FORMATAÇÃO DE SIMILARES"
                    if (!string.IsNullOrEmpty(dtgMatMed.Rows[e.RowIndex].Cells["colMtmdIdOriginal"].Value.ToString()) && Convert.ToDecimal(dtgMatMed.Rows[e.RowIndex].Cells["colMtmdIdOriginal"].Value.ToString()) > 0)
                    {
                        //e.CellStyle.Font = 
                        dtgMatMed.Rows[e.RowIndex].Cells["colDsProduto"].Style.Font = new Font(e.CellStyle.Font, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                        dtgMatMed.Rows[e.RowIndex].Cells["colDsProduto"].ToolTipText = "ORIGINAL DO PEDIDO: " + dtgMatMed.Rows[e.RowIndex].Cells["colDsProdutoOriginal"].Value.ToString();
                    }
                    #endregion
                }
            }            
        }

        private void dtgMatMed_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dtgMatMed.Columns[e.ColumnIndex].Name == "colSimilar")
                {
                    this.Cursor = Cursors.WaitCursor;
                    MaterialMedicamentoDTO dtoMatMed = new MaterialMedicamentoDTO();
                    dtoMatMed.Idt.Value = Convert.ToDecimal(dtgMatMed.Rows[e.RowIndex].Cells["colIdtProduto"].Value.ToString());
                    new FrmPesquisaSimilares().VisualizarSimilares(dtoMatMed);
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void cmbUnidade_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Limpar();
            tsHac.Controla(Evento.eCancelar);
        }

        private void cmbLocal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Limpar();
            tsHac.Controla(Evento.eCancelar);
        }

        private void cmbSetor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Limpar();
            tsHac.Controla(Evento.eCancelar);            
            VerificaEstoqueUnificado();
            tsCompra.Visible = false;
            if (cmbSetor.Enabled && cmbSetor.SelectedValue != null && Acesso.VerificaAcessoFuncionalidade("FrmRelatorios") && EstoqueEntradaNF()) tsCompra.Visible = true;
        }             

        private void dtgMatMed_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                MovimentacaoDTO dtoMovimentacao = new MovimentacaoDTO();
                dtoMovimentacao.IdtProduto.Value = Convert.ToInt64(dtgMatMed.Rows[e.RowIndex].Cells["colIdtProduto"].Value.ToString());
                dtoMovimentacao.DsProduto.Value = dtgMatMed.Rows[e.RowIndex].Cells["colDsProduto"].Value.ToString();
                dtoMovimentacao.IdtUnidade.Value = dtoEstoque.IdtUnidade.Value;
                dtoMovimentacao.IdtLocal.Value = dtoEstoque.IdtLocal.Value;
                dtoMovimentacao.IdtSetor.Value = dtoEstoque.IdtSetor.Value;
                dtoMovimentacao.IdtFilial.Value = dtoEstoque.IdtFilial.Value;
                if (dtgMatMed.Rows[e.RowIndex].Cells["colQtdeEstoque"].Value.ToString() == string.Empty)
                    dtoMovimentacao.Qtde.Value = 0;
                else
                    dtoMovimentacao.Qtde.Value = Convert.ToDecimal(dtgMatMed.Rows[e.RowIndex].Cells["colQtdeEstoque"].Value.ToString());
                // dtoMovimentacao.DataMovimento.Value = dtoMovimentacao.DataMovimento.Value = DateTime.Parse("1/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
                new Movimentacao.FrmMovimentacao().Movimentacao(dtoMovimentacao);
            }
        }

        private CurrencyManager CriaManager()
        {
            return (_CM != null ? _CM : (CurrencyManager)dtgMatMed.BindingContext[dtbEstoque]);
        }

        private void PesquisaGrid()
        {            
            if (txtPesquisa.Text == string.Empty) return;
            string Texto;
            Boolean bExiste = false;
            if (dtgMatMed.SelectedRows.Count == 0 && dtgMatMed.Rows.Count > 0) dtgMatMed.Select();
            chkPriAti.Checked = false;
            if (TextoPesquisado != txtPesquisa.Text)
            {
                // MUDOU TEXTO RECOMEÇA PESQUISA
                LinhaAtual = 0;
                TextoPesquisado = txtPesquisa.Text;
            }
            dtgMatMed.ClearSelection();
            int posiciona;
            for (int i = LinhaAtual; i < dtgMatMed.Rows.Count; i++)
            {
                Texto = dtgMatMed.Rows[i].Cells["colDsProduto"].Value.ToString().ToUpper();
                if (Texto.IndexOf(txtPesquisa.Text) != -1)
                {
                    if (dtgMatMed.Rows[i].Visible)
                    {
                        if (i != LinhaAtual)
                        {
                            dtgMatMed.Rows[i].Selected = true;
                            // CM.Position = i;
                            if (!dtgMatMed.Rows[i].Displayed)
                            {
                                posiciona = i - 10;
                                posiciona = (posiciona < 0 ? 0 : posiciona);
                                // procura primeira linha visivel
                                for (int x = 0; x < 9; x++)
                                {
                                    if (!dtgMatMed.Rows[posiciona].Visible)
                                    {
                                        posiciona++;
                                        if (posiciona == i)
                                        {
                                            //dtgMatMed.Rows[i].Selected = true;
                                            dtgMatMed.FirstDisplayedScrollingRowIndex = posiciona;
                                            // ela é a única linha visivel
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        //dtgMatMed.Rows[i].Selected = true;
                                        dtgMatMed.FirstDisplayedScrollingRowIndex = posiciona;
                                        break;
                                    }
                                }
                                //dtgMatMed.FirstDisplayedScrollingRowIndex = posiciona;
                            }
                            LinhaAtual = i;
                            //dtgMatMed.Select();
                            bExiste = true;
                            break;
                        }
                    }
                }
            }
            if (!bExiste)
            {
                MessageBox.Show("Não foi encontrado nenhum conteúdo com o Texto Digitado", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LinhaAtual = 0;
            }
            txtPesquisa.Focus();
        }

        private void txtPesquisa_Validating(object sender, CancelEventArgs e)
        {

        }

        private void hacButton1_Click(object sender, EventArgs e)
        {
            PesquisaGrid();
        }

        //private void chkMateriais_Click(object sender, EventArgs e)
        //{
        //    FiltraDtg();
        //}

        //private void chkMedicamentos_Click(object sender, EventArgs e)
        //{
        //    FiltraDtg();
        //}

        //private void TotaldeItens()
        //{
        //    dtgMatMed.ClearSelection();
        //    lblTotalProdutos.Text = "0";
        //    int contador = 0;
        //    for (int i = 0; i < dtgMatMed.Rows.Count; i++)
        //    {
        //        if (dtgMatMed.Rows[i].Cells["colTpMatMed"].Value.ToString() == "ME")
        //        {
        //            if (chkMedicamentos.Checked)
        //                contador++;
        //        }
        //        if (dtgMatMed.Rows[i].Cells["colTpMatMed"].Value.ToString() == "MA")
        //        {
        //            if (chkMateriais.Checked)
        //                contador++;
        //        }
        //    }
        //    lblTotalProdutos.Text = contador.ToString();
        //}        

        private void dtgMatMed_Sorted(object sender, EventArgs e)
        {
            if (dtgMatMed.Rows.Count > 0)
            {
                FiltraDtg();
            }
        }

        private void lblOculto_Click(object sender, EventArgs e)
        {
            dtgMatMed.Columns["colIdtProduto"].Visible = !(dtgMatMed.Columns["colIdtProduto"].Visible);
            dtgMatMed.Columns["colBaixaAutomatica"].Visible = !(dtgMatMed.Columns["colBaixaAutomatica"].Visible);
            dtgMatMed.Columns["colMtmdIdOriginal"].Visible = !(dtgMatMed.Columns["colMtmdIdOriginal"].Visible);
            dtgMatMed.Columns["colPriAti"].Visible = !(dtgMatMed.Columns["colPriAti"].Visible);
            dtgMatMed.Columns["colFaturado"].Visible = !(dtgMatMed.Columns["colFaturado"].Visible);
            dtgMatMed.Columns["colFlAtivo"].Visible = !(dtgMatMed.Columns["colFlAtivo"].Visible);
            dtgMatMed.Columns["colIdGrupo"].Visible = !(dtgMatMed.Columns["colIdGrupo"].Visible);            
        }

        private int _linha = 0;
        private void chkPriAti_Click(object sender, EventArgs e)
        {
            if (dtgMatMed.Rows.Count > 0)
            {
                if (chkPriAti.Checked)
                {
                    _linha = LinhaAtual;
                    selecionada = LinhaSelecionada();                    

                    if (selecionada >= 0)
                    {
                        //chkMedicamentos.Checked = true;
                        //chkMateriais.Checked = true;
                        cmbGrupo.SelectedIndex = 0;
                        txtPesquisa.Text = string.Empty;
                        FiltraDtg();

                        // nScroll = dtgMatMed.VerticalScrollingOffset;
                        decimal nPriAti = 0;
                        if (dtgMatMed.Rows[selecionada].Cells["colPriAti"].Value.ToString() != string.Empty && dtgMatMed.Rows[selecionada].Cells["colPriAti"].Value.ToString() != "0")
                        {
                            dtgMatMed.ClearSelection();

                            nPriAti = Convert.ToDecimal(dtgMatMed.Rows[selecionada].Cells["colPriAti"].Value.ToString());
                            // reseta filtro de Materiais e Medicamentos
                            this.Cursor = Cursors.WaitCursor;
                            for (int i = 0; i < dtgMatMed.Rows.Count; i++)
                            {
                                if (Convert.ToDecimal(dtgMatMed.Rows[i].Cells["colPriAti"].Value.ToString()) == nPriAti)
                                {
                                    dtgMatMed.Rows[i].Visible = true;
                                }
                                else
                                {
                                    dtgMatMed.Rows[i].Visible = false;
                                }
                            }
                            //txtPesquisa.Text = string.Empty;
                            //selecionada = 0;
                            //dtgMatMed.Rows[selecionada].Selected = true;
                            this.Cursor = Cursors.Default;
                        }
                        else
                        {
                            MessageBox.Show("Este Produto não tem Principio Ativo Cadastrado");
                            chkPriAti.Checked = false;
                            dtgMatMed.Rows[selecionada].Selected = true;
                            dtgMatMed.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não existe Material ou Medicamento Selecionado");
                        chkPriAti.Checked = false;
                        dtgMatMed.Focus();
                    }
                }
                else
                {
                    //chkMedicamentos.Checked = true;
                    //chkMateriais.Checked = true;      
                    cmbGrupo.SelectedIndex = 0;
                    txtPesquisa.Text = string.Empty;
                    FiltraDtg();
                    dtgMatMed.ClearSelection();
                    dtgMatMed.Rows[_linha].Selected = true;
                    selecionada = (selecionada - 2);
                    if (selecionada < 0) selecionada = 0;
                    dtgMatMed.FirstDisplayedScrollingRowIndex = selecionada;
                    dtgMatMed.Focus();
                }
            }
        }

        private void mnuItemIR_Click(object sender, EventArgs e)
        {
            if (dtgMatMed.CurrentRow == null) return;

            MaterialMedicamentoDTO MatMedIr = new MaterialMedicamentoDTO();

            // dtgMatMed.CurrentRow.Cells[].Value.ToString();
            MatMedIr.Idt.Value = dtgMatMed.CurrentRow.Cells["colIdtProduto"].Value.ToString();
            MatMedIr.IdtFilial.Value = RetornaFilial();

            FrmAnaliseEstoqueCustos.AbreIndiceRotatividade(MatMedIr);
        }

        private void mnuTransfere_Click(object sender, EventArgs e)
        {
            if (dtgMatMed.CurrentRow == null) return;
            if (base.Confirma(string.Format("{0} {1}?", "Deseja Fazer Transferência entre estoques do produto", dtgMatMed.CurrentRow.Cells["colDsProduto"].Value.ToString())))
            {
                MovimentacaoDTO dtoTransfere = new MovimentacaoDTO();
                dtoTransfere.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                dtoTransfere.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                dtoTransfere.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                dtoTransfere.IdtProduto.Value = dtgMatMed.CurrentRow.Cells["colIdtProduto"].Value.ToString();
                dtoTransfere.DsProduto.Value = dtgMatMed.CurrentRow.Cells["colDsProduto"].Value.ToString();
                dtoTransfere.IdtFilial.Value = RetornaFilial();
                FrmTransfMatMed.Transferencia(dtoTransfere);
            }
        }

        private void mnuAcerto_Click(object sender, EventArgs e)
        {
            if (base.Confirma(string.Format("{0} {1}", "Deseja Fazer acerto de estoque no produto", dtgMatMed.CurrentRow.Cells["colDsProduto"].Value.ToString())))
            {
                MovimentacaoDTO dtoAcerto = new MovimentacaoDTO();
                dtoAcerto.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                dtoAcerto.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                dtoAcerto.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                dtoAcerto.IdtProduto.Value = dtgMatMed.CurrentRow.Cells["colIdtProduto"].Value.ToString();
                dtoAcerto.DsProduto.Value = dtgMatMed.CurrentRow.Cells["colDsProduto"].Value.ToString();
                dtoAcerto.IdtFilial.Value = RetornaFilial();
                FrmAcertoEstoque.AcertaEstoque(dtoAcerto);
            }
        }

        private void mnuExcluirItem_Click(object sender, EventArgs e)
        {
            //    int selecionados = dtgMatMed.SelectedRows.Count;
            //    if (selecionados > 1)
            //    {
            //        if (base.Confirma(string.Format("{0} {1} {2}", "Existem ", selecionados.ToString(), " para exclusão, Deseja Continuar ?")))
            //        {
            //            EstoqueLocalDTO dtoInativa;
            //            DataGridViewSelectedRowCollection linhas = dtgMatMed.SelectedRows;                   


            //            for (int i = 0; i < linhas.Count; i++)
            //            {
            //                    try
            //                    {
            //                        dtoInativa = new EstoqueLocalDTO();
            //                        dtoInativa.IdtProduto.Value = Convert.ToDecimal(linhas[i].Cells["colIdtProduto"].Value.ToString());
            //                        dtoInativa.IdtFilial.Value = RetornaFilial();
            //                        dtoInativa.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            //                        dtoInativa.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            //                        dtoInativa.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            //                        dtoInativa.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
            //                        Estoque.InativaEstoqueProduto(dtoInativa);
            //                        //dtgMatMed.Rows.Remove(linhas[i]);
            //                        dtbEstoque.Rows[linhas[i].Index].Delete();
            //                    }
            //                    catch (Exception ex)
            //                    {
            //                        MessageBox.Show(ex.Message);
            //                    }
            //            }
            //            TotaldeItens();
            //        }
            //    }
            //    else if (selecionados == 1)
            //    {
            //        if (base.Confirma(string.Format("{0} {1}", "Deseja Excluir o produto", dtgMatMed.CurrentRow.Cells["colDsProduto"].Value.ToString())))
            //        {
            //            try
            //            {
            //                EstoqueLocalDTO dtoInativa = new EstoqueLocalDTO();
            //                dtoInativa.IdtProduto.Value = Convert.ToDecimal(dtgMatMed.CurrentRow.Cells["colIdtProduto"].Value.ToString());
            //                dtoInativa.IdtFilial.Value = RetornaFilial();
            //                dtoInativa.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            //                dtoInativa.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            //                dtoInativa.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            //                dtoInativa.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
            //                Estoque.InativaEstoqueProduto(dtoInativa);
            //                dtbEstoque.Rows[dtgMatMed.CurrentRow.Index].Delete();
            //                // dtgMatMed.Rows.Remove(dtgMatMed.CurrentRow);                        
            //                TotaldeItens();
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show(ex.Message);
            //            }
            //        }
            //    }
            //    dtbEstoque.AcceptChanges();
        }

        private void mnuItemImp_Click(object sender, EventArgs e)
        {
            if (dtgMatMed.CurrentRow == null) return;
            HistoricoNotaFiscalDTO dtoHistNFImprimir = new HistoricoNotaFiscalDTO();

            dtoHistNFImprimir.IdtProduto.Value = dtgMatMed.CurrentRow.Cells[colIdtProduto.Name].Value.ToString();
            //dtoHistNFImprimir.CodLote.Value = dtgMatMed.CurrentRow.Cells[colCodLote.Name].Value.ToString();
            dtoHistNFImprimir.IdtFilial.Value = (decimal)FilialMatMedDTO.Filial.HAC;

            FrmImpCodBarra.CarregarItemImpressao(dtoHistNFImprimir);
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            MovimentacaoDTO dtoMovImporta = new MovimentacaoDTO();

            dtoMovImporta.DsUnidade.Value = cmbUnidade.Text;
            dtoMovImporta.DsLocal.Value = cmbLocal.Text;
            dtoMovImporta.DsSetor.Value = cmbSetor.Text;

            dtoMovImporta.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoMovImporta.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoMovImporta.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoMovImporta.IdtFilial.Value = RetornaFilial();

            // frmimp.MdiParent = FrmPrincipal.ActiveForm;

            // frmimp.WindowState = FormWindowState.Normal;
            // frmimp.Focus();
            FrmImportaInventario frmimp = new FrmImportaInventario();
            dtoMovImporta.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
            frmimp.Importa(dtoMovImporta);
        }

        private void btnGerarSugCompra_Click(object sender, EventArgs e)
        {
            if (cmbGrupo.SelectedValue == null || cmbGrupo.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("Selecione o Grupo.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (rbCE.Checked || rbConsig.Checked || (!rbHac.Checked && !rbAcs.Checked))
            {
                MessageBox.Show("Selecione Estoque HAC / ACS / CONSIGNADO ?", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string nomeRelatorio = "GM_23_SUGESTAO_COMPRA_ESTOQUE";
            Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[7];

            if (rbSugCompraGeral.Checked) nomeRelatorio = "GM_45_CONSUMO_MENSAL_GRUPO";

            #region Monta Parâmetros

            int x = 0;
            
            if (!rbSugCompraGeral.Checked)
            {
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("USUARIO", FrmPrincipal.dtoSeguranca.Login.Value);                
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("SETOR", cmbSetor.Text);
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("UNIDADE", cmbUnidade.Text);
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("GRUPO", cmbGrupo.Text);
            }
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_SET_ID", cmbSetor.SelectedValue.ToString());
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_FILIAL_ID", rbHac.Checked ? ((byte)FilialMatMedDTO.Filial.HAC).ToString() :
                                                                                                                       ((byte)FilialMatMedDTO.Filial.ACS).ToString());
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_GRUPO_ID", cmbGrupo.SelectedValue.ToString());
            

            #endregion

            Microsoft.Reporting.WinForms.ReportParameter[] reportParamTemp = new Microsoft.Reporting.WinForms.ReportParameter[x];

            for (int i = 0; i < reportParam.Length; i++)
            {
                if (reportParam[i] == null) break;
                reportParamTemp[i] = reportParam[i];
            }
            reportParam = reportParamTemp;
            reportParamTemp = null;

            FrmReportViewer frmRelatorio = new FrmReportViewer();
            frmRelatorio.AbreRelatorio(nomeRelatorio, reportParam);
            return;
        }

        private void btnCancelarSugCompra_Click(object sender, EventArgs e)
        {
            pnlSugCompra.Visible = false;            
        }

        private void btnGerarPlanilha_Click(object sender, EventArgs e)
        {
            if (cmbSetor.SelectedIndex == -1 && !chkTodosSetores.Checked)
            {
                MessageBox.Show("Selecione o Setor", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (RetornaFilial() == 0) return;
            if (!ValidarPeriodo()) return;

            if (chkSaldos.Checked)
            {
                this.Cursor = Cursors.WaitCursor;
                EstoqueLocalDTO dto = new EstoqueLocalDTO();
                string strAnoMesDe = DateTime.Parse(txtDtIni.Text).ToString("yyyyMM");
                string strAnoMesAte = DateTime.Parse(txtDtFim.Text).ToString("yyyyMM");

                dto.IdtFilial.Value = RetornaFilial().ToString();

                if (!chkTodosSetores.Checked)
                    dto.IdtSetor.Value = cmbSetor.SelectedValue.ToString();

                DataTable dtb = Estoque.ListarEstoqueMes(dto, strAnoMesDe, strAnoMesAte);

                if (dtb.Rows.Count > 0)
                {
                    Generico.ExportarExcel(dtb.DefaultView.ToTable(true, "UNIDADE",
                                                                         "SETOR",
                                                                         "CODGRP",
                                                                         "GRUPO",
                                                                         "PRODUTO_ID",
                                                                         "PRODUTO_DESCRICAO",
                                                                         "UNIDADE_PROD",
                                                                         "ANO_MES",
                                                                         "SALDO_MES",
                                                                         "VALOR_MEDIO_MES"));
                }
                else
                    MessageBox.Show("Nenhum registro encontrado.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Cursor = Cursors.Default;
            }
            else
            {
                string nomeRelatorio = "GM_32_MOV_GERAL_SETOR";
                Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[5];

                #region Monta Parâmetros

                int x = 0;

                if (chkAgruparMes.Checked)
                    nomeRelatorio = "GM_33_MOV_GERAL_SETOR_MES";

                if (!chkTodosSetores.Checked)
                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_SET_ID", cmbSetor.SelectedValue.ToString());

                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_FILIAL_ID", RetornaFilial().ToString());
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PDATA_DE", txtDtIni.Text);
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PDATA_ATE", DateTime.Parse(txtDtFim.Text).AddDays(1).Date.ToString());

                #endregion

                Microsoft.Reporting.WinForms.ReportParameter[] reportParamTemp = new Microsoft.Reporting.WinForms.ReportParameter[x];

                for (int i = 0; i < reportParam.Length; i++)
                {
                    if (reportParam[i] == null) break;
                    reportParamTemp[i] = reportParam[i];
                }
                reportParam = reportParamTemp;
                reportParamTemp = null;

                FrmReportViewer frmRelatorio = new FrmReportViewer();
                frmRelatorio.AbreRelatorio(nomeRelatorio, reportParam);
            }
        }

        private void btnCancelarPlanilha_Click(object sender, EventArgs e)
        {
            pnlPlanilha.Visible = false;
            txtDtIni.Text = txtDtFim.Text = string.Empty;
        }

        private void tsCompra_Click(object sender, EventArgs e)
        {
            if (RetornaFilial() == 0) return;
            
            // configura panel
            pnlSugCompra.BorderStyle = BorderStyle.FixedSingle;
            pnlSugCompra.Visible = true;
            // configura panel
            return;
        }

        private void tsPlanilha_Click(object sender, EventArgs e)
        {
            if (RetornaFilial() == 0) return;
            if (gen.VerificaAcessoFuncionalidade("cmbUnidade")) chkTodosSetores.Enabled = true;

            txtDtIni.Text = Utilitario.ObterDataHoraServidor().ToString("01/MM/yyyy");
            txtDtFim.Text = Utilitario.ObterDataHoraServidor().ToString("dd/MM/yyyy");

            // configura panel
            pnlPlanilha.BorderStyle = BorderStyle.FixedSingle;
            pnlPlanilha.Visible = true;
            // configura panel
            return;
        }

        private void chkSaldos_Click(object sender, EventArgs e)
        {
            if (chkSaldos.Checked) chkAgruparMes.Checked = true;
        }

        #endregion        
    }
}