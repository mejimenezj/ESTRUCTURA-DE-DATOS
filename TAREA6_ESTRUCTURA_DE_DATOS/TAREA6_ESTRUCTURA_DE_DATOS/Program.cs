using System;

namespace LinkedListSearch
{
    // Nodo de la lista enlazada
    public class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }

    // Clase de la lista enlazada
    public class LinkedList
    {
        private Node head;

        public LinkedList()
        {
            head = null;
        }

        // Método para agregar un nodo al final de la lista
        public void Add(int data)
        {
            Node newNode = new Node(data);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        // Método para mostrar los elementos de la lista
        public void Display()
        {
            if (head == null)
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            Node current = head;
            while (current != null)
            {
                Console.Write(current.Data + " -> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }

        // Método para buscar un dato en la lista
        public int Search(int value)
        {
            if (head == null)
            {
                Console.WriteLine("La lista está vacía. No se puede buscar el valor.");
                return 0;
            }

            Node current = head;
            int count = 0;

            while (current != null)
            {
                if (current.Data == value)
                {
                    count++;
                }
                current = current.Next;
            }

            if (count == 0)
            {
                Console.WriteLine($"El dato {value} no fue encontrado en la lista.");
            }
            else
            {
                Console.WriteLine($"El dato {value} fue encontrado {count} veces en la lista.");
            }

            return count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            // Agregar datos a la lista
            list.Add(10);
            list.Add(20);
            list.Add(10);
            list.Add(30);
            list.Add(10);
            list.Add(40);

            Console.WriteLine("Lista enlazada:");
            list.Display();

            // Búsqueda de un dato
            Console.WriteLine("\nBúsqueda de valores en la lista:");
            list.Search(10); // Debería encontrar 3 ocurrencias
            list.Search(20); // Debería encontrar 1 ocurrencia
            list.Search(50); // No debería encontrar el dato
        }
    }
}