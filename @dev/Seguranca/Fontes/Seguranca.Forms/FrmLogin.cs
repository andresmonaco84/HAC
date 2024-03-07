using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using HospitalAnaCosta.Framework.Data;
using HospitalAnaCosta.Framework;
using System.Data.Common;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Seguranca.Interface;
using HospitalAnaCosta.SGS.Componentes;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace HospitalAnaCosta.SGS.Seguranca.Forms
{
    public partial class FrmLogin : FrmBaseSeguranca
    {

        private int TelaAberta = 478;
        private int TelaFechada = 330;

        private bool bSenha = false;
        private bool bLocalizacao = false;
        private static bool bOrigemDispensacao = false;

        private SegurancaDTO dtoSegurancaLogin = new SegurancaDTO();

        #region Construtor

        public FrmLogin()
        {
            InitializeComponent();
        }

        #endregion        

        #region Variáveis Privadas

        private string _regPath = "Software\\Hospital_Ana_Costa\\GestaoMateriais";
        //private string textoTrocaLocal = "Trocar Localização";
        //private string textoSalvaLocal = "Salvar Localização";

        #endregion

        #region Variáveis Públicas

        // public SegurancaDTO dto = new SegurancaDTO();

        #endregion     

        #region Métodos

        public static SegurancaDTO Logar(bool origemDispensacao)
        {
            FrmLogin me = new FrmLogin();
            bOrigemDispensacao = origemDispensacao;
            me.ShowDialog();
            return me.dtoSegurancaLogin;
        }


        private void RegistrarUsuario(bool limparValores)
        {
            RegistryKey reg = Registry.CurrentUser;

            reg = reg.OpenSubKey(_regPath, true);

            if (reg == null)
            {
                reg = Microsoft.Win32.Registry.CurrentUser;
                reg = reg.CreateSubKey(_regPath);
            }

            if (!limparValores)
            {
                if (txtUsuario.Text != string.Empty) reg.SetValue("Usuario", txtUsuario.Text);
            }
            else
            {
                reg.SetValue("Usuario", string.Empty);
            }
            AjustaDescricaoLocal();
        }


        private void RegistrarLocal(bool limparValores)
        {
            RegistryKey reg = Registry.CurrentUser;            
            
            reg = reg.OpenSubKey(_regPath, true);

            if (reg == null)
            {
                reg = Microsoft.Win32.Registry.CurrentUser;
                reg = reg.CreateSubKey(_regPath);                
            }

            if (!limparValores)
            {
                if (cmbUnidade.SelectedValue != null) reg.SetValue("Unidade", cmbUnidade.SelectedValue);
                if (cmbLocal.SelectedValue != null) reg.SetValue("LocalAtendimento", cmbLocal.SelectedValue);
                if (cmbSetor.SelectedValue != null) reg.SetValue("Setor", cmbSetor.SelectedValue);                
            }
            else
            {
                reg.SetValue("Unidade", string.Empty);
                reg.SetValue("LocalAtendimento", string.Empty);
                reg.SetValue("Setor", string.Empty);
            }
            AjustaDescricaoLocal();
        }

        /// <summary>
        /// Busca nome do último usuário logado no Sistema
        /// </summary>
        private void SelecionarUsuario()
        {
            RegistryKey reg = Registry.CurrentUser;

            reg = reg.OpenSubKey(_regPath, true);

            if (reg != null)
            {
                if (reg.GetValue("Usuario") != null)
                {
                    if (reg.GetValue("Usuario").ToString() != string.Empty)
                    {
                        txtUsuario.Text = reg.GetValue("Usuario").ToString();
                    }
                }
            }
        }


        /// <summary>
        /// Verifica se unidade/Local/Setor já foram definidos
        /// </summary>
        private void SelecionarCombos()
        {
            RegistryKey reg = Registry.CurrentUser;
            
            reg = reg.OpenSubKey(_regPath, true);

            if (reg != null)
            {
                if (reg.GetValue("Unidade") != null)
                {
                    if (reg.GetValue("Unidade").ToString() != string.Empty)
                    {
                        cmbUnidade.SelectedValue = reg.GetValue("Unidade").ToString();
                    }
                }
                if (reg.GetValue("LocalAtendimento") != null)
                {
                    if (reg.GetValue("LocalAtendimento").ToString() != string.Empty)
                    {
                        cmbLocal.SelectedValue = reg.GetValue("LocalAtendimento").ToString();
                    }
                }
                if (reg.GetValue("Setor") != null)
                {
                    if (reg.GetValue("Setor").ToString() != string.Empty && cmbUnidade.SelectedIndex != -1 && cmbLocal.SelectedIndex != -1)
                    {
                        cmbSetor.SelectedValue = reg.GetValue("Setor").ToString();
                        AjustaDescricaoLocal();
                    }
                    else
                    {
                        lblTrocarLocalizacao_Click(null, null);
                    }
                }
            }
            else
            {
                lblTrocarLocalizacao_Click(null, null);
            }
        }

        private void DesabilitarCombos(bool desabilitar)
        {
            cmbUnidade.Enabled = !desabilitar;
            cmbLocal.Enabled = !desabilitar;
            cmbSetor.Enabled = !desabilitar;
        }

        public void VerificarClientControl()
        {
            #if (!DEBUG)
            try
            {
                var url = "http://localhost:9091/";
                var http = (HttpWebRequest)WebRequest.Create(url);
                var response = http.GetResponse();

            }
            catch (WebException e)
            {

                if (e.Status != WebExceptionStatus.ProtocolError && System.Windows.Forms.MessageBox.Show("Será instalado um novo componente do Sistema SGS.\nPressione OK para iniciar a instalação.", "SGS.ClientControl", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.OK)
                {
                    Process.Start("IExplore.exe", "http://iishac01.anacosta.com.br/instalar/SGSClientControl/SGS.ClientControl.application");
                }

            }
            #endif
        }

        #endregion

        #region Eventos

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            VerificarClientControl();
            Height = TelaFechada;
            cmbUnidade.Carregaunidade();
            pnlTrocaSenha.Visible = false;
            pnlUnidade.Visible = false;            
            this.SelecionarCombos();
            this.SelecionarUsuario();

            if (bOrigemDispensacao)
            {
                lblTrocarLocalizacao.Visible = false;
                lblTrocaSenha.Visible = false;
            }

            btnLogin.GotFocus += btnLogin_GotFocus;
            btnSalvarNovaSenha.GotFocus += btnSalvarNovaSenha_GotFocus;

        }


        private void FrmLogin_Shown(object sender, EventArgs e)
        {
            if (txtUsuario.Text != string.Empty)
            {
                txtSenha.Focus();
            }
            else
            {
                txtUsuario.Focus();
            }
        }       


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == string.Empty)
            {
                MessageBox.Show("Digite o usuário", "Erro no Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsuario.Focus();
                return;
            }
            if (txtSenha.Text == string.Empty)
            {
                MessageBox.Show("Digite a senha", "Erro no Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSenha.Focus();
                return;
            }
            if (dtoSegurancaLogin.IdtSetor.Value.IsNull || dtoSegurancaLogin.IdtSetor.Value == 0)
            {
                MessageBox.Show("Informe o setor de localização", "Erro no Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
                return;
            }
            try
            {
                dtoSegurancaLogin.Login.Value = txtUsuario.Text;
                dtoSegurancaLogin.Senha.Value = txtSenha.Text;

                dtoSegurancaLogin = Autentica.Login(dtoSegurancaLogin);

                //dtoSegurancaLogin.NmUsuario.Value = base.dtoSegurancaBase.NmUsuario.Value;
                dtoSegurancaLogin.Senha.Value = string.Empty;
                dtoSegurancaLogin.NovaSenha.Value = string.Empty;
                //dtoSegurancaLogin.Idt.Value = base.dtoSegurancaBase.Idt.Value;
                dtoSegurancaLogin.Login.Value = txtUsuario.Text;

                this.RegistrarUsuario(false);

                //base.dtoSegurancaBase.IdtUnidade.Value = dto.IdtUnidade.Value;
                //base.dtoSegurancaBase.IdtSetor.Value = dto.IdtSetor.Value;
                //base.dtoSegurancaBase.IdtLocal.Value = dto.IdtLocal.Value;
                //base.dtoSegurancaBase.DsUnidade.Value = dto.DsUnidade.Value;
                //base.dtoSegurancaBase.DsSetor.Value = dto.DsSetor.Value;
                //base.dtoSegurancaBase.DsLocal.Value = dto.DsLocal.Value;

                this.Close();

            }
            catch (HacException ex)
            {
                MessageBox.Show(ex.Message, "Erro no Login", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro no Login", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }        

        #endregion              

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (bOrigemDispensacao)
            {
                dtoSegurancaLogin = null;
                this.Close();
            }
            else
            {
                Application.Exit();
            }            
        }


        #region PAINEL SENHA

        private void PainelSenhaShow()
        {
            btnCancelar.Enabled = false;
            btnLogin.Enabled = false;
            txtUsuario.Enabled = false;
            txtSenha.Enabled = false;

            this.Height = TelaAberta;
            pnlTrocaSenha.Dock = DockStyle.Bottom;
            pnlTrocaSenha.Visible = true;
            lblTrocarLocalizacao.Enabled = false;

            if (txtSenha.Text == string.Empty)
            {
                txtSenhaAtual.Focus();
            }
            else
            {
                txtSenhaAtual.Text = txtSenha.Text;
                txtNovaSenha.Focus();
            }
        }

        private void PainelSenhaHide()
        {
            lblTrocarLocalizacao.Enabled = true;
            pnlTrocaSenha.Visible = false;
            this.Height = TelaFechada;
            btnCancelar.Enabled = true;
            btnLogin.Enabled = true;
            txtUsuario.Enabled = true;
            txtSenha.Enabled = true;
            if (txtUsuario.Text == string.Empty) { txtUsuario.Focus(); }
            else if (txtSenha.Text == string.Empty) { txtSenha.Focus(); }
        }

        private void btnCancelarNovaSenha_Click(object sender, EventArgs e)
        {
            this.Height = TelaFechada;
            pnlTrocaSenha.Visible = false;
            lblTrocarLocalizacao.Enabled = true;
            PainelSenhaHide();
        }

        private void lblTrocaSenha_Click(object sender, EventArgs e)
        {
            txtSenhaAtual.Text = string.Empty;
            txtNovaSenha.Text = string.Empty;
            if (!bSenha)
            {
                bSenha = true;
                PainelSenhaShow();
            }
            else
            {
                bSenha = false;
                PainelSenhaHide();
            }
        }
        
        private void btnSalvarNovaSenha_Click(object sender, EventArgs e)
        {
            try
            {
                dtoSegurancaLogin.Login.Value = txtUsuario.Text;
                dtoSegurancaLogin.Senha.Value = txtSenhaAtual.Text;
                dtoSegurancaLogin.NovaSenha.Value = txtNovaSenha.Text;
                if (!Autentica.TrocaSenha(dtoSegurancaLogin))
                {
                    MessageBox.Show("Houve um erro na tentativa de troca da Senha", "Erro na Troca de Senha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Nova senha OK", "Troca de Senha", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (HacException ex)
            {
                MessageBox.Show(ex.Message, "Erro na Troca de Senha", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro na Troca de Senha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            PainelSenhaHide();
        }

        #endregion

        #region PAINEL UNIDADE

        private void PainelLocallizacaoShow()
        {
            this.Cursor = Cursors.WaitCursor;
            this.Height = TelaAberta;
            pnlUnidade.Dock = DockStyle.Bottom;
            pnlUnidade.Visible = true;
            lblTrocaSenha.Enabled = false;
            this.Cursor = Cursors.Default;
            cmbUnidade.Focus();

        }

        private void PainelLocallizacaoHide()
        {
            lblTrocaSenha.Enabled = true;
            pnlUnidade.Visible = false;
            this.Height = TelaFechada;

            if (txtUsuario.Text == string.Empty)
            {
                txtUsuario.Focus();
            }
            else
            {
                txtSenha.Focus();
            }
            RegistrarLocal(false);
        }

        private void lblTrocarLocalizacao_Click(object sender, EventArgs e)
        {
            if (!bLocalizacao)
            {
                PainelLocallizacaoShow();
                bLocalizacao = true;
            }
            else
            {
                PainelLocallizacaoHide();
                bLocalizacao = false;
            }

        }

        private void btnSalvarUnidade_Click(object sender, EventArgs e)
        {
            PainelLocallizacaoHide();
        }


        private void btnCancelarUnidade_Click(object sender, EventArgs e)
        {
            PainelLocallizacaoHide();
        }

        private void AjustaDescricaoLocal()
        {
            dtoSegurancaLogin.IdtUnidade.Value = Convert.ToDecimal(cmbUnidade.SelectedValue);
            dtoSegurancaLogin.DsUnidade.Value = cmbUnidade.Text;
            dtoSegurancaLogin.IdtLocal.Value = Convert.ToDecimal(cmbLocal.SelectedValue);
            dtoSegurancaLogin.DsLocal.Value = cmbLocal.Text;
            dtoSegurancaLogin.IdtSetor.Value = Convert.ToDecimal(cmbSetor.SelectedValue);
            dtoSegurancaLogin.DsSetor.Value = cmbSetor.Text;

            toolStatus.Items["lblUnidade"].Text = cmbUnidade.Text;
            toolStatus.Items["lblLocal"].Text = cmbLocal.Text;
            toolStatus.Items["lblSetor"].Text = cmbSetor.Text;
        }


        #endregion

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se teclar enter quando tiver focado na senha, executa a rotina que processa o login
            if (e.KeyChar == 13) btnLogin_Click(sender, e);
        }        

        protected void btnLogin_GotFocus(object sender, EventArgs e)
        {
            if (txtUsuario.Text == string.Empty) { txtUsuario.Focus(); }
            else if (txtSenha.Text == string.Empty) { txtSenha.Focus(); }
        }

        private void txtNovaSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se teclar enter quando tiver focado na nova senha, executa a rotina que salva a nova senha
            if (e.KeyChar == 13) btnSalvarNovaSenha_Click(sender, e);
        }

        protected void btnSalvarNovaSenha_GotFocus(object sender, EventArgs e)
        {
            if (txtSenhaAtual.Text == string.Empty) { txtSenhaAtual.Focus(); }
            else if (txtNovaSenha.Text == string.Empty) { txtNovaSenha.Focus(); }
        }

    }
}