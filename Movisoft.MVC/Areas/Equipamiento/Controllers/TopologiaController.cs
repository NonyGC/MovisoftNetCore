using System;
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
    public class TopologiaController : Controller
    {
        private readonly ILogger<TipoEquipoController> _logger;
        private readonly ISetopologiaAppService _setopologiaAppService;
        public TopologiaController(ILogger<TipoEquipoController> logger, ISetopologiaAppService setopologiaAppService)
        {
            _logger = logger;
            _setopologiaAppService = setopologiaAppService;
        }
        // GET: Topologia
        public ActionResult Index()
        {
            return View();
        }

        // GET: Topologia/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var model = new VMEquipamiento
                {
                    Setopologia= _setopologiaAppService.GetById(id)
                };

                return Ok(model);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }


        // POST: Topologia/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SetopologiaDTO setopologiaDTO, [FromServices] SetopologiaValidadorInsertar validationRules)
        {
            try
            {
                var validador = validationRules.Validate(setopologiaDTO);

                if (!validador.IsValid)
                    return BadRequest(validador);

                var id = _setopologiaAppService.Insertar(setopologiaDTO);

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

        // POST: Topologia/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SetopologiaDTO setopologiaDTO, [FromServices] SetopologiaValidadorActualizar validationRules)
        {
            try
            {
                var validador = validationRules.Validate(setopologiaDTO);

                if (!validador.IsValid)
                    return BadRequest(validador);

                var exito = _setopologiaAppService.Actualizar(setopologiaDTO);

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
                bool exito = _setopologiaAppService.ActualizarAEstadoInactivo(id);
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
                    ListaSetopologia = _setopologiaAppService.ObtenerListaPorEstado(estado)
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