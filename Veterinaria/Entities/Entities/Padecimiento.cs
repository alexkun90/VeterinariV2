using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Padecimiento
{
    public int CodigoPadecimiento { get; set; }

    public string? NombrePadecimiento { get; set; }

    public int? MascotaId { get; set; }

    public virtual Mascota? Mascota { get; set; }
}
