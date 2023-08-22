using System.Data;
using System.Data.SqlClient;

namespace Estacionamento.Repositories
{
    public static class DbSession
    {

        public static IServiceCollection ConncectionDatabase(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<IDbConnection>(db => new SqlConnection(
                    configuration.GetConnectionString("DefaultConnection")));

            return services;

        }
    }
}
