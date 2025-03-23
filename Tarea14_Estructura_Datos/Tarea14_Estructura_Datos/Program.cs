using System;

class NodesTree
{
    public int Valor;
    public NodesTree Izquierda, Derecha;

    public NodesTree(int valor)
    {
        this.Valor = valor;
        Izquierda = Derecha = null;
    }
}

class ArbolBusqueda
{
    private NodesTree root;

    public void Agregar(int valor)
    {
        root = AgregarNodo(root, valor);
    }

    private NodesTree AgregarNodo(NodesTree nodo, int valor)
    {
        if (nodo == null)
            return new NodesTree(valor);

        if (valor < nodo.Valor)
            nodo.Izquierda = AgregarNodo(nodo.Izquierda, valor);
        else if (valor > nodo.Valor)
            nodo.Derecha = AgregarNodo(nodo.Derecha, valor);

        return nodo;
    }

    public void MostrarInorden()
    {
        RecorrerInorden(root);
        Console.WriteLine();
    }

    private void RecorrerInorden(NodesTree nodo)
    {
        if (nodo != null)
        {
            RecorrerInorden(nodo.Izquierda);
            Console.Write(nodo.Valor + " ");
            RecorrerInorden(nodo.Derecha);
        }
    }

    public void MostrarPreorden()
    {
        RecorrerPreorden(root);
        Console.WriteLine();
    }

    private void RecorrerPreorden(NodesTree nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.Valor + " ");
            RecorrerPreorden(nodo.Izquierda);
            RecorrerPreorden(nodo.Derecha);
        }
    }

    public void MostrarPostorden()
    {
        RecorrerPostorden(root);
        Console.WriteLine();
    }

    private void RecorrerPostorden(NodesTree nodo)
    {
        if (nodo != null)
        {
            RecorrerPostorden(nodo.Izquierda);
            RecorrerPostorden(nodo.Derecha);
            Console.Write(nodo.Valor + " ");
        }
    }

    public bool Encontrar(int valor)
    {
        return BuscarNodo(root, valor);
    }

    private bool BuscarNodo(NodesTree nodo, int valor)
    {
        if (nodo == null)
            return false;
        
        if (valor == nodo.Valor)
            return true;

        return valor < nodo.Valor ? BuscarNodo(nodo.Izquierda, valor) : BuscarNodo(nodo.Derecha, valor);
    }
}

class ProgramaPrincipal
{
    static void Main()
    {
        ArbolBusqueda arbol = new ArbolBusqueda();
        int opcion, numero;

        do
        {
            Console.WriteLine("\nGestión del Árbol Binario:");
            Console.WriteLine("1. Insertar un valor");
            Console.WriteLine("2. Buscar un valor");
            Console.WriteLine("3. Mostrar en Inorden");
            Console.WriteLine("4. Mostrar en Preorden");
            Console.WriteLine("5. Mostrar en Postorden");
            Console.WriteLine("6. Salir");
            Console.Write("Selecciona una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese un número: ");
                    numero = int.Parse(Console.ReadLine());
                    arbol.Agregar(numero);
                    break;
                case 2:
                    Console.Write("Número a buscar: ");
                    numero = int.Parse(Console.ReadLine());
                    Console.WriteLine(arbol.Encontrar(numero) ? "Valor encontrado" : "Valor no encontrado");
                    break;
                case 3:
                    Console.WriteLine("Recorrido en Inorden:");
                    arbol.MostrarInorden();
                    break;
                case 4:
                    Console.WriteLine("Recorrido en Preorden:");
                    arbol.MostrarPreorden();
                    break;
                case 5:
                    Console.WriteLine("Recorrido en Postorden:");
                    arbol.MostrarPostorden();
                    break;
                case 6:
                    Console.WriteLine("Finalizando el programa...");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        } while (opcion != 6);
    }
}