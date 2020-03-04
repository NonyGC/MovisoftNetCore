using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movisoft.Aplication.DTO;
using Movisoft.Aplication.Interface;
using Movisoft.Aplication.Interface.Entity;
using Movisoft.Aplication.Validations;
using Movisoft.MVC.Areas.Equipamiento.Models;

namespace Movisoft.MVC.Areas.Equipamiento.Controllers
{
    [Area("Equipamiento")]
    [Authorize]
    public class EquipoController : Controller
    {
        private readonly ILogger<EquipoController> _logger;
        private readonly ISeequipoAppService _equipoAppService;
        private readonly ISharedAppService _sharedAppService;

        public EquipoController(ILogger<EquipoController> logger,
            ISeequipoAppService equipamientoAppService, ISharedAppService sharedAppService)
        {
            _logger = logger;
            _equipoAppService = equipamientoAppService;
            _sharedAppService = sharedAppService;
        }

        // GET: Seequipo
        public ActionResult Index()
        {
            var model = new VMEquipamiento();

            try
            {
                model.ListSelectItems = new List<List<SelectListItemDTO>>()
                {
                    _sharedAppService.ObtenerSelectItemTopologia(),
                    _sharedAppService.ObtenerSelectItemTipoEquipo(),
                    _sharedAppService.ObtenerSelectItemEmpresa()
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return NotFound(e.Message);
            }

            return View(model);
        }


        // POST: Seequipo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SeequipoDTO seequipoDTO, [FromServices] SeequipoValidadorInsertar validationRules)
        {
            try
            {
                var validador = validationRules.Validate(seequipoDTO);

                if (!validador.IsValid)
                    return BadRequest(validador);

                var id = _equipoAppService.Insertar(seequipoDTO);

                if (id.HasValue)
                    return Ok();

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        // POST: Seequipo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SeequipoDTO seequipoDTO, [FromServices] SeequipoValidadorActualizar validationRules)
        {
            try
            {
                var validador = validationRules.Validate(seequipoDTO);

                if (!validador.IsValid)
                    return BadRequest(validador);

                var exito = _equipoAppService.Actualizar(seequipoDTO);
                if (exito)
                    return Ok();

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET: Seequipo/Delete/5

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id == default)
                    BadRequest();

                bool exito = _equipoAppService.ActualizarAEstadoInactivo(id);

                if (exito)
                    return Ok();

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            try
            {
                var model = new VMEquipamiento
                {
                    Seequipo = _equipoAppService.GetById(id)
                };
                return Ok(model);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        public ActionResult ListaEquipos(string estado)
        {
            try
            {
                var model = new VMEquipamiento
                {
                    ListaSeequipo = _equipoAppService.ObtenerListaPorEstado(estado)
                };

                return Ok(model);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}