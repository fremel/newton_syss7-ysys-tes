using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TodosController : ControllerBase
{
    private readonly TodoDbContext _context;

    public TodosController(TodoDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Todo>> GetTodos()
    {
        return _context.Todos.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Todo> GetTodoById(int id)
    {
        var todo = _context.Todos.FirstOrDefault(t => t.Id == id);

        if (todo == null)
        {
            return NotFound();
        }

        return todo;
    }

    [HttpPost]
    public ActionResult<Todo> CreateTodo(Todo todo)
    {
        todo.Id = _context.Todos.Count + 1;
        _context.Todos.Add(todo);
        Console.WriteLine("Added item with id " + todo.Id);

        return CreatedAtAction(nameof(GetTodoById), new { id = todo.Id }, todo);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTodo(int id, Todo todo)
    {
        if (id != todo.Id)
        {
            return BadRequest();
        }

        var existingTodo = _context.Todos.FirstOrDefault(t => t.Id == id);
        if (existingTodo == null)
        {
            return NotFound();
        }

        existingTodo.Task = todo.Task;
        existingTodo.IsCompleted = todo.IsCompleted;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTodo(int id)
    {
        var todo = _context.Todos.FirstOrDefault(t => t.Id == id);
        if (todo == null)
        {
            return NotFound();
        }

        _context.Todos.Remove(todo);
        return NoContent();
    }
}