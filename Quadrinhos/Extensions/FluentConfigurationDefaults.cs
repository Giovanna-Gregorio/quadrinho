using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Quadrinhos.Extensions
{
    public static class FluentConfigurationDefaults
    {
        public static void AddFluentDefaults(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var errors = context.ModelState
                    .Values
                    .SelectMany(x => x.Errors.Select(p => p.ErrorMessage)).ToList();

                    var defaultReturn = false;

                    foreach (var item in errors)
                    {
                        if (string.IsNullOrEmpty(item))
                            defaultReturn = true;
                    }

                    if (defaultReturn)
                    {
                        errors.Clear();

                        foreach (var item in context.ModelState.Values)
                        {
                            foreach (var i in item.Errors)
                            {
                                errors.Add(i.Exception.Message);
                            }
                        }
                    }

                    var result = new
                    {
                        success = false,
                        message = "A operação não pode ser completada. Verifique as mensagens para prosseguir.",
                        errors
                    };

                    return new OkObjectResult(result);
                };
            });
        }
    }
}
