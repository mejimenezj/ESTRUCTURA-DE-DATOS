using System;
class Nodo
{
    public string Titulo { get; set; }
    public Nodo Izquierdo { get; set; }
    public Nodo Derecho { get; set; }
    public Nodo(string titulo)
    {
        Titulo = titulo;
        Izquierdo = null;
        Derecho = null;
    }
}
class ArbolBinario
{
    public Nodo Raiz { get; set; }

    public ArbolBinario()
    {
        Raiz = null;
    }
    // Método para insertar un título en el árbol
    public void Insertar(string titulo)
    {
        Raiz = InsertarRecursivo(Raiz, titulo);
    }
    private Nodo InsertarRecursivo(Nodo nodo, string titulo)
    {
        if (nodo == null)
        {
            return new Nodo(titulo);
        }
        // Comparar títulos para decidir si va a la izquierda o derecha
        if (string.Compare(titulo, nodo.Titulo, StringComparison.OrdinalIgnoreCase) < 0)
        {
            nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, titulo);
        }
        else if (string.Compare(titulo, nodo.Titulo, StringComparison.OrdinalIgnoreCase) > 0)
        {
            nodo.Derecho = InsertarRecursivo(nodo.Derecho, titulo);
        }

        return nodo;
    }
    // Método para buscar un título en el árbol (recursivo)
    public bool BuscarRecursivo(string titulo)
    {
        return BuscarRecursivo(Raiz, titulo);
    }
    private bool BuscarRecursivo(Nodo nodo, string titulo)
    {
        if (nodo == null)
        {
            return false;
        }

        if (string.Equals(nodo.Titulo, titulo, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        if (string.Compare(titulo, nodo.Titulo, StringComparison.OrdinalIgnoreCase) < 0)
        {
            return BuscarRecursivo(nodo.Izquierdo, titulo);
        }
        else
        {
            return BuscarRecursivo(nodo.Derecho, titulo);
        }
    }
    // Método para buscar un título en el árbol (iterativo)
    public bool BuscarIterativo(string titulo)
    {
        Nodo actual = Raiz;

        while (actual != null)
        {
            if (string.Equals(actual.Titulo, titulo, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (string.Compare(titulo, actual.Titulo, StringComparison.OrdinalIgnoreCase) < 0)
            {
                actual = actual.Izquierdo;
            }
            else
            {
                actual = actual.Derecho;
            }
        }

        return false;
    }
}
class Program
{
    static void Main()
    {
        // Crear el árbol y insertar los títulos de las revistas
        ArbolBinario arbol = new ArbolBinario();
        string[] titulos = {
            "Revista Científica",
            "Tecnología Hoy",
            "Mundo Digital",
            "Ciencia y Salud",
            "Historia Viva",
            "Espacio y Universo",
            "Innovación y Futuro",
            "Ecología Moderna",
            "Psicología Práctica",
            "Economía Global"
        };
        foreach (var titulo in titulos)
        {
            arbol.Insertar(titulo);
        }    
        while (true)
        {
            Console.WriteLine("\nMenú de búsqueda de revistas:");
            Console.WriteLine("1. Buscar título (Iterativa)");
            Console.WriteLine("2. Buscar título (Recursiva)");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            if (opcion == "3")
            {
                Console.WriteLine("Fin del programa");
                break;
            }

            if (opcion != "1" && opcion != "2")
            {
                Console.WriteLine("Opción no válida. Intente de nuevo.");
                continue;
            }

            Console.Write("Ingrese el título a buscar: ");
            string titulo = Console.ReadLine();

            bool encontrado = opcion switch
            {
                "1" => arbol.BuscarIterativo(titulo),
                "2" => arbol.BuscarRecursivo(titulo),
                _ => false
            };

            Console.WriteLine(encontrado ? "Encontrado" : "No encontrado");
        }
    }
}