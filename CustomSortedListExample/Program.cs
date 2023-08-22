using CustomSortedListExample;

CustomSortedList<string, int> customSortedList = new CustomSortedList<string, int>();

customSortedList.Add("three", 3);
customSortedList.Add("one", 1);
customSortedList.Add("two", 2);

foreach (var kvp in customSortedList)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
}

Console.WriteLine($"Value for key 'two': {customSortedList["two"]}");