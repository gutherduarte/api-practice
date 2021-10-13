using System;
using System.Collections.Generic;
using System.Text;

namespace App.Dominio
{
    public class Producto
    {
		public Guid productoId { get; set; }
		public string Nombre { get; set; }
		public decimal Precio { get; set; }
		public string Imagen { get; set; }
		public string Descripcion { get; set; }
		public List<detalleFactura> detalleFacturaNav { get; set; }
	}
}
