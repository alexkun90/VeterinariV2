using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IMascotaHelper
    {
        List<MascotaViewModel> GetMascotas();
        MascotaViewModel GetMascota(int id);
        MascotaViewModel Add(MascotaViewModel mascota);
        MascotaViewModel Remove(int id);
        MascotaViewModel Update(MascotaViewModel mascota);
    }
}
