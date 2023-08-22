using CustomQueueExample;

CustomQueue<string> customQueue = new CustomQueue<string>();

customQueue.Enqueue("first");
customQueue.Enqueue("second");
customQueue.Enqueue("third");

Console.WriteLine("Dequeuing items:");
while (customQueue.Count > 0)
{
    Console.WriteLine(customQueue.Dequeue());
}