using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
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
            UsuarioViewModel usuario = usuarioHelper.GetUsuarioId(id);
            return View(usuario);
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
    }
}
