using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FrontEnd.Controllers
{
    public class UsuarioController : Controller
    {
        IUsuarioHelper usuarioHelper;
        public UsuarioController(IUsuarioHelper usuarioHelper)
        {
            this.usuarioHelper = usuarioHelper;
        }
        public IActionResult Index()
        {
            List<UsuarioViewModel> lista = usuarioHelper.GetAllUsuarios();
            return View(lista);
        }

        public ActionResult Details(string id)
        {
            return View(usuarioHelper.GetUsuarioId(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel model)
        {
            try
            {
                usuarioHelper.AddUsuario(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(string id)
        {
            var user = usuarioHelper.GetUsuarioId(id);
            var availableRoles = new List<string> { "User", "Admin", "Veterinario" };
            user.AvailableRoles = availableRoles;
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, UsuarioViewModel model)
        {
            try
            {
                usuarioHelper.EditUsuario(id, model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UsuarioViewModel model)
        {
            try
            {
                usuarioHelper.DeleteUsuario(model.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
