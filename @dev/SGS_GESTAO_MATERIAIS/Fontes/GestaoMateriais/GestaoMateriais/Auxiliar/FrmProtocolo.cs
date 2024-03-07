using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Reporting.WinForms;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using Microsoft.ReportingServices.ReportRendering;
using HospitalAnaCosta.SGS.GestaoMateriais.Relatorio;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    public partial class FrmProtocolo : FrmBase
    {
        public string _nomePaciente;

        // Movimentos
        public MovimentacaoDTO _dtoMovimento;
        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject(typeof(IMovimentacao)); }
        }

        public FrmProtocolo()
        {
            InitializeComponent();
        }
                
        private void FrmProtocolo_Load(object sender, EventArgs e)
        {
            dtgProtocolos.AutoGenerateColumns = false;
            dtgProtocolos.Columns[colNumProt.Name].DataPropertyName = "MTMD_MOV_PROTOCOLO_ID";
            dtgProtocolos.Columns[colData.Name].DataPropertyName = "MTMD_MOV_PROTOCOLO_DATA";            
            dtgProtocolos.Columns[colQtd.Name].DataPropertyName = MovimentacaoDTO.FieldNames.Qtde;            

            lblAtendimento.Text = _dtoMovimento.IdtAtendimento.Value + " - " + _nomePaciente;
        }

        private bool tsHac_PesquisarClick(object sender)
        {
            if (txtInicio.Text != string.Empty && txtFim.Text != string.Empty)
            {
                try
                {
                    if (Convert.ToDateTime(txtFim.Text) < Convert.ToDateTime(txtInicio.Text))
                    {
                        MessageBox.Show("A Data Fim deve ser maior ou igual à Data Início.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtFim.Focus();
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show("Data inválida.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            _dtoMovimento.DataMovimento.Value = new Framework.DTO.TypeDateTime();
            _dtoMovimento.DataAte.Value = new Framework.DTO.TypeDateTime();

            if (txtInicio.Text != string.Empty)
                _dtoMovimento.DataMovimento.Value = txtInicio.Text;
            else if (txtFim.Text != string.Empty)
                _dtoMovimento.DataMovimento.Value = txtFim.Text;

            if (txtFim.Text != string.Empty)
                _dtoMovimento.DataAte.Value = txtFim.Text;
            else if (txtInicio.Text != string.Empty)
                _dtoMovimento.DataAte.Value = DateTime.Now.Date;

            decimal? numProtocolo = null;
            if (!string.IsNullOrEmpty(txtNumProtocolo.Text))
                numProtocolo = decimal.Parse(txtNumProtocolo.Text);

            dtgProtocolos.DataSource = Movimento.ObterProtocolosPaciente(_dtoMovimento, numProtocolo);
            dtgProtocolos.ClearSelection();

            return default(bool);
        }

        private void dtgProtocolos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == dtgProtocolos.Columns[colImprimir.Name].Index)
                {
                    this.Cursor = Cursors.WaitCursor;

                    new Generico().ImprimirProtocolo(decimal.Parse(dtgProtocolos.Rows[e.RowIndex].Cells[colNumProt.Name].Value.ToString()),
                                                     (decimal)_dtoMovimento.IdtAtendimento.Value,
                                                     _nomePaciente,
                                                     (decimal)_dtoMovimento.IdtSetor.Value,
                                                     DateTime.Parse(dtgProtocolos.Rows[e.RowIndex].Cells[colData.Name].Value.ToString()));
                    this.Cursor = Cursors.Default;
                    tsHac.Focus();                    
                }
            }
        }
    }
}