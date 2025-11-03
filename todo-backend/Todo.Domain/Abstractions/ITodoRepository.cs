using Todo.Domain.Entities;

namespace Todo.Domain.Abstractions;

public interface ITodoRepository
{
    Task<TodoItem> AddAsync(TodoItem item, CancellationToken ct = default);
    Task<TodoItem?> GetAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<TodoItem>> ListAsync(CancellationToken ct = default);
    Task UpdateAsync(TodoItem item, CancellationToken ct = default);
    Task DeleteAsync(Guid id, CancellationToken ct = default);
}
