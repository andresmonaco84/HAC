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
    public partial class HacCmbEspecialidade : HacComboBox
    {
        EspecialidadeDTO especialidadeDTO = new EspecialidadeDTO();
        private IEspecialidade _especialidade;
        protected IEspecialidade Especialidade
        {
            get { return _especialidade != null ? _especialidade : _especialidade = (IEspecialidade)CommonServices.GetObject(typeof(IEspecialidade)); }
        }

        public HacCmbEspecialidade()
        {
            InitializeComponent();
        }

        public HacCmbEspecialidade(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        [Category("Hac")]
        public void CarregarComboEspecialidade()
        {
            this.DataSource = null;
            DataTable dtbEspecialidade = new DataTable();            
            dtbEspecialidade = Especialidade.Listar(especialidadeDTO);
            DataView dv = dtbEspecialidade.DefaultView;
            dv.Sort = "TIS_CBO_DS_CBOS_HAC ASC";
            dtbEspecialidade = dv.ToTable();
            CarregarComboComSelecione(this, dtbEspecialidade, "TIS_CBO_CD_CBOS", "TIS_CBO_DS_CBOS_HAC");
        }
        [Category("Hac")] //Nesse metodo o status da Espec. e Prof. estão na proc. (Ativos)
        public void CarregarComboEspecialidadePorProfissional(int idtProfissional)
        {
            this.DataSource = null;
            DataTable dtbEspecialidade = new DataTable();
            dtbEspecialidade = Especialidade.ListarEspecialidadesPorProfissionalTodas(idtProfissional);
            DataView dv = dtbEspecialidade.DefaultView;
            dv.Sort = "TIS_CBO_DS_CBOS_HAC ASC";
            CarregarComboComSelecione(this, dtbEspecialidade, "TIS_CBO_CD_CBOS", "TIS_CBO_DS_CBOS_HAC");
        }

        [Category("Hac")] //Nesse metodo o status da Espec. e Prof. estão na proc. (Ativos)
        public void CarregarComboEspecialidadesAssociadas(int idtProfissional, int idtUnidade)
        {
            this.DataSource = null;
            DataTable dtbEspecialidade = new DataTable();
            dtbEspecialidade = Especialidade.ListarEspecialidadesPorProfissional(idtProfissional);
            DataView dv = dtbEspecialidade.DefaultView;
            dv.Sort = "TIS_CBO_DS_CBOS_HAC ASC";
            CarregarComboComSelecione(this, dtbEspecialidade, "TIS_CBO_CD_CBOS", "TIS_CBO_DS_CBOS_HAC");
        }

        [Category("Hac")] //Nesse metodo o status da Espec. e Prof. estão na proc. (Ativos)
        public void CarregarComboEspecialidadesAssociadas(int idtProfissional, int? idtUnidade,bool apenasAtivas)
        {
            this.DataSource = null;
            DataTable dtbEspecialidade = new DataTable();
            dtbEspecialidade = Especialidade.ListarEspecialidadesPorProfissional(idtProfissional,idtUnidade, apenasAtivas);
            DataView dv = dtbEspecialidade.DefaultView;
            dv.Sort = "TIS_CBO_DS_CBOS_HAC ASC";
            CarregarComboComSelecione(this, dtbEspecialidade, "TIS_CBO_CD_CBOS", "TIS_CBO_DS_CBOS_HAC");
        }
    }
}

