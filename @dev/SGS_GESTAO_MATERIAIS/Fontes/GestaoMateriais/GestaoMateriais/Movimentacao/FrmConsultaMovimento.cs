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
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.Seguranca.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmConsultaMovimento : FrmBase
    {
        public FrmConsultaMovimento()
        {
            InitializeComponent();
        }

        #region OBJETOS SERVIÇOS

        // Movimentos
        private MovimentacaoDTO dtoMovimento;
        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject(typeof(IMovimentacao)); }
        }


        // MatMed
        private MaterialMedicamentoDTO dtoMatMed;

        #endregion

        #region FUNÇÕES

        //private void ConfiguraCombos()
        //{
        //    cmbUnidade.SelectedValue = FrmPrincipal.dtoSeguranca.IdtUnidade.Value;
        //    cmbLocal.SelectedValue = FrmPrincipal.dtoSeguranca.IdtLocal.Value;
        //    cmbSetor.SelectedValue = FrmPrincipal.dtoSeguranca.IdtSetor.Value;

        //    if (FrmPrincipal.dtoSeguranca.IdtNivelSeguranca.Value == (int)SegurancaDTO.NivelSeguranca.OPERADOR)
        //    {
        //        cmbUnidade.Enabled = false;
        //        cmbUnidade.Editavel = ControleEdicao.Nunca;

        //        cmbLocal.Enabled = false;
        //        cmbLocal.Editavel = ControleEdicao.Nunca;

        //        cmbSetor.Enabled = false;
        //        cmbSetor.Editavel = ControleEdicao.Nunca;
        //    }
        //}

        private void ConfiguraDtg()
        {
            dtgMovimento.AutoGenerateColumns = false;
            dtgMovimento.Columns["colDtMov"].DataPropertyName = MovimentacaoDTO.FieldNames.DataMovimento;
            dtgMovimento.Columns["colDtMov"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            // dtgMovimento.Columns["colUnidade"].DataPropertyName = MovimentacaoDTO.FieldNames.DsUnidade;
            // dtgMovimento.Columns["colSetor"].DataPropertyName = MovimentacaoDTO.FieldNames.DsSetor;
            dtgMovimento.Columns["colSaldo"].DataPropertyName = MovimentacaoDTO.FieldNames.SaldoMovimento;
            dtgMovimento.Columns["colProduto"].DataPropertyName = MovimentacaoDTO.FieldNames.DsProduto;
            dtgMovimento.Columns[colMAV.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia;
            dtgMovimento.Columns["colQtdE"].DataPropertyName = MovimentacaoDTO.FieldNames.QtdeEntrada;
            dtgMovimento.Columns["colQtdS"].DataPropertyName = MovimentacaoDTO.FieldNames.QtdeSaida;
            //dtgMovimento.Columns["colTipo"].DataPropertyName = MovimentacaoDTO.FieldNames.;
            dtgMovimento.Columns["colSubTipo"].DataPropertyName = MovimentacaoDTO.FieldNames.DsSubtipoMov;
            dtgMovimento.Columns["colReqId"].DataPropertyName = MovimentacaoDTO.FieldNames.IdtRequisicao;
            dtgMovimento.Columns["colUsuario"].DataPropertyName = MovimentacaoDTO.FieldNames.DsUsuario;
            dtgMovimento.Columns["colSubTp"].DataPropertyName = MovimentacaoDTO.FieldNames.IdtSubTipo;
            dtgMovimento.Columns["colDtFat"].DataPropertyName = MovimentacaoDTO.FieldNames.DtFaturamento;
            dtgMovimento.Columns["colHrFat"].DataPropertyName = MovimentacaoDTO.FieldNames.HrFaturamento;
            dtgMovimento.Columns["colFlEstorno"].DataPropertyName = MovimentacaoDTO.FieldNames.FlEstornado;
            
            // dtgMovimento.Columns["colUsuarioEstorno"].DataPropertyName = MovimentacaoDTO.FieldNames.DsUsuarioEstorno;
        }

        private void CarregarProduto()
        {
            if (dtoMatMed != null)
            {
                lblProduto.Text = dtoMatMed.NomeFantasia.Value;
            }
            else
            {
                lblProduto.Text = "--";
            }            
        }

        private void CarregarCombos()
        {
            cmbUnidade.Carregaunidade();

            Array arrSubTipoNames = Enum.GetNames(typeof(MovimentacaoDTO.SubTipoMovimento));
            Array arrSubTipoValues = Enum.GetValues(typeof(MovimentacaoDTO.SubTipoMovimento));            
            Array.Sort(arrSubTipoNames, arrSubTipoValues);

            cmbSubTipoMov.DataSource = arrSubTipoValues;
            cmbSubTipoMov.IniciaLista();

            Array arrTipo = Enum.GetValues(typeof(MovimentacaoDTO.TipoMovimento));

            cmbTipoMov.DataSource = arrTipo;
            cmbTipoMov.IniciaLista();
        }

        private byte ObterValorTipoSelecionado()
        {
            return (byte)(MovimentacaoDTO.TipoMovimento)Enum.Parse(typeof(MovimentacaoDTO.TipoMovimento), cmbTipoMov.SelectedValue.ToString());
        }

        private byte ObterValorSubTipoSelecionado()
        {
            return (byte)(MovimentacaoDTO.SubTipoMovimento)Enum.Parse(typeof(MovimentacaoDTO.SubTipoMovimento), cmbSubTipoMov.SelectedValue.ToString());
        }

        private bool ValidarFilial()
        {
            if (!rbAcs.Checked && !rbHac.Checked)
            {
                MessageBox.Show("Selecione o estoque (HAC/ACS)", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void LimparProduto()
        {
            dtoMatMed = null;
            lblProduto.Text = "NENHUM PRODUTO SELECIONADO";
        }

        private void Pesquisar()
        {
            if (!ValidarFilial()) return;

            dtoMovimento = new MovimentacaoDTO();

            if (cmbUnidade.SelectedIndex != -1) dtoMovimento.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            if (cmbLocal.SelectedIndex != -1) dtoMovimento.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            if (cmbSetor.SelectedIndex != -1) dtoMovimento.IdtSetor.Value = cmbSetor.SelectedValue.ToString();

            if (txtAtdId.Text != string.Empty)
                dtoMovimento.IdtFilial.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();
            else if (rbHac.Checked)
            {
                dtoMovimento.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
            }
            else if (rbAcs.Checked)
            {
                dtoMovimento.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.ACS;
            }

            if (txtData.Text != string.Empty)
            {
                DateTime dt;
                if (!DateTime.TryParse(txtData.Text, out dt))
                {
                    MessageBox.Show("Data inválida", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtData.Focus();
                    return;
                }
                else
                {
                    dtoMovimento.DataMovimento.Value = txtData.Text;
                }  
            }

            if (txtNumPedido.Text != string.Empty) dtoMovimento.IdtRequisicao.Value = txtNumPedido.Text;
            if (cmbTipoMov.SelectedIndex != -1) dtoMovimento.IdtTipo.Value = ObterValorTipoSelecionado();
            if (cmbSubTipoMov.SelectedIndex != -1) dtoMovimento.IdtSubTipo.Value = ObterValorSubTipoSelecionado();

            if (!dtoMovimento.IdtSubTipo.Value.IsNull)
            {
                //Se movimento for referente a carrinho de emergencia e não for baixa no almoxarifado para ressuprimento de estoque,
                //filial sera de CARRINHO_EMERGENCIA
                if (cmbSubTipoMov.SelectedItem.ToString().IndexOf("CARRINHO") > -1 &&
                    dtoMovimento.IdtSubTipo.Value != (byte)MovimentacaoDTO.SubTipoMovimento.BAIXA_RESSUPRIMENTO_CARRINHO_EMERGENCIA)
                {
                    dtoMovimento.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
                }
            }            

            if (dtoMatMed != null)
            {
                if (!dtoMatMed.Idt.Value.IsNull) dtoMovimento.IdtProduto.Value = dtoMatMed.Idt.Value;
            }

            dtoMovimento.IdtAtendimento.Value = txtAtdId.Text;

            this.Cursor = Cursors.WaitCursor;            
            // dtgMovimento.DataSource = Movimento.Sel(dtoMovimento, false);
            dtgMovimento.DataSource = Movimento.ListaMovimentacao(dtoMovimento);
            ShowColums();
            this.Cursor = Cursors.Default;
        }

        #endregion

        #region EVENTOS

        private void FrmConsultaMovimento_Load(object sender, EventArgs e)
        {
            // txtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            LimparProduto();
            CarregarCombos();
            Generico.ConfiguraCombos(cmbUnidade, cmbLocal, cmbSetor, FrmPrincipal.dtoSeguranca);
            ConfiguraDtg();
            // ConfiguraCombos();
            tsHac.Items["tsBtnPesquisar"].Enabled = true;
            tsHac.Items["tsBtnMatMed"].Enabled = true;
        }

        private bool tsHac_MatMedClick(object sender)
        {
            MaterialMedicamentoDTO dtoMatMedAux = new MaterialMedicamentoDTO();
            
            dtoMatMedAux.TpPesquisa.Value = (int)MaterialMedicamentoDTO.TipoDePesquisa.SEM_ESTOQUE;
            dtoMatMedAux = FrmPesquisaMatMed.SelecionaMatMed(dtoMatMedAux);

            if (dtoMatMedAux != null)
            {
                if (!dtoMatMedAux.Idt.Value.IsNull)
                {
                    dtoMatMed = dtoMatMedAux;

                    this.CarregarProduto();
                }
            }

            return true;
        }

        private bool tsHac_PesquisarClick(object sender)
        {
            Pesquisar();
            return true;
        }

        private void cmbTipoMov_Leave(object sender, EventArgs e)
        {
            if (cmbTipoMov.SelectedIndex == -1) cmbTipoMov.IniciaLista();
        }

        private void cmbSubTipoMov_Leave(object sender, EventArgs e)
        {
            if (cmbSubTipoMov.SelectedIndex == -1) cmbSubTipoMov.IniciaLista();
        }

        private void cmbUnidade_Leave(object sender, EventArgs e)
        {
            if (cmbUnidade.SelectedIndex == -1) cmbUnidade.IniciaLista();
        }

        private void cmbLocal_Leave(object sender, EventArgs e)
        {
            //if (cmbLocal.SelectedIndex == -1) cmbLocal.IniciaLista();
        }

        private void cmbSetor_Leave(object sender, EventArgs e)
        {
            //if (cmbSetor.SelectedIndex == -1) cmbSetor.IniciaLista();
        }

        private void btnLimparProduto_Click(object sender, EventArgs e)
        {
            LimparProduto();
        }

        #endregion                

        private void hacLabel5_DoubleClick(object sender, EventArgs e)
        {
            dtgMovimento.Columns["colSubTp"].Visible = !(dtgMovimento.Columns["colSubTp"].Visible);
            dtgMovimento.Columns["colDtFat"].Visible = !(dtgMovimento.Columns["colDtFat"].Visible);
            dtgMovimento.Columns["colHrFat"].Visible = !(dtgMovimento.Columns["colHrFat"].Visible);
        }

        private void dtgMovimento_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dtgMovimento.Rows.Count > 0)
            {
                // acerto baixa
                if (dtgMovimento.Rows[e.RowIndex].Cells["colSubTp"].Value.ToString() == "30")
                {
                    dtgMovimento.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSeaGreen;
                } // acerto entrada
                else if (dtgMovimento.Rows[e.RowIndex].Cells["colSubTp"].Value.ToString() == "31")
                {
                    dtgMovimento.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
                } // cONSUMO NÃO FATURADO
                else if (dtgMovimento.Rows[e.RowIndex].Cells["colSubTp"].Value.ToString() == "18")
                {
                    dtgMovimento.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen ;
                } // ESTORNO NÃO FATURADO
                else if (dtgMovimento.Rows[e.RowIndex].Cells["colSubTp"].Value.ToString() == "13")
                {
                    dtgMovimento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                } // ESTORNO CONSUMO FATURADO
                else if (dtgMovimento.Rows[e.RowIndex].Cells["colSubTp"].Value.ToString() == "16")
                {
                    dtgMovimento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Salmon;
                }
            }
         }

        private void chkVerTodos_CheckedChanged(object sender, EventArgs e)
        {
            ShowColums();
        }

        private void ShowColums()
        {
            for (int i = 0; i < dtgMovimento.Rows.Count; i++)
            {
                try
                {
                    if (dtgMovimento.Rows[i].Cells["colFlEstorno"].Value.ToString() == "1")
                    {
                            dtgMovimento.Rows[i].Visible = (chkVerTodos.Checked ? true : false);
                    }
                    else if (dtgMovimento.Rows[i].Cells["colSubTp"].Value.ToString() == "34")
                    {
                        dtgMovimento.Rows[i].Visible = (chkVerTodos.Checked ? true : false);
                    }
                }
                catch (Exception ex)
                {

                }

            }

        }

    }
}