using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace Hac.Windows.Forms.Controls
{
    public static class VerificadorClientControl
    {
        public static void VerificarClientControl()
        {
#if RELEASE

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
    }
}
