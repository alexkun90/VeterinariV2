using FrontEnd.ApiMoldels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class MascotaHelper : IMascotaHelper
    {
        IServiceRepository ServiceRepository;

        public MascotaHelper(IServiceRepository serviceRepository)
        {
            this.ServiceRepository = serviceRepository;
        }


        public MascotaViewModel Add(MascotaViewModel mascota)
        {
            HttpResponseMessage response = ServiceRepository.PostResponse("api/mascota", Convertir(mascota));


            if (response != null)
            {

                var content = response.Content.ReadAsStringAsync().Result;


            }
            return mascota;
        }

        private MascotaViewModel Convertir(Mascota mascota)
        {
            return new MascotaViewModel
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
        }


        private Mascota Convertir(MascotaViewModel mascota)
        {
            return new Mascota
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
        }


        public List<MascotaViewModel> GetMascotas()
        {
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/mascota");
            List<Mascota> resultado = new List<Mascota>();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<Mascota>>(content);


            }
            List<MascotaViewModel> mascotas = new List<MascotaViewModel>();

            foreach (var item in resultado)
            {
                mascotas.Add(Convertir(item));
            }

            return mascotas;

        }

        public MascotaViewModel GetMascota(int id)
        {
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/mascota/" + id.ToString());
            Mascota resultado = new Mascota();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<Mascota>(content);
            }

            return Convertir(resultado);

        }



        public MascotaViewModel Remove(int id)
        {
            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/mascota/" + id.ToString());
            Mascota resultado = new Mascota();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }

            return Convertir(resultado);
        }

        public MascotaViewModel Update(MascotaViewModel mascota)
        {
            HttpResponseMessage response = ServiceRepository.PutResponse("api/mascota", Convertir(mascota));


            if (response != null)
            {

                var content = response.Content.ReadAsStringAsync().Result;


            }
            return mascota;
        }
    }
}
