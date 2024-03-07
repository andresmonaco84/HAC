using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using System.Threading;
using HospitalAnaCosta.SGS.Cadastro.View;
using HospitalAnaCosta.Services.Repasse.Interface;
using HospitalAnaCosta.Services.Repasse.DTO;
using HospitalAnaCosta.Services.Repasse.View;
using HospitalAnaCosta.SGS.Cadastro.Interface;


namespace Hac.Windows.Forms.Controls
{
    public partial class HacPesquisaDinamica : UserControl
    {
        
        private ClinicaDataTable dtbClinica;

        private DataTable dtbUnidadePagamentoGrid;
        private DataTable dtbBaseCalculoGrid;
        private DataTable dtbResumoPagamento;

        public HacPesquisaDinamica()
        {
            InitializeComponent();
            
            dtbClinica = new ClinicaDataTable();
            
            dgvClinica.AutoGenerateColumns = false;
            ctlClinica.Enabled = true;
            

            UnidadePagamentoDTO dtoUnidadePagamento =  new UnidadePagamentoDTO();
            DataTable dtbUnidadePagamento = UnidadePagamento.ListarJoinUnidade(dtoUnidadePagamento);                                              

            cbxUnidadePagamento.DisplayMember = "CAD_UNI_DS_UNIDADE";
            cbxUnidadePagamento.ValueMember = "CAD_UNI_ID_UNIDADE";            
            cbxUnidadePagamento.DataSource = dtbUnidadePagamento;

            CadastroBaseCalculoDataTable dtbCadastroBaseCalculo = CadastroBaseCalculo.ListarDistinto(new CadastroBaseCalculoDTO());
            cbxBaseCalculo.DisplayMember = "CAD_REP_TP_BASE_CALCULO";
            cbxBaseCalculo.ValueMember = "CAD_REP_TP_BASE_CALCULO";                        
            cbxBaseCalculo.DataSource = dtbCadastroBaseCalculo;
            
            dtbUnidadePagamentoGrid = new DataTable("UnidadePagamento");
            dtbUnidadePagamentoGrid.Columns.Add("CAD_UNI_ID_UNIDADE");
            dtbUnidadePagamentoGrid.Columns.Add("CAD_UNI_DS_UNIDADE");

            dtbBaseCalculoGrid = new DataTable("BaseCalculo");
            dtbBaseCalculoGrid.Columns.Add("CAD_REP_TP_BASE_CALCULO");

            dtbResumoPagamento = new DataTable("ResumoPagamento");
            dtbResumoPagamento.Columns.Add("CAD_CLC_CD_CLINICA");
            dtbResumoPagamento.Columns.Add("CAD_CLC_DS_DESCRICAO");
            dtbResumoPagamento.Columns.Add("CAD_UNI_DS_UNIDADE");
            dtbResumoPagamento.Columns.Add("ASS_RPG_PC_HAC");
            dtbResumoPagamento.Columns.Add("ASS_RPG_PC_ACS");
            dtbResumoPagamento.Columns.Add("REP_TOTAL_ORIGINAL");
            dtbResumoPagamento.Columns.Add("REP_RPA_VL_ACRESCIMO");
            dtbResumoPagamento.Columns.Add("REP_RPA_VL_DESCONTO");
            dtbResumoPagamento.Columns.Add("REP_TOTAL_FINAL");
            dtbResumoPagamento.Columns.Add("REP_RPA_DT_PAGAMENTO");
            dtbResumoPagamento.Columns.Add("REP_RPA_DT_INICIO");
            dtbResumoPagamento.Columns.Add("REP_RPA_DT_FIM");
            dtbResumoPagamento.Columns.Add("ID_CAD_JPG");

        }

        #region eventos

        #endregion

        #region propriedades        
        #endregion propriedades


        public DataTable Pesquisar()
        {
            DataTable dtbPagamentoMedico = new DataTable();
            DataTable dtbPagamentoProfissionalClinica = new DataTable();
            PagamentoMedicoDTO dtoPagamentoMedico = new PagamentoMedicoDTO();
            PagamentoProfissionalClinicaDTO dtoPagamentoProfissionalClinica = new PagamentoProfissionalClinicaDTO();

            dtoPagamentoMedico.AnoPagamento.Value = edtMesAnoPagamento.Text.Split('/')[1];
            dtoPagamentoMedico.MesPagamento.Value = edtMesAnoPagamento.Text.Split('/')[0];

            dtoPagamentoProfissionalClinica.AnoPagto.Value = edtMesAnoPagamento.Text.Split('/')[1]; ;
            dtoPagamentoProfissionalClinica.MesPagto.Value = edtMesAnoPagamento.Text.Split('/')[0];

            String lIdtClinicas = "";
            String lBaseDeCalculo = "";
            String lIdtUnidadePagamento = "";
           

            for (int i = 0; i < dgvClinica.Rows.Count; i++)
            {
                if (i == 0)
                    lIdtClinicas += dgvClinica.Rows[i].Cells[0].Value.ToString();
                else
                    lIdtClinicas += "," + dgvClinica.Rows[i].Cells[0].Value.ToString();
            }

            for (int i = 0; i < dgvUnidadePagamento.Rows.Count; i++)
            {
                if (i == 0)
                    lIdtUnidadePagamento += dgvUnidadePagamento.Rows[i].Cells[0].Value.ToString();
                else
                    lIdtUnidadePagamento += "," + dgvUnidadePagamento.Rows[i].Cells[0].Value.ToString();
            }

            for (int i = 0; i < dgvBaseCalculo.Rows.Count; i++)
            {
                if (i == 0)
                    lBaseDeCalculo += dgvBaseCalculo.Rows[i].Cells[0].Value.ToString();
                else
                    lBaseDeCalculo += "," + dgvBaseCalculo.Rows[i].Cells[0].Value.ToString();
            }

            //dtbPagamentoMedico = PagamentoMedico.ListarParaFinalizar(dtoPagamentoMedico, lBaseDeCalculo, lIdtClinicas, lIdtUnidadePagamento);
            //dtbPagamentoProfissionalClinica = PagamentoProfissionalClinica.ListarParaFinalizar(dtoPagamentoProfissionalClinica, lBaseDeCalculo, lIdtClinicas, lIdtUnidadePagamento);

            for (int i = 0; i < dtbPagamentoMedico.Rows.Count; i++)
            {
                object[] row ={ 
                            dtbPagamentoMedico.Rows[i]["CAD_CLC_ID"], 
                            dtbPagamentoMedico.Rows[i]["CAD_CLC_DS_DESCRICAO"],
                            dtbPagamentoMedico.Rows[i]["CAD_UNI_DS_UNIDADE"],
                            dtbPagamentoMedico.Rows[i]["ASS_RPG_PC_HAC"],
                            dtbPagamentoMedico.Rows[i]["ASS_RPG_PC_ACS"],
                            dtbPagamentoMedico.Rows[i]["REP_PGM_VL_CALCULADO"], //REP_TOTAL_ORIGINAL
                            0, // REP_RPA_VL_ACRESCIMO
                            0, // REP_RPA_VL_DESCONTO
                            0, // REP_TOTAL_FINAL
                            dtbPagamentoMedico.Rows[i]["REP_PGM_DT_PAGAMENTO"],
                            "", // REP_RPA_DT_INICIO
                            "", //REP_RPA_DT_FIM
                            "" }; //ID_CAD_JPG

                dtbResumoPagamento.Rows.Add(row);                            
            }

            for (int i = 0; i < dtbPagamentoProfissionalClinica.Rows.Count; i++)
            {
                object[] row ={ 
                            dtbPagamentoProfissionalClinica.Rows[i]["CAD_CLC_ID"], 
                            dtbPagamentoProfissionalClinica.Rows[i]["CAD_CLC_DS_DESCRICAO"],
                            dtbPagamentoProfissionalClinica.Rows[i]["CAD_UNI_DS_UNIDADE"],
                            dtbPagamentoProfissionalClinica.Rows[i]["ASS_RPG_PC_HAC"],
                            dtbPagamentoProfissionalClinica.Rows[i]["ASS_RPG_PC_ACS"],
                            Convert.ToDouble(dtbPagamentoProfissionalClinica.Rows[i]["REP_PPC_VL_PAGO_HAC"]) + Convert.ToDouble(dtbPagamentoProfissionalClinica.Rows[i]["REP_PPC_VL_PAGO_ASC"]) , //REP_TOTAL_ORIGINAL
                            0, // REP_RPA_VL_ACRESCIMO
                            0, // REP_RPA_VL_DESCONTO
                            0, // REP_TOTAL_FINAL
                            dtbPagamentoProfissionalClinica.Rows[i]["REP_PMG_DT_PAGAMENTO"],
                            "", // REP_RPA_DT_INICIO
                            "", //REP_RPA_DT_FIM
                            "" }; //ID_CAD_JPG

                dtbResumoPagamento.Rows.Add(row);

            }

            return dtbResumoPagamento;
        }

        #region respostas a eventos

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                object[] row ={ cbxUnidadePagamento.SelectedValue, (cbxUnidadePagamento.SelectedItem as DataRowView).Row["CAD_UNI_DS_UNIDADE"].ToString() };
                dtbUnidadePagamentoGrid.Rows.Add(row);
            
                this.dgvUnidadePagamento.DataSource = dtbUnidadePagamentoGrid;
            }
            catch
            {
            }            
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            try
            {                
                object[] row ={ (cbxBaseCalculo.SelectedItem as DataRowView).Row["CAD_REP_TP_BASE_CALCULO"].ToString() };
                dtbBaseCalculoGrid.Rows.Add(row);

                this.dgvBaseCalculo.DataSource = dtbBaseCalculoGrid;                
            }
            catch
            {
            }            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                dtbClinica.Add(ctlClinica.DtoClinica);

                this.dgvClinica.DataSource = dtbClinica;
            }
            catch
            {
            }
        }


        #endregion



        private CommonRepasse _commonRepasse;
        protected CommonRepasse CommonRepasse
        {
            get { return _commonRepasse != null ? _commonRepasse : _commonRepasse = new CommonRepasse(FrmBase.DtoPassport); }
        }

        /// <summary>
        /// UnidadePagamento
        /// </summary>
        private IUnidadePagamento _UnidadePagamento;
        public IUnidadePagamento UnidadePagamento
        {
            get
            {
                return _UnidadePagamento != null ? _UnidadePagamento : _UnidadePagamento = 
                    (IUnidadePagamento)CommonRepasse.GetObject(typeof(IUnidadePagamento));
            }
        }

        /// <summary>
        /// UnidadePagamento
        /// </summary>
        private ICadastroBaseCalculo _cadastroBaseCalculo;
        public ICadastroBaseCalculo CadastroBaseCalculo
        {
            get
            {
                return _cadastroBaseCalculo != null ? _cadastroBaseCalculo : _cadastroBaseCalculo =
                    (ICadastroBaseCalculo)CommonRepasse.GetObject(typeof(ICadastroBaseCalculo));
            }
        }

        /// <summary>
        /// PagamentoMedico
        /// </summary>
        private IPagamentoMedico _pagamentoMedico;
        public IPagamentoMedico PagamentoMedico
        {
            get
            {
                return _pagamentoMedico != null ? _pagamentoMedico : _pagamentoMedico =
                    (IPagamentoMedico)CommonRepasse.GetObject(typeof(IPagamentoMedico));
            }
        }

        /// <summary>
        /// PagamentoProfissionalClinica
        /// </summary>
        private IPagamentoProfissionalClinica _pagamentoProfissionalClinica;
        public IPagamentoProfissionalClinica PagamentoProfissionalClinica
        {
            get
            {
                return _pagamentoProfissionalClinica != null ? _pagamentoProfissionalClinica : _pagamentoProfissionalClinica =
                    (IPagamentoProfissionalClinica)CommonRepasse.GetObject(typeof(IPagamentoProfissionalClinica));
            }
        }

        /// <summary>
        /// ResumoPagamento
        /// </summary>
        private IResumoPagamento _resumoPagamento;
        public IResumoPagamento ResumoPagamento
        {
            get
            {
                return _resumoPagamento != null ? _resumoPagamento : _resumoPagamento =
                    (IResumoPagamento)CommonRepasse.GetObject(typeof(IResumoPagamento));
            }
        }


    }
}
