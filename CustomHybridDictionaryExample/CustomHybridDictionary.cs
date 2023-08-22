using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;

namespace CustomHybridDictionaryExample
{
    class CustomHybridDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private ListDictionary listDictionary = new ListDictionary();
        private Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();

        public void Add(TKey key, TValue value)
        {
            if (Count >= 10)
            {
                dictionary.Add(key, value);
            }
            else
            {
                listDictionary.Add(key, value);
            }
        }

        public bool ContainsKey(TKey key)
        {
            return listDictionary.Contains(key) || dictionary.ContainsKey(key);
        }

        public ICollection<TKey> Keys => throw new NotImplementedException();

        public bool Remove(TKey key)
        {
            if (listDictionary.Contains(key))
            {
                listDictionary.Remove(key);
                return true;
            }
            else if (dictionary.ContainsKey(key))
            {
                dictionary.Remove(key);
                return true;
            }

            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (listDictionary.Contains(key))
            {
                value = (TValue)listDictionary[key];
                return true;
            }
            else if (dictionary.TryGetValue(key, out value))
            {
                return true;
            }

            value = default(TValue);
            return false;
        }

        public int Count => listDictionary.Count + dictionary.Count;

        public bool IsReadOnly => false;

        public ICollection<TValue> Values => throw new NotImplementedException();

        public TValue this[TKey key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (DictionaryEntry entry in listDictionary)
            {
                yield return new KeyValuePair<TKey, TValue>((TKey)entry.Key, (TValue)entry.Value);
            }

            foreach (var kvp in dictionary)
            {
                yield return kvp;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }
    }
}
