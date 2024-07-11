using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class TiposMascota
{
    public int CodigoTipoMascota { get; set; }

    public string? NombreTipoMascota { get; set; }

    public virtual ICollection<Mascota> Mascota { get; set; } = new List<Mascota>();

    public virtual ICollection<Raza> Razas { get; set; } = new List<Raza>();
}
