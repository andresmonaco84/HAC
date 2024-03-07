using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sgs_admin.Models
{
    public class Script
    {
        [Display(Name = "Atendimento Novo")]
        public Int32 AtendimentoNovo { get; set; }

        [Display(Name = "Atendimento Antigo")]
        public Int32 AtendimentoAntigo { get; set; }
    }
}
