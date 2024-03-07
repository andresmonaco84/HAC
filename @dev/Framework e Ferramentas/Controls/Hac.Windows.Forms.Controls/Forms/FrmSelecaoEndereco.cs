using System;
using System.Data;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using HospitalAnaCosta.Framework.DataSetHelper;
using Hac.Windows.Forms;

namespace Hac.Windows.Forms.Controls.Forms
{
    public partial class FrmSelecaoEndereco : FrmBase
    {

        private DataTable dtEndereco;
        protected DataTable DtEndereco
        {
            get { return dtEndereco; }
            set { dtEndereco = value; }
        }


        private bool retorno = false;

        public FrmSelecaoEndereco()
        {
            InitializeComponent();
            Titulo = "Seleção de Endereco";
        }

        public static bool AbrirSelecaoEndereco(ref DataTable dtEndereco)
        {
            FrmSelecaoEndereco frmPesqEndereco = new FrmSelecaoEndereco();

            frmPesqEndereco.DtEndereco = dtEndereco;
            frmPesqEndereco.ShowDialog();
            dtEndereco = frmPesqEndereco.DtEndereco;

            return frmPesqEndereco.retorno;
        }

        private void FrmSelecaoEndereco_Load(object sender, EventArgs e)
        {
            dgvEnderecos.AutoGenerateColumns = false;
            dgvEnderecos.Columns["colTipoLogradouro"].DataPropertyName = "TIPOLOGRADOURO";
            dgvEnderecos.Columns["colNomeLogradouro"].DataPropertyName = "NOMELOGRADOURO";
            dgvEnderecos.Columns["colBairro"].DataPropertyName = "BAIRRO";
            dgvEnderecos.Columns["colCidade"].DataPropertyName = "CIDADE";
            dgvEnderecos.Columns["colUF"].DataPropertyName = "UF";
            dgvEnderecos.Columns["colCEP"].DataPropertyName = "CEP";
            dgvEnderecos.Columns["colComplemento"].DataPropertyName = "COMPLEMENTO";

            dgvEnderecos.DataSource = dtEndereco;
        }

        private bool tspCommand_SairClick(object sender)
        {
            //Se clicar em Sair retorno = false, cancela seleção
            retorno = false;
            return true;
        }

        private void dgvEnderecos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                //Recupero a linha selecionada no grid e o idtEndereco
                DataRow rowSelectedEndereco = ((DataRowView)dgvEnderecos.Rows[e.RowIndex].DataBoundItem).Row;

                //Removo todos os endereços não selecionados
                DataRow drEndereco = dtEndereco.NewRow();
                drEndereco["TIPOLOGRADOURO"] = rowSelectedEndereco["TIPOLOGRADOURO"];
                drEndereco["NOMELOGRADOURO"] = rowSelectedEndereco["NOMELOGRADOURO"];
                drEndereco["BAIRRO"] = rowSelectedEndereco["BAIRRO"];
                drEndereco["CIDADE"] = rowSelectedEndereco["CIDADE"];
                drEndereco["UF"] = rowSelectedEndereco["UF"];
                drEndereco["CEP"] = rowSelectedEndereco["CEP"];
                drEndereco["COMPLEMENTO"] = rowSelectedEndereco["COMPLEMENTO"];

                dtEndereco.Rows.Clear();
                dtEndereco.Rows.Add(drEndereco);

                retorno = true;
                Close();
            }
        }
    }
}

