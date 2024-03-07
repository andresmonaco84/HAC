using System;
using System.Data;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Cadastro.DTO;
namespace Hac.Windows.Forms.Controls.Forms
{
    public partial class FrmSelecaoPessoa : FrmBase
    {

        private DataSet dsPessoa;
        protected DataSet DsPessoa
        {
            get { return dsPessoa; }
            set { dsPessoa = value; }
        }

     
        private bool retorno = false;

        public FrmSelecaoPessoa()
        {
            InitializeComponent();
            Titulo = "Seleção de Pessoa";
        }

        public static bool AbrirSelecaoPessoa(ref DataSet dsPessoa)
        {
            FrmSelecaoPessoa frmPesqPessoa = new FrmSelecaoPessoa();

            frmPesqPessoa.DsPessoa = dsPessoa;
            frmPesqPessoa.ShowDialog();
            dsPessoa = frmPesqPessoa.DsPessoa;
            return frmPesqPessoa.retorno;
        }

        private void FrmSelecaoPessoa_Load(object sender, EventArgs e)
        {
            dgvPessoas.AutoGenerateColumns = false;
            dgvPessoas.Columns["colIdtPessoa"].DataPropertyName = CadastroPessoaDTO.FieldNames.IdtPessoa;
            dgvPessoas.Columns["colNome"].DataPropertyName = CadastroPessoaDTO.FieldNames.NomePessoa;
            dgvPessoas.Columns["colDataNascimento"].DataPropertyName = CadastroPessoaDTO.FieldNames.DataNascimento;
            dgvPessoas.Columns["colSexo"].DataPropertyName = "DescricaoSexo";
            dgvPessoas.Columns["colNomeMae"].DataPropertyName = CadastroPessoaDTO.FieldNames.NomeMae;
            dgvPessoas.Columns["colEstadoCivil"].DataPropertyName = "DescricaoEstadoCivil";
            dgvPessoas.Columns["colRG"].DataPropertyName = CadastroPessoaDTO.FieldNames.RG;
            dgvPessoas.Columns["colCPF"].DataPropertyName = CadastroPessoaDTO.FieldNames.CNPJCPF;

            dsPessoa.Tables["CadastroPessoa"].Columns.Add("DescricaoSexo",typeof(string));
            dsPessoa.Tables["CadastroPessoa"].Columns.Add("DescricaoEstadoCivil",typeof(string));

            foreach (DataRow row in dsPessoa.Tables["CadastroPessoa"].Rows)
            {
                row["DescricaoSexo"] = row[CadastroPessoaDTO.FieldNames.Sexo].ToString() == "M" ? "MASCULINO" : "FEMININO";
                row["DescricaoEstadoCivil"] = estadoCivil(row[CadastroPessoaDTO.FieldNames.EstadoCivil].ToString()); 
            }

            dgvPessoas.DataSource = dsPessoa.Tables["CadastroPessoa"];

        }

        private string estadoCivil(string _codigoEstadoCivil)
        {
            switch (_codigoEstadoCivil)
            {
                case "2":
                    return "CASADO";
                case "4":
                    return "DIVORCIADO";
                case "3":
                    return "SEPARADO";
                case "1":
                    return "SOLTEIRO";
                case "6":
                    return "UNIÃO ESTÁVEL";
                case "5":
                    return "VIUVO";
                default:
                    return string.Empty;
            }
        }


        private bool tspCommand_SairClick(object sender)
        {
            //Se clicar em Sair retorno = false, cancela seleção
            retorno = false;
            return true;
        }

        private void dgvPessoas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                if(MessageBox.Show("Ao selecionar essa pessoa, as informações digitadas serão descartadas e substituídas!\nDeseja continuar?", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    return;

                //Recupero a linha selecionada no grid e o idtPessoa
                DataRow rowJoinedPessoa = ((DataRowView)dgvPessoas.Rows[e.RowIndex].DataBoundItem).Row;
                Decimal idtPessoa = Convert.ToDecimal(rowJoinedPessoa[CadastroPessoaDTO.FieldNames.IdtPessoa]);

                //Removo todos os Pessoas não selecionados
                DataRow[] listRowPessoa = dsPessoa.Tables["CadastroPessoa"].Select(CadastroPessoaDTO.FieldNames.IdtPessoa + "<>" + idtPessoa);
                foreach (DataRow rowPessoa in listRowPessoa)
                {
                    dsPessoa.Tables["CadastroPessoa"].Rows.Remove(rowPessoa);
                }

                //Faz o commit no DataSet
                dsPessoa.AcceptChanges();

                //Se escolher um Pessoa retorno = true, continua com a pesquisa
                retorno = true;
                Close();
            }
        }
    }
}

