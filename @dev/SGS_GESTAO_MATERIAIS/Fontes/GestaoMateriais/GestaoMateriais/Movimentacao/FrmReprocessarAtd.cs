using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmReprocessarAtd : FrmBase
    {
        private DateTime? dataInicio = null, dataFim = null;
        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject(typeof(IMovimentacao)); }
        }

        public FrmReprocessarAtd()
        {
            InitializeComponent();
        }

        private bool ValidarPeriodo()
        {
            dataInicio = null; dataFim = null;

            if (cbPeriodoCompleto.Checked) return true;

            if (txtInicio.Text == string.Empty || txtHoraIni.Text == string.Empty || txtMinIni.Text == string.Empty)
            {
                MessageBox.Show("Data/Hora Início Obrigatória.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtInicio.Focus();
                return false;
            }
            if (txtFim.Text == string.Empty || txtHoraFim.Text == string.Empty || txtMinFim.Text == string.Empty)
            {
                MessageBox.Show("Data/Hora Fim Obrigatória.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFim.Focus();
                return false;
            }            

            try
            {
                string strDataIni = txtInicio.Text + " " + txtHoraIni.Text + ":" + txtMinIni.Text;
                string strDataFim = txtFim.Text + " " + txtHoraFim.Text + ":" + txtMinFim.Text;

                dataInicio = Convert.ToDateTime(strDataIni);
                dataFim = Convert.ToDateTime(strDataFim);

                if (dataFim < dataInicio)
                {
                    MessageBox.Show("A Data Fim deve ser maior ou igual à Data Início.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFim.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Data/Hora Início ou Fim inválida.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }           

            return true;
        }

        private void cbPeriodoCompleto_Click(object sender, EventArgs e)
        {
            if (!cbPeriodoCompleto.Checked)
            {
                ConfigurarControles(grbPeriodo.Controls, true);
                txtHoraIni.Text = txtMinIni.Text = "00";
                txtHoraFim.Text = "23";
                txtMinFim.Text = "59";
                txtFim.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                txtInicio.Focus();
            }
            else
            {
                ConfigurarControles(grbPeriodo.Controls, false);
                LimparControles(grbPeriodo.Controls);                
            }
        }

        private void btnReprocessar_Click(object sender, EventArgs e)
        {
            if (txtAtd.Text == string.Empty)
            {
                MessageBox.Show("Digite o Atendimento.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAtd.Focus();
                return;
            }
            if (ValidarPeriodo())
            {
                if (MessageBox.Show("Deseja realmente reprocessar este atendimento ?",
                                    "Gestão de Materiais e Medicamentos",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MovimentacaoDTO dtoMov = new MovimentacaoDTO();
                    dtoMov.IdtAtendimento.Value = txtAtd.Text;

                    this.Cursor = Cursors.WaitCursor;

                    if (!cbPeriodoCompleto.Checked)
                    {
                        if (!cbDuplicar.Checked && Movimento.TemParcelaFaturamento((int)dtoMov.IdtAtendimento.Value, dataInicio))
                        {
                            MessageBox.Show("Esta Conta já tem Parcela neste período no Faturamento, impossibilitando o reprocessamento por esta funcionalidade, favor verificar!", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Cursor = Cursors.Default;
                            return;
                        }
                        dtoMov.DataMovimento.Value = dataInicio;
                        dtoMov.DataAte.Value = dataFim;
                    }
                    else if (!cbDuplicar.Checked && Movimento.TemParcelaFaturamento((int)dtoMov.IdtAtendimento.Value, null))
                    {
                        MessageBox.Show("Esta Conta já tem Parcela neste período no Faturamento, impossibilitando o reprocessamento por esta funcionalidade, favor verificar!", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Cursor = Cursors.Default;
                        return;
                    }

                    dtoMov.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

                    int qtd = Movimento.ReprocessarContaFaturamentoMatMed(dtoMov, cbDuplicar.Checked);

                    this.Cursor = Cursors.Default;

                    MessageBox.Show(string.Format("Foram reenviados {0} itens para o faturamento!", qtd), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}