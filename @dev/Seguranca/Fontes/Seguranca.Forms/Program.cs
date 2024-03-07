using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Seguranca.Forms;

namespace HospitalAnaCosta.SGS.Seguranca.Forms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmCfgSeguranca());
            // Application.Run(new FrmLogin());
        }
    }
}