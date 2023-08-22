using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomQueueExample
{
    class CustomQueue<T> : IEnumerable<T>
    {
        private List<T> data = new List<T>();

        public void Enqueue(T item)
        {
            data.Add(item);
        }

        public T Dequeue()
        {
            if (data.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            T item = data[0];
            data.RemoveAt(0);
            return item;
        }

        public T Peek()
        {
            if (data.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            return data[0];
        }

        public int Count => data.Count;

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in data)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
