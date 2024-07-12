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


        public RazasController(IRazasService razasService)
        {
            this._razasService = razasService;
        }

        // GET: api/<RazasController>
        [HttpGet]
        public IEnumerable<RazasModel> Get()
        {
            return _razasService.Get();
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
