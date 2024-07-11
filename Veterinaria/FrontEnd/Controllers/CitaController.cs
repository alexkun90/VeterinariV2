using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class CitaController : Controller
    {
        ICitaHelper citaHelper;
        IMascotaHelper mascotaHelper;

        public CitaController(ICitaHelper citaHelper,IMascotaHelper mascotaHelper)
        {
            this.citaHelper = citaHelper;
            this.mascotaHelper = mascotaHelper;
        }
        // GET: CitaController
        public ActionResult Index()
        {
           List<CitaViewModel> lista = citaHelper.GetAllCitas();
            return View(lista);
        }

        // GET: CitaController/Details/5
        public ActionResult Details(int id)
        {
            return View(citaHelper.GetCitaId(id));
        }

        // GET: CitaController/Create
        public ActionResult Create()
        {
            CitaViewModel cita = new CitaViewModel();
            cita.Mascotas = mascotaHelper.GetMascotas();
            return View(cita);
        }

        // POST: CitaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CitaViewModel cita)
        {
            try
            {
               citaHelper.AddCita(cita);
               return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CitaController/Edit/5
        public ActionResult Edit(int id)
        {
            CitaViewModel cita = citaHelper.GetCitaId(id);
            cita.Mascotas = mascotaHelper.GetMascotas();
            return View(cita);
        }

        // POST: CitaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CitaViewModel cita)
        {
            try
            {
                _ = citaHelper.EditCita(cita);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CitaController/Delete/5
        public ActionResult Delete(int id)
        {
            CitaViewModel cita = citaHelper.GetCitaId(id);
            return View(cita);
        }

        // POST: CitaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CitaViewModel cita)
        {
            try
            {
                citaHelper.DeleteCita(cita.CitaId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
