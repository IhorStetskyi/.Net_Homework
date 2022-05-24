using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        DoublyLinkedList<T> source = new DoublyLinkedList<T>();

        public T Dequeue()
        {
            SourceNotEmptyValidation();
            return source.RemoveAt(0);
        }

        public void Enqueue(T item)
        {
            source.Add(item);
        }

        public T Pop()
        {
            SourceNotEmptyValidation();
            return source.RemoveAt(source.Length - 1);
        }

        public void Push(T item)
        {
            source.Add(item);
        }


        void SourceNotEmptyValidation()
        {
            if (source.Length == 0)
            {
                throw new InvalidOperationException("Source is empty");
            }
        }
    }
}
