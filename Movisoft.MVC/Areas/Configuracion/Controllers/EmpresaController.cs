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
using Movisoft.MVC.Areas.Configuracion.Models;

namespace Movisoft.MVC.Areas.Configuracion.Controllers
{
    [Authorize]
    [Area("Configuracion")]
    public class EmpresaController : Controller
    {
        private readonly ILogger<EmpresaController> _logger;
        private readonly ISiempresaAppService _siempresaAppService;
        private readonly ISitipempresaAppService _sitipempresaAppService;
        public EmpresaController(ILogger<EmpresaController> logger, ISiempresaAppService siempresaAppService, ISitipempresaAppService sitipempresaAppService)
        {
            _logger = logger;
            _siempresaAppService = siempresaAppService;
            _sitipempresaAppService = sitipempresaAppService;
        }

        // GET: Empresa
        public ActionResult Index()
        {
            return View();
        }

        // GET: Empresa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Empresa/Create
        public ActionResult Create()
        {
            var vm = new VMConfiguracion { ListaSitipempresa = _sitipempresaAppService.GetAll() };
            return View(vm);
        }

        // POST: Empresa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SiempresaDTO siempresaDTO, int[] sirelempresas)
        {
            try
            {
                bool exito = _siempresaAppService.Insert(siempresaDTO, sirelempresas);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Empresa/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Empresa/Edit/5
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

        // GET: Empresa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Empresa/Delete/5
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


        [HttpGet]
        public ActionResult List()
        {
            try
            {
                var lstEmpresas = _siempresaAppService.GetListActivo();
                return Ok(lstEmpresas);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}