using CustomOrderedDictionaryExample;

CustomOrderedDictionary<string, int> orderedDict = new CustomOrderedDictionary<string, int>();

orderedDict.Add("one", 1);
orderedDict.Add("two", 2);
orderedDict.Add("three", 3);

foreach (var kvp in orderedDict)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
}