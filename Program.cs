namespace tree_solution;

class Program
{
    static void Main(string[] args)
    {
        MinHeap minHeap = new MinHeap();
        minHeap.Insert(10);
        minHeap.Insert(20);
        minHeap.Insert(30);
        minHeap.Insert(40);
        minHeap.Insert(15);
        minHeap.Insert(100);
        minHeap.Insert(50);

        Console.WriteLine("The Min-Heap tree:");
        minHeap.Traverse();

        Console.WriteLine("\nRemoving min value from heap: " + minHeap.RemoveMin());
        Console.WriteLine("Heap after removal:");
        minHeap.Traverse();
    }
}