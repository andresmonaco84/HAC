using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAnaCosta.Framework.Events
{
    public class HacComboEventArgs : EventArgs
    {
        private string value;

        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }
}
