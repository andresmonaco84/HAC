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
    public partial class HacCmbTipoTelefone : HacComboBox
    {
        TipoTelefoneEnderecoDTO TipoTelefoneDTO = new TipoTelefoneEnderecoDTO();
        private ITipoTelefoneEndereco _TipoTelefone;
        protected ITipoTelefoneEndereco TipoTelefone
        {
            get { return _TipoTelefone != null ? _TipoTelefone : _TipoTelefone = (ITipoTelefoneEndereco)CommonServices.GetObject(typeof(ITipoTelefoneEndereco)); }
        }


        public HacCmbTipoTelefone()
        {
            InitializeComponent();
        }

        public HacCmbTipoTelefone(IContainer container)
        {
            container.Add(this);
            InitializeComponent();            
        }

        [Category("Hac")]
        public void CarregarComboTipoTelefone()
        {
            this.DataSource = null;
            DataTable dtbTipoTelefone = new DataTable();
            dtbTipoTelefone = TipoTelefone.Listar(TipoTelefoneDTO);
            DataView dv = dtbTipoTelefone.DefaultView;
            dv.RowFilter = "AUX_TTE_CD_TIPO IN ('A','T')";
            dv.Sort = TipoTelefoneDTO.Nome.FieldName;
            dtbTipoTelefone = dv.ToTable();
            CarregarComboComSelecione(this, dtbTipoTelefone, TipoTelefoneDTO.TipoTelefoneEndereco.FieldName, TipoTelefoneDTO.Nome.FieldName);
        }

        [Category("Hac")]
        public void CarregarComboTipoTelefoneCorrespondecia()
        {
            this.DataSource = null;
            DataTable dtbTipoTelefone = new DataTable();
            dtbTipoTelefone = TipoTelefone.Listar(TipoTelefoneDTO);
            DataView dv = dtbTipoTelefone.DefaultView;
            dv.RowFilter = "AUX_TTE_CD_TIPO IN ('A','T') AND AUX_TTE_CD_TP_TEL_END NOT IN (9,10,11,14)";
            dv.Sort = TipoTelefoneDTO.Nome.FieldName;
            dtbTipoTelefone = dv.ToTable();
            CarregarComboComSelecione(this, dtbTipoTelefone, TipoTelefoneDTO.TipoTelefoneEndereco.FieldName, TipoTelefoneDTO.Nome.FieldName);            
        }
    }
}
