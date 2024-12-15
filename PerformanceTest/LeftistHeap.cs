public class LeftistHeapNode<T> where T : IComparable<T>
{
    public T Value;
    public LeftistHeapNode<T> Left, Right;
    public int Rank;

    public LeftistHeapNode(T value)
    {
        Value = value;
        Left = Right = null;
        Rank = 1;
    }
}

public class LeftistHeap<T> where T : IComparable<T>
{
    private LeftistHeapNode<T> root;

    public void Insert(T value)
    {
        root = Merge(root, new LeftistHeapNode<T>(value));
    }

    public T ExtractMin()
    {
        if (root == null) throw new InvalidOperationException("Heap is empty");

        T minValue = root.Value;
        root = Merge(root.Left, root.Right);

        return minValue;
    }

    public void Merge(LeftistHeap<T> other)
    {
        root = Merge(root, other.root);
    }

    private LeftistHeapNode<T> Merge(LeftistHeapNode<T> h1, LeftistHeapNode<T> h2)
    {
        if (h1 == null) return h2;
        if (h2 == null) return h1;

        if (h1.Value.CompareTo(h2.Value) > 0)
        {
            var temp = h1;
            h1 = h2;
            h2 = temp;
        }

        h1.Right = Merge(h1.Right, h2);

        if (h1.Left == null || h1.Right?.Rank > h1.Left.Rank)
        {
            var temp = h1.Left;
            h1.Left = h1.Right;
            h1.Right = temp;
        }

        h1.Rank = (h1.Right?.Rank ?? 0) + 1;
        return h1;
    }
}
