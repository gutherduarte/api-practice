using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Dominio;

namespace App.Infraestructura.Datos.Entidades
{
    class ProductoConfig : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Producto");
            builder.HasKey(p => p.productoId);

            builder.HasMany(p => p.detalleFacturaNav)
            .WithOne(df => df.productoNav);
        }
    }
}
