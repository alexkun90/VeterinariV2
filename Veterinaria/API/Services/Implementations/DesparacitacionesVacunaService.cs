using API.Model;
using API.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace API.Services.Implementations
{
    public class DesparacitacionesVacunaService : IDesparasitacionesVacunaService
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private IDesparasitacionesVacunaDAL vacunaDAL;

        private DesparasitacionesVacuna Convertir(DesparasitacionesVacunaDTO DesparasitacionesVacuna)
        {

            DesparasitacionesVacuna entity = new DesparasitacionesVacuna
            {

                CodigoDesparasitacionVacuna = DesparasitacionesVacuna.CodigoDesparasitacionVacuna,
                Tipo = DesparasitacionesVacuna.Tipo,
                Fecha = DesparasitacionesVacuna.Fecha,
                Producto = DesparasitacionesVacuna.Producto,
                MascotaId = DesparasitacionesVacuna.MascotaId


            };
            return entity;

        }

        private DesparasitacionesVacunaDTO Convertir(DesparasitacionesVacuna DesparasitacionesVacuna)
        {

            DesparasitacionesVacunaDTO entity = new DesparasitacionesVacunaDTO
            {
                CodigoDesparasitacionVacuna = DesparasitacionesVacuna.CodigoDesparasitacionVacuna,
                Tipo = DesparasitacionesVacuna.Tipo,
                Fecha = DesparasitacionesVacuna.Fecha,
                Producto = DesparasitacionesVacuna.Producto,
                MascotaId = DesparasitacionesVacuna.MascotaId


            };
            return entity;

        }

        public DesparacitacionesVacunaService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool Add(DesparasitacionesVacunaDTO DesparasitacionesVacuna)
        {
            _unidadDeTrabajo.DesparasitacionesVacunaDAL.Add(Convertir(DesparasitacionesVacuna));
            return _unidadDeTrabajo.Complete();
        }

        public bool Remove(DesparasitacionesVacunaDTO DesparasitacionesVacuna)
        {
            _unidadDeTrabajo.DesparasitacionesVacunaDAL.Remove(Convertir(DesparasitacionesVacuna));
            return _unidadDeTrabajo.Complete();
        }

        public bool Update(DesparasitacionesVacunaDTO DesparasitacionesVacuna)
        {
            _unidadDeTrabajo.DesparasitacionesVacunaDAL.Update(Convertir(DesparasitacionesVacuna));
            return _unidadDeTrabajo.Complete();
        }

        public DesparasitacionesVacunaDTO Get(int id)
        {
            return Convertir(_unidadDeTrabajo.DesparasitacionesVacunaDAL.Get(id));
        }

        public IEnumerable<DesparasitacionesVacunaDTO> Get()
        {
            var lista = _unidadDeTrabajo.DesparasitacionesVacunaDAL.GetAll();
            List<DesparasitacionesVacunaDTO> DesparasitacionesVacuna = new List<DesparasitacionesVacunaDTO>();
            foreach (var item in lista)
            {
                DesparasitacionesVacuna.Add(Convertir(item));
            }
            return DesparasitacionesVacuna;
        }

 
    }
}
