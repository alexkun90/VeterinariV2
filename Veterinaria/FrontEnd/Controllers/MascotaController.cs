using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class MascotaController : Controller
    {
        IMascotaHelper MascotaHelper;
        IRazasHelper RazaHelper;
        ITiposMascotasHelper TipoMascotaHelper;

        public MascotaController(IMascotaHelper mascotaHelper, IRazasHelper razaHelper, ITiposMascotasHelper tipoMascotaHelper)
        {
            MascotaHelper = mascotaHelper;
            RazaHelper = razaHelper;
            TipoMascotaHelper = tipoMascotaHelper;
        }
        // GET: MascotaController
        public ActionResult Index()
        {
            List<MascotaViewModel> lista = MascotaHelper.GetMascotas();

            foreach (var item in lista)
            {
                if (item.TipoMascotaId.HasValue)
                {
                    item.TipoMascota = TipoMascotaHelper.GetTiposMascota((int)item.TipoMascotaId);
                }
                else
                {
                    // Cuando TipoMascotaId asigna un valor null
                    item.TipoMascota = null; 
                }

                if (item.RazaId.HasValue)
                {
                    item.Raza = RazaHelper.GetRaza((int)item.RazaId);
                }
                else
                {
                    // Cuando RazaId asigna un valor null
                    item.Raza = null; 
                }
            }

            return View(lista);
        }


        // GET: MascotaController/Details/5
        public ActionResult Details(int id)
        {
            MascotaViewModel mascota = MascotaHelper.GetMascota(id);
            mascota.Razas = RazaHelper.GetRazas();
            mascota.TiposMascotas = TipoMascotaHelper.GetTiposMascotas();
            return View(mascota);
        }

        // GET: DistritoController/Create
        public ActionResult Create()
        {
            MascotaViewModel mascota = new MascotaViewModel();
            mascota.Razas = RazaHelper.GetRazas();
            mascota.TiposMascotas = TipoMascotaHelper.GetTiposMascotas();
            return View(mascota);
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
            mascota.Razas = RazaHelper.GetRazas();
            mascota.TiposMascotas = TipoMascotaHelper.GetTiposMascotas();
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
            mascota.Razas = RazaHelper.GetRazas();
            mascota.TiposMascotas = TipoMascotaHelper.GetTiposMascotas();
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
