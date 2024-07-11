using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ICitaHelper
    {
        List<CitaViewModel> GetAllCitas();
        CitaViewModel GetCitaId(int id);
        CitaViewModel AddCita(CitaViewModel CitaViewModel);
        CitaViewModel EditCita(CitaViewModel CitaViewModel);

        void DeleteCita(int id);
    }
}
