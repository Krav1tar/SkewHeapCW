class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Запуск тестов производительности...");
        var tester = new PerformanceTester();
        tester.RunTests();
        Console.WriteLine("Тестирование завершено.");
    }
}