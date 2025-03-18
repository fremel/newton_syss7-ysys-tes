namespace TaskManagerSolution;

public class TaskManager
{
    private int NextId = 1;
    public List<Task> Tasks { get; set; } = [];

    public Task AddTask(string Name, string Description) 
    {
        Task task = new Task();
        task.Name = Name;
        task.Description = Description;
        task.Id = NextId;
        NextId++;
        task.IsCompleted = false;

        Tasks.Add(task);

        return task;
    }

    public Task GetTaskById(int Id) {
        return Tasks.FirstOrDefault(task => task.Id.Equals(Id));
    }

    public void CompleteTask(int id) 
    {
        var task = Tasks.FirstOrDefault(task => task.Id == id);
        
        if(task is not null) 
        {
            task.IsCompleted = true;
        }
        else 
        {
            throw new ArgumentException("Given task " + id + " not found.");
        }
    }

    public List<Task> GetAllTasks() {
        return Tasks;
    }

    public List<Task> GetAllIncompleteTasks() {
        return Tasks.Where(task => task.IsCompleted == false).ToList();

        /*List<Task> allIncompleteTasks = new List<Task>();
        for(int i = 0; i < Tasks.Count; i++) 
        {
            if(Tasks[i].IsCompleted == false)
            {
                allIncompleteTasks.Add(Tasks[i]);
            }
        }

        return allIncompleteTasks;*/
    }
}
