using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    [Authorize]
    public class MascotaController : Controller
    {
        IMascotaHelper MascotaHelper;
        IRazasHelper RazaHelper;
        ITiposMascotasHelper TipoMascotaHelper;
        IUsuarioHelper UsuarioHelper;

        public MascotaController(IMascotaHelper mascotaHelper, IRazasHelper razaHelper, ITiposMascotasHelper tipoMascotaHelper, IUsuarioHelper usuarioHelper)
        {
            MascotaHelper = mascotaHelper;
            RazaHelper = razaHelper;
            TipoMascotaHelper = tipoMascotaHelper;
            UsuarioHelper = usuarioHelper;
        }
        // GET: MascotaController
        public ActionResult Index()
        {
            

            var mascotas = MascotaHelper.GetMascotas();
            var razas = RazaHelper.GetRazas();
            var tiposMascotas = TipoMascotaHelper.GetTiposMascotas();
            var usuarios = UsuarioHelper.GetAllUsuarios();

            foreach (var item in mascotas)
            {

                item.TiposMascotas = tiposMascotas;
                item.Razas = razas;
                item.Usuarios = usuarios;
            }
              

            return View(mascotas);
        }


        // GET: MascotaController/Details/5
        public ActionResult Details(int id)
        {
            MascotaViewModel mascota = MascotaHelper.GetMascota(id);
            mascota.Razas = RazaHelper.GetRazas();
            mascota.TiposMascotas = TipoMascotaHelper.GetTiposMascotas();
            mascota.Usuarios = UsuarioHelper.GetAllUsuarios();

            return View(mascota);
        }

        // GET: DistritoController/Create
        public ActionResult Create()
        {
            MascotaViewModel mascota = new MascotaViewModel();
            mascota.Razas = RazaHelper.GetRazas();
            mascota.TiposMascotas = TipoMascotaHelper.GetTiposMascotas();
            mascota.Usuarios = UsuarioHelper.GetAllUsuarios();
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
            mascota.Usuarios = UsuarioHelper.GetAllUsuarios();

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
            mascota.Usuarios = UsuarioHelper.GetAllUsuarios();
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
