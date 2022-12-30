using System;

namespace Constrains
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(5.CompareTo(6)); //-1 kogato desniqt e po-golqm
            Console.WriteLine(5.CompareTo(5)); //0 zashtoto sa ravni
            Console.WriteLine(5.CompareTo(1)); //1 kogato leviqt element e po-golqm
        }
    }
}
