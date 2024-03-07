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
    public partial class HacCmbCodigoDespesa : HacComboBox
    {

        CodigoDespesaTISSDTO dtoCodigoDespesaTISS = new CodigoDespesaTISSDTO();
        private ICodigoDespesaTISS _codigoDespesaTISS;
        protected ICodigoDespesaTISS CodigoDespesaTISS
        {
            get { return _codigoDespesaTISS != null ? _codigoDespesaTISS : _codigoDespesaTISS = (ICodigoDespesaTISS)CommonServices.GetObject(typeof(ICodigoDespesaTISS)); }
        }

        public HacCmbCodigoDespesa()
        {
            InitializeComponent();
        }

        public HacCmbCodigoDespesa(IContainer container)
        {
            container.Add(this);

            InitializeComponent();            
        }

        [Category("Hac")]
        [Description("Carrega o CodigoDespesaTISS.")]
        public void CarregarComboCodigoDespesaTISS(CodigoDespesaTISSDTO dto)
        {
            this.DataSource = null;
            DataTable dtb = new DataTable();
            dtb = CodigoDespesaTISS.Listar(dto);
            DataView dv = dtb.DefaultView;
            dv.Sort = string.Format("{0} ASC",CodigoDespesaTISSDTO.FieldNames.DescricaoDespesa);

            dtb = dv.ToTable();
            this.DataSource = dtb;
            this.DisplayMember = CodigoDespesaTISSDTO.FieldNames.DescricaoDespesa;
            this.ValueMember = CodigoDespesaTISSDTO.FieldNames.CodigoDespesa;
            this.SelectedIndex = -1;

            this.IniciaLista();
        }
        [Category("Hac")]
        [Description("Carrega o CodigoDespesaTISS com DT. INÍCIO <= a dt. atual e c/ DT. FIM nula ou >= a data atual. ATIVOS")]
        public void CarregarComboCodigoDespesaTISS_VIGENTES()
        {
            CodigoDespesaTISSDTO dto = new CodigoDespesaTISSDTO();
            this.DataSource = null;
            DataTable dtb = new DataTable();
            dtb = CodigoDespesaTISS.ListarVigentes(dto);
            DataView dv = dtb.DefaultView;
            dv.Sort = string.Format("{0} ASC", CodigoDespesaTISSDTO.FieldNames.DescricaoDespesa);

            dtb = dv.ToTable();
            this.DataSource = dtb;
            this.DisplayMember = CodigoDespesaTISSDTO.FieldNames.DescricaoDespesa;
            this.ValueMember = CodigoDespesaTISSDTO.FieldNames.CodigoDespesa;
            this.SelectedIndex = -1;

            this.IniciaLista();
        }
    }
}
