using API.Model;

namespace API.Services.Interfaces
{
    public interface ICitaService
    {
        bool Add(CitaDTO cita);
        bool Remove(int id);
        bool Update(CitaDTO cita);

        CitaDTO Get(int id);
        IEnumerable<CitaDTO> Get();
    }
}
