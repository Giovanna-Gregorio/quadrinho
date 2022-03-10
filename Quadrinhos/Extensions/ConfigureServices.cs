using Microsoft.Extensions.DependencyInjection;
using Quadrinhos.Domain.Interfaces;
using Quadrinhos.Services;

namespace Quadrinhos.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IQuadrinhoService, QuadrinhoService>();
            services.AddTransient<IVendaService, VendaService>();

            return services;
        }
    }
}
