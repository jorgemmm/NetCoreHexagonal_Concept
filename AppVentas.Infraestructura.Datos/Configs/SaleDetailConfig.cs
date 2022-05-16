using System;
using System.Collections.Generic;
using System.Text;


using AppVenta.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AppVentas.Infraestructura.Datos.Configs
{
    public class SaleDetailConfig : IEntityTypeConfiguration<SaleDetail>
    {
        public void Configure(EntityTypeBuilder<SaleDetail> builder)
        {
            builder.ToTable("SaleDetailTable");
            builder.HasKey(key => new { key.productId, key.SaleId });

            builder
                .HasOne(detail => detail.Sale)
                .WithMany(Product => Product.SaleDetails);

            builder
                .HasOne(detail => detail.Sale)
                .WithMany(Sale => Sale.SaleDetails);
        }
    }
}
