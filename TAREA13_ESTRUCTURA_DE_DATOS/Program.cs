using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> catalogo = new List<string>
        {
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

        while (true)
        {
            Console.WriteLine("\nMenú de búsqueda de revistas:");
            Console.WriteLine("1. Buscar título (Iterativa)");
            Console.WriteLine("2. Buscar título (Recursiva)");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            if (opcion == "3")
                break;

            Console.Write("Ingrese el título a buscar: ");
            string titulo = Console.ReadLine();

            bool encontrado = opcion switch
            {
                "1" => BusquedaIterativa(catalogo, titulo),
                "2" => BusquedaRecursiva(catalogo, titulo, 0),
                _ => false
            };

            Console.WriteLine(encontrado ? "Encontrado" : "No encontrado");
        }
    }

    static bool BusquedaIterativa(List<string> catalogo, string titulo)
    {
        foreach (var revista in catalogo)
        {
            if (revista.Equals(titulo, StringComparison.OrdinalIgnoreCase))
                return true;
        }
        return false;
    }

    static bool BusquedaRecursiva(List<string> catalogo, string titulo, int indice)
    {
        if (indice >= catalogo.Count)
            return false;
        if (catalogo[indice].Equals(titulo, StringComparison.OrdinalIgnoreCase))
            return true;
        return BusquedaRecursiva(catalogo, titulo, indice + 1);
    }
}
