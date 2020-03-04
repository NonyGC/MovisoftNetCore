using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movisoft.Aplication.DTO;
using Movisoft.Aplication.Interface.Entity;
using Movisoft.Aplication.Validations;
using Movisoft.MVC.Areas.Equipamiento.Models;

namespace Movisoft.MVC.Areas.Equipamiento.Controllers
{
    [Area("Equipamiento")]
    [Authorize]
    public class TipoEquipoController : Controller
    {
        private readonly ILogger<TipoEquipoController> _logger;
        private readonly ISetipequipoAppService _setipequipoAppService;

        public TipoEquipoController(ILogger<TipoEquipoController> logger, ISetipequipoAppService setipequipoAppService)
        {
            _setipequipoAppService = setipequipoAppService;
            _logger = logger;
        }

        // GET: TipoEquipo
        public ActionResult Index()
        {
            return View();
        }


        // GET: TipoEquipo/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var model = new VMEquipamiento
                {
                    Setipequipo = _setipequipoAppService.GetById(id)
                };
                return Ok(model);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // POST: TipoEquipo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SetipequipoDTO setipequipoDTO, [FromServices] SetipequipoValidadorInsertar validationRules)
        {
            try
            {
                var validador = validationRules.Validate(setipequipoDTO);

                if (!validador.IsValid)
                    return BadRequest(validador);

                var id = _setipequipoAppService.Insertar(setipequipoDTO);

                if (id.HasValue)
                    return Ok(id);

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // POST: TipoEquipo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SetipequipoDTO setipequipoDTO, [FromServices] SetipequipoValidadorActualizar validationRules)
        {
            try
            {
                var validador = validationRules.Validate(setipequipoDTO);

                if (!validador.IsValid)
                    return BadRequest(validador);

                var exito = _setipequipoAppService.Actualizar(setipequipoDTO);

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

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                bool exito = _setipequipoAppService.ActualizarAEstadoInactivo(id);
                if (exito)
                {
                    return Ok(exito);
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }


        [HttpGet]
        public ActionResult List(string estado)
        {
            try
            {
                var model = new VMEquipamiento
                {
                    ListaSetipequipo = _setipequipoAppService.ObtenerListaPorEstado(estado)
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