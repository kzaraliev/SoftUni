using System;
using System.IO;
using System.Text;

namespace Streams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using (FileStream writerStream = new FileStream("../../../text.txt", FileMode.Append))
            //{
            //    string input = Console.ReadLine();
            //    while (input != "end")
            //    {
            //        byte[] buffer = Encoding.Unicode.GetBytes(input + "\n");
            //        writerStream.Write(buffer);
            //        input = Console.ReadLine();
            //    }
            //}

            int bufferSize = 16;
            using (FileStream readStream = new FileStream("../../../text.txt", FileMode.Open))
            {
                byte[] buffer = new byte[bufferSize];
                while (readStream.Read(buffer) != 0)
                {
                    Console.WriteLine("Position of stream: " + readStream.Position);
                    string text = Encoding.Unicode.GetString(buffer);
                    Console.WriteLine(text);
                }
            }
        }
    }
}
