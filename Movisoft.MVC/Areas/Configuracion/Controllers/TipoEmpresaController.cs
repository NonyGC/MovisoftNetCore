using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movisoft.Aplication.DTO;
using Movisoft.Aplication.Interface.Entity;
using Movisoft.Aplication.Validations;

namespace Movisoft.MVC.Areas.Configuracion.Controllers
{
    [Area("Configuracion")]
    public class TipoEmpresaController : Controller
    {
        private readonly ILogger<TipoEmpresaController> _logger;
        private readonly ISitipempresaAppService _sitipempresaAppService;
        public TipoEmpresaController(ILogger<TipoEmpresaController> logger, ISitipempresaAppService sitipempresaAppService)
        {
            _logger = logger;
            _sitipempresaAppService = sitipempresaAppService;
        }

        // GET: TipoEmpresa
        public ActionResult Index()
        {
            return View();
        }

        // GET: TipoEmpresa/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var tipoempresa = _sitipempresaAppService.GetById(id);
                return Ok(tipoempresa);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET: TipoEmpresa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEmpresa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SitipempresaDTO sitipempresaDTO, [FromServices] SitipempresaInsertValidator validationRules)
        {
            try
            {
                var validador = validationRules.Validate(sitipempresaDTO);

                if (!validador.IsValid)
                    return BadRequest(validador);

                var id = _sitipempresaAppService.Add(sitipempresaDTO);

                if (id != null)
                    return Ok(id);

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // POST: TipoEmpresa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SitipempresaDTO setopologiaDTO, [FromServices] SitipempresaUpdateValidator validationRules)
        {
            try
            {
                var validador = validationRules.Validate(setopologiaDTO);

                if (!validador.IsValid)
                    return BadRequest(validador);

                var exito = _sitipempresaAppService.Update(setopologiaDTO);

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

        // POST: TipoEmpresa/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                bool exito = _sitipempresaAppService.RemoveById(id);
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
        public ActionResult List()
        {
            try
            {
                var lstTipoempresa = _sitipempresaAppService.GetAll();
                return Ok(lstTipoempresa);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}