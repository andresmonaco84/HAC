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

namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    public partial class FrmDispensacaoPendencias : FrmBase
    {
        // Itens Requisição
        private RequisicaoItensDataTable dtbReqItem;        
        private IRequisicaoItens _ReqItem;
        private IRequisicaoItens RequisicaoItem
        {
            get { return _ReqItem != null ? _ReqItem : _ReqItem = (IRequisicaoItens)Global.Common.GetObject(typeof(IRequisicaoItens)); }
        }

        public FrmDispensacaoPendencias()
        {
            InitializeComponent();
            this.MdiParent = FrmPrincipal.ActiveForm;
        }

        private void FrmDispensacaoPendencias_Load(object sender, EventArgs e)
        {
            dtgPedidos.AutoGenerateColumns = false;
            dtgPedidos.Columns[colIdPedido.Name].DataPropertyName = RequisicaoDTO.FieldNames.Idt;
            dtgPedidos.Columns[colData.Name].DataPropertyName = RequisicaoDTO.FieldNames.DataRequisicao;
            dtgPedidos.Columns[colSetor.Name].DataPropertyName = SetorDTO.FieldNames.Descricao;
            dtgPedidos.Columns[colItem.Name].DataPropertyName = MaterialMedicamentoDTO.FieldNames.NomeFantasia;
            dtgPedidos.Columns[colQtde.Name].DataPropertyName = RequisicaoItensDTO.FieldNames.QtdFornecida;

            dtgPedidos.DataSource = RequisicaoItem.ListarPendenciasDispensacao(null);
        }
    }
}