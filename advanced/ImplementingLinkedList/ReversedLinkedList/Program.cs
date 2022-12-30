using System;

namespace ReversedLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedListReversed linkedListReversed = new LinkedListReversed();

            linkedListReversed.AddFirst(new Node(1));
            linkedListReversed.AddFirst(new Node(2));
            linkedListReversed.AddFirst(new Node(3));
            linkedListReversed.AddFirst(new Node(4));

            Node currentNode = linkedListReversed.Head;

            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }
    }
}
