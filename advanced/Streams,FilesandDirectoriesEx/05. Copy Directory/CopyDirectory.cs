namespace CopyDirectory
{
    using System.IO;

    public class CopyDirectory
    {
        static void Main(string[] args)
        {
            //string inputPath = Console.ReadLine();
            string inputPath = @"D:\C#Advanced\Solutions\StreamsFilesAndDirectories\CopyBinaryFile";
            //string outputPath = Console.ReadLine();
            string outputPath = @"D:\C#Advanced\Solutions\StreamsFilesAndDirectories\CopyHere";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath);
            }

            Directory.CreateDirectory(outputPath);

            string[] files = Directory.GetFiles(inputPath);

            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file);

                string destination = Path.Combine(outputPath, fileName);

                File.Copy(file, destination);
            }
        }
    }
}
