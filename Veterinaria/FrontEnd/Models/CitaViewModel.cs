namespace FrontEnd.Models
{
    public class CitaViewModel
    {
        public int CitaId { get; set; }

        public int? MascotaId { get; set; }

        public IEnumerable<MascotaViewModel> Mascotas { get; set; }

        public DateTime? FechaHora { get; set; }

        public string? VeterinarioPrincipalId { get; set; }

        public string? VeterinarioSecundarioId { get; set; }

        public string? DescripcionCita { get; set; }

        public string? Diagnostico { get; set; }

        public bool? Estado { get; set; }


    }
}
