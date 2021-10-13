using App.Dominio;
using App.Infraestructura.Datos.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infraestructura.Datos.Contexto
{
    public class AppDbContext : DbContext
    {
        string SERVER = Environment.GetEnvironmentVariable("SERVER");
        string PORT = Environment.GetEnvironmentVariable("PORT");
        string DATABASE = Environment.GetEnvironmentVariable("DATABASE");
        string USERNAME = Environment.GetEnvironmentVariable("USERNAME");
        string PASSWORD = Environment.GetEnvironmentVariable("PASSWORD");
        string INTEGRATED_SECURITY = Environment.GetEnvironmentVariable("INTEGRATED_SECURITY");
        string TRUST_SERVER_CERTIFICATE = Environment.GetEnvironmentVariable("TRUST_SERVER_CERTIFICATE");

        public AppDbContext()
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Produtos { get; set; }
        public DbSet<detalleFactura> DetalleFacturas { get; set; }
        public DbSet<Factura> Facturas { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer($"Server={SERVER},{PORT}; Initial Catalog={DATABASE};Persist Security Info=False; User ID={USERNAME};Password={PASSWORD};MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate={TRUST_SERVER_CERTIFICATE}; Integrated Security={INTEGRATED_SECURITY};Connection Timeout=30;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new detalleFacturaConfig());
            modelBuilder.ApplyConfiguration(new FacturaConfig());
            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new ProductoConfig());

        }
    }
}
