namespace ElaineCristina09112017
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COLABORADOR")]
    public partial class Colaborador
    {
        [Key]
        public int IDCOLAB { get; set; }

        public int? IDPESSOA { get; set; }

        public int? IDEMPRESA { get; set; }

        [Column(TypeName = "numeric")]
        [Display(Name = "Salário")]
        [Required(ErrorMessage ="Preencha o salário do colaborador")]
        public decimal? VLRSALARIO { get; set; }

        [Required(ErrorMessage ="Status do colaborador deve ser selecionado")]
        [Display(Name = "Status")]
        public bool? BSTATUS { get; set; }

        [Required(ErrorMessage ="Informe a data de admissão")]
        [Column(TypeName = "date")]
        [Display(Name = "Dt. Admissão")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DTCADASTRO { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Dt. Demissão")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DTDEMISSAO { get; set; }

        [StringLength(70)]
        [Display(Name = "Cargo")]
        public string STRCARGO { get; set; }

        public virtual Empresa EMPRESA { get; set; }

        public virtual Pessoa PESSOA { get; set; }
    }
}
