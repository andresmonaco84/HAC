using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Hac.Windows.Forms;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using Microsoft.Win32;
using HospitalAnaCosta.SGS.Seguranca.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais
{
    public partial class FrmLogin : FrmBase
    {
        #region Construtor

        public FrmLogin()
        {
            InitializeComponent();
        }

        #endregion        

        #region Variáveis Privadas

        private string _regPath = "Software\\Hospital_Ana_Costa\\GestaoMateriais";
        private string textoTrocaLocal = "Trocar Localização";
        private string textoSalvaLocal = "Salvar Localização";

        #endregion

        #region Variáveis Públicas

        public SegurancaDTO dto = new SegurancaDTO();

        #endregion     

        #region Métodos

        public static SegurancaDTO Logar()
        {
            FrmLogin me = new FrmLogin();

            me.ShowDialog();

            return me.dto;
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
        }

        private void SelecionarCombos()
        {
            RegistryKey reg = Registry.CurrentUser;
            
            reg = reg.OpenSubKey(_regPath, true);

            if (reg != null)
            {
                if (reg.GetValue("Unidade") != null)
                {
                    if (reg.GetValue("Unidade").ToString() != string.Empty) cmbUnidade.SelectedValue = reg.GetValue("Unidade").ToString();
                }
                if (reg.GetValue("LocalAtendimento") != null)
                {
                    if (reg.GetValue("LocalAtendimento").ToString() != string.Empty) cmbLocal.SelectedValue = reg.GetValue("LocalAtendimento").ToString();
                }
                if (reg.GetValue("Setor") != null)
                {
                    if (reg.GetValue("Setor").ToString() != string.Empty && cmbUnidade.SelectedIndex != -1 && cmbLocal.SelectedIndex != -1)
                    {
                        cmbSetor.SelectedValue = reg.GetValue("Setor").ToString();
                        chkLocal.Text = textoTrocaLocal;
                        this.DesabilitarCombos(true);
                        toolTip.SetToolTip(chkLocal, "Remove o registro da Unidade/Local/Setor do usuário corrente do Windows");
                    }
                    else
                    {
                        this.DesabilitarCombos(false);
                        toolTip.SetToolTip(chkLocal, "Registra a Unidade/Local/Setor selecionados para o usuário corrente do Windows");
                    }
                }
            }
            else
            {
                toolTip.SetToolTip(chkLocal, "Registra a Unidade/Local/Setor selecionados para o usuário corrente do Windows");
            }
        }

        private void DesabilitarCombos(bool desabilitar)
        {
            cmbUnidade.Enabled = !desabilitar;
            cmbLocal.Enabled = !desabilitar;
            cmbSetor.Enabled = !desabilitar;
        }

        #endregion

        #region Eventos

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.cmbUnidade.Carregaunidade();
            this.SelecionarCombos();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (chkLocal.Checked && chkLocal.Text == textoSalvaLocal)
            {
                this.RegistrarLocal(false);
            }

            if (txtUsuario.Text.Length != 0)
            {
                dto.NmUsuario.Value = txtUsuario.Text;
                dto.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                dto.DsUnidade.Value = cmbUnidade.Text;
                dto.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                dto.DsLocal.Value = cmbLocal.Text;
                dto.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                dto.DsSetor.Value = cmbSetor.Text;
                dto.IdtNivelSeguranca.Value = (int)SegurancaDTO.NivelSeguranca.OPERADOR;
            }
            else
            {
                dto.NmUsuario.Value = "Gestor Almoxarifado";
                dto.IdtUnidade.Value = 244;
                dto.DsUnidade.Value = "SANTOS";
                dto.IdtLocal.Value = 29;
                dto.DsLocal.Value = "INTERNADO";
                dto.IdtSetor.Value = 29;
                dto.DsSetor.Value = "ALMOXARIFADO";
                dto.IdtNivelSeguranca.Value = (int)SegurancaDTO.NivelSeguranca.GESTOR;

                #region
                //dto.NmUsuario.Value = "Gestor Almoxarifado";
                //dto.IdtUnidade.Value = 245;
                //dto.DsUnidade.Value = "GUARUJA";
                //dto.IdtLocal.Value = 27;
                //dto.DsLocal.Value = "AMBULATORIO";
                //dto.IdtSetor.Value = 30;
                //dto.DsSetor.Value = "ALMOXARIFADO";

                //dto.NmUsuario.Value = "Gestor Almoxarifado";
                //dto.IdtUnidade.Value = 246;
                //dto.DsUnidade.Value = "CUBATAO";
                //dto.IdtLocal.Value = 29;
                //dto.DsLocal.Value = "AMBULATORIO";
                //dto.IdtSetor.Value = 31;
                //dto.DsSetor.Value = "ALMOXARIFADO";

                //dto.NmUsuario.Value = "Gestor Almoxarifado";
                //dto.IdtUnidade.Value = 247;
                //dto.DsUnidade.Value = "SAO VICENTE";
                //dto.IdtLocal.Value = 27;
                //dto.DsLocal.Value = "AMBULATORIO";
                //dto.IdtSetor.Value = 32;
                //dto.DsSetor.Value = "ALMOXARIFADO";
                #endregion
            }
            this.Close();
        }        

        private void chkLocal_Click(object sender, EventArgs e)
        {
            if (chkLocal.Text == textoTrocaLocal)
            {
                chkLocal.Checked = false;
                chkLocal.Text = textoSalvaLocal;

                this.DesabilitarCombos(false);
                this.RegistrarLocal(true);                
            }
        }     

        #endregion              
    }
}