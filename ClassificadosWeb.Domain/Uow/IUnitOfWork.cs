using System;
using System.Threading.Tasks;

namespace ClassificadosWeb.Domain.Uow
{
    public interface IUnitOfWork
    {
        Task<int> SaveChanges();
    }
}