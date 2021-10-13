using System;
using System.Collections.Generic;
using System.Text;

namespace App.Dominio
{
    public class detalleFactura
    {
        public Guid productoId { get; set; }
        public Guid facturaId { get; set; }
        public decimal cantidadProductosVendidos { get; set; }
        public decimal costoProductosVendidos { get; set; }
        public decimal precioProductosVendidos { get; set; }
        public Factura facturaNav { get; set; }
        public Producto productoNav { get; set; }
    }
}
