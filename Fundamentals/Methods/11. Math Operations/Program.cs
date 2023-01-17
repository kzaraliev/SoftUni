using System;

namespace _11._Math_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            string @operator = Console.ReadLine();
            int secondNum = int.Parse(Console.ReadLine());

            Console.WriteLine(Calculate(firstNum, @operator, secondNum));
        }

        static double Calculate(int firstNum, string @operator, int secondNum)
        {
            double result = 0;

            switch (@operator)
            {
                case "/":
                    result = firstNum / secondNum;
                    break;
                case "*":
                    result = firstNum * secondNum;
                    break;
                case "+":
                    result = firstNum + secondNum;
                    break;
                case "-":
                    result = firstNum - secondNum;
                    break;
            }

            return result;
        }
    }
}
