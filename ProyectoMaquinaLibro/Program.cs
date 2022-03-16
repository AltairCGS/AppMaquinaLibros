using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMaquinaLibros
{
    class Program
    {
        static void Main(string[] args)
        {
            Maquina maquina = new Maquina();

            while (true)
            {
                Console.WriteLine("Bienvenido a la maquina de libros");
                Console.WriteLine("");
                Console.WriteLine("Libros: \n{0}", maquina.listarLibros());
                Console.WriteLine("//-------------// ");
                Console.WriteLine("");
                Console.WriteLine("1. Agregar libro ");
                Console.WriteLine("2. Modificar libro ");
                Console.WriteLine("3. Eliminar libro ");
                Console.WriteLine("4. Comprar libro ");
                Console.WriteLine("Ingresa una opcion: ");
                string opcion = Console.ReadLine();
                Console.WriteLine("");

                switch (opcion)
                {
                    case "1":
                        Libro libro = new Libro();
                        Console.Write("Codigo: ");
                        libro.Codigo = Console.ReadLine();

                        Console.Write("Nombre: ");
                        libro.Nombre = Console.ReadLine();

                        Console.Write("Categoria: ");
                        libro.Categoria = Console.ReadLine();

                        Console.Write("Cantidad: ");
                        libro.Cantidad = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Valor: ");
                        libro.Valor = double.Parse(Console.ReadLine());

                        maquina.agregarLibro(libro);
                        Console.WriteLine("");
                        Console.WriteLine("Libros: \n{0}", maquina.listarLibros());
                        Console.WriteLine("//-------------//");

                        break;
                    case "2":
                        Console.Write("Codigo: ");
                        string ccodigo = Console.ReadLine();

                        Console.Write("Nuevo nombre: ");
                        string nnombre = Console.ReadLine();

                        Console.Write("Nueva categoria: ");
                        string ncategoria = Console.ReadLine();

                        Console.Write("Nuevo valor: ");
                        double nvalor = double.Parse(Console.ReadLine());

                        maquina.modificarLibro(ccodigo, nnombre, ncategoria, nvalor);
                        Console.WriteLine("Libros: \n{0}", maquina.listarLibros());
                        Console.WriteLine("");
                        Console.WriteLine("//-------------//");

                        break;
                    case "3":
                        Console.Write("Codigo: ");
                        string codigo = Console.ReadLine();

                        maquina.eliminarLibro(codigo);
                        Console.WriteLine("");
                        Console.WriteLine("Libros: \n{0}", maquina.listarLibros());
                        Console.WriteLine("//-------------//");

                        break;
                    case "4":
                        Console.Write("Codigo: ");
                        string codigo_venta = Console.ReadLine();

                        Console.Write("Monedas solo de (1000-500-200-100): ");
                        maquina.Pago = Console.ReadLine();

                        Libro lcomprado = maquina.vender(codigo_venta);

                        if (lcomprado == null)
                        {
                            Console.WriteLine("No se pudo sacar el libro");
                        }
                        else
                        {
                            Console.WriteLine("Su libro es {0} {1} y la devuelta es {2}", lcomprado.Codigo, lcomprado.Nombre, lcomprado.Cambio);
                        }

                        break;

                }

                Console.WriteLine("Desea continuar si/no: ");
                if (Console.ReadLine() == "no")
                {
                    break;
                }
                Console.WriteLine("");
                Console.WriteLine("//---------------------------------------------//");



            }

        }
    }
}
