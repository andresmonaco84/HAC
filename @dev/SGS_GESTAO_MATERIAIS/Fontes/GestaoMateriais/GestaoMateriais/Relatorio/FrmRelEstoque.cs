using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Reporting.WinForms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using Microsoft.ReportingServices.ReportRendering;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Relatorio
{
    public partial class FrmRelEstoque : FrmBase
    {
        private bool _divergeCont1;
        public bool DivergenciaContagem_1
        {
            set { _divergeCont1 = value; }
            get { return _divergeCont1; }
        }

        private bool _divergeCont2;
        public bool DivergenciaContagem_2
        {
            set { _divergeCont2 = value; }
            get { return _divergeCont2; }
        }

        private bool _divergeCont3;
        public bool DivergenciaContagem_3
        {
            set { _divergeCont3 = value; }
            get { return _divergeCont3; }
        }

        private bool _digitacaoFim;
        public bool DigitacaoFinal
        {
            set { _digitacaoFim = value; }
            get { return _digitacaoFim; }
        }

        private bool _demonstrativoCont;
        public bool DemonstrativoContagem
        {
            set { _demonstrativoCont = value; }
            get { return _demonstrativoCont; }
        }

        public FrmRelEstoque()
        {
            InitializeComponent();
        }

        #region OBJETOS SERVIÇOS

        // Setor                  
        private ISetor _isetor;
        private ISetor Setor
        {
            get { return _isetor != null ? _isetor : _isetor = (ISetor)Global.Common.GetObject(typeof(ISetor)); }
        }

        // GrupoMatMed        
        private IGrupoMatMed _grupoMatMed;
        private IGrupoMatMed GrupoMatMed
        {
            get { return _grupoMatMed != null ? _grupoMatMed : _grupoMatMed = (IGrupoMatMed)Global.Common.GetObject(typeof(IGrupoMatMed)); }
        }

        private IInventarioMatMed _inventarioMatMed;
        private IInventarioMatMed InventarioMatMed
        {
            get { return _inventarioMatMed != null ? _inventarioMatMed : _inventarioMatMed = (IInventarioMatMed)Global.Common.GetObject(typeof(IInventarioMatMed)); }
        }

        private IEstoqueLocal _estoque;
        private IEstoqueLocal Estoque
        {
            get { return _estoque != null ? _estoque : _estoque = (IEstoqueLocal)Global.Common.GetObject(typeof(IEstoqueLocal)); }
        }

        #endregion

        #region MÉTODOS

        private bool ValidarData()
        {
            if (txtData.Text == string.Empty)
            {
                MessageBox.Show("Data deve ser preenchida", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtData.Focus();
                return false;
            }
            DateTime dt;
            if (!DateTime.TryParse(txtData.Text, out dt))
            {
                MessageBox.Show("Data inválida", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtData.Focus();
                return false;
            }
            return true;
        }

        private void ExecRelatorio()
        {
            Microsoft.Reporting.WinForms.ReportParameter[] reportParam = new Microsoft.Reporting.WinForms.ReportParameter[16];
            string nomeRelatorio = "GM_04_INVENTARIO_PRODUTOS_ESTOQUE";
            if (rbMedSimilar.Checked)
            { nomeRelatorio = "GM_19_INVENTARIO_MEDICAMENTOS"; }
            else
            {
                if (DivergenciaContagem_1 || DivergenciaContagem_2 || DivergenciaContagem_3)
                    nomeRelatorio = "GM_05_INVENTARIO_DIVERGE_CONTAGEM";
                else if (DigitacaoFinal)
                    nomeRelatorio = "GM_06_INVENTARIO_DIGITA_FIM";
                else if (DemonstrativoContagem && !chbGrupo.Checked && !chbComLote.Checked)
                    nomeRelatorio = "GM_07_INVENTARIO_X_ESTOQUE";
                else if (DemonstrativoContagem && chbGrupo.Checked)
                    nomeRelatorio = "GM_09_INVENTARIO_X_ESTOQUE_GRUPO";
                else if (DemonstrativoContagem && chbComLote.Checked)
                    nomeRelatorio = "GM_39_INVENT_X_ESTOQUE_LOTE";
            }

            #region Monta Parâmetros
            byte x = 0;
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_FILIAL_ID", rbHac.Checked ? ((byte)FilialMatMedDTO.Filial.HAC).ToString() :
                                                                                                       rbAcs.Checked ? ((byte)FilialMatMedDTO.Filial.ACS).ToString() :
                                                                                                       rbConsig.Checked ? ((byte)FilialMatMedDTO.Filial.CONSIGNADO).ToString() :
                                                                                                       ((byte)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA).ToString());
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_SET_ID", cmbSetor.SelectedValue.ToString()); cmbUnidade.Focus();
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("UNIDADE", cmbUnidade.SelectedText); cmbSetor.Focus();
            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("SETOR", cmbSetor.SelectedText);
            if (!DemonstrativoContagem)
            {
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("FILIAL", rbHac.Checked ? "HOSPITAL ANA COSTA" : rbAcs.Checked ? "PLANO ACS" : rbConsig.Checked ? "CONSIGNADOS" : "CARRO EMERGÊNCIA");
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("USUARIO", FrmPrincipal.dtoSeguranca.Login.Value);
                if (!DivergenciaContagem_1 && !DivergenciaContagem_2 && !DivergenciaContagem_3 && !DigitacaoFinal)
                {
                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_UNI_ID_UNIDADE", cmbUnidade.SelectedValue.ToString());
                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_LAT_ID_LOCAL_ATENDIMENTO", cmbLocal.SelectedValue.ToString()); cmbLocal.Focus();
                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("LOCAL", cmbLocal.SelectedText);
                    if (!rbMedSimilar.Checked)
                    {
                        if (rbApenasMateriais.Checked)
                            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PTIS_MED_CD_TABELAMEDICA", ((byte)MaterialMedicamentoDTO.TipoMatMed.MATERIAL).ToString());
                        else if (rbApenasMedicamentos.Checked)
                            reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PTIS_MED_CD_TABELAMEDICA", ((byte)MaterialMedicamentoDTO.TipoMatMed.MEDICAMENTO).ToString());
                    }
                    else
                    {
                        reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pAGRUPA_SIMILAR_MED", "1");
                    }
                }
                else
                {
                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_DT_INVENTARIO", txtData.Text);
                    if (DivergenciaContagem_1)
                        reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PDIVERGENCIA_CONTAGEM_1", "1");
                    else if (DivergenciaContagem_2 || DivergenciaContagem_3)
                        reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter(DivergenciaContagem_2 ? "PDIVERGENCIA_CONTAGEM_2" : "PDIVERGENCIA_CONTAGEM_3", "1");
                }
                if (!DigitacaoFinal)
                {
                    SetorDTO dtoSetor = new SetorDTO();
                    dtoSetor.Idt.Value = cmbSetor.SelectedValue.ToString();
                    dtoSetor = Setor.SelChave(dtoSetor);
                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("CENTRO_DISPENSACAO", dtoSetor.SubstituiAlmoxarifado.Value == "S" || dtoSetor.FlAlmoxCentral.Value == (byte)SetorDTO.AlmoxarifadoCentral.SIM ? true.ToString() : false.ToString());
                }
                if (DivergenciaContagem_1 || DivergenciaContagem_2 || DivergenciaContagem_3 || DigitacaoFinal)
                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PFL_MEDICAMENTO", rbApenasMedicamentos.Checked ? "1" : "0");

                if (cmbGrupo.Visible && cmbGrupo.SelectedIndex > -1)
                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_GRUPO_ID", cmbGrupo.SelectedValue.ToString());
            }
            else
            {
                //DemonstrativoContagem
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_DT_INVENTARIO", txtData.Text);
                if (cmbGrupo.SelectedIndex > -1 && !chbGrupo.Checked)
                    reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("PCAD_MTMD_GRUPO_ID", cmbGrupo.SelectedValue.ToString());
            }

            if ((nomeRelatorio == "GM_04_INVENTARIO_PRODUTOS_ESTOQUE" || DivergenciaContagem_1 || DivergenciaContagem_2 || DivergenciaContagem_3) && chbOrdenarEnd.Visible && chbOrdenarEnd.Checked)
                reportParam[x++] = new Microsoft.Reporting.WinForms.ReportParameter("pORDENAR_ENDERECO", "1");

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
            tsHac.Focus();
        }

        //Validar se setor usar estoque compartilhado (task 40478)
        private bool ValidarEstoqueCompartilhado()
        {
            if ((rbHac.Checked || rbAcs.Checked || rbCE.Checked || rbConsig.Checked) && cmbSetor.SelectedIndex != -1)
            {
                EstoqueLocalDTO dtoEstoque = new EstoqueLocalDTO();
                dtoEstoque.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                dtoEstoque.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                dtoEstoque.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                if (rbHac.Checked)
                    dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
                else if (rbAcs.Checked)
                    dtoEstoque.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.ACS;
                else if (rbCE.Checked)
                    dtoEstoque.IdtFilial.Value = (int)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
                else if (rbConsig.Checked)
                    dtoEstoque.IdtFilial.Value = (int)FilialMatMedDTO.Filial.CONSIGNADO;

                this.Cursor = Cursors.WaitCursor;
                int idSetorEstoque = Estoque.EstoqueDeConsumo(dtoEstoque);
                this.Cursor = Cursors.Default;

                if (idSetorEstoque != int.Parse(cmbSetor.SelectedValue.ToString()))
                {
                    SetorDTO dtoSetor = new SetorDTO();
                    dtoSetor.Idt.Value = idSetorEstoque;
                    MessageBox.Show("Este Setor/Estoque não pode ser selecionado, pois utiliza o estoque do(a) " + Setor.SelChave(dtoSetor).Descricao.Value, "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSetor.SelectedIndex = -1;
                    rbHac.Checked = rbAcs.Checked = rbCE.Checked = rbConsig.Checked = false;
                    return false;
                }
            }
            return true;
        }

        private void SugerirData()
        {
            txtData.Text = string.Empty;
            if (cmbSetor.SelectedIndex > -1 && cmbSetor.SelectedValue != null)
            {
                this.Cursor = Cursors.WaitCursor;
                InventarioMatMedDTO dto = new InventarioMatMedDTO();
                dto.IdFilial.Value = new Generico().RetornaFilial(rbHac, rbAcs, rbCE, rbConsig);
                if (dto.IdFilial.Value == 0) dto.IdFilial.Value = 1; //HAC
                dto.IdSetor.Value = cmbSetor.SelectedValue.ToString();
                if (cmbGrupo.SelectedIndex > -1) dto.IdtGrupo.Value = cmbGrupo.SelectedValue.ToString();
                InventarioMatMedDataTable dtb = InventarioMatMed.ListarControle(dto);
                if (dtb.Rows.Count > 0)
                    txtData.Text = DateTime.Parse(dtb.TypedRow(0).DataInventario.Value.ToString()).ToString("dd/MM/yyyy");
                this.Cursor = Cursors.Default;
            }
        }

        private void CarregarGrupo()
        {
            lblGrupo.Visible = true;
            cmbGrupo.Visible = true;
            cmbGrupo.DataSource = GrupoMatMed.Sel(new GrupoMatMedDTO());
            cmbGrupo.IniciaLista();
        }

        #endregion

        private void FrmRelEstoque_Load(object sender, EventArgs e)
        {
            chbOrdenarEnd.Visible = false;
            if (DivergenciaContagem_1 || DivergenciaContagem_2 || DivergenciaContagem_3 || DigitacaoFinal || DemonstrativoContagem)
            {
                gbMatMed.Visible = false;
                if (!DemonstrativoContagem)
                {
                    gbMatMed.Visible = true;
                    rbTodos.Enabled = rbMedSimilar.Enabled = false;
                    rbApenasMateriais.Checked = true;
                }
                lblData.Visible = true;
                txtData.Visible = true;

                if (DivergenciaContagem_1)
                    tsHac.TituloTela = "Divergências na 1° contagem";
                else if (DivergenciaContagem_2)
                    tsHac.TituloTela = "Divergências na 2° contagem";
                else if (DivergenciaContagem_3)
                    tsHac.TituloTela = "Divergências na 3° contagem";
                else if (DigitacaoFinal)
                    tsHac.TituloTela = "Relatório de digitação final";
                else if (DemonstrativoContagem)
                {
                    tsHac.TituloTela = "Demonstrativo da contagem efetuada";
                    CarregarGrupo();
                    chbGrupo.Visible = chbComLote.Visible = true;
                }
                if (!DigitacaoFinal)
                    CarregarGrupo();
            }
            else
                CarregarGrupo();

            cmbUnidade.Carregaunidade();
            rbHac.Checked = true;
        }

        private bool tsHac_PesquisarClick(object sender)
        {
            if (cmbUnidade.SelectedIndex == -1 || cmbLocal.SelectedIndex == -1 || cmbSetor.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione Unidade/Local/Setor antes de pesquisar", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (!rbAcs.Checked && !rbHac.Checked && !rbCE.Checked && !rbConsig.Checked)
            {
                MessageBox.Show("Selecione o estoque (HAC / CE / CONSIGNADO)", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (DivergenciaContagem_1 || DivergenciaContagem_2 || DivergenciaContagem_3 || DigitacaoFinal || DemonstrativoContagem) { if (!ValidarData()) return false; }
            if (DivergenciaContagem_1 || DivergenciaContagem_2 || DivergenciaContagem_3)
            {
                InventarioMatMedDTO dtoInv = new InventarioMatMedDTO();
                dtoInv.IdSetor.Value = cmbSetor.SelectedValue.ToString();
                dtoInv.IdFilial.Value = new Generico().RetornaFilial(rbHac, rbAcs, rbCE, rbConsig);
                dtoInv.DataInventario.Value = txtData.Text;
                if (rbApenasMedicamentos.Checked)
                    dtoInv.FlMedicamento.Value = 1;
                else
                    dtoInv.FlMedicamento.Value = 0;
                InventarioMatMedDataTable dtbInv = InventarioMatMed.ListarControle(dtoInv);
                if (dtbInv.Rows.Count == 0)
                {
                    MessageBox.Show("Inventário inexistente nesta data", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //if (DivergenciaContagem_1 && decimal.Parse(dtbInv.TypedRow(0).Fechamento.Value.ToString()) < 1)
                //{
                //    MessageBox.Show("Contagem número 1 precisa ser fechada para este relatório ficar disponível", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return false;
                //}
                //else if (DivergenciaContagem_2 && decimal.Parse(dtbInv.TypedRow(0).Fechamento.Value.ToString()) < 2)
                //{
                //    MessageBox.Show("Contagem número 2 precisa ser fechada para este relatório ficar disponível", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return false;
                //}
                //else if (DivergenciaContagem_3 && decimal.Parse(dtbInv.TypedRow(0).Fechamento.Value.ToString()) < 3)
                //{
                //    MessageBox.Show("Contagem número 3 precisa ser fechada para este relatório ficar disponível", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return false;
                //}
            }
            ExecRelatorio();
            return false;
        }

        private bool tsHac_LimparClick(object sender)
        {
            rbConsig.Enabled = true;
            return true;
        }

        private void tsHac_AfterLimpar(object sender)
        {
            rbTodos.Checked = true;
        }

        private void chbGrupo_Click(object sender, EventArgs e)
        {
            cmbGrupo.IniciaLista();
            if (chbGrupo.Checked)
            {
                cmbGrupo.Enabled = false;
                chbComLote.Visible = chbComLote.Checked = false;
            }
            else
            {
                cmbGrupo.Enabled = true;
                chbComLote.Visible = true;
            }
        }

        private void chbComLote_Click(object sender, EventArgs e)
        {
            if (chbComLote.Checked)
            {
                chbGrupo.Checked = false;
                rbConsig.Checked = false;
                rbConsig.Enabled = false;
            }
            else
                rbConsig.Enabled = true;
        }

        private void cmbGrupo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbGrupo.SelectedIndex > -1)
            {
                chbGrupo.Checked = false;
                SugerirData();
            }
        }

        private void rbMedSimilar_Click(object sender, EventArgs e)
        {
            if (rbMedSimilar.Checked)
            {
                chbOrdenarEnd.Visible = chbOrdenarEnd.Checked = false;
            }
            else if (gbMatMed.Visible && cmbSetor.SelectedIndex > -1)
            {
                chbOrdenarEnd.Visible = false;

                this.Cursor = Cursors.WaitCursor;
                SetorDTO dtoSetor = new SetorDTO();
                dtoSetor.Idt.Value = cmbSetor.SelectedValue.ToString();
                dtoSetor = Setor.SelChave(dtoSetor);
                this.Cursor = Cursors.Default;

                if (dtoSetor.FlAlmoxCentral.Value == (byte)SetorDTO.AlmoxarifadoCentral.SIM || (int)dtoSetor.Idt.Value == 2592) //2592 = Farmacia Central
                    chbOrdenarEnd.Visible = true;
            }
        }

        private void chbOrdenarEnd_Click(object sender, EventArgs e)
        {
            if (chbOrdenarEnd.Checked && rbMedSimilar.Checked)
                rbTodos.Checked = true;
        }

        private void cmbSetor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            chbOrdenarEnd.Visible = false;
            if (!DigitacaoFinal && cmbSetor.SelectedIndex > -1 && ((DivergenciaContagem_1 || DivergenciaContagem_2 || DivergenciaContagem_3) || (gbMatMed.Visible && !rbMedSimilar.Checked)))
            {
                this.Cursor = Cursors.WaitCursor;
                SetorDTO dtoSetor = new SetorDTO();
                dtoSetor.Idt.Value = cmbSetor.SelectedValue.ToString();
                dtoSetor = Setor.SelChave(dtoSetor);
                this.Cursor = Cursors.Default;

                if (dtoSetor.FlAlmoxCentral.Value == (byte)SetorDTO.AlmoxarifadoCentral.SIM || (int)dtoSetor.Idt.Value == 2592) //2592 = Farmacia Central
                    chbOrdenarEnd.Visible = true;
            }
            rbEstoque_Click(sender, e);
            SugerirData();
        }

        private void rbEstoque_Click(object sender, EventArgs e)
        {
            if (!DemonstrativoContagem && !DigitacaoFinal) ValidarEstoqueCompartilhado();
            SugerirData();
        }
    }
}