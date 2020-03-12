using Movisoft.Aplication.DTO;
using Movisoft.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Aplication.Interface.Entity
{
    public interface ISiempresaAppService : IBaseAppService<SiempresaDTO, Siempresa>
    {
        IEnumerable<SiempresaDTO> GetListActivo();
        bool Insert(SiempresaDTO siempresaDTO, int[] sirelempresas);
    }
}
