namespace TaskManagerSolution.Tests;

[TestClass]
public class TaskManagerTests
{
    [TestMethod]
    public void AddTask_ShouldAddTaskWithNameAndDescriptionAndSetIdAndIsCompletedFalse()
    {
        TaskManager taskManager = new TaskManager();
        
        var result = taskManager.AddTask("NewTask", "Do a lot of work");
        
        Assert.IsNotNull(result);
        Assert.IsNotNull(taskManager.Tasks[0].Id);
        Assert.IsFalse(taskManager.Tasks[0].IsCompleted);
    }

    [TestMethod]
    public void AddTask_ShouldAddTaskWithUniqueId()
    {
        TaskManager taskManager = new TaskManager();
        taskManager.AddTask("NewTask1", "Do a lot of work");

        var result = taskManager.AddTask("NewTask2", "Do even more work");
        
        Assert.IsNotNull(result);
        Assert.IsNotNull(taskManager.Tasks[0].Id);
        Assert.IsNotNull(taskManager.Tasks[1].Id);
        Assert.AreNotEqual(taskManager.Tasks[0].Id, taskManager.Tasks[1].Id);
    }

    [TestMethod]
    public void CompleteTask_ShouldSetIsCompletedToTrueOnCorrectTask() 
    {
        TaskManager taskManager = new TaskManager();
        taskManager.AddTask("NewTask1", "Do a lot of work");
        var id = taskManager.Tasks[0].Id;

        taskManager.CompleteTask(id);

        Assert.IsTrue(taskManager.Tasks[0].IsCompleted);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException), "Task with given id should not have existed.")]
    public void CompleteTask_ShouldThrowExceptionIfNoTaskWithGivenIdExists() 
    {
        TaskManager taskManager = new TaskManager();

        taskManager.CompleteTask(99);
    }

    [TestMethod]
    public void GetAllTasks_ShouldReturnListOfAllTasks() 
    {
        TaskManager taskManager = new TaskManager();
        string name1 = "NewTask1";
        string description1 = "Do a lot of work";
        Task task1 = taskManager.AddTask(name1, description1);
        taskManager.CompleteTask(taskManager.Tasks[0].Id);
        string name2 = "NewTask2";
        string description2 = "Do even more work";
        Task task2 = taskManager.AddTask(name2, description2); 

        List<Task> tasks = taskManager.GetAllTasks();

        Assert.AreEqual(2, tasks.Count);
        Assert.AreEqual(description1, taskManager.GetTaskById(task1.Id).Description);
        Assert.IsTrue(tasks.FirstOrDefault(task => task.Name.Equals(name1)).IsCompleted);
        Assert.AreEqual(description2, tasks.FirstOrDefault(task => task.Name.Equals(name2)).Description);
        Assert.AreEqual(description2, tasks.FirstOrDefault(task => task.Name.Equals(name2)).Description);
        Assert.IsFalse(tasks.FirstOrDefault(task => task.Name.Equals(name2)).IsCompleted);

    }

    [TestMethod]
    public void GetAllTasks_ShouldReturnEmptyTaskListIfNoTasksExist() 
    {
        TaskManager taskManager = new TaskManager();

        List<Task> tasks = taskManager.GetAllTasks();

        Assert.IsNotNull(tasks);
        Assert.AreEqual(0, tasks.Count);
    }

    [TestMethod]
    public void GetAllIncompleteTasks_ShouldReturnEmptyListIfNothingIncomplete() {
        TaskManager taskManager = new TaskManager();
        Task task1 = taskManager.AddTask("Task1", "Desc1");
        taskManager.CompleteTask(task1.Id);

        List<Task> tasks = taskManager.GetAllIncompleteTasks();

        Assert.AreEqual(0, tasks.Count);
    }

    [TestMethod]
    public void GetAllIncompleteTasks_ShouldReturnCorrectNumberOfIncompleteTasks() {
        TaskManager taskManager = new TaskManager();
        Task task1 = taskManager.AddTask("Task1", "Desc1");
        Task task2 = taskManager.AddTask("Task2", "Desc2");
        taskManager.CompleteTask(task2.Id);

        List<Task> tasks = taskManager.GetAllIncompleteTasks();

        Assert.AreEqual(1, tasks.Count);
        Assert.AreEqual(task1.Id, tasks[0].Id);
        Assert.IsFalse(tasks[0].IsCompleted);
    }

    [TestMethod]
    public void GetAllIncompleteTasks_ShouldReturnAllTasksIfAllIncomplete() {
        TaskManager taskManager = new TaskManager();
        taskManager.AddTask("Task1", "Desc1");
        taskManager.AddTask("Task2", "Desc2");

        List<Task> tasks = taskManager.GetAllIncompleteTasks();

        Assert.AreEqual(2, tasks.Count);
    }
}