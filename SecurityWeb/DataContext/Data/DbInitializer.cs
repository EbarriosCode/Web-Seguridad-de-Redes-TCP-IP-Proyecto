using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SecurityWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityWeb.DataContext.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var _context = new SecurityContext(serviceProvider.GetRequiredService<DbContextOptions<SecurityContext>>()))
            {
                if (_context.Usuarios.Any())
                {
                    return;
                }

                _context.Usuarios.AddRange(
                    new Usuario
                    {
                        UserId = new Guid(),
                        UserName = "Ebarrios",
                        Password = "123456",
                        Name = "Eduardo Barrios",
                        RememberMe = true
                    },

                    new Usuario
                    {
                        UserId = new Guid(),
                        UserName = "Dralon",
                        Password = "admin1234",
                        Name = "Denis Rosales",
                        RememberMe = true
                    },
                    new Usuario
                    {
                        UserId = new Guid(),
                        UserName = "Acabrera",
                        Password = "cadena23",
                        Name = "Abel Cabrera",
                        RememberMe = false
                    }
                );

                _context.SaveChanges();
            }
        }
    }
}
