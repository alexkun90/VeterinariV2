using BackEnd.Model;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IRazasService
    {


        bool Add(RazasModel razas);
        bool Remove(RazasModel razas);
        bool Update(RazasModel razas);

        RazasModel Get(int id);
        IEnumerable<RazasModel> Get();
    }
}
