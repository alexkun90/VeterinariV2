using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnidadDeTrabajo: IDisposable
    {
        IMascotaDAL MascotaDAL { get; }
        ICitasDAL CitasDAL { get; }
        IDesparasitacionesVacunaDAL DesparasitacionesVacunaDAL { get; }
       
        bool Complete();
    }
}
