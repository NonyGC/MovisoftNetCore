using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movisoft.Aplication.DTO;
using Movisoft.Aplication.Interface;
using Movisoft.CrossCutting.Common;
using Movisoft.MVC.Areas.Equipamiento.Models;
using Movisoft.MVC.Controllers;
using SmartBreadcrumbs.Attributes;

namespace Movisoft.MVC.Areas.Equipamiento.Controllers
{
    [Area("Equipamiento")]
    public class EquipoController : Controller
    {
        private readonly ILogger<EquipoController> _logger;
        private readonly IEquipoAppService _equipoAppService;
        private readonly ITipequipoAppService _setipequipoAppService;
        private readonly ISharedAppService _sharedAppService;

        public EquipoController(ILogger<EquipoController> logger, IEquipoAppService equipamientoAppService,
            ITipequipoAppService setipequipoAppService, ISharedAppService sharedAppService)
        {
            _logger = logger;
            _equipoAppService = equipamientoAppService;
            _setipequipoAppService = setipequipoAppService;
            _sharedAppService = sharedAppService;
        }

        // GET: Seequipo
        public ActionResult Index()
        {
            var model = new VMEquipamiento();

            try
            {
                model.ListaSetipequipo = _equipoAppService.ObtenerListaEquipos();

                model.ListSelectItems = new List<List<SelectListItemDTO>>()
                {
                    _sharedAppService.ObtenerSelectItemTopologia(),
                    _sharedAppService.ObtenerSelectItemTipoEquipo(),
                    _sharedAppService.ObtenerSelectItemEmpresa()
                };

                model.Estado = (int)Constantes.Estado.Ok;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                model.Mensaje = e.Message;
                model.Estado = (int)Constantes.Estado.Error;
            }

            return View(model);
        }


        // POST: Seequipo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SeequipoDTO seequipoDTO)
        {
            var model = new VMEquipamiento();
            try
            {
                var id = _equipoAppService.Save(seequipoDTO);

                model.Estado = id.HasValue ? (int)Constantes.Estado.Ok : (int)Constantes.Estado.Error;
            }
            catch(Exception e)
            {
                _logger.LogError(e, e.Message);
                model.Mensaje = e.Message;
                model.Estado = (int)Constantes.Estado.Error;
            }

            return Json(model);
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