using System;

namespace Data_Types_and_VariablesEx
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            int fourthNum = int.Parse(Console.ReadLine());
            int result = 0;

            result = firstNum + secondNum;
            result = result / thirdNum;
            result = result * fourthNum;

            Console.WriteLine(result);
        }
    }
}
