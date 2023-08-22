using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSortedListExample
{
    class CustomSortedList<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private List<KeyValuePair<TKey, TValue>> data = new List<KeyValuePair<TKey, TValue>>();

        public void Add(TKey key, TValue value)
        {
            int index = 0;
            while (index < data.Count && Comparer<TKey>.Default.Compare(key, data[index].Key) > 0)
            {
                index++;
            }

            data.Insert(index, new KeyValuePair<TKey, TValue>(key, value));
        }

        public TValue this[TKey key]
        {
            get
            {
                foreach (var kvp in data)
                {
                    if (EqualityComparer<TKey>.Default.Equals(kvp.Key, key))
                    {
                        return kvp.Value;
                    }
                }

                throw new KeyNotFoundException("The key was not found in the sorted list.");
            }
            set
            {
                for (int i = 0; i < data.Count; i++)
                {
                    if (EqualityComparer<TKey>.Default.Equals(data[i].Key, key))
                    {
                        data[i] = new KeyValuePair<TKey, TValue>(key, value);
                        return;
                    }
                }

                Add(key, value);
            }
        }

        public int Count => data.Count;

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var kvp in data)
            {
                yield return kvp;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
