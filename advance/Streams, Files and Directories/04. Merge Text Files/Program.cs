using System.Collections.Generic;
using System.IO;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            List<string> firstInput = new List<string>();
            List<string> secondInput = new List<string>();
            List<string> output = new List<string>();
            using (StreamReader firstReader = new StreamReader(firstInputFilePath))
            {
                while (!firstReader.EndOfStream)
                {
                    firstInput.Add(firstReader.ReadLine());
                }
            }

            using (StreamReader secondReader = new StreamReader(secondInputFilePath))
            {
                while (!secondReader.EndOfStream)
                {
                    secondInput.Add(secondReader.ReadLine());
                }
            }

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                for (int i = 0; i < firstInput.Count; i++)
                {
                    output.Add(firstInput[i]);
                    output.Add(secondInput[i]);
                }
                output.Add(secondInput[secondInput.Count - 1]);

                foreach (var item in output)
                {
                    writer.WriteLine(item);
                }
            }
        }
    }
}
