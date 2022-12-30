using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingLinkedList
{
    public class LinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public void AddLast(Node node)
        {
            if (Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            Tail.Next = node;
            Tail = node;
        }
    }
}
