using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAnaCosta.SGS.Componentes
{
    class ToolStripHacEventArgs : EventArgs
    {

    }
    // public delegate void ToolStripHacEventHandler(object sender, ToolStripHacEventArgs e);
    public delegate bool ToolStripHacEventHandler(object sender);
    public delegate void AfterBeforeHacEventHandler(object sender);
}
