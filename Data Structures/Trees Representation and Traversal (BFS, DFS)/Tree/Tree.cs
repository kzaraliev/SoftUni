using System.Linq;

namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private T value;
        private List<Tree<T>> children;
        private Tree<T> parent;

        public Tree(T value)
        {
            this.value = value;
            this.children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.parent = this;
                this.children.Add(child);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var parentNode = this.FindNodeWithBfs(parentKey);

            if (parentNode is null)
            {
                throw new ArgumentNullException();
            }

            parentNode.children.Add(child);
            child.parent = parentNode;
        }

        private Tree<T> FindNodeWithBfs(T parentKey)
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();

                if (subtree.value.Equals(parentKey))
                {
                    return subtree;
                }
                foreach (var child in subtree.children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        public IEnumerable<T> OrderBfs()
        {
            var queue = new Queue<Tree<T>>();
            var result = new List<T>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();
                result.Add(subtree.value);

                foreach (var child in subtree.children)
                {
                    queue.Enqueue(child);
                }
            }
            return result;
        }

        private void Dfs(Tree<T> node, ICollection<T> result)
        {
            foreach (var child in node.children)
            {
                this.Dfs(child, result);
            }

            result.Add(node.value);
        }

        public IEnumerable<T> OrderDfs()
        {
            var list = new List<T>();
            Dfs(this, list);
            return list;
        }

        // private IEnumerable<T> DfsWithStack()
        // {
        //     var result = new Stack<T>();
        //     var stack = new Stack<Tree<T>>();
        //     stack.Push(this);
        //
        //     while (stack.Count > 0)
        //     {
        //         var node = stack.Pop();
        //         foreach (var child in node.children)
        //         {
        //             stack.Push(child);
        //         }
        //
        //         result.Push(node.value);
        //     }
        //
        //     return result;
        // }

        public void RemoveNode(T nodeKey)
        {
            var nodeToDelete = FindNodeWithBfs(nodeKey);
            if (nodeToDelete is null)
            {
                throw new ArgumentNullException();
            }

            var parentNode = nodeToDelete.parent;
            if (parentNode is null)
            {
                throw new ArgumentException();
            }
            parentNode.children = parentNode.children.Where(node => !node.value.Equals(nodeKey)).ToList();
            nodeToDelete.parent = null;
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = FindNodeWithBfs(firstKey);
            var secondNode = FindNodeWithBfs(secondKey);

            if (firstNode is null || secondNode is null)
            {
                throw new ArgumentNullException();
            }

            var firstParent = firstNode.parent;
            var secondParent = secondNode.parent;

            if (firstNode.parent is null || secondNode.parent is null)
            {
                throw new ArgumentException();
            }

            var indexOfFirstChild = firstParent.children.IndexOf(firstNode);
            var indexOfSecondChild = secondParent.children.IndexOf(secondNode);

            firstParent.children[indexOfFirstChild] = secondNode;
            secondNode.parent = firstParent;
            secondParent.children[indexOfSecondChild] = firstNode;
            firstNode.parent = secondParent;
        }
    }
}
