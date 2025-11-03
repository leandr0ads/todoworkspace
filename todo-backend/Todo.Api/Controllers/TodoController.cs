using Microsoft.AspNetCore.Mvc;
using Todo.Application.DTOs;
using Todo.Application.Services;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly TodoService _service;

    public TodoController(TodoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> List()
        => Ok(await _service.ListAsync());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var todo = await _service.GetAsync(id);
        return todo is null ? NotFound() : Ok(todo);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TodoCreateDto dto)
    {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, TodoUpdateDto dto)
    {
        var ok = await _service.UpdateAsync(id, dto);
        return ok ? NoContent() : NotFound();
    }

    [HttpPatch("{id:guid}/complete")]
    public async Task<IActionResult> Toggle(Guid id, [FromQuery] bool completed)
    {
        var ok = await _service.ToggleCompleteAsync(id, completed);
        return ok ? NoContent() : NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
