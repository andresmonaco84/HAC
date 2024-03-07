using System;
using System.ComponentModel;
using System.Data;
using HospitalAnaCosta.Framework.Events;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using HospitalAnaCosta.SGS.Cadastro.Interface;


namespace Hac.Windows.Forms.Controls
{     
    public partial class HacCmbTabelaMedica : HacComboBox
    {
        TabelaMedicaDTO tabelaMedicaDTO = new TabelaMedicaDTO();
        private ITabelaMedica _tabelaMedica;
        protected ITabelaMedica TabelaMedica
        {
            get { return _tabelaMedica != null ? _tabelaMedica : _tabelaMedica = (ITabelaMedica)CommonServices.GetObject(typeof(ITabelaMedica)); }
        }

        private IConvenioTabelaUtilizada _convenioTabelaUtilizada;
        protected IConvenioTabelaUtilizada ConvenioTabelaUtilizada
        {
            get
            {
                return _convenioTabelaUtilizada != null ? _convenioTabelaUtilizada : _convenioTabelaUtilizada = (IConvenioTabelaUtilizada)CommonServices.GetObject(typeof(IConvenioTabelaUtilizada));
            }
        }

        public HacCmbTabelaMedica()
        {
            InitializeComponent();
        }

        protected override void OnSelectionChangeCommitted(System.EventArgs e)
        {
            HacComboEventArgs eCombo = new HacComboEventArgs();
            eCombo.Value = this.SelectedValue.ToString();
            OnSelecionar(eCombo);
        }

        public delegate void SelecionarDelegate(object sender, HacComboEventArgs e);

        private bool _utilizaLancamento;
        [Category("Hac")]
        public bool UtilizaLancamento
        {
            get { return _utilizaLancamento; }
            set { _utilizaLancamento = value; }            
        }

        [Category("Hac")]
        public event SelecionarDelegate Selecionar;

        [Category("Hac")]
        protected virtual void OnSelecionar(HacComboEventArgs e)
        {
            if (Selecionar != null)
            {
                Selecionar(this, e);
            }
        }

        public HacCmbTabelaMedica(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void Inicializar()
        {
            CarregarComboTabelaMedica(tabelaMedicaDTO);
        }

        [Category("Hac")]
        public void CarregarComboLancamentoAutomatico()
        {
            TabelaMedicaDTO dto = new TabelaMedicaDTO();
            dto.FlagUtilizaLancamento.Value = "S";

            this.DataSource = null;

            DataTable dtbTabelaMedica = TabelaMedica.Listar(dto);
            DataView dv = dtbTabelaMedica.DefaultView;
            dv.Sort = TabelaMedicaDTO.FieldNames.DescricaoTabelaMedica;
            dtbTabelaMedica = dv.ToTable();

            this.CarregarComboComSelecione(this, dtbTabelaMedica, TabelaMedicaDTO.FieldNames.CodigoTabelaMedica, TabelaMedicaDTO.FieldNames.DescricaoTabelaMedica);
        }



        [Category("Hac")]
        public void CarregarComboTabelaMedica(TabelaMedicaDTO dto)
        {
            this.CarregarComboTabelaMedica(dto, false);
        }

        [Category("Hac")]
        public void CarregarComboTabelaMedica(TabelaMedicaDTO dto, bool adicionarIdtDescricao)
        {
            this.DataSource = null;

            DataTable dtbTabelaMedica;

            if (_utilizaLancamento)
                dto.FlagUtilizaLancamento.Value = "S";
            
            dtbTabelaMedica = TabelaMedica.Listar(dto);

            DataView dv = dtbTabelaMedica.DefaultView;
            dv.Sort = "TIS_MED_DS_TABELAMEDICA ASC";
            dtbTabelaMedica = dv.ToTable();
            
            if (adicionarIdtDescricao)
            {
                foreach (DataRow row in dtbTabelaMedica.Rows)
                {
                    row[TabelaMedicaDTO.FieldNames.DescricaoTabelaMedica] = string.Format("{0} - {1}", row[TabelaMedicaDTO.FieldNames.CodigoTabelaMedica].ToString().Trim().PadRight(2,' '),
                                                                                                       row[TabelaMedicaDTO.FieldNames.DescricaoTabelaMedica]);
                }
            }
            
            this.CarregarComboComSelecione(this, dtbTabelaMedica, TabelaMedicaDTO.FieldNames.CodigoTabelaMedica, TabelaMedicaDTO.FieldNames.DescricaoTabelaMedica);
        }

        [Category("Hac")] //95 MAT.  //96 MED.
        public void CarregarComboTabelaMedicaMatMed(TabelaMedicaDTO dto)
        {
            DataTable dtbTabelaMedica;
            dtbTabelaMedica = TabelaMedica.Listar(dto);            
            
            DataView dv = dtbTabelaMedica.DefaultView;
            dv.RowFilter = "TIS_MED_CD_TABELAMEDICA IN (95,96)";
            dv.Sort = "TIS_MED_DS_TABELAMEDICA ASC";
            dtbTabelaMedica = dv.ToTable();

            this.CarregarComboComSelecione(this, dtbTabelaMedica, TabelaMedicaDTO.FieldNames.CodigoTabelaMedica, TabelaMedicaDTO.FieldNames.DescricaoTabelaMedica);
        }

        [Category("Hac")] //95 MAT.  //96 MED. //12 SIMPRO //5 BRASINDICE
        public void CarregarComboTabelaMedicaMatMedBrasindiceSimpro(TabelaMedicaDTO dto)
        {
            DataTable dtbTabelaMedica;
            dtbTabelaMedica = TabelaMedica.Listar(dto);

            DataView dv = dtbTabelaMedica.DefaultView;
            dv.RowFilter = "TIS_MED_CD_TABELAMEDICA IN (95,96,5,12)";
            dv.Sort = "TIS_MED_DS_TABELAMEDICA ASC";
            dtbTabelaMedica = dv.ToTable();

            this.CarregarComboComSelecione(this, dtbTabelaMedica, TabelaMedicaDTO.FieldNames.CodigoTabelaMedica, TabelaMedicaDTO.FieldNames.DescricaoTabelaMedica);
        }
        [Category("Hac")] //TODAS -//95 MAT.  //96 MED. //12 SIMPRO //5 BRASINDICE
        public void CarregarComboTabelaMedicaEXCETOMatMedBrasindiceSimpro(TabelaMedicaDTO dto)
        {
            DataTable dtbTabelaMedica;
            dtbTabelaMedica = TabelaMedica.Listar(dto);

            DataView dv = dtbTabelaMedica.DefaultView;
            dv.RowFilter = "TIS_MED_CD_TABELAMEDICA NOT IN (95,96,5,12)";
            dv.Sort = "TIS_MED_DS_TABELAMEDICA ASC";
            dtbTabelaMedica = dv.ToTable();

            this.CarregarComboComSelecione(this, dtbTabelaMedica, TabelaMedicaDTO.FieldNames.CodigoTabelaMedica, TabelaMedicaDTO.FieldNames.DescricaoTabelaMedica);
        }

        [Category("Hac")]  //CARREGA TODAS AS TABELAS QUE UTILIZAM REPASSE
        public void CarregarComboTabelaMedicaRepasse()
        {
            DataTable dtbTabelaMedica;
            TabelaMedicaDTO dto = new TabelaMedicaDTO();
            dtbTabelaMedica = TabelaMedica.Listar(dto);
            
            DataView dv = dtbTabelaMedica.DefaultView;
            dv.RowFilter = "TIS_MED_FL_UTILIZA_REPASSE = 'S'";
            dv.Sort = "TIS_MED_DS_TABELAMEDICA ASC";
            dtbTabelaMedica = dv.ToTable();

            this.CarregarComboComSelecione(this, dtbTabelaMedica, TabelaMedicaDTO.FieldNames.CodigoTabelaMedica, TabelaMedicaDTO.FieldNames.DescricaoTabelaMedica);
        }


        [Category("Hac")]
        public void CarregarComboTabelaMedica(DataTable dtbTabelaMedica)
        {
            this.DataSource = null;

            DataView dv = dtbTabelaMedica.DefaultView;
            dv.Sort = "TIS_MED_DS_TABELAMEDICA ASC";
            DataTable dtbTabelaMedicaOrdenado = dv.ToTable();

            this.CarregarComboComSelecione(this, dtbTabelaMedicaOrdenado, TabelaMedicaDTO.FieldNames.CodigoTabelaMedica, TabelaMedicaDTO.FieldNames.DescricaoTabelaMedica);
        }

        [Category("Hac")]
        public void CarregarComboTabelaMedicaConvenio(ConvenioDTO dtoConvenio)
        {
            this.DataSource = null;

            ConvenioTabelaUtilizadaDTO dtoCTU = new ConvenioTabelaUtilizadaDTO();
            dtoCTU.IdtConvenio.Value = dtoConvenio.IdtConvenio.Value;

            DataTable dtbAssociacao = ConvenioTabelaUtilizada.ListarJoinTudo(dtoCTU);

            DataView dv = dtbAssociacao.DefaultView;
            //dv.Sort = "COD_DESC_TABELA_COB ASC";
            dv.Sort = TabelaMedicaDTO.FieldNames.DescricaoTabelaMedica;
            DataTable dtbTabelaMedicaOrdenado = dv.ToTable();
            //dtbTabelaMedicaOrdenado = dtbTabelaMedicaOrdenado.DefaultView.ToTable(true, ConvenioTabelaUtilizadaDTO.FieldNames.CodigoTabelaMedicaCobranca, "COD_DESC_TABELA_COB");
            dtbTabelaMedicaOrdenado = dtbTabelaMedicaOrdenado.DefaultView.ToTable(true, ConvenioTabelaUtilizadaDTO.FieldNames.CodigoTabelaMedica, TabelaMedicaDTO.FieldNames.DescricaoTabelaMedica);

            //this.CarregarComboComSelecione(this, dtbTabelaMedicaOrdenado, ConvenioTabelaUtilizadaDTO.FieldNames.CodigoTabelaMedicaCobranca, "COD_DESC_TABELA_COB");
            this.CarregarComboComSelecione(this, dtbTabelaMedicaOrdenado, ConvenioTabelaUtilizadaDTO.FieldNames.CodigoTabelaMedica, TabelaMedicaDTO.FieldNames.DescricaoTabelaMedica);
        }

        [Category("Hac")]
        public void CarregarComboTabelaMedicaConvenioMatMed(ConvenioDTO dtoConvenio)
        {
            this.DataSource = null;

            ConvenioTabelaUtilizadaDTO dtoCTU = new ConvenioTabelaUtilizadaDTO();
            dtoCTU.IdtConvenio.Value = dtoConvenio.IdtConvenio.Value;

            DataTable dtbAssociacao = ConvenioTabelaUtilizada.ListarJoinTudo(dtoCTU);

            DataView dv = dtbAssociacao.DefaultView;
            dv.RowFilter = string.Format("{0} in ('MAT','MED')", ConvenioTabelaUtilizadaDTO.FieldNames.TipoAtributo);
            
            dv.Sort = "COD_DESC_TABELA_COB ASC";
            DataTable dtbTabelaMedicaOrdenado = dv.ToTable();
            dtbTabelaMedicaOrdenado = dtbTabelaMedicaOrdenado.DefaultView.ToTable(true, ConvenioTabelaUtilizadaDTO.FieldNames.CodigoTabelaMedicaCobranca, "COD_DESC_TABELA_COB");

            this.CarregarComboComSelecione(this, dtbTabelaMedicaOrdenado, ConvenioTabelaUtilizadaDTO.FieldNames.CodigoTabelaMedicaCobranca, "COD_DESC_TABELA_COB");
        }
    }
}