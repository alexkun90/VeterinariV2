using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Model
{
    public class MedicamentoDTO
    {
        public int CodigoMedicamento { get; set; }

        public string? NombreMedicamento { get; set; }

        public string? Dosis { get; set; }

        public int? CitaId { get; set; }

        public virtual Cita? Cita { get; set; }
    }
}
