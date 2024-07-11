using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Raza
{
    public int CodigoRaza { get; set; }

    public string? NombreRaza { get; set; }

    public int? TipoMascotaId { get; set; }

    public virtual ICollection<Mascota> Mascota { get; set; } = new List<Mascota>();

    public virtual TiposMascota? TipoMascota { get; set; }
}
