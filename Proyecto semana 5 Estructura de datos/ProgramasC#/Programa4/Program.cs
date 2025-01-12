// See https://aka.ms/new-console-template for more information

//Escribir un programa que almacene el abecedario en una lista, elimine de la lista las letras que ocupen posiciones múltiplos de 3, y muestre por pantalla la lista resultante.

namespace Programa4
{
    // Clase que representa la manipulación del alfabeto
    public class Alfabeto
    {
        public List<char> Letras { get; set; } // Lista de letras del alfabeto

        public Alfabeto()
        {
            Letras = new List<char>
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'ñ', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
            };
        }

        public void EliminarPosicionesMultiplosDe3()
        {
            for (int i = Letras.Count; i > 1; i--)
            {
                if (i % 3 == 0)
                {
                    Letras.RemoveAt(i - 1);
                }
            }
        }

        public void MostrarAlfabeto()
        {
            Console.WriteLine("Letras restantes en el alfabeto: " + string.Join(", ", Letras));
        }
    }

    // Clase principal para ejecutar el programa
    public class Programa
    {
        public static void Main(string[] args)
        {
            Alfabeto alfabeto = new Alfabeto();
            alfabeto.EliminarPosicionesMultiplosDe3();
            alfabeto.MostrarAlfabeto();
        }
    }
}

