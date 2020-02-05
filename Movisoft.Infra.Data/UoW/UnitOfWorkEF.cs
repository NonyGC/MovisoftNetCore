using Movisoft.Domain.Interfaces.UoW;
using Movisoft.Infra.Data.Context;

namespace Movisoft.Infra.Data.UoW
{
    public class UnitOfWorkEF : IUnitOfWorkEF
    {
        private readonly MovisoftContext _context;

        public UnitOfWorkEF(MovisoftContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
