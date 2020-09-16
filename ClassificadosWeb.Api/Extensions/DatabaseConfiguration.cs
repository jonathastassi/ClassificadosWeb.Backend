using ClassificadosWeb.Infra.Configuration;
using ClassificadosWeb.Infra.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClassificadosWeb.Api.Extensions
{
    public static class DatabaseConfiguration
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMongoContext>(s => new MongoContext( 
                new Settings(configuration.GetConnectionString("connectionString"), configuration.GetConnectionString("databaseName")) ));
        }
    }
}