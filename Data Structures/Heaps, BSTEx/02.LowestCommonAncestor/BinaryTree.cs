namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
            if (leftChild != null)
            {
                this.LeftChild.Parent = this;
            }

            if (rightChild != null)
            {
                this.RightChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            BinaryTree<T> firstNode = this.FindBfs(first, this);
            BinaryTree<T> secondNode = this.FindBfs(second, this);

            if (firstNode == null || secondNode == null)
            {
                throw new InvalidOperationException();
            }

            var firstNodeAncestors = this.FindAncestors(firstNode);
            var secondNodeAncestors = this.FindAncestors(secondNode);

            return firstNodeAncestors.Intersect(secondNodeAncestors).First();
        }

        private Queue<T> FindAncestors(BinaryTree<T> root)
        {
            var result = new Queue<T>();

            var current = root;

            while (current != null)
            {
                result.Enqueue(current.Value);
                current = current.Parent;
            }

            return result;
        }

        private BinaryTree<T> FindBfs(T element, BinaryTree<T> root)
        {
            var queue = new Queue<BinaryTree<T>>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (element.Equals(current.Value))
                {
                    return current;
                }

                if (current.LeftChild != null )
                {
                    queue.Enqueue(current.LeftChild);
                }

                if (current.RightChild != null)
                {
                    queue.Enqueue(current.RightChild);
                }
            }

            return null;
        }
    }
}
