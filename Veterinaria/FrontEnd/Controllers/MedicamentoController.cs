using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class MedicamentoController : Controller
    {
        IMedicamentoHelper MedicamentoHelper;
        ICitaHelper CitaHelper;
        public MedicamentoController(IMedicamentoHelper medicamentoHelper, ICitaHelper citaHelper)
        {
            MedicamentoHelper = medicamentoHelper;
            CitaHelper = citaHelper;
        }
        // GET: MascotaController
        public ActionResult Index()
        {
            var lista = MedicamentoHelper.GetMedicamentos();
            var citas = CitaHelper.GetAllCitas();

            foreach(var item in lista)
            {
                item.Citas = citas;
            }
            return View(lista);
        }

        // GET: MascotaController/Details/5
        public ActionResult Details(int id)
        {
            MedicamentoViewModel medicamento = MedicamentoHelper.GetMedicamento(id);
             medicamento.Citas = CitaHelper.GetAllCitas();

            return View(medicamento);
        }

        // GET: DistritoController/Create
        public ActionResult Create()
        {
            MedicamentoViewModel medicamento = new MedicamentoViewModel();
            medicamento.Citas = CitaHelper.GetAllCitas();

            return View(medicamento);
        }

        // POST: DistritoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MedicamentoViewModel medicamento)
        {
            try
            {
                _ = MedicamentoHelper.Add(medicamento);
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
            MedicamentoViewModel medicamento = MedicamentoHelper.GetMedicamento(id);
            medicamento.Citas = CitaHelper.GetAllCitas();

            return View(medicamento);
        }

        // POST: DistritoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MedicamentoViewModel medicamento)
        {
            try
            {
                _ = MedicamentoHelper.Update(medicamento);
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
            MedicamentoViewModel medicamento = MedicamentoHelper.GetMedicamento(id);
            medicamento.Citas = CitaHelper.GetAllCitas();

            return View(medicamento);
        }

        // POST: DistritoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MedicamentoViewModel medicamento)
        {
            try
            {
                _ = MedicamentoHelper.Remove(medicamento.CodigoMedicamento);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

