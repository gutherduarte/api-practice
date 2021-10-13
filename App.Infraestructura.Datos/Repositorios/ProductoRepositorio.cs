using System;
using System.Collections.Generic;
using System.Text;
using App.Dominio;
using App.Dominio.Interfaces.Repositorios;
using App.Infraestructura.Datos.Contexto;
using System.Linq;

namespace App.Infraestructura.Datos.Repositorios
{
    public class ProductoRepositorio : IRepositorioBase<Producto, Guid>
    {
        private AppDbContext db;
        public ProductoRepositorio(AppDbContext _db)
        {
            db = _db;
        }
        public Producto Agregar(Producto entidad)
        {
            entidad.productoId = Guid.NewGuid();

            db.Produtos.Add(entidad);

            return entidad;
        }

        public void Editar(Producto entidad)
        {
            var productoSelecconado = db.Produtos.Where(c => c.productoId == entidad.productoId).FirstOrDefault();
            if (productoSelecconado != null)
            {
                productoSelecconado.Nombre = entidad.Nombre;
                productoSelecconado.Precio = entidad.Precio;
                productoSelecconado.Descripcion = entidad.Descripcion;
                productoSelecconado.Imagen = entidad.Imagen;

                db.Entry(productoSelecconado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(Guid entidadId)
        {
            var productoSeleccionado = db.Produtos.Where(c => c.productoId == entidadId).FirstOrDefault();
            if (productoSeleccionado != null)
            {
                db.Produtos.Remove(productoSeleccionado);
            }
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public List<Producto> Listar()
        {
            return db.Produtos.ToList();
        }

        public Producto SeleccionarPorID(Guid entidadId)
        {
            var productoSeleccionado = db.Produtos.Where(c => c.productoId == entidadId).FirstOrDefault();
            return productoSeleccionado;
        }
    }
}
