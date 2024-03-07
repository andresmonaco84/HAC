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
    public partial class HacCmbMunicipio : HacComboBox
    {
        private string _nomeComboUF;
        [Category("Hac")]
        [Description("Nome do objeto combo referente ao UF. Se este campo não está preenchido, ele pega todo objeto HacCmbUF")]
        public string NomeComboUF
        {
            get { return _nomeComboUF; }
            set { _nomeComboUF = value; }
        }

        //private string _nomeComboTipoLogradouro;
        //[Category("Hac")]
        //[Description("Nome do objeto combo referente ao TipoLogradouro. Se este campo não está preenchido, ele pega todo objeto HacCmbTipoLogradouro")]
        //public string NomeComboTipoLogradouro
        //{
        //    get { return _nomeComboTipoLogradouro; }
        //    set { _nomeComboTipoLogradouro = value; }
        //}

        //private Decimal _codigoUF = string.Empty;
        //[Category("Hac")]
        //[Description("Codigo do Estado Obrigatório.")]
        //public string CodigoUF
        //{
        //    get { return _codigoUF; }
        //    set { _codigoUF = value; }
        //}

        int Inicio;

       // TipoLogradouroDTO dtoTipoLogradouro = new TipoLogradouroDTO();

        MunicipioDTO MunicipioDTO = new MunicipioDTO();
        private IMunicipio _Municipio;
        protected IMunicipio Municipio
        {
            get { return _Municipio != null ? _Municipio : _Municipio = (IMunicipio)CommonServices.GetObject(typeof(IMunicipio)); }
        }


        public HacCmbMunicipio()
        {
            InitializeComponent();
        }

        public HacCmbMunicipio(IContainer container)
        {
            container.Add(this);

            InitializeComponent();            
        }

        [Category("Hac")]
        public void CarregarComboMunicipio(string codigoUF)
        {
            this.DataSource = null;
            DataTable dtbMunicipio = new DataTable();
            MunicipioDTO.SiglaUF.Value = codigoUF;
            dtbMunicipio = Municipio.Listar(MunicipioDTO);
            DataView dv = dtbMunicipio.DefaultView;
            dv.Sort = MunicipioDTO.FieldNames.NomeMunicipio;
            dtbMunicipio = dv.ToTable();
            CarregarComboComSelecione(this, dtbMunicipio, MunicipioDTO.FieldNames.CodigoIBGE, MunicipioDTO.FieldNames.NomeMunicipio);            
        }

        private HacCmbUF FindUF(Control.ControlCollection controls)
        {
            Control control = null;
            foreach (Control ctr in controls)
            {
                if ((ctr is HacCmbUF && string.IsNullOrEmpty(this.NomeComboUF)) ||
                    (ctr is HacCmbUF && ctr.Name == this.NomeComboUF))
                {
                    control = ctr;
                    break;
                }
                else
                {
                    control = FindUF(ctr.Controls);
                    if (control != null) break;
                }
            }
            return control == null ? null : (HacCmbUF)control;
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
            //base.OnSelectedIndexChanged(e);
            Form frm = this.FindForm();
            object obj = new object();
           // obj = FindTipoLogradouro(frm.Controls);
            if (this.SelectedIndex != -1)
            {
                //if (Inicio == 0)
                //{
                //    dtoTipoLogradouro.Codigo.Value = Convert.ToInt32(this.SelectedValue);
                //    dtoTipoLogradouro.FlAtivo.Value = "S";

                    //if (obj != null)
                    //{
                        
                    //    ((HacCmbTipoLogradouro)obj).CarregarComboTipoLogradouro();
                    //}
               // }
            }
            else
            {
                //if (obj != null)
                //{
                //    ((HacCmbTipoLogradouro)obj).Limpa();
                //}

                obj = FindUF(frm.Controls);

                if (obj != null)
                {
                    if (((HacCmbUF)obj).SelectedIndex == -1) this.Limpa();
                }
            }
            base.OnSelectedIndexChanged(e);
        }

        /// <summary>
        /// Funciona apenas se a propriedade Limpar = True.
        /// Limpa também o combo de TipoLogradouro.
        /// </summary>
        public void LimparCmbF()
        {
            if (this.Limpar)
            {
                //HacCmbTipoLogradouro cmbTipoLogradouro = this.FindTipoLogradouro(this.FindForm().Controls);

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
