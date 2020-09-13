using System.Threading.Tasks;
using ClassificadosWeb.Domain.Entities;

namespace ClassificadosWeb.Domain.Repositories
{
    public interface IUserRepository
    {
        UserEntity Add(UserEntity entity);
        UserEntity Update(UserEntity entity);
        Task<UserEntity> GetByEmail(string email);
    }
}