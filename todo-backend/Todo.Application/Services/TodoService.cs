using Todo.Application.DTOs;
using Todo.Domain.Abstractions;
using Todo.Domain.Entities;

namespace Todo.Application.Services;

public sealed class TodoService(ITodoRepository repo)
{
    public async Task<TodoViewDto> CreateAsync(TodoCreateDto dto, CancellationToken ct = default)
    {
        var entity = new TodoItem(dto.Title, dto.Description, dto.DueDate);
        await repo.AddAsync(entity, ct);
        return Map(entity);
    }

    public async Task<IReadOnlyList<TodoViewDto>> ListAsync(CancellationToken ct = default)
        => (await repo.ListAsync(ct)).Select(Map).ToList();

    public async Task<TodoViewDto?> GetAsync(Guid id, CancellationToken ct = default)
    {
        var e = await repo.GetAsync(id, ct);
        return e is null ? null : Map(e);
    }

    public async Task<bool> UpdateAsync(Guid id, TodoUpdateDto dto, CancellationToken ct = default)
    {
        var e = await repo.GetAsync(id, ct);
        if (e is null) return false;
        e.Update(dto.Title, dto.Description, dto.DueDate);
        await repo.UpdateAsync(e, ct);
        return true;
    }

    public async Task<bool> ToggleCompleteAsync(Guid id, bool isCompleted, CancellationToken ct = default)
    {
        var e = await repo.GetAsync(id, ct);
        if (e is null) return false;
        if (isCompleted) e.Complete(); else e.Uncomplete();
        await repo.UpdateAsync(e, ct);
        return true;
    }

    public Task DeleteAsync(Guid id, CancellationToken ct = default) => repo.DeleteAsync(id, ct);

    private static TodoViewDto Map(TodoItem e)
        => new(e.Id, e.Title, e.Description, e.DueDate, e.IsCompleted, e.CreatedAt, e.UpdatedAt);
}
