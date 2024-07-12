using BackEnd.Model;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class PadecimientosService : IPadecimientosService
    {

        private IUnidadDeTrabajo _unidadDeTrabajo;

        private IPadecimientosDAL padecimientosDAL;

        private Padecimiento Convertir(PadecimientosModel padecimientos)
        {

            Padecimiento entity = new Padecimiento
            {
                CodigoPadecimiento = padecimientos.CodigoPadecimiento,
                NombrePadecimiento = padecimientos.NombrePadecimiento,
                MascotaId = padecimientos.MascotaId

            };
            return entity;

        }


        private PadecimientosModel Convertir(Padecimiento padecimientos)
        {

            PadecimientosModel entity = new PadecimientosModel
            {
                CodigoPadecimiento = padecimientos.CodigoPadecimiento,
                NombrePadecimiento = padecimientos.NombrePadecimiento,
                MascotaId = padecimientos.MascotaId

            };
            return entity;

        }
        public PadecimientosService(IUnidadDeTrabajo unidadDeTrabajo)
        {
                this._unidadDeTrabajo = unidadDeTrabajo;
        }


        public bool Add(PadecimientosModel padecimientos)
        {
             _unidadDeTrabajo.PadecimientosDAL.Add(Convertir(padecimientos));
            return _unidadDeTrabajo.Complete();

        }

        public PadecimientosModel Get(int id)
        {
            return Convertir(_unidadDeTrabajo.PadecimientosDAL.Get(id));
        }

        public IEnumerable<PadecimientosModel> Get()
        {
            var lista= _unidadDeTrabajo.PadecimientosDAL.GetAll();
            List<PadecimientosModel> padecimientos = new List<PadecimientosModel>();
            foreach (var item in lista)
            {
                padecimientos.Add(Convertir(item));
            }
            return padecimientos;
        }

        public bool Remove(PadecimientosModel padecimientos)
        {
            
             _unidadDeTrabajo.PadecimientosDAL.Remove(Convertir(padecimientos));
            return _unidadDeTrabajo.Complete();
        }

        public bool Update(PadecimientosModel padecimientos)
        {
             _unidadDeTrabajo.PadecimientosDAL.Update(Convertir(padecimientos));
            return _unidadDeTrabajo.Complete();
        }
    }
}
