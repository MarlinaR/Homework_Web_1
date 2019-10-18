using System;

namespace ConsoleApp1
{
    class Program
    {
        class getStringInfo
        {
            public static void doTheThings(string str)
            {
                
                int notWhiteSpaceSymbols = 0, wordCount = 0;
                double symbolToWordRatio;
                string lastCharsWord = string.Empty;

                for (int i = 1; i < str.Length; i++) 
                {
                    if (char.IsLetterOrDigit(str[i - 1]) == true)
                    {
                        notWhiteSpaceSymbols++;
                        if (char.IsLetterOrDigit(str[i]) == false)
                        {
                            wordCount++;
                            lastCharsWord += Convert.ToString(str[i - 1]);
                        }
                    }
                    else if (char.IsWhiteSpace(str[i - 1]) == false)
                        notWhiteSpaceSymbols++;
                }

                if (char.IsWhiteSpace(str[str.Length-1]) == false)
                    notWhiteSpaceSymbols++;
                if (char.IsLetterOrDigit(str[str.Length-1]) == true)
                {
                    wordCount++;
                    lastCharsWord += Convert.ToString(str[str.Length-1]);
                }

                symbolToWordRatio = Convert.ToDouble(notWhiteSpaceSymbols) / Convert.ToDouble(wordCount);

                Console.WriteLine("Количество слов: {0};", wordCount);
                Console.WriteLine("Количество символов без пробелов: {0};", notWhiteSpaceSymbols);
                Console.WriteLine("Соотношение количество символов без пробелов к количеству слов: {0:F2};", symbolToWordRatio);
                Console.WriteLine("Слово из последних символов слов: \"{0}\";", lastCharsWord);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Ведите строку или проганите тест:");
            string str = Console.ReadLine();
            if (str == string.Empty)
            {
                str = "Lorem Ipsum - это текст-\"рыба\", часто используемый в печати и вэб-дизайне";
            }
            Console.WriteLine(str + "\n");
            getStringInfo.doTheThings(str);

        }
    }
}