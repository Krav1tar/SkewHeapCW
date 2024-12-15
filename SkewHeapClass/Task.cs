namespace SkewHeap;

public class Task : IComparable<Task>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Priority { get; set; }

    public Task(string title, string description, int priority)
    {
        Title = title;
        Description = description;
        Priority = priority;
    }

    public int CompareTo(Task other)
    {
        return Priority.CompareTo(other.Priority); // Меньшее значение — выше приоритет
    }

    public override string ToString()
    {
        return $"[Приоритет: {Priority}] {Title} — {Description}";
    }
}
