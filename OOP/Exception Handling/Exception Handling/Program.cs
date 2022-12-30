using System;

namespace Exception_Handling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            Console.WriteLine($"{x}/{y} = {x/y}");

            }
            catch (ArithmeticException ex) //vlizat vsiscki deca na dadeniq klas
            {

                Console.WriteLine(ex.Message);
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Invalid number");
            }
            catch(NullReferenceException)
            {
                Console.WriteLine("Value was null!");
            }

            Console.WriteLine("After try-catch block");
        }
    }
}
