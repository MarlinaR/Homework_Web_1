using System;

namespace FormulaAggregator
{
    class FormulaAggregator
    {
        //Запрашивает у пользователя переменную, входной параметр - название переменной (наприме "Х")
        public static double GetParam(string paramName)
        {
            Console.Write("Enter {0} variable: ", paramName);
            string numInput = Console.ReadLine();

            double goodNumInput = 0;
            while (!double.TryParse(numInput, out goodNumInput))
            {
                Console.Write("Invalid input, enter valid value: ");
                numInput = Console.ReadLine();
            }

            return goodNumInput;
        }
        public static double DoOperation(int id)
        {
            //NaN - Not a Number. используется если функция не сможет вывести результат.
            double result = double.NaN;

            switch (id)
            {
                case 0:
                    double x = GetParam("x"); //запрашиваем нужные переменные затем выводим ответ
                    double a = GetParam("a");
                    double b = GetParam("b");
                    result = Math.Tan(x) * Math.Tan(2 * x) / (Math.Pow(a, 2) + Math.Pow(b, 2) + 1);
                    break;
                default:
                    break;
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            int MAX_FORMULAS = 1; //Количество формул, расчет на то что считаются с 0
            double result;
            Console.WriteLine("Console formula aggregator in C#\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                Console.Write("Choose formula: \n");
                Console.Write("0) y = tg(x) * tg(2x) / (a^2 + b^2 + 1)\n");
                Console.Write("0) y = tg(x) * tg(2x) / (a^2 + b^2 + 1)\n");
                //пиши еще формулы, увеличь MAX_FORMULAS


                //выбор номера формулы
                int formulaId = -1;
                while (formulaId < 0 || formulaId >= MAX_FORMULAS)
                {
                    string tempId = Console.ReadLine();
                    while (!int.TryParse(tempId, out formulaId))
                    {
                        Console.Write("Invalid input, enter integer value: ");
                        tempId = Console.ReadLine();
                    }
                    formulaId = Convert.ToInt32(tempId);
                }

                //вычисления. try catch для выявления ошибок
                try
                {
                    result = FormulaAggregator.DoOperation(formulaId);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("Mathematical error.\n");
                    }
                    else Console.WriteLine("Your result: {0}\n", result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Catch an exception.\n - Details: " + ex.Message);
                }

                Console.WriteLine("------------------------\n");

                Console.Write("Enter 'no' to close the app, or enter any other to continue: ");
                if (Console.ReadLine() == "no") endApp = true;
                Console.WriteLine("\n");
            }
            return;
        }
    }
}