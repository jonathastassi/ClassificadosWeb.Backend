using System;
using ClassificadosWeb.Domain.Entities;

namespace ClassificadosWeb.Api.Models
{
    public class UserAuth
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public static explicit operator UserAuth(UserEntity user)
        {
            return new UserAuth()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
            };
        }
    }
}