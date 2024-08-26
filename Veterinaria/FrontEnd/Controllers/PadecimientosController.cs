
using FrontEnd.ApiMoldels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    [Authorize(Roles = "Veterinario")]
    public class PadecimientosController : Controller
    {
        IPadecimientosHelper PadecimientosHelper;
        IMascotaHelper MascotaHelper;

        public PadecimientosController(IPadecimientosHelper padecimientosHelper, IMascotaHelper mascotaHelper)
        {
            PadecimientosHelper = padecimientosHelper;
            MascotaHelper = mascotaHelper;
        }

        // GET: PadecimientosController
        public ActionResult Index()
        {
            var padecimientos = PadecimientosHelper.GetPadecimientos();
            var mascotas = MascotaHelper.GetMascotas();

            foreach (var item in padecimientos)
            {
                item.Mascotas = mascotas;
            }

            return View(padecimientos);
        }

        // GET: PadecimientosController/Details/5
        public ActionResult Details(int id)
        {
            PadecimientosViewModel padecimientos = PadecimientosHelper.GetPadecimiento(id);
            padecimientos.Mascotas = MascotaHelper.GetMascotas();
            return View(padecimientos);
        }

        // GET: PadecimientosController/Create
        public ActionResult Create()
        {
            PadecimientosViewModel padecimiento = new PadecimientosViewModel();
            padecimiento.Mascotas = MascotaHelper.GetMascotas();

            return View(padecimiento);
        }

        // POST: PadecimientosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PadecimientosViewModel padecimientos)
        {
            try
            {
                _ = PadecimientosHelper.Add(padecimientos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PadecimientosController/Edit/5
        public ActionResult Edit(int id)
        {
           PadecimientosViewModel padecimientos = PadecimientosHelper.GetPadecimiento(id);
            padecimientos.Mascotas = MascotaHelper.GetMascotas();

            return View(padecimientos);
        }

        // POST: PadecimientosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PadecimientosViewModel padecimientos)
        {
            try
            {
                _ = PadecimientosHelper.Update(padecimientos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PadecimientosController/Delete/5
        public ActionResult Delete(int id)
        {
            PadecimientosViewModel padecimientos = PadecimientosHelper.GetPadecimiento(id);
            padecimientos.Mascotas = MascotaHelper.GetMascotas();

            return View(padecimientos);
        }

        // POST: PadecimientosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PadecimientosViewModel padecimientos)
        {
            try
            {
                _ = PadecimientosHelper.Remove(padecimientos.CodigoPadecimiento);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
