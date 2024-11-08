using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeInventarioDeProductos
{
    public class Productos
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public Productos(string nombre, decimal precio)
        {
            Nombre = nombre;
            Precio = precio;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Precio: {Precio:C}";
        }
    }

}
