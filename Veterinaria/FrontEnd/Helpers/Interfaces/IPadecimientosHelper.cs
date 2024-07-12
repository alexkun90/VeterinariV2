using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IPadecimientosHelper
    {
        List<PadecimientosViewModel> GetPadecimientos();

   
       PadecimientosViewModel GetPadecimiento(int id);
       PadecimientosViewModel Add(PadecimientosViewModel padecimientos);
       PadecimientosViewModel Remove(int id);
       PadecimientosViewModel Update(PadecimientosViewModel padecimientos);
    }
}
