using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CreateUserAD
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request["user"] != null && Request["nome"] != null)
            {
                CreateUserAd(Request["user"], Request["nome"]);
            }
        }

        protected void CreateUserAd(string username, string nome)
        {

            var primeiro = nome.Split(' ')[0];
            var segundo = primeiro;
            if (nome.Split(' ').Length > 1)
            {
                segundo = nome.Split(' ')[1];
            }

            var cmdUser = string.Format(@"user ""cn={0},ou=TemporarioPS,ou=Medicos,ou=Usuarios,ou=Ana Costa,dc=anacosta,dc=com,dc=br"" -fn {1} -ln {2} -display ""{3}"" -upn {0}@anacosta.com.br -samid {0} -pwd hac123", username, primeiro, segundo, nome);

            var cmdGroup = string.Format(@"group ""cn=HAC-Prontel,ou=Santos,ou=Grupos,ou=Ana Costa,dc=anacosta,dc=com,dc=br"" -addmbr ""cn={0},ou=TemporarioPS,ou=Medicos,ou=Usuarios,ou=Ana Costa,dc=anacosta,dc=com,dc=br", username);
                       
            string userName = "tisgsservice";
            string password = "sgs123";
            string domainName = "anacosta";


            var securePassword = new SecureString();
            foreach (char c in password)
                securePassword.AppendChar(c);
            securePassword.MakeReadOnly();

            ProcessStartInfo infoUser = new ProcessStartInfo(@"dsadd.exe", cmdUser);
            infoUser.UserName = userName;
            infoUser.Password = securePassword;
            infoUser.Domain = domainName;
            infoUser.UseShellExecute = false;

            ProcessStartInfo infoGroup = new ProcessStartInfo(@"dsmod.exe", cmdGroup);
            infoGroup.UserName = userName;
            infoGroup.Password = securePassword;
            infoGroup.Domain = domainName;
            infoGroup.UseShellExecute = false;

            Process.Start(infoUser);

            System.Threading.Thread.Sleep(10000);

            Process.Start(infoGroup);

        }
    }
}