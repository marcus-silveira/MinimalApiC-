using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers;

[ApiController]
[Route("api/todo")]
public class TodoController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public TodoController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("/")]
    public IActionResult Get() => Ok(_dbContext.Todos.ToList());
    
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var todo = await _dbContext.Todos.FirstOrDefaultAsync(todo => todo.Id == id);
        if (todo is null) return NoContent();
        
        return Ok(todo);
    }

    [HttpPost]
    public async Task<IActionResult> Post(TodoModeInput todoModel)
    {
        var todo = new TodoModel(todoModel.Title, todoModel.Done);

        await _dbContext.Todos.AddAsync(todo);
        await _dbContext.SaveChangesAsync();

        return Ok(todo);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, TodoModelUpdate todoModel)
    {
        var todo = await _dbContext.Todos.FirstOrDefaultAsync(model => model.Id == id);
        if (todo is null) return NoContent();
        
        todo.Update(todoModel.Title, todoModel.Done);
        
        await _dbContext.SaveChangesAsync();

        return Ok(todoModel);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var todo = await _dbContext.Todos.FirstOrDefaultAsync(model => model.Id == id);
        if (todo is null) return NoContent();
        
        _dbContext.Todos.Remove(todo);

        await _dbContext.SaveChangesAsync();

        return Ok();
    }
}