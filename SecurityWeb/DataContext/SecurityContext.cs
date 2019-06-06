using Microsoft.EntityFrameworkCore;
using SecurityWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityWeb.DataContext
{
    public class SecurityContext : DbContext
    {
        public SecurityContext(DbContextOptions<SecurityContext> options)
            : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
