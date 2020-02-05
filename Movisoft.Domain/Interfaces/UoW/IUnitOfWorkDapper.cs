using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Movisoft.Domain.Interfaces.UoW
{
    public interface IUnitOfWorkDapper : IDisposable
    {
        Guid Id { get; }
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        void Begin();
        void Commit();
        void Rollback();
    }
}
