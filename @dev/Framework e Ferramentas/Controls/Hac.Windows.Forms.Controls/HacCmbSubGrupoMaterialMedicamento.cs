using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using HospitalAnaCosta.Framework.Events;
using HospitalAnaCosta.Services.Produto.DTO;
using HospitalAnaCosta.Services.Produto.Interface;

namespace Hac.Windows.Forms.Controls
{     
    public partial class HacCmbSubGrupoMaterialMedicamento : HacComboBox
    {
        private string _nomeComboGrupo;
        [Category("Hac")]
        [Description("Nome do objeto combo referente ao Grupo. Se este campo não está preenchido, ele pega todo objeto HacCmbEspecialidadeProcedimento")]
        public string NomeComboGrupo
        {
            get { return _nomeComboGrupo; }
            set { _nomeComboGrupo = value; }
        }

        private ISubGrupoMatMed _subGrupoMatMed;
        protected ISubGrupoMatMed SubGrupoMatMed
        {
            get { return _subGrupoMatMed != null ? _subGrupoMatMed : _subGrupoMatMed = (ISubGrupoMatMed)CommonServices.GetObject(typeof(ISubGrupoMatMed)); }
        }

        SubGrupoMatMedDTO dtoSubGrupoMatMed = new SubGrupoMatMedDTO();

        public HacCmbSubGrupoMaterialMedicamento()
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

        public HacCmbSubGrupoMaterialMedicamento(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public void CarregaSubGrupoMatMed(SubGrupoMatMedDTO dtoSubGrupoMatMed)
        {
            this.Limpa();
            
            //this.ValueMember = SubGrupoMatMedDTO.FieldNames.Codigo;
            //this.DisplayMember = SubGrupoMatMedDTO.FieldNames.Descricao;
            //this.DataSource = SubGrupoMatMed.Listar(dtoSubGrupoMatMed);
            //this.IniciaLista();
            
            this.DataSource = null;
            DataTable dtbSubGrupoMatMed = new DataTable();
            dtbSubGrupoMatMed = SubGrupoMatMed.Sel(dtoSubGrupoMatMed);
            DataView dv = dtbSubGrupoMatMed.DefaultView;
            dv.Sort = "CAD_MTMD_SUBGRUPO_DESCRICAO ASC";

            dtbSubGrupoMatMed = dv.ToTable();

            this.CarregarComboComSelecione(this, dtbSubGrupoMatMed, SubGrupoMatMedDTO.FieldNames.Idt, SubGrupoMatMedDTO.FieldNames.DsSubGrupo);
        }

        private HacCmbGrupoProdutoMaterialMecicamento FindGrupo(ControlCollection controls)
        {
            Control control = null;
            foreach (Control ctr in controls)
            {
                if ((ctr is HacCmbGrupoProdutoMaterialMecicamento && string.IsNullOrEmpty(this.NomeComboGrupo)) ||
                    (ctr is HacCmbGrupoProdutoMaterialMecicamento && ctr.Name == this.NomeComboGrupo))
                {
                    control = ctr;
                    break;
                }
                else
                {
                    control = FindGrupo(ctr.Controls);
                    if (control != null) break;
                }
            }
            return control == null ? null : (HacCmbGrupoProdutoMaterialMecicamento)control;
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            HacCmbGrupoProdutoMaterialMecicamento cmbGrupo = FindGrupo(this.FindForm().Controls);

            if (cmbGrupo != null)
            {
                if (cmbGrupo.SelectedIndex == -1)
                {
                    if (this.SelectedIndex == -1) this.Limpa();
                }                
            }

            base.OnSelectedIndexChanged(e);
        }

        /// <summary>
        /// Funciona apenas se a propriedade Limpar = True.        
        /// </summary>
        public void LimparCmbSubGrupo()
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

