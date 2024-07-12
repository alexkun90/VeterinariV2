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
    public class TiposMascotasDALImpl : DALGenericoImpl<TiposMascota>, ITiposMascotasDAL
    {

        private VeteProV2Context context;


        public TiposMascotasDALImpl(VeteProV2Context context): base(context) 
        {
            this.context = context;
        }


      
       
    }
}
