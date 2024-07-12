using System.ComponentModel.DataAnnotations;

namespace BackEnd.Model
{
    public class TiposMascotasModel
    {

        public int CodigoTipoMascota { get; set; }

        [Required]
        public string NombreTipoMascota { get; set; } = null!;

        
    }
}
