using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IRazasHelper
    {
        List<RazasViewModel> GetRazas();
        
        RazasViewModel GetRaza(int id);
        RazasViewModel Add(RazasViewModel raza);
        RazasViewModel Remove(int id);
        RazasViewModel Update(RazasViewModel raza);
    }
}
