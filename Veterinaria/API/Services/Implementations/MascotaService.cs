using API.Model;
using API.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace API.Services.Implementations
{
    public class MascotaService : IMascotaService
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private IMascotaDAL mascotaDAL;

        private Mascota Convertir(MascotaDTO mascota)
        {

            Mascota entity = new Mascota
            {
                MascotaId = mascota.MascotaId,
                NombreMascota = mascota.NombreMascota,
                TipoMascotaId = mascota.TipoMascotaId,
                RazaId = mascota.RazaId,
                Genero = mascota.Genero,
                Edad = mascota.Edad,
                Peso = mascota.Peso,
                ImagenMascota = mascota.ImagenMascota,
                DueñoId = mascota.DueñoId,
                CodigoUsuarioCreacion = mascota.CodigoUsuarioCreacion,
                FechaCreacion = mascota.FechaCreacion,
                CodigoUsuarioModificacion = mascota.CodigoUsuarioModificacion,
                FechaModificacion = mascota.FechaModificacion,
                Estado = mascota.Estado


            };
            return entity;

        }

        private MascotaDTO Convertir(Mascota mascota)
        {

            MascotaDTO entity = new MascotaDTO
            {
                MascotaId = mascota.MascotaId,
                NombreMascota = mascota.NombreMascota,
                TipoMascotaId = mascota.TipoMascotaId,
                RazaId = mascota.RazaId,
                Genero = mascota.Genero,
                Edad = mascota.Edad,
                Peso = mascota.Peso,
                ImagenMascota = mascota.ImagenMascota,
                DueñoId = mascota.DueñoId,
                CodigoUsuarioCreacion = mascota.CodigoUsuarioCreacion,
                FechaCreacion = mascota.FechaCreacion,
                CodigoUsuarioModificacion = mascota.CodigoUsuarioModificacion,
                FechaModificacion = mascota.FechaModificacion,
                Estado = mascota.Estado


            };
            return entity;

        }

        public bool Add(MascotaDTO mascota)
        {
            _unidadDeTrabajo.MascotaDAL.Add(Convertir(mascota));
            return _unidadDeTrabajo.Complete();
        }

        public bool Remove(MascotaDTO mascota)
        {
            _unidadDeTrabajo.MascotaDAL.Remove(Convertir(mascota));
            return _unidadDeTrabajo.Complete();
        }

        public bool Update(MascotaDTO mascota)
        {
            _unidadDeTrabajo.MascotaDAL.Update(Convertir(mascota));
            return _unidadDeTrabajo.Complete();
        }

        public MascotaDTO Get(int id)
        {
            return Convertir(_unidadDeTrabajo.MascotaDAL.Get(id));
        }

        public IEnumerable<MascotaDTO> Get()
        {
            var lista = _unidadDeTrabajo.MascotaDAL.GetAll();
            List<MascotaDTO> mascota = new List<MascotaDTO>();
            foreach (var item in lista)
            {
                mascota.Add(Convertir(item));
            }
            return mascota;
        }

        public MascotaService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this._unidadDeTrabajo = unidadDeTrabajo;
        }
    }
}
