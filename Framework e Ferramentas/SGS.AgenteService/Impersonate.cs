using System;
using System.IO;
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.Text;


public class Impersonation
{
    private IntPtr tokenHandle = new IntPtr(0);

    private WindowsImpersonationContext impersonatedUser;

    public Impersonation()
    {
        string userName = "tisgsservice";
        string password = "sgs123";
        string domainName = "anacosta.com.br";

        // Use the standard logon provider.
        const int LOGON32_PROVIDER_DEFAULT = 0;

        // Create a primary token.
        const int LOGON32_LOGON_INTERACTIVE = 2;

        this.tokenHandle = IntPtr.Zero;

        // Call LogonUser to obtain a handle to an access token.
        bool returnValue = LogonUser(
                            userName,
                            domainName,
                            password,
                            LOGON32_LOGON_INTERACTIVE,
                            LOGON32_PROVIDER_DEFAULT,
                            ref this.tokenHandle);

        if (false == returnValue)
        {
            // Something went wrong.
            int ret = Marshal.GetLastWin32Error();
            throw new System.ComponentModel.Win32Exception(ret);
        }

    }

    public bool SalvarArquivo(string caminhoArquivo, string textoArquivo)
    {
        this.Impersonate();

        StreamWriter streamWriter = new StreamWriter(caminhoArquivo, false, Encoding.ASCII);

        using (StringReader reader = new StringReader(textoArquivo))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                streamWriter.WriteLine(line);
            }
        }

        streamWriter.Close();

        this.Revert();

        return true;
    }

    /// <summary>
    /// Starts the impersonation.
    /// </summary>
    public void Impersonate()
    {
        // Create Identity.
        WindowsIdentity newId = new WindowsIdentity(this.tokenHandle);

        // Start impersonating.
        this.impersonatedUser = newId.Impersonate();
    }

    /// <summary>
    /// Stops the impersonation and releases security token.
    /// </summary>
    public void Revert()
    {
        // Stop impersonating.
        if (this.impersonatedUser != null)
        {
            this.impersonatedUser.Undo();
        }

        // Release the token.
        if (this.tokenHandle != IntPtr.Zero)
        {
            CloseHandle(this.tokenHandle);
        }
    }

    [DllImport("advapi32.dll", SetLastError = true)]
    private static extern bool LogonUser(
            string lpszUsername,
            string lpszDomain,
            string lpszPassword,
            int dwLogonType,
            int dwLogonProvider,
            ref IntPtr phToken);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    private static extern bool CloseHandle(IntPtr handle);
}