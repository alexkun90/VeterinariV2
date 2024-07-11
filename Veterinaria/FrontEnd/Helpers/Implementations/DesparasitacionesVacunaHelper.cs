using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class DesparasitacionesVacunaHelper : IDesparasitacionesVacunaHelper
    {
        IServiceRepository ServiceRepository;

        public DesparasitacionesVacunaHelper(IServiceRepository serviceRepository)
        {
            this.ServiceRepository = serviceRepository;
        }


        public DesparasitacionesVacunaViewModel Add(DesparasitacionesVacunaViewModel desparasitacionesVacuna)
        {
            HttpResponseMessage response = ServiceRepository.PostResponse("api/desparasitacionesVacuna", Convertir(desparasitacionesVacuna));


            if (response != null)
            {

                var content = response.Content.ReadAsStringAsync().Result;


            }
            return desparasitacionesVacuna;
        }

        private DesparasitacionesVacunaViewModel Convertir(DesparasitacionesVacuna desparasitacionesVacuna)
        {
            return new DesparasitacionesVacunaViewModel
            {
                CodigoDesparasitacionVacuna = desparasitacionesVacuna.CodigoDesparasitacionVacuna,
                Tipo = desparasitacionesVacuna.Tipo,
                Fecha = desparasitacionesVacuna.Fecha,
                Producto = desparasitacionesVacuna.Producto,
                MascotaId = desparasitacionesVacuna.MascotaId

            };
        }


        private DesparasitacionesVacuna Convertir(DesparasitacionesVacunaViewModel desparasitacionesVacuna)
        {
            return new DesparasitacionesVacuna
            {
                CodigoDesparasitacionVacuna = desparasitacionesVacuna.CodigoDesparasitacionVacuna,
                Tipo = desparasitacionesVacuna.Tipo,
                Fecha = desparasitacionesVacuna.Fecha,
                Producto = desparasitacionesVacuna.Producto,
                MascotaId = desparasitacionesVacuna.MascotaId
            };
        }


        public List<DesparasitacionesVacunaViewModel> GetDesparasitaciones()
        {
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/desparasitacionesVacuna");
            List<DesparasitacionesVacuna> resultado = new List<DesparasitacionesVacuna>();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<DesparasitacionesVacuna>>(content);


            }
            List<DesparasitacionesVacunaViewModel> desparasitacionesVacunas = new List<DesparasitacionesVacunaViewModel>();

            foreach (var item in resultado)
            {
                desparasitacionesVacunas.Add(Convertir(item));
            }

            return desparasitacionesVacunas;

        }

        public DesparasitacionesVacunaViewModel GetDesparasitaciones(int id)
        {
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/desparasitacionesVacuna/" + id.ToString());
            DesparasitacionesVacuna resultado = new DesparasitacionesVacuna();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<DesparasitacionesVacuna>(content);
            }

            return Convertir(resultado);

        }



        public DesparasitacionesVacunaViewModel Remove(int id)
        {
            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/desparasitacionesVacuna/" + id.ToString());
            DesparasitacionesVacuna resultado = new DesparasitacionesVacuna();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }

            return Convertir(resultado);
        }

        public DesparasitacionesVacunaViewModel Update(DesparasitacionesVacunaViewModel desparasitacionesVacuna)
        {
            HttpResponseMessage response = ServiceRepository.PutResponse("api/desparasitacionesVacuna", Convertir(desparasitacionesVacuna));


            if (response != null)
            {

                var content = response.Content.ReadAsStringAsync().Result;


            }
            return desparasitacionesVacuna;
        }
    }
}
