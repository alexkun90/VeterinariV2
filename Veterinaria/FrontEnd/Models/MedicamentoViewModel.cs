namespace FrontEnd.Models
{
    public class MedicamentoViewModel 
    {
        public int CodigoMedicamento { get; set; }

        public string? NombreMedicamento { get; set; }

        public string? Dosis { get; set; }

        public int? CitaId { get; set; }

        public IEnumerable<CitaViewModel> Citas { get; set; }

        public CitaViewModel Cita { get; set; }
    }
}
