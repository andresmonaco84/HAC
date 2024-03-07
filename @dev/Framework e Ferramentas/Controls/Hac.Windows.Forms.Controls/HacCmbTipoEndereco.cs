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
    public partial class HacCmbTipoEndereco : HacComboBox
    {
        TipoTelefoneEnderecoDTO TipoEnderecoDTO = new TipoTelefoneEnderecoDTO();
        private ITipoTelefoneEndereco _TipoEndereco;
        protected ITipoTelefoneEndereco TipoEndereco
        {
            get { return _TipoEndereco != null ? _TipoEndereco : _TipoEndereco = (ITipoTelefoneEndereco)CommonServices.GetObject(typeof(ITipoTelefoneEndereco)); }
        }


        public HacCmbTipoEndereco()
        {
            InitializeComponent();
        }

        public HacCmbTipoEndereco(IContainer container)
        {
            container.Add(this);
            InitializeComponent();            
        }

        [Category("Hac")]
        public void CarregarComboTipoEndereco()
        {
            this.DataSource = null;
            DataTable dtbTipoEndereco = new DataTable();
            dtbTipoEndereco = TipoEndereco.Listar(TipoEnderecoDTO);
            DataView dv = dtbTipoEndereco.DefaultView;
            dv.RowFilter = "AUX_TTE_CD_TIPO IN ('A','E')";
            dv.Sort = TipoEnderecoDTO.Nome.FieldName;
            dtbTipoEndereco = dv.ToTable();
            CarregarComboComSelecione(this, dtbTipoEndereco, TipoEnderecoDTO.TipoTelefoneEndereco.FieldName, TipoEnderecoDTO.Nome.FieldName);

        }

        [Category("Hac")]
        public void CarregarComboTipoEnderecoCorrespondecia()
        {
            this.DataSource = null;
            DataTable dtbTipoEndereco = new DataTable();
            dtbTipoEndereco = TipoEndereco.Listar(TipoEnderecoDTO);
            DataView dv = dtbTipoEndereco.DefaultView;
            dv.RowFilter = "AUX_TTE_CD_TIPO IN ('A','E') AND AUX_TTE_CD_TP_TEL_END NOT IN (12)";
            dv.Sort = TipoEnderecoDTO.Nome.FieldName;
            dtbTipoEndereco = dv.ToTable();
            CarregarComboComSelecione(this, dtbTipoEndereco, TipoEnderecoDTO.TipoTelefoneEndereco.FieldName, TipoEnderecoDTO.Nome.FieldName);            
        }
    }
}
