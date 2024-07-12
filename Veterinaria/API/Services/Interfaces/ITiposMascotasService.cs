using BackEnd.Model;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface ITiposMascotasService
    {


        bool Add(TiposMascotasModel razas);
        bool Remove(TiposMascotasModel razas);
        bool Update(TiposMascotasModel razas);

        TiposMascotasModel Get(int id);
        IEnumerable<TiposMascotasModel> Get();
    }
}
