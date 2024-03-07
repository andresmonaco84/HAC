using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Seguranca.Forms;
using HospitalAnaCosta.Framework;
using HacFramework.Windows.Helpers;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Cadastro
{
    public partial class FrmDoencaDiagnostico : FrmBase
    {
        private bool _itemModificado = false;
        private bool _itemNovo = false;

        private DoencaDiagnosticoDTO dtoDoDi;
        private static IDoencaDiagnostico _dodi;
        private static IDoencaDiagnostico DoencaDiagnostico
        {
            get { return _dodi != null ? _dodi : _dodi = (IDoencaDiagnostico)Global.Common.GetObject(typeof(IDoencaDiagnostico)); }
        }

        private IPrescricao _prescricao;
        private IPrescricao Prescricao
        {
            get { return _prescricao != null ? _prescricao : _prescricao = (IPrescricao)Global.Common.GetObject(typeof(IPrescricao)); }
        }

        public static DoencaDiagnosticoDTO Carregar(DoencaDiagnosticoDTO dto, out bool selecionarNovoItem, out bool itemModificado)
        {
            FrmDoencaDiagnostico frm = new FrmDoencaDiagnostico();
            frm.dtoDoDi = dto;
            //frm.MdiParent = FrmPrincipal.ActiveForm;
            frm.ShowDialog();
            selecionarNovoItem = frm.cbSelecionar.Checked;
            itemModificado = frm._itemModificado;
            return frm.dtoDoDi;
        }

        public FrmDoencaDiagnostico()
        {
            InitializeComponent();
        }

        private void CarregarCombo()
        {
            cmbDoDi.ValueMember = DoencaDiagnosticoDTO.FieldNames.Id;
            cmbDoDi.DisplayMember = DoencaDiagnosticoDTO.FieldNames.Descricao;

            DoencaDiagnosticoDTO dto = new DoencaDiagnosticoDTO();
            dto.Tipo.Value = dtoDoDi.Tipo.Value;
            cmbDoDi.DataSource = DoencaDiagnostico.Listar(dto);
            cmbDoDi.IniciaLista();
        }

        private void FrmDoencaDiagnostico_Load(object sender, EventArgs e)
        {
            CarregarCombo();
            if (dtoDoDi.Tipo.Value == "DO")
            {
                tsHac.TituloTela = "Cadastro de Doença de Base";
                lblDoDi.Text = "Doença:";
            }
            else if (dtoDoDi.Tipo.Value == "DI")
            {
                tsHac.TituloTela = "Cadastro de Diagnóstico Infeccioso";
                lblDoDi.Text = "Diagnóstico:";
            }
            //cmbDoDi_SelectionChangeCommitted(sender, e);
        }

        private void FrmDoencaDiagnostico_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((_itemModificado || !_itemNovo) && !cbSelecionar.Checked)
                dtoDoDi = null;
        }   

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (cmbDoDi.SelectedIndex > -1)
            {
                PrescricaoDTO dtoPrc = new PrescricaoDTO();
                dtoPrc.IdDoencaDiagnostico.Value = cmbDoDi.SelectedValue.ToString();
                DataTable dtb = Prescricao.ListarDoencaDiagnostico(dtoPrc, dtoDoDi);
                if (dtb.Rows.Count == 0)
                {
                    dtoDoDi.Id.Value = cmbDoDi.SelectedValue.ToString();
                    DoencaDiagnostico.Excluir(dtoDoDi);
                    
                    _itemModificado = true;                    
                    tsHac_NovoClick(sender);
                    txtDoDi.Text = string.Empty;
                    CarregarCombo();
                }
                else
                    MessageBox.Show("Registro já associado a uma ou mais prescrições!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Nenhum registro selecionado!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private bool tsHac_SalvarClick(object sender)
        {
            if (cmbDoDi.SelectedIndex > -1)
                dtoDoDi.Id.Value = cmbDoDi.SelectedValue.ToString();
            dtoDoDi.Descricao.Value = txtDoDi.Text;
            dtoDoDi.IdUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
            dtoDoDi = DoencaDiagnostico.Gravar(dtoDoDi);

            if (cmbDoDi.SelectedIndex == -1)
            {
                _itemNovo = _itemModificado = true;
                this.Close();
            }
            else
            {
                _itemModificado = true;
                tsHac_NovoClick(sender);
                txtDoDi.Text = string.Empty;
                CarregarCombo();
            }

            return default(bool);
        }

        private bool tsHac_NovoClick(object sender)
        {
            dtoDoDi.Id.Value = new Framework.DTO.TypeDecimal();
            //cmbDoDi.SelectedIndex == -1;            
            return true;
        }

        private bool tsHac_AfterNovo(object sender)
        {
            //cbSelecionar.Visible = true;
            txtDoDi.Focus();
            return true;
        }

        private bool tsHac_CancelarClick(object sender)
        {
            dtoDoDi.Id.Value = new Framework.DTO.TypeDecimal();
            return true;
        }

        private void tsHac_AfterCancelar(object sender)
        {
            //cmbDoDi_SelectionChangeCommitted(sender, null);
        }   

        private void cmbDoDi_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbDoDi.SelectedIndex > -1)
            {
                dtoDoDi.Id.Value = cmbDoDi.SelectedValue.ToString();
                txtDoDi.Text = cmbDoDi.Text;
                txtDoDi.Enabled = true;
                cbSelecionar.Checked = cbSelecionar.Visible = false;
                _itemNovo = false;
            }
            else
            {
                dtoDoDi.Id.Value = new Framework.DTO.TypeDecimal();
                txtDoDi.Text = string.Empty;
                txtDoDi.Enabled = false;
                //cbSelecionar.Visible = true;
            }
        }                  
    }
}