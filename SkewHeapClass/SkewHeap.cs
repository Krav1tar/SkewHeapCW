namespace SkewHeap;

using System;

public class SkewHeapNode<T> where T : IComparable<T>
{
    public T Value;                  // Значение узла
    public SkewHeapNode<T> Left;     // Левое поддерево
    public SkewHeapNode<T> Right;    // Правое поддерево

    public SkewHeapNode(T value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

public class SkewHeap<T> where T : IComparable<T>
{
    private SkewHeapNode<T> root;   // Корень дерева

    // Слияние двух скошенных куч
    private SkewHeapNode<T> Merge(SkewHeapNode<T> h1, SkewHeapNode<T> h2)
    {
        if (h1 == null) return h2;  // Если первая куча пуста
        if (h2 == null) return h1;  // Если вторая куча пуста

        // Убедимся, что корень h1 меньше корня h2
        if (h1.Value.CompareTo(h2.Value) > 0)
        {
            var temp = h1;
            h1 = h2;
            h2 = temp;
        }
        

        // Рекурсивное слияние правого поддерева h1 и второй кучи
        h1.Right = Merge(h1.Right, h2);

        // Переключение поддеревьев
        var tempNode = h1.Left;
        h1.Left = h1.Right;
        h1.Right = tempNode;

        return h1;
    }
    public void Merge(SkewHeap<T> other)
    {
        if (other == null) throw new ArgumentNullException(nameof(other));

        // Слияние двух корней
        root = Merge(root, other.root);

        // Очищаем вторую кучу после слияния
        other.root = null;
    }


    // Добавление нового элемента
    public void Insert(T value)
    {
        var newNode = new SkewHeapNode<T>(value); // Создаем новый узел
        root = Merge(root, newNode);             // Сливаем с текущей кучей
    }

    // Удаление минимального элемента (корня)
    public T ExtractMin()
    {
        if (root == null) throw new InvalidOperationException("Heap is empty");

        T minValue = root.Value;                // Сохраняем значение корня
        root = Merge(root.Left, root.Right);    // Сливаем левое и правое поддеревья
        return minValue;
    }

    // Возвращение минимального элемента без удаления
    public T PeekMin()
    {
        if (root == null) throw new InvalidOperationException("Heap is empty");
        return root.Value;
    }

    // Очистка кучи
    public void Clear()
    {
        root = null; // Удаляем ссылку на корень, освобождая память
    }

    // Проверка на пустоту
    public bool IsEmpty()
    {
        return root == null;
    }
}
