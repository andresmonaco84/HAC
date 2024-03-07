using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using HospitalAnaCosta.SGS.Cadastro.Interface;
using Hac.Windows.Forms;


namespace Hac.Windows.Forms.Controls.Forms
{
    public partial class FrmCadastroSetor : FrmBase
    {
        

        private SetorDTO setorDTO = new SetorDTO();
        private SetorDataTable dtbSetor = new SetorDataTable();
        private ISetor _setor;

        private ISetor Setor
        {
            get { return _setor != null ? _setor : _setor = (ISetor)CommonServices.GetObject(typeof(ISetor)); }
        }

        public FrmCadastroSetor()
        {            
            InitializeComponent();
            grdSetor.AutoGenerateColumns = false;
        }



        private void FrmCadastroSetor_Load(object sender, EventArgs e)
        {
            cboUnidade.Carregaunidade();
            cboUnidade.IniciaLista();
        }

        private bool tspCommand_PesquisarClick(object sender)
        {
            CarregarGrid();
            return default(bool);
        }

        private void CarregarGrid()
        {
            SetorDTO setorDTO = new SetorDTO();
            setorDTO.IdtUnidade.Value = Convert.ToInt32(cboUnidade.SelectedValue);
            setorDTO.IdtLocalAtendimento.Value = Convert.ToInt32(cboLocal.SelectedValue);
            dtbSetor = Setor.Sel(setorDTO);
            grdSetor.DataSource = dtbSetor;
            //dtbSetor = (SetorDataTable)grdSetor.DataSource;            
        }

        private bool tspCommand_SalvarClick(object sender)
        {
            if (cboUnidade.SelectedIndex == -1 || cboLocal.SelectedIndex == -1 || cboStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Preencha todos os campos corretamente.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return default (bool);
            }            
            setorDTO.IdtUnidade.Value = Convert.ToInt32(cboUnidade.SelectedValue);
            setorDTO.IdtLocalAtendimento.Value = Convert.ToInt32(cboLocal.SelectedValue);
            setorDTO.Codigo.Value = txtCodigo.Text;           
            
            setorDTO.Descricao.Value = txtDescricao.Text;
            setorDTO.NumeroAndar.Value = (string.IsNullOrEmpty(txtAndar.Text) ? null : (int?)Convert.ToInt32(txtAndar.Text));
            setorDTO.NumeroTelefone.Value = txtTelefone.Text;
            setorDTO.IdtRamal.Value = txtRamal.Text;
            if (cboStatus.SelectedItem != "<Selecione>")
	        {
                setorDTO.FlAtivo.Value = (cboStatus.SelectedItem == "Ativo") ? "S" : "N";
	        }
            setorDTO.GravaAtendimento.Value = (chkGravAtend.Checked == true) ? "S" : "N";
            setorDTO.PermiteInternacao.Value = (chkPermiteInternacao.Checked == true) ? "S" : "N" ;
            setorDTO.PreferencialACS.Value = (chkPreferencialACS.Checked == true) ? "S" : "N" ;
            setorDTO.PossuiEstoqueProprio.Value = (chkEstoqueProprio.Checked == true) ? "S" : "N" ;
            setorDTO.SubstituiAlmoxarifado.Value = (chkAtendAlmox.Checked == true) ? "S" : "N";
            setorDTO.AtendeServicoMulher.Value = (chkServMulher.Checked == true) ? "S" : "N";
            
            try
            {
                Setor.Salvar(setorDTO);
                MessageBox.Show("Setor Salvo com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CarregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
            return default(bool);
        }

      

        private bool tspCommand_SairClick(object sender)
        {
            this.Dispose();
            return default(bool);
        }

        private void grdSetor_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {            
           // SetorDTO setorDTO = new SetorDTO();
            //DataRow row = dtbSetor.Select(string.Format("{0} = '{1}'", SetorDTO.FieldNames.Idt, row.Cells["CAD_SET_ID"].Value.ToString()))[0];
            DataRow row = dtbSetor.Rows.Find(grdSetor.Rows[e.RowIndex].Cells["CAD_SET_ID"].Value);

            //if (e.RowIndex != -1)
            //{
            //}
            //SetorDTO setorDTO = new SetorDTO();
            ////CAD_SET_ID  idtsetor
            //setorDTO.Idt.Value = grdSetor.SelectedRows.Count > 0 ? grdSetor.SelectedRows[0].Index : -1;
            //setorDTO = Setor.SelChave(setorDTO);
            if (row[SetorDTO.FieldNames.FlAtivo].ToString() == "S")
            {
                cboStatus.SelectedIndex = 0;
            }
            else
            {
                cboStatus.SelectedIndex = 1;
            }
            //cboStatus.SelectedValue = (row[SetorDTO.FieldNames.FlAtivo].ToString() == "S") ? cboStatus.SelectedIndex = 0 : cboStatus.SelectedIndex = 1;
            txtAndar.Text = row[SetorDTO.FieldNames.NumeroAndar].ToString();
            txtCodigo.Text = row[SetorDTO.FieldNames.Codigo].ToString();
            txtDescricao.Text = row[SetorDTO.FieldNames.Descricao].ToString();
            txtTelefone.Text = row[SetorDTO.FieldNames.NumeroTelefone].ToString(); 
            txtRamal.Text = row[SetorDTO.FieldNames.IdtRamal].ToString(); 
            chkEstoqueProprio.Checked = (row[SetorDTO.FieldNames.PossuiEstoqueProprio].ToString() == "S");
            chkGravAtend.Checked = (row[SetorDTO.FieldNames.GravaAtendimento].ToString() == "S");
            chkPermiteInternacao.Checked = (row[SetorDTO.FieldNames.PermiteInternacao].ToString() == "S");
            chkPreferencialACS.Checked = (row[SetorDTO.FieldNames.PreferencialACS].ToString() == "S"); 
  
        }

       
    }
}