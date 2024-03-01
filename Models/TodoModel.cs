namespace Todo.Models;

public class TodoModel
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public bool Done { get; private set; }
    public DateTime CreatedAt { get; set; }
}