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
    public class RazasDALImpl : DALGenericoImpl<Raza>, IRazasDAL
    {

       
        private VeteProV2Context context;

        public RazasDALImpl(VeteProV2Context context): base(context) 
        {
            this.context = context;
        }


      
       
    }
}
