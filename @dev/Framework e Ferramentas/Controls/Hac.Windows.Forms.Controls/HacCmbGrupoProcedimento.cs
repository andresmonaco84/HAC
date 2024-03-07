using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using HospitalAnaCosta.Framework.Events;
using HospitalAnaCosta.Services.Produto.DTO;
using HospitalAnaCosta.Services.Produto.Interface;


namespace Hac.Windows.Forms.Controls
{     
    public partial class HacCmbGrupoProcedimento : HacComboBox
    {
        private string _nomeComboEspecialidade;
        [Category("Hac")]
        [Description("Nome do objeto combo referente a Especialdiade. Se este campo não está preenchido, ele pega todo objeto HacCmbEspecialidadeProcedimento")]
        public string NomeComboEspecialidade
        {
            get { return _nomeComboEspecialidade; }
            set { _nomeComboEspecialidade = value; }
        }

        private IGrupoProcedimento _grupoProcedimento;
        protected IGrupoProcedimento GrupoProcedimento
        {
            get { return _grupoProcedimento != null ? _grupoProcedimento : _grupoProcedimento = (IGrupoProcedimento)CommonServices.GetObject(typeof(IGrupoProcedimento)); }
        }

        GrupoProcedimentoDTO dtoGrupoProcedimento = new GrupoProcedimentoDTO();

        public HacCmbGrupoProcedimento()
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


        private string codigoTabelaMedica;
        public string CodigoTabelaMedica
        {
            get { return codigoTabelaMedica; }
            set { codigoTabelaMedica = value; }
        }

        private string codigoEspecialidadeProcedimento;
        public string CodigoEspecialidadeProcedimento
        {
        get { return codigoEspecialidadeProcedimento; }
        set { codigoEspecialidadeProcedimento = value; }
    
        }


        public HacCmbGrupoProcedimento(IContainer container)
        {
            container.Add(this);
            InitializeComponent();        
        }

        public void CarregaGrupoProcedimento()
        {
            this.CarregaGrupoProcedimento(false);
        }

        public void CarregaGrupoProcedimento(bool adicionarIdtDescricao)
        {
            this.Limpa();

            GrupoProcedimentoDTO dtoGrupoProcedimento = new GrupoProcedimentoDTO();

            dtoGrupoProcedimento.CodigoTabelaMedica.Value = codigoTabelaMedica;
            dtoGrupoProcedimento.CodigoEspecialidade.Value = codigoEspecialidadeProcedimento;

            this.DataSource = null;
            DataTable dtbGrupoProcedimento = new DataTable();
            dtbGrupoProcedimento = GrupoProcedimento.Listar(dtoGrupoProcedimento);
            DataView dv = dtbGrupoProcedimento.DefaultView;
            dv.Sort = "AUX_GPC_DS_DESCRICAO ASC";

            dtbGrupoProcedimento = dv.ToTable();

            if (adicionarIdtDescricao)
            {
                foreach (DataRow row in dtbGrupoProcedimento.Rows)
                {
                    row[GrupoProcedimentoDTO.FieldNames.Descricao] = string.Format("{0} - {1}", row[GrupoProcedimentoDTO.FieldNames.Codigo],
                                                                                                row[GrupoProcedimentoDTO.FieldNames.Descricao]);
                }
            } 

            this.CarregarComboComSelecione(this, dtbGrupoProcedimento, GrupoProcedimentoDTO.FieldNames.Codigo, GrupoProcedimentoDTO.FieldNames.Descricao);

            this.Enabled = true;
        }
        
        public void CarregaGrupoProcedimento(GrupoProcedimentoDTO dtoGrupoProcedimento)
        {
            this.Limpa();
            
            //this.ValueMember = GrupoProcedimentoDTO.FieldNames.Codigo;
            //this.DisplayMember = GrupoProcedimentoDTO.FieldNames.Descricao;
            //this.DataSource = GrupoProcedimento.Listar(dtoGrupoProcedimento);
            //this.IniciaLista();
            
            this.DataSource = null;
            DataTable dtbGrupoProcedimento = new DataTable();
            dtbGrupoProcedimento = GrupoProcedimento.Listar(dtoGrupoProcedimento);
            DataView dv = dtbGrupoProcedimento.DefaultView;
            dv.Sort = "AUX_GPC_DS_DESCRICAO ASC";



            //if (CodigoTabelaMedica == "95" || CodigoTabelaMedica == "96")
            //{
            //    dv.RowFilter = "CAD_MTMD_SUBGRUPO_ID IS NOT NULL";
            //}
            //else if (CodigoTabelaMedica != null)
            //{
            //    dv.RowFilter = "CAD_MTMD_SUBGRUPO_ID IS NULL";
            //}

            dtbGrupoProcedimento = dv.ToTable();

            this.CarregarComboComSelecione(this, dtbGrupoProcedimento, GrupoProcedimentoDTO.FieldNames.Codigo, GrupoProcedimentoDTO.FieldNames.Descricao);
        }

        public void CarregaGrupoMaterialMedicamento(GrupoProcedimentoDTO dtoGrupoProcedimento)
        {
            this.Limpa();

            this.DataSource = null;
            DataTable dtbGrupoProcedimento = new DataTable();
            dtbGrupoProcedimento = GrupoProcedimento.Listar(dtoGrupoProcedimento);
            DataView dv = dtbGrupoProcedimento.DefaultView;
            //dv.RowFilter = "CAD_MTMD_SUBGRUPO_ID IS NOT NULL";
            dv.Sort = "AUX_GPC_DS_DESCRICAO ASC";

            dtbGrupoProcedimento = dv.ToTable();

            this.CarregarComboComSelecione(this, dtbGrupoProcedimento, GrupoProcedimentoDTO.FieldNames.Codigo, GrupoProcedimentoDTO.FieldNames.Descricao);
        }

        private HacCmbEspecialidadeProcedimento FindEspecialidade(ControlCollection controls)
        {
            Control control = null;
            foreach (Control ctr in controls)
            {
                if ((ctr is HacCmbEspecialidadeProcedimento && string.IsNullOrEmpty(this.NomeComboEspecialidade)) ||
                    (ctr is HacCmbEspecialidadeProcedimento && ctr.Name == this.NomeComboEspecialidade))
                {
                    control = ctr;
                    break;
                }
                else
                {
                    control = FindEspecialidade(ctr.Controls);
                    if (control != null) break;
                }
            }
            return control == null ? null : (HacCmbEspecialidadeProcedimento)control;
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            HacCmbEspecialidadeProcedimento cmbEspecialidade = FindEspecialidade(this.FindForm().Controls);

            if (cmbEspecialidade != null)
            {
                if (cmbEspecialidade.SelectedIndex == -1)
                {
                    if (this.SelectedIndex == -1) this.Limpa();
                }                
            }

            base.OnSelectedIndexChanged(e);
        }

        /// <summary>
        /// Funciona apenas se a propriedade Limpar = True.        
        /// </summary>
        public void LimparCmbGrupoProcedimento()
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

