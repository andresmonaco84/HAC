using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;

namespace HospitalAnaCosta.SGS.GestaoMateriais.HomeCare
{
    public partial class FrmAtdDomiciliarPendencias : FrmBase
    {
        // Itens Requisição
        private IRequisicaoItens _requisicaoitens;
        private IRequisicaoItens RequisicaoItens
        {
            get { return _requisicaoitens != null ? _requisicaoitens : _requisicaoitens = (IRequisicaoItens)Global.Common.GetObject(typeof(IRequisicaoItens)); }
        }        

        public FrmAtdDomiciliarPendencias()
        {
            InitializeComponent();
            dtgAtdDom.AutoGenerateColumns = false;
            this.Cursor = Cursors.WaitCursor;
            dtgAtdDom.DataSource = RequisicaoItens.SelReqItensPendentes(2252); //ATENDIMENTO DOMICILIAR
            this.Cursor = Cursors.Default;
        }
    }
}
