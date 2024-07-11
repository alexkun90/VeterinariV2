using System.ComponentModel;

namespace FrontEnd.Models
{
    public class DesparasitacionesVacunaViewModel
    {
        [DisplayName("ID")]
        public int CodigoDesparasitacionVacuna { get; set; }

        public string? Tipo { get; set; }

        public DateOnly? Fecha { get; set; }

        public string? Producto { get; set; }

        public int? MascotaId { get; set; }

        public IEnumerable<MascotaViewModel> Mascotas { get; set; }

        public virtual MascotaViewModel? Mascota { get; set; }

    }
}
