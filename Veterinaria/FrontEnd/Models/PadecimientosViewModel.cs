namespace FrontEnd.Models
{
    public class PadecimientosViewModel
    {

        public int CodigoPadecimiento { get; set; }

        public string NombrePadecimiento { get; set; } = null!;

        public int? MascotaID { get; set; }
        public IEnumerable<MascotaViewModel> Mascotas { get; set; }
        public MascotaViewModel Mascota { get; set; }
    }
}
