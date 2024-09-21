using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using System.Data;
using WebPlenoCliente.Domain.Interfaces;
using WebPlenoCliente.Infra.Repositories;

namespace WebPlenoCliente.Application
{
    public static class InjecaoDependencia
    {
        public static void AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IDbConnection>(sp => new MySqlConnection(connectionString));
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
        }
    }
}
