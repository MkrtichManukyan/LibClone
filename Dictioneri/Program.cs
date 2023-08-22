using System;
using System.Collections.Generic;

CustomDictionary<string, int> customDict = new CustomDictionary<string, int>();

customDict.Add("one", 1);
customDict.Add("two", 2);
customDict.Add("three", 3);

if (customDict.TryGetValue("two", out int value))
{
    Console.WriteLine($"Value for key 'two': {value}");
}
else
{
    Console.WriteLine("Key not found.");
}