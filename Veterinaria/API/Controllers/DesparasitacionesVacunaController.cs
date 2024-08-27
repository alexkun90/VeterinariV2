using API.Model;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesparasitacionesVacunaController : ControllerBase
    {
        private IDesparasitacionesVacunaService _vacunaService;
        ILogger<DesparasitacionesVacunaController> _logger;

        public DesparasitacionesVacunaController(IDesparasitacionesVacunaService vacunaService, ILogger<DesparasitacionesVacunaController> logger)
        {
            this._vacunaService = vacunaService;
            this._logger = logger;
        }

        // GET: api/<DesparasitacionesVacunaController>
        [HttpGet]
        public IEnumerable<DesparasitacionesVacunaDTO> Get()
        {
            try
            {

                _logger.LogError("Prueba");
                return _vacunaService.Get();

            }
            catch (Exception e)
            {

                _logger.LogError(e.Message);
                throw;


            }

        }

        // GET api/<DesparasitacionesVacunaController>/5
        [HttpGet("{id}")]
        public DesparasitacionesVacunaDTO Get(int id)
        {
            return _vacunaService.Get(id);
        }

        // POST api/<DesparasitacionesVacunaController>
        [HttpPost]
        public DesparasitacionesVacunaDTO Post([FromBody] DesparasitacionesVacunaDTO vacuna)
        {
            _vacunaService.Add(vacuna);
            return vacuna;

        }

        // PUT api/<DesparasitacionesVacunaController>/5
        [HttpPut]
        public DesparasitacionesVacunaDTO Put([FromBody] DesparasitacionesVacunaDTO vacuna)
        {
            _vacunaService.Update(vacuna);
            return vacuna;
        }

        // DELETE api/<DesparasitacionesVacunaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DesparasitacionesVacunaDTO vacuna = new DesparasitacionesVacunaDTO { CodigoDesparasitacionVacuna = id };
            _vacunaService.Remove(vacuna);

        }
    }
}