using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Estoque
{
    public partial class FrmMarcas : FrmBase
    {
        private decimal numMarca = 0;

        MaterialMedicamentoDTO _dtoMatMed;
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject(typeof(IMaterialMedicamento)); }

        }   

        public FrmMarcas()
        {
            InitializeComponent();            
        }

        public void Visualizar(MaterialMedicamentoDTO dtoMatMed)
        {
            _dtoMatMed = dtoMatMed;
            lblMatMed.Text = dtoMatMed.NomeFantasia.ToString();

            dtgMarcas.AutoGenerateColumns = false;
            dtgMarcas.DataSource = MatMed.SelMarcas((decimal)dtoMatMed.Idt.Value);
            dtgMarcas.ClearSelection();

            this.ShowDialog();
        }

        private bool tsHac_NovoClick(object sender)
        {
            return true;
        }

        private bool tsHac_AfterNovo(object sender)
        {
            numMarca = 0;
            txtMarca.Focus();
            return default(bool);
        }    

        private bool tsHac_SalvarClick(object sender)
        {
            if (string.IsNullOrEmpty(txtMarca.Text))
            {
                MessageBox.Show("Digite a marca!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (numMarca == 0)
            {
                numMarca = 1;
                if (dtgMarcas.RowCount > 0)                                    
                    numMarca = decimal.Parse(((DataTable)dtgMarcas.DataSource).Select("CAD_MTMD_MARCA_NUM = MAX(CAD_MTMD_MARCA_NUM)")[0]["CAD_MTMD_MARCA_NUM"].ToString()) + 1;                

                MatMed.InserirMarca((decimal)_dtoMatMed.Idt.Value,
                                     numMarca,
                                     txtMarca.Text,
                                     (decimal)FrmPrincipal.dtoSeguranca.Idt.Value);
            }
            else
            {
                MatMed.AtualizarMarca((decimal)_dtoMatMed.Idt.Value,
                                      numMarca,
                                      txtMarca.Text,
                                      (decimal)FrmPrincipal.dtoSeguranca.Idt.Value);
            }
            dtgMarcas.DataSource = MatMed.SelMarcas((decimal)_dtoMatMed.Idt.Value);
            dtgMarcas.ClearSelection();
            this.Controla(Evento.eNovo);
            tsHac_AfterNovo(null);
            return default(bool);
        }

        private void dtgMarcas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1 && dtgMarcas.Columns[e.ColumnIndex].Name == colExcluir.Name)
            {
                if (MessageBox.Show("Deseja realmente excluir esta marca do produto ?",
                                    "Gestão de Materiais e Medicamentos",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MatMed.ExcluirMarca((decimal)_dtoMatMed.Idt.Value, decimal.Parse(dtgMarcas.Rows[e.RowIndex].Cells[colNumMarca.Name].Value.ToString()));
                    dtgMarcas.DataSource = MatMed.SelMarcas((decimal)_dtoMatMed.Idt.Value);
                    dtgMarcas.ClearSelection();                    
                    this.Controla(Evento.eNovo);
                    tsHac_AfterNovo(null);
                }
            }
        }

        private void dtgMarcas_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgMarcas.CurrentRow != null)
            {
                numMarca = decimal.Parse(dtgMarcas.CurrentRow.Cells[colNumMarca.Name].Value.ToString());
                txtMarca.Text = dtgMarcas.CurrentRow.Cells[colDescricao.Name].Value.ToString();
                txtMarca.Enabled = true;
                txtMarca.Focus();
            }
        }   

        private void FrmMarcas_Load(object sender, EventArgs e)
        {
            dtgMarcas.ClearSelection();
            dtgMarcas.SelectionChanged += new System.EventHandler(dtgMarcas_SelectionChanged);            
        }
    }
}