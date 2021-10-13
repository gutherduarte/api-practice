using System;
using System.Collections.Generic;
using System.Text;
using App.Dominio;
using App.Dominio.Interfaces.Repositorios;
using App.Infraestructura.Datos.Contexto;
using System.Linq;

namespace App.Infraestructura.Datos.Repositorios
{
    public class ClienteRepositorio : IRepositorioBase<Cliente, Guid>
    {
        private AppDbContext db;

        public ClienteRepositorio(AppDbContext _db)
        {
            db = _db;
        }
        public Cliente Agregar(Cliente entidad)
        {
            entidad.clienteId = Guid.NewGuid();

            db.Clientes.Add(entidad);

            return entidad;
        }

        public void Editar(Cliente entidad)
        {

            var ClienteSeleccionado = db.Clientes.Where(c => c.clienteId ==entidad.clienteId).FirstOrDefault();
            if (ClienteSeleccionado != null)
            {
                ClienteSeleccionado.Nombres = entidad.Nombres;
                ClienteSeleccionado.Cedula = entidad.Cedula;
                ClienteSeleccionado.Apellidos = entidad.Apellidos;
                ClienteSeleccionado.Direccion = entidad.Direccion;
                ClienteSeleccionado.Telefono = entidad.Telefono;
                ClienteSeleccionado.Sexo = entidad.Sexo;

                db.Entry(ClienteSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(Guid entidadId)
        {
            var ClienteSeleccionado = db.Clientes.Where(c => c.clienteId == entidadId).FirstOrDefault();
            if (ClienteSeleccionado != null)
            {
                db.Clientes.Remove(ClienteSeleccionado);
            }
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public List<Cliente> Listar()
        {
            return db.Clientes.ToList();
        }

        public Cliente SeleccionarPorID(Guid entidadId)
        {
            var ClienteSeleccionado = db.Clientes.Where(c => c.clienteId == entidadId).FirstOrDefault();
            return ClienteSeleccionado;
        }
    }
}
