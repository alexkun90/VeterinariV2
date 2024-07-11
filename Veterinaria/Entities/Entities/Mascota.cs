using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Mascota
{
    public int MascotaId { get; set; }

    public string? NombreMascota { get; set; }

    public int? TipoMascotaId { get; set; }

    public int? RazaId { get; set; }

    public string? Genero { get; set; }

    public int? Edad { get; set; }

    public double? Peso { get; set; }

    public byte[]? ImagenMascota { get; set; }

    public string? DueñoId { get; set; }

    public string? CodigoUsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? CodigoUsuarioModificacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<DesparasitacionesVacuna> DesparasitacionesVacunas { get; set; } = new List<DesparasitacionesVacuna>();

    public virtual ICollection<Padecimiento> Padecimientos { get; set; } = new List<Padecimiento>();

    public virtual Raza? Raza { get; set; }

    public virtual TiposMascota? TipoMascota { get; set; }
}
