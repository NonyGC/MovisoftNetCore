using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movisoft.Aplication.DTO;
using Movisoft.Aplication.Interface;

namespace Movisoft.MVC.Areas.Equipamiento.Controllers
{
    [Area("Equipamiento")]
    public class SeequipoController : Controller
    {
        private readonly ISeequipoAppService _equipoAppService;
        private readonly ISetipequipoAppService _setipequipoAppService;

        public SeequipoController(ISeequipoAppService equipamientoAppService, ISetipequipoAppService setipequipoAppService)
        {
            _equipoAppService = equipamientoAppService;
            _setipequipoAppService = setipequipoAppService;
        }

        // GET: Seequipo
        public ActionResult Index()
        {
            List<SeequipoDTO> lstEquipos = _equipoAppService.ObtenerListaEquipos();
            return View(lstEquipos);
        }

        public JsonResult ObtenerListaTipoEquipos()
        {
            var lstTipoEquipos = _setipequipoAppService.GetAll();
            return Json(lstTipoEquipos.Select(x => new { key = x.Tequicodi, value = x.Tequinomb }));
        }


        // POST: Seequipo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: Seequipo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Seequipo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Seequipo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}