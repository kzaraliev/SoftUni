using System;

namespace Multidimensional_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[3, 3]
            {
                {1,2,3 },
                {4,5,6 },
                {7,8,9 },
            };

            Console.WriteLine(matrix[1,1]);
           //matrix[0, 0] = 1;
           //matrix[0, 1] = 2;
           //matrix[0, 2] = 3;
           //matrix[0, 3] = 4;

            int x = matrix[0,0]; //vzimane na element v kletka

            int[][] array2D =new int[3][];
            array2D[0] = new int[4]
                { 1,2,3,4 };
            array2D[1] = new int[4]
                { 5,6,7,8 };

            int[] firstRow = array2D[0];
            int[] secondRow = array2D[1];

            Console.WriteLine(String.Join(", ", firstRow));
            Console.WriteLine(String.Join(", ", secondRow));


            Console.WriteLine("");

            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            int[,] matrica = new int[rows, cols];
            int counter = 1;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"matrix [{row}, {col}] = ");
                    matrica[row, col] = int.Parse(Console.ReadLine());
                    counter++;
                }
            }

            matrica.GetLength(0); //broi na redove
            matrica.GetLength(1); //broi koloni
            
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrica[row, col]} ");
                }
                Console.WriteLine();
            }


            
        }
    }
}
