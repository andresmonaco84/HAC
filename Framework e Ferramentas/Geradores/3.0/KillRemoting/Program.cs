using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace KillRemoting
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                switch (clsProcess.ProcessName)
                {
                    case "Cadastro.Remoting":
                        clsProcess.Kill();
                        break;
                    case "HospitalAnaCosta.SGS.Internacao.Remoting":
                        clsProcess.Kill();
                        break;
                    case "Seguranca.Remoting":
                        clsProcess.Kill();
                        break;
                    case "HospitalAnaCosta.Services.Seguranca.Remoting":
                        clsProcess.Kill();
                        break;
                    case "HospitalAnaCosta.Services.Produto.Remoting":
                        clsProcess.Kill();
                        break;
                    case "HospitalAnaCosta.Services.CadastroFaturamento.Remoting":
                        clsProcess.Kill();
                        break;
                    case "GestaoMateriais.Remoting":
                        clsProcess.Kill();
                        break;
                    case "HospitalAnaCosta.Services.BeneficiarioACS.Remoting":
                        clsProcess.Kill();
                        break;
                    case "HospitalAnaCosta.Services.CalculoFaturamento.Remoting":
                        clsProcess.Kill();
                        break;
                    case "AtendimentoSADT.Remoting":
                        clsProcess.Kill();
                        break;
                }
            }
        }
    }
}
