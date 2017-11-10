namespace ElaineCristina09112017
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelColab : DbContext
    {
        public ModelColab()
            : base("name=ModelColab")
        {
        }

        public virtual DbSet<Colaborador> COLABORADORs { get; set; }
        public virtual DbSet<Empresa> EMPRESAs { get; set; }
        public virtual DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Colaborador>()
                .Property(e => e.VLRSALARIO)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Colaborador>()
                .Property(e => e.STRCARGO)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.STRNOME)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.STRCNPJ)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.STRRAZAOSOCIAL)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.STRCPF)
                .IsUnicode(false);
        }
    }
}
