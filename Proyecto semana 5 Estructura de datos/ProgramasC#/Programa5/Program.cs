// See https://aka.ms/new-console-template for more information

//Escribir un programa que almacene los vectores (1,2,3) y (-1,0,2) en dos tuplas y muestre por pantalla su producto escalar.

namespace Programa5
{
    // Clase que representa la operación de producto escalar entre dos vectores
    public class Vectores
    {
        public int[] VectorA { get; set; } // Primer vector
        public int[] VectorB { get; set; } // Segundo vector

        public Vectores(int[] vectorA, int[] vectorB)
        {
            VectorA = vectorA;
            VectorB = vectorB;
        }

        public int CalcularProductoEscalar()
        {
            int producto = 0;
            for (int i = 0; i < VectorA.Length; i++)
            {
                producto += VectorA[i] * VectorB[i];
            }
            return producto;
        }

        public void MostrarResultado()
        {
            Console.WriteLine("El producto de los vectores " +
                              "(" + string.Join(", ", VectorA) + ") y (" + string.Join(", ", VectorB) + ") es " +
                              CalcularProductoEscalar());
        }
    }

    // Clase principal para ejecutar el programa
    public class Programa
    {
        public static void Main(string[] args)
        {
            int[] a = { 1, 2, 3 };
            int[] b = { -1, 0, 2 };

            Vectores vectores = new Vectores(a, b);
            vectores.MostrarResultado();
        }
    }
}

