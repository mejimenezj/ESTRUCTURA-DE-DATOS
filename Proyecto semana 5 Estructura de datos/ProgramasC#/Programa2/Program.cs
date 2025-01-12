// See https://aka.ms/new-console-template for more information

//Escribir un programa que pregunte al usuario los números ganadores de la lotería primitiva, los almacene en una lista y los muestre por pantalla ordenados de menor a mayor.

namespace Programa2
{
    // Clase que representa el manejo de números ganadores
    public class Loteria
    {
        public List<int> NumerosGanadores { get; private set; } // Lista de números ganadores

        public Loteria()
        {
            NumerosGanadores = new List<int>();
        }

        public void AgregarNumerosGanadores()
        {
            //Introducción de números
            for (int i = 0; i < 6; i++)
            {
                int numero;
                while (true)
                {
                    Console.Write($"Introduce un número ganador {i + 1}: ");
                    string numString = Console.ReadLine()!;
                    if (int.TryParse(numString, out numero) && numero >= 1 && !NumerosGanadores.Contains(numero))
                    {
                        NumerosGanadores.Add(numero);
                        break;
                    }
                    else if (NumerosGanadores.Contains(numero))
                    {
                        Console.WriteLine("El número ya ha sido introducido. Por favor, introduce un número diferente.");
                    }
                    else
                    {
                        Console.WriteLine("Entrada no válida. Por favor, introduce un número entero mayor que 0");
                    }
                }
            }
        }

        public void OrdenarNumeros()
        {
            NumerosGanadores.Sort();
        }

        public void MostrarNumerosGanadores()
        {
            Console.WriteLine("Los números ganadores son: " + string.Join(", ", NumerosGanadores));
        }
    }

    // Clase principal para ejecutar el programa
    public class Program
    {
        public static void Main(string[] args)
        {
            Loteria lottery = new Loteria();
            lottery.AgregarNumerosGanadores();
            lottery.OrdenarNumeros();
            lottery.MostrarNumerosGanadores();
        }
    }
}
