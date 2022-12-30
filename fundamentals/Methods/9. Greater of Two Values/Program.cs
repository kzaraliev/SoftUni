using System;

namespace _9._Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "int":
                    int num1 = int.Parse(Console.ReadLine());
                    int num2 = int.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(num1, num2));
                    break;
                case "char":
                    char sym1 = char.Parse(Console.ReadLine());
                    char sym2 = char.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(sym1, sym2));

                    break;
                case "string":
                    string word1 = Console.ReadLine();
                    string word2 = Console.ReadLine();
                    Console.WriteLine(GetMax(word1, word2));

                    break;
            }
          
        }


        static int GetMax(int num1, int num2)
        {
            if (num1 > num2)
            {
                return num1;
            }
            else
            {
                return num2;
            }
        }

        static char GetMax(char sym1, char sym2)
        {
            if (sym1 > sym2)
            {
                return sym1;
            }
            else
            {
                return sym2;
            }
        }

        static string GetMax(string word1, string word2)
        {
            int result = word1.CompareTo(word2);
            if (result > 0)
            {
                return word1;
            }
            else
            {
                return word2;
            }
        }
    }
}
