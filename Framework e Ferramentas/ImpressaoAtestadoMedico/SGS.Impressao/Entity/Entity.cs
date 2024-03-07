using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAnaCosta.SGS.Impressao
{
    public abstract class Entity
    {
        private string nomeImpressora;
        private int qtdeCopias;
        private bool possuiCodigoDeBarras = false;

        public string NomeImpressora
        {
            get { return nomeImpressora; }
            set { nomeImpressora = value; }
        }

        public int QuantidadeCopias
        {
            get { return qtdeCopias; }
            set { qtdeCopias = value; }
        }

        public bool PossuiCodigoDeBarras
        {
            get { return possuiCodigoDeBarras; }
            set { possuiCodigoDeBarras = value; }
        }

        
    }
}
