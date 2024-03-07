using System.ComponentModel;
using System.Data;
using HospitalAnaCosta.Services.Produto.DTO;
using HospitalAnaCosta.Services.Produto.Interface;

namespace Hac.Windows.Forms.Controls
{     
    public partial class HacCmbAtributoProduto : HacComboBox
    {

        private ITipoAtributoProduto _tipoAtributoProduto;
        protected ITipoAtributoProduto TipoAtributoProduto
        {
            get { return _tipoAtributoProduto != null ? _tipoAtributoProduto : _tipoAtributoProduto = (ITipoAtributoProduto)CommonServices.GetObject(typeof(ITipoAtributoProduto)); }
        }

        public HacCmbAtributoProduto()
        {
            InitializeComponent();
        }

        public HacCmbAtributoProduto(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        [Category("Hac")]
        public void CarregarComboTipoAtributoProduto(TipoAtributoProdutoDTO dtoTipoAtributoProduto)
        {
            this.DataSource = null;

            TipoAtributoProdutoDataTable dtbTipoAtributoProduto = new TipoAtributoProdutoDataTable();
            dtbTipoAtributoProduto = TipoAtributoProduto.Listar(dtoTipoAtributoProduto);
            DataView dv = dtbTipoAtributoProduto.DefaultView;
            dv.Sort = string.Format("{0} ASC", TipoAtributoProdutoDTO.FieldNames.DescricacaoAtributo);
            //dtbTipoAtributoProduto = dv.ToTable();
            CarregarComboComSelecione(this, dtbTipoAtributoProduto, TipoAtributoProdutoDTO.FieldNames.TipoAtributo, TipoAtributoProdutoDTO.FieldNames.DescricacaoAtributo);
        }
    }
}

