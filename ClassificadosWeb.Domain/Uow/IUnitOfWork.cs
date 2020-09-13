using System;
using System.Threading.Tasks;

namespace ClassificadosWeb.Domain.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChanges();
    }
}