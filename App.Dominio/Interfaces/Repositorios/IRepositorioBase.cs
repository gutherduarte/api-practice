using System;
using System.Collections.Generic;
using System.Text;

namespace App.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase <TEntidad, TEntidadID>
         : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>, ITransaccion

    {

    }
}
