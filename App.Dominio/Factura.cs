using System;
using System.Collections.Generic;
using System.Text;

namespace App.Dominio
{
    public class Factura
    {
        public bool Anulado;
        public Guid facturaId { get; set; }
        public Guid clienteId { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public Cliente clienteNav { get; set; }
        public List<detalleFactura> detalleFacturaNav { get; set; }
    }
}
