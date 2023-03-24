using Proyecto_IDYGS81.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Proyecto_IDYGS81.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
    }
}
