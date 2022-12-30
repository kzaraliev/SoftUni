using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> List { get; set; }
        public Box()
        {
            List = new List<T>();
        }

        public void Add(T elementToAdd)
        {
            List.Insert(0, elementToAdd);
        }

        public T Remove()
        {
            T elementToRemove = List[0];
            List.RemoveAt(0);
            return elementToRemove;
        }

        public int Count{ get { return List.Count; } }
    }
}
