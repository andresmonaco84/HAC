using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriaisView;

namespace HospitalAnaCosta.SGS.GestaoMateriais
{
    public partial class FrmPacienteSetor : FrmBase
    {
        // Atendimento
        private PacienteDataTable dtbAtendimento = new PacienteDataTable();
        private PacienteDTO dtoAtendimento;
        private IPaciente _atendimento;
        private IPaciente Atendimento
        {
            get { return _atendimento != null ? _atendimento : _atendimento = (IPaciente)Global.Common.GetObject(typeof(IPaciente)); }
        }


        public FrmPacienteSetor()
        {
            InitializeComponent();
            
        }

        public static PacienteDTO BuscaAtendimento(PacienteDTO dto)
        {
            FrmPacienteSetor frmAtendimento = new FrmPacienteSetor();
            frmAtendimento.dtoAtendimento = dto;
            frmAtendimento.ShowDialog();
            return frmAtendimento.dtoAtendimento;
        }

        private void ConfiguraDTG()
        {
            dtgAtendimento.AutoGenerateColumns = false;
            dtgAtendimento.Columns["ColIdt"].DataPropertyName = PacienteDTO.FieldNames.Idt;
            dtgAtendimento.Columns["colNmPaciente"].DataPropertyName = PacienteDTO.FieldNames.NmPaciente;
            dtgAtendimento.Columns["colQuarto"].DataPropertyName = PacienteDTO.FieldNames.CdQuarto;
            dtgAtendimento.Columns["colLeito"].DataPropertyName = PacienteDTO.FieldNames.CdLeito;
            dtgAtendimento.Columns["colDtTransf"].DataPropertyName = PacienteDTO.FieldNames.DtTransf;
            dtgAtendimento.Columns["colDtAlta"].DataPropertyName = PacienteDTO.FieldNames.DtAlta;
            dtgAtendimento.Columns["colTpAtendimento"].DataPropertyName = PacienteDTO.FieldNames.TpAtendimento;
            dtgAtendimento.Columns["colTpPlano"].DataPropertyName = PacienteDTO.FieldNames.TpPlano;
            dtgAtendimento.Columns["colSetor"].DataPropertyName = PacienteDTO.FieldNames.DsSetor;

            

        }

        private void FrmAtendimentoSetor_Load(object sender, EventArgs e)
        {
            ConfiguraDTG();
            try
            {
                dtbAtendimento = Atendimento.Sel(dtoAtendimento);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dtgAtendimento.DataSource = dtbAtendimento;
        }
        
        private void dtgAtendimento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                //dtoAtendimento = (AtendimentoDTO)dtbAtendimento.Rows.Find(Convert.ToInt64(dtgAtendimento.Rows[e.RowIndex].Cells["colIdt"].Value));
                dtoAtendimento = (PacienteDTO)dtbAtendimento.Select(string.Format("{0} = {1}", PacienteDTO.FieldNames.Idt, dtgAtendimento.Rows[e.RowIndex].Cells["colIdt"].Value), string.Empty)[0];
                Close();
            }

        }

        private void hacToolStrip1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            dtgAtendimento.Columns["colDtTransf"].Visible = !(dtgAtendimento.Columns["colDtTransf"].Visible);
            dtgAtendimento.Columns["colDtAlta"].Visible = !(dtgAtendimento.Columns["colDtAlta"].Visible);
            dtgAtendimento.Columns["colTpAtendimento"].Visible = !(dtgAtendimento.Columns["colTpAtendimento"].Visible);
            dtgAtendimento.Columns["colTpPlano"].Visible = !(dtgAtendimento.Columns["colTpPlano"].Visible);
            dtgAtendimento.Columns["colSetor"].Visible = !(dtgAtendimento.Columns["colSetor"].Visible);

        }   
    }
}