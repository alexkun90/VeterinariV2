using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ITiposMascotasHelper
    {
        List<TiposMascotasViewModel> GetTiposMascotas();
        TiposMascotasViewModel GetTiposMascota(int id);
        TiposMascotasViewModel Add(TiposMascotasViewModel tiposMascotas);
        TiposMascotasViewModel Remove(int id);
        TiposMascotasViewModel Update(TiposMascotasViewModel tiposMascotas);
    }
}
