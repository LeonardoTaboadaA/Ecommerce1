﻿namespace TiendaVirtual.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Igv { get; set; }
        public string Imagen { get; set; }
        public decimal Precio { get; set; }
        public decimal Descuento { get; set; }
        public string Imagen1 { get; set; }
        public int IdCategoria { get; set; }
    }
}
