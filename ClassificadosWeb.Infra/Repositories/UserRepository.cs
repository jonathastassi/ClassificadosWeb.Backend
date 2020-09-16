using System.Threading.Tasks;
using ClassificadosWeb.Domain.Entities;
using ClassificadosWeb.Domain.Queries;
using ClassificadosWeb.Domain.Repositories;
using ClassificadosWeb.Infra.Context;
using ClassificadosWeb.Infra.Repositories.Base;

namespace ClassificadosWeb.Infra.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(IMongoContext context) : base(context, "Users")
        {
        }

        public async Task<UserEntity> GetByEmail(string email)
        {
            var user = await this.FindOneBy(UserQueries.GetByEmail(email));
            return user;
        }
    }
}