using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.Domain.Interfaces.UoW
{
    public interface IUnitOfWorkEF : IDisposable
    {
        bool Commit();
    }
}
