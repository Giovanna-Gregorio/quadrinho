using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Quadrinhos.Domain.Contracts;
using Quadrinhos.Domain.Models;
using Quadrinhos.Validators;

namespace Quadrinhos.Extensions
{
    public static class FluentValidators
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<Usuario>, UsuarioValidator>();
            services.AddTransient<IValidator<Quadrinho>, QuadrinhoValidator>();
            services.AddTransient<IValidator<CompraContract>, CompraContractValidator>();

            return services;
        }
    }
}
