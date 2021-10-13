using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Dominio;

namespace App.Infraestructura.Datos.Entidades
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("tCliente");
            builder.HasKey(c => c.clienteId);

            builder.HasMany(f => f.facturaNav)
               .WithOne(c => c.clienteNav);
        }
    }
}
