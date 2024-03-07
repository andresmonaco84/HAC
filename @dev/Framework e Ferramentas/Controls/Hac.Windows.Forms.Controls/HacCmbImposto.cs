using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using HospitalAnaCosta.SGS.Cadastro.Interface;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using System.Data;

namespace Hac.Windows.Forms.Controls
{     
    public partial class HacCmbImposto : HacComboBox
    {

        ImpostoDTO especialidadeDTO = new ImpostoDTO();
        private IImposto _imposto;
        protected IImposto Imposto
        {
            get { return _imposto != null ? _imposto : _imposto = (IImposto)CommonServices.GetObject(typeof(IImposto)); }
        }

        public HacCmbImposto()
        {
            InitializeComponent();
        }

        public HacCmbImposto(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        [Category("Hac")]
        public void CarregarComboImposto(ImpostoDTO dtoImposto)
        {
            this.DataSource = null;
            DataTable dtbImposto = new DataTable();
            dtbImposto = Imposto.Listar(dtoImposto);
            DataView dv = dtbImposto.DefaultView;
            dv.Sort = string.Format("{0} ASC",ImpostoDTO.FieldNames.NomeImposto);
            dtbImposto = dv.ToTable();
            CarregarComboComSelecione(this, dtbImposto, ImpostoDTO.FieldNames.IdtImposto, ImpostoDTO.FieldNames.NomeImposto);
        }
        
    }
}

