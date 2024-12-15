namespace SkewHeap;

public class PriorityPlanner
{
    private SkewHeap<Task> tasks = new SkewHeap<Task>();

    // Добавление новой задачи
    public void AddTask(string title, string description, int priority)
    {
        var task = new Task(title, description, priority);
        tasks.Insert(task);
        Console.WriteLine("Задача успешно добавлена.");
    }

    // Получение задачи с наивысшим приоритетом
    public Task ViewTopTask()
    {
        if (tasks.IsEmpty())
        {
            Console.WriteLine("Ежедневник пуст.");
            throw new InvalidOperationException("Ежедневник пуст.");
        }

        var topTask = tasks.PeekMin(); // Получаем задачу с наивысшим приоритетом
        Console.WriteLine("Задача с наивысшим приоритетом:");
        Console.WriteLine(topTask);

        return topTask; // Возвращаем задачу для использования в коде
    }


    // Удаление задачи с наивысшим приоритетом
    public void RemoveTopTask()
    {
        if (tasks.IsEmpty())
        {
            Console.WriteLine("Ежедневник пуст.");
            return;
        }

        var removedTask = tasks.ExtractMin();
        Console.WriteLine($"Удалена задача: {removedTask}");
    }

    // Показать все задачи
    public void ShowAllTasks()
    {
        if (tasks.IsEmpty())
        {
            Console.WriteLine("Ежедневник пуст.");
            return;
        }

        Console.WriteLine("Список всех задач:");
        var tempHeap = new SkewHeap<Task>(); // Временная куча для вывода
        while (!tasks.IsEmpty())
        {
            var task = tasks.ExtractMin();
            Console.WriteLine(task);
            tempHeap.Insert(task); // Сохраняем задачи обратно
        }

        tasks = tempHeap; // Восстанавливаем кучу
    }

    // Очистка всех задач
    public void ClearAllTasks()
    {
        tasks.Clear();
        Console.WriteLine("Ежедневник очищен.");
    }
}
