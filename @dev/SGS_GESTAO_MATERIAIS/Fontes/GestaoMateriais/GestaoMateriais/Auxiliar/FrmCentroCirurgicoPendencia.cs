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

namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    public partial class FrmCentroCirurgicoPendencia : FrmBase
    {

        MovimentacaoDTO dtoPendencia;


        // Movimentos
        private MovimentacaoDTO dtoMovimento;
        private MovimentacaoDataTable dtbMovimento = new MovimentacaoDataTable();
        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject(typeof(IMovimentacao)); }
        }


        
        public FrmCentroCirurgicoPendencia()
        {
            InitializeComponent();
        }

        public FrmCentroCirurgicoPendencia(MovimentacaoDTO dto)
        {
            InitializeComponent();
            this.MdiParent = FrmPrincipal.ActiveForm;
            dtoPendencia = dto;
        }


        private void ConfiguraDTG()
        {
            // 
            // 
            // 
            dtgCCirurgico.AutoGenerateColumns = false;
            dtgCCirurgico.Columns["colDtConsumo"].DataPropertyName = MovimentacaoDTO.FieldNames.DataMovimento;
            dtgCCirurgico.Columns["colIdtAtendimento"].DataPropertyName = MovimentacaoDTO.FieldNames.IdtAtendimento;
            dtgCCirurgico.Columns["colQtde"].DataPropertyName = MovimentacaoDTO.FieldNames.Qtde;

        }

        private void CarregaPendencias()
        {
            MovimentacaoDataTable dtb = new MovimentacaoDataTable();
            dtb = Movimento.PendenciaCCirurgico(dtoPendencia);
            dtgCCirurgico.DataSource = dtb;
            
        }

        private void FrmCentroCirurgicoPendencia_Load(object sender, EventArgs e)
        {
            ConfiguraDTG();
            CarregaPendencias();

        }
    }
}