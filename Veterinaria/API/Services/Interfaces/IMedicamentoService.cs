using API.Model;

namespace API.Services.Interfaces
{
    public interface IMedicamentoService
    {
        bool Add(MedicamentoDTO medicamento);
        bool Remove(MedicamentoDTO medicamento);
        bool Update(MedicamentoDTO medicamento);

        MedicamentoDTO Get(int id);
        IEnumerable<MedicamentoDTO> Get();
    }
}
