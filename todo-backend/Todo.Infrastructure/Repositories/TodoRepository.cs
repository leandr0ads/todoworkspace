using Microsoft.EntityFrameworkCore;
using Todo.Domain.Abstractions;
using Todo.Domain.Entities;
using Todo.Infrastructure.Persistence;

namespace Todo.Infrastructure.Repositories;

public sealed class TodoRepository(TodoDbContext db) : ITodoRepository
{
    public async Task<TodoItem> AddAsync(TodoItem item, CancellationToken ct = default)
    {
        db.Todos.Add(item);
        await db.SaveChangesAsync(ct);
        return item;
    }

    public Task<TodoItem?> GetAsync(Guid id, CancellationToken ct = default)
        => db.Todos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, ct);

    public async Task<IReadOnlyList<TodoItem>> ListAsync(CancellationToken ct = default)
        => await db.Todos.AsNoTracking().OrderBy(x => x.IsCompleted).ThenBy(x => x.DueDate).ToListAsync(ct);

    public async Task UpdateAsync(TodoItem item, CancellationToken ct = default)
    {
        db.Todos.Update(item);
        await db.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await db.Todos.FindAsync([id], ct);
        if (entity is null) return;
        db.Todos.Remove(entity);
        await db.SaveChangesAsync(ct);
    }
}
