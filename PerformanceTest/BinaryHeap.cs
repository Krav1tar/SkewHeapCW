using System;
using System.Collections.Generic;
public class BinaryHeap<T> where T : IComparable<T>
{
    private List<T> heap = new List<T>();

    public void Insert(T value)
    {
        heap.Add(value);
        HeapifyUp(heap.Count - 1);
    }

    public T ExtractMin()
    {
        if (heap.Count == 0) throw new InvalidOperationException("Heap is empty");

        T minValue = heap[0];
        heap[0] = heap[heap.Count - 1];
        heap.RemoveAt(heap.Count - 1);
        HeapifyDown(0);

        return minValue;
    }

    public void Merge(BinaryHeap<T> other)
    {
        foreach (var item in other.heap)
        {
            Insert(item);
        }
    }

    private void HeapifyUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;
            if (heap[index].CompareTo(heap[parentIndex]) >= 0) break;

            Swap(index, parentIndex);
            index = parentIndex;
        }
    }

    private void HeapifyDown(int index)
    {
        while (index < heap.Count)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;
            int smallest = index;

            if (left < heap.Count && heap[left].CompareTo(heap[smallest]) < 0)
                smallest = left;

            if (right < heap.Count && heap[right].CompareTo(heap[smallest]) < 0)
                smallest = right;

            if (smallest == index) break;

            Swap(index, smallest);
            index = smallest;
        }
    }

    private void Swap(int i, int j)
    {
        T temp = heap[i];
        heap[i] = heap[j];
        heap[j] = temp;
    }
}