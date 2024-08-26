namespace FrontEnd.Models
{
    public class RazasViewModel
    {

        public int CodigoRaza { get; set; }

        public string NombreRaza { get; set; } = null!;

        public int? TipoMascotaID { get; set; }
        public IEnumerable<TiposMascotasViewModel> TiposMascotas { get; set; }

        public TiposMascotasViewModel TipoMascota { get; set; }
    }
}
