using FrontEnd.ApiMoldels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class CitaHelper : ICitaHelper
    {
        IServiceRepository _serviceRepository;
        public CitaHelper(IServiceRepository serviceRepository)
        {
            this._serviceRepository = serviceRepository;
        }

        public CitaViewModel AddCita(CitaViewModel CitaViewModel)
        {
            CitaViewModel cita = new CitaViewModel();
            HttpResponseMessage responseMessage = _serviceRepository.PostResponse("api/Cita", Convertir(CitaViewModel));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }

            return new CitaViewModel { };
        }

        public void DeleteCita(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.DeleteResponse("api/Cita/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }
        }

        public CitaViewModel EditCita(CitaViewModel CitaViewModel)
        {
            CitaViewModel cita = new CitaViewModel();
            HttpResponseMessage responseMessage = _serviceRepository.PutResponse("api/Cita", Convertir(CitaViewModel));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                // var result = JsonConvert.DeserializeObject<bool>(content);
            }

            return new CitaViewModel { };
        }

        public List<CitaViewModel> GetAllCitas()
        {
            List<CitaViewModel> lista = new List<CitaViewModel>();
            List<Cita> result = new List<Cita>();
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/Cita");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<List<Cita>>(content);
            }

            foreach (var item in result)
            {
                lista.Add(Convertir(item));
            }

            return lista; throw new NotImplementedException();
        }

        public CitaViewModel GetCitaId(int id)
        {
            CitaViewModel cita = new CitaViewModel();
            Cita resultado = new Cita();
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/Cita/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<Cita>(content);
            }
            cita = Convertir(resultado);
            return cita;
        }

        private CitaViewModel Convertir(Cita cita)
        {
            return new CitaViewModel
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
        }
        private Cita Convertir(CitaViewModel cita)
        {
            return new Cita
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
        }
    }
}
