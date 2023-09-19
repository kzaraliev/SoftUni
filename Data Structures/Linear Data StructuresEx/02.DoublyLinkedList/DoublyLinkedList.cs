namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public Node Next { get; set; }
            public Node Previous { get; set; }
            public T Value { get; set; }

            public Node(T Value)
            {
                this.Value = Value;
            }
        }

        private Node head;
        private Node tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node(item);

            if (this.Count == 0)
            {
                this.head = newNode;
                this.tail = newNode;

                //this.head = this.tail = newNode;
            }
            else
            {
                this.head.Previous = newNode;
                newNode.Next = this.head;
                this.head = newNode;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node(item);

            if (this.Count == 0)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                newNode.Previous = this.tail;
                this.tail.Next = newNode;
                this.tail = newNode;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            var node = this.head;
            if (node == null)
            {
                throw new InvalidOperationException();
            }

            return node.Value;
        }

        public T GetLast()
        {
            var node = this.tail;
            if (node == null)
            {
                throw new InvalidOperationException();
            }

            return node.Value;
        }

        public T RemoveFirst()
        {
            var firstNode = this.head;
            if (firstNode == null)
            {
                throw new InvalidOperationException();
            }

            this.head = firstNode.Next;
            this.Count--;

            return firstNode.Value;

            //if (this.Count == 0)
            //{
            //    throw new InvalidOperationException();
            //}
            //
            //var currentHead = this.head;
            //
            //if (this.head.Next == null)
            //{
            //    this.head = this.tail = null;
            //}
            //else
            //{
            //    this.head = this.head.Next;
            //    this.head.Previous = null;
            //}
            //
            //this.Count--;
            //return currentHead.Value;
            // solution from the teacher
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var current = this.tail;
            if (current.Previous == null)
            {
                this.head = this.tail = null;
            }
            else
            {
                var newTail = this.tail.Previous;
                newTail.Next = null;
                this.tail = newTail;
            }

            this.Count--;
            return current.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.head;

            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}