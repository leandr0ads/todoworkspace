namespace Todo.Application.DTOs;

public sealed record TodoCreateDto(string Title, string? Description, DateTime? DueDate);
public sealed record TodoUpdateDto(string Title, string? Description, DateTime? DueDate);
public sealed record TodoViewDto(Guid Id, string Title, string? Description, DateTime? DueDate, bool IsCompleted, DateTime CreatedAt, DateTime? UpdatedAt);
