using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
    public class DoencaDiagnostico : Control, IDoencaDiagnostico
    {
        private Model.DoencaDiagnostico entity = new Model.DoencaDiagnostico();

        public DoencaDiagnosticoDTO Gravar(DoencaDiagnosticoDTO dto)
        {
            entity.Gravar(dto);
            return dto;
        }

        public void Excluir(DoencaDiagnosticoDTO dto)
        {
            entity.Excluir(dto);
        }

        public DoencaDiagnosticoDataTable Listar(DoencaDiagnosticoDTO dto)
        {
            return entity.Listar(dto);
        }
    }
}