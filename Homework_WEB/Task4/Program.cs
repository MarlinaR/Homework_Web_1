using System;

namespace Task4
{
    class Program
    {
        static int partition(int[] array, int start, int end)
        {
            int temp;
            int marker = start;
            for (int i = start; i < end; i++)
            {
                if (array[i] < array[end]) 
                {
                    temp = array[marker]; 
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }

        static void quicksort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = partition(array, start, end);
            quicksort(array, start, pivot - 1);
            quicksort(array, pivot + 1, end);
        }
        static void Main(string[] args)
        {
            int size = 10;
            int[] array = new int[size];
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(1, 100);
            }
            quicksort(array,0, array.Length-1);
            Console.WriteLine("Вывести по > или <");
            if (Console.ReadLine() == ">")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i]);
                    Console.Write(' ');

                }
            } else
            {
                for (int i = array.Length-1; i >= 0; i--)
                {
                    Console.Write(array[i]);
                    Console.Write(' ');

                }
            }
        }
    }
}
