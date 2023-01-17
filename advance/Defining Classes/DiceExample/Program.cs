using System;

namespace DiceExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.ReadLine();
                Dice dice = ThrowDice();

                Console.WriteLine($"Dice: {dice.Side}");
            }
        }

        static Dice ThrowDice()
        {
            Random random = new Random();
            int side = random.Next(1, 7);

            Dice dice = new Dice()
            {
                Side = side,
                Color = "Pink"
            };

            return dice;
        }
    }
}
