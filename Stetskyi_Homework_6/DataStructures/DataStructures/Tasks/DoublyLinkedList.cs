using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>, IEnumerator<T>
    {
        T[] elementArray = Array.Empty<T>();
        int position = -1;

        public T this[int index]
        {
            get { return elementArray[index]; }
            set { elementArray[index] = value; }
        }

        public object Current
        {
            get { return elementArray[position]; }
        }

        T IEnumerator<T>.Current
        {
            get { return elementArray[position]; }
        }

        public int Length
        {
            get { return elementArray.Length; }
        }

        public void Add(T e)
        {
            var newArray = new T[elementArray.Length + 1];
            elementArray.CopyTo(newArray, 0);
            newArray[newArray.Length - 1] = e;
            elementArray = newArray;
        }

        public void AddAt(int index, T e)
        {
            var newArray = new T[elementArray.Length + 1];
            elementArray.CopyTo(newArray, 0);
            for (int i = elementArray.Length - 1; i > index; i--)
            {
                newArray[i] = newArray[i - 1];
            }
            newArray[index] = e;
            elementArray = newArray;
        }

        public void Dispose()
        {
            Reset();
        }

        public void Reset()
        {
            position = -1;
        }

        public T ElementAt(int index)
        {
            return elementArray[index];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        public void Remove(T item)
        {
            DoublyLinkedList<T> result = new DoublyLinkedList<T>();
            bool removed = false;
            foreach (var element in elementArray)
            {
                if (element.Equals(item) && !removed)
                {
                    removed = true;
                    continue;
                }
                result.Add(element);
            }
            elementArray = result.elementArray;
        }

        public T RemoveAt(int index)
        {
            DoublyLinkedList<T> result = new DoublyLinkedList<T>();
            T removedItem = elementArray[index];

            for (int i = 0; i < elementArray.Length; i++)
            {
                if (i != index)
                {
                    result.Add(elementArray[i]);
                }
            }
            elementArray = result.elementArray;
            return removedItem;
        }

        public bool MoveNext()
        {
            if (position < elementArray.Length - 1)
            {
                position++;
                return true;
            }
            Reset();
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
    }
}
