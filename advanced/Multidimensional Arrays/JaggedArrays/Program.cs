using System;
using System.Linq;

namespace JaggedArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //JAGGED ARRAY

            int[][] jagged = new int[3][];

            jagged[0] = new int[2]
            {
                1,
                2
            };

            jagged[1] = new int[3]
            {
                1, 2, 3

            };

            jagged[2] = new int[4]
            {
                5, 6, 7, 8
            };


            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.WriteLine($"{jagged[row][col]}");
                }
            }


            int[][] jaggedArr = new int[int.Parse(Console.ReadLine())][];

            for (int i = 0; i < jaggedArr.Length; i++)
            {
                jaggedArr[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            for (int i = 0; i < jaggedArr.Length; i++)
            {
                Console.WriteLine(String.Join(", ", jaggedArr[i]));
            }
        }
    }
}
