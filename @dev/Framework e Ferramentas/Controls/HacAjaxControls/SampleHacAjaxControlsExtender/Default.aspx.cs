using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Threading;
using System.Web.Services;
using System.Net.Mail;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Button3.Attributes.Add("onclick","EscreveLetra()" );
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Thread.Sleep(2000);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Thread.Sleep(4000);
    }
    [WebMethod]
    public static string Escreve()
    {
        return "Teste de PageMethods.";
    }
    protected void btnPanel_Click(object sender, EventArgs e)
    {
        Thread.Sleep(6000 );
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        System.Web.Mail.MailMessage mm = new System.Web.Mail.MailMessage();
        mm.To = ("guilherme.holdack@anacosta.com.br");

        mm.Priority = System.Web.Mail.MailPriority.High;
        mm.Subject = "FALE CONOSCO - SITE";
        mm.From = ("guilherme@holdack.net");
        mm.Body = "Teste de mensagem";
        SmtpClient smtp = new SmtpClient("172.16.1.12");
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        mm.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");	//basic authentication
        mm.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "my_username_here"); //set your username here
        mm.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "super_secret");	//set your password here

        smtp.Send(mm.From,mm.To,mm.Subject,mm.Body );

    }
}
