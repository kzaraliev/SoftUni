using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace _04.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIndivid> entities = new List<IIndivid>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmd = input.Split();
                if (cmd.Length == 2)
                {
                    string name = cmd[0];
                    string id = cmd[1];
                    entities.Add(new Robot(name, id));
                }
                else if (cmd.Length == 3)
                {
                    string name = cmd[0];
                    int age = int.Parse(cmd[1]);
                    string id = cmd[2];
                    entities.Add(new Human(name, age, id));
                }
            }
            string fakeSubstring = Console.ReadLine();

            foreach (IIndivid entity in entities)
                entity.CheckId(fakeSubstring);
        }
    }
}
