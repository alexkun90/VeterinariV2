using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class DesparasitacionesVacunaController : Controller
    {
        IDesparasitacionesVacunaHelper DesparasitacionesVacunaHelper;

        public DesparasitacionesVacunaController(IDesparasitacionesVacunaHelper desparasitacionesVacunaHelper)
        {
            DesparasitacionesVacunaHelper = desparasitacionesVacunaHelper;
        }

        // GET: DesparasitacionesVacunaController
        public ActionResult Index()
        {

            return View(DesparasitacionesVacunaHelper.GetDesparasitaciones());
        }

        // GET: DesparasitacionesVacunaController/Details/5
        public ActionResult Details(int id)
        {
            DesparasitacionesVacunaViewModel desparasitacionesVacuna = DesparasitacionesVacunaHelper.GetDesparasitaciones(id);
            return View(desparasitacionesVacuna);
        }

        // GET: DesparasitacionesVacunaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DesparasitacionesVacunaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DesparasitacionesVacunaViewModel desparasitacionesVacuna)
        {
            try
            {
                _ = DesparasitacionesVacunaHelper.Add(desparasitacionesVacuna);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DesparasitacionesVacunaController/Edit/5
        public ActionResult Edit(int id)
        {
            DesparasitacionesVacunaViewModel desparasitacionesVacuna = DesparasitacionesVacunaHelper.GetDesparasitaciones(id);
            return View(desparasitacionesVacuna);
        }

        // POST: DesparasitacionesVacunaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DesparasitacionesVacunaViewModel desparasitacionesVacuna)
        {
            try
            {
                _ = DesparasitacionesVacunaHelper.Update(desparasitacionesVacuna);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DesparasitacionesVacunaController/Delete/5
        public ActionResult Delete(int id)
        {
            DesparasitacionesVacunaViewModel desparasitacionesVacuna = DesparasitacionesVacunaHelper.GetDesparasitaciones(id);
            return View(desparasitacionesVacuna);
        }

        // POST: DesparasitacionesVacunaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DesparasitacionesVacunaViewModel desparasitacionesVacuna)
        {
            try
            {
                _ = DesparasitacionesVacunaHelper.Remove(desparasitacionesVacuna.CodigoDesparasitacionVacuna);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
