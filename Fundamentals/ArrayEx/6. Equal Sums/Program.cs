using System;
using System.Linq;

namespace _6._Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rightSum = 0;
            int leftSum = 0;
            bool flag = true;

            for (int i = 0; i < num.Length; i++)
            {
                if (num.Length == 1)
                {
                    Console.WriteLine(0);
                    return;
                }
                for (int j = i - 1; j >= 0; j--)
                {
                    leftSum += num[j];
                }

                for (int z = i + 1; z < num.Length; z++)
                {
                    rightSum += num[z];
                }

                if (rightSum == leftSum)
                {
                    Console.WriteLine(i);
                    flag = false;
                    break;
                }
                else
                {
                    leftSum = 0;
                    rightSum = 0;
                }
            }

            if (flag)
            {
                Console.WriteLine("no");
            }

        }
    }
}
