using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using HospitalAnaCosta.Framework.Events;
using HospitalAnaCosta.Services.Produto.DTO;
using HospitalAnaCosta.Services.Produto.Interface;

namespace Hac.Windows.Forms.Controls
{     
    public partial class HacCmbEspecialidadeProcedimentoCirurgico : HacComboBox
    {
        private string _nomeComboGrupoProcedimento;
        [Category("Hac")]
        [Description("Nome do objeto combo referente ao Grupo Procedimento. Se este campo não está preenchido, ele pega todo objeto HacCmbGrupoProcedimento")]
        public string NomeComboGrupoProcedimento
        {
            get { return _nomeComboGrupoProcedimento; }
            set { _nomeComboGrupoProcedimento = value; }
        }

        byte Inicio;

        EspecialidadeProcedimentoDTO especialidadeProcedimentoDTO = new EspecialidadeProcedimentoDTO();
        private IEspecialidadeProcedimento _especialidadeProcedimento;
        protected IEspecialidadeProcedimento EspecialidadeProcedimento
        {
            get { return _especialidadeProcedimento != null ? _especialidadeProcedimento : _especialidadeProcedimento = (IEspecialidadeProcedimento)CommonServices.GetObject(typeof(IEspecialidadeProcedimento)); }
        }

        private bool _somenteEspecialidadeProcedimento = false;
        [Category("Hac")]
        [Description("True - Não carrega combo grupo procedimento. False - Carrega combo grupo procedimento.")]
        public bool SomenteEspecialidadeProcedimento
        {
            get { return _somenteEspecialidadeProcedimento; }
            set { _somenteEspecialidadeProcedimento = value; }
        }

        public HacCmbEspecialidadeProcedimentoCirurgico()
        {
            InitializeComponent();
        }

        protected override void OnSelectionChangeCommitted(System.EventArgs e)
        {
            HacComboEventArgs eCombo = new HacComboEventArgs();
            eCombo.Value = this.SelectedValue.ToString();
            OnSelecionar(eCombo);
        }

        public delegate void SelecionarDelegate(object sender, HacComboEventArgs e);

        [Category("Hac")]
        public event SelecionarDelegate Selecionar;

        [Category("Hac")]
        protected virtual void OnSelecionar(HacComboEventArgs e)
        {
            if (Selecionar != null)
            {
                Selecionar(this, e);
            }
        }


        private string codigoTabelaMedica;
        public string CodigoTabelaMedica
        {
            get { return codigoTabelaMedica; }
            set { codigoTabelaMedica = value; }
        }
        
        private string flagAgendaCirugia;
        public string FlagAgendaCirugia
        {
            get { return flagAgendaCirugia; }
            set { flagAgendaCirugia = value; }
        }




        public HacCmbEspecialidadeProcedimentoCirurgico(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void CarregaEspecialidadeProcedimento(bool adicionarIdtDescricao, DataTable dtbEspecialidadeProcedimento)
        {
            Inicio = 1;

            this.DataSource = null;
            if (dtbEspecialidadeProcedimento == null)
            {
                dtbEspecialidadeProcedimento = EspecialidadeProcedimento.ListarJoinProdutoCirurgia(especialidadeProcedimentoDTO, flagAgendaCirugia);
            }
                        
            DataView dv = dtbEspecialidadeProcedimento.DefaultView;
            dv.Sort = "AUX_EPP_DS_DESCRICAO ASC";

            if (codigoTabelaMedica != string.Empty && codigoTabelaMedica != null)
            {
                dv.RowFilter = "TIS_MED_CD_TABELAMEDICA = '" + codigoTabelaMedica + "'";                            
            }

            //if (CodigoTabelaMedica == "95" || CodigoTabelaMedica == "96")
            //{
            //    dv.RowFilter = "CAD_MTMD_GRUPO_ID IS NOT NULL";
            //}
            //else if (CodigoTabelaMedica != null)
            //{
            //    dv.RowFilter = "CAD_MTMD_GRUPO_ID IS NULL";
            //}

            dtbEspecialidadeProcedimento = dv.ToTable();

            if (adicionarIdtDescricao)
            {
                foreach (DataRow row in dtbEspecialidadeProcedimento.Rows)
                {
                    row[EspecialidadeProcedimentoDTO.FieldNames.Descricao] = string.Format("{0} - {1}", row[EspecialidadeProcedimentoDTO.FieldNames.Codigo],
                                                                                                        row[EspecialidadeProcedimentoDTO.FieldNames.Descricao]);
                }
            }   

            this.CarregarComboComSelecione(this, dtbEspecialidadeProcedimento, EspecialidadeProcedimentoDTO.FieldNames.Codigo, EspecialidadeProcedimentoDTO.FieldNames.Descricao);

            if (!_somenteEspecialidadeProcedimento)
            {
                Inicio = 0;
                Form frm = this.FindForm();
                object obj = FindGrupoProcedimento(frm.Controls);
                if (obj != null)
                {
                    ((HacCmbGrupoProcedimento)obj).Limpa();
                }
            }
        }

        public void CarregaEspecialidadeProcedimento()
        {
            this.CarregaEspecialidadeProcedimento(false, null);
        }

         public void CarregaEspecialidadeMaterialMedicamento()
        {
            Inicio = 1;

            this.DataSource = null;
            DataTable dtbEspecialidadeProcedimento = new DataTable();
            dtbEspecialidadeProcedimento = EspecialidadeProcedimento.Listar(especialidadeProcedimentoDTO);
            DataView dv = dtbEspecialidadeProcedimento.DefaultView;
            dv.RowFilter = "CAD_MTMD_GRUPO_ID IS NOT NULL";
            dv.Sort = "AUX_EPP_DS_DESCRICAO ASC";

            dtbEspecialidadeProcedimento = dv.ToTable();

            this.CarregarComboComSelecione(this, dtbEspecialidadeProcedimento, EspecialidadeProcedimentoDTO.FieldNames.Codigo, EspecialidadeProcedimentoDTO.FieldNames.Descricao);

            if (!_somenteEspecialidadeProcedimento)
            {
                Inicio = 0;
                Form frm = this.FindForm();
                object obj = FindGrupoProcedimento(frm.Controls);
                if (obj != null)
                {
                    ((HacCmbGrupoProcedimento)obj).Limpa();
                }
            }
        }

        private HacCmbGrupoProcedimento FindGrupoProcedimento(ControlCollection controls)
        {
            Control control = null;
            foreach (Control ctr in controls)
            {
                if ((ctr is HacCmbGrupoProcedimento && string.IsNullOrEmpty(this.NomeComboGrupoProcedimento)) ||
                    (ctr is HacCmbGrupoProcedimento && ctr.Name == this.NomeComboGrupoProcedimento))
                {
                    control = ctr;
                    break;
                }
                else
                {
                    control = FindGrupoProcedimento(ctr.Controls);
                    if (control != null) break;
                }
            }
            return control == null ? null : (HacCmbGrupoProcedimento)control;              
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (!_somenteEspecialidadeProcedimento)
            {
                Form frm = this.FindForm();
                GrupoProcedimentoDTO dtoGrupoProcedimento = new GrupoProcedimentoDTO();
                HacCmbGrupoProcedimento obj = FindGrupoProcedimento(frm.Controls);

                if (this.SelectedIndex != -1)
                {
                    if (Inicio == 0)
                    {
                        dtoGrupoProcedimento.CodigoEspecialidade.Value = this.SelectedValue.ToString();

                        if (obj != null)
                        {
                            obj.CodigoTabelaMedica = CodigoTabelaMedica;
                            ((HacCmbGrupoProcedimento)obj).CarregaGrupoProcedimento(dtoGrupoProcedimento);
                        }
                    }
                }
                else
                {
                    if (obj != null) ((HacCmbGrupoProcedimento)obj).Limpa();
                }
            }
            base.OnSelectedIndexChanged(e);
        }

        /// <summary>
        /// Funciona apenas se a propriedade Limpar = True.
        /// Limpa também os combos de Grupo Procedimento.
        /// </summary>
        public void LimparCmbGrupoProcedimento()
        {
            if (this.Limpar)
            {
                if (!_somenteEspecialidadeProcedimento)
                {
                    //HacCmbSetor cmbSetor = this.FindSetor(this.FindForm().Controls);
                    HacCmbGrupoProcedimento cmbGrupoProcedimento = this.FindGrupoProcedimento(this.FindForm().Controls);

                    //if (cmbSetor != null) cmbSetor.Limpa();
                    if (cmbGrupoProcedimento != null) cmbGrupoProcedimento.Limpa();
                }
                this.IniciaLista();
            }
        }

    }
}

