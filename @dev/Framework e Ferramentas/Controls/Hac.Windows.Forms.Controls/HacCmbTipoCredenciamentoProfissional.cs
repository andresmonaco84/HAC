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
    public partial class HacCmbTipoCredenciamentoProfissional : HacComboBox
    {
        //private bool _permiteDifClasse = false;
        //[Category("Hac")]
        //public bool PermiteDiferencaClasse
        //{
        //    get { return _permiteDifClasse; }
        //    set { _permiteDifClasse = value; }
        //}

        TipoCredenciaProfissionalDTO tipoCredenciaProfissionalDTO = new TipoCredenciaProfissionalDTO();
        private ITipoCredenciaProfissional _tipoCredenciaProfissional;
        protected ITipoCredenciaProfissional TipoCredenciaProfissional
        {
            get { return _tipoCredenciaProfissional != null ? _tipoCredenciaProfissional : _tipoCredenciaProfissional = (ITipoCredenciaProfissional)CommonServices.GetObject(typeof(ITipoCredenciaProfissional)); }
        }

       

        public HacCmbTipoCredenciamentoProfissional()
        {
            InitializeComponent();
        }

        public HacCmbTipoCredenciamentoProfissional(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        [Category("Hac")]
        public void CarregarComboTipoCredenciaProfissional()
        {
            this.DataSource = null;
            DataTable dtbTipoCredenciaProfissional = new DataTable();
            //if (PermiteDiferencaClasse) tipoCredenciaProfissionalDTO.FlagPermiteDiferencaClasse.Value = "S";
            dtbTipoCredenciaProfissional = TipoCredenciaProfissional.Listar(tipoCredenciaProfissionalDTO);
            DataView dv = dtbTipoCredenciaProfissional.DefaultView;
            dv.Sort = string.Format("{0} ASC", TipoCredenciaProfissionalDTO.FieldNames.DescricaoTipoCredenciaProfissional);

            dtbTipoCredenciaProfissional = dv.ToTable();

            CarregarComboComSelecione(this, dtbTipoCredenciaProfissional, TipoCredenciaProfissionalDTO.FieldNames.CodigoTipoCredenciaProfissional, TipoCredenciaProfissionalDTO.FieldNames.DescricaoTipoCredenciaProfissional);
        }

        //[Category("Hac")]
        //public void CarregarComboTipoCredenciaProfissional(TipoCredenciaProfissionalDTO dtoTipoCredenciaProfissional)
        //{

        //    dtbTipoCredenciaProfissional.AcceptChanges();

        //    DataView dv = dtbTipoCredenciaProfissional.DefaultView;
        //    dv.Sort = " ASC";

        //    dtbTipoCredenciaProfissional = dv.ToTable();

        //    CarregarComboComSelecione(this, dtbTipoCredenciaProfissional, TipoCredenciaProfissionalDTO.FieldNames.CodigoTipoCredenciaProfissional, TipoCredenciaProfissionalDTO.FieldNames.DescricaoTipoCredenciaProfissional);

        //}
    }
}