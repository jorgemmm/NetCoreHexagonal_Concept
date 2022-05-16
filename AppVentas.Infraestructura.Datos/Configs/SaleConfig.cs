using System;
using System.Collections.Generic;
using System.Text;


using AppVenta.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppVentas.Infraestructura.Datos.Configs
{
    public class SaleConfig : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("SaleTable");
            builder.HasKey(key => key.saleId);

            builder
                .HasMany(Sale => Sale.SaleDetails)
                .WithOne(SaleDetail => SaleDetail.Sale);
        }
    }
    }
}
