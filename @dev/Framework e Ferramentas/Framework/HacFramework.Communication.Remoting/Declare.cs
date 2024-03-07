using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAnaCosta.Framework.Communication.Remoting
{
    #region Enumeradores
    /// <summary>
    /// Enum com os tipos de canal
    /// </summary>
    public enum ChannelType
    {
        TCP, HTTP
    }
    #endregion

    #region Events Args
    public class StatusEventArgs : EventArgs
    {
        string statusMessage;
        public string StatusMessage
        {
            get { return statusMessage; }
            set { statusMessage = value; }
        }

    }

    public class InstanceEventArgs : EventArgs
    {
        Dictionary<string, int> instance = new Dictionary<string, int>();

        public Dictionary<string, int> Instance
        {
            get { return instance; }
            set { instance = value; }
        }
    }
    #endregion

    #region Delegates
    public delegate void ShowStatusEventHandler(StatusEventArgs args);
    public delegate void ShowStatusInstanceEventHandler(InstanceEventArgs args);
    #endregion
}
