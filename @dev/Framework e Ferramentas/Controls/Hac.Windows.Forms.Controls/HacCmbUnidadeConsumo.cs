using System;
using System.ComponentModel;
using System.Data;
using HospitalAnaCosta.Framework.Events;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using HospitalAnaCosta.SGS.Cadastro.Interface;
using HospitalAnaCosta.Framework;

namespace Hac.Windows.Forms.Controls
{
    public partial class HacCmbUnidadeConsumo : HacComboBox
    {

        CadastroUnidadeMedidaConsumoDTO dtoCadastroUnidadeMedidaConsumo = new CadastroUnidadeMedidaConsumoDTO();
        private ICadastroUnidadeMedidaConsumo _cadastroUnidadeMedidaConsumo;
        protected ICadastroUnidadeMedidaConsumo CadastroUnidadeMedidaConsumo
        {
            get { return _cadastroUnidadeMedidaConsumo != null ? _cadastroUnidadeMedidaConsumo : _cadastroUnidadeMedidaConsumo = (ICadastroUnidadeMedidaConsumo)CommonServices.GetObject(typeof(ICadastroUnidadeMedidaConsumo)); }
        }

        public HacCmbUnidadeConsumo()
        {
            InitializeComponent();
        }

        public HacCmbUnidadeConsumo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void Inicializar()
        {
            CarregarComboUnidadeMedidaConsumo(dtoCadastroUnidadeMedidaConsumo);
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

        [Category("Hac")]
        public void CarregarComboUnidadeMedidaConsumo(CadastroUnidadeMedidaConsumoDTO dto)
        {
            this.DataSource = null;
            dto.FlagStatus.Value = "A";
            DataTable dtb = CadastroUnidadeMedidaConsumo.Listar(dto);
            
            DataView dv = dtb.DefaultView;
            dv.Sort = CadastroUnidadeMedidaConsumoDTO.FieldNames.DescricaoMedidaConsumo;
            dtb = dv.ToTable();

            this.CarregarComboComSelecione(this, dtb, CadastroUnidadeMedidaConsumoDTO.FieldNames.CodigoMedidaConsumo, CadastroUnidadeMedidaConsumoDTO.FieldNames.DescricaoMedidaConsumo);
        }
    }
}