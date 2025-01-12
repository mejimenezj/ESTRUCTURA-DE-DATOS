// See https://aka.ms/new-console-template for more information

//Escribir un programa que almacene las asignaturas de un curso (por ejemplo Matemáticas, Física, Química, Historia y Lengua) en una lista y la muestre por pantalla el mensaje Yo estudio <asignatura>, donde <asignatura> es cada una de las asignaturas de la lista.

namespace Programa1
{
    // Clase que representa una materia
    public class ListaMaterias
    {
        public string Materia { get; set; } // Propiedad para el nombre de la materia

        public ListaMaterias(string materia)
        {
            Materia =  materia;
        }

        public void Mensaje()
        {
            Console.WriteLine($"Yo estudio {Materia}");
        }
    }

    // Clase principal para manejar la lista de materias
    public class Program
    {
        public static void Main(string[] args)
        {
            // Crear una lista de materias
            List<ListaMaterias> subjects = new List<ListaMaterias>
            {
                new ListaMaterias("Matemáticas"),
                new ListaMaterias("Física"),
                new ListaMaterias("Química"),
                new ListaMaterias("Historia"),
                new ListaMaterias("Lengua")
            };

            // Mostrar el mensaje para cada materia
            foreach (var subject in subjects)
            {
                subject.Mensaje();
            }
        }
    }
}
