using FrontEnd.ApiMoldels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class TiposMascotasHelper : ITiposMascotasHelper
    {
        IServiceRepository ServiceRepository;

        public TiposMascotasHelper(IServiceRepository serviceRepository)
        {
            this.ServiceRepository = serviceRepository;
        }


        private TiposMascotasViewModel Convertir(TiposMascotas tiposMascotas)
        {
            return new TiposMascotasViewModel
            {
              CodigoTipoMascota = tiposMascotas.CodigoTipoMascota,
              NombreTipoMascota = tiposMascotas.NombreTipoMascota
            };
        }


        private TiposMascotas Convertir(TiposMascotasViewModel tiposMascotas)
        {
            return new TiposMascotas
            {
                CodigoTipoMascota = tiposMascotas.CodigoTipoMascota,
                NombreTipoMascota = tiposMascotas.NombreTipoMascota
            };
        }

        public TiposMascotasViewModel Add(TiposMascotasViewModel tiposMascotas)
        {
            HttpResponseMessage response = ServiceRepository.PostResponse("api/tiposMascotas", Convertir(tiposMascotas));


            if (response != null)
            {

                var content = response.Content.ReadAsStringAsync().Result;


            }
            return tiposMascotas;
        }



        public List<TiposMascotasViewModel> GetTiposMascotas()
         {
             HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/tiposMascotas");
            List<TiposMascotas> resultado = new List<TiposMascotas>();

             if (responseMessage!=null)
             {
                 var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<TiposMascotas>>(content);


             }
             List<TiposMascotasViewModel> tiposMascotas = new List<TiposMascotasViewModel>();

            foreach (var item in resultado)
            {   
                tiposMascotas.Add(Convertir(item));
            }

            return tiposMascotas;

         }


        public TiposMascotasViewModel GetTiposMascota(int id)
        {
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/tiposMascotas/" + id.ToString());
            TiposMascotas resultado = new TiposMascotas();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<TiposMascotas>(content);
            }

            return Convertir(resultado);

        }




        

        //public TiposMascotasViewModel Remove(int id)
        //{
        //    HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/tiposMascotas/" + id.ToString());
        //    TiposMascotas resultado = new TiposMascotas();
        //    if (responseMessage != null)
        //    {
        //        var content = responseMessage.Content.ReadAsStringAsync().Result;

        //    }

        //    return Convertir(resultado);
        //}

        public TiposMascotasViewModel Update(TiposMascotasViewModel tiposMascotas)
        {
            HttpResponseMessage response = ServiceRepository.PutResponse("api/tiposMascotas", Convertir(tiposMascotas));


            if (response != null)
            {

                var content = response.Content.ReadAsStringAsync().Result;


            }
            return tiposMascotas;
        }



    }
}
