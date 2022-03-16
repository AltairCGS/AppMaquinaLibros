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

            Libro nombre = new Libro();
            nombre.Codigo = "01";
            nombre.Nombre = "Nombre1";
            nombre.Categoria = "Fantasia";
            nombre.Cantidad = 5;
            nombre.Valor = 2000;

            Libro nombre2 = new Libro();
            nombre2.Codigo = "02";
            nombre2.Nombre = "Nombre2";
            nombre2.Categoria = "Ficcion";
            nombre2.Cantidad = 2;
            nombre2.Valor = 1500;

            this.Libros.Add(nombre);
            this.Libros.Add(nombre2);

        }
        //Validamos si la maquina ya tiene el libro
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

        //Crear metodo "modificarLibro"

        public bool agregarLibro(Libro libro)
        {
            int enc = this.validaLibro(libro.Codigo);
            if (enc > 0)
            {
                this.Libros[enc].sumarCantidad(libro.Cantidad);
            }
            else
            {
                this.Libros.Add(libro);
            }

            return true;
        }



        //Elimina un libro de la maquina
        //probando github cambios
        //Probando otro cambio

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

        // 1000-500-200-100
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
