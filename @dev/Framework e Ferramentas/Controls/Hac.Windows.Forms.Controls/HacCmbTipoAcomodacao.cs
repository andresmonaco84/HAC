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
    public partial class HacCmbTipoAcomodacao : HacComboBox
    {
        private bool _permiteDifClasse = false;
        [Category("Hac")]
        public bool PermiteDiferencaClasse
        {
            get { return _permiteDifClasse; }
            set { _permiteDifClasse = value; }
        }

        private bool _utilizaRepasse = false;
        [Category("Hac")]
        public bool UtilizaRepasse
        {
            get { return _utilizaRepasse; }
            set { _utilizaRepasse = value; }
        }

        TipoAcomodacaoDTO tipoAcomodacaoDTO = new TipoAcomodacaoDTO();
        private ITipoAcomodacao _tipoAcomodacao;
        protected ITipoAcomodacao TipoAcomodacao
        {
            get { return _tipoAcomodacao != null ? _tipoAcomodacao : _tipoAcomodacao = (ITipoAcomodacao)CommonServices.GetObject(typeof(ITipoAcomodacao)); }
        }

        AssociacaoConvenioUnidadeTipoAcomodacaoDTO associacaoConvenioUnidadeTipoAcomodacaoDTO = new AssociacaoConvenioUnidadeTipoAcomodacaoDTO();
        private IAssociacaoConvenioUnidadeTipoAcomodacao _associacaoConvenioUnidadeTipoAcomodacao;
        protected IAssociacaoConvenioUnidadeTipoAcomodacao AssociacaoConvenioUnidadeTipoAcomodacao
        {
            get { return _associacaoConvenioUnidadeTipoAcomodacao != null ? _associacaoConvenioUnidadeTipoAcomodacao : _associacaoConvenioUnidadeTipoAcomodacao = (IAssociacaoConvenioUnidadeTipoAcomodacao)CommonServices.GetObject(typeof(IAssociacaoConvenioUnidadeTipoAcomodacao)); }
        }
                
        private IAssociacaoConvenioUnidadePlanoTipoAcomodacao _assConvenioUnidadePlanoTipoAcomodacao;
        protected IAssociacaoConvenioUnidadePlanoTipoAcomodacao AssConvenioUnidadePlanoTipoAcomodacao
        {
            get
            {
                return _assConvenioUnidadePlanoTipoAcomodacao != null ? _assConvenioUnidadePlanoTipoAcomodacao : _assConvenioUnidadePlanoTipoAcomodacao = (IAssociacaoConvenioUnidadePlanoTipoAcomodacao)CommonServices.GetObject(typeof(IAssociacaoConvenioUnidadePlanoTipoAcomodacao));
            }
        }

        public HacCmbTipoAcomodacao()
        {
            InitializeComponent();
        }

        public HacCmbTipoAcomodacao(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        [Category("Hac")]
        public void CarregarComboTipoAcomodacao()
        {
            this.DataSource = null;
            DataTable dtbTipoAcomodacao = new DataTable();
            if (PermiteDiferencaClasse) tipoAcomodacaoDTO.FlagPermiteDiferencaClasse.Value = "S";
            if (UtilizaRepasse) tipoAcomodacaoDTO.FlagUtilizaRepasse.Value = "S";
            dtbTipoAcomodacao = TipoAcomodacao.Listar(tipoAcomodacaoDTO);
            DataView dv = dtbTipoAcomodacao.DefaultView;
            dv.Sort = "TIS_TAC_DS_TIPO_ACOMODACAO ASC";

            dtbTipoAcomodacao = dv.ToTable();

            CarregarComboComSelecione(this, dtbTipoAcomodacao, TipoAcomodacaoDTO.FieldNames.CodigoTipoAcomodacao, TipoAcomodacaoDTO.FieldNames.DescricaoTipoAcomodacao);
        }

        [Category("Hac")]
        public void CarregarComboTipoAcomodacao(int codigoConvenio, int? codigoPlano, int? codigoUnidade)
        {
            this.DataSource = null;
            string campoDataIni, campoDataFim;
            DateTime dtIni, dtFim;
            DataTable dtbTipoAcomodacao = new DataTable();            

            if (codigoPlano == null)
            {
                dtbTipoAcomodacao = AssociacaoConvenioUnidadeTipoAcomodacao.ListarUnidadeConvenioTPAcomodacao(codigoConvenio);
                campoDataIni = AssociacaoConvenioUnidadeTipoAcomodacaoDTO.FieldNames.DataInicioVigencia;
                campoDataFim = AssociacaoConvenioUnidadeTipoAcomodacaoDTO.FieldNames.DataFimVigencia;
            }
            else
            {
                PlanoDTO dtoPlano = new PlanoDTO();
                dtoPlano.IdtConvenio.Value = codigoConvenio;
                if (codigoPlano != null) dtoPlano.IdtPlano.Value = codigoPlano.Value;
                dtbTipoAcomodacao = AssConvenioUnidadePlanoTipoAcomodacao.ListarUnidadeLocalConvenioPlanoTPAcomodacao(dtoPlano, codigoUnidade.Value);
                campoDataIni = AssociacaoConvenioUnidadePlanoTipoAcomodacaoDTO.FieldNames.DataInicioVigencia;
                campoDataFim = AssociacaoConvenioUnidadePlanoTipoAcomodacaoDTO.FieldNames.DataFimVigencia;
            }

            //retira os itens fora do período de vigência
            for (int index = 0; index < dtbTipoAcomodacao.Rows.Count; index++)
            {
                dtIni = (DateTime)dtbTipoAcomodacao.Rows[index][campoDataIni];

                if (dtbTipoAcomodacao.Rows[index][campoDataFim].ToString() != string.Empty)
                {
                    dtFim = (DateTime)dtbTipoAcomodacao.Rows[index][campoDataFim];
                    if (DateTime.Now < dtIni || DateTime.Now > dtFim)
                    {
                        dtbTipoAcomodacao.Rows[index].Delete();
                    }
                }
                else
                {
                    if (DateTime.Now < dtIni)
                    {
                        dtbTipoAcomodacao.Rows[index].Delete();
                    }
                }
            }
            dtbTipoAcomodacao.AcceptChanges();

            DataView dv = dtbTipoAcomodacao.DefaultView;
            dv.Sort = "TIS_TAC_DS_TIPO_ACOMODACAO ASC";

            dtbTipoAcomodacao = dv.ToTable();

            CarregarComboComSelecione(this, dtbTipoAcomodacao, TipoAcomodacaoDTO.FieldNames.CodigoTipoAcomodacao, TipoAcomodacaoDTO.FieldNames.DescricaoTipoAcomodacao);

        }
    }
}