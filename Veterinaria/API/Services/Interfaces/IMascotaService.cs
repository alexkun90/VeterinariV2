using API.Model;

namespace API.Services.Interfaces
{
    public interface IMascotaService
    {
        bool Add(MascotaDTO mascota);
        bool Remove(MascotaDTO mascota);
        bool Update(MascotaDTO mascota);

        MascotaDTO Get(int id);
        IEnumerable<MascotaDTO> Get();
    }
}
