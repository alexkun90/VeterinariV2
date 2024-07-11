using Entities.Entities;

namespace API.Model
{
    public class DesparasitacionesVacunaDTO
    {
        public int CodigoDesparasitacionVacuna { get; set; }

        public string? Tipo { get; set; }

        public DateOnly? Fecha { get; set; }

        public string? Producto { get; set; }

        public int? MascotaId { get; set; }

        public virtual MascotaDTO? Mascota { get; set; }
    }
}
