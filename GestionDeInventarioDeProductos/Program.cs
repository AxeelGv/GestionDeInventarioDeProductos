using GestionDeInventarioDeProductos;
using System;

namespace GestionInventario
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventario inventario = new Inventario();
            int opcion;

            do
            {
                Console.WriteLine("\n--- Menu de Inventario ---");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Actualizar precio de un producto");
                Console.WriteLine("3. Eliminar un producto");
                Console.WriteLine("4. Filtrar y mostrar productos por precio minimo");
                Console.WriteLine("5. Contar y agrupar productos por rango de precios");
                Console.WriteLine("6. Generar reporte resumido del inventario");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opcion: ");

                while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 0 || opcion > 6)
                {
                    Console.WriteLine("Ingrese una opcion valida (0-6).");
                }

                switch (opcion)
                {
                    case 1:
                        AgregarProducto(inventario);
                        break;
                    case 2:
                        ActualizarPrecioProducto(inventario);
                        break;
                    case 3:
                        EliminarProducto(inventario);
                        break;
                    case 4:
                        FiltrarYMostrarProductos(inventario);
                        break;
                    case 5:
                        inventario.ContarYAgruparProductosPorPrecio();
                        break;
                    case 6:
                        inventario.GenerarReporteResumen();
                        break;
                    case 0:
                        Console.WriteLine("¡Nos vemos!");
                        break;
                }
            } while (opcion != 0);
        }

        static void AgregarProducto(Inventario inventario)
        {
            string nombre;
            do
            {
                Console.WriteLine("Ingrese el nombre del producto:");
                nombre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("El nombre del producto no puede estar vacío.");
                }
            } while (string.IsNullOrWhiteSpace(nombre));

            decimal precio;
            do
            {
                Console.WriteLine("Ingrese el precio del producto:");
                if (!decimal.TryParse(Console.ReadLine(), out precio) || precio <= 0)
                {
                    Console.WriteLine("Por favor, ingrese un número positivo para el precio.");
                }
            } while (precio <= 0);

            Productos producto = new Productos(nombre, precio);
            inventario.AgregarProducto(producto);
            Console.WriteLine("Producto agregado correctamente.");
        }

        static void ActualizarPrecioProducto(Inventario inventario)
        {
            Console.WriteLine("Ingrese el nombre del producto que desea actualizar:");
            string nombre = Console.ReadLine();

            decimal nuevoPrecio;
            do
            {
                Console.Write("Ingrese el nuevo precio: ");
                if (!decimal.TryParse(Console.ReadLine(), out nuevoPrecio) || nuevoPrecio <= 0)
                {
                    Console.WriteLine("Por favor, ingrese un número positivo para el nuevo precio.");
                }
            } while (nuevoPrecio <= 0);

            if (inventario.ActualizarPrecioProducto(nombre, nuevoPrecio))
            {
                Console.WriteLine("Precio actualizado correctamente.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        static void EliminarProducto(Inventario inventario)
        {
            Console.WriteLine("Ingrese el nombre del producto que desea eliminar:");
            string nombre = Console.ReadLine();

            if (inventario.EliminarProducto(nombre))
            {
                Console.WriteLine("Producto eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        static void FiltrarYMostrarProductos(Inventario inventario)
        {
            decimal precioMinimo;
            do
            {
                Console.Write("Ingrese el precio mínimo para filtrar los productos: ");
                if (!decimal.TryParse(Console.ReadLine(), out precioMinimo) || precioMinimo < 0)
                {
                    Console.WriteLine("Por favor, ingrese un número positivo para el precio mínimo.");
                }
            } while (precioMinimo < 0);

            var productosFiltrados = inventario.FiltrarYOrdenarProductos(precioMinimo);

            Console.WriteLine("\nProductos filtrados y ordenados:");
            foreach (var producto in productosFiltrados)
            {
                Console.WriteLine(producto);
            }
        }
    }
}

