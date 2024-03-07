using System;
using System.Data;
using System.Windows.Forms;

using HospitalAnaCosta.SGS.Cadastro.DTO;
using System.Drawing;

namespace Hac.Windows.Forms.Controls.Forms
{
    public partial class FrmSelecaoPacienteAtendimento : FrmBase
    {

        private DataTable dtbPacienteAtendimento;

        public DataTable DtbPacienteAtendimento
        {
            get { return dtbPacienteAtendimento; }
            set { dtbPacienteAtendimento = value; }
        }

        private DataRow rowConvenio;

        public DataRow RowConvenio
        {
            get { return rowConvenio; }
            set { rowConvenio = value; }
        }


        public static DataRow AbrirSelecaoPacienteAtendimento(DataTable dtbConvenio)
        {
            FrmSelecaoPacienteAtendimento frm = new FrmSelecaoPacienteAtendimento();

            if (dtbConvenio.Rows.Count > 1)
            {
                frm.CarregarGrid(dtbConvenio);
                frm.ShowDialog();
                return frm.RowConvenio;
            }
            else
                return dtbConvenio.Rows[0];
        }

        public FrmSelecaoPacienteAtendimento()
        {
            InitializeComponent();
            Titulo = "Seleção Paciente Atendimento";

            dgvResultado.ColumnHeadersDefaultCellStyle.Font = new Font(new FontFamily("Verdana"), 6.75f); 
        }

        private void CarregarGrid(DataTable dtbConvenio)
        {
            dtbConvenio.Columns.Add("CodPlano", typeof (string));
            dtbConvenio.Columns.Add("DesPlano", typeof(string));
            dtbConvenio.Columns.Add("nomePessoa", typeof(string));
            if(!dtbConvenio.Columns.Contains(CadastroPacienteDTO.FieldNames.CodigoCredencial))
            {
                dtbConvenio.Columns.Add(CadastroPacienteDTO.FieldNames.CodigoCredencial, typeof(string));
            }
            
            if(dtbConvenio.Rows.Count > 0 && dtbConvenio.Columns.Contains(CadastroPacienteDTO.FieldNames.IdtPaciente))
            {
                foreach (DataRow row in dtbConvenio.Rows)
                {
                    CadastroPacienteDTO dtoPaciente = new CadastroPacienteDTO();
                    dtoPaciente.IdtPaciente.Value = row[CadastroPacienteDTO.FieldNames.IdtPaciente].ToString();
                    dtoPaciente = Paciente.PesquisarChave(dtoPaciente);

                    if (dtoPaciente != null)
                    {
                        CadastroPessoaDTO dtoPessoa = new CadastroPessoaDTO();
                        dtoPessoa.IdtPessoa.Value = dtoPaciente.IdtPessoa.Value;
                        dtoPessoa = Pessoa.Pesquisar(dtoPessoa);

                        row["nomePessoa"] = dtoPessoa.NomePessoa.Value.ToString();

                        row[CadastroPacienteDTO.FieldNames.CodigoCredencial] = dtoPaciente.CodigoCredencial.Value.ToString();

                        PlanoDTO dtoPlano = new PlanoDTO();
                        dtoPlano.IdtPlano.Value = dtoPaciente.IdtPlano.Value;
                        dtoPlano = Plano.Pesquisar(dtoPlano);
                        if(dtoPlano != null)
                        {
                            row["CodPlano"] = dtoPlano.CodigoPlanoHAC.Value.ToString();
                            row["DesPlano"] = dtoPlano.NomePlano.Value.ToString();
                        }
                    }
                }
            }

            dgvResultado.AutoGenerateColumns = false;
            dgvResultado.DataSource = dtbConvenio;
            dgvResultado.Enabled = true;
        }

        private void dgvResultado_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                this.rowConvenio = ((DataRowView)dgvResultado.Rows[e.RowIndex].DataBoundItem).Row;
                this.Close();
            }
        }
    }
}