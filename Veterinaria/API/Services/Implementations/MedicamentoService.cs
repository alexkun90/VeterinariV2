using API.Model;
using API.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;


namespace API.Services.Implementations
{
    public class MedicamentoService : IMedicamentoService
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private IMedicamentoDAL MedicamentoDAL;

        private Medicamento Convertir(MedicamentoDTO Medicamento)
        {

            Medicamento entity = new Medicamento
            {
                CodigoMedicamento = Medicamento.CodigoMedicamento,
                NombreMedicamento = Medicamento.NombreMedicamento,
                Dosis = Medicamento.Dosis,
                CitaId = Medicamento.CitaId


            };
            return entity;

        }

        private MedicamentoDTO Convertir(Medicamento Medicamento)
        {

            MedicamentoDTO entity = new MedicamentoDTO
            {
                CodigoMedicamento = Medicamento.CodigoMedicamento,
                NombreMedicamento = Medicamento.NombreMedicamento,
                Dosis = Medicamento.Dosis,
                CitaId = Medicamento.CitaId


            };
            return entity;

        }

        public bool Add(MedicamentoDTO Medicamento)
        {
            _unidadDeTrabajo.MedicamentoDAL.Add(Convertir(Medicamento));
            return _unidadDeTrabajo.Complete();
        }

        public bool Remove(MedicamentoDTO Medicamento)
        {
            _unidadDeTrabajo.MedicamentoDAL.Remove(Convertir(Medicamento));
            return _unidadDeTrabajo.Complete();
        }

        public bool Update(MedicamentoDTO Medicamento)
        {
            _unidadDeTrabajo.MedicamentoDAL.Update(Convertir(Medicamento));
            return _unidadDeTrabajo.Complete();
        }

        public MedicamentoDTO Get(int id)
        {
            return Convertir(_unidadDeTrabajo.MedicamentoDAL.Get(id));
        }

        public IEnumerable<MedicamentoDTO> Get()
        {
            var lista = _unidadDeTrabajo.MedicamentoDAL.GetAll();
            List<MedicamentoDTO> Medicamento = new List<MedicamentoDTO>();
            foreach (var item in lista)
            {
                Medicamento.Add(Convertir(item));
            }
            return Medicamento;
        }

        public MedicamentoService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this._unidadDeTrabajo = unidadDeTrabajo;
        }
    }
}
