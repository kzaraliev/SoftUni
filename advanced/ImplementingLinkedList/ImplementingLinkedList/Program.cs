using System;

namespace ImplementingLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();

            linkedList.AddLast(new Node(1));
            linkedList.AddLast(new Node(2));
            linkedList.AddLast(new Node(3));
            linkedList.AddLast(new Node(4));

            Node currentNode = linkedList.Head;

            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }
    }
}