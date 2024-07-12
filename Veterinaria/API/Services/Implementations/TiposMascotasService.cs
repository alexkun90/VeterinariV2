using BackEnd.Model;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class TiposMascotasService : ITiposMascotasService
    {

        private IUnidadDeTrabajo _unidadDeTrabajo;

        private ITiposMascotasDAL tiposMascotasDAL;

        private TiposMascota Convertir(TiposMascotasModel tiposMascotas)
        {

            TiposMascota entity = new TiposMascota
            {
                CodigoTipoMascota = tiposMascotas.CodigoTipoMascota,
                NombreTipoMascota = tiposMascotas.NombreTipoMascota,
               
            };
            return entity;

        }


        private TiposMascotasModel Convertir(TiposMascota tiposMascotas)
        {

            TiposMascotasModel entity = new TiposMascotasModel
            {
                CodigoTipoMascota = tiposMascotas.CodigoTipoMascota,
                NombreTipoMascota = tiposMascotas.NombreTipoMascota,

            };
            return entity;

        }
        public TiposMascotasService(IUnidadDeTrabajo unidadDeTrabajo)
        {
                this._unidadDeTrabajo = unidadDeTrabajo;
        }


        public bool Add(TiposMascotasModel tiposMascotas)
        {
           

             _unidadDeTrabajo.TiposMascotasDAL.Add(Convertir(tiposMascotas));
            return _unidadDeTrabajo.Complete();

        }

        public TiposMascotasModel Get(int id)
        {
            return Convertir(_unidadDeTrabajo.TiposMascotasDAL.Get(id));
        }

        public IEnumerable<TiposMascotasModel> Get()
        {
            var lista= _unidadDeTrabajo.TiposMascotasDAL.GetAll();
            List<TiposMascotasModel> categories = new List<TiposMascotasModel>();
            foreach (var item in lista)
            {
                categories.Add(Convertir(item));
            }
            return categories;
        }

        public bool Remove(TiposMascotasModel tiposMascotas)
        {
            
             _unidadDeTrabajo.TiposMascotasDAL.Remove(Convertir(tiposMascotas));
            return _unidadDeTrabajo.Complete();
        }

        public bool Update(TiposMascotasModel tiposMascotas)
        {
             _unidadDeTrabajo.TiposMascotasDAL.Update(Convertir(tiposMascotas));
            return _unidadDeTrabajo.Complete();
        }
    }
}
