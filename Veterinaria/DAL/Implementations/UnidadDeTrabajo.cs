﻿using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        public IMascotaDAL MascotaDAL { get; set; }
        public ICitasDAL CitasDAL { get; set; }
        public IMedicamentoDAL MedicamentoDAL { get; set; }
        public IDesparasitacionesVacunaDAL DesparasitacionesVacunaDAL { get; set; }

        public IRazasDAL RazasDAL { get; set; }
        public IPadecimientosDAL PadecimientosDAL { get; set; }

        public ITiposMascotasDAL TiposMascotasDAL { get; set; }


        private VeteProV2Context _veteProV2Context;

        public UnidadDeTrabajo(VeteProV2Context veteProV2Context,
                        IMascotaDAL mascotaDAL,
                        IMedicamentoDAL medicamentoDAL,
                        ICitasDAL citasDAL,
                        IDesparasitacionesVacunaDAL desparasitacionesVacunaDAL, 
                        IRazasDAL RazasDAL,
                        IPadecimientosDAL PadecimientosDAL,
                        ITiposMascotasDAL TiposMascotasDAL
            ) 
        {
                this._veteProV2Context = veteProV2Context;
                this.MascotaDAL = mascotaDAL;
                this.CitasDAL = citasDAL;
                this.DesparasitacionesVacunaDAL = desparasitacionesVacunaDAL;
                this.MedicamentoDAL = medicamentoDAL;
                this.RazasDAL = RazasDAL;
                this.PadecimientosDAL = PadecimientosDAL;
                this.TiposMascotasDAL = TiposMascotasDAL;

        }
       

        public bool Complete()
        {
            try
            {
                _veteProV2Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }

        public void Dispose()
        {
            this._veteProV2Context.Dispose();
        }
    }
}
