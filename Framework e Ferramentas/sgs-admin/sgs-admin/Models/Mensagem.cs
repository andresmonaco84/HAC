using System;
using System.ComponentModel.DataAnnotations;

namespace sgs_admin.Models
{
    public class Mensagem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Início é obrigatório")]
        [Display(Name = "Início")]
        [DataType(DataType.DateTime, ErrorMessage = "Data Inicio inválida")]
        public DateTime Inicio { get; set; }

        [Required(ErrorMessage = "O campo Fim é obrigatório")]
        [Display(Name = "Fim")]
        [DataType(DataType.DateTime, ErrorMessage = "Data Fim inválida")]
        public DateTime Fim { get; set; }
        
        [StringLength(30, ErrorMessage = "Deve ter entre {2} e {1} caracteres.", MinimumLength = 3)]
        [Required(ErrorMessage = "O campo Sistema é obrigatório")]
        public string Sistema { get; set; }

        [StringLength(320, ErrorMessage = "Deve ter entre {2} e {1} caracteres.", MinimumLength = 6)]
        [Required (ErrorMessage = "O campo Texto é obrigatório")]
        public string Texto { get; set; }
        
        //[ReadOnly(true)]
        public Boolean Status { get; set; }

        [Display(Name = "Módulo")]
        public string Modulo { get; set; }

        [Display(Name = "Imagem")]
        
        [Required(ErrorMessage = "O campo imagem da mensagem é obrigatório")]
        public string LogoImagem { get; set; }
    }

    public enum logoImagem
    {
        [Display(Name = "ti", Order = 1)]
        ti = 1,

        [Display(Name = "acs", Order = 2)]
        acs = 2,

        [Display(Name = "uhg", Order = 3)]
        uhg = 3,
    }
    //public class MensagemViewModel
    //{
    //    public List<Mensagem> Todas { get; set; }
    //    public List<Mensagem> Excluidas { get; set; }
    //}
}