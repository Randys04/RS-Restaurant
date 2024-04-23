using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantProject.Models;

namespace RestaurantProject.Data
{
    public class RestaurantProjectContext : DbContext
    {
        public RestaurantProjectContext (DbContextOptions<RestaurantProjectContext> options)
            : base(options)
        {
        }

        public DbSet<RestaurantProject.Models.Platos> Platos { get; set; } = default!;

        public DbSet<RestaurantProject.Models.Reservas>? Reservas { get; set; }

        public DbSet<RestaurantProject.Models.Ventas>? Ventas { get; set; }

        //public DbSet<RestaurantProject.Models.Clientes>? Clientes { get; set; }
    }
}
