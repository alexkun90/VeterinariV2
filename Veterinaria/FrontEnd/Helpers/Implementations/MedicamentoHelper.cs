
using FrontEnd.ApiMoldels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class MedicamentoHelper : IMedicamentoHelper
    {
        IServiceRepository ServiceRepository;

        public MedicamentoHelper(IServiceRepository serviceRepository)
        {
            this.ServiceRepository = serviceRepository;
        }


        public MedicamentoViewModel Add(MedicamentoViewModel medicamento)
        {
            HttpResponseMessage response = ServiceRepository.PostResponse("api/medicamento", Convertir(medicamento));


            if (response != null)
            {

                var content = response.Content.ReadAsStringAsync().Result;


            }
            return medicamento;
        }

        private MedicamentoViewModel Convertir(Medicamento medicamento)
        {
            return new MedicamentoViewModel
            {
                CodigoMedicamento = medicamento.CodigoMedicamento,
                NombreMedicamento = medicamento.NombreMedicamento,
                Dosis = medicamento.Dosis,
                CitaId = medicamento.CitaId
            };
        }


        private Medicamento Convertir(MedicamentoViewModel medicamento)
        {
            return new Medicamento
            {
                CodigoMedicamento = medicamento.CodigoMedicamento,
                NombreMedicamento = medicamento.NombreMedicamento,
                Dosis = medicamento.Dosis,
                CitaId = medicamento.CitaId
            };
        }


        public List<MedicamentoViewModel> GetMedicamentos()
        {
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/medicamento");
            List<Medicamento> resultado = new List<Medicamento>();

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<Medicamento>>(content);


            }
            List<MedicamentoViewModel> medicamento = new List<MedicamentoViewModel>();

            foreach (var item in resultado)
            {
                medicamento.Add(Convertir(item));
            }

            return medicamento;

        }

        public MedicamentoViewModel GetMedicamento(int id)
        {
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/medicamento/" + id.ToString());
            Medicamento resultado = new Medicamento();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<Medicamento>(content);
            }

            return Convertir(resultado);

        }



        public MedicamentoViewModel Remove(int id)
        {
            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/medicamento/" + id.ToString());
            Medicamento resultado = new Medicamento();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }

            return Convertir(resultado);
        }

        public MedicamentoViewModel Update(MedicamentoViewModel medicamento)
        {
            HttpResponseMessage response = ServiceRepository.PutResponse("api/medicamento", Convertir(medicamento));


            if (response != null)
            {

                var content = response.Content.ReadAsStringAsync().Result;


            }
            return medicamento;
        }
    }
}

