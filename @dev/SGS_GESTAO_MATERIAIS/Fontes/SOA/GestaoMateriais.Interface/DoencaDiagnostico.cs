using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
    public interface IDoencaDiagnostico
    {
        DoencaDiagnosticoDTO Gravar(DoencaDiagnosticoDTO dto);

        void Excluir(DoencaDiagnosticoDTO dto);

        DoencaDiagnosticoDataTable Listar(DoencaDiagnosticoDTO dto);
    }
}