using SkewHeap;
using Xunit;

public class PriorityPlannerTests
{
    [Fact]
    public void ViewTopTask_Test()
    {
        var planner = new PriorityPlanner();
        planner.AddTask("Test Task 1", "Test Description 1", 1);
        planner.AddTask("Test Task 2", "Test Description 2", 2);
        Assert.Equal("Test Task 1", planner.ViewTopTask().Title);
    }
    [Fact]
    public void AddTask_ShouldAddNewTask()
    {
        var planner = new PriorityPlanner();
        planner.AddTask("Test Task", "Test Description", 1);

        // Проверяем минимальную задачу
        var topTask = planner.ViewTopTask();
        Assert.Equal("Test Task", topTask.Title);
    }


    [Fact]
    public void RemoveTopTask_ShouldRemoveHighestPriorityTask()
    {
        var planner = new PriorityPlanner();
        planner.AddTask("Task 1", "Description 1", 2);
        planner.AddTask("Task 2", "Description 2", 1);

        planner.RemoveTopTask();

        // Проверяем, что осталась задача с приоритетом 2
        Assert.Equal("Task 1", planner.ViewTopTask().Title);
    }

    [Fact]
    public void ClearAllTasks_ShouldRemoveAllTasks()
    {
        var planner = new PriorityPlanner();
        planner.AddTask("Task 1", "Description 1", 1);
        planner.AddTask("Task 2", "Description 2", 2);

        planner.ClearAllTasks();

        Assert.Throws<InvalidOperationException>(() => planner.ViewTopTask());
    }

    [Fact]
    public void ClearAllTasks_ShouldNotRemoveTasks()
    {
        var planner = new PriorityPlanner();
        planner.AddTask("Task 1", "Description 1", 1);
        planner.AddTask("Task 2", "Description 2", 1);
        
        planner.ClearAllTasks();
        Assert.Throws<InvalidOperationException>(() => planner.ViewTopTask());
    }
}
