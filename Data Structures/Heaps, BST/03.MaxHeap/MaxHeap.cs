namespace _03.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        private List<T> elements;

        public MaxHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);

            this.HeapifyUp(this.elements.Count - 1);
        }

        private void HeapifyUp(int index)
        {
            var parentIndex = this.GetParentIndex(index);

            while (index > 0 && this.elements[index].CompareTo(this.elements[parentIndex]) > 0)
            {
                this.Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = this.GetParentIndex(index);
            }
        }

        private void Swap(int index, int parentIndex)
        {
            (this.elements[index], this.elements[parentIndex]) = (this.elements[parentIndex], this.elements[index]);
        }

        private int GetParentIndex(int index) => (index - 1) / 2;

        public T ExtractMax()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T element = this.elements[0];
            this.Swap(0, this.elements.Count - 1);
            this.elements.RemoveAt(this.elements.Count - 1);
            this.HeapifyDown(0);

            return element;
        }

        private void HeapifyDown(int index)
        {
            var biggerChildIndex = this.GetBiggerChildIndex(index);

            while (IsIndexValid(biggerChildIndex) && this.elements[biggerChildIndex].CompareTo(this.elements[index]) > 0) //!!!
            {
                this.Swap(biggerChildIndex, index);

                index = biggerChildIndex;
                biggerChildIndex = this.GetBiggerChildIndex(index);
            }
        }

        private bool IsIndexValid(int index) => index >= 0 && index < this.elements.Count;

        private int GetBiggerChildIndex(int index)
        {
            var firstChildIndex = index * 2 + 1;
            var secondChildIndex = index * 2 + 2;

            if (secondChildIndex < this.elements.Count)
            {
                if (this.elements[firstChildIndex].CompareTo(this.elements[secondChildIndex]) > 0)
                {
                    return firstChildIndex;
                }

                return secondChildIndex;
            }
            else if (firstChildIndex < this.elements.Count)
            {
                return firstChildIndex;
            }
            else
            {
                return -1;
            }
        }

        public T Peek()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return this.elements[0];
        }
    }
}
