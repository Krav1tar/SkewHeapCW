using System;
using System.Collections.Generic;
using System.Diagnostics;
using SkewHeap;
class PerformanceTester
{
    private const int ElementCount = 10000000;

    public void RunTests()
    {
        Console.WriteLine("Сравнение производительности куч:");

        // Скошенная куча
        var skewHeap = new SkewHeap<int>();
        MeasurePerformance("Скошенная куча", skewHeap);

        // Бинарная куча
        var binaryHeap = new BinaryHeap<int>();
        MeasurePerformance("Бинарная куча", binaryHeap);

        // Левосторонняя куча
        var leftistHeap = new LeftistHeap<int>();
        MeasurePerformance("Левосторонняя куча", leftistHeap);
    }

    private void MeasurePerformance(string name, dynamic heap)
    {
        var data = GenerateRandomData(ElementCount);
        var otherData = GenerateRandomData(ElementCount / 10);

        // Вставка
        Stopwatch stopwatch = Stopwatch.StartNew();
        foreach (var item in data)
        {
            heap.Insert(item);
        }
        stopwatch.Stop();
        Console.WriteLine($"{name} - Вставка: {stopwatch.ElapsedMilliseconds} мс");

        // Извлечение минимума
        stopwatch.Restart();
        for (int i = 0; i < ElementCount / 2; i++)
        {
            heap.ExtractMin();
        }
        stopwatch.Stop();
        Console.WriteLine($"{name} - Извлечение минимума: {stopwatch.ElapsedMilliseconds} мс");

        // Слияние
        dynamic otherHeap = Activator.CreateInstance(heap.GetType());
        foreach (var item in otherData)
        {
            otherHeap.Insert(item);
        }

        stopwatch.Restart();
        heap.Merge(otherHeap);
        stopwatch.Stop();
        Console.WriteLine($"{name} - Слияние: {stopwatch.ElapsedMilliseconds} мс");
    }


    private List<int> GenerateRandomData(int count)
    {
        var random = new Random();
        var data = new List<int>(count);
        for (int i = 0; i < count; i++)
        {
            data.Add(random.Next());
        }
        return data;
    }
}
