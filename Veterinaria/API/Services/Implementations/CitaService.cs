using API.Model;
using API.Services.Interfaces;
using Azure.Core;
using DAL.Interfaces;
using Entities.Entities;

namespace API.Services.Implementations
{
    public class CitaService : ICitaService
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private ICitasDAL _citaDAL;

        public CitaService(IUnidadDeTrabajo _unidadDeTrabajo)
        {
            this._unidadDeTrabajo = _unidadDeTrabajo;
        }

        public bool Add(CitaDTO cita)
        {
            _unidadDeTrabajo.CitasDAL.Add(Convertir(cita));
            return _unidadDeTrabajo.Complete();
        }

        public CitaDTO Get(int id)
        {
            return Convertir(_unidadDeTrabajo.CitasDAL.Get(id));
        }

        public IEnumerable<CitaDTO> Get()
        {
            var lista = _unidadDeTrabajo.CitasDAL.GetAll();
            List<CitaDTO> cita = new List<CitaDTO>();
            foreach (var item in lista)
            {
                cita.Add(Convertir(item));
            }
            return cita;
        }

        public bool Remove(int id)
        {
            var cita = new Cita { CitaId = id };            
            _unidadDeTrabajo.CitasDAL.Remove(cita);
            return _unidadDeTrabajo.Complete();
        }

        public bool Update(CitaDTO cita)
        {
            _unidadDeTrabajo.CitasDAL.Update(Convertir(cita));
            return _unidadDeTrabajo.Complete();
        }

        private Cita Convertir(CitaDTO cita)
        {
            Cita entity = new Cita
            {
                CitaId = cita.CitaId,
                MascotaId = cita.MascotaId,
                FechaHora = cita.FechaHora,
                VeterinarioPrincipalId = cita.VeterinarioPrincipalId,
                VeterinarioSecundarioId = cita.VeterinarioSecundarioId,
                DescripcionCita = cita.DescripcionCita,
                Diagnostico = cita.Diagnostico,
                Estado = cita.Estado,
            };
            return entity;
        }

        private CitaDTO Convertir(Cita cita)
        {
            CitaDTO entity = new CitaDTO
            {
                CitaId = cita.CitaId,
                MascotaId = cita.MascotaId,
                FechaHora = cita.FechaHora,
                VeterinarioPrincipalId = cita.VeterinarioPrincipalId,
                VeterinarioSecundarioId = cita.VeterinarioSecundarioId,
                DescripcionCita = cita.DescripcionCita,
                Diagnostico = cita.Diagnostico,
                Estado = cita.Estado,
            };
            return entity;
        }
    }

    
}
