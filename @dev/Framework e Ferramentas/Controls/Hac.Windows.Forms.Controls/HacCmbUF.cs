using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

using HospitalAnaCosta.SGS.Cadastro.Interface;
using System.Data;
using HospitalAnaCosta.SGS.Cadastro.DTO;

namespace Hac.Windows.Forms.Controls
{
    public partial class HacCmbUF : HacComboBox
    {
        private string _nomeComboMunicipio;
        [Category("Hac")]
        [Description("Nome do objeto combo referente ao Municipio. Se este campo não está preenchido, ele pega todo objeto HacCmbMunicipio")]
        public string NomeComboMunicipio
        {
            get { return _nomeComboMunicipio; }
            set { _nomeComboMunicipio = value; }
        }

        //private string _nomeComboTipoLogradouro;
        //[Category("Hac")]
        //[Description("Nome do objeto combo referente ao TipoLogradouro. Se este campo não está preenchido, ele pega todo objeto HacCmbTipoLogradouro")]
        //public string NomeComboTipoLogradouro
        //{
        //    get { return _nomeComboTipoLogradouro; }
        //    set { _nomeComboTipoLogradouro = value; }
        //}

        UFDTO UFDTO = new UFDTO();
        private IUF _UF;
        protected IUF UF
        {
            get { return _UF != null ? _UF : _UF = (IUF)CommonServices.GetObject(typeof(IUF)); }
        }
        byte Inicio;

        public HacCmbUF()
        {
            InitializeComponent();
        }

        public HacCmbUF(IContainer container)
        {
            container.Add(this);

            InitializeComponent();            
        }

        [Category("Hac")]
        public void CarregarComboUF()
        {
            Inicio = 1;
            this.DataSource = null;
            DataTable dtbUF = new DataTable();
            dtbUF = UF.Listar(UFDTO);
            DataView dv = dtbUF.DefaultView;
            dv.Sort = UFDTO.FieldNames.Descricao;
            dtbUF = dv.ToTable();
            CarregarComboComSelecione(this, dtbUF, UFDTO.FieldNames.Codigo, UFDTO.FieldNames.Descricao);            
        }

        private HacCmbMunicipio FindMunicipio(ControlCollection controls)
        {
            Control control = null;
            foreach (Control ctr in controls)
            {
                if ((ctr is HacCmbMunicipio && string.IsNullOrEmpty(this.NomeComboMunicipio)) ||
                    (ctr is HacCmbMunicipio && ctr.Name == this.NomeComboMunicipio))
                {
                    control = ctr;
                    break;
                }
                else
                {
                    control = FindMunicipio(ctr.Controls);
                    if (control != null) break;
                }
            }
            return control == null ? null : (HacCmbMunicipio)control;
        }

        //private HacCmbTipoLogradouro FindTipoLogradouro(Control.ControlCollection controls)
        //{
        //    Control control = null;
        //    foreach (Control ctr in controls)
        //    {
        //        if ((ctr is HacCmbTipoLogradouro && string.IsNullOrEmpty(this.NomeComboTipoLogradouro)) ||
        //            (ctr is HacCmbTipoLogradouro && ctr.Name == this.NomeComboTipoLogradouro))
        //        {
        //            control = ctr;
        //            break;
        //        }
        //        else
        //        {
        //            control = FindTipoLogradouro(ctr.Controls);
        //            if (control != null) break;
        //        }
        //    }
        //    return control == null ? null : (HacCmbTipoLogradouro)control;
        //}

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
           
                Form frm = this.FindForm();
                MunicipioDTO dtoMunicipio = new MunicipioDTO();
                object obj = FindMunicipio(frm.Controls);
                //ListItem item = (ListItem)this.SelectedItem;     
                if (this.SelectedIndex != -1)
                {
                    //if (Inicio == 0)
                    //{
                        dtoMunicipio.SiglaUF.Value = this.SelectedValue.ToString();
                        
                        if (obj != null)
                        {
                            ((HacCmbMunicipio)obj).CarregarComboMunicipio(dtoMunicipio.SiglaUF.Value);
                        }
                    //}
                }
                else
                {
                    if (obj != null) ((HacCmbMunicipio)obj).Limpa();
                }
           
            base.OnSelectedIndexChanged(e);
        }

        /// <summary>
        /// Funciona apenas se a propriedade Limpar = True.
        /// Limpa também o combo de Municipio e TipoLogradouro.
        /// </summary>
        public void LimparCmbUF()
        {
            if (this.Limpar)
            {
                HacCmbMunicipio cmbMunicipio = this.FindMunicipio(this.FindForm().Controls);
               // HacCmbTipoLogradouro cmbTipoLogradouro = this.FindTipoLogradouro(this.FindForm().Controls);

                if (cmbMunicipio != null) cmbMunicipio.Limpa();
               // if (cmbTipoLogradouro != null) cmbTipoLogradouro.Limpa();
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
