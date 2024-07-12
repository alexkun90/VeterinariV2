using BackEnd.Model;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class RazasService : IRazasService
    {

        private IUnidadDeTrabajo _unidadDeTrabajo;

        private IRazasDAL razasDAL;

        private Raza Convertir(RazasModel razas)
        {

            Raza entity = new Raza
            {
                CodigoRaza = razas.CodigoRaza,
                NombreRaza = razas.NombreRaza,
                TipoMascotaId = razas.TipoMascotaId

            };
            return entity;

        }


        private RazasModel Convertir(Raza razas)
        {

            RazasModel entity = new RazasModel
            {
                CodigoRaza = razas.CodigoRaza,
                NombreRaza = razas.NombreRaza,
                TipoMascotaId = razas.TipoMascotaId

            };
            return entity;

        }
        public RazasService(IUnidadDeTrabajo unidadDeTrabajo)
        {
                this._unidadDeTrabajo = unidadDeTrabajo;
        }


        public bool Add(RazasModel razas)
        {
           

             _unidadDeTrabajo.RazasDAL.Add(Convertir(razas));
            return _unidadDeTrabajo.Complete();

        }

        public RazasModel Get(int id)
        {
            return Convertir(_unidadDeTrabajo.RazasDAL.Get(id));
        }

        public IEnumerable<RazasModel> Get()
        {
            var lista= _unidadDeTrabajo.RazasDAL.GetAll();
            List<RazasModel> categories = new List<RazasModel>();
            foreach (var item in lista)
            {
                categories.Add(Convertir(item));
            }
            return categories;
        }

        public bool Remove(RazasModel razas)
        {
            
             _unidadDeTrabajo.RazasDAL.Remove(Convertir(razas));
            return _unidadDeTrabajo.Complete();
        }

        public bool Update(RazasModel razas)
        {
             _unidadDeTrabajo.RazasDAL.Update(Convertir(razas));
            return _unidadDeTrabajo.Complete();
        }
    }
}
