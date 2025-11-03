namespace Todo.Domain.Entities;

public sealed class TodoItem
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public DateTime? DueDate { get; private set; }
    public bool IsCompleted { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; }

    public TodoItem(string title, string? description = null, DateTime? dueDate = null)
    {
        if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title is required");
        Title = title.Trim();
        Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();
        DueDate = dueDate;
    }

    public void Update(string title, string? description, DateTime? dueDate)
    {
        if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title is required");
        Title = title.Trim();
        Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();
        DueDate = dueDate;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Complete()
    {
        IsCompleted = true;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Uncomplete()
    {
        IsCompleted = false;
        UpdatedAt = DateTime.UtcNow;
    }
}
