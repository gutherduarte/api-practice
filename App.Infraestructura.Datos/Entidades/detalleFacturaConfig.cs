using App.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace App.Infraestructura.Datos.Entidades
{
    class detalleFacturaConfig : IEntityTypeConfiguration<detalleFactura>
    {
        public void Configure(EntityTypeBuilder<detalleFactura> builder)
        {
            builder.ToTable("detalleFactura");
            builder.HasKey(df => new { df.productoId, df.facturaId });

            builder
                .HasOne(df => df.productoNav)
                .WithMany(p => p.detalleFacturaNav);

            builder
                .HasOne(df => df.facturaNav)
                .WithMany(f => f.detalleFacturaNav);
        }
    }
}
