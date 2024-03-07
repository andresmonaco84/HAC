using System;
using System.Data;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Cadastro.DTO;

namespace Hac.Windows.Forms.Controls.Forms
{
    public partial class FrmSelecaoProntuario : FrmBase
    {
        private DataTable dtbPaciente = new DataTable();
   
        private string prontuario;
        protected string Prontuario
        {
            get { return prontuario; }
            set { prontuario = value; }
        }        

        public FrmSelecaoProntuario()
        {
            InitializeComponent();
            Titulo = "Seleção de Prontuário";
        }

        public static string AbrirSelecaoProntuario(decimal idtPessoa)
        {
            FrmSelecaoProntuario frm = new FrmSelecaoProntuario();
            frm.CarregarDataTableProntuario(idtPessoa,new DataTable());

            if (frm.dtbPaciente.Rows.Count > 1)
            { frm.ShowDialog(); }
            else if (frm.dtbPaciente.Rows.Count == 1)
            { frm.prontuario = frm.dtbPaciente.Rows[0][CadastroPacienteDTO.FieldNames.Prontuario].ToString(); }
            else
            { frm.prontuario = string.Empty; }

            return frm.prontuario;
        }

        public static string AbrirSelecaoProntuario(DataTable dtb)
        {
            FrmSelecaoProntuario frm = new FrmSelecaoProntuario();
            frm.CarregarDataTableProntuario(null, dtb);

            if (frm.dtbPaciente.Rows.Count > 1)
            { frm.ShowDialog(); }
            else if (frm.dtbPaciente.Rows.Count == 1)
            { frm.prontuario = frm.dtbPaciente.Rows[0][CadastroPacienteDTO.FieldNames.Prontuario].ToString(); }
            else
            { frm.prontuario = string.Empty; }

            return frm.prontuario;
        }
       
        private void CarregarDataTableProntuario(decimal? idtPessoa, DataTable dtb)
        {
            if (dtb.Rows.Count == 0)
            {
                CadastroPacienteDTO dtoPaciente = new CadastroPacienteDTO();
                dtoPaciente.IdtPessoa.Value = idtPessoa;
                dtbPaciente = Paciente.Listar(dtoPaciente);
            }
            else
                dtbPaciente = dtb;

            dgvProntuario.AutoGenerateColumns = false;
            dgvProntuario.Columns[colProntuario.Name].DataPropertyName = CadastroPacienteDTO.FieldNames.Prontuario;

            //Remove duplicados
            for (int i = 0; i < dtbPaciente.Rows.Count; i++)
            {
                for (int j = 0; j < dtbPaciente.Rows.Count; j++)
                {
                    if (i != j && dtbPaciente.Rows[i][CadastroPacienteDTO.FieldNames.Prontuario].ToString() == dtbPaciente.Rows[j][CadastroPacienteDTO.FieldNames.Prontuario].ToString())
                    {
                        dtbPaciente.Rows[j][CadastroPacienteDTO.FieldNames.Prontuario] = DBNull.Value;
                    }
                }
            }

            DataView dv = dtbPaciente.DefaultView;
            dv.RowFilter = CadastroPacienteDTO.FieldNames.Prontuario + " IS NOT NULL AND " +
                           CadastroPacienteDTO.FieldNames.Prontuario + " <> 7";
            dtbPaciente = dv.ToTable();

            dgvProntuario.DataSource = dtbPaciente;
            dgvProntuario.ClearSelection();

        }

        private void dgvPessoas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataRow row = ((DataRowView)dgvProntuario.Rows[e.RowIndex].DataBoundItem).Row;
                prontuario = row[CadastroPacienteDTO.FieldNames.Prontuario].ToString();
                Close();
            }
        }

        private void FrmSelecaoProntuario_Load(object sender, EventArgs e)
        {
            dgvProntuario.ClearSelection();
        }
    }
}

