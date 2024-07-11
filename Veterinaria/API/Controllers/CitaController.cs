using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Entities;
using API.Services.Interfaces;
using API.Model;
using API.Services.Implementations;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private ICitaService _citaService;

        public CitaController(ICitaService citaService)
        {
            this._citaService = citaService;
        }

        // GET: api/Cita
        [HttpGet]
        public ActionResult GetCitas()
        {
            IEnumerable<CitaDTO> result = _citaService.Get();
            return new JsonResult(result);
        }

        // GET: api/Cita/5
        [HttpGet("{id}")]
        public ActionResult GetCita(int id)
        {
            CitaDTO result = _citaService.Get(id);
            return new JsonResult(result);
        }

        // POST: api/Cita
        [HttpPost]
        public ActionResult PostCita([FromBody] CitaDTO cita)
        {
            var result = _citaService.Add(cita);
            return new JsonResult(result);
        }

        // PUT: api/Cita/5
        [HttpPut]
        public ActionResult PutCita([FromBody] CitaDTO cita)
        {
            var result = _citaService.Update(cita);
            return new JsonResult(result);
        }

        

        // DELETE: api/Cita/5
        [HttpDelete("{id}")]
        public ActionResult DeleteCita(int id)
        {
            var result = _citaService.Remove(id);
            return new JsonResult(result);
        }
    }
}
