namespace ElaineCristina09112017
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PESSOA")]
    public partial class Pessoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pessoa()
        {
            Colaboradores = new HashSet<Colaborador>();
        }

        [Key]
        public int IDPESSOA { get; set; }

        [Required, StringLength(100)]
        public string STRNOME { get; set; }

        [Required, StringLength(11)]
        public string STRCPF { get; set; }

        [Required, Column(TypeName = "date")]
        public DateTime? DTNASCIMENTO { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DTCADASTRO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Colaborador> Colaboradores { get; set; }
    }
}
