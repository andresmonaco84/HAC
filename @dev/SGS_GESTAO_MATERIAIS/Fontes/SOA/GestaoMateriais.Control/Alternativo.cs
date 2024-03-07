using System;
using System.Collections.Generic;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using System.Data;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
    public class Altenativo : Control, IAlternativo
	{
        private Model.Alternativo entity = new Model.Alternativo();

        public DataTable InformacoesInternadoAla(int? nroInternacao, string nome)
        {
            return entity.InformacoesInternadoAla(nroInternacao, nome);
        }
    
    }
}
