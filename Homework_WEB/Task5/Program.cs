using System;

namespace FormulaAggregator
{
    class FormulaAggregator
    {
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
            double result = double.NaN;

            switch (id)
            {
                case 0:
                    double x = GetParam("x"); 
                    double a = GetParam("a");
                    double b = GetParam("b");
                    result = Math.Tan(x) * Math.Tan(2 * x) / (Math.Pow(a, 2) + Math.Pow(b, 2) + 1);
                    break;
                case 1:
                    double x1 = GetParam("x");
                    result = x1 * Math.Pow(2 * x1 - 1, 2) * Math.Pow(x1 + 3,2);
                    break;
                case 2:
                    double n = GetParam("n");
                    result = 0;
                    for (double k = 1; k <= n; k++)
                        result += 1 / ((k + 1) * (k + 2));
                    break;
                case 3:
                    double x3 = GetParam("x");
                    result = Math.Log((Math.Sqrt(Math.Pow(x3, 2) + 3) + 2 * Math.Sqrt(Math.Pow(x3, 4) + 1)) / (Math.Pow(x3, 2) + 9));
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
            int MAX_FORMULAS = 4; 
            double result;
            Console.WriteLine("Console formula aggregator in C#\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                Console.Write("Choose formula: \n");
                Console.Write("0) y = tg(x) * tg(2x) / (a^2 + b^2 + 1)\n");
                Console.Write("1) y = x * (2x - 1)^2 * (x + 3)^3\n");
                Console.Write("2) y = sum(1 / ((k + 1) * (k + 2)), где k = 1 .. n\n");
                Console.Write("3) y = ln ((sqrt(x^2 + 3) - 2*sqrt(x^2 + 1))/(x^2 + 9))\n");

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