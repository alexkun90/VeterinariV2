using API.Model;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        private IMascotaService _mascotaService;

        public MascotaController(IMascotaService mascotaService)
        {
            this._mascotaService = mascotaService;
        }

        // GET: api/<DistritoController>
        [HttpGet]
        public IEnumerable<MascotaDTO> Get()
        {
            return _mascotaService.Get();
        }

        // GET api/<DistritoController>/5
        [HttpGet("{id}")]
        public MascotaDTO Get(int id)
        {
            return _mascotaService.Get(id);
        }

        // POST api/<DistritoController>
        [HttpPost]
        public MascotaDTO Post([FromBody] MascotaDTO mascota)
        {
            _mascotaService.Add(mascota);
            return mascota;
        }

        // PUT api/<DistritoController>/5
        [HttpPut]
        public MascotaDTO Put([FromBody] MascotaDTO mascota)
        {
            _mascotaService.Update(mascota);
            return mascota;
        }

        // DELETE api/<DistritoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            MascotaDTO mascota = new MascotaDTO { MascotaId = id };
            _mascotaService.Remove(mascota);
        }
    }
}
