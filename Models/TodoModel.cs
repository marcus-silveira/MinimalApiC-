namespace Todo.Models;

public class TodoModel
{
    public TodoModel(string title, bool done)
    {
        Title = title;
        Done = done;
        CreatedAt = DateTime.Now;
    }

    public int Id { get; set;}
    public string Title { get; private set; }
    public bool Done { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public void Update(string title, bool done)
    {
        Title = title;
        Done = done;
    }
}