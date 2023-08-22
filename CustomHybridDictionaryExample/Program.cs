using CustomHybridDictionaryExample;

CustomHybridDictionary<string, int> hybridDict = new CustomHybridDictionary<string, int>();

hybridDict.Add("one", 1);
hybridDict.Add("two", 2);
hybridDict.Add("three", 3);

Console.WriteLine(hybridDict.TryGetValue("two", out int value)); 
Console.WriteLine(value);