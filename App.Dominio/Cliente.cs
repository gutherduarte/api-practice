using System;
using System.Collections.Generic;
using System.Text;

namespace App.Dominio
{
    public class Cliente
    {
        public Guid clienteId { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public char Sexo { get; set; }
        public List<Factura> facturaNav { get; set; }
    }
}
