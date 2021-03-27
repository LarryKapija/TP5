using System;
using System.Collections;
using System.Collections.Generic;

namespace TP5
{
    class Program
    {
        static void Main(string[] args)
        {
            string oracion;
            Console.Write("Escriba su oración: ");
            oracion = Console.ReadLine();
            oracion = reverse(oracion);
            Console.WriteLine($"\nOracion revertida: {oracion}");
            

            
            LaColaLoca cola = new LaColaLoca();
            
            for (int i = 1; i <= 10; i++)
            {
                cola.Encolar(i);
            }
            Console.WriteLine("\nPrimera cola: ");
            printColaLoca(cola);
            
            Console.Write("\n\nInserte el numero reversor: ");
            int num = Convert.ToInt16(Console.ReadLine());

            try
            {
                cola = reorder(cola,num);
                
                Console.WriteLine("\nCola loca nueva: ");
                printColaLoca(cola);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

        }
        static string reverse(string s)
        {
            Stack stack = new Stack();
            string[] words = s.Split(" ");

            foreach (string item in words)
            {
                stack.Push(item);
            }
            string oracion="";
            foreach (string item in stack)
            {
                oracion += $"{item} ";
            }
            return oracion;

        }
        static LaColaLoca reorder(LaColaLoca colaVieja, int n)
        {
            if (n>colaVieja.Cantidad)
            {
                throw new Exception("El numero insertado esta fuera del rango");
            }
            LaColaLoca colaNueva = new LaColaLoca();
            Stack<int> pila = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                pila.Push(colaVieja.Tope);
                colaVieja.Desencolar();
            }

            foreach (int item in pila)
            {
                colaNueva.Encolar(item);
            }

            foreach (int item in colaVieja)
            {
                colaNueva.Encolar(item);
            }
            return colaNueva;
        }
        static void printColaLoca(LaColaLoca cola)
        {
            foreach (var item in cola)
            {
                Console.Write($"{item} ->");
            }
        }

    }
    public class LaColaLoca : IEnumerable
    {
        /* 
        Dado un valor entero N y una Cola de números enteros, se requiere reversar el orden de los primeros N elementos manteniendo el mismo orden para los demás elementos
        Debe realizar la implementación de la Cola utilizando una Lista Enlazada Simple y solo puede contener las siguientes operaciones:
        -encolar(i) : Añade un elemento i a la cola
        -desencolar() : Retira el elemento que se encuentra al inicio
        -cantidad() : Devuelve la cantidad de elementos que posee la cola
        -tope() : Indica cuál es el primer elemento de la cola
        */

        LinkedList<int> cola = new LinkedList<int>();
        

        public void Encolar(int i)
        {
            cola.AddLast(i);
        }

        public void Desencolar()
        {
            cola.RemoveFirst();
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)cola).GetEnumerator();
        }

        public int Cantidad
        {
            get
            {
                return cola.Count;
            }
        }
        public int Tope
        {
            get
            {
                return cola.First.Value;
            }
        }
    }

}
