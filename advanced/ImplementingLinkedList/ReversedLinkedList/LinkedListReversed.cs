using System;
using System.Collections.Generic;
using System.Text;

namespace ReversedLinkedList
{
    public class LinkedListReversed
    {
        public Node Head { get; set; }

        public void AddFirst(Node node)
        {
            node.Next = Head;
            Head = node;
        }
    }
}
