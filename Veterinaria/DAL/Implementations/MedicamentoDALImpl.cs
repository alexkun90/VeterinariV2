using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class MedicamentoDALImpl : DALGenericoImpl<Medicamento>, IMedicamentoDAL
    {
        private VeteProV2Context context;
        public MedicamentoDALImpl(VeteProV2Context context) : base(context)
        {
            this.context = context;
        }
    
    }
}
