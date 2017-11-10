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

        [Required, StringLength(150)]
        public string STRNOME { get; set; }

        [Required]
        [StringLength(14)]
        public string STRCNPJ { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DTCADASTRO { get; set; }

        [StringLength(150)]
        public string STRRAZAOSOCIAL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Colaborador> Colaboradores { get; set; }
    }
}
