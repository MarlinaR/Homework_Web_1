using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag_success = false;
            double a = 0, b = 0, c = 0;

            Console.WriteLine("Введите два числа");

            a = TryNum();
            b = TryNum();

            flag_success = false;
            while (!flag_success)
            {
                Console.WriteLine("Введите знак операции");
                char str = Convert.ToChar(Console.ReadLine());
                if (str == '+') c = a + b;
                switch (str)
                {
                    case '+':
                        c = a + b;
                        flag_success = true;
                        break;
                    case '-':
                        c = a - b;
                        flag_success = true;
                        break;
                    case '/':
                        if (b == 0) Console.WriteLine("Ошибка в исполнении: Деление на ноль");
                        else
                        {
                            c = a / b;
                        }
                        flag_success = true;
                        break;
                    case '*':
                        c = a * b;
                        flag_success = true;
                        break;
                    default:
                        Console.WriteLine("Неверный знак операции. Повторите попытку (-,+,/,*)");
                        break;
                }
            }
            Console.WriteLine(c);
        }
        static double TryNum()
        {
            string str_a;
            double a = 0;
            bool flag_success = false;
            while (!flag_success)
            {
                str_a = Console.ReadLine();
                if (!double.TryParse(str_a, out a))
                    Console.WriteLine("Аргумент не число. Попробуте еще");
                else flag_success = true;
            }
            return a;
        
        }
    }
}
