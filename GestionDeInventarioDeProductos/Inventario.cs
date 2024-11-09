using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeInventarioDeProductos
{
    public class Inventario
    {
        private List<Productos> productos;

        public Inventario()
        {
            productos = new List<Productos>();
        }

        public void AgregarProducto(Productos producto)
        {
            productos.Add(producto);
        }

        public bool ActualizarPrecioProducto(string nombre, decimal nuevoPrecio)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                producto.Precio = nuevoPrecio;
                return true;
            }
            return false;
        }

        public bool EliminarProducto(string nombre)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                productos.Remove(producto);
                return true;
            }
            return false;
        }

        public void ContarYAgruparProductosPorPrecio()
        {
            var grupos = productos.GroupBy(p =>
            {
                if (p.Precio < 100) return "Menores a 100";
                else if (p.Precio >= 100 && p.Precio <= 500) return "Entre 100 y 500";
                else return "Mayores a 500";
            });

            foreach (var grupo in grupos)
            {
                Console.WriteLine($"{grupo.Key}: {grupo.Count()} productos");
            }
        }

        public void GenerarReporteResumen()
        {
            Console.WriteLine("\n--- Reporte Resumido del Inventario ---");
            Console.WriteLine($"Número total de productos: {productos.Count}");
            Console.WriteLine($"Precio promedio de los productos: {productos.Average(p => p.Precio):C}");

            var productoMasCaro = productos.OrderByDescending(p => p.Precio).FirstOrDefault();
            var productoMasBarato = productos.OrderBy(p => p.Precio).FirstOrDefault();

            if (productoMasCaro != null && productoMasBarato != null)
            {
                Console.WriteLine($"Producto con el precio más alto: {productoMasCaro.Nombre} - {productoMasCaro.Precio:C}");
                Console.WriteLine($"Producto con el precio más bajo: {productoMasBarato.Nombre} - {productoMasBarato.Precio:C}");
            }
        }

        public IEnumerable<Productos> FiltrarYOrdenarProductos(decimal precioMinimo)
        {
            return productos.Where(p => p.Precio > precioMinimo)
                            .OrderBy(p => p.Precio); 
        }

    }
}
