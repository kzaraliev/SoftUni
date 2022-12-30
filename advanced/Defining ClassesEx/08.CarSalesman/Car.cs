using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
                Model = model;
                Engine = engine;
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            string weight = Weight == 0 ? "n/a" : Weight.ToString(); 
            string color = Color ?? "n/a"; 

            string result =
                $"{Model}:{Environment.NewLine}" +
                $"  {Engine.ToString()}{Environment.NewLine}" +
                $"  Weight: {weight}{Environment.NewLine}" +
                $"  Color: {color}";

            return result;
        }
    }
}
