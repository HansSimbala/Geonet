using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaGeonet.Models;

namespace SistemaGeonet.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Equipo> Equipo { get; set; }

        public DbSet<Proveedor> Proveedor { get; set; }

      
       public DbSet<SistemaGeonet.Models.OrdenPedido> OrdenPedido { get; set; }

        public DbSet<SistemaGeonet.Models.Inventario> Inventario { get; set; }

        public DbSet<SistemaGeonet.Models.EquipoxProveedor> EquipoxProveedor { get; set; }

        public DbSet<SistemaGeonet.Models.OrdenCompra> OrdenCompra { get; set; }

        public DbSet<SistemaGeonet.Models.EquipoxOC> EquipoxOC { get; set; }

     

        public DbSet<SistemaGeonet.Models.Usuarios> Usuarios { get; set; }

        public DbSet<SistemaGeonet.Models.ApplicationUser> ApplicationUser { get; set; }

        public DbSet<SistemaGeonet.Models.Movimiento> Movimiento { get; set; }

        public DbSet<SistemaGeonet.Models.Catalogo> Catalogo { get; set; }

        public DbSet<SistemaGeonet.Models.DetallePedido> DetallePedido { get; set; }

        public DbSet<SistemaGeonet.Models.Item> Item { get; set; }

        public DbSet<SistemaGeonet.Models.Reseña> Reseña { get; set; }

    }
}
