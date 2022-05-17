using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using AppVenta.Dominio;
using AppVentas.Infraestructura.Datos.Configs;



namespace AppVentas.Infraestructura.Datos.Contextos
{
    public class SaleContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<SaleDetail> SaleDetails { get; set; }

        protected override void OnConfiguring( DbContextOptionsBuilder options) 
        {    
            // crear base de datos y poner la string ( BD SQL)
            options.UseSqlServer(@"Data source=(localdb)\MSSQLLocalDB; Initial catalog = VentasDb ; Integrated security= True;");

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfig());
            builder.ApplyConfiguration(new SaleConfig());
            builder.ApplyConfiguration(new SaleDetailConfig());


        }
    }
}
