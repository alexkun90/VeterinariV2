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
    public class PadecimientosController : ControllerBase
    {

        private IPadecimientosService _padecimientosService;


        public PadecimientosController(IPadecimientosService padecimientosService)
        {
            this._padecimientosService = padecimientosService;
        }

        // GET: api/<PadecimientosController>
        [HttpGet]
        public IEnumerable<PadecimientosModel> Get()
        {
            return _padecimientosService.Get();
        }

        // GET api/<PadecimientosController>/5
        [HttpGet("{id}")]
        public PadecimientosModel Get(int id)
        {
            return _padecimientosService.Get(id);
        }

        // POST api/<PadecimientosController>
        [HttpPost]
        public PadecimientosModel Post([FromBody] PadecimientosModel padecimientos)
        {
            _padecimientosService.Add(padecimientos);
            return padecimientos;

        }

        // PUT api/<PadecimientosController>/5
        [HttpPut]
        public PadecimientosModel Put([FromBody] PadecimientosModel padecimientos)
        {
            _padecimientosService.Update(padecimientos);
            return padecimientos;
        }

        // DELETE api/<PadecimientosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            PadecimientosModel padecimientos = new PadecimientosModel { CodigoPadecimiento = id };
            _padecimientosService.Remove(padecimientos);

        }
    }
}
