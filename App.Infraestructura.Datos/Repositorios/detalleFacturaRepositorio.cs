using System;
using System.Collections.Generic;
using System.Text;
using App.Dominio;
using App.Dominio.Interfaces.Repositorios;
using App.Infraestructura.Datos.Contexto;
using System.Linq;

namespace App.Infraestructura.Datos.Repositorios
{
    public class detalleFacturaRepositorio : IRepositorioDetalle<detalleFactura, Guid>
    {
        private AppDbContext db;
        public detalleFacturaRepositorio(AppDbContext _db)
        {
            db = _db;
        }
        public detalleFactura Agregar(detalleFactura entidad)
        {
            db.DetalleFacturas.Add(entidad);

            return entidad;
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public List<detalleFactura> SeleccionarDetallesPorMovimiento(Guid movimientoId)
        {
            return db.DetalleFacturas.Where(c => c.facturaId == movimientoId).ToList();
        }
    }
}
