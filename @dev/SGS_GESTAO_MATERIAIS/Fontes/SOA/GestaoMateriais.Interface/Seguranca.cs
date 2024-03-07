
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
    public interface ISeguranca
    {
        void Login(SegurancaDTO dto);

        SegurancaDTO InfoUsuario();
    }
}
