using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> wordsAndCount = new Dictionary<string, int>();
            using (StreamReader readerOfWords = new StreamReader(wordsFilePath))
            {
                using (StreamReader readerOfText = new StreamReader(textFilePath))
                {

                    string[] words = readerOfWords.ReadToEnd().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string currentSentence = readerOfText.ReadLine();

                    while (currentSentence != null)
                    {
                        foreach (var word in words)
                        {
                            if (currentSentence.ToLower().Contains(word.ToLower()))
                            {
                                if (!wordsAndCount.ContainsKey(word))
                                {
                                    wordsAndCount.Add(word, 0);
                                }
                                wordsAndCount[word]++;
                            }
                        }
                        currentSentence = readerOfText.ReadLine();
                    }
                }

                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    foreach (var word in wordsAndCount.OrderByDescending(x => x.Value))
                    {
                        writer.WriteLine($"{word.Key} - {word.Value}");
                    }
                }
            }
        }
    }
}
