using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Seguranca.View;
using HospitalAnaCosta.SGS.Seguranca.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HacFramework.Windows.Helpers;
using HospitalAnaCosta.Framework;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmPedidoReplicar : FrmBase
    {
        private bool _farmacia = false;
        Generico gen = new Generico();

        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        private IRequisicao _requisicao;
        private IRequisicao Requisicao
        {
            get { return _requisicao != null ? _requisicao : _requisicao = (IRequisicao)Global.Common.GetObject(typeof(IRequisicao)); }
        }

        public FrmPedidoReplicar()
        {
            InitializeComponent();
        }        

        #region OBJETOS SERVIÇOS

        #endregion

        #region Métodos

        private void AtribuirSetorHomeCare()
        {
            cmbUnidade.SelectedValue = 244; //SANTOS
            cmbLocal.SelectedValue = 46; //ATENDIMENTO DOMICILIAR
            cmbSetor.SelectedValue = 2252; //ATENDIMENTO DOMICILIAR
            cmbTipoRequisicao.SelectedValue = ((byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO).ToString();
        }

        private void AtribuirPeriodoPadrao()
        {
            txtInicio.Text = Utilitario.ObterDataHoraServidor().AddDays(-7).ToString("dd/MM/yyyy");
            txtFim.Text = Utilitario.ObterDataHoraServidor().AddDays(-1).ToString("dd/MM/yyyy");
        }

        private void CarregarComboTipo()
        {
            Generico gen = new Generico();
            List<ListItem> list = new List<ListItem>();
            list.Add(new ListItem("-1", "<Selecione>"));
            list.Add(new ListItem(((byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO).ToString(), "PERSONALIZADO"));
            list.Add(new ListItem(((byte)RequisicaoDTO.TipoRequisicao.ESTOQUE_LOCAL_MAT_MED).ToString(), "ESTOQUE LOCAL MAT/MED"));
            //list.Add(new ListItem(((byte)RequisicaoDTO.TipoRequisicao.PADRAO).ToString(), "PADRÃO"));
            if (!_farmacia)
            {
                list.Add(new ListItem(((byte)RequisicaoDTO.TipoRequisicao.IMPRESSOS_MAT_EXPEDIENTE).ToString(), "IMPRESSOS E MATERIAIS DE EXPEDIENTE"));
                list.Add(new ListItem(((byte)RequisicaoDTO.TipoRequisicao.HIGIENIZACAO).ToString(), "HIGIENIZAÇÃO"));
                list.Add(new ListItem(((byte)RequisicaoDTO.TipoRequisicao.OUTROS).ToString(), "OUTROS"));
            }

            cmbTipoRequisicao.ValueMember = ListItem.FieldNames.Key;
            cmbTipoRequisicao.DisplayMember = ListItem.FieldNames.Value;
            cmbTipoRequisicao.DataSource = list;
            cmbTipoRequisicao.IniciaLista();
        }

        private bool ValidarPeriodo()
        {
            //Validar Datas
            if (txtInicio.Text == string.Empty || !BasicFunctions.ValidarData(txtInicio.Text))
            {
                MessageBox.Show("Digite uma data de período inicial válida.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Convert.ToDateTime(txtInicio.Text) > DateTime.Now.Date)
            {
                MessageBox.Show("Data de período inicial não pode ser maior que hoje.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtFim.Text != string.Empty && !BasicFunctions.ValidarData(txtFim.Text))
            {
                MessageBox.Show("Digite uma data de período final válida.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtFim.Text.Length > 0)
            {
                if (Convert.ToDateTime(txtInicio.Text) > Convert.ToDateTime(txtFim.Text))
                {
                    MessageBox.Show("A data inicial não pode ser maior que a data final.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
                txtFim.Text = DateTime.Now.ToString("dd/MM/yyyy");

            TimeSpan periodoConsulta = DateTime.Parse(txtFim.Text) - DateTime.Parse(txtInicio.Text);
            if (periodoConsulta.Days > 10)
            {
                MessageBox.Show("Período não pode ser superior a 10 dias.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion

        #region Eventos

        private void FrmPedidoReplicar_Load(object sender, EventArgs e)
        {
            tsHac.Controla(Evento.eNovo);
            _farmacia = gen.LogadoSetorFarmacia();
            CarregarComboTipo();
            cmbUnidade.Carregaunidade();
            if (_farmacia)
            {
                chbAtendDom.Checked = false;
                lblCentroDisp.Text = "FARMACIA";
                cmbTipoRequisicao.SelectedValue = ((byte)RequisicaoDTO.TipoRequisicao.PERSONALIZADO).ToString();                
            }
            else
            {
                chbAtendDom.Checked = true;
                lblCentroDisp.Text = "ALMOXARIFADO";
                AtribuirSetorHomeCare();
            }
            AtribuirPeriodoPadrao();            
        }

        private void chbAtendDom_Click(object sender, EventArgs e)
        {
            if (chbAtendDom.Checked)
                AtribuirSetorHomeCare();
            else
                cmbUnidade.LimparCmbUnidade();
        }

        private void cmbSetor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbSetor.SelectedIndex > -1)
                chbAtendDom.Checked = false;
        }

        private void cmbTipoRequisicao_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbTipoRequisicao.SelectedValue.ToString() != "-1")
                chbAtendDom.Checked = false;
        }

        private void btnSugerir_Click(object sender, EventArgs e)
        {
            if (cmbSetor.SelectedIndex == -1 || cmbSetor.SelectedValue == null)
            {
                MessageBox.Show("Selecione o Setor.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cmbTipoRequisicao.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("Selecione o Tipo Pedido.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (ValidarPeriodo())
            {
                if (MessageBox.Show("Deseja realmente replicar estes pedidos ?",
                                    "Gestão de Materiais e Medicamentos",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    Requisicao.ReplicarPedidos(int.Parse(cmbTipoRequisicao.SelectedValue.ToString()),
                                               int.Parse(cmbSetor.SelectedValue.ToString()),
                                               DateTime.Parse(txtInicio.Text),
                                               DateTime.Parse(txtFim.Text),
                                               chbApenasFornecidos.Checked,
                                               _farmacia,
                                               (int)FrmPrincipal.dtoSeguranca.Idt.Value);
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Processo finalizado com sucesso!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }   

        #endregion        
    }
}