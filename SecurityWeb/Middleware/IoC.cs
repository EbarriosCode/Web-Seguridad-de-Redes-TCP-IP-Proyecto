using Microsoft.Extensions.DependencyInjection;
using SecurityWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityWeb.Middleware
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            // Inyectar el servicio de Authorización => Login
            services.AddTransient<ILoginService, LoginService>();

            return services;
        }
    }
}
