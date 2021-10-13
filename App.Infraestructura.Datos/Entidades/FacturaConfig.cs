using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Dominio;

namespace App.Infraestructura.Datos.Entidades
{
    public class FacturaConfig : IEntityTypeConfiguration<Factura>
    {
        public void Configure(EntityTypeBuilder<Factura> builder)
        {
            builder.ToTable("Factura");
            builder.HasKey(f => f.facturaId);

            builder
                    .HasMany(f => f.detalleFacturaNav)
                    .WithOne(df => df.facturaNav);
        }
    }
}
