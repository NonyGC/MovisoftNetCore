﻿using Movisoft.Aplication.DTO;
using Movisoft.Aplication.Interface;
using Movisoft.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movisoft.Aplication.Service
{
    public class SharedAppService : ISharedAppService
    {
        private readonly ISetipequipoRepository _setipequipoRepository;
        private readonly ISiempresaRepository _siempresaRepository;
        private readonly ISetopologiaRepository _setopologiaRepository;
        private readonly ISitipempresaRepository _sitipempresaRepository;
        public SharedAppService(ISetipequipoRepository setipequipoRepository, ISiempresaRepository siempresaRepository,
            ISetopologiaRepository setopologiaRepository, ISitipempresaRepository sitipempresaRepository)
        {
            _setipequipoRepository = setipequipoRepository;
            _siempresaRepository = siempresaRepository;
            _setopologiaRepository = setopologiaRepository;
            _sitipempresaRepository = sitipempresaRepository;
        }
        public List<SelectListItemDTO> ObtenerSelectItemEmpresa()
        {
           return _siempresaRepository.ObtenerListSelectItem()
                .Select(x => new SelectListItemDTO { Value = x.Emprcodi, Text = x.Emprnomb })
                .ToList();
        }

        public List<SelectListItemDTO> ObtenerSelectItemTipoEquipo()
        {
            var lstTipoEquipo = _setipequipoRepository.GetAll()
                 .Select(x => new SelectListItemDTO { Value = x.Tequicodi, Text = x.Tequinomb })
                 .ToList();

            return lstTipoEquipo;
        }

        public List<SelectListItemDTO> ObtenerSelectItemTopologia()
        {
           return _setopologiaRepository.GetAll()
                .Select(x => new SelectListItemDTO { Value = x.Topcodi, Text = x.Topnombre })
                .ToList();
        }

        public List<SelectListItemDTO> ObtenerSelectItemTipoEmpresa()
        {
            return _sitipempresaRepository.GetAll()
                .Select(x => new SelectListItemDTO { Value = x.Tempcodi, Text = x.Tempdesc })
                .ToList();
        }

    }
}
