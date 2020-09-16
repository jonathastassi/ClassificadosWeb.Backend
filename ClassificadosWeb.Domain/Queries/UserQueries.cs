using System;
using System.Linq.Expressions;
using ClassificadosWeb.Domain.Entities;

namespace ClassificadosWeb.Domain.Queries
{
    public static class UserQueries
    {
        public static Expression<Func<UserEntity, bool>> GetByEmail(string email)
        {
            return x => x.Email == email;
        }

        public static Expression<Func<UserEntity, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}