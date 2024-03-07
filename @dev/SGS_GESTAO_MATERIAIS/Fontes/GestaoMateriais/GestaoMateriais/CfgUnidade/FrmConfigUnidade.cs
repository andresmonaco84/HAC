using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Seguranca.Interface;
using HospitalAnaCosta.SGS.Seguranca.View;
using HospitalAnaCosta.SGS.Componentes;


namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    public partial class FrmConfigUnidade : FrmBase
    {
        public FrmConfigUnidade()
        {
            InitializeComponent();
        }

        #region OBJETOS SERVIÇOS

        private CommonSeguranca _commonSeguranca;
        protected CommonSeguranca CommonSeguranca
        {
            get { return _commonSeguranca != null ? _commonSeguranca : _commonSeguranca = new CommonSeguranca(null); }
        }

        // Setor
        private SetorDTO dtoSetor;
        private SetorDTO dtoSetorSelecionado;
        private SetorDataTable dtbSetoresCentroDisp;        
        private ISetor _isetor;
        private ISetor Setor
        {
            get { return _isetor != null ? _isetor : _isetor = (ISetor)Global.Common.GetObject(typeof(ISetor)); }
        }

        private SetorEstoqueConsumoDataTable dtbSetoresEstoqueCompartilhado;

        private MatMedSetorConfigDataTable dtbMatMedSetorConfig;
        private MatMedSetorConfigDTO dtoMatMedSetorConfig;
        private MatMedSetorConfigDTO dtoSetorCfg;

        private IMatMedSetorConfig _matMedConfig;
        private IMatMedSetorConfig MatMedSetorConfig
        {
            get { return _matMedConfig != null ? _matMedConfig : _matMedConfig = (IMatMedSetorConfig)Global.Common.GetObject( typeof(IMatMedSetorConfig)); }
        }        

        // Movimentos
        private MovimentacaoDTO dtoMovimento;        
        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject( typeof(IMovimentacao)); }
        }

        private IUnidadeLocalSetorUsuario _usuariosetor;
        private IUnidadeLocalSetorUsuario UsuarioSetor
        { 
            get { return _usuariosetor != null? _usuariosetor : _usuariosetor = (IUnidadeLocalSetorUsuario)CommonSeguranca.GetObject(typeof(IUnidadeLocalSetorUsuario)); }
        }        

        Generico gen = new Generico();
        #endregion

        #region FUNÇÕES

        private void ConfiguraSetorCentroDispDTG()
        {
            dtgSetorCentroDisp.AutoGenerateColumns = false;
            dtgSetorCentroDisp.Columns["colIdUnidade"].DataPropertyName = SetorDTO.FieldNames.IdtUnidade;
            dtgSetorCentroDisp.Columns["colDsUnidade"].DataPropertyName = SetorDTO.FieldNames.DsUnidade;
            dtgSetorCentroDisp.Columns["colIdLocal"].DataPropertyName = SetorDTO.FieldNames.IdtLocalAtendimento;
            dtgSetorCentroDisp.Columns["colDsLocal"].DataPropertyName = SetorDTO.FieldNames.DsLocal;
            dtgSetorCentroDisp.Columns["colIdSetor"].DataPropertyName = SetorDTO.FieldNames.Idt;
            dtgSetorCentroDisp.Columns["colDsSetor"].DataPropertyName = SetorDTO.FieldNames.Descricao;
        }

        private void ConfiguraUsuarioSetor()
        {
            dtgUsuariosSetor.AutoGenerateColumns = false;
            dtgUsuariosSetor.Columns["colIdtUsuario"].DataPropertyName = UnidadeLocalSetorUsuarioDTO.FieldNames.IdtUsuario;
            dtgUsuariosSetor.Columns["colNmUsuario"].DataPropertyName = UnidadeLocalSetorUsuarioDTO.FieldNames.NmUsuario;
        }
        private void ConfiguraSubGrupoDTG()
        {
            dtgSubGrupo.AutoGenerateColumns = false;
            dtgSubGrupo.Columns["colDsGrupo"].DataPropertyName = MatMedSetorConfigDTO.FieldNames.DsGrupo;
            dtgSubGrupo.Columns["colDsSubGrupo"].DataPropertyName = MatMedSetorConfigDTO.FieldNames.DsSubGrupo;
            dtgSubGrupo.Columns["colSubGrupoIdt"].DataPropertyName = MatMedSetorConfigDTO.FieldNames.IdtSubGrupo;
            dtgSubGrupo.Columns["colGrupoIdt"].DataPropertyName = MatMedSetorConfigDTO.FieldNames.IdtGrupo;
        }

        private void ConfiguraEstoqueConsumoDTG()
        {
            dtgEstoqueConsumo.AutoGenerateColumns = false;
            dtgEstoqueConsumo.Columns["colIdtUnidadeConsumo"].DataPropertyName = SetorEstoqueConsumoDTO.FieldNames.IdtUnidadeConsumo;
            dtgEstoqueConsumo.Columns["colDsUnidadeConsumo"].DataPropertyName = SetorEstoqueConsumoDTO.FieldNames.DsUnidadeConsumo;
            dtgEstoqueConsumo.Columns["colIdtLocalConsumo"].DataPropertyName = SetorEstoqueConsumoDTO.FieldNames.IdtLocalConsumo;
            dtgEstoqueConsumo.Columns["colDsLocalConsumo"].DataPropertyName = SetorEstoqueConsumoDTO.FieldNames.DsLocalConsumo;
            dtgEstoqueConsumo.Columns["colIdtSetorConsumo"].DataPropertyName = SetorEstoqueConsumoDTO.FieldNames.IdtSetorConsumo;
            dtgEstoqueConsumo.Columns["colDsSetorConsumo"].DataPropertyName = SetorEstoqueConsumoDTO.FieldNames.DsSetorConsumo;
            dtgEstoqueConsumo.Columns["colIdtFilialConsumo"].DataPropertyName = SetorEstoqueConsumoDTO.FieldNames.IdtFilial;
            dtgEstoqueConsumo.Columns["colDsFilialConsumo"].DataPropertyName = SetorEstoqueConsumoDTO.FieldNames.DsFilial;
        }

        private void MostrarAbaCorretaCentroDispensacao(bool centroDispensacao)
        {
            if (centroDispensacao)
            {
                //tcConfig.TabPages.Insert(0, tpCentroDispSetores);
                tcConfig.TabPages.Add(tpCentroDispSetores);
                tcConfig.TabPages.Remove(tpCentroDisp);
                //tcConfig.SelectedTab = tpCentroDispSetores;
            }
            else
            {
                //tcConfig.TabPages.Insert(0, tpCentroDisp);
                tcConfig.TabPages.Add(tpCentroDisp);
                tcConfig.TabPages.Remove(tpCentroDispSetores);
                //tcConfig.SelectedTab = tpCentroDisp;

                dtoMovimento = new MovimentacaoDTO();

                dtoMovimento.IdtSetor = dtoSetorSelecionado.Idt;
                SetorDTO dtoSetFarm;
                dtoMovimento = Movimento.CentroDispensacao(dtoMovimento, out dtoSetFarm);

                cmbUnidadeCD.Carregaunidade();
                cmbUnidadeCD.SelectedValue = dtoMovimento.IdtUnidadeBaixa.Value;
                cmbLocalCD.SelectedValue = dtoMovimento.IdtLocalBaixa.Value;
                cmbSetorCD.SelectedValue = dtoMovimento.IdtSetorBaixa.Value;

                cmbUnidadeFarm.Carregaunidade();
                if (dtoSetFarm != null)
                {
                    cmbUnidadeFarm.SelectedValue = dtoSetFarm.IdtUnidade.Value;
                    cmbLocalFarm.SelectedValue = dtoSetFarm.IdtLocalAtendimento.Value;
                    cmbSetorFarm.SelectedValue = dtoSetFarm.Idt.Value;
                }
            }
        }

        private void CarregarSetorConfig()
        {
            this.Cursor = Cursors.WaitCursor;
            dtoSetorSelecionado = new SetorDTO();
            dtoSetorCfg = new MatMedSetorConfigDTO();

            dtoSetorSelecionado.Idt.Value = cmbSetor.SelectedValue.ToString();

            dtoSetorSelecionado = Setor.SelChave(dtoSetorSelecionado);

            chkPermiteEstoque.Checked = (dtoSetorSelecionado.PossuiEstoqueProprio.Value == "S" ? true : false);

            dtoSetorCfg.IdtUnidade.Value = dtoSetorSelecionado.IdtUnidade.Value;
            dtoSetorCfg.IdtLocal.Value = dtoSetorSelecionado.IdtLocalAtendimento.Value;
            dtoSetorCfg.Idtsetor.Value = dtoSetorSelecionado.Idt.Value;

            dtoSetorCfg = MatMedSetorConfig.SetorCfg(dtoSetorCfg);
            if (dtoSetorCfg.EstoqueUnificadoHAC.Value.IsNull) dtoSetorCfg.EstoqueUnificadoHAC.Value = "0";
            cbEstoqueUnificado.Checked = (dtoSetorCfg.EstoqueUnificadoHAC.Value == 1 ? true : false);
            chkTodosSetores.Checked = (dtoSetorCfg.AtendeTodosSetores.Value == 1 ? true : false);
            chkTodasUnidades.Checked = (dtoSetorCfg.AtendeTodasUnidades.Value == 1 ? true : false);
            chkIgnoraAlta.Checked = (dtoSetorCfg.IgnoraAlta.Value == 1 ? true : false);
            txtIgnoraAltaAte.Text = !dtoSetorCfg.IgnoraAltaHorasAte.Value.IsNull ? dtoSetorCfg.IgnoraAltaHorasAte.Value.ToString() : string.Empty;
            chkConsomeOutroSetor.Checked = (dtoSetorCfg.ConsomeParaOutroCentroCusto.Value == 1 ? true : false);
            if (dtoSetorCfg.SolicitaKit.Value.IsNull) dtoSetorCfg.SolicitaKit.Value = 0;
            chkSolicitaKit.Checked = (dtoSetorCfg.SolicitaKit.Value == 1 ? true : false);
            if (dtoSetorCfg.ControlaConsumoPaciente.Value.IsNull) dtoSetorCfg.ControlaConsumoPaciente.Value = 0;
            chkControlaConsPac.Checked = (dtoSetorCfg.ControlaConsumoPaciente.Value == 1 ? true : false);
            if (chkControlaConsPac.Checked && !dtoSetorCfg.DataControlaConsumoPaciente.Value.IsNull)
            {
                grbControlaConsumoPac.Visible = true;
                txtDataConsPac.Text = DateTime.Parse(dtoSetorCfg.DataControlaConsumoPaciente.Value.ToString()).ToString("dd/MM/yyyy");
                txtHora.Text = DateTime.Parse(dtoSetorCfg.DataControlaConsumoPaciente.Value.ToString()).ToString("HH");
                txtMinuto.Text = DateTime.Parse(dtoSetorCfg.DataControlaConsumoPaciente.Value.ToString()).ToString("mm");
            }
            else
            {
                grbControlaConsumoPac.Visible = false;
                txtDataConsPac.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtHora.Text = DateTime.Now.ToString("HH");
                txtMinuto.Text = DateTime.Now.ToString("mm");
            }
            if (!dtoSetorCfg.IdFuncionalidade.Value.IsNull)
                cmbTipoPedido.SelectedValue = dtoSetorCfg.IdFuncionalidade.Value;
            else
                cmbTipoPedido.IniciaLista();

            btnAddSubGrupo.Visible = true;
            cbAlmoxCentral.Checked = false;
            cbCentroDisp.Checked = false;
            tcConfig.TabPages.Remove(tpCentroDispSetores);
            tcConfig.TabPages.Remove(tpCentroDisp);

            if (dtoSetorSelecionado.FlAlmoxCentral.Value == (byte)SetorDTO.AlmoxarifadoCentral.SIM)
            {
                cbAlmoxCentral.Checked = true;
                cbCentroDisp.Enabled = false;
            }
            else
            {
                if (dtoSetorSelecionado.SubstituiAlmoxarifado.Value == "S")
                {
                    //O setor selecionado é um centro de dispensação.
                    //Lista os setores que são abastecidos por este centro de dispensação para edição.

                    cbCentroDisp.Checked = true;
                    cbAlmoxCentral.Enabled = false;
                    MostrarAbaCorretaCentroDispensacao(true);

                    dtoSetor = new SetorDTO();

                    dtoSetor.UnidadeAlmoxarifado.Value = cmbUnidade.SelectedValue.ToString();
                    dtoSetor.LocalAlmoxarifado.Value = cmbLocal.SelectedValue.ToString();
                    dtoSetor.SetorAlmoxarifado.Value = cmbSetor.SelectedValue.ToString();

                    dtbSetoresCentroDisp = Setor.SelSetoresCentroDispensacao(dtoSetor);
                    dtgSetorCentroDisp.DataSource = dtbSetoresCentroDisp;                    
                }
                else
                {
                    //O setor selecionado não é um centro de dispensação.
                    //Mostra o centro de dispensação deste setor para edição.

                    MostrarAbaCorretaCentroDispensacao(false);                    
                }                
            }

            //Seleciona os subgrupos de Mat/Med que este setor tem acesso para edição.
            dtoMatMedSetorConfig = new MatMedSetorConfigDTO();

            dtoMatMedSetorConfig.Idtsetor = dtoSetorSelecionado.Idt;
            dtoMatMedSetorConfig.IdtUnidade = dtoSetorSelecionado.IdtUnidade;
            dtoMatMedSetorConfig.IdtLocal = dtoSetorSelecionado.IdtLocalAtendimento;

            dtbMatMedSetorConfig = MatMedSetorConfig.Sel(dtoMatMedSetorConfig);
            dtgSubGrupo.DataSource = dtbMatMedSetorConfig;

            CarregarCarrEmergPai();
            chkCE.Checked = false;
            chkCE.Text = "Carrinho Emergência";
            if (!dtoSetorSelecionado.CarrinhoEmergSetorPai.Value.IsNull)
            {
                chkCE.Checked = true;
                chkCE.Text += " do Setor " + cmbSetorCE.Text;
            }   

            this.Cursor = Cursors.Default;
        }

        private void CarregaUsuarioSetor()
        {
            UnidadeLocalSetorUsuarioDataTable dtbUsuarioSetor = new UnidadeLocalSetorUsuarioDataTable();
            UnidadeLocalSetorUsuarioDTO dtoSetorUsuario = new UnidadeLocalSetorUsuarioDTO();

            dtoSetorUsuario.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoSetorUsuario.IdtLocalAtendimento.Value = cmbLocal.SelectedValue.ToString();
            dtoSetorUsuario.IdtSetor.Value = cmbSetor.SelectedValue.ToString();

            dtbUsuarioSetor = UsuarioSetor.UsuarioPorSetor(dtoSetorUsuario);
            dtgUsuariosSetor.DataSource = dtbUsuarioSetor;
            
        }

        private bool Salvar()
        {
            DateTime? dtControlaConsumoPac = null;
            if (chkControlaConsPac.Checked && grbControlaConsumoPac.Visible)
            {
                if (txtDataConsPac.Text == string.Empty ||
                    txtHora.Text == string.Empty ||
                    txtMinuto.Text == string.Empty)
                {
                    MessageBox.Show("Digite a Data/Hora/Minuto para início de controle de consumo do paciente.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDataConsPac.Focus();
                    return false;
                }
                if (int.Parse(txtHora.Text) > 24)
                {
                    MessageBox.Show("Hora inválida.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHora.Focus();
                    return false;
                }
                if (int.Parse(txtMinuto.Text) > 59)
                {
                    MessageBox.Show("Minuto inválido.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMinuto.Focus();
                    return false;
                }
                string strHoraMin = txtHora.Text.PadLeft(2, '0') + ":" + txtMinuto.Text.PadLeft(2, '0');
                string strData;
                try
                {
                    strData = DateTime.Parse(txtDataConsPac.Text).ToString("dd/MM/yyyy");
                }
                catch
                {
                    MessageBox.Show("Data inválida.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDataConsPac.Focus();
                    return false;
                }
                dtControlaConsumoPac = DateTime.Parse(strData + " " + strHoraMin);
            }            
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtoSetorSelecionado.UnidadeAlmoxarifado.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();
                dtoSetorSelecionado.LocalAlmoxarifado.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();
                dtoSetorSelecionado.SetorAlmoxarifado.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();

                dtoSetorSelecionado.SubstituiAlmoxarifado.Value = "N";
                dtoSetorSelecionado.FlAlmoxCentral.Value = (byte)SetorDTO.AlmoxarifadoCentral.NAO;

                if (cbAlmoxCentral.Checked)
                {
                    dtoSetorSelecionado.FlAlmoxCentral.Value = (byte)SetorDTO.AlmoxarifadoCentral.SIM;                    
                }
                else if (cbCentroDisp.Checked)
                {                    
                    dtoSetorSelecionado.SubstituiAlmoxarifado.Value = "S";
                }
                else
                {
                    dtoSetorSelecionado.UnidadeAlmoxarifado.Value = cmbUnidadeCD.SelectedValue.ToString();
                    dtoSetorSelecionado.LocalAlmoxarifado.Value = cmbLocalCD.SelectedValue.ToString();
                    dtoSetorSelecionado.SetorAlmoxarifado.Value = cmbSetorCD.SelectedValue.ToString();

                    if (cmbSetorFarm.SelectedIndex > -1 && cmbSetorFarm.SelectedValue != null)
                        dtoSetorSelecionado.SetorFarmacia.Value = cmbSetorFarm.SelectedValue.ToString();
                    else
                        dtoSetorSelecionado.SetorFarmacia.Value = new Framework.DTO.TypeDecimal();
                }

                if (dtbMatMedSetorConfig == null) dtbMatMedSetorConfig = new MatMedSetorConfigDataTable();
                if (dtbSetoresCentroDisp == null) dtbSetoresCentroDisp = new SetorDataTable();

                dtoSetorSelecionado.PossuiEstoqueProprio.Value = (chkPermiteEstoque.Checked ? "S" : "N");                

                MatMedSetorConfig.Gravar(dtoSetorSelecionado, dtoMatMedSetorConfig, dtbMatMedSetorConfig, dtbSetoresCentroDisp);
                // cfg
                dtoSetorCfg = new MatMedSetorConfigDTO();
                dtoMatMedSetorConfig.Idtsetor = dtoSetorSelecionado.Idt;
                dtoMatMedSetorConfig.IdtUnidade = dtoSetorSelecionado.IdtUnidade;
                dtoMatMedSetorConfig.IdtLocal = dtoSetorSelecionado.IdtLocalAtendimento;
                dtoMatMedSetorConfig.AtendeTodosSetores.Value = (chkTodosSetores.Checked ? 1 : 0);
                dtoMatMedSetorConfig.AtendeTodasUnidades.Value = (chkTodasUnidades.Checked ? 1 : 0);
                dtoMatMedSetorConfig.IgnoraAlta.Value = ( chkIgnoraAlta.Checked ? 1 : 0);
                if (chkIgnoraAlta.Checked && txtIgnoraAltaAte.Text != string.Empty) dtoMatMedSetorConfig.IgnoraAltaHorasAte.Value = txtIgnoraAltaAte.Text;
                dtoMatMedSetorConfig.ConsomeParaOutroCentroCusto.Value = (chkConsomeOutroSetor.Checked ? 1 : 0);
                dtoMatMedSetorConfig.EstoqueUnificadoHAC.Value = (cbEstoqueUnificado.Checked ? 1 : 0);
                dtoMatMedSetorConfig.SolicitaKit.Value = (chkSolicitaKit.Checked ? 1 : 0);
                dtoMatMedSetorConfig.ControlaConsumoPaciente.Value = (chkControlaConsPac.Checked ? 1 : 0);
                if (chkControlaConsPac.Checked && grbControlaConsumoPac.Visible && dtControlaConsumoPac != null)
                    dtoMatMedSetorConfig.DataControlaConsumoPaciente.Value = dtControlaConsumoPac;
                else
                    dtoMatMedSetorConfig.DataControlaConsumoPaciente.Value = new Framework.DTO.TypeDateTime();

                if (cmbTipoPedido.SelectedValue != null && cmbTipoPedido.SelectedIndex > -1)
                    dtoMatMedSetorConfig.IdFuncionalidade.Value = cmbTipoPedido.SelectedValue.ToString();
                else
                    dtoMatMedSetorConfig.IdFuncionalidade.Value = new Framework.DTO.TypeDecimal();

                MatMedSetorConfig.SetorCfgSalvar(dtoMatMedSetorConfig);

                Pesquisar();
                this.Cursor = Cursors.Default;
                MessageBox.Show("Configurações do Setor atualizada com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }            
            return true;
        }

        private void Cancelar()
        {
            tsHac.Controla(Evento.eCancelar);
            tcConfig.TabPages.Remove(tpCentroDispSetores);
            tcConfig.TabPages.Remove(tpCentroDisp);            
            dtbMatMedSetorConfig = null;
            // dtbEstoqueConsumo = null;
            dtgSubGrupo.DataSource = null;
            dtgEstoqueConsumo.DataSource = null;
            dtoMatMedSetorConfig = new MatMedSetorConfigDTO();
            btnAddSubGrupo.Visible = 
            btnEstoqueConsumo.Enabled =
            lblCompartilhado.Visible = 
            chkSolicitaKit.Checked =
            chkPermiteEstoque.Checked =
            chkConsomeOutroSetor.Checked = 
            chkTodosSetores.Checked = 
            chkTodasUnidades.Checked = 
            chkIgnoraAlta.Checked =
            chkControlaConsPac.Checked =
            chkCE.Checked = 
            grbControlaConsumoPac.Visible = false;
            chkCE.Text = "Carrinho Emergência";
            cmbTipoPedido.IniciaLista();
        }

        private void Pesquisar()
        {
            tsHac.Controla(Evento.eNovo);
            tsHac.Controla(Evento.eEditar);
            btnEstoqueConsumo.Enabled = true;
            CarregarSetorConfig();
            CarregaUsuarioSetor();
            SetorEstoqueConsumoDTO dto = new SetorEstoqueConsumoDTO();
            dto.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dto.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dto.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtgEstoqueConsumo.DataSource =  gen.CarregaEstoqueConsumo(dto);
            dtbSetoresEstoqueCompartilhado = gen.VerificaEstoqueCompartilhado(dto);
            if (dtbSetoresEstoqueCompartilhado.Rows.Count > 0) lblCompartilhado.Visible = true;            
        }

        private void CarregarCarrEmergPai()
        {
            if (dtoSetorSelecionado != null && !dtoSetorSelecionado.CarrinhoEmergSetorPai.Value.IsNull)
            {
                this.Cursor = Cursors.WaitCursor;
                SetorDTO dtoSetCE = new SetorDTO();
                dtoSetCE.Idt.Value = dtoSetorSelecionado.CarrinhoEmergSetorPai.Value;
                dtoSetCE = Setor.SelChave(dtoSetCE);
                cmbUnidadeCE.SelectedValue = dtoSetCE.IdtUnidade.Value;
                cmbLocalCE.SelectedValue = dtoSetCE.IdtLocalAtendimento.Value;
                cmbSetorCE.SelectedValue = dtoSetCE.Idt.Value;
                this.Cursor = Cursors.Default;
            }
            else
                cmbUnidadeCE.SelectedIndex = -1;
        }

        #endregion

        #region EVENTOS

        private void FrmConfigUnidade_Load(object sender, EventArgs e)
        {
            cmbUnidade.Carregaunidade();
            cmbUnidadeCE.Carregaunidade();
            ConfiguraSetorCentroDispDTG();
            ConfiguraUsuarioSetor();
            ConfiguraSubGrupoDTG();
            tcConfig.TabPages.Remove(tpCentroDispSetores);
            tcConfig.TabPages.Remove(tpCentroDisp);
            ConfiguraEstoqueConsumoDTG();
            cmbTipoPedido.DataSource = gen.ListarTipoPedidoFuncionalidade(false);
            cmbTipoPedido.IniciaLista();
        }

        private void cbAlmoxCentral_Click(object sender, EventArgs e)
        {
            tcConfig.TabPages.Remove(tpCentroDispSetores);
            tcConfig.TabPages.Remove(tpCentroDisp);
            cbCentroDisp.Checked = false;
            if (cbAlmoxCentral.Checked)
            {
                cbCentroDisp.Enabled = false;
            }
            else
            {
                cbCentroDisp.Enabled = true;
            }
        }

        private void cbCentroDisp_Click(object sender, EventArgs e)
        {
            cbAlmoxCentral.Checked = false;
            if (cbCentroDisp.Checked)
            {
                cbAlmoxCentral.Enabled = false;
            }
            else
            {
                cbAlmoxCentral.Enabled = true;
            }
            MostrarAbaCorretaCentroDispensacao(cbCentroDisp.Checked);
        }

        private void btnAddSubGrupo_Click(object sender, EventArgs e)
        {
            FrmAddSubGrupo frmAddSubGrupo = new FrmAddSubGrupo();
            dtbMatMedSetorConfig = frmAddSubGrupo.SelecionarSubGrupos(dtbMatMedSetorConfig);
            dtgSubGrupo.DataSource = dtbMatMedSetorConfig;
        }
       
        private void btnAddSetorCentroDisp_Click(object sender, EventArgs e)
        {
            dtoSetor = FrmAddSetorAlmox.SelecionarSetor();

            if (dtoSetor != null)
            {
                if (dtbSetoresCentroDisp == null) dtbSetoresCentroDisp = new SetorDataTable();

                try
                {
                    if (dtoSetor.Idt.Value == cmbSetor.SelectedValue.ToString())
                    {
                        MessageBox.Show("Você não pode selecionar o próprio setor como o seu centro de dispensação", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        dtbSetoresCentroDisp.Add(dtoSetor);
                        dtgSetorCentroDisp.DataSource = dtbSetoresCentroDisp;
                    }                    
                }
                catch (ConstraintException ex)
                {
                    MessageBox.Show("Já foi adicionado o setor selecionado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }        
        }
        
        private void dtgSetorCentroDisp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgSetorCentroDisp.Columns[e.ColumnIndex].Name == "colDeletarAlmox")
            {
                if (MessageBox.Show("Deseja deletar esse setor do almoxarifado selecionado ?",
                                     "Gestão de Materiais e Medicamentos",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int nCount = 0; nCount < dtbSetoresCentroDisp.Rows.Count; nCount++)
                    {
                        if (dtbSetoresCentroDisp.Rows[nCount].RowState != DataRowState.Deleted)
                        {
                            if (dtbSetoresCentroDisp.Rows[nCount][SetorDTO.FieldNames.Idt].ToString() == dtgSetorCentroDisp.Rows[e.RowIndex].Cells["colIdSetor"].Value.ToString())
                            {
                                dtbSetoresCentroDisp.Rows[nCount].Delete();
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void dtgSubGrupo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgSubGrupo.Columns[e.ColumnIndex].Name == "colDeletarSubGrupo")
            {
                if (MessageBox.Show("Deseja deletar este sub grupo referente ao acesso do almoxarifado selecionado ?",
                                     "Gestão de Materiais e Medicamentos",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int nCount = 0; nCount < dtbMatMedSetorConfig.Rows.Count; nCount++)
                    {
                        if (dtbMatMedSetorConfig.Rows[nCount].RowState != DataRowState.Deleted)
                        {
                            if (dtbMatMedSetorConfig.Rows[nCount][MatMedSetorConfigDTO.FieldNames.IdtSubGrupo].ToString() == dtgSubGrupo.Rows[e.RowIndex].Cells["colSubGrupoIdt"].Value.ToString() &&
                                dtbMatMedSetorConfig.Rows[nCount][MatMedSetorConfigDTO.FieldNames.IdtGrupo].ToString() == dtgSubGrupo.Rows[e.RowIndex].Cells["colGrupoIdt"].Value.ToString())
                            {
                                dtbMatMedSetorConfig.Rows[nCount].Delete();
                                break;
                            }
                        }
                    }
                }
            }
        }

        private bool tsHac_CancelarClick(object sender)
        {
            this.Cancelar();
            return true;
        }

        private bool tsHac_PesquisarClick(object sender)
        {
            if (cmbUnidade.SelectedIndex == -1 || cmbLocal.SelectedIndex == -1 || cmbSetor.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione Unidade/Local/Setor antes de pesquisar", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            Pesquisar();
            return false;
        }
        
        private bool tsHac_SalvarClick(object sender)
        {
            Salvar();
            return false;
        }

        private void cmbUnidade_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void cmbLocal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void cmbSetor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void btnEstoqueConsumo_Click(object sender, EventArgs e)
        {

            // FrmEstoqueConsumo frm = new FrmEstoqueConsumo( Convert.ToDecimal( cmbUnidade.SelectedValue.ToString()), Convert.ToDecimal( cmbLocal.SelectedValue.ToString()), Convert.ToDecimal( cmbSetor.SelectedValue.ToString()));
            // frm.ShowDialog();

            SetorEstoqueConsumoDTO dtoConsumo = new SetorEstoqueConsumoDTO();

            dtoConsumo = FrmAddSetorConsumo.SelecionarSetor();
            if (dtoConsumo != null)
            {
                dtoConsumo.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                dtoConsumo.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                dtoConsumo.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                MatMedSetorConfig.SetorEstoqueConsumoSalvar(dtoConsumo);
                dtgEstoqueConsumo.DataSource = gen.CarregaEstoqueConsumo(dtoConsumo);
            }

        }

        private void dtgEstoqueConsumo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgEstoqueConsumo.Columns[e.ColumnIndex].Name == "colDeletarConsumo")
            {
                if (MessageBox.Show("Deseja excluir esta unidade da lista ?",
                                     "Gestão de Materiais e Medicamentos",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SetorEstoqueConsumoDTO dto = new SetorEstoqueConsumoDTO();
                    dto.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                    dto.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                    dto.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                    dto.IdtFilial.Value = dtgEstoqueConsumo.Rows[e.RowIndex].Cells["colIdtFilialConsumo"].Value.ToString();
                    MatMedSetorConfig.SetorEstoqueConsumoExcluir(dto);
                    dtgEstoqueConsumo.DataSource = gen.CarregaEstoqueConsumo(dto);
                }
            }

        }

        private void lblCompartilhado_Click(object sender, EventArgs e)
        {
            if (dtbSetoresEstoqueCompartilhado.Rows.Count > 0)
            {
                SetorEstoqueConsumoDTO dto;
                StringBuilder sbSetor = new StringBuilder();
                //sbSetor.Append(string.Format("- {0} | {1} | {2} | {3} \n", "UNIDADE".PadRight(25, ' '), "LOCAL".PadRight(25, ' '), "SETOR".PadRight(25, ' '), "FILIAL".PadRight(25, ' ')));
                foreach (DataRow row in dtbSetoresEstoqueCompartilhado.Rows)
                {
                    dto = (SetorEstoqueConsumoDTO)row;
                    sbSetor.Append(string.Format("->  {0} | {1} | {2} | {3} \n", dto.DsUnidadeConsumo.Value.ToString().PadRight(25, ' '),
                                                                                 dto.DsLocalConsumo.Value.ToString().PadRight(25, ' '),
                                                                                 dto.DsSetorConsumo.Value.ToString().PadRight(25, ' '),
                                                                                 dto.DsFilial.Value.ToString().PadRight(25, ' ')));
                }
                MessageBox.Show(sbSetor.ToString(), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void chkIgnoraAlta_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIgnoraAlta.Checked)
            {
                txtIgnoraAltaAte.Enabled = true;
            }
            else
            {
                txtIgnoraAltaAte.Enabled = false;
                txtIgnoraAltaAte.Text = string.Empty;
            }
        }

        private void chkControlaConsPac_Click(object sender, EventArgs e)
        {
            if (chkControlaConsPac.Checked)            
                grbControlaConsumoPac.Visible = true;           
            else
                grbControlaConsumoPac.Visible = false;            
        }

        private void chkCE_Click(object sender, EventArgs e)
        {
            chkCE.Checked = !chkCE.Checked;
            CarregarCarrEmergPai();
            pnlCE.Visible = true;
        }

        private void btnGravarCE_Click(object sender, EventArgs e)
        {
            chkCE.Checked = false;
            chkCE.Text = "Carrinho Emergência";

            if (dtoSetorSelecionado != null)
            {
                if (cmbSetorCE.SelectedValue != null && cmbSetorCE.SelectedIndex > -1)
                {
                    dtoSetorSelecionado.CarrinhoEmergSetorPai.Value = cmbSetorCE.SelectedValue.ToString();
                    chkCE.Checked = true;
                    chkCE.Text += " do Setor " + cmbSetorCE.Text;
                }
                else
                    dtoSetorSelecionado.CarrinhoEmergSetorPai.Value = new Framework.DTO.TypeDecimal();
            }
            pnlCE.Visible = false;
        }

        private void btnLimparCE_Click(object sender, EventArgs e)
        {
            cmbUnidadeCE.SelectedIndex = -1;
        }

        private void btnCancelarCE_Click(object sender, EventArgs e)
        {
            pnlCE.Visible = false;
        }
        #endregion                
    }
}