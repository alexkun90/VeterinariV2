
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class PadecimientosController : Controller
    {
        IPadecimientosHelper PadecimientosHelper;

        public PadecimientosController(IPadecimientosHelper padecimientosHelper)
        {
            PadecimientosHelper = padecimientosHelper;
        }

        // GET: PadecimientosController
        public ActionResult Index()
        {

            return View(PadecimientosHelper.GetPadecimientos());
        }

        // GET: PadecimientosController/Details/5
        public ActionResult Details(int id)
        {
            PadecimientosViewModel padecimientos = PadecimientosHelper.GetPadecimiento(id);
            return View(padecimientos);
        }

        // GET: PadecimientosController/Create
        public ActionResult Create()
        {
            return View();
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
