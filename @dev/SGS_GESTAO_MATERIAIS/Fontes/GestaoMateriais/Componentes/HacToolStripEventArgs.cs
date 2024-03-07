using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAnaCosta.SGS.Componentes
{
    public class HacToolStripEventArgs : EventArgs
    {

        public HacToolStripEventArgs()
        {
        }

        public HacToolStripEventArgs(bool cancelar)
        {
            _cancelar = cancelar;

        }
        private bool _cancelar = false;

        public bool Cancelar
        {
            get { return _cancelar; }
            set { _cancelar = value; }
        }
    }
}
