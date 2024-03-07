using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data;
using HospitalAnaCosta.SGS.Cadastro.Interface;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Threading;

//using HospitalAnaCosta.SGS.Seguranca.DTO;

namespace Hac.Windows.Forms.Controls
{
    public partial class HacCmbLocal : HacComboBox
    {
        //public SegurancaDTO dtoSeguranca;

        private string _nomeComboUnidade;
        [Category("Hac")]
        [Description("Nome do objeto combo referente ao Unidade. Se este campo não está preenchido, ele pega todo objeto HacCmbUnidade")]
        public string NomeComboUnidade
        {
            get { return _nomeComboUnidade; }
            set { _nomeComboUnidade = value; }
        }

        private string _nomeComboSetor;
        [Category("Hac")]
        [Description("Nome do objeto combo referente ao Setor. Se este campo não está preenchido, ele pega todo objeto HacCmbSetor")]
        public string NomeComboSetor
        {
            get { return _nomeComboSetor; }
            set { _nomeComboSetor = value; }
        }

        private bool _utilizaTabelaAssociacaoUnidadeLocal = false;
        [Category("Hac")]
        [Description("True - Para Carregar o Local, utiliza a tabela 'TB_ASS_ULO_UNID_LOCAL'.")]
        [DisplayName("Utiliza Tabela de Associação de Unidade com Local")]
        [DefaultValue(true)]
        public bool UtilizaTabelaAssociacaoUnidadeLocal
        {
            get { return _utilizaTabelaAssociacaoUnidadeLocal; }
            set { _utilizaTabelaAssociacaoUnidadeLocal = value; }
        }

        SetorDTO dtoSetor = new SetorDTO();

        int Inicio;
        
        private ILocalAtendimento _local;
        protected ILocalAtendimento Local
        {
            get
            {
                return _local != null ? _local : _local = (ILocalAtendimento)CommonServices.GetObject(typeof(ILocalAtendimento));
            }
        }

        private IAssociacaoUnidadeLocal _associacaoUnidadeLocal;
        protected IAssociacaoUnidadeLocal AssociacaoUnidadeLocal
        {
            get
            {
                return _associacaoUnidadeLocal != null ? _associacaoUnidadeLocal : _associacaoUnidadeLocal = (IAssociacaoUnidadeLocal)CommonServices.GetObject(typeof(IAssociacaoUnidadeLocal));
            }
        }

        public HacCmbLocal()
        {
            InitializeComponent();

            //this.AlterarStatus = false;
        }

        public HacCmbLocal(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            //this.AlterarStatus = false;
        }

        /// <summary>
        /// Carrega todos os locais de atendimento.
        /// </summary>
        public void Inicializar()
        {
            this.Carregar(new LocalAtendimentoDTO());
            this.IniciaLista();
        }

        /// <summary>
        /// Carrega todos os locais de uma unidade.
        /// </summary>
        /// <param name="dtoLocal"></param>
        public void CarregaLocal(LocalAtendimentoDTO dtoLocal)
        {
            Inicio = 1;
            this.Limpa();            
            dtoSetor.IdtUnidade.Value = dtoLocal.IdtUnidade.Value;
            if (dtoLocal.IdtUnidade.Value == -1) dtoLocal.IdtUnidade.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();
            if (dtoLocal.IdtUnidade.Value.IsNull)
            {
                CarregarComboComSelecione(this, new DataView(Local.Sel(dtoLocal), string.Empty, LocalAtendimentoDTO.FieldNames.DsLocalAtendimento, DataViewRowState.OriginalRows).ToTable(),
                                          LocalAtendimentoDTO.FieldNames.Idt, LocalAtendimentoDTO.FieldNames.DsLocalAtendimento);
            }
            else
            {
                CarregarComboComSelecione(this, Local.SelPorUnidade(dtoLocal), LocalAtendimentoDTO.FieldNames.Idt, LocalAtendimentoDTO.FieldNames.DsLocalAtendimento);
            } 

            this.IniciaLista();
            Inicio = 0;
            Form frm = this.FindForm();
            object obj = FindSetor(frm.Controls);
            if (obj != null)
            {
                ((HacCmbSetor)obj).Limpa();
            }
        }
        public void CarregaLocal(Int32 idtUnidade, Int32? idtLocalAtendimento)
        {
            LocalAtendimentoDTO dtoLocal = new LocalAtendimentoDTO();
            dtoLocal.IdtUnidade.Value = idtUnidade;
            if(idtLocalAtendimento!= null)
                dtoLocal.Idt.Value = idtLocalAtendimento;
            CarregaLocal(dtoLocal);
        }
        /// <summary>
        /// Carrega todos os locais.
        /// </summary>
        /// <param name="dtoLocal"></param>
        private void Carregar(LocalAtendimentoDTO dtoLocal)
        {          

            DataTable dtb;

            dtb = this.Local.Sel(dtoLocal);

            DataView dv = dtb.DefaultView;

            dv.Sort = LocalAtendimentoDTO.FieldNames.DsLocalAtendimento;

            dtb = dv.ToTable();

            //this.DisplayMember = LocalAtendimentoDTO.FieldNames.DsLocalAtendimento;
            //this.ValueMember = LocalAtendimentoDTO.FieldNames.Idt;
            //this.DataSource = dtb;            

            CarregarComboComSelecione(this, dtb, LocalAtendimentoDTO.FieldNames.Idt, LocalAtendimentoDTO.FieldNames.DsLocalAtendimento);

            IniciaLista();
        }

        private HacCmbUnidade FindUnidade(Control.ControlCollection controls)
        {
            Control control = null;
            foreach (Control ctr in controls)
            {
                if ((ctr is HacCmbUnidade && string.IsNullOrEmpty(this.NomeComboUnidade)) ||
                    (ctr is HacCmbUnidade && ctr.Name == this.NomeComboUnidade))
                {
                    control = ctr;
                    break;
                }
                else
                {
                    control = FindUnidade(ctr.Controls);
                    if (control != null) break;
                }
            }
            return control == null ? null : (HacCmbUnidade)control;
        }

        private HacCmbSetor FindSetor(Control.ControlCollection controls)
        {
            Control control = null;
            foreach (Control ctr in controls)
            {
                if ((ctr is HacCmbSetor && string.IsNullOrEmpty(this.NomeComboSetor)) ||
                    (ctr is HacCmbSetor && ctr.Name == this.NomeComboSetor))
                {
                    control = ctr;
                    break;
                }
                else
                {
                    control = FindSetor(ctr.Controls);
                    if (control != null) break;
                }
            }
            return control == null ? null : (HacCmbSetor)control;
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            //base.OnSelectedIndexChanged(e);
            Form frm = this.FindForm();
            object obj = FindSetor(frm.Controls);

            // ListItem item = (ListItem)this.SelectedItem;
            if (this.SelectedIndex != -1)
            {
                if (Inicio == 0)
                {
                    dtoSetor.IdtLocalAtendimento.Value = Convert.ToInt32(this.SelectedValue);
                    dtoSetor.FlAtivo.Value = "S";
                    
                    if (obj != null)
                    {
                        //if (((HacCmbSetor)obj).Internacao == true)
                        //{
                        //    dtoSetor.PermiteInternacao.Value = "S";
                        //}
                        ((HacCmbSetor)obj).CarregaSetor(dtoSetor);
                    }
                }
            }
            else
            {
                if (obj != null)
                {
                    ((HacCmbSetor)obj).Limpa();
                }

                obj = FindUnidade(frm.Controls);

                if (obj != null)
                {
                    if (((HacCmbUnidade)obj).SelectedIndex == -1) this.Limpa();
                }                
            }
            base.OnSelectedIndexChanged(e);
        }

        /// <summary>
        /// Funciona apenas se a propriedade Limpar = True.
        /// Limpa também o combo de Setor.
        /// </summary>
        public void LimparCmbLocal()
        {
            if (this.Limpar)
            {
                HacCmbSetor cmbSetor = this.FindSetor(this.FindForm().Controls);                

                if (cmbSetor != null) cmbSetor.Limpa();
                this.IniciaLista();
            }
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