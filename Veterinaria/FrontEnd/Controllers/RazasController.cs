

using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace FrontEnd.Controllers
{
    public class RazasController : Controller
    {
        IRazasHelper RazasHelper;

        public RazasController(IRazasHelper razasHelper)
        {
            this.RazasHelper = razasHelper;
        }

        // GET: RazasController
        public ActionResult Index()
        {
            return View(RazasHelper.GetRazas());
        }

        // GET: RazasController/Details/5
        public ActionResult Details(int id)
        {
            RazasViewModel razas = RazasHelper.GetRaza(id);
            return View(razas);
        }

        // GET: RazasController/Create
        public ActionResult Create()
        {
            return View();
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

        // GET: RazasController/Delete/5
        public ActionResult Delete(int id)

        {
            RazasViewModel razas = RazasHelper.GetRaza(id);
            return View(razas);
        }

        // POST: RazasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RazasViewModel razas)
        {
            try
            {
                _ = RazasHelper.Remove(razas.CodigoRaza);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
