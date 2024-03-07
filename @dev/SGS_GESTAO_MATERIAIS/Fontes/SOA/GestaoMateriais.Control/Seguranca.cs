using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
    public class Seguranca : Control, ISeguranca
    {
        // private Model.Seguranca entity = new Model.Seguranca();

        private SegurancaDTO DtoGlobal = new SegurancaDTO();

        public void Login(SegurancaDTO dto)
        {
            this.DtoGlobal.Idt.Value = dto.Idt.Value;
            this.DtoGlobal.IdtLocal.Value = dto.IdtLocal.Value;
            this.DtoGlobal.IdtSetor.Value = dto.IdtSetor.Value;
            this.DtoGlobal.IdtUnidade.Value = dto.IdtUnidade.Value;
            this.DtoGlobal.NmUsuario.Value = dto.NmUsuario.Value;
        }


        public SegurancaDTO InfoUsuario()
        {

            return this.DtoGlobal;
        }
    }
}
