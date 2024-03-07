using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using HospitalAnaCosta.Framework.Events;
using HospitalAnaCosta.Services.Produto.DTO;
using HospitalAnaCosta.Services.Produto.Interface;


namespace Hac.Windows.Forms.Controls
{     
    public partial class HacCmbGrupoProdutoMaterialMecicamento : HacComboBox
    {
        private IGrupoMatMed _GrupoMatMed;
        protected IGrupoMatMed GrupoMatMed
        {
            get { return _GrupoMatMed != null ? _GrupoMatMed : _GrupoMatMed = (IGrupoMatMed)CommonServices.GetObject(typeof(IGrupoMatMed)); }
        }

        GrupoMatMedDTO dtoGrupoMatMed = new GrupoMatMedDTO();

        public HacCmbGrupoProdutoMaterialMecicamento()
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

        public HacCmbGrupoProdutoMaterialMecicamento(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public void CarregaGrupoMatMed(GrupoMatMedDTO dtoGrupoMatMed)
        {
            this.Limpa();
            
            //this.ValueMember = GrupoMatMedDTO.FieldNames.Codigo;
            //this.DisplayMember = GrupoMatMedDTO.FieldNames.Descricao;
            //this.DataSource = GrupoMatMed.Listar(dtoGrupoMatMed);
            //this.IniciaLista();
            
            this.DataSource = null;
            DataTable dtbGrupoMatMed = new DataTable();
            dtbGrupoMatMed = GrupoMatMed.Sel(dtoGrupoMatMed);
            DataView dv = dtbGrupoMatMed.DefaultView;
            dv.Sort = "CAD_MTMD_GRUPO_DESCRICAO ASC";

            dtbGrupoMatMed = dv.ToTable();

            this.CarregarComboComSelecione(this, dtbGrupoMatMed, GrupoMatMedDTO.FieldNames.Idt, GrupoMatMedDTO.FieldNames.DsGrupo);
        }
              
        

        /// <summary>
        /// Funciona apenas se a propriedade Limpar = True.        
        /// </summary>
        public void LimparCmbGrupoMatMed()
        {
            if (this.Limpar) this.LimparComboBox();
        }

        /// <summary>
        /// Zera o DataSource e os itens deste combo
        /// </summary>
        public void Limpa()
        {
            this.DataSource = null;
            this.Items.Clear();
            this.Text = string.Empty;
        }
    }
}

