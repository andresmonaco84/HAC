using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sgs_admin.Models
{
    public class ClinicaAtendimento
    {
        [Display(Name = "Idt")]
        public int Idt { get; set; }

        [Display(Name = "Código")]
        public int Codigo { get; set; }

        [Display(Name = "Clínica")]
        public string Clinica { get; set; }

        [Display(Name = "Início Vigência")]
        [DataType(DataType.DateTime)]
        public DateTime Inicio { get; set; }

        [Display(Name = "Fim Vigência")]
        [DataType(DataType.DateTime)]
        public DateTime? Fim { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }
    }
}