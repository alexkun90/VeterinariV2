using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IDesparasitacionesVacunaHelper
    {
        List<DesparasitacionesVacunaViewModel> GetDesparasitaciones();
        DesparasitacionesVacunaViewModel GetDesparasitaciones(int id);
        DesparasitacionesVacunaViewModel Add(DesparasitacionesVacunaViewModel category);
        DesparasitacionesVacunaViewModel Remove(int id);
        DesparasitacionesVacunaViewModel Update(DesparasitacionesVacunaViewModel category);

    }
}
