using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Seguranca.Interface;


namespace HospitalAnaCosta.SGS.GestaoMateriais.Componentes
{
    public partial class GestaoCmbLocalEstoque : HacComboBox
    {

        private ILocalEstoque _localestoque;
        private ILocalEstoque LocalEstoque
        {
            get { return _localestoque != null ? _localestoque : _localestoque = (ILocalEstoque)Global.Common.GetObject(typeof(ILocalEstoque)); }
        }

        public GestaoCmbLocalEstoque()
        {
            InitializeComponent();
        }

        public GestaoCmbLocalEstoque(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void CarregaLocalEstoque()
        {
            LocalEstoqueDTO dto = new LocalEstoqueDTO();
            this.ValueMember = LocalEstoqueDTO.FieldNames.IdtLocalEstoque;
            this.DisplayMember = LocalEstoqueDTO.FieldNames.DsLocalEstoque;
            this.DataSource = LocalEstoque.Sel(dto);
            
        }
    }
}
