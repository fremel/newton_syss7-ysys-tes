public class TodoDbContext
{
    public List<Todo> Todos { get; set; }

    public TodoDbContext()
    {
        Todos = new List<Todo>();
    }
}