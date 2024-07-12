using System.ComponentModel.DataAnnotations;

namespace BackEnd.Model
{
    public class RazasModel
    {

        public int CodigoRaza { get; set; }

        [Required]
        public string NombreRaza { get; set; } = null!;

        public int? TipoMascotaId { get; set; }
    }
}
