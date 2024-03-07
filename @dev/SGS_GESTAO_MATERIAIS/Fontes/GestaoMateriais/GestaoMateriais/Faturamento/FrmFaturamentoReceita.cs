using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.SGS.GestaoMateriais;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Componentes;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Faturamento
{
    public partial class FrmFaturamentoReceita : FrmBase
    {
        public FrmFaturamentoReceita()
        {
            InitializeComponent();
        }

        #region Objetos Serviço
        
        //private CommonCadastro _commonCadastro;
        //protected new CommonCadastro CommonCadastro
        //{
        //    get { return _commonCadastro != null ? _commonCadastro : _commonCadastro = new CommonCadastro(null); }
        //}
        
        // Atendimento
        private PacienteDTO dtoAtendimento;
        private PacienteDataTable dtbAtendimento;
        private IPaciente _atendimento;
        private IPaciente Atendimento
        {
            get { return _atendimento != null ? _atendimento : _atendimento = (IPaciente)Global.Common.GetObject( typeof(IPaciente)); }
        }

        // Itens Requisição        
        private MaterialMedicamentoDataTable _dtbMamed;
        private MaterialMedicamentoDataTable dtbMatMed
        {
            get { return _dtbMamed != null ? _dtbMamed : _dtbMamed = new MaterialMedicamentoDataTable(); }
        }
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject( typeof(IMaterialMedicamento)); }
        }

        // Movimentos
        private MovimentacaoDTO dtoMovimento;
        private MovimentacaoDataTable dtbMovimento = new MovimentacaoDataTable();
        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject( typeof(IMovimentacao)); }
        }

        // MatMed
        //private MaterialMedicamentoDTO dtoMatMed;
        private MaterialMedicamentoDTO dtoMatMed = new MaterialMedicamentoDTO();        

        // Filial        
        private IFilialMatMed _filialMatMed;
        private IFilialMatMed FilialMatMed
        {
            get { return _filialMatMed != null ? _filialMatMed : _filialMatMed = (IFilialMatMed)Global.Common.GetObject( typeof(IFilialMatMed)); }
        }

        #endregion

        #region Métodos

        private void ConfiguraMovimentoDTO()
        {
            dtoMovimento = new MovimentacaoDTO();            
            
            dtoMovimento.IdtAtendimento.Value = dtoAtendimento.Idt.Value;            
            dtoMovimento.TpAtendimento.Value = Atendimento.ObterTipoAtendimento(dtoAtendimento).TpAtendimento.Value;
        }

        private void ConfiguraDTG()
        {
            dtgHistConsumo.AutoGenerateColumns = false;
            dtgHistConsumo.Columns["colIdtMovimentoHist"].DataPropertyName = MovimentacaoDTO.FieldNames.Idt;
            dtgHistConsumo.Columns["colIdtProdutoHist"].DataPropertyName = MovimentacaoDTO.FieldNames.IdtProduto;
            dtgHistConsumo.Columns["colDsProdutoHist"].DataPropertyName = MovimentacaoDTO.FieldNames.DsProduto;
            dtgHistConsumo.Columns["colDataHist"].DataPropertyName = MovimentacaoDTO.FieldNames.DataMovimento;
            dtgHistConsumo.Columns["colDataHist"].DefaultCellStyle.Format = "dd/MM/yyyy à\\s HH:mm:ss";
            dtgHistConsumo.Columns["colQtdHist"].DataPropertyName = MovimentacaoDTO.FieldNames.DsQtdeConsumo;
            dtgHistConsumo.Columns["colQtdHist"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;            
            dtgHistConsumo.Columns["colQtdInteiraHist"].DataPropertyName = MovimentacaoDTO.FieldNames.Qtde;
            dtgHistConsumo.Columns["colFaturado"].DataPropertyName = MovimentacaoDTO.FieldNames.FlFaturado;
        }

        private void CarregarHistoricoConsumo()
        {
            //lblLegenda.Visible = false;
            ConfiguraMovimentoDTO();
            // dtgHistConsumo.DataSource = Movimento.Sel(dtoMovimento, true);
        }

        private void CarregaInfoPaciente(HospitalAnaCosta.SGS.GestaoMateriais.DTO.PacienteDTO dto)
        {
            if (!dto.NmPaciente.Value.IsNull)
            {
                FilialMatMedDTO dtoFilial = new FilialMatMedDTO();
                txtNomePac.Text = dto.NmPaciente.Value;
                txtNroInternacao.Text = dto.Idt.Value.ToString();
                txtCodConvenio.Text = dto.CdPlano.Value;
                txtNomeConvenio.Text = dto.NmPlano.Value;
                txtLocal.Text = dto.DsSetor.Value;
                txtQuartoLeito.Text = string.Format("{0} / {1}", dto.CdQuarto.ToString(), dto.CdLeito.ToString());
                dtoFilial.TpPlano.Value = dto.TpPlano.Value;                

                this.CarregarHistoricoConsumo();
            }
        }

        private void PesquisarPaciente()
        {
            dtoAtendimento = new HospitalAnaCosta.SGS.GestaoMateriais.DTO.PacienteDTO();
            dtbAtendimento = new HospitalAnaCosta.SGS.GestaoMateriais.DTO.PacienteDataTable();

            if (this.Validar())
            {
                dtoAtendimento.IdtUnidade.Value = 244;
                dtoAtendimento.IdtLocalAtendimento.Value = 29;
                dtoAtendimento.IdtSetor.Value = 1;
                dtoAtendimento.TpAtendimento.Value = this.ObterTipoAtendimento();

                //if (txtNroInternacao.Text.Length != 0)
                //{
                //    dtoAtendimento.Idt.Value = Convert.ToInt64(txtNroInternacao.Text);
                //    dtbAtendimento = Atendimento.Sel(dtoAtendimento);
                //    if (dtbAtendimento.Rows.Count != 0)
                //    {
                //        dtoAtendimento = dtbAtendimento.TypedRow(0);
                //    }
                //    else
                //    {
                //        MessageBox.Show("Não foi encontrado Paciente Internado com essa sequência", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //        txtNroInternacao.Focus();
                //    }
                //}
                //else
                //{
                //    dtoAtendimento = FrmAtendimentoSetor.BuscaAtendimento(dtoAtendimento);
                //}
                                
                //dtoAtendimento.IdtUnidade.Value = 244;
                //dtoAtendimento.IdtLocalAtendimento.Value = 29;
                //dtoAtendimento.IdtSetor.Value = 1;
                dtoAtendimento.TpAtendimento.Value = this.ObterTipoAtendimento();

                this.CarregaInfoPaciente(dtoAtendimento);
            }
        }

        private bool ValidarTipoAtendimento()
        {
            if (!rbInternado.Checked && !rbAmbulatorio.Checked)
            {
                MessageBox.Show("Selecione o Tipo de Atendimento", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private bool Validar()
        {
            return this.ValidarTipoAtendimento();
        }

        private string ObterTipoAtendimento()
        {
            return rbInternado.Checked ? HospitalAnaCosta.SGS.GestaoMateriais.DTO.PacienteDTO.TipoAtendimentoSGS.INTERNADO : HospitalAnaCosta.SGS.GestaoMateriais.DTO.PacienteDTO.TipoAtendimentoSGS.AMBULATORIO;
        }

        #endregion

        #region Eventos

        private void FaturamentoReceita_Load(object sender, EventArgs e)
        {
            ConfiguraDTG();             
        }

        private void btnPesquisaPac_Click(object sender, EventArgs e)
        {
            this.PesquisarPaciente();
        }

        private void txtNroInternacao_Validated(object sender, EventArgs e)
        {
            if (txtNroInternacao.Text.Length != 0) btnPesquisaPac_Click(sender, e);
        }

        private void dtgHistConsumo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {   
            if (dtgHistConsumo.Columns[e.ColumnIndex].Name == "colPrecoCusto")
            {
                MovimentacaoDTO dtoMov = new MovimentacaoDTO();

                dtoMov.IdtProduto.Value = 1;
                dtoMov.IdtFilial.Value = 1;

                e.Value = this.MatMed.ObterCustoMedio(dtoMov).ToString();
            }
        }

        #endregion                
    }
}