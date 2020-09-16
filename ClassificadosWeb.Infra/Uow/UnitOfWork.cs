using System.Threading.Tasks;
using ClassificadosWeb.Domain.Uow;
using ClassificadosWeb.Infra.Context;

namespace ClassificadosWeb.Infra.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoContext _context;

        public UnitOfWork(IMongoContext context)
        {
            _context = context;
        }
        
        public async Task<int> SaveChanges()
        {
            int changedCount = await _context.SaveChanges();
            return changedCount;
        }
    }
}