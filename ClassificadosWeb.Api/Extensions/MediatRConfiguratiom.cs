using System.Reflection;
using ClassificadosWeb.Domain.Commands.User;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ClassificadosWeb.Api.Extensions
{
    public static class MediatRConfiguratiom
    {
        public static void AddMediatRConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly, typeof(CreateUserCommand).GetTypeInfo().Assembly);
        }
    }
}