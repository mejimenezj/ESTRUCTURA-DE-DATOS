// See https://aka.ms/new-console-template for more information

//Escribir un programa que almacene las asignaturas de un curso (por ejemplo Matemáticas, Física, Química, Historia y Lengua) en una lista y la muestre por pantalla.

namespace Programa3
{
    // Clase que representa una materia con su nota
    public class Materia
    {
        public string Nombre { get; set; } // Nombre de la materia
        public int Nota { get; set; } // Nota obtenida

        public Materia(string nombre, int nota)
        {
            Nombre = nombre;
            Nota = nota;
        }

        public void MostrarNota()
        {
            Console.WriteLine($"En {Nombre} has sacado {Nota}.");
        }
    }

    // Clase principal para las materias y notas
    public class Programa
    {
        public static void Main(string[] args)
        {
            List<Materia> materias = new List<Materia>();
            string[] nombresMaterias = { "Matemáticas", "Física", "Química", "Historia", "Lengua" };

            foreach (string nombre in nombresMaterias)
            {
                int nota;
                while (true)
                {
                    Console.Write($"¿Qué nota has sacado en {nombre}? ");
                    string numNota = Console.ReadLine()!;
                    if (int.TryParse(numNota, out nota) && nota >= 0)
                    {
                        materias.Add(new Materia(nombre, nota));
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Por favor, introduce una nota válida desde 0");
                    }
                }
            }

            Console.WriteLine("\nResumen de notas:");
            foreach (Materia materia in materias)
            {
                materia.MostrarNota();
            }
        }
    }
}

