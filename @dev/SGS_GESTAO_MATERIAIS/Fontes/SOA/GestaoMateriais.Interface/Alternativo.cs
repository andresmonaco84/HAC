using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
    public interface IAlternativo
    {
        DataTable InformacoesInternadoAla(int? nroInternacao, string nome);
    }
}
