using FrontEnd.ApiMoldels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class PadecimientosHelper : IPadecimientosHelper
    {
        IServiceRepository ServiceRepository;

        public PadecimientosHelper(IServiceRepository serviceRepository)
        {
            this.ServiceRepository = serviceRepository;
        }

        public PadecimientosViewModel Add(PadecimientosViewModel padecimientos)
        {
            HttpResponseMessage response = ServiceRepository.PostResponse("api/padecimientos", Convertir(padecimientos));


            if (response != null)
            {

                var content = response.Content.ReadAsStringAsync().Result;


            }
            return padecimientos;
        }


        private PadecimientosViewModel Convertir(Padecimientos padecimientos)
        {
            return new PadecimientosViewModel
            {
                CodigoPadecimiento = padecimientos.CodigoPadecimiento,
                NombrePadecimiento = padecimientos.NombrePadecimiento,
                MascotaID = padecimientos.MascotaID
            };
        }


        private Padecimientos Convertir(PadecimientosViewModel padecimientos)
        {
            return new Padecimientos
            {
                CodigoPadecimiento = padecimientos.CodigoPadecimiento,
                NombrePadecimiento = padecimientos.NombrePadecimiento,
                MascotaID = padecimientos.MascotaID
            };
        }


        public List<PadecimientosViewModel> GetPadecimientos()
         {
             HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/padecimientos");
            List<Padecimientos> resultado = new List<Padecimientos>();

             if (responseMessage!=null)
             {
                 var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<Padecimientos>>(content);


             }
             List<PadecimientosViewModel> padecimiento = new List<PadecimientosViewModel>();

            foreach (var item in resultado)
            {   
                padecimiento.Add(Convertir(item));
            }

            return padecimiento;

         }


        public PadecimientosViewModel GetPadecimiento(int id)
        {
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/padecimientos/" + id.ToString());
            Padecimientos resultado = new Padecimientos();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<Padecimientos>(content);
            }

            return Convertir(resultado);

        }


        public PadecimientosViewModel Remove(int id)
        {
            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/padecimientos/" + id.ToString());
            Padecimientos resultado = new Padecimientos();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }

            return Convertir(resultado);
        }

        public PadecimientosViewModel Update(PadecimientosViewModel padecimientos)
        {
            HttpResponseMessage response = ServiceRepository.PutResponse("api/padecimientos", Convertir(padecimientos));


            if (response != null)
            {

                var content = response.Content.ReadAsStringAsync().Result;


            }
            return padecimientos;
        }

       
    }
}
