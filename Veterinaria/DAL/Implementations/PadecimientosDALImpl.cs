using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class PadecimientosDALImpl : DALGenericoImpl<Padecimiento>, IPadecimientosDAL
    {

        private VeteProV2Context context;


        public PadecimientosDALImpl(VeteProV2Context context): base(context) 
        {
            this.context = context;
        }


      
       
    }
}
