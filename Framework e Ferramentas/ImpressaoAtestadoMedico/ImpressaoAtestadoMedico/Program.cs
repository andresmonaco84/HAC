using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
// using System.Linq;
// using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Drawing.Text;
using System.Data;
using HospitalAnaCosta.SGS.tools;
using HospitalAnaCosta.SGS.Impressao;
using System.Runtime.InteropServices;

namespace impressaoProntuarioEletrocnico
{
    static class Program
    {
        static string sIdtAtendimento;
        static string sIdtUsuario;
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        [STAThread]
        static void Main(string[] args)
        {
            //#region ESCONDE TELA DO CONSOLE
            //var handle = GetConsoleWindow();
            //ShowWindow(handle, SW_HIDE);
            //#endregion ESCONDE TELA DO CONSOLE

            string nomeDaImpressora = null;

            try
            {
                ImpressaoProntuarioEletronico imp = new ImpressaoProntuarioEletronico();
                if (args.Length > 0)
                {
                    sIdtAtendimento = args[0];
                    Console.WriteLine(sIdtAtendimento);
                    Console.WriteLine(args[1]);
                }
                else
                {
#if DEBUG
                    // sIdtAtendimento = "14579956";
                    // sIdtAtendimento = "14655044";
                    // sIdtAtendimento = "30168302";
                    sIdtAtendimento = "27022777";
                    String[] a = new String[2];
                    a[0] = "";
                    a[1] = " ";
                    args = (string[])a.Clone();
                    sIdtUsuario = "";
                    nomeDaImpressora = "CutePDF Writer";
#else
                    // ShowWindow(handle, SW_SHOW);
                    Console.WriteLine("Sem parametros para pesquisa");
                    Console.Read();
                    return;
#endif
                }
                try
                {
                    if (args[1] == null || args[1] == "0")
                    {
                        imp.tipoImpressao = ImpressaoProntuarioEletronico.TipoImpressaoProntuario.AtestadoDeclaracaoDto;
                    }
                    else if (args[1] == "1")
                    {
                        imp.tipoImpressao = ImpressaoProntuarioEletronico.TipoImpressaoProntuario.RelatorioInss;
                    }
                }
                catch
                {
                    imp.tipoImpressao = ImpressaoProntuarioEletronico.TipoImpressaoProntuario.AtestadoDeclaracaoDto;
                }
                
                string retorno = imp.imprimir(sIdtAtendimento, sIdtUsuario, nomeDaImpressora);
                if (!string.IsNullOrEmpty(retorno))
                {
                    // ShowWindow(handle, SW_SHOW);
                    Console.WriteLine(retorno);
                    Console.Read();
                    return;
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                // ShowWindow(handle, SW_SHOW);
                Console.WriteLine(ex.Message);
                Console.Read();
                return;
            }
        }

    }
}
