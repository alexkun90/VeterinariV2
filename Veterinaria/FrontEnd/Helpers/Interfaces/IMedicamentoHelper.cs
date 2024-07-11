using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IMedicamentoHelper 
    {
        List<MedicamentoViewModel> GetMedicamentos();
        MedicamentoViewModel GetMedicamento(int id);
        MedicamentoViewModel Add(MedicamentoViewModel medicamento);
        MedicamentoViewModel Remove(int id);
        MedicamentoViewModel Update(MedicamentoViewModel medicamento);
    }
}
