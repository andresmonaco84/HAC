using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Deployment;
using System.Deployment.Application;
using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    public partial class FrmVersao : FrmBase
    {
        public FrmVersao()
        {
            InitializeComponent();
        }

        private void FrmVersao_Load(object sender, EventArgs e)
        {
            try
            {
                IPAddress[] IpLocal = Dns.GetHostAddresses(Dns.GetHostName());
                lblEndereco.Text = IpLocal[0].ToString();
                
                lblVersao.Text = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            catch( Exception ex)
            {
            }
        }
    }
}