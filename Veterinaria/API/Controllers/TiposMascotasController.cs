using BackEnd.Model;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposMascotasController : ControllerBase
    {

        private ITiposMascotasService _tiposMascotasService;
        ILogger<TiposMascotasController> _logger;

        public TiposMascotasController(ITiposMascotasService tiposMascotasService, ILogger<TiposMascotasController> logger)
        {
            this._tiposMascotasService = tiposMascotasService;
            this._logger = logger;
        }

        // GET: api/<TiposMascotasController>
        [HttpGet]
        public IEnumerable<TiposMascotasModel> Get()
        {
            try
            {

                _logger.LogError("Funciona sin error");
                return _tiposMascotasService.Get();

            }
            catch (Exception e)
            {

                _logger.LogError(e.Message);
                throw;


            }
        }

        // GET api/<TiposMascotasController>/5
        [HttpGet("{id}")]
        public TiposMascotasModel Get(int id)
        {
            return _tiposMascotasService.Get(id);
        }

        // POST api/<TiposMascotasController>
        [HttpPost]
        public TiposMascotasModel Post([FromBody] TiposMascotasModel tiposMascotas)
        {
            _tiposMascotasService.Add(tiposMascotas);
            return tiposMascotas;

        }

        // PUT api/<TiposMascotasController>/5
        [HttpPut]
        public TiposMascotasModel Put([FromBody] TiposMascotasModel tiposMascotas)
        {
            _tiposMascotasService.Update(tiposMascotas);
            return tiposMascotas;
        }

        // DELETE api/<TiposMascotasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            TiposMascotasModel tiposMascotas = new TiposMascotasModel { CodigoTipoMascota = id };
            _tiposMascotasService.Remove(tiposMascotas);

        }
    }
}
