using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class CitasDALImpl : DALGenericoImpl<Cita>, ICitasDAL
    {
        private VeteProV2Context context;
        public CitasDALImpl(VeteProV2Context context) : base(context)
        {
            this.context = context;
        }
    }
}
