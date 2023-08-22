using Estacionamento.Contracts;
using Estacionamento.Repositories;
using System.Data;
using System.Data.SqlClient;

namespace Estacionamento
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddApplicationRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton((Func<IServiceProvider, IDbConnection>)((IServiceProvider _) => new SqlConnection(
                    configuration.GetConnectionString("DefaultConnection"))));

            services.AddScoped<IEstacionamentoRepository, EstacionamentoRepository>();
            return services;
        }
    }
}