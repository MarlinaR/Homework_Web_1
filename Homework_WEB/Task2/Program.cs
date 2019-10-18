using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c = 0;
            string flag_continue = "";
            while (flag_continue != "exit")
            {
                Console.WriteLine("Введите знак операции");
                char str = TryChar();

                Console.WriteLine("Введите два числа");
                a = TryNum();
                b = TryNum();

                if (str == '+') c = a + b;
                switch (str)
                {
                    case '+':
                        c = a + b;
                        break;
                    case '-':
                        c = a - b;
                        break;
                    case '/':
                        if (b == 0) Console.WriteLine("Ошибка в исполнении: Деление на ноль");
                        else
                            c = a / b;
                        break;
                    case '*':
                        c = a * b;
                        break;
                }
                Console.WriteLine(c);
                Console.WriteLine("Хотите завершить выполнение программы ? Введите - exit");
                flag_continue = Console.ReadLine();
            }
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
        static char TryChar()
        {
            string str_s;
            char s = ' ';
            bool flag_success = false;
            while (!flag_success)
            {
                str_s = Console.ReadLine();
                if (!char.TryParse(str_s, out s) || (str_s != "+" && str_s != "-" && str_s != "*" && str_s != "/"))
                    Console.WriteLine("Неверный знак операции. Повторите попытку (-,+,/,*)");
                else  flag_success = true;
            }
            return s;
        }
    }
}
