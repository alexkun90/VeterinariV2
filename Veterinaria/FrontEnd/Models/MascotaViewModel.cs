using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class MascotaViewModel
    {
        public int MascotaId { get; set; }

        public string? NombreMascota { get; set; }

        
        public int? TipoMascotaId { get; set; }
        public IEnumerable<TiposMascotasViewModel> TiposMascotas { get; set; }

        public TiposMascotasViewModel TipoMascota { get; set; }
      
        public IEnumerable<RazasViewModel> Razas { get; set; }
        public int? RazaId { get; set; }      
        
        public RazasViewModel Raza { get; set; }

        public string? Genero { get; set; }

        public int? Edad { get; set; }

        public double? Peso { get; set; }

        public byte[]? ImagenMascota { get; set; }

        public string? DueñoId { get; set; }
        public IEnumerable<UsuarioViewModel> Usuarios { get; set; }
        public UsuarioViewModel Usuario { get; set; }

        public string? CodigoUsuarioCreacion { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public string? CodigoUsuarioModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public bool? Estado { get; set; }
    }
}
