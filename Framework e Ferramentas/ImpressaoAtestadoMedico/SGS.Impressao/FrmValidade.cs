using HospitalAnaCosta.SGS.Impressao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SGS.ClientControl
{
    public partial class FrmValidade : Form
    {
        Tools tools = new Tools();
        private AtendimentoEntity atendimentoEntity;
        public AtendimentoEntity Atendimento
        {
            get { return atendimentoEntity; }
            set { atendimentoEntity = value; }
        }

        private int linha = 0;

        public FrmValidade()
        {
            InitializeComponent();
        }

        private void FrmValidade_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = tools.ConsultarValidade(Atendimento);
        }

        public static string AbrirDataValidade(AtendimentoEntity entity)
        {
            FrmValidade frm = new FrmValidade();
            frm.Atendimento = entity;
            frm.BringToFront();
            //frm.Capture = true;
            //frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
            
            return entity.Validade;
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            DataTable dtbFeriados = tools.ConsultarFeriado(atendimentoEntity.IDUnidade,string.Empty);

            string strValidade = "";
            DateTime dtValidade = Convert.ToDateTime(Atendimento.DataAtual);
            if (dataGridView1.Rows[linha].Cells["CAD_PVE_UN_TEMPO"].Value.ToString() == "HORAS")
            {
                int nDias = Convert.ToInt32(dataGridView1.Rows[linha].Cells["CAD_PVE_QT_VALIDADE"].Value) / 24;
                if (nDias > 0)
                {
                    dtValidade = dtValidade.AddDays(nDias);
                    dtValidade = tools.ProximoDiaUtil(dtValidade, dtbFeriados, false, true);
                    strValidade = Convert.ToDateTime(dtValidade).ToString("dd/MM/yyyy");
                }
            }
            else
            {
                //dtValidade = busAtendimento.ObterDiaUtil(Convert.ToInt32(enValidadeExame.QtdValidade), unidade);
                dtValidade = dtValidade.AddDays(Convert.ToInt32(dataGridView1.Rows[linha].Cells["CAD_PVE_QT_VALIDADE"].Value));
                dtValidade = tools.ProximoDiaUtil(dtValidade, dtbFeriados, false, true);
                strValidade = Convert.ToDateTime(dtValidade).ToString("dd/MM/yyyy");
            }

            if (atendimentoEntity.DataFimConvenio.Length > 0)
            {
                if (dtValidade > Convert.ToDateTime(atendimentoEntity.DataFimConvenio))
                {
                    MessageBox.Show("A data de validade não pode ser superior à data final de vigência do Convênio.", "Validação da data do Convênio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (atendimentoEntity.DataFimPlano.Length > 0)
            {
                if (dtValidade > Convert.ToDateTime(atendimentoEntity.DataFimPlano))
                {
                    MessageBox.Show("A data de validade não pode ser superior à data final de vigência do Plano.", "Validação da data do Plano", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            Atendimento.Validade = dtValidade.ToShortDateString();
            this.Close();
            this.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                linha = e.RowIndex;
        }

       

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSelecionar_Click(null, null);
        }
    }
}
