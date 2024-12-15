using Xunit;
using SkewHeap;

public class SkewHeapTests
{
    [Fact]
    public void Insert_ShouldMaintainHeapProperty()
    {
        var heap = new SkewHeap<int>();
        heap.Insert(10);
        heap.Insert(5);
        heap.Insert(20);

        Assert.Equal(5, heap.PeekMin());
    }

    [Fact]
    public void DeleteMin_ShouldRemoveMinimumElement()
    {
        var heap = new SkewHeap<int>();
        heap.Insert(10);
        heap.Insert(5);
        heap.Insert(20);

        Assert.Equal(5, heap.ExtractMin());
        Assert.Equal(10, heap.PeekMin());
    }

    [Fact]
    public void Clear_ShouldEmptyTheHeap()
    {
        var heap = new SkewHeap<int>();
        heap.Insert(10);
        heap.Insert(5);

        heap.Clear();

        Assert.True(heap.IsEmpty());
    }

    [Fact]
    public void DeleteMin_OnEmptyHeap_ShouldThrowException()
    {
        var heap = new SkewHeap<int>();

        Assert.Throws<InvalidOperationException>(() => heap.ExtractMin());
    }
}
