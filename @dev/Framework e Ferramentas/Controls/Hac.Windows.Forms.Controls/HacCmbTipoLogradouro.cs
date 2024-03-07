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
    public partial class HacCmbTipoLogradouro : HacComboBox
    {
        TipoLogradouroDTO TipoLogradouroDTO = new TipoLogradouroDTO();
        private ITipoLogradouro _TipoLogradouro;
        protected ITipoLogradouro TipoLogradouro
        {
            get { return _TipoLogradouro != null ? _TipoLogradouro : _TipoLogradouro = (ITipoLogradouro)CommonServices.GetObject(typeof(ITipoLogradouro)); }
        }


        public HacCmbTipoLogradouro()
        {
            InitializeComponent();
        }

        public HacCmbTipoLogradouro(IContainer container)
        {
            container.Add(this);

            InitializeComponent();            
        }

        [Category("Hac")]
        public void CarregarComboTipoLogradouro()
        {
            this.DataSource = null;
            DataTable dtbTipoLogradouro = new DataTable();
            dtbTipoLogradouro = TipoLogradouro.Listar(TipoLogradouroDTO);
            DataView dv = dtbTipoLogradouro.DefaultView;
            dv.Sort = TipoLogradouroDTO.FieldNames.Descricao;
            dtbTipoLogradouro = dv.ToTable();
            CarregarComboComSelecione(this, dtbTipoLogradouro, TipoLogradouroDTO.FieldNames.Codigo, TipoLogradouroDTO.FieldNames.Descricao);            
        }

        /// <summary>
        /// Funciona apenas se a propriedade Limpar = True.        
        /// </summary>
        public void LimparCmbTipoLogradouro()
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
