class CustomDictionary<TKey, TValue>
{
    private List<TKey> keys;
    private List<TValue> values;

    public CustomDictionary()
    {
        keys = new List<TKey>();
        values = new List<TValue>();
    }

    public void Add(TKey key, TValue value)
    {
        keys.Add(key);
        values.Add(value);
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        int index = keys.IndexOf(key);
        if (index != -1)
        {
            value = values[index];
            return true;
        }

        value = default(TValue);
        return false;
    }
}