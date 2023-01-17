using System;
using System.Linq;

namespace _02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[Arcticle] command = Console.ReadLine().Split(", ").ToArray();

            Arcticle arcticle = new Arcticle()
            {
                Title = command[0],
                Content = command[1],
                Author = command[2]
            };

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] changes = Console.ReadLine().Split(": ").ToArray();

                switch (changes[0])
                {
                    case "Edit":
                        
                        break;
                    case "ChangeAuthor":

                        break;
                    case "Rename":

                        break;
                }
            }
        }
    }

    class Arcticle
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}
