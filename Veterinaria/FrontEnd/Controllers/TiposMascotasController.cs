using FrontEnd.ApiMoldels;
using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class TiposMascotasController : Controller
    {
        ITiposMascotasHelper TiposMascotasHelper;

        public TiposMascotasController(ITiposMascotasHelper tiposMascotasHelper)
        {
            TiposMascotasHelper = tiposMascotasHelper;
        }

        // GET: TiposMascotasController
        public ActionResult Index()
        {

            return View(TiposMascotasHelper.GetTiposMascotas());
       
        }

        // GET: TiposMascotasController/Details/5
        public ActionResult Details(int id)
        {
            TiposMascotasViewModel tiposMascotas = TiposMascotasHelper.GetTiposMascota(id);
            return View(tiposMascotas);
        }

        // GET: TiposMascotasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposMascotasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TiposMascotasViewModel tiposMascotas)
        {
            try
            {
                _ = TiposMascotasHelper.Add(tiposMascotas);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TiposMascotasController/Edit/5
        public ActionResult Edit(int id)
        {
            TiposMascotasViewModel tiposMascotas = TiposMascotasHelper.GetTiposMascota(id);
            return View(tiposMascotas);
        }

        // POST: TiposMascotasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TiposMascotasViewModel tiposMascotas)
        {
            try
            {
                _ = TiposMascotasHelper.Update(tiposMascotas);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TiposMascotasController/Delete/5
        public ActionResult Delete(int id)
        {
            TiposMascotasViewModel tiposMascotas = TiposMascotasHelper.GetTiposMascota(id);

            return View(tiposMascotas);
        }

        // POST: TiposMascotasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TiposMascotasViewModel tiposMascotas)
        {
            try
            {
                _ = TiposMascotasHelper.Remove(tiposMascotas.CodigoTipoMascota);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
