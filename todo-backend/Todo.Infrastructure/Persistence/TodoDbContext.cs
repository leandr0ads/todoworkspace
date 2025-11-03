using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Infrastructure.Persistence;

public sealed class TodoDbContext(DbContextOptions<TodoDbContext> options) : DbContext(options)
{
    public DbSet<TodoItem> Todos => Set<TodoItem>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        var e = b.Entity<TodoItem>();
        e.ToTable("Todos");
        e.HasKey(x => x.Id);
        e.Property(x => x.Title).IsRequired().HasMaxLength(200);
        e.Property(x => x.Description).HasMaxLength(1000);
        e.Property(x => x.IsCompleted).HasDefaultValue(false);
        e.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
    }
}
