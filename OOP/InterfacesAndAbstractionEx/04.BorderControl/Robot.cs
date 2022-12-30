using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public class Robot : IIndivid
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public Robot(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }

        public void CheckId(string fakeSubstring)
        {
            if (this.Id.EndsWith(fakeSubstring))
                Console.WriteLine(this.Id);
        }
    }
}
