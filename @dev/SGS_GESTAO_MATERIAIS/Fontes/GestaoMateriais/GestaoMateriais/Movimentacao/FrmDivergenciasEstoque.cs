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
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmDivergenciasEstoque : FrmBase
    {
        public FrmDivergenciasEstoque()
        {
            InitializeComponent();
        }

        #region OBJETOS SERVIÇO

        // Movimentos
        private MovimentacaoDTO dtoMovimento;
        private MovimentacaoDataTable dtbMovimento;
        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject(typeof(IMovimentacao)); }
        }   

        #endregion

        #region MÉTODOS

        private void ConfiguraDTG()
        {
            dtgDivergencia.AutoGenerateColumns = false;
            dtgDivergencia.Columns["colReqIdt"].DataPropertyName = MovimentacaoDTO.FieldNames.IdtRequisicao;
            dtgDivergencia.Columns["colDsUnidade"].DataPropertyName = MovimentacaoDTO.FieldNames.DsUnidade;
            dtgDivergencia.Columns["colDsSetor"].DataPropertyName = MovimentacaoDTO.FieldNames.DsSetor;
            dtgDivergencia.Columns["colDsProduto"].DataPropertyName = MovimentacaoDTO.FieldNames.DsProduto;
            dtgDivergencia.Columns["colData"].DataPropertyName = MovimentacaoDTO.FieldNames.DataMovimento;
            dtgDivergencia.Columns["colData"].DefaultCellStyle.Format = "dd/MM/yyyy à\\s HH:mm:ss";
            dtgDivergencia.Columns["colIdMov"].DataPropertyName = MovimentacaoDTO.FieldNames.Idt;
            dtgDivergencia.Columns["colQtd"].DataPropertyName = MovimentacaoDTO.FieldNames.Qtde;
        }

        private void CarregarDivergencias()
        {
            this.Cursor = Cursors.WaitCursor;
            dtoMovimento = new MovimentacaoDTO();
            dtoMovimento.FlFinalizado.Value = (byte)MovimentacaoDTO.StatusDivergencia.EM_DIVERGENCIA;
            if (rbHac.Checked)
            {
                dtoMovimento.IdtFilial.Value = (int)FilialMatMedDTO.Filial.HAC;
            }
            else if (rbAcs.Checked)
            {
                dtoMovimento.IdtFilial.Value = (int)FilialMatMedDTO.Filial.ACS;
            }
            else if (rbCE.Checked)
            {
                dtoMovimento.IdtFilial.Value = (int)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
            }
            dtbMovimento = Movimento.SelDivergencias(dtoMovimento);
            dtgDivergencia.DataSource = dtbMovimento;
            this.Cursor = Cursors.Default;
        }

        #endregion        

        #region EVENTOS

        private void FrmDivergenciasEstoque_Load(object sender, EventArgs e)
        {
            ConfiguraDTG();
            rbHac.Checked = true;
            rbHac.Checked = false;
        }

        private void rbHac_Click(object sender, EventArgs e)
        {
            CarregarDivergencias();
        }

        private void rbAcs_Click(object sender, EventArgs e)
        {
            CarregarDivergencias();
        }

        private void rbCE_Click(object sender, EventArgs e)
        {
            CarregarDivergencias();
        }

        private void dtgDivergencia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int nCount = 0; nCount < dtbMovimento.Rows.Count; nCount++)
            {
                if (dtbMovimento.Rows[nCount][MovimentacaoDTO.FieldNames.Idt].ToString() == dtgDivergencia.Rows[e.RowIndex].Cells["colIdMov"].Value.ToString())
                {
                    dtoMovimento = (MovimentacaoDTO)dtbMovimento.Rows[nCount];
                    break;
                }
            }
            FrmRegDiveg.RegistrarDivergencia(dtoMovimento);
            CarregarDivergencias();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dtgDivergencia.Columns["colIdMov"].Visible = !(dtgDivergencia.Columns["colIdMov"].Visible);
        }

        #endregion        
    }
}