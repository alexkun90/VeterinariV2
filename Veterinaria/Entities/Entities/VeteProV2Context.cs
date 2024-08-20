using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities.Entities;

public partial class VeteProV2Context : DbContext
{
    public VeteProV2Context()
    {
    }

    public VeteProV2Context(DbContextOptions<VeteProV2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<DesparasitacionesVacuna> DesparasitacionesVacunas { get; set; }

    public virtual DbSet<Mascota> Mascotas { get; set; }

    public virtual DbSet<Medicamento> Medicamentos { get; set; }

    public virtual DbSet<Padecimiento> Padecimientos { get; set; }

    public virtual DbSet<Raza> Razas { get; set; }

    public virtual DbSet<TiposMascota> TiposMascotas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ALEX\\SQLEXPRESS;Database=VeteProV2;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=true;");
    //=> optionsBuilder.UseSqlServer("Server=SC-DER-2525;Database=VeteProV2;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=true;"); //BD Cisneros

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.CitaId).HasName("PK__Citas__F0E2D9F2A574E9C0");

            entity.Property(e => e.CitaId).HasColumnName("CitaID");
            entity.Property(e => e.DescripcionCita).IsUnicode(false);
            entity.Property(e => e.Diagnostico).IsUnicode(false);
            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.MascotaId).HasColumnName("MascotaID");
            entity.Property(e => e.VeterinarioPrincipalId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("VeterinarioPrincipalID");
            entity.Property(e => e.VeterinarioSecundarioId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("VeterinarioSecundarioID");

            entity.HasOne(d => d.Mascota).WithMany(p => p.Cita)
                .HasForeignKey(d => d.MascotaId)
                .HasConstraintName("FK_Citas_Mascotas");
        });

        modelBuilder.Entity<DesparasitacionesVacuna>(entity =>
        {
            entity.HasKey(e => e.CodigoDesparasitacionVacuna).HasName("PK__Desparas__2D9E31E7205585F6");

            entity.Property(e => e.MascotaId).HasColumnName("MascotaID");
            entity.Property(e => e.Producto)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Mascota).WithMany(p => p.DesparasitacionesVacunas)
                .HasForeignKey(d => d.MascotaId)
                .HasConstraintName("FK_DesparasitacionesVacunas_Mascotas");
        });

        modelBuilder.Entity<Mascota>(entity =>
        {
            entity.HasKey(e => e.MascotaId).HasName("PK__Mascotas__8DBC411CDCF29CEC");

            entity.Property(e => e.MascotaId).HasColumnName("MascotaID");
            entity.Property(e => e.CodigoUsuarioCreacion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CodigoUsuarioModificacion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DueñoId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DueñoID");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NombreMascota)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RazaId).HasColumnName("RazaID");
            entity.Property(e => e.TipoMascotaId).HasColumnName("TipoMascotaID");

            entity.HasOne(d => d.Raza).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.RazaId)
                .HasConstraintName("FK_Mascotas_Razas");

            entity.HasOne(d => d.TipoMascota).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.TipoMascotaId)
                .HasConstraintName("FK_Mascotas_TiposMascotas");
        });

        modelBuilder.Entity<Medicamento>(entity =>
        {
            entity.HasKey(e => e.CodigoMedicamento).HasName("PK__Medicame__44FEECE968F5F1C7");

            entity.Property(e => e.CitaId).HasColumnName("CitaID");
            entity.Property(e => e.Dosis)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreMedicamento)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Cita).WithMany(p => p.Medicamentos)
                .HasForeignKey(d => d.CitaId)
                .HasConstraintName("FK_Medicamentos_Citas");
        });

        modelBuilder.Entity<Padecimiento>(entity =>
        {
            entity.HasKey(e => e.CodigoPadecimiento).HasName("PK__Padecimi__EDA0C741495B42A3");

            entity.Property(e => e.MascotaId).HasColumnName("MascotaID");
            entity.Property(e => e.NombrePadecimiento)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Mascota).WithMany(p => p.Padecimientos)
                .HasForeignKey(d => d.MascotaId)
                .HasConstraintName("FK_Padecimientos_Mascotas");
        });

        modelBuilder.Entity<Raza>(entity =>
        {
            entity.HasKey(e => e.CodigoRaza).HasName("PK__Razas__2B50068F6A30C518");

            entity.Property(e => e.NombreRaza)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TipoMascotaId).HasColumnName("TipoMascotaID");

            entity.HasOne(d => d.TipoMascota).WithMany(p => p.Razas)
                .HasForeignKey(d => d.TipoMascotaId)
                .HasConstraintName("FK_Razas_TiposMascotas");
        });

        modelBuilder.Entity<TiposMascota>(entity =>
        {
            entity.HasKey(e => e.CodigoTipoMascota).HasName("PK__TiposMas__DF59DB92C73ADDA9");

            entity.Property(e => e.NombreTipoMascota)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
