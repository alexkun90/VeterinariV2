using API.Model;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentoController : ControllerBase
    {
        private IMedicamentoService _medicamentoService;

        public MedicamentoController(IMedicamentoService medicamentoService)
        {
            this._medicamentoService = medicamentoService;
        }

        // GET: api/<DistritoController>
        [HttpGet]
        public IEnumerable<MedicamentoDTO> Get()
        {
            return _medicamentoService.Get();
        }

        // GET api/<DistritoController>/5
        [HttpGet("{id}")]
        public MedicamentoDTO Get(int id)
        {
            return _medicamentoService.Get(id);
        }

        // POST api/<DistritoController>
        [HttpPost]
        public MedicamentoDTO Post([FromBody] MedicamentoDTO medicamento)
        {
            _medicamentoService.Add(medicamento);
            return medicamento;
        }

        // PUT api/<DistritoController>/5
        [HttpPut]
        public MedicamentoDTO Put([FromBody] MedicamentoDTO medicamento)
        {
            _medicamentoService.Update(medicamento);
            return medicamento;
        }

        // DELETE api/<DistritoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            MedicamentoDTO medicamento = new MedicamentoDTO { CodigoMedicamento = id };
            _medicamentoService.Remove(medicamento);
        }
    }
}
