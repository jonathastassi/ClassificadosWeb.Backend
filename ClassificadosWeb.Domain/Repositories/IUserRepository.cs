using System;
using System.Threading.Tasks;
using ClassificadosWeb.Domain.Entities;
using ClassificadosWeb.Domain.Repositories.Base;

namespace ClassificadosWeb.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task<UserEntity> GetByEmail(string email);
        Task<UserEntity> GetById(Guid id);
    }
}