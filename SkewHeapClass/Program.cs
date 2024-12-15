using System;
using SkewHeap;

class Program
{
    static void Main()
    {
        var planner = new PriorityPlanner();
        string? command;

        do
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Добавить задачу");
            Console.WriteLine("2. Показать задачу с наивысшим приоритетом");
            Console.WriteLine("3. Удалить задачу с наивысшим приоритетом");
            Console.WriteLine("4. Показать все задачи");
            Console.WriteLine("5. Очистить все задачи");
            Console.WriteLine("0. Выйти");
            Console.Write("Введите команду: ");
            command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    Console.Write("Введите заголовок задачи: ");
                    var title = Console.ReadLine();
                    Console.Write("Введите описание задачи: ");
                    var description = Console.ReadLine();
                    Console.Write("Введите приоритет задачи (меньшее значение — выше приоритет): ");
                    if (int.TryParse(Console.ReadLine(), out int priority))
                    {
                        planner.AddTask(title, description, priority);
                    }
                    else
                    {
                        Console.WriteLine("Некорректный приоритет.");
                    }
                    break;

                case "2":
                    planner.ViewTopTask();
                    break;

                case "3":
                    planner.RemoveTopTask();
                    break;

                case "4":
                    planner.ShowAllTasks();
                    break;

                case "5":
                    planner.ClearAllTasks();
                    break;

                case "0":
                    Console.WriteLine("Выход из программы.");
                    break;

                default:
                    Console.WriteLine("Некорректная команда.");
                    break;
            }
        } while (command != "0");
    }
}
