using System;
using System.ComponentModel;
using System.Data;
using HospitalAnaCosta.Framework.Events;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using HospitalAnaCosta.SGS.Cadastro.Interface;

namespace Hac.Windows.Forms.Controls
{     
    public partial class HacCmbClassificacaoContabil : HacComboBox
    {
        CadastroClassificacaoContabilDTO dtocadastroClassificacaoContabil = new CadastroClassificacaoContabilDTO();
        private ICadastroClassificacaoContabil _cadastroClassificacaoContabil;
        protected ICadastroClassificacaoContabil CadastroClassificacaoContabil
        {
            get { return _cadastroClassificacaoContabil != null ? _cadastroClassificacaoContabil : _cadastroClassificacaoContabil = (ICadastroClassificacaoContabil)CommonServices.GetObject(typeof(ICadastroClassificacaoContabil)); }
        }

        public HacCmbClassificacaoContabil()
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

        public HacCmbClassificacaoContabil(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void Inicializar()
        {
            CarregarComboClassificacaoContabil(dtocadastroClassificacaoContabil);
        }

        [Category("Hac")]
        public void CarregarComboClassificacaoContabil(CadastroClassificacaoContabilDTO dto)
        {
            this.DataSource = null;            
            dtbClassificacaoContabil = CadastroClassificacaoContabil.Listar(dto);

            DataView dv = dtbClassificacaoContabil.DefaultView;
            dv.Sort = "CAD_CAC_DS_CLASSCONTABIL ASC";
            dtbClassificacaoContabil = dv.ToTable();

            this.CarregarComboComSelecione(this, dtbClassificacaoContabil, CadastroClassificacaoContabilDTO.FieldNames.IdtClassificacaoContabil, CadastroClassificacaoContabilDTO.FieldNames.DescricaoClassificacaoContabil);
        }

                [Category("Hac")]
        public void CarregarComboClassificacaoContabilComCodigo(CadastroClassificacaoContabilDTO dto)
        {
            this.DataSource = null;            
            dtbClassificacaoContabil = CadastroClassificacaoContabil.Listar(dto);

            DataView dv = dtbClassificacaoContabil.DefaultView;
            dv.Sort = "CAD_CAC_DS_CLASSCONTABIL ASC";
            dtbClassificacaoContabil = dv.ToTable();


            dtbClassificacaoContabil.Columns.Add("DescricaoCombo", typeof(string));

            for (int i = 0; i < dtbClassificacaoContabil.Rows.Count; i++)
            {
                dtbClassificacaoContabil.Rows[i]["DescricaoCombo"] = dtbClassificacaoContabil.Rows[i][CadastroClassificacaoContabilDTO.FieldNames.CodigoClassificacaoContabil].ToString() + " - " + dtbClassificacaoContabil.Rows[i][CadastroClassificacaoContabilDTO.FieldNames.DescricaoClassificacaoContabil].ToString();
            }

            this.CarregarComboComSelecione(this, dtbClassificacaoContabil, CadastroClassificacaoContabilDTO.FieldNames.IdtClassificacaoContabil, "DescricaoCombo");
        }

        private DataTable dtbClassificacaoContabil;

        public DataTable DtbClassificacaoContabil
        {
            get { return dtbClassificacaoContabil; }
            set { dtbClassificacaoContabil = value; }
        }
    }
}

