namespace ElaineCristina09112017
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPRESA")]
    public partial class Empresa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empresa()
        {
            Colaboradores = new HashSet<Colaborador>();
        }

        [Key]
        public int IDEMPRESA { get; set; }

        [Required(ErrorMessage ="Preencha o nome da empresa")]
        [StringLength(150, ErrorMessage = "O nome da empresa pode ter no m�ximo 150 caracteres." )]
        [Display(Name = "Nome")]
        public string STRNOME { get; set; }

        [Required(ErrorMessage ="CNPJ de preenchimento obrigat�rio")]
        [StringLength(18, ErrorMessage = "CNPJ cont�m no m�ximo 18 caracteres")]
        [Display(Name = "CNPJ")]
        public string STRCNPJ { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Dt. Cadastro")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DTCADASTRO { get; set; }

        [StringLength(150, ErrorMessage ="Raz�o social deve ter no m�ximo 150 caracteres")]
        [Display(Name = "Raz�o Social")]
        public string STRRAZAOSOCIAL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Colaborador> Colaboradores { get; set; }
    }
}
