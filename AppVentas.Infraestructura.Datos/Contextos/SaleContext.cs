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

        //private DbContext Database;
    
        string SERVER = Environment.GetEnvironmentVariable("SERVER");
        string PORT = Environment.GetEnvironmentVariable("PORT");
        string DATABASE = Environment.GetEnvironmentVariable("DATABASE");
        string USERNAME = Environment.GetEnvironmentVariable("USERNAME");
        string PASSWORD = Environment.GetEnvironmentVariable("PASSWORD");
        

        public SaleContext()
        {
            this.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<SaleDetail> SaleDetails { get; set; }

        protected override void OnConfiguring( DbContextOptionsBuilder options) 
        {    
            // crear base de datos y poner la string ( BD SQL)
            // options.UseSqlServer(@"Data source=(localdb)\MSSQLLocalDB; Initial catalog = VentasDb ; Integrated security= True;");
             options.UseSqlServer($"Server={SERVER},{PORT}; Initial catalog = {DATABASE}  ; User ID={USERNAME}; Password={ PASSWORD} ;Persist Security Info= False ;Integrated security= True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfig());
            builder.ApplyConfiguration(new SaleConfig());
            builder.ApplyConfiguration(new SaleDetailConfig());


        }
    }
}
