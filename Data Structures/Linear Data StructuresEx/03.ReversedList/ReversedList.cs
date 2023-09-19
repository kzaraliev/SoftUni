namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.items[this.Count - 1 - index];
            }
            set
            {
                this.ValidateIndex(index);
                this.items[index] = value;
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Index is outside the bounds of this list!");
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (this.items.Length == this.Count)
            {
                this.Grow();
            }
            this.items[this.Count++] = item;
        }

        private void Grow()
        {
            var newArr = new T[this.items.Length * 2];
            Array.Copy(this.items, newArr, this.Count);
            this.items = newArr;
        }

        public bool Contains(T item)
        {
            return this.IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            for (int i = 1; i <= this.Count; i++)
            {
                if (this.items[this.Count - i].Equals(item))
                {
                    return i - 1;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            int indexToInsert = this.Count - index;
            for (int i = this.Count; i > indexToInsert; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[indexToInsert] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            int index = this.IndexOf(item);

            if (index == -1)
            {
                return false;
            }

            this.RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);
            index = this.Count - 1 - index;

            for (int i = index; i < this.Count; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default;
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}