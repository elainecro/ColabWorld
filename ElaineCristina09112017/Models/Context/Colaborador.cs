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
        public decimal? VLRSALARIO { get; set; }

        [Required]
        public bool? BSTATUS { get; set; }

        [Required, Column(TypeName = "date")]
        public DateTime? DTCADASTRO { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DTDEMISSAO { get; set; }

        [StringLength(70)]
        public string STRCARGO { get; set; }

        public virtual Empresa EMPRESA { get; set; }

        public virtual Pessoa PESSOA { get; set; }
    }
}
