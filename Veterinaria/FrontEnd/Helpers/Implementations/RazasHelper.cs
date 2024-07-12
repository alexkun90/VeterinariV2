using FrontEnd.ApiMoldels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class RazasHelper : IRazasHelper
    {
        IServiceRepository ServiceRepository;

        public RazasHelper(IServiceRepository serviceRepository)
        {
            this.ServiceRepository = serviceRepository;
        }


        private RazasViewModel Convertir(Razas razas)
        {
            return new RazasViewModel
            {
                CodigoRaza = razas.CodigoRaza,
                NombreRaza = razas.NombreRaza,
                TipoMascotaID = razas.TipoMascotaID
            };
        }


        private Razas Convertir(RazasViewModel razas)
        {
            return new Razas
            {
                CodigoRaza = razas.CodigoRaza,
                NombreRaza = razas.NombreRaza,
                TipoMascotaID = razas.TipoMascotaID
            };
        }

        public RazasViewModel Add(RazasViewModel razas)
        {
            HttpResponseMessage response = ServiceRepository.PostResponse("api/razas", Convertir(razas));


            if (response != null)
            {

                var content = response.Content.ReadAsStringAsync().Result;


            }
            return razas;
        }



        public List<RazasViewModel> GetRazas()
         {
             HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/razas");
            List<Razas> resultado = new List<Razas>();

             if (responseMessage!=null)
             {
                 var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<Razas>>(content);


             }
             List<RazasViewModel> razas = new List<RazasViewModel>();

            foreach (var item in resultado)
            {   
                razas.Add(Convertir(item));
            }

            return razas;

         }


        public RazasViewModel GetRaza(int id)
        {
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/razas/" + id.ToString());
            Razas resultado = new Razas();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<Razas>(content);
            }

            return Convertir(resultado);

        }




        

        public RazasViewModel Remove(int id)
        {
            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/razas/" + id.ToString());
            Razas resultado = new Razas();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }

            return Convertir(resultado);
        }

        public RazasViewModel Update(RazasViewModel razas)
        {
            HttpResponseMessage response = ServiceRepository.PutResponse("api/razas", Convertir(razas));


            if (response != null)
            {

                var content = response.Content.ReadAsStringAsync().Result;


            }
            return razas;
        }



    }
}
