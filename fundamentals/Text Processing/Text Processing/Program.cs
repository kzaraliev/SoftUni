using System;

namespace Text_Processing
{
    class Program
    {
        static void Main(string[] args)
        {
            string greeting = "Hello, C#";
            char ch = greeting[2];
            Console.WriteLine(ch);


            
            string str = new string(new char[] { 'a', 'k', 'o' });
            Console.WriteLine(str);
        }
    }
}
