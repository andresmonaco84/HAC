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
    public partial class HacCmbBanco : HacComboBox
    {
        
        private ICadastroBanco _cadastroBanco;
        protected ICadastroBanco CadastroBanco
        {
            get { return _cadastroBanco != null ? _cadastroBanco : _cadastroBanco = (ICadastroBanco)CommonServices.GetObject(typeof(ICadastroBanco)); }
        }

        public HacCmbBanco()
        {
            InitializeComponent();
        }

        public HacCmbBanco(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        [Category("Hac")]
        public void CarregarComboBanco(CadastroBancoDTO dtoCadastroBanco,bool codigoNome)
        {
            this.DataSource = null;
            DataTable dtbCadastroBanco = new DataTable();
            dtbCadastroBanco = CadastroBanco.Listar(dtoCadastroBanco);
            DataView dv = dtbCadastroBanco.DefaultView;
            dv.Sort = string.Format("{0} ASC", CadastroBancoDTO.FieldNames.Nome);
            dtbCadastroBanco = dv.ToTable();
            if (codigoNome)
                CarregarComboComSelecione(this, dtbCadastroBanco, CadastroBancoDTO.FieldNames.Idt, CadastroBancoDTO.FieldNames.Codigo, CadastroBancoDTO.FieldNames.Nome);
            else
                CarregarComboComSelecione(this, dtbCadastroBanco, CadastroBancoDTO.FieldNames.Idt, CadastroBancoDTO.FieldNames.Nome);
        }

        [Category("Hac")]
        public void CarregarComboBanco(bool codigoNome)
        {
            this.DataSource = null;
            DataTable dtbCadastroBanco = new DataTable();
            CadastroBancoDTO dtoCadastroBanco = new CadastroBancoDTO();
            dtbCadastroBanco = CadastroBanco.Listar(dtoCadastroBanco);
            DataView dv = dtbCadastroBanco.DefaultView;
            dv.Sort = string.Format("{0} ASC", CadastroBancoDTO.FieldNames.Nome);
            dtbCadastroBanco = dv.ToTable();
            if (codigoNome)
                CarregarComboComSelecione(this, dtbCadastroBanco, CadastroBancoDTO.FieldNames.Idt, CadastroBancoDTO.FieldNames.Codigo,CadastroBancoDTO.FieldNames.Nome);
            else
                CarregarComboComSelecione(this, dtbCadastroBanco, CadastroBancoDTO.FieldNames.Idt, CadastroBancoDTO.FieldNames.Nome);
        }

       
        
    }
}

