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
using HospitalAnaCosta.Framework;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Cadastro
{
    public partial class FrmCContabilGrupo : FrmBase
    {
        private bool _inclusao = false;
        private bool _novo = false;
        private bool _limpar = false;

        #region OBJETOS SERVIÇO

        private IContaContabilGrupo _ccontabilGrupo;
        public IContaContabilGrupo ContaContabilGrupo
        {
            get { return _ccontabilGrupo != null ? _ccontabilGrupo : _ccontabilGrupo = (IContaContabilGrupo)Global.Common.GetObject(typeof(IContaContabilGrupo)); }
        }

        private ISetor _setor;
        public ISetor Setor
        {
            get { return _setor != null ? _setor : _setor = (ISetor)Global.Common.GetObject(typeof(ISetor)); }
        }

        #endregion

        #region MÉTODOS

        private void ConfigGridGrupo()
        {
            dtgGrupo.AutoGenerateColumns = false;
            dtgGrupo.Columns[colGrupoIdt.Name].DataPropertyName = GrupoMatMedDTO.FieldNames.Idt;
            dtgGrupo.Columns[colDsGrupo.Name].DataPropertyName = GrupoMatMedDTO.FieldNames.DsGrupo;
            dtgGrupo.Columns[colDsContaCred.Name].DataPropertyName = ContaContabilGrupoDTO.FieldNames.ContaCreditoDescricao;
            dtgGrupo.Columns[colDsContaDeb.Name].DataPropertyName = ContaContabilGrupoDTO.FieldNames.ContaDebitoDescricao;
            dtgGrupo.Columns[colSetor.Name].DataPropertyName = SetorDTO.FieldNames.Descricao;
            dtgGrupo.Columns[colDataIni.Name].DataPropertyName = ContaContabilGrupoDTO.FieldNames.DataIni;
            dtgGrupo.Columns[colDataFim.Name].DataPropertyName = ContaContabilGrupoDTO.FieldNames.DataFim;
            dtgGrupo.Columns[colContaCredito.Name].DataPropertyName = ContaContabilGrupoDTO.FieldNames.ContaCredito;
            dtgGrupo.Columns[colContaDebito.Name].DataPropertyName = ContaContabilGrupoDTO.FieldNames.ContaDebito;
            dtgGrupo.Columns[colIdSetor.Name].DataPropertyName = ContaContabilGrupoDTO.FieldNames.IdSetor;
        }

        private void CarregaGrupo()
        {
            if ((rbHac.Checked || rbAcs.Checked) && (rbBaixa.Checked || rbQuebra.Checked))
            {
                this.Cursor = Cursors.WaitCursor;
                ContaContabilGrupoDTO dtoContaContabilGrupo = new ContaContabilGrupoDTO();
                dtoContaContabilGrupo.CodColigada.Value = new Generico().RetornaFilial(rbHac, rbAcs);
                dtoContaContabilGrupo.TipoMov.Value = rbBaixa.Checked ? "B" : "Q";
                //dtgGrupo.ClearSelection();
                dtgGrupo.DataSource = ContaContabilGrupo.Listar(dtoContaContabilGrupo, 1);
                this.Cursor = Cursors.Default;
            }
            //else
            //{
            //    MessageBox.Show("Selecione o tipo de movimento e a filial.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        private void RotinaNovo()
        {
            cmbUnidade.Enabled = cmbLocal.Enabled = cmbSetor.Enabled = txtDataInicio.Enabled = txtDataFinal.Enabled = _inclusao = true;
            btnNovo.Enabled = false;
            cmbUnidade.LimparCmbUnidade();
            txtDataInicio.Text = txtDataFinal.Text = txtContaCredito.Text = txtContaDebito.Text = string.Empty;
            lblContaCredito.Text = string.Empty;
            lblContaDebito.Text = string.Empty;
        }

        private bool ValidarDatas()
        {
            DateTime dt;
            if (!DateTime.TryParse(txtDataInicio.Text, out dt))
            {
                MessageBox.Show("Data início inválida.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDataInicio.Focus();
                return false;
            }
            if (txtDataFinal.Text != string.Empty)
            {
                if (!DateTime.TryParse(txtDataFinal.Text, out dt))
                {
                    MessageBox.Show("Data final inválida.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDataFinal.Focus();
                    return false;
                }
                if (Convert.ToDateTime(txtDataInicio.Text) > Convert.ToDateTime(txtDataFinal.Text))
                {
                    MessageBox.Show("A data inicial não pode ser maior que a data final.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDataFinal.Focus();
                    return false;
                }
            }
            return true;
        }

        #endregion
     
        #region EVENTOS

        public FrmCContabilGrupo()
        {
            InitializeComponent();
        }

        private void FrmCContabilGrupo_Load(object sender, EventArgs e)
        {
            ConfigGridGrupo();
            CarregaGrupo();
            cmbUnidade.Carregaunidade();
        }

        private void rbBaixa_Click(object sender, EventArgs e)
        {
            CarregaGrupo();
        }

        private void rbQuebra_Click(object sender, EventArgs e)
        {
            CarregaGrupo();
        }

        private void rbHac_Click(object sender, EventArgs e)
        {
            CarregaGrupo();
        }

        private void rbAcs_Click(object sender, EventArgs e)
        {
            CarregaGrupo();
        }

        private void dtgGrupo_SelectionChanged(object sender, EventArgs e)
        {
            if (!_novo && !_limpar)
            {
                lblGrupo.Text = string.Empty;
                lblContaCredito.Text = string.Empty;
                lblContaDebito.Text = string.Empty;
                this.Cursor = Cursors.WaitCursor;
                lblGrupo.Text = "GRUPO: " + dtgGrupo.CurrentRow.Cells[colDsGrupo.Name].Value.ToString();
                if (!string.IsNullOrEmpty(dtgGrupo.CurrentRow.Cells[colContaCredito.Name].Value.ToString()))
                {
                    if (dtgGrupo.CurrentRow.Cells[colIdSetor.Name].Value.ToString() != "0" &&
                    !string.IsNullOrEmpty(dtgGrupo.CurrentRow.Cells[colIdSetor.Name].Value.ToString()))
                    {
                        SetorDTO dtoSetor = new SetorDTO();
                        dtoSetor.Idt.Value = dtgGrupo.CurrentRow.Cells[colIdSetor.Name].Value.ToString();
                        dtoSetor = Setor.SelChave(dtoSetor);
                        cmbUnidade.SelectedValue = dtoSetor.IdtUnidade.Value;
                        cmbLocal.SelectedValue = dtoSetor.IdtLocalAtendimento.Value;
                        cmbSetor.SelectedValue = dtoSetor.Idt.Value;
                    }
                    else
                    {
                        cmbUnidade.LimparCmbUnidade();
                    }
                    txtDataInicio.Text = DateTime.Parse(dtgGrupo.CurrentRow.Cells[colDataIni.Name].Value.ToString()).ToString("dd/MM/yyyy");
                    txtDataFinal.Text = string.Empty;
                    if (!string.IsNullOrEmpty(dtgGrupo.CurrentRow.Cells[colDataFim.Name].Value.ToString()))
                        txtDataFinal.Text = DateTime.Parse(dtgGrupo.CurrentRow.Cells[colDataFim.Name].Value.ToString()).ToString("dd/MM/yyyy");
                    txtContaCredito.Text = dtgGrupo.CurrentRow.Cells[colContaCredito.Name].Value.ToString();
                    lblContaCredito.Text = dtgGrupo.CurrentRow.Cells[colDsContaCred.Name].Value.ToString();
                    txtContaDebito.Text = dtgGrupo.CurrentRow.Cells[colContaDebito.Name].Value.ToString();
                    lblContaDebito.Text = dtgGrupo.CurrentRow.Cells[colDsContaDeb.Name].Value.ToString();

                    txtDataFinal.Enabled = true;
                    //if (txtDataFinal.Text != string.Empty) txtDataFinal.Enabled = false;
                    cmbUnidade.Enabled = cmbLocal.Enabled = cmbSetor.Enabled = txtDataInicio.Enabled =
                    _inclusao = false;
                    btnNovo.Enabled = true;
                }
                else
                {
                    RotinaNovo();
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void dtgGrupo_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //lblGrupo.Text = string.Empty;
            //lblContaCredito.Text = string.Empty;
            //lblContaDebito.Text = string.Empty;
            //if (e.RowIndex >= 0)
            //{
            //    this.Cursor = Cursors.WaitCursor;
            //    lblGrupo.Text = "GRUPO: " + dtgGrupo.Rows[e.RowIndex].Cells[colDsGrupo.Name].Value.ToString();
            //    if (!string.IsNullOrEmpty(dtgGrupo.Rows[e.RowIndex].Cells[colContaCredito.Name].Value.ToString()))
            //    {
            //        if (dtgGrupo.Rows[e.RowIndex].Cells[colIdSetor.Name].Value.ToString() != "0" &&
            //        !string.IsNullOrEmpty(dtgGrupo.Rows[e.RowIndex].Cells[colIdSetor.Name].Value.ToString()))
            //        {
            //            SetorDTO dtoSetor = new SetorDTO();
            //            dtoSetor.Idt.Value = dtgGrupo.Rows[e.RowIndex].Cells[colIdSetor.Name].Value.ToString();
            //            dtoSetor = Setor.SelChave(dtoSetor);
            //            cmbUnidade.SelectedValue = dtoSetor.IdtUnidade.Value;
            //            cmbLocal.SelectedValue = dtoSetor.IdtLocalAtendimento.Value;
            //            cmbSetor.SelectedValue = dtoSetor.Idt.Value;
            //        }
            //        else
            //        {
            //            cmbUnidade.LimparCmbUnidade();
            //        }
            //        txtDataInicio.Text = DateTime.Parse(dtgGrupo.Rows[e.RowIndex].Cells[colDataIni.Name].Value.ToString()).ToString("dd/MM/yyyy");
            //        txtDataFinal.Text = string.Empty;
            //        if (!string.IsNullOrEmpty(dtgGrupo.Rows[e.RowIndex].Cells[colDataFim.Name].Value.ToString()))
            //            txtDataFinal.Text = DateTime.Parse(dtgGrupo.Rows[e.RowIndex].Cells[colDataFim.Name].Value.ToString()).ToString("dd/MM/yyyy");
            //        txtContaCredito.Text = dtgGrupo.Rows[e.RowIndex].Cells[colContaCredito.Name].Value.ToString();
            //        txtContaDebito.Text = dtgGrupo.Rows[e.RowIndex].Cells[colContaDebito.Name].Value.ToString();

            //        if (txtDataFinal.Text != string.Empty) txtDataFinal.Enabled = false;
            //        cmbUnidade.Enabled = cmbLocal.Enabled = cmbSetor.Enabled = txtDataInicio.Enabled =
            //        _inclusao = false;
            //        btnNovo.Enabled = true;
            //    }
            //    else
            //    {
            //        RotinaNovo();
            //    }
            //    this.Cursor = Cursors.Default;
            //}
        }

        private bool tsHac_SalvarClick(object sender)
        {
            if (!ValidarDatas()) return false;

            ContaContabilGrupoDTO dtoContaContabilGrupo = new ContaContabilGrupoDTO();
            dtoContaContabilGrupo.IdGrupo.Value = dtgGrupo.SelectedRows[0].Cells[colGrupoIdt.Name].Value.ToString();
            dtoContaContabilGrupo.CodColigada.Value = new Generico().RetornaFilial(rbHac, rbAcs);
            dtoContaContabilGrupo.TipoMov.Value = rbBaixa.Checked ? "B" : "Q";
            dtoContaContabilGrupo.IdSetor.Value = 0;
            if (cmbSetor.SelectedIndex > -1 && !string.IsNullOrEmpty(cmbSetor.Text))
                dtoContaContabilGrupo.IdSetor.Value = cmbSetor.SelectedValue.ToString();

            #region Validar período da vigência
            DataTable dtbCCG = ContaContabilGrupo.Listar(dtoContaContabilGrupo, 0);
            DataTable dtbValida;
            if (_inclusao)
            {
                //Verifica vigência da Data Inicial
                dtbValida = (DataTable)BasicFunctions.ValidarVigencia(DateTime.Parse(txtDataInicio.Text),
                                                                      ContaContabilGrupoDTO.FieldNames.DataIni,
                                                                      ContaContabilGrupoDTO.FieldNames.DataFim,
                                                                      dtbCCG);
                if (dtbValida.Rows.Count > 0)
                {
                    MessageBox.Show("Já existe registro deste grupo com esta vigência", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                //Verifica vigência da Data Final
                dtbValida = (DataTable)BasicFunctions.ValidarVigencia(txtDataFinal.Text != string.Empty ? DateTime.Parse(txtDataFinal.Text) : DateTime.Now.AddYears(100),
                                                                      ContaContabilGrupoDTO.FieldNames.DataIni,
                                                                      ContaContabilGrupoDTO.FieldNames.DataFim,
                                                                      dtbCCG);
                if (dtbValida.Rows.Count > 0)
                {
                    MessageBox.Show("Já existe registro deste grupo com esta vigência", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            else
            {
                //Verifica vigência da Data Final
                dtbValida = (DataTable)BasicFunctions.ValidarVigencia(txtDataFinal.Text != string.Empty ? DateTime.Parse(txtDataFinal.Text) : DateTime.Now.AddYears(100),
                                                                      ContaContabilGrupoDTO.FieldNames.DataIni,
                                                                      ContaContabilGrupoDTO.FieldNames.DataFim,
                                                                      dtbCCG);
                if (dtbValida.Rows.Count > 0 && //Não compara ao original
                    DateTime.Parse(dtbValida.Rows[0][ContaContabilGrupoDTO.FieldNames.DataIni].ToString()) != DateTime.Parse(txtDataInicio.Text)) 
                {
                    MessageBox.Show("Já existe registro deste grupo com esta vigência", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            #endregion

            dtoContaContabilGrupo.DataIni.Value = txtDataInicio.Text;
            dtoContaContabilGrupo.DataFim.Value = txtDataFinal.Text;
            dtoContaContabilGrupo.ContaCredito.Value = txtContaCredito.Text;
            dtoContaContabilGrupo.ContaCreditoDescricao.Value = lblContaCredito.Text;
            dtoContaContabilGrupo.ContaDebito.Value = txtContaDebito.Text;
            dtoContaContabilGrupo.ContaDebitoDescricao.Value = lblContaDebito.Text;

            dtoContaContabilGrupo.IdUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

            if (_inclusao)
                ContaContabilGrupo.Incluir(dtoContaContabilGrupo);
            else
                ContaContabilGrupo.Alterar(dtoContaContabilGrupo);

            _inclusao = false;
            CarregaGrupo();
            MessageBox.Show("Registro salvo com sucesso.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return false;
        }

        private bool tsHac_LimparClick(object sender)
        {
            _limpar = true;
            RotinaNovo();
            lblGrupo.Text = string.Empty;            
            return true;
        }

        private void tsHac_AfterLimpar(object sender)
        {
            _limpar = false;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            _novo = true;
            RotinaNovo();
            _novo = false;
        }

        private void txtConta_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(((TextBox)sender).Text))
            {
                string contaDsc = ContaContabilGrupo.ObterDescricaoContaRM(((TextBox)sender).Text);
                if (string.IsNullOrEmpty(contaDsc))
                {
                    MessageBox.Show("Favor digitar uma conta existente no RM", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
                else
                {
                    if (((TextBox)sender).Name == txtContaCredito.Name)
                        lblContaCredito.Text = contaDsc.ToUpper();

                    if (((TextBox)sender).Name == txtContaDebito.Name)
                        lblContaDebito.Text = contaDsc.ToUpper();
                }
            }
            else
            {
                if (((TextBox)sender).Name == txtContaCredito.Name)
                    lblContaCredito.Text = string.Empty;

                if (((TextBox)sender).Name == txtContaDebito.Name)
                    lblContaDebito.Text = string.Empty;
            }
        }

        #endregion        
    }
}