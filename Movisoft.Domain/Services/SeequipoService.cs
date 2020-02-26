using Movisoft.Domain.Entity;
using Movisoft.Domain.Interfaces.Repository;
using Movisoft.Domain.Interfaces.Service;
using Movisoft.Domain.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Domain.Services
{
    public class SeequipoService : ISeequipoService
    {
        private readonly IUnitOfWorkDapper _unitOfWork;
        private readonly ISeequipoRepository _seequipoRepository;
        public SeequipoService(IUnitOfWorkDapper unitOfWork, ISeequipoRepository seequipoRepository)
        {
            _unitOfWork = unitOfWork;
            _seequipoRepository = seequipoRepository;
        }
        public int? Save(Seequipo seequipo)
        {
            int? id;
            try
            {
                _unitOfWork.Begin();
                id = _seequipoRepository.Save(seequipo, _unitOfWork.Connection, _unitOfWork.Transaction);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();
                throw;
            }

            return id;
        }
    }

}
