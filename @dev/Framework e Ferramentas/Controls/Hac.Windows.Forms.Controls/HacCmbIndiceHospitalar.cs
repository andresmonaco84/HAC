using System.ComponentModel;
using System.Data;
using HospitalAnaCosta.Services.Produto.DTO;
using HospitalAnaCosta.Services.Produto.Interface;

namespace Hac.Windows.Forms.Controls
{     
    public partial class HacCmbIndiceHospitalar : HacComboBox
    {
        IndiceHospitalarDTO dtoIndiceHospitalar = new IndiceHospitalarDTO();

        private IIndiceHospitalar _indiceHospitalar;
        protected IIndiceHospitalar IndiceHospitalar
        {
            get { return _indiceHospitalar != null ? _indiceHospitalar : _indiceHospitalar = (IIndiceHospitalar)CommonServices.GetObject(typeof(IIndiceHospitalar)); }
        }

        public HacCmbIndiceHospitalar()
        {
            InitializeComponent();
        }

        public HacCmbIndiceHospitalar(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        [Category("Hac")]
        public void CarregarComboIndiceHospitalar()
        {
            this.DataSource = null;
            DataTable dtbIndiceHospitalar = new DataTable();
            //dtoIndiceHospitalar.Status.Value = "A";
            dtbIndiceHospitalar = IndiceHospitalar.Listar(dtoIndiceHospitalar);
            DataView dv = dtbIndiceHospitalar.DefaultView;
            dv.Sort = "CAD_TIH_DS_INDICE_HOSP ASC";
            dtbIndiceHospitalar = dv.ToTable();
            CarregarComboComSelecione(this, dtbIndiceHospitalar, "CAD_TIH_TP_INDICE_HOSP", "CAD_TIH_DS_INDICE_HOSP");
        }
    }
}

