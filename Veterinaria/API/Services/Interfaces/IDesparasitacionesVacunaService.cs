using API.Model;

namespace API.Services.Interfaces
{
    public interface IDesparasitacionesVacunaService
    {
        bool Add(DesparasitacionesVacunaDTO vacuna);
        bool Remove(DesparasitacionesVacunaDTO vacuna);
        bool Update(DesparasitacionesVacunaDTO vacuna);

        DesparasitacionesVacunaDTO Get(int id);
        IEnumerable<DesparasitacionesVacunaDTO> Get();
    }
}
