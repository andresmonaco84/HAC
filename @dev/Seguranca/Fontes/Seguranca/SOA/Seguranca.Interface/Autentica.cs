using System;
using System.Collections.Generic;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Seguranca.DTO;

namespace HospitalAnaCosta.SGS.Seguranca.Interface
{
    public interface IAutentica
    {
        SegurancaDTO Login(SegurancaDTO dto);
        Boolean TrocaSenha(SegurancaDTO dto);

        // SegurancaDTO InfoUsuario();
    }
}
