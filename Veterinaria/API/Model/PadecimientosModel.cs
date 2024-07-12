using System.ComponentModel.DataAnnotations;

namespace BackEnd.Model
{
    public class PadecimientosModel
    {

        public int CodigoPadecimiento { get; set; }

        [Required]
        public string NombrePadecimiento { get; set; } = null!;

        public int? MascotaId { get; set; }
    }
}
