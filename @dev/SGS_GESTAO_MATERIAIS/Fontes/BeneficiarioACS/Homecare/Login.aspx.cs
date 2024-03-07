using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HospitalAnaCosta.SGS.Seguranca.Control;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.Framework;

public partial class Login : System.Web.UI.Page
{
    #region OBJETOS SERVIÇO

    public Autentica Autentica = new Autentica();
    private AssPerfilUsuario AssPerfilUsuario = new AssPerfilUsuario();
    

    #endregion

    #region MÉTODOS

    private void Autenticar()
    {
        try
        {
            SegurancaDTO dto = new SegurancaDTO();

            dto.Login.Value = UserName.Text;
            dto.Senha.Value = Password.Text;
            dto.IdtUnidade.Value = 244; //SANTOS
            dto.IdtLocal.Value = 33; //ADM
            dto.IdtSetor.Value = 552; //HOME CARE

            dto = Autentica.Login(dto);

            #region PERMISSÃO DO USUÁRIO

            AssPerfilUsuarioDTO dtoAssPerfilUsuario = new AssPerfilUsuarioDTO();

            //dtoAssPerfilUsuario.IdtSistema.Value = 2; //Gestão de Materiais
            dtoAssPerfilUsuario.IdtUsuario.Value = dto.Idt.Value;
            dtoAssPerfilUsuario.IdtUnidade.Value = 244; //Santos
            dtoAssPerfilUsuario.IdtModulo.Value = 43; //Gestão de Materiais

            AssPerfilUsuarioDataTable dtbPerfilUsu = AssPerfilUsuario.Sel(dtoAssPerfilUsuario);

            //Perfil 1162 = ADMINISTRADOR
            //Perfil 1241 = INTERNAÇÃO DOMICILIAR
            if (dtbPerfilUsu.Select(string.Format("{0} = 1162", AssPerfilUsuarioDTO.FieldNames.IdtPerfil)).Length == 0 &&
                dtbPerfilUsu.Select(string.Format("{0} = 1241", AssPerfilUsuarioDTO.FieldNames.IdtPerfil)).Length == 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(),
                                                    "alert('Usuário sem permissão de acesso');", true);
                ScriptManager.GetCurrent(this.Page).SetFocus(this.UserName);
                return;
            }

            //Se usuário tiver apenas permissão de INTERNAÇÃO DOMICILIAR, não permitir o acesso a funcionalidade RELATÓRIOS
            if (dtbPerfilUsu.Select(string.Format("{0} = 1241", AssPerfilUsuarioDTO.FieldNames.IdtPerfil)).Length == 1 &&
                dtbPerfilUsu.Rows.Count == 1)
            {
                Session.Add("REMOVER_FUNCIONALIDADE_RELATORIOS", true);
            }
            else
            {
                Session.Add("REMOVER_FUNCIONALIDADE_RELATORIOS", false);
            }

            #endregion

            if (RememberMe.Checked)
            {
                // Verifica se o Browser suporta Cookies
                if (Request.Browser.Cookies)
                {
                    HttpCookie cokLogin = new HttpCookie("cokUserNameBeneficiarioACS");

                    cokLogin.Value = UserName.Text;
                    cokLogin.Expires = DateTime.Today.AddDays(5);

                    Response.Cookies.Add(cokLogin);
                }
            }
            else
            {
                Response.Cookies["cokUserNameBeneficiarioACS"].Expires = DateTime.Now;
            }

            System.Web.Security.FormsAuthentication.RedirectFromLoginPage(UserName.Text, false);

        }
        catch (HacException ex)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(),
                                                "alert('" + ex.Message + "');", true);
            ScriptManager.GetCurrent(this.Page).SetFocus(this.Password);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(),
                                                "alert('" + ex.Message + "');", true);
        }
    }

    #endregion

    #region EVENTOS

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // Verifica se o Browser suporta Cookies
            if (Request.Browser.Cookies)
            {
                // Verifica se existe cookie criado
                if (Request.Cookies["cokUserNameBeneficiarioACS"] != null)
                {
                    UserName.Text = Request.Cookies["cokUserNameBeneficiarioACS"].Value;
                    ScriptManager.GetCurrent(this.Page).SetFocus(this.Password);
                }
                else
                {
                    ScriptManager.GetCurrent(this.Page).SetFocus(this.UserName);
                }
            }
            else
            {
                ScriptManager.GetCurrent(this.Page).SetFocus(this.UserName);
            }
        }
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        this.Autenticar();
    }

    #endregion
}