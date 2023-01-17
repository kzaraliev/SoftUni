using System;
using System.Collections.Generic;

namespace SimpleTextEditor
{
    class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());

            string text = string.Empty;

            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < commandsCount; i++)
            {
                string[] line = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int command = int.Parse(line[0]);

                switch (command)
                {
                    case 1:
                        string charactersForAdd = line[1];
                        text += charactersForAdd;
                        stack.Push(text);
                        break;
                    case 2:
                        int charsForErase = int.Parse(line[1]); ;
                        text = text.Substring(0, text.Length - charsForErase);
                        stack.Push(text);
                        break;
                    case 3:
                        int index = int.Parse(line[1]);
                        Console.WriteLine(text[index - 1]);
                        break;
                    case 4:
                        stack.Pop();
                        text = stack.Peek();
                        break;
                }
            }
        }
    }
}