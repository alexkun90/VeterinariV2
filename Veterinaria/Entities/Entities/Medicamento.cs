using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Medicamento
{
    public int CodigoMedicamento { get; set; }

    public string? NombreMedicamento { get; set; }

    public string? Dosis { get; set; }

    public int? CitaId { get; set; }

    public virtual Cita? Cita { get; set; }
}
