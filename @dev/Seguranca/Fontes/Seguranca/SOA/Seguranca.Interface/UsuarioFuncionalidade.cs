
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using System.Data;

namespace HospitalAnaCosta.SGS.Seguranca.Interface
{
    public interface IUsuarioFuncionalidade
    {
        UsuarioFuncionalidadeDTO Obter(UsuarioFuncionalidadeDTO dto);        

    }
}
