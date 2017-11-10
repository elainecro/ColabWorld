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

        [Required(ErrorMessage ="Informe o nome da pessoa")]
        [StringLength(100, ErrorMessage ="Nome da pessoa deve ter no máximo 100 caracteres")]
        [Display(Name = "Nome")]
        public string STRNOME { get; set; }

        [Required(ErrorMessage ="Informe o CPF da pessoa")]
        [StringLength(14, ErrorMessage = "CPF contém no máximo 14 caracteres")]
        [Display(Name = "CPF")]
        public string STRCPF { get; set; }

        [Required(ErrorMessage ="Informe a data de nascimento")]
        [Column(TypeName = "date")]
        [Display(Name = "Dt. Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DTNASCIMENTO { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Dt. Cadastro")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DTCADASTRO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Colaborador> Colaboradores { get; set; }
    }
}
