﻿using System;
using System.Collections.Generic;

namespace ParqueDiversiones
{
    // Clase Persona
    public class Persona
    {
        public string Nombre { get; set; }

        public Persona(string nombre)
        {
            Nombre = nombre;
        }
    }

    // Clase Atraccion
    public class Atraccion
    {
        private Queue<Persona> colaEspera = new Queue<Persona>();
        private const int TotalAsientos = 30;
        private List<Persona> asientos = new List<Persona>(TotalAsientos);

        // Agregar una persona a la cola de espera
        public void AgregarPersona(Persona persona)
        {
            if (asientos.Count < TotalAsientos)
            {
                asientos.Add(persona);
                Console.WriteLine($"Asiento asignado a {persona.Nombre}.");
            }
            else
            {
                colaEspera.Enqueue(persona);
                Console.WriteLine($" {persona.Nombre} se ha agregado a la cola de espera.");
            }
        }

        // Ejecutar la atracción y asignar los asientos
        public void EjecutarAtraccion()
        {
            while (asientos.Count > 0 || colaEspera.Count > 0)
            {
                Console.WriteLine("La atracción está lista para comenzar.");
                Console.WriteLine("Personas en los asientos:");

                foreach (var persona in asientos)
                {
                    Console.WriteLine(persona.Nombre);
                }
                Console.WriteLine("--- Fin del recorrido ---\n");

                // Vaciar los asientos y reasignar desde la cola
                asientos.Clear();
                for (int i = 0; i < TotalAsientos && colaEspera.Count > 0; i++)
                {
                    Persona siguientePersona = colaEspera.Dequeue();
                    asientos.Add(siguientePersona);
                    Console.WriteLine($"{siguientePersona.Nombre} ha subido a la atracción.");
                }

                if (asientos.Count > 0)
                {
                    Console.WriteLine("\nPresione una tecla para iniciar el próximo recorrido.");
                    Console.ReadKey();
                }
            }
        }

        // Mostrar personas en la cola de espera
        public void MostrarColaEspera()
        {
            if (colaEspera.Count == 0)
            {
                Console.WriteLine("No hay personas en la cola de espera.");
                return;
            }

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Atraccion atraccion = new Atraccion();
            Console.WriteLine("Simulación de asignación de asientos para una atracción en el parque.");

            Console.Write("Ingrese el número de personas que desean subir a la atracción: ");
            int cantidadPersonas;
            bool asientoDisponible=true;
            while (!int.TryParse(Console.ReadLine(), out cantidadPersonas) || cantidadPersonas <= 0)
            {
                Console.Write("Entrada inválida. Ingrese un número válido: ");
            }

            // Agregar personas manualmente según la cantidad ingresada
            for (int i = 1; i <= cantidadPersonas; i++)
            {
                 if(i>30 && asientoDisponible){
                     Console.WriteLine();
                     Console.Write("No hay asientos disponibles ");
                      Console.WriteLine();
                     asientoDisponible=false;
                }
                atraccion.AgregarPersona(new Persona($"Persona {i}"));
               
            }

            Console.WriteLine();
            atraccion.EjecutarAtraccion();
            Console.WriteLine();

            // Mostrar la cola de espera restante
            atraccion.MostrarColaEspera();
        }
    }
}