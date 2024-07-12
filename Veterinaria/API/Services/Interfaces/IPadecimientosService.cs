using BackEnd.Model;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IPadecimientosService
    {


        bool Add(PadecimientosModel padecimientos);
        bool Remove(PadecimientosModel padecimientos);
        bool Update(PadecimientosModel padecimientos);

        PadecimientosModel Get(int id);
        IEnumerable<PadecimientosModel> Get();
    }
}
