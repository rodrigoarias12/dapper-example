using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Persona.API.Model
{
    public partial class PersonaContext : DbContext
    {
        public PersonaContext()
        {
        }

        public PersonaContext(DbContextOptions<PersonaContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Contacto> Contacto { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Relacion> Relacion { get; set; }

    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.HasKey(e => new { e.IdDoc, e.IdTipoContacto })
                    .HasName("PK__Contacto__C92D3B36AD16FC3D");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdDoc)
                    .HasName("PK__Persona__5EACE01C794D0B1D");

                entity.Property(e => e.IdDoc).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Relacion>(entity =>
            {
                entity.HasKey(e => new { e.IdDoc1, e.IdDoc2 })
                    .HasName("PK__Relacion__2E9D386BF7281ECC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
