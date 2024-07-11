using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class MascotaController : Controller
    {
        IMascotaHelper MascotaHelper;
        //IRazaHelper RazaHelper;
        //ITipoMascota TipoMascota;

        public MascotaController(IMascotaHelper mascotaHelper)
        {
            this.MascotaHelper = mascotaHelper;
        }
        // GET: MascotaController
        public ActionResult Index()
        {
            List<MascotaViewModel> lista = MascotaHelper.GetMascotas();

            return View(MascotaHelper.GetMascotas());
        }

        // GET: MascotaController/Details/5
        public ActionResult Details(int id)
        {
            MascotaViewModel mascota = MascotaHelper.GetMascota(id);
            return View(mascota);
        }

        // GET: DistritoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DistritoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MascotaViewModel mascota)
        {
            try
            {
                _ = MascotaHelper.Add(mascota);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DistritoController/Edit/5
        public ActionResult Edit(int id)
        {
            MascotaViewModel mascota = MascotaHelper.GetMascota(id);
            return View(mascota);
        }

        // POST: DistritoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MascotaViewModel mascota)
        {
            try
            {
                _ = MascotaHelper.Update(mascota);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DistritoController/Delete/5
        public ActionResult Delete(int id)
        {
            MascotaViewModel mascota = MascotaHelper.GetMascota(id);
            return View(mascota);
        }

        // POST: DistritoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MascotaViewModel mascota)
        {
            try
            {
                _ = MascotaHelper.Remove(mascota.MascotaId);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
