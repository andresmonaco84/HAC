using System;
using System.ComponentModel;
using System.Data;
using HospitalAnaCosta.Framework.Events;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using HospitalAnaCosta.SGS.Cadastro.Interface;

namespace Hac.Windows.Forms.Controls
{     
    public partial class HacCmbCentroDeCusto : HacComboBox
    {
        CadastroCentroCustoDTO dtoCadastroCentroCusto = new CadastroCentroCustoDTO();
        private ICadastroCentroCusto _cadastroCentroCusto;
        protected ICadastroCentroCusto CadastroCentroCusto
        {
            get { return _cadastroCentroCusto != null ? _cadastroCentroCusto : _cadastroCentroCusto = (ICadastroCentroCusto)CommonServices.GetObject(typeof(ICadastroCentroCusto)); }
        }

        public HacCmbCentroDeCusto()
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

        public HacCmbCentroDeCusto(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void Inicializar()
        {
            CarregarComboCentroDeCusto(dtoCadastroCentroCusto);
        }

        [Category("Hac")]
        public void CarregarComboCentroDeCusto(CadastroCentroCustoDTO dtoCadastroCentroCusto)
        {
            this.DataSource = null;

            DataTable dtbCentroDeCusto;
            dtbCentroDeCusto = CadastroCentroCusto.Listar(dtoCadastroCentroCusto);

            DataView dv = dtbCentroDeCusto.DefaultView;
            dv.Sort = "CAD_CEC_DS_CCUSTO ASC";
            dtbCentroDeCusto = dv.ToTable();

            this.CarregarComboComSelecione(this, dtbCentroDeCusto, CadastroCentroCustoDTO.FieldNames.IdtCentroCusto, CadastroCentroCustoDTO.FieldNames.DescricaoCentroCusto);
        }

        [Category("Hac")]
        public void CarregarComboCentroDeCustoComCodigo(CadastroCentroCustoDTO dtoCadastroCentroCusto)
        {
            this.DataSource = null;

            DataTable dtbCentroDeCusto;
            dtbCentroDeCusto = CadastroCentroCusto.Listar(dtoCadastroCentroCusto);

            DataView dv = dtbCentroDeCusto.DefaultView;
            dv.Sort = "CAD_CEC_CD_CCUSTO ASC";
            dtbCentroDeCusto = dv.ToTable();

            dtbCentroDeCusto.Columns.Add("DescricaoCombo", typeof(string));

            for (int i = 0; i < dtbCentroDeCusto.Rows.Count; i++)
            {
                dtbCentroDeCusto.Rows[i]["DescricaoCombo"] = dtbCentroDeCusto.Rows[i][CadastroCentroCustoDTO.FieldNames.CodigoCentroCusto].ToString() + " - " + dtbCentroDeCusto.Rows[i][CadastroCentroCustoDTO.FieldNames.DescricaoCentroCusto].ToString();
            }

            this.CarregarComboComSelecione(this, dtbCentroDeCusto, CadastroCentroCustoDTO.FieldNames.IdtCentroCusto, "DescricaoCombo");
        }

    }
}

