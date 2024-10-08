﻿using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    [Authorize(Roles = "Veterinario")]
    public class DesparasitacionesVacunaController : Controller
    {
        IDesparasitacionesVacunaHelper DesparasitacionesVacunaHelper;
        IMascotaHelper MascotaHelper;

        public DesparasitacionesVacunaController(IDesparasitacionesVacunaHelper desparasitacionesVacunaHelper, IMascotaHelper mascotaHelper)
        {
            DesparasitacionesVacunaHelper = desparasitacionesVacunaHelper;
            MascotaHelper = mascotaHelper;
        }

        // GET: DesparasitacionesVacunaController
        public ActionResult Index()
        {
            var desparasitaciones = DesparasitacionesVacunaHelper.GetDesparasitaciones();
            var mascotas = MascotaHelper.GetMascotas();
            
            foreach (var desparasitacion in desparasitaciones)
            {
                desparasitacion.Mascotas = mascotas; 
            }

            return View(desparasitaciones);
        }

        // GET: DesparasitacionesVacunaController/Details/5
        public ActionResult Details(int id)
        {
            DesparasitacionesVacunaViewModel desparasitacionesVacuna = DesparasitacionesVacunaHelper.GetDesparasitaciones(id);
            desparasitacionesVacuna.Mascotas = MascotaHelper.GetMascotas();

            return View(desparasitacionesVacuna);
        }

        // GET: DesparasitacionesVacunaController/Create
        public ActionResult Create()
        {
            DesparasitacionesVacunaViewModel desparasitaciones = new DesparasitacionesVacunaViewModel();
            desparasitaciones.Mascotas = MascotaHelper.GetMascotas();
            return View(desparasitaciones);
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
            desparasitacionesVacuna.Mascotas = MascotaHelper.GetMascotas();
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DesparasitacionesVacunaViewModel model)
        {
            try
            {
                DesparasitacionesVacunaHelper.Remove(model.CodigoDesparasitacionVacuna);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
