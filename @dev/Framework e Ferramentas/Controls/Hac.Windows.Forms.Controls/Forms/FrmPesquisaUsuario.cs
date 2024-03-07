using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Hac.Windows.Forms;
using HospitalAnaCosta.Services.Seguranca.DTO;
using HospitalAnaCosta.Services.Seguranca.Interface;


namespace Hac.Windows.Forms.Controls.Forms
{
    public partial class FrmPesquisaUsuario : FrmBase
    {
        public FrmPesquisaUsuario()
        {
            InitializeComponent();
            Titulo = "Pesquisar Usuário";
        }

        private UsuarioDataTable dtbUsuario;

        public UsuarioDataTable DtbUsuario
        {
            get { return dtbUsuario; }
            set { dtbUsuario = value; }
        }

        private UsuarioDTO dtoUsuario;

        private void FrmPesquisaUsuario_Load(object sender, EventArgs e)
        {
            dgvPesquisaUsuario.AutoGenerateColumns = false;
            dgvPesquisaUsuario.Columns["Idt"].DataPropertyName = UsuarioDTO.FieldNames.Idt;
            dgvPesquisaUsuario.Columns["Matricula"].DataPropertyName = UsuarioDTO.FieldNames.Matricula;
            dgvPesquisaUsuario.Columns["Nome"].DataPropertyName = UsuarioDTO.FieldNames.Nome;

            dgvPesquisaUsuario.DataSource = dtbUsuario;
        }

        public static UsuarioDTO AbrirPesquisaUsuario
                        (UsuarioDataTable dtbUsuario)
        {
            FrmPesquisaUsuario frmPesquisa = new FrmPesquisaUsuario();
            frmPesquisa.DtbUsuario = dtbUsuario;
            frmPesquisa.ShowDialog();
            return frmPesquisa.dtoUsuario;
        }

        private void dgvPesquisaUsuario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dtoUsuario = (UsuarioDTO)((DataRowView)dgvPesquisaUsuario.Rows[e.RowIndex].DataBoundItem).Row;
                this.Close();               
            }
        }

        private void txtNomeUsuario_TextChanged(object sender, EventArgs e)
        {
            if (txtNomeUsuario.Text.ToString() == string.Empty)
                dtbUsuario.DefaultView.RowFilter = null;
            else
                dtbUsuario.DefaultView.RowFilter = String.Format("{0} LIKE '%{1}%'",
                        UsuarioDTO.FieldNames.Nome, txtNomeUsuario.Text.ToString());
        }


    }
}