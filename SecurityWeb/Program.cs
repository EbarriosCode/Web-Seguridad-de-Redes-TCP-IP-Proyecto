using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SecurityWeb.DataContext;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SecurityWeb.DataContext.Data;

namespace SecurityWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Obtener el IWebHost que alojará la aplicación.
            var host = CreateWebHostBuilder(args).Build();

            // Encuentrar la capa de servicio dentro de nuestro alcance.
            using (var scope = host.Services.CreateScope())
            {
                // Crear la instancia del Contexto en la capa de servicios
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<SecurityContext>();

                // Llamar a la clase DbInitializer para crear los datos
                DbInitializer.Initialize(services);
            }

            // Continuar corriendo la aplicación
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
