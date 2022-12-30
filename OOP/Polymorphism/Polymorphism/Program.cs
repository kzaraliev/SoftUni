using System;

namespace Polymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWorker worker = null;
            Random random = new Random();

            if (random.Next() % 2 == 0)
            {
                worker = new Programmer();
                if (worker is Programmer)
                {
                    Console.WriteLine("Programistche");
                }
            }
            else
            {
                worker = new PM();
                if (worker is PM)
                {
                    Console.WriteLine("PM-che sme");
                }
            }

            Console.WriteLine(worker.GetType().Name.ToString());
            worker.Work();
        }
    }

    interface IWorker
    {
        void Work();
    }

    class Programmer : IWorker
    {
        public int WorkHours { get; set; }

        public void Work()
        {
            Console.WriteLine("Chillvam");
            WorkHours++;
        }
    }

    class PM : IWorker
    {
        public void Work()
        {
            Console.WriteLine("Bachkam qko!!");
        }
    }
}
