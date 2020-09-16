using ClassificadosWeb.Domain.Repositories;
using ClassificadosWeb.Domain.Uow;
using ClassificadosWeb.Infra.Repositories;
using ClassificadosWeb.Infra.Uow;
using Microsoft.Extensions.DependencyInjection;

namespace ClassificadosWeb.Api.Extensions
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
        } 
    }
}