using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomOrderedDictionaryExample
{
    class CustomOrderedDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private List<TKey> keys = new List<TKey>();
        private Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();

        public void Add(TKey key, TValue value)
        {
            if (!dictionary.ContainsKey(key))
            {
                keys.Add(key);
                dictionary.Add(key, value);
            }
            else
            {
                throw new ArgumentException("An element with the same key already exists.");
            }
        }

        public TValue this[TKey key]
        {
            get => dictionary[key];
            set
            {
                if (dictionary.ContainsKey(key))
                {
                    dictionary[key] = value;
                }
                else
                {
                    keys.Add(key);
                    dictionary.Add(key, value);
                }
            }
        }

        public bool ContainsKey(TKey key)
        {
            return dictionary.ContainsKey(key);
        }

        public bool Remove(TKey key)
        {
            if (dictionary.ContainsKey(key))
            {
                keys.Remove(key);
                dictionary.Remove(key);
                return true;
            }

            return false;
        }

        public int Count => keys.Count;

        public IEnumerable<TKey> Keys => keys;

        public IEnumerable<TValue> Values => keys.ConvertAll(key => dictionary[key]);

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (TKey key in keys)
            {
                yield return new KeyValuePair<TKey, TValue>(key, dictionary[key]);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
