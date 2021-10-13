using System;
using System.Collections.Generic;
using System.Text;
using App.Dominio;
using App.Dominio.Interfaces.Repositorios;
using App.Infraestructura.Datos.Contexto;
using System.Linq;

namespace App.Infraestructura.Datos.Repositorios
{
    public class FacturaRepositorio : IRepositorioMovimiento<Factura, Guid>
    {
        private AppDbContext db;
        public FacturaRepositorio(AppDbContext _db)
        {
            db = _db;
        }
        public Factura Agregar(Factura entidad)
        {
            entidad.facturaId = Guid.NewGuid();

            db.Facturas.Add(entidad);

            return entidad;
        }

        public void Anular(Guid entidadId)
        {
            var ventaSeleccionada = SeleccionarPorID(entidadId);

            if (ventaSeleccionada != null)
            {
                ventaSeleccionada.Anulado = true;

                db.Entry(ventaSeleccionada).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                throw new NullReferenceException("No se ha encontrado la venta que intenta anular.");
            }
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public List<Factura> Listar()
        {
            return db.Facturas.ToList();
        }

        public Factura SeleccionarPorID(Guid entidadId)
        {
            var FacturaSeleccionado = db.Facturas.Where(c => c.facturaId == entidadId).FirstOrDefault();
            return FacturaSeleccionado;
        }
    }
}
