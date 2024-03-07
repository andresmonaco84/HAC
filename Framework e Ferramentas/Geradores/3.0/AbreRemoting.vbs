
Set WshShell = WScript.CreateObject("WScript.Shell")

WshShell.Run("..\..\..\DLL\HospitalAnaCosta.SGS.Internacao.Remoting.exe"),2 

WshShell.Run("..\..\..\DLL\HospitalAnaCosta.Services.Seguranca.Remoting.exe"),2

WshShell.Run("..\..\..\DLL\Seguranca.Remoting.exe"),2

WshShell.Run("..\..\..\DLL\Cadastro.Remoting.exe"),2

WshShell.Run("..\..\..\DLL\HospitalAnaCosta.Services.Produto.Remoting.exe"),2

WshShell.Run("..\..\..\DLL\HospitalAnaCosta.Services.BeneficiarioACS.Remoting.exe"),2

WshShell.Run("..\..\..\DLL\HospitalAnaCosta.Services.CadastroFaturamento.Remoting.exe"),2

WshShell.Run("..\..\..\DLL\HospitalAnaCosta.Services.CalculoFaturamento.Remoting.exe"),2

'WshShell.Run("..\..\..\DLL\SADT.Remoting.exe"),2

WshShell.Run("..\..\..\SGS\Fontes\SOA\AtendimentoSADT\AtendimentoSADT.Remoting\bin\Debug\AtendimentoSADT.Remoting.exe"),2
