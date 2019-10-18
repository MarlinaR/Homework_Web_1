using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер");
            int size = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите min");
            int min = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите max");
            int max = int.Parse(Console.ReadLine());
            int[] array = new int[size];
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(min, max);
                Console.Write(array[i]);
                Console.Write(' ');
            }
                

        }
    }
}
