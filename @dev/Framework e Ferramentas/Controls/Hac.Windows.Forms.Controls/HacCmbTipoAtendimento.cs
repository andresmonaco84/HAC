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
    public partial class HacCmbTipoAtendimento : HacComboBox
    {
        TipoAtendimentoDTO tipoAtendimentoDTO = new TipoAtendimentoDTO();
        private ITipoAtendimento _tipoAtendimento;
        protected ITipoAtendimento TipoAtendimento
        {
            get { return _tipoAtendimento != null ? _tipoAtendimento : _tipoAtendimento = (ITipoAtendimento)CommonServices.GetObject(typeof(ITipoAtendimento)); }
        }


        public HacCmbTipoAtendimento()
        {
            InitializeComponent();
        }

        public HacCmbTipoAtendimento(IContainer container)
        {
            container.Add(this);

            InitializeComponent();            
        }

        [Category("Hac")]
        public void CarregarComboTipoAcomodacao()
        {
            this.DataSource = null;
            DataTable dtbTipoAtendimento = new DataTable();
            dtbTipoAtendimento = TipoAtendimento.Listar(tipoAtendimentoDTO);
            DataView dv = dtbTipoAtendimento.DefaultView;
            dv.Sort = TipoAtendimentoDTO.FieldNames.DescricaoTipoAtendimento;
            dtbTipoAtendimento = dv.ToTable();
            CarregarComboComSelecione(this, dtbTipoAtendimento, TipoAtendimentoDTO.FieldNames.CodigoTipoAtendimento, TipoAtendimentoDTO.FieldNames.DescricaoTipoAtendimento);            
        }
    }
}
