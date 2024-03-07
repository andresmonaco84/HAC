using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Seguranca.Interface;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Seguranca.View;
using HospitalAnaCosta.SGS.Componentes;

namespace HospitalAnaCosta.SGS.Seguranca.Forms
{
    public partial class FrmCfgSeguranca : FrmBaseSeguranca
    {
        //private int _unidade = 244; // Santos
        // private int _modulo = 43; //GESTAO MATERIAIS

        public SegurancaDTO dtoSegurancaLocal = new SegurancaDTO();
        int LinhaAtual = 0;
        string TextoPesquisado;

        public FrmCfgSeguranca()
        {
            InitializeComponent();
        }

        public FrmCfgSeguranca(SegurancaDTO dto)
        {
            InitializeComponent();
            dtoSegurancaLocal = dto;
            this.Titulo = "Segurança SGS";
        }

        private bool ValidarDataExpiraSenha()
        {
            if (txtDataExpira.Text != string.Empty)
            {
                DateTime dt;
                if (!DateTime.TryParse(txtDataExpira.Text, out dt))
                {
                    MessageBox.Show("Data Expira Senha inválida !!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDataExpira.Focus();
                    return false;
                }
                if (DateTime.Parse(txtDataExpira.Text).Date < DateTime.Now.Date)
                {
                    MessageBox.Show("Data Expira Senha não pode ser menor que a data de hoje !!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDataExpira.Focus();
                    return false;
                }
            }
            return true;
        }

        private bool ValidarDataNascto()
        {
            if (txtDataNasc.Text != string.Empty)
            {
                DateTime dt;
                if (!DateTime.TryParse(txtDataNasc.Text, out dt))
                {
                    MessageBox.Show("Data  Nascto. inválida !!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDataNasc.Focus();
                    return false;
                }
                if (DateTime.Parse(txtDataNasc.Text).Date > DateTime.Now.Date)
                {
                    MessageBox.Show("Data  Nascto. não pode ser maior que a data de hoje !!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDataNasc.Focus();
                    return false;
                }
            }            
            return true;
        }

        private bool ValidarCPF(string str)
        {
            string novo = str.PadLeft(11, '0');
            return IsCpf(novo);
        }

        private bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        private void CarregaLstPerfil()
        {

            PerfilDataTable dtbPerfil = new PerfilDataTable();
            PerfilDTO DtoAssPerfil = new PerfilDTO();


            lstAssPerfil.DisplayMember = PerfilDTO.FieldNames.NmPerfil;
            lstAssPerfil.ValueMember = PerfilDTO.FieldNames.Idt;
            lstAssPerfil.DataSource = ListarPerfisNaoAssociados(DtoAssPerfil);

        }

        private PerfilDataTable ListarPerfisNaoAssociados(PerfilDTO dtoPerfil)
        {
            PerfilDataTable dtbPerfis = new PerfilDataTable();            
            DataRow[] perfilAssociado;
            dtoPerfil.IdtModulo.Value = cmbModulo.SelectedValue.ToString();
            dtoPerfil.IdtUsuario.Value = txtIdtUusario.Text;            
            dtbPerfis = Perfil.Sel(dtoPerfil);            

            foreach (DataRowView rowView in lstAssPerfUsuario.Items)
            {
                AssPerfilUsuarioDTO perfilUsuario = (AssPerfilUsuarioDTO)rowView.Row;
                
                perfilAssociado = dtbPerfis.Select(string.Format("{0} = {1}", PerfilDTO.FieldNames.Idt, perfilUsuario.IdtPerfil.Value));
                if ( perfilAssociado.Length > 0 )
                    dtbPerfis.Rows.Remove(perfilAssociado[0]); 
            }
            dtbPerfis.AcceptChanges();

            return dtbPerfis;
        }

        private void FrmCfgSeguranca_Load(object sender, EventArgs e)
        {            
            ConfiguraUnidadeDTG();
            CarregaCmbModulos();
            CarregaGridUsuario();
            DesabilitaSetor();
            DesabilitaUnidade();
        }

        /// <summary>
        /// Desabilita Objetos da Aba Setor
        /// </summary>
        private void DesabilitaSetor()
        {
            cmbLocal.Enabled = false;
            btnSetorPesquisar.Enabled = false;
            dtgSetor.Enabled = false;
        }

        /// <summary>
        /// Desabilita Objetos da Aba Unidade
        /// </summary>
        private void DesabilitaUnidade()
        {
            cmbUnidade.Enabled = false;
            btnAdicionarUnidade.Enabled = false;
            dtgUnidade.Enabled = false;
        }

        private void CarregaModulosAssPerFun()
        {
            // CARREGA MODULOS ASSOCIAÇÃO PERFIL FUNCIONALIDADE
            ModuloDTO DtoModulo = new ModuloDTO();
            ModuloDataTable DtbModulo = new ModuloDataTable();

            cmbModulo.ValueMember = ModuloDTO.FieldNames.Idt;
            cmbModulo.DisplayMember = ModuloDTO.FieldNames.NmModulo;
            //DtoModulo.IdtSistema.Value = cmbSisAssPerFun.SelectedValue.ToString();
            cmbModulo.DataSource = Modulo.Sel(DtoModulo);
            cmbModulo.SelectedIndex = -1;
        }

        private void ExcluirPerfilUsuario()
        {
            AssPerfilUsuarioDTO dtoAssPerfilUsuario = new AssPerfilUsuarioDTO();
            
            for (int i = 0; i < lstAssPerfUsuario.SelectedItems.Count; i++)
            {
                DataRowView selectedItem1 = (DataRowView)lstAssPerfUsuario.Items[this.lstAssPerfUsuario.SelectedIndices[i]];
                dtoAssPerfilUsuario = (AssPerfilUsuarioDTO)selectedItem1.Row;

                AssPerfilUsuario.Del(dtoAssPerfilUsuario);
            }

            if (dtoAssPerfilUsuario != null) this.CarregarPerfisUsuario();
        }

        /// <summary>
        /// Carrega Perfis que usuário tem acesso
        /// </summary>
        private void CarregarPerfisUsuario()
        {
            if (txtIdtUusario.Text != string.Empty && cmbModulo.SelectedValue != null)
            {
                // CARREGA PERFIS DO USUARIO SELECIONADO
                AssPerfilUsuarioDTO dtoPerfilUsuario = new AssPerfilUsuarioDTO();

                dtoPerfilUsuario.IdtUsuario.Value = Convert.ToDecimal( txtIdtUusario.Text );
                if (cmbModulo.SelectedValue != null )
                dtoPerfilUsuario.IdtModulo.Value = cmbModulo.SelectedValue.ToString();
                if (txtIdtUnidade.Text == string.Empty)
                {
                    MessageBox.Show("Selecione a unidade", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                else
                {
                    dtoPerfilUsuario.IdtUnidade.Value = Convert.ToDecimal(txtIdtUnidade.Text);
                }


                lstAssPerfUsuario.ValueMember = AssPerfilUsuarioDTO.FieldNames.IdtPerfil;
                lstAssPerfUsuario.DisplayMember = AssPerfilUsuarioDTO.FieldNames.NmPerfil;
                lstAssPerfUsuario.DataSource = AssPerfilUsuario.Sel(dtoPerfilUsuario);

                // RECARREGA LISTA DE PERFIL
                CarregaLstPerfil();
            }
        }

        private void lstAssUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CarregarPerfisUsuario();
        }
        
        private void btnAssociarPerfilUsuario_Click(object sender, EventArgs e)
        {
            // ASSOCIA PERFIL AO USUÁRIO
            AssPerfilUsuarioDTO DtoPerfilUsuario = new AssPerfilUsuarioDTO();
            PerfilDTO DtoPerfil = new PerfilDTO();
            DtoPerfilUsuario.IdtUsuario.Value = txtIdtUusario.Text;

            for (int i = 0; i < lstAssPerfil.SelectedItems.Count; i++)
            {
                DataRowView selectedItem1 = (DataRowView)lstAssPerfil.Items[this.lstAssPerfil.SelectedIndices[i]];
                DtoPerfil = (PerfilDTO)selectedItem1.Row;
                DtoPerfilUsuario.IdtUsuario.Value = txtIdtUusario.Text;
                DtoPerfilUsuario.IdtPerfil.Value = DtoPerfil.Idt.Value;

                /***********************************
                 * Início - Incluído por Alexandre *
                 ***********************************/

                // DtoPerfilUsuario.IdtUnidade.Value = _unidade;
                DtoPerfilUsuario.IdtModulo.Value = cmbModulo.SelectedValue.ToString();

                /***********************************
                 * Fim - Incluído por Alexandre    *
                 ***********************************/
                DtoPerfilUsuario.IdtUnidade.Value = Convert.ToDecimal(txtIdtUnidade.Text);
                AssPerfilUsuario.Ins(DtoPerfilUsuario);
            }

            //RECARREGA USUÁRIOS            
            this.CarregarPerfisUsuario();
        }

        private void cmbAssSisUsuPerfil_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // CARREGA LISTA DE PERFIL NA ABA 
            //CarregaLstPerfil();
            CarregarPerfisUsuario();
        }

        private void btnExcluirPerfilAssociado_Click(object sender, EventArgs e)
        {
            this.ExcluirPerfilUsuario();
        }

        #region ASSOCIAÇÃO PERFIL FUNCIONALIDADE

        private void lstPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Seleção do Perfil para associar com a funcionalidade
            AssPerfilFuncionalidadeDataTable dtbPerfilFun = new AssPerfilFuncionalidadeDataTable();
            AssPerfilFuncionalidadeDTO dtoPerfilFun = new AssPerfilFuncionalidadeDTO();

            //txtMensagem.Text = "ASSOCIADAS";

            lstAssPerFun.ValueMember = AssPerfilFuncionalidadeDTO.FieldNames.IdtFuncionalidade;
            lstAssPerFun.DisplayMember = AssPerfilFuncionalidadeDTO.FieldNames.NmFuncionalidade;
            dtoPerfilFun.IdtPerfil.Value = lstPerfil.SelectedValue.ToString();
            dtoPerfilFun.IdtModulo.Value = cmbModulo.SelectedValue.ToString();

            lstAssPerFun.DataSource = AssPerfilFuncionalidade.Sel(dtoPerfilFun);

            cmbAssModPerFun_SelectionChangeCommitted((object)sender, (EventArgs)e);

        }

        private void cmbAssModPerFun_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // CARREGA FUNCIONALIDADES ASSOCIADO AO PERFIL SELECIONADO
            FuncionalidadeDataTable dtbFuncionalidade = new FuncionalidadeDataTable();
            FuncionalidadeDTO dtoFuncionalidade = new FuncionalidadeDTO();

            lstFuncionalidade.ValueMember = FuncionalidadeDTO.FieldNames.Idt;
            lstFuncionalidade.DisplayMember = FuncionalidadeDTO.FieldNames.NmFuncionalidade;
            //funcionalidade
            // modulo
            if (cmbModulo.SelectedValue != null) dtoFuncionalidade.IdtModulo.Value = cmbModulo.SelectedValue.ToString();
            if (lstPerfil.SelectedValue != null) dtoFuncionalidade.IdtPerfil.Value = lstPerfil.SelectedValue.ToString();
            dtoFuncionalidade.FiltraAssociados.Value = (int)FuncionalidadeDTO.FiltraFuncionalidade.FUNCIONALIDADE_NAO_ASSOCIADA;

            lstFuncionalidade.DataSource = Funcionalidade.Sel(dtoFuncionalidade);

        }

        private void btnAssociar_Click(object sender, EventArgs e)
        {
            AssPerfilFuncionalidadeDataTable dtbPerfilFunc = new AssPerfilFuncionalidadeDataTable();
            AssPerfilFuncionalidadeDTO DtoPerfilFunc = new AssPerfilFuncionalidadeDTO();
            FuncionalidadeDTO DtoFuncionalidade = new FuncionalidadeDTO();

            for (int i = 0; i < lstFuncionalidade.SelectedItems.Count; i++)
            {
                DataRowView selectedItem1 = (DataRowView)lstFuncionalidade.Items[this.lstFuncionalidade.SelectedIndices[i]];
                DtoFuncionalidade = (FuncionalidadeDTO)selectedItem1.Row;
                // converte para AssPerFunc
                DtoPerfilFunc.IdtFuncionalidade.Value = DtoFuncionalidade.Idt.Value;
                DtoPerfilFunc.IdtPerfil.Value = lstPerfil.SelectedValue.ToString();
                DtoPerfilFunc.IdtModulo.Value = cmbModulo.SelectedValue.ToString();
                AssPerfilFuncionalidade.Ins(DtoPerfilFunc);
            }
            lstPerfil_SelectedIndexChanged((object)sender, (EventArgs)e);
            cmbAssModPerFun_SelectionChangeCommitted((object)sender, (EventArgs)e);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            AssPerfilFuncionalidadeDataTable dtbPerfilFunc = new AssPerfilFuncionalidadeDataTable();
            AssPerfilFuncionalidadeDTO DtoPerfilFunc = new AssPerfilFuncionalidadeDTO();
            FuncionalidadeDTO DtoFuncionalidade = new FuncionalidadeDTO();

            for (int i = 0; i < lstAssPerFun.SelectedItems.Count; i++)
            {
                DataRowView selectedItem1 = (DataRowView)lstAssPerFun.Items[this.lstAssPerFun.SelectedIndices[i]];
                DtoPerfilFunc = (AssPerfilFuncionalidadeDTO)selectedItem1.Row;
                AssPerfilFuncionalidade.Del(DtoPerfilFunc);
            }
            lstPerfil_SelectedIndexChanged((object)sender, (EventArgs)e);
            cmbAssModPerFun_SelectionChangeCommitted((object)sender, (EventArgs)e);
        }

        /// <summary>
        /// Lista TODOS os perfis associados a funcionalidade selecionada
        /// </summary>
        private void CarregaLstPerfilFuncionalidade()
        {
            PerfilDataTable dtbPerfil = new PerfilDataTable();
            PerfilDTO dtoPerfil = new PerfilDTO();

            if (cmbModulo.SelectedValue != null)
            {
                dtoPerfil.IdtModulo.Value = cmbModulo.SelectedValue.ToString();

                // CARREGA COMBO COM TODOS OS PERFIS DO MODULO
                lstPerfil.DisplayMember = PerfilDTO.FieldNames.NmPerfil;
                lstPerfil.ValueMember = PerfilDTO.FieldNames.Idt;
                lstPerfil.DataSource = Perfil.Sel(dtoPerfil);
                //lstPerfil.DataSource = new DataView(Perfil.Sel(dtoPerfil), string.Empty, PerfilDTO.FieldNames.NmPerfil,DataViewRowState.CurrentRows);
            }
        }

        #endregion

        #region MODULO

        private void CarregaCmbModulos()
        {
            ModuloDTO DtoModulo = new ModuloDTO();
            ModuloDataTable DtbModulo = new ModuloDataTable();
            cmbModulo.ValueMember = ModuloDTO.FieldNames.Idt;
            cmbModulo.DisplayMember = ModuloDTO.FieldNames.NmModulo;
            cmbModulo.DataSource = Modulo.Sel(DtoModulo);
            cmbModulo.SelectedIndex = -1;
            cmbModulo.Text = "<Selecione>";

        }

        private void cmbModulo_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            // CARREGA FUNCIONALIDADES DO MODULO
            CarregaGridFuncionalidade();
            CarregaGridPerfil();
            CarregaLstPerfilFuncionalidade();
            btnNovaFuncionalidade.Enabled = true;

            // CARREGA PERFIL ASSOCIADO AO USUARIO E AO MODULO
            if (txtIdtUusario.Text != string.Empty)
            {
                CarregarPerfisUsuario();
            }
        }

        #endregion

        #region USUÁRIO

        private void btnNovoUsuario_Click(object sender, EventArgs e)
        {
            StatusUsuario("N");
        }

        private void btnSalvarUsuario_Click(object sender, EventArgs e)
        {
            UsuarioDataTable dtbUsuario = new UsuarioDataTable();
            UsuarioDTO dtoUsuario = new UsuarioDTO();
            // bool inserirULSU = false; //Unidade Local Setor Usuario (só insere quando é inserção de usuario)

            if (txtMatricula.Text == string.Empty)
            {
                MessageBox.Show("Matricula não pode estar em Branco !!", "Segurança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMatricula.Focus();
                return;
            }

            if (txtNmUsuario.Text == string.Empty)
            {
                MessageBox.Show("Nome não pode estar em Branco !!", "Segurança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNmUsuario.Focus();                
                return;
            }

            string strCPF = txtCPF.Text.Replace(",", "").Replace("-", "").Replace("_", "").Replace(".", "").Trim();
            if (!string.IsNullOrEmpty(strCPF))
            {
                if (!ValidarCPF(strCPF))
                {
                    MessageBox.Show("CPF inválido !!", "Segurança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCPF.Focus();
                    txtCPF.SelectAll();
                    return;
                }
                if (decimal.Parse(strCPF) < 10)
                {
                    MessageBox.Show("CPF inválido !!", "Segurança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCPF.Focus();
                    txtCPF.SelectAll();
                    return;
                }
            }

            if (!ValidarDataNascto()) return;
            if (!ValidarDataExpiraSenha()) return;

            this.Cursor = Cursors.WaitCursor;

            dtoUsuario.Idt.Value = txtIdtUusario.Text;
            dtoUsuario.Login.Value = txtLogin.Text;
            dtoUsuario.Matricula.Value = txtMatricula.Text;
            dtoUsuario.NmUsuario.Value = txtNmUsuario.Text;
            dtoUsuario.Email.Value = txtEmail.Text;
            dtoUsuario.Status.Value = (ChkAtivo.Checked ? "A" : "I");
            dtoUsuario.FlResponsavelPerfilOk.Value = "N";
            dtoUsuario.TpInterExter.Value = "I";

            dtoUsuario.FlTrocarSenha.Value = (chkTrocarSenha.Checked ? "S" : "N"); //"N";
            dtoUsuario.FlSenhaNaoExpira.Value = (chkSenhaNuncaExpira.Checked ? "S" : "N"); //"N";
            if (!string.IsNullOrEmpty(txtDataExpira.Text)) dtoUsuario.DtExpiraSenha.Value = txtDataExpira.Text;

            if (!string.IsNullOrEmpty(strCPF)) dtoUsuario.CPF.Value = strCPF;
            if (!string.IsNullOrEmpty(txtDataNasc.Text)) dtoUsuario.DataNascimento.Value = txtDataNasc.Text;

            // if (dtoUsuario.Idt.Value.IsNull) inserirULSU = true;
            try
            {
                dtoUsuario = Usuario.Gravar(dtoUsuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Erro ao salvar usuário - {0}", ex), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cursor = Cursors.Default;
                return;
            }

            txtIdtUusario.Text = dtoUsuario.Idt.Value;
            StatusUsuario("S");

            CarregaGridUsuario();

            this.Cursor = Cursors.Default;

            /*
            if (inserirULSU)
            {
                UsuarioUnidadeDTO dtoUsUnid = new UsuarioUnidadeDTO();

                // dtoUsUnid.IdtUnidade.Value = _unidade;
                dtoUsUnid.IdtUsuario.Value = DtoUsuario.Idt.Value;

                UsuarioUnidade.Ins(dtoUsUnid);

                UnidadeLocalSetorUsuarioDTO dtoULS = new UnidadeLocalSetorUsuarioDTO();

                dtoULS.IdtUsuarioAtualizadoPor.Value = 1;
                dtoULS.IdtUsuario.Value = DtoUsuario.Idt.Value;
                // dtoULS.IdtUnidade.Value = _unidade;
                // dtoULS.IdtLocalAtendimento.Value = 33; //ADM.
                // dtoULS.IdtSetor.Value = 29; //ALMOXARIFADO
                // dtoULS.FlagStatus.Value = "A";

                UnidadeLocalSetorUsuario.Ins(dtoULS);
            }                
            */
        }

        private void btnCancelarUsuario_Click(object sender, EventArgs e)
        {
            StatusUsuario("C");
        }

        private void dtgUsuario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // CARREGA USUÁRIO SELECIONADO NO GRID
            // tsSeguranca.Controla(Evento.eNovo);
            txtIdtUusario.Text = dtgUsuario.Rows[e.RowIndex].Cells["colIdtUusario"].Value.ToString();
            txtNmUsuario.Text = dtgUsuario.Rows[e.RowIndex].Cells["colNmUsuario"].Value.ToString();
            txtLogin.Text = dtgUsuario.Rows[e.RowIndex].Cells["colLogin"].Value.ToString();
            txtMatricula.Text = dtgUsuario.Rows[e.RowIndex].Cells["colMatricula"].Value.ToString();
            txtEmail.Text = dtgUsuario.Rows[e.RowIndex].Cells["colEmail"].Value.ToString();            
            txtCPF.Text = dtgUsuario.Rows[e.RowIndex].Cells[colCPF.Name].Value.ToString();
            if (!string.IsNullOrEmpty(dtgUsuario.Rows[e.RowIndex].Cells[colDataNasc.Name].Value.ToString()))
                txtDataNasc.Text = DateTime.Parse(dtgUsuario.Rows[e.RowIndex].Cells[colDataNasc.Name].Value.ToString()).ToString("dd/MM/yyyy");
            else
                txtDataNasc.Text = string.Empty;

            if (dtgUsuario.Rows[e.RowIndex].Cells["colAtivo"].Value.ToString() == "A")
                ChkAtivo.Checked = true;
            else
                ChkAtivo.Checked = false;

            if (dtgUsuario.Rows[e.RowIndex].Cells[colTrocarSenha.Name].Value.ToString() == "S")
                chkTrocarSenha.Checked = true;
            else
                chkTrocarSenha.Checked = false;

            if (dtgUsuario.Rows[e.RowIndex].Cells[colSenhaNaoExpira.Name].Value.ToString() == "S")
                chkSenhaNuncaExpira.Checked = true;
            else
                chkSenhaNuncaExpira.Checked = false;

            if (!string.IsNullOrEmpty(dtgUsuario.Rows[e.RowIndex].Cells[colDataExpiraSenha.Name].Value.ToString()))
                txtDataExpira.Text = DateTime.Parse(dtgUsuario.Rows[e.RowIndex].Cells[colDataExpiraSenha.Name].Value.ToString()).ToString("dd/MM/yyyy");
            else
                txtDataExpira.Text = string.Empty;

            StatusUsuario("E");

            // CARREGA PERFIL/UNIDADES/SETORES ASSOCIADAS AO USUARIO E AO MODULO
            CarregaUnidadesUsuario();
            
            if (cmbModulo.SelectedIndex != -1)
                CarregarPerfisUsuario();

            chkSelTodos.Visible = chkSelTodos.Checked = false;
        }

        private void CarregaGridUsuario()
        {
            this.Cursor = Cursors.WaitCursor;
            UsuarioDataTable dtbUsuario = new UsuarioDataTable();
            UsuarioDTO DtoUsuario = new UsuarioDTO();
            dtgUsuario.AutoGenerateColumns = false;
            dtgUsuario.Columns["colIdtUusario"].DataPropertyName = UsuarioDTO.FieldNames.Idt;
            dtgUsuario.Columns["colNmUsuario"].DataPropertyName = UsuarioDTO.FieldNames.NmUsuario;
            dtgUsuario.Columns["colLogin"].DataPropertyName = UsuarioDTO.FieldNames.Login;
            dtgUsuario.Columns["colMatricula"].DataPropertyName = UsuarioDTO.FieldNames.Matricula;
            dtgUsuario.Columns["colAtivo"].DataPropertyName = UsuarioDTO.FieldNames.Status;
            dtgUsuario.Columns["colEmail"].DataPropertyName = UsuarioDTO.FieldNames.Email;
            dtgUsuario.Columns[colDataNasc.Name].DataPropertyName = UsuarioDTO.FieldNames.DataNascimento;
            dtgUsuario.Columns[colCPF.Name].DataPropertyName = UsuarioDTO.FieldNames.CPF;
            dtgUsuario.Columns[colTrocarSenha.Name].DataPropertyName = UsuarioDTO.FieldNames.FlTrocarSenha;
            dtgUsuario.Columns[colSenhaNaoExpira.Name].DataPropertyName = UsuarioDTO.FieldNames.FlSenhaNaoExpira;
            dtgUsuario.Columns[colDataExpiraSenha.Name].DataPropertyName = UsuarioDTO.FieldNames.DtExpiraSenha;
            dtgUsuario.DataSource = Usuario.Sel(DtoUsuario);
            this.Cursor = Cursors.Default;
            // StatusUsuario("C");
            // tsSeguranca.Controla(Evento.eInicio);
            // base.ModoTela = ModoEdicao.Inicio;            
        }

        private void StatusUsuario(string modo)
        {
            if (modo == "N")
            {
                txtEmail.Text = string.Empty;
                txtEmail.Enabled = true;
                txtIdtUusario.Text = string.Empty;                
                txtMatricula.Text = string.Empty;
                txtMatricula.Enabled = true;
                txtNmUsuario.Text = string.Empty;
                txtNmUsuario.Enabled = true;
                txtLogin.Text = string.Empty;
                txtLogin.Enabled = true;
                txtDsUnidade.Text = string.Empty;
                txtIdtUnidade.Text = string.Empty;
                ChkAtivo.Checked = true;
                ChkAtivo.Enabled = true;
                txtCPF.Enabled = txtDataNasc.Enabled = true;
                txtCPF.Text = txtDataNasc.Text = string.Empty;
                chkSenhaNuncaExpira.Enabled = chkTrocarSenha.Enabled = txtDataExpira.Enabled = true;
                chkTrocarSenha.Checked = true; chkSenhaNuncaExpira.Checked = false;
                txtDataExpira.Text = string.Empty;

                btnNovoUsuario.Enabled = false;
                btnSalvarUsuario.Enabled = true;
                btnAdicionarUnidade.Enabled = false;
                btnCancelarUsuario.Enabled = true;
                cmbUnidade.Enabled = false;

                cmbLocal.Enabled = false;
                cmbUnidade.Enabled = false;
                btnSetorPesquisar.Enabled = false;
                dtgSetor.Enabled = false;


                dtgUnidade.DataSource = null;
                dtgSetor.DataSource = null;

                txtMatricula.Focus();
            }
            else if (modo == "S")
            {
                // txtEmail.Text = string.Empty;
                txtEmail.Enabled = false;
                // txtIdtUusario.Text = string.Empty;
                // txtMatricula.Text = string.Empty;
                txtMatricula.Enabled = false;
                // txtNmUsuario.Text = string.Empty;
                txtNmUsuario.Enabled = false;
                // txtLogin.Text = string.Empty;
                txtLogin.Enabled = false;
                // ChkAtivo.Checked = false;
                ChkAtivo.Enabled = false;
                cmbUnidade.Enabled = true;
                btnAdicionarUnidade.Enabled = true;
                dtgUnidade.Enabled = true;
                btnSetorPesquisar.Enabled = false;
                dtgSetor.Enabled = false;

                txtCPF.Enabled = txtDataNasc.Enabled = false;
                //txtCPF.Text = txtDataNasc.Text = string.Empty;
                chkSenhaNuncaExpira.Enabled = chkTrocarSenha.Enabled = txtDataExpira.Enabled = false;

                cmbLocal.Enabled = false;
                try
                {
                    dtgUnidade.Rows.Clear();
                    dtgSetor.Rows.Clear();
                }catch
                {
                }

                btnNovoUsuario.Enabled = true;
                btnSalvarUsuario.Enabled = false;
                btnCancelarUsuario.Enabled = false;
            }
            else if (modo == "C")
            {
                txtEmail.Text = string.Empty;
                txtEmail.Enabled = false;
                txtIdtUusario.Text = string.Empty;
                txtMatricula.Text = string.Empty;
                txtMatricula.Enabled = false;
                txtNmUsuario.Text = string.Empty;
                txtNmUsuario.Enabled = false;
                txtLogin.Text = string.Empty;
                txtLogin.Enabled = false;
                txtDsUnidade.Text = string.Empty;
                txtIdtUnidade.Text = string.Empty;

                txtCPF.Enabled = txtDataNasc.Enabled = false;
                txtCPF.Text = txtDataNasc.Text = string.Empty;
                chkSenhaNuncaExpira.Enabled = chkTrocarSenha.Enabled = txtDataExpira.Enabled = false;
                chkTrocarSenha.Checked = chkSenhaNuncaExpira.Checked = false;
                txtDataExpira.Text = string.Empty;

                ChkAtivo.Checked = false;
                ChkAtivo.Enabled = false;
                cmbUnidade.Enabled = false;
                dtgUnidade.Enabled = true;


                cmbLocal.Enabled = false;
                cmbUnidade.Enabled = false;
                btnAdicionarUnidade.Enabled = false;
                btnSetorPesquisar.Enabled = false;
                dtgSetor.Enabled = false;

                dtgUnidade.DataSource = null;
                dtgSetor.DataSource = null;


                btnNovoUsuario.Enabled = true;
                btnSalvarUsuario.Enabled = false;
                btnCancelarUsuario.Enabled = false;
                btnSetorPesquisar.Enabled = false;
            }
            else if (modo == "E")
            {
                txtEmail.Enabled = true;
                txtMatricula.Enabled = true;
                txtNmUsuario.Enabled = true;                
                txtDsUnidade.Text = string.Empty;
                txtIdtUnidade.Text = string.Empty;
                txtCPF.Enabled = txtDataNasc.Enabled = true;
                chkSenhaNuncaExpira.Enabled = chkTrocarSenha.Enabled = txtDataExpira.Enabled = true;

                txtLogin.Enabled = true;
                ChkAtivo.Enabled = true;
                cmbUnidade.Enabled = true;
                btnAdicionarUnidade.Enabled = true;
                cmbUnidade.Carregaunidade();
                dtgUnidade.Enabled = true;

                dtgUnidade.DataSource = null;
                dtgSetor.DataSource = null;


                btnNovoUsuario.Enabled = false;
                btnSalvarUsuario.Enabled = true;
                btnCancelarUsuario.Enabled = true;
            }

        }

        private void btnSenhaPadrao_Click(object sender, EventArgs e)
        {
            if (txtIdtUusario.Text != string.Empty)
            {
                if (MessageBox.Show("Deseja realmente inicializar a senha deste usuário ?",
                                     "Gestão de Materiais e Medicamentos",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UsuarioDTO dtoUsuario = new UsuarioDTO();
                    dtoUsuario.Idt.Value = txtIdtUusario.Text;
                    Usuario.AtribuirSenhaPadrao(dtoUsuario);
                    MessageBox.Show("Processo realizado com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #endregion

        #region PERFIL

        private void SalvarPerfil()
        {
            PerfilDTO dtoPerfil = new PerfilDTO();

            dtoPerfil.NmPerfil.Value = txtNmPerfil.Text;
            if (txtIdtPerfil.Text != string.Empty)
                dtoPerfil.Idt.Value = Convert.ToDecimal( txtIdtPerfil.Text );
            dtoPerfil.FlStatus.Value = "A";
            dtoPerfil.IdtUsuario.Value = 1; // usuario padrao
            dtoPerfil.IdtModulo.Value = cmbModulo.SelectedValue.ToString();
            dtoPerfil = Perfil.Gravar(dtoPerfil);
            txtIdtPerfil.Text = dtoPerfil.Idt.Value;
            StatusPerfil("S");
            CarregaGridPerfil();
        }

        private void dtgPerfil_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtIdtPerfil.Text = dtgPerfil.Rows[e.RowIndex].Cells["colIdtPerfil"].Value.ToString();
                txtNmPerfil.Text = dtgPerfil.Rows[e.RowIndex].Cells["ColNmPerfil"].Value.ToString();
                StatusPerfil("E");
            }
        }

        private void CarregaGridPerfil()
        {
            PerfilDataTable dtbPerfil = new PerfilDataTable();
            PerfilDTO dtoPerfil = new PerfilDTO();
            dtgPerfil.AutoGenerateColumns = false;
            dtgPerfil.Columns["colIdtPerfil"].DataPropertyName = PerfilDTO.FieldNames.Idt;
            dtgPerfil.Columns["ColNmPerfil"].DataPropertyName = PerfilDTO.FieldNames.NmPerfil;
            dtgPerfil.Columns["ColIdtModulo"].DataPropertyName = PerfilDTO.FieldNames.IdtModulo;

            if (cmbModulo.SelectedValue != null)
            {
                // dtoPerfil.FlStatus.Value = "A";
                dtoPerfil.IdtModulo.Value = cmbModulo.SelectedValue.ToString();
                dtgPerfil.DataSource = Perfil.Sel(dtoPerfil);
                StatusPerfil("C");
            }

        }

        private void btnNovoPerfil_Click(object sender, EventArgs e)
        {
            StatusPerfil("N");
        }

        private void btnSalvarPerfil_Click(object sender, EventArgs e)
        {
            SalvarPerfil();
        }

        private void btnCancelarPerfil_Click(object sender, EventArgs e)
        {
            StatusPerfil("C");
        }

        private void StatusPerfil(string modo)
        {
            if (modo == "N")
            {
                txtIdtPerfil.Text = string.Empty;
                txtNmPerfil.Enabled = true;
                txtNmPerfil.Text = string.Empty;
                txtNmPerfil.Focus();

                btnSalvarPerfil.Enabled = true;
                btnNovoPerfil.Enabled = false;
                btnCancelarPerfil.Enabled = true;
            }
            else if(modo == "S")
            {
                txtIdtPerfil.Text = string.Empty;
                txtNmPerfil.Enabled = false;
                txtNmPerfil.Text = string.Empty;
                txtNmPerfil.Focus();

                btnSalvarPerfil.Enabled = false;
                btnNovoPerfil.Enabled = true;
                btnCancelarPerfil.Enabled = false;
            }
            else if(modo == "C")
            {
                txtIdtPerfil.Text = string.Empty;
                txtNmPerfil.Enabled = false;
                txtNmPerfil.Text = string.Empty;
                txtNmPerfil.Focus();

                btnSalvarPerfil.Enabled = false;
                btnNovoPerfil.Enabled = true;
                btnCancelarPerfil.Enabled = false;
            }
            else if (modo == "E")
            {
                txtNmPerfil.Enabled = true;
                txtNmPerfil.Focus();

                btnSalvarPerfil.Enabled = true;
                btnNovoPerfil.Enabled = false;
                btnCancelarPerfil.Enabled = true;
            }
        }

        #endregion

        #region FUNCIONALIDADE

        private void btnNovaFuncionalidade_Click(object sender, EventArgs e)
        {
            StatusFuncionalidade("N");
        }

        private void btnSalvarFuncionalidade_Click(object sender, EventArgs e)
        {
            FuncionalidadeDTO DtoFuncionalidade = new FuncionalidadeDTO();

            DtoFuncionalidade.Idt.Value = txtIdtFuncionalidade.Text;
            if (cmbFuncionalidadePai.SelectedValue != null) DtoFuncionalidade.IdtFuncionalidadePai.Value = cmbFuncionalidadePai.SelectedValue.ToString();
            DtoFuncionalidade.IdtModulo.Value = cmbModulo.SelectedValue.ToString();
            DtoFuncionalidade.NmFuncionalidade.Value = txtNomeFuncionalidade.Text;
            DtoFuncionalidade.NmPagina.Value = txtObjeto.Text;
            DtoFuncionalidade.FlItemMenu.Value = chkMenu.Checked ? "S" : "N";
            //
            DtoFuncionalidade = Funcionalidade.Gravar(DtoFuncionalidade);
            txtIdtFuncionalidade.Text = DtoFuncionalidade.Idt.Value.ToString();
            StatusFuncionalidade("S");
            CarregaCmbFuncionalidadePai();
            CarregaGridFuncionalidade();

        }

        private void dtgListaFuncionalidade_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdtFuncionalidade.Text = dtgListaFuncionalidade.Rows[e.RowIndex].Cells["colIdt"].Value.ToString();
            txtNomeFuncionalidade.Text = dtgListaFuncionalidade.Rows[e.RowIndex].Cells["colNmFuncionalidade"].Value.ToString();
            txtObjeto.Text = dtgListaFuncionalidade.Rows[e.RowIndex].Cells["colNmPagina"].Value.ToString();
            chkMenu.Checked = (dtgListaFuncionalidade.Rows[e.RowIndex].Cells["colMenu"].Value.ToString() == "S" ? true : false);
            CarregaCmbFuncionalidadePai();
            cmbFuncionalidadePai.SelectedValue = dtgListaFuncionalidade.Rows[e.RowIndex].Cells["colFuncionalidadePai"].Value;
            StatusFuncionalidade("E");

        }

        private void btnCancelarFuncionalidade_Click(object sender, EventArgs e)
        {
            StatusFuncionalidade("C");
        }


        private void CarregaCmbFuncionalidadePai()
        {
            // CARREGA FUNCIONALIDADE PAI DA ABA FUNCIONALIDADE
            FuncionalidadeDTO DtoFuncionalidade = new FuncionalidadeDTO();
            FuncionalidadeDataTable dtbFuncionalidade = new FuncionalidadeDataTable();
            cmbFuncionalidadePai.ValueMember = FuncionalidadeDTO.FieldNames.Idt;
            cmbFuncionalidadePai.DisplayMember = FuncionalidadeDTO.FieldNames.NmFuncionalidade;

            DtoFuncionalidade.IdtModulo.Value = cmbModulo.SelectedValue.ToString();
            DtoFuncionalidade.FiltraAssociados.Value = (int)FuncionalidadeDTO.FiltraFuncionalidade.TODAS_FUNCIONALIDADES;
            DtoFuncionalidade.FiltraAssociados.Value = -1; // funcionalidades pai
            cmbFuncionalidadePai.DataSource = Funcionalidade.Sel(DtoFuncionalidade);
            cmbFuncionalidadePai.Text = "";
            cmbFuncionalidadePai.SelectedIndex = -1;
        }

        private void StatusFuncionalidade(string modo)
        {

            if (modo == "N")
            {
                btnSalvarFuncionalidade.Enabled = true;
                btnCancelarFuncionalidade.Enabled = true;

                CarregaCmbFuncionalidadePai();
                // dtgListaFuncionalidade.Enabled = false;
                txtNomeFuncionalidade.Enabled = true;
                txtIdtFuncionalidade.Text = string.Empty;

                cmbFuncionalidadePai.Enabled = true;
                cmbFuncionalidadePai.SelectedIndex = -1;

                txtObjeto.Enabled = true;
                txtObjeto.Text = string.Empty;

                chkMenu.Enabled = true;
                chkMenu.Checked = false;
                txtNomeFuncionalidade.Focus();
            }
            else if (modo == "C")
            {
                // dtgListaFuncionalidade.Enabled = false;
                txtNomeFuncionalidade.Enabled = false;
                txtNomeFuncionalidade.Text = string.Empty;

                txtIdtFuncionalidade.Text = string.Empty;

                txtObjeto.Text = string.Empty;
                txtObjeto.Enabled = false;

                cmbFuncionalidadePai.SelectedIndex = -1;
                cmbFuncionalidadePai.Enabled = false;

                chkMenu.Enabled = true;
                chkMenu.Checked = false;

                btnSalvarFuncionalidade.Enabled = false;
                btnCancelarFuncionalidade.Enabled = false;
                btnNovaFuncionalidade.Enabled = true;
            }
            else if (modo == "S")
            {
                btnSalvarFuncionalidade.Enabled = false;
                btnCancelarFuncionalidade.Enabled = false;
                btnNovaFuncionalidade.Enabled = true;

                txtNomeFuncionalidade.Enabled = false;
                txtNomeFuncionalidade.Text = string.Empty;

                txtObjeto.Text = string.Empty;
                txtObjeto.Enabled = false;

                cmbFuncionalidadePai.Enabled = false;
                cmbFuncionalidadePai.SelectedIndex = -1;

                chkMenu.Enabled = false;
                chkMenu.Checked = false;
            }
            else if (modo == "E")
            {
                // dtgListaFuncionalidade.Enabled = false;
                txtNomeFuncionalidade.Enabled = true;
                cmbFuncionalidadePai.Enabled = true;
                txtObjeto.Enabled = true;
                chkMenu.Enabled = true;

                btnSalvarFuncionalidade.Enabled = true;
                btnCancelarFuncionalidade.Enabled = true;
                btnNovaFuncionalidade.Enabled = false;

            }


        }

        private void CarregaGridFuncionalidade()
        {
            if (cmbModulo.SelectedValue != null)
            {
                FuncionalidadeDataTable DtbFuncionalidade = new FuncionalidadeDataTable();
                FuncionalidadeDTO DtoFuncionalidade = new FuncionalidadeDTO();
                dtgListaFuncionalidade.AutoGenerateColumns = false;
                dtgListaFuncionalidade.Columns["colIdt"].DataPropertyName = FuncionalidadeDTO.FieldNames.Idt;
                dtgListaFuncionalidade.Columns["colFuncionalidadePai"].DataPropertyName = FuncionalidadeDTO.FieldNames.IdtFuncionalidadePai;
                dtgListaFuncionalidade.Columns["colMenu"].DataPropertyName = FuncionalidadeDTO.FieldNames.FlItemMenu;
                dtgListaFuncionalidade.Columns["colNmFuncionalidade"].DataPropertyName = FuncionalidadeDTO.FieldNames.NmFuncionalidade;
                dtgListaFuncionalidade.Columns["colNmPagina"].DataPropertyName = FuncionalidadeDTO.FieldNames.NmPagina;

                DtoFuncionalidade.IdtModulo.Value = cmbModulo.SelectedValue.ToString();
                DtoFuncionalidade.FiltraAssociados.Value = (int)FuncionalidadeDTO.FiltraFuncionalidade.TODAS_FUNCIONALIDADES;
                dtgListaFuncionalidade.DataSource = Funcionalidade.Sel(DtoFuncionalidade);
            }
        }


        #endregion

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            PesquisaGrid();
        }

        private void PesquisaGrid()
        {
            string Texto;// 
            Boolean bExiste = false;

            if (txtPesquisa.Text != string.Empty)
            {
                if (TextoPesquisado != txtPesquisa.Text)
                {
                    // MUDOU TEXTO RECOMEÇA PESQUISA
                    LinhaAtual = 0;
                    TextoPesquisado = txtPesquisa.Text;
                }
                dtgUsuario.ClearSelection();
                int posiciona;
                for (int i = LinhaAtual; i < dtgUsuario.Rows.Count; i++)
                {
                    Texto = dtgUsuario.Rows[i].Cells["colNmUsuario"].Value.ToString();
                    
                    if (Texto.IndexOf(txtPesquisa.Text) != -1)
                    {
                        if (dtgUsuario.Rows[i].Visible)
                        {
                            if (i != LinhaAtual)
                            {
                                dtgUsuario.Rows[i].Selected = true;
                                // CM.Position = i;
                                if (!dtgUsuario.Rows[i].Displayed)
                                {
                                    posiciona = i - 10;
                                    posiciona = (posiciona < 0 ? 0 : posiciona);
                                    // procura primeira linha visivel
                                    for (int x = 0; x < 9; x++)
                                    {
                                        if (!dtgUsuario.Rows[posiciona].Visible)
                                        {
                                            posiciona++;
                                            if (posiciona == i)
                                                // ela é a única linha visivvel
                                                break;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    dtgUsuario.FirstDisplayedScrollingRowIndex = posiciona;
                                }
                                LinhaAtual = i;
                                dtgUsuario.Select();
                                bExiste = true;
                                break;
                            }
                        }
                    }
                }
            }
            if (!bExiste)
            {
                MessageBox.Show("Não foi encontrado nenhum conteúdo com o Texto Digitado", "Gestão de Materiais", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LinhaAtual = 0;
                TextoPesquisado = string.Empty;
            }
            txtPesquisa.Focus();
        }

        #region UNIDADE

        private void ConfiguraUnidadeDTG()
        {
            dtgUnidade.AutoGenerateColumns = false;
            dtgUnidade.Columns["colIdtUnidade"].DataPropertyName = UsuarioUnidadeDTO.FieldNames.IdtUnidade;
            dtgUnidade.Columns["colDsUnidade"].DataPropertyName = UsuarioUnidadeDTO.FieldNames.DsUnidade;

        }

        private void CarregaUnidadesUsuario()
        {
            UsuarioUnidadeDTO dtoUnidade = new UsuarioUnidadeDTO();
            UsuarioUnidadeDataTable dtbUnidade = new UsuarioUnidadeDataTable();
            ConfiguraUnidadeDTG();
            dtoUnidade.IdtUsuario.Value = Convert.ToDecimal(txtIdtUusario.Text);
            dtbUnidade = UsuarioUnidade.Sel(dtoUnidade);
            dtgUnidade.DataSource = dtbUnidade;
            btnSetorPesquisar.Enabled = false;
            dtgSetor.Enabled = false;

        }

        private void dtgUnidade_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgUnidade.Rows.Count > 0)
            {
                if (dtgUnidade.Columns[e.ColumnIndex].Name == "colExcluirUnidade")
                {
                    UsuarioUnidadeDTO dtoUnidade = new UsuarioUnidadeDTO();
                    dtoUnidade.IdtUnidade.Value = Convert.ToDecimal(dtgUnidade.Rows[e.RowIndex].Cells["colIdtUnidade"].Value.ToString());
                    dtoUnidade.IdtUsuario.Value = Convert.ToDecimal(txtIdtUusario.Text);
                    UsuarioUnidade.Del(dtoUnidade);
                    CarregaUnidadesUsuario();
                    txtDsUnidade.Text = string.Empty;
                    txtIdtUnidade.Text = string.Empty;
                }
                else
                {
                    txtIdtUnidade.Text = dtgUnidade.Rows[e.RowIndex].Cells["colIdtUnidade"].Value.ToString();
                    txtDsUnidade.Text = dtgUnidade.Rows[e.RowIndex].Cells["colDsUnidade"].Value.ToString();
                    CarregarPerfisUsuario();
                    cmbUnidade.SelectedValue = dtgUnidade.Rows[e.RowIndex].Cells["colIdtUnidade"].Value.ToString();
                    
                    cmbLocal.Enabled = true;
                    btnSetorPesquisar.Enabled = true;
                    dtgSetor.Enabled = true;
                    if (dtgSetor.Rows.Count > 0)
                        dtgSetor.DataSource = null;

                }

            }
        }

        private void btnAdicionarUnidade_Click(object sender, EventArgs e)
        {            
            if (cmbUnidade.SelectedValue != null)
            {
                UsuarioUnidadeDTO dtoUnidade = new UsuarioUnidadeDTO();
                UsuarioUnidadeDataTable dtbUnidade = new UsuarioUnidadeDataTable();
                dtoUnidade.IdtUsuario.Value = Convert.ToDecimal(txtIdtUusario.Text);
                dtoUnidade.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                // verifica se ja existe unidade associada ao usuário
                dtbUnidade = UsuarioUnidade.Sel(dtoUnidade);
                if (dtbUnidade.Rows.Count > 0)
                {
                    MessageBox.Show("Esta Unidade já está associada ao Usuário", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                UsuarioUnidade.Ins(dtoUnidade);
                CarregaUnidadesUsuario();
            }
            chkSelTodos.Visible = chkSelTodos.Checked = false;
        }

        #endregion

        #region SETORES

        private void ConfiguraSetorDTG()
        {
            dtgSetor.AutoGenerateColumns = false;            
            dtgSetor.Columns["colIdtSetor"].DataPropertyName = UnidadeLocalSetorUsuarioDTO.FieldNames.IdtSetor;
            dtgSetor.Columns["colDsSetor"].DataPropertyName = UnidadeLocalSetorUsuarioDTO.FieldNames.DsSetor;
            dtgSetor.Columns["colStatus"].DataPropertyName = UnidadeLocalSetorUsuarioDTO.FieldNames.FlagStatus;
            dtgSetor.Columns["colIdtAssSetor"].DataPropertyName = UnidadeLocalSetorUsuarioDTO.FieldNames.Idt;
        }

        private void CarregarGridSetores()
        {
            if (txtIdtUnidade.Text != string.Empty && txtIdtUusario.Text != string.Empty && cmbLocal.SelectedValue != null)
            {
                ConfiguraSetorDTG();
                UnidadeLocalSetorUsuarioDataTable dtbSetores = new UnidadeLocalSetorUsuarioDataTable();
                UnidadeLocalSetorUsuarioDTO dtoSetores = new UnidadeLocalSetorUsuarioDTO();

                dtoSetores.IdtUsuario.Value = Convert.ToDecimal(txtIdtUusario.Text);
                dtoSetores.IdtLocalAtendimento.Value = cmbLocal.SelectedValue.ToString();

                dtoSetores.IdtUnidade.Value = Convert.ToDecimal(txtIdtUnidade.Text);

                dtbSetores = UnidadeLocalSetorUsuario.AssociarSetorUsuario(dtoSetores);

                dtgSetor.DataSource = dtbSetores;
            }
        }

        private void AtualizarSetorUsuario(DataGridViewRow dtgRow, bool naoExcluir)
        {
            if (dtgRow.Cells[colIdtAssSetor.Name].Value.ToString() == string.Empty)
            {                
                // não esta associado INSERE
                UnidadeLocalSetorUsuarioDTO dtoSetor = new UnidadeLocalSetorUsuarioDTO();
                dtoSetor.IdtUnidade.Value = Convert.ToDecimal(txtIdtUnidade.Text);
                dtoSetor.IdtSetor.Value = Convert.ToDecimal(dtgRow.Cells[colIdtSetor.Name].Value.ToString());
                dtoSetor.IdtLocalAtendimento.Value = cmbLocal.SelectedValue.ToString();
                dtoSetor.IdtUsuario.Value = Convert.ToDecimal(txtIdtUusario.Text);
                dtoSetor.FlagStatus.Value = "A";
                dtoSetor.IdtUsuarioAtualizadoPor.Value = dtoSegurancaLocal.Idt.Value;

                dtoSetor = UnidadeLocalSetorUsuario.Ins(dtoSetor);
            }
            else if (!naoExcluir)
            {
                // esta associado esclui
                UnidadeLocalSetorUsuarioDTO dtoSetor = new UnidadeLocalSetorUsuarioDTO();
                dtoSetor.IdtUnidade.Value = Convert.ToDecimal(txtIdtUnidade.Text);
                dtoSetor.IdtSetor.Value = Convert.ToDecimal(dtgRow.Cells[colIdtSetor.Name].Value.ToString());
                dtoSetor.IdtLocalAtendimento.Value = cmbLocal.SelectedValue.ToString();
                dtoSetor.IdtUsuario.Value = Convert.ToDecimal(txtIdtUusario.Text);
                UnidadeLocalSetorUsuario.Del(dtoSetor);
            }
        }

        #endregion

        private void btnSetorPesquisar_Click(object sender, EventArgs e)
        {            
            CarregarGridSetores();
            if (dtgSetor.RowCount > 0)
            {
                chkSelTodos.Checked = false;
                chkSelTodos.Visible = true;
            }
        }

        private void dtgSetor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //if (dtgSetor.Columns[e.ColumnIndex].Name == "colAddAss")
            AtualizarSetorUsuario(dtgSetor.Rows[e.RowIndex], false);            
            CarregarGridSetores();
            this.Cursor = Cursors.Default;
        }

        private void dtgSetor_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
                if (dtgSetor.Rows[e.RowIndex].Cells["colIdtAssSetor"].Value.ToString() == string.Empty)
                {
                    // NÃO ESTA ASSOACIADO AO SETOR
                    // e.CellStyle.ForeColor = Color.Gray;
                    // dtgSetor.Rows[e.RowIndex].Cells["colAddAss"].Value = imgLst.Images[1]; // PODE ADICONAR, NÃO ESTA ASSOCIADO
                }
                else
                {
                    e.CellStyle.BackColor = Color.LightGray; // .ForeColor = Color.Gray;
                    // ESTA ASSOCIADO
                    // dtgSetor.Rows[e.RowIndex].Cells["colAddAss"].Value = imgLst.Images[0]; // NÃO PODE ADICONAR, JÁ ESTA ASSOCIADO
                }
        }

        private void txtMatricula_Validating(object sender, CancelEventArgs e)
        {
            if (txtMatricula.Text != string.Empty)
            {
                this.Cursor = Cursors.WaitCursor;

                UsuarioDTO dtoUsuario = new UsuarioDTO();
                UsuarioDataTable dtbUsuario = new UsuarioDataTable();
                dtoUsuario.Matricula.Value = txtMatricula.Text;
                dtbUsuario = Usuario.Sel(dtoUsuario);                
                if (dtbUsuario.Rows.Count > 0)
                {
                    bool matriculaEmUso = false;
                    if (string.IsNullOrEmpty(txtIdtUusario.Text))
                        matriculaEmUso = true;
                    else
                    {
                        if (dtbUsuario.TypedRow(0).Idt.Value.ToString() != txtIdtUusario.Text.Trim())
                            matriculaEmUso = true;
                    }
                    if (matriculaEmUso)
                    {
                        MessageBox.Show("Esta matricula já esta em uso por outro usuário", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dtbUsuario.Rows.Clear();
                        txtMatricula.Text = string.Empty;
                        txtMatricula.Focus();
                        this.Cursor = Cursors.Default;
                        return;
                    }
                }

                if (txtLogin.Text == string.Empty)
                    txtLogin.Text = txtMatricula.Text;

                this.Cursor = Cursors.Default;
            }
            txtCPF.Focus();
        }

        private void btnSetorPesquisar_Click_1(object sender, EventArgs e)
        {

        }

        private void chkSelTodos_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            foreach (DataGridViewRow dtgRow in dtgSetor.Rows)
            {
                if (chkSelTodos.Checked)
                    AtualizarSetorUsuario(dtgRow, true);
                else if (dtgRow.Cells[colStatus.Name].Value.ToString() == "A")
                    AtualizarSetorUsuario(dtgRow, false);
            }

            CarregarGridSetores();
            this.Cursor = Cursors.Default;
        }

        private void txtCPF_Validating(object sender, CancelEventArgs e)
        {            
            txtDataNasc.Focus();
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            txtDataExpira.Focus();
        }

        private void txtDataNasc_Validating(object sender, CancelEventArgs e)
        {
            txtNmUsuario.Focus();
        }
    }
}