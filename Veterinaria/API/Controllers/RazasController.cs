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
    public class RazasController : ControllerBase
    {

        private IRazasService _razasService;
        ILogger<RazasController> _logger;

        public RazasController(IRazasService razasService, ILogger<RazasController> logger)
        {
            this._razasService = razasService;
            this._logger = logger;
        }

        // GET: api/<RazasController>
        [HttpGet]
        public IEnumerable<RazasModel> Get()
        {
            try
            {

                _logger.LogError("Funciona sin error");
                return _razasService.Get();

            }
            catch (Exception e)
            {

                _logger.LogError(e.Message);
                throw;


            }

        }

        // GET api/<RazasController>/5
        [HttpGet("{id}")]
        public RazasModel Get(int id)
        {
            return _razasService.Get(id);
        }

        // POST api/<RazasController>
        [HttpPost]
        public RazasModel Post([FromBody] RazasModel razas)
        {
            _razasService.Add(razas);
            return razas;

        }

        // PUT api/<RazasController>/5
        [HttpPut]
        public RazasModel Put([FromBody] RazasModel razas)
        {
            _razasService.Update(razas);
            return razas;
        }

        // DELETE api/<RazasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            RazasModel razas = new RazasModel { CodigoRaza = id };
            _razasService.Remove(razas);

        }
    }
}
