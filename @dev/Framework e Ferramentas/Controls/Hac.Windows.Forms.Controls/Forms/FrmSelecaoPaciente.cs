using System;
using System.Data;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Cadastro.DTO;

using System.Collections.Generic;
using HospitalAnaCosta.Framework.DataSetHelper;
using Hac.Windows.Forms;

namespace Hac.Windows.Forms.Controls.Forms
{
    public partial class FrmSelecaoPaciente : FrmBase
    {

        private DataSet dsPaciente;
        protected DataSet DsPaciente
        {
            get { return dsPaciente; }
            set { dsPaciente = value; }
        }

        private bool retorno = false;

        public FrmSelecaoPaciente()
        {
            InitializeComponent();
            Titulo = "Seleção de Paciente";
        }

        public static bool AbrirSelecaoPaciente(ref DataSet dsPaciente)
        {
            FrmSelecaoPaciente frmPesqPaciente = new FrmSelecaoPaciente();

            frmPesqPaciente.DsPaciente = dsPaciente;
            frmPesqPaciente.ShowDialog();
            dsPaciente = frmPesqPaciente.DsPaciente;
            return frmPesqPaciente.retorno;
        }

        private void FrmPesquisaPaciente_Load(object sender, EventArgs e)
        {
            dgvPacientes.AutoGenerateColumns = false;
            dgvPacientes.Columns["colIdtPaciente"].DataPropertyName = CadastroPacienteDTO.FieldNames.IdtPaciente;
            dgvPacientes.Columns["colConvenio"].DataPropertyName = ConvenioDTO.FieldNames.CodigoHACPrestador;
            dgvPacientes.Columns["colPlano"].DataPropertyName = PlanoDTO.FieldNames.CodigoPlanoHAC;
            dgvPacientes.Columns["colCredencial"].DataPropertyName = CadastroPacienteDTO.FieldNames.CodigoCredencial;
            dgvPacientes.Columns["colProntuario"].DataPropertyName = CadastroPacienteDTO.FieldNames.Prontuario;
            dgvPacientes.Columns["colCPF"].DataPropertyName = CadastroPessoaDTO.FieldNames.CNPJCPF;
            dgvPacientes.Columns["colRG"].DataPropertyName = CadastroPessoaDTO.FieldNames.RG;
            dgvPacientes.Columns["colNome"].DataPropertyName = CadastroPessoaDTO.FieldNames.NomePessoa;
            dgvPacientes.Columns["colEstadoCivil"].DataPropertyName = "DescricaoEstadoCivil";
            dgvPacientes.Columns["colSexo"].DataPropertyName = "DescricaoSexo";

            DataSetHelper dsHelper = new DataSetHelper(ref dsPaciente);
            DataTable dtJoinPaciente = dsHelper.SelectJoinInto("CadastroPaciente",
                dsPaciente.Tables["CadastroPaciente"], null, null, 
                new string []
                {
                    CadastroPacienteDTO.FieldNames.IdtPaciente,
                    "relConvenio." + ConvenioDTO.FieldNames.CodigoHACPrestador,
                    "relPlano." + PlanoDTO.FieldNames.CodigoPlanoHAC,
                    CadastroPacienteDTO.FieldNames.CodigoCredencial,
                    CadastroPacienteDTO.FieldNames.Prontuario,
                    "relPessoa." + CadastroPessoaDTO.FieldNames.CNPJCPF,
                    "relPessoa." + CadastroPessoaDTO.FieldNames.RG,
                    "relPessoa." + CadastroPessoaDTO.FieldNames.NomePessoa,                                        
                    "relPessoa.CadastroPessoa.relSexo.DescricaoSexo",
                    "relPessoa.CadastroPessoa.relEstadoCivil.DescricaoEstadoCivil"
                });
            dgvPacientes.DataSource = dtJoinPaciente;
        }

        private bool tspCommand_SairClick(object sender)
        {
            //Se clicar em Sair retorno = false, cancela seleção
            retorno = false;
            return true;
        }

        private void dgvPacientes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                //Recupero a linha selecionada no grid e o idtPaciente
                DataRow rowJoinedPaciente = ((DataRowView)dgvPacientes.Rows[e.RowIndex].DataBoundItem).Row;
                Decimal idtPaciente = Convert.ToDecimal(rowJoinedPaciente[CadastroPacienteDTO.FieldNames.IdtPaciente]);

                //Removo todos os pacientes não selecionados
                DataRow[] listRowPaciente = dsPaciente.Tables["CadastroPaciente"].Select(CadastroPacienteDTO.FieldNames.IdtPaciente + "<>" + idtPaciente);
                foreach (DataRow rowPaciente in listRowPaciente)
                {
                    dsPaciente.Tables["CadastroPaciente"].Rows.Remove(rowPaciente);
                }

                //Encontro a pessoa do paciente selecionado
                Decimal idtPessoa = Convert.ToDecimal(dsPaciente.Tables["CadastroPaciente"].Rows[0][CadastroPessoaDTO.FieldNames.IdtPessoa]);

                //Removo todos as pessoas não selecionados
                DataRow[] listRowPessoa = dsPaciente.Tables["CadastroPessoa"].Select(CadastroPessoaDTO.FieldNames.IdtPessoa + "<>" + idtPessoa);
                foreach (DataRow rowPessoa in listRowPessoa)
                {
                    dsPaciente.Tables["CadastroPessoa"].Rows.Remove(rowPessoa);
                }

                //Faz o commit no DataSet
                dsPaciente.AcceptChanges();

                //Se escolher um paciente retorno = true, continua com a pesquisa
                retorno = true;
                Close();
            }
        }
    }
}

