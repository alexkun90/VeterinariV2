

using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace FrontEnd.Controllers
{
    [Authorize(Roles = "Admin , Veterinario")]
    public class RazasController : Controller
    {
        IRazasHelper RazasHelper;
        ITiposMascotasHelper TipoMascotaHelper;
        public RazasController(IRazasHelper razasHelper, ITiposMascotasHelper tipoMascotaHelper)
        {
            RazasHelper = razasHelper;
            TipoMascotaHelper = tipoMascotaHelper;
        }

        // GET: RazasController
        public ActionResult Index()
        {
            var lista = RazasHelper.GetRazas();
            var tipoMascotas = TipoMascotaHelper.GetTiposMascotas();
            foreach (var item in lista)
            {
               item.TiposMascotas = tipoMascotas;
            }
                return View(lista);
        }

        // GET: RazasController/Details/5
        public ActionResult Details(int id)
        {
            RazasViewModel razas = RazasHelper.GetRaza(id);
            razas.TiposMascotas = TipoMascotaHelper.GetTiposMascotas();
            return View(razas);
        }

        // GET: RazasController/Create
        public ActionResult Create()
        {
            RazasViewModel razas = new RazasViewModel();
            razas.TiposMascotas = TipoMascotaHelper.GetTiposMascotas();
            return View(razas);
        }

        // POST: RazasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RazasViewModel raza)
        {
            try
            {
               

                _ =RazasHelper.Add(raza);
            
               
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RazasController/Edit/5
        public ActionResult Edit(int id)
        {
            RazasViewModel razas = RazasHelper.GetRaza(id);
            razas.TiposMascotas = TipoMascotaHelper.GetTiposMascotas();
            return View(razas);
        }

        // POST: RazasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RazasViewModel razas)
        {
            try
            {
                _ = RazasHelper.Update(razas);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RazasViewModel model)
        {
            try
            {
                RazasHelper.Remove(model.CodigoRaza);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
