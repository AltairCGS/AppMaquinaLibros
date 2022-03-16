using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMaquinaLibros
{
    public class Libro
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
        public double Valor { get; set; }
        public double Cambio { get; set; }


        //Suma a la cantidad de un libro
        public void sumarCantidad(int cantidad)
        {
            this.Cantidad += cantidad;
        }

        //Cambiamos el nombre de un libro en la maquina
        public void cambiarNombre(string nombre)
        {
            this.Nombre = nombre;
        }

        //Cambiamos la categoria de un libro en la maquina
        public void cambiarCategoria(string categoria)
        {
            this.Categoria = categoria;
        }

        //Cambiamos el valor de un libro en la maquina
        public void cambiarValor(double valor)
        {
            this.Valor = valor;
        }

        //Validamos la cantidad de un libro en la maquina
        public bool validarCantidad()
        {
            if (this.Cantidad > 0)
            {
                return true;
            }
            return false;
        }

        //Restamos el valor ingresado por el usuario con el valor del libro y sacamos el cambio (devuelta)
        public bool validarValor(double valor)
        {
            if (this.Valor <= valor)
            {
                this.Cambio = valor - this.Valor;
                return true;
            }
            return false;
        }

        //Restamos -1 a un libro vendido
        public void restarLibro()
        {
            this.Cantidad--;
        }
    }
}