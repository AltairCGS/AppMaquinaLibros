using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMaquinaLibros
{
    public class Maquina
    {
        public List<Libro> Libros { get; set; }
        public string Pago { get; set; }

        public Maquina()
        {
            this.Libros = new List<Libro>();

            Libro libro1 = new Libro();
            libro1.Codigo = "01";
            libro1.Nombre = "Algebra y trigonometria";
            libro1.Categoria = "Ciencias basicas";
            libro1.Cantidad = 10;
            libro1.Valor = 2000;

            Libro libro2 = new Libro();
            libro2.Codigo = "02";
            libro2.Nombre = "Matematicas discretas";
            libro2.Categoria = "Ciencias basicas";
            libro2.Cantidad = 15;
            libro2.Valor = 5000;

            this.Libros.Add(libro1);
            this.Libros.Add(libro2);

        }
        //Validamos si la maquina ya tiene el libro.
        public int validaLibro(string codigo)
        {
            int encontro = -1;

            for (int i = 0; i < this.Libros.Count; i++)
            {
                if (this.Libros[i].Codigo == codigo)
                {
                    encontro = i;
                }
            }

            return encontro;
        }

        //Modificamos el libro.
        public bool modificarLibro(string codigo, string nombre, string categoria, double valor)
        {
            int enc = this.validaLibro(codigo);

            if (enc >= 0)
            {
                this.Libros[enc].cambiarNombre(nombre);
                this.Libros[enc].cambiarCategoria(categoria);
                this.Libros[enc].cambiarValor(valor);
                return true;
            }
            return false;
        }

        //Agregamos el libro.
        public bool agregarLibro(Libro libro)
        {
            int enc = this.validaLibro(libro.Codigo);
            if (enc >= 0)
            {
                this.Libros[enc].sumarCantidad(libro.Cantidad);
            }
            else
            {
                this.Libros.Add(libro);
            }

            return true;
        }

        //Elimina un libro de la maquina.
        public bool eliminarLibro(string codigo)
        {
            int enc = this.validaLibro(codigo);

            if (enc >= 0)
            {
                this.Libros.RemoveAt(enc);
                return true;
            }

            return false;
        }

        //Sacamos el total de las monedas ingresadas por el usuario.
        public double validarMonedas(string[] monedas)
        {
            double total = 0;
            foreach (string item in monedas)
            {
                try
                {
                    total += float.Parse(item);
                }
                catch (Exception e) { }
            }
            return total;
        }

        //Vendemos un libro.
        public Libro vender(string codigo)
        {
            int enc = this.validaLibro(codigo);
            if (enc >= 0)
            {
                if (this.Libros[enc].validarCantidad())
                {
                    string[] monedas = this.Pago.Split('-');

                    double total = this.validarMonedas(monedas);

                    if (this.Libros[enc].validarValor(total))
                    {
                        this.Libros[enc].restarLibro();

                        return this.Libros[enc];
                    }
                }
            }
            return null;
        }

        //Listamos los libros.
        public string listarLibros()
        {
            string lista = "";
            foreach (Libro item in this.Libros)
            {
                lista += item.Codigo + " " + item.Nombre + " " + item.Categoria + " " + item.Cantidad + " " + item.Valor + "\n";
            }
            return lista;

        }
    }
}
