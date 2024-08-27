using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FrontEnd.Controllers
{
    [Authorize]
    public class CitaController : Controller
    {
        ICitaHelper citaHelper;
        IMascotaHelper mascotaHelper;
        IUsuarioHelper UsuarioHelper;


        public CitaController(ICitaHelper citaHelper,IMascotaHelper mascotaHelper, IUsuarioHelper usuarioHelper)
        {
            this.citaHelper = citaHelper;
            UsuarioHelper = usuarioHelper;
            this.mascotaHelper = mascotaHelper;
        }
        // GET: CitaController

        [Authorize(Roles = "Veterinario, User, Admin")]
        public ActionResult Index()
        {
            var lista = citaHelper.GetAllCitas();
            var usuarios = UsuarioHelper.GetAllUsuarios();
            var mascotas = mascotaHelper.GetMascotas();

            foreach (var item in lista)
            {
                item.Usuarios = usuarios;
                item.Mascotas = mascotas;
            }

            return View(lista);
        }


        //[Authorize(Roles = "User")]
        public ActionResult IndexCliente()
        {
            var lista = citaHelper.GetAllCitas();
            var usuarios = UsuarioHelper.GetAllUsuarios();
            var mascotas = mascotaHelper.GetMascotas();

            foreach (var item in lista)
            {
                item.Usuarios = usuarios;
                item.Mascotas = mascotas;
            }

            return View(lista);
        }
    

        // GET: CitaController/Details/5
        public ActionResult Details(int id)
        {
            CitaViewModel citaViewModel = citaHelper.GetCitaId(id);
            citaViewModel.Mascotas = mascotaHelper.GetMascotas();
            citaViewModel.Usuarios = UsuarioHelper.GetAllUsuarios();

            return View(citaViewModel);
        }

        // GET: CitaController/Create
        public ActionResult Create()
        {
            CitaViewModel cita = new CitaViewModel();

            cita.Mascotas = mascotaHelper.GetMascotas();
            var todosLosUsuarios = UsuarioHelper.GetAllUsuarios();

            var veterinarios = todosLosUsuarios
            .Where(u => u.Roles != null && u.Roles.Contains("Veterinario"))
            .ToList();

            cita.Usuarios = veterinarios;

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
            var todosLosUsuarios = UsuarioHelper.GetAllUsuarios();

            var veterinarios = todosLosUsuarios
            .Where(u => u.Roles != null && u.Roles.Contains("Veterinario"))
            .ToList();

            cita.Usuarios = veterinarios;

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
            CitaViewModel citaViewModel = citaHelper.GetCitaId(id);
            citaViewModel.Mascotas = mascotaHelper.GetMascotas();
            citaViewModel.Usuarios = UsuarioHelper.GetAllUsuarios();

            return View(citaViewModel);
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CitaViewModel model)
        {
            try
            {
                citaHelper.DeleteCita(model.CitaId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
