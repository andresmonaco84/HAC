using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Events;
using HospitalAnaCosta.Services.Produto.Interface;
using HospitalAnaCosta.Services.Produto.DTO;

namespace Hac.Windows.Forms.Controls
{
    public partial class HacCmbTipoProduto : HacComboBox
    {
        public HacCmbTipoProduto()
        {
            InitializeComponent();
        }

        public HacCmbTipoProduto(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #region [Propriedades de Acesso aos Serviços de Produtos]
        

        /// <summary>
        /// Acessa os serviços de Tipo de Atributo do Produto
        /// </summary>
        private ITipoAtributoProduto _tipoAtributoProduto;
        protected ITipoAtributoProduto TipoAtributoProduto
        {
            get
            {
                return _tipoAtributoProduto != null ? _tipoAtributoProduto : _tipoAtributoProduto = (HospitalAnaCosta.Services.Produto.Interface.ITipoAtributoProduto)CommonServices.GetObject(typeof(HospitalAnaCosta.Services.Produto.Interface.ITipoAtributoProduto));
            }
        }

        #endregion

        public void Inicializar()
        {
            this.Carregar(new TipoAtributoProdutoDTO());
        }

        public void Inicializar(TipoAtributoProdutoDTO dtoTipoAtributoProduto)
        {
            this.Carregar(dtoTipoAtributoProduto);
        }
                
        //[Category("Hac")]
        private void Carregar(TipoAtributoProdutoDTO dtoTipoAtributoProduto)
        {
            DataTable dtb;
            dtoTipoAtributoProduto.Status.Value = "A";
            dtb = this.TipoAtributoProduto.Listar(dtoTipoAtributoProduto);
            
            DataView dv = dtb.DefaultView;
            dv.Sort = TipoAtributoProdutoDTO.FieldNames.DescricacaoAtributo;

            dtb = dv.ToTable();
            this.ValueMember = TipoAtributoProdutoDTO.FieldNames.TipoAtributo;
            this.DisplayMember = TipoAtributoProdutoDTO.FieldNames.DescricacaoAtributo;

            DataRow row = dtb.NewRow();
            row[TipoAtributoProdutoDTO.FieldNames.TipoAtributo] = "-1";
            row[TipoAtributoProdutoDTO.FieldNames.DescricacaoAtributo] = "<Selecione>";
            dtb.Rows.InsertAt(row, 0);

            this.DataSource = dtb;            
            this.SelectedIndex = 0;
            //this.CarregarComboComSelecione(this, dtb, TipoAtributoProdutoDTO.FieldNames.TipoAtributo, TipoAtributoProdutoDTO.FieldNames.DescricacaoAtributo);            
        }

        protected override void OnSelectionChangeCommitted(EventArgs e)
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

    }
}
