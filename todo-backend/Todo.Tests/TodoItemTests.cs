using Todo.Domain.Entities;
using Xunit;
using FluentAssertions;

public class TodoItemTests
{
    [Fact]
    public void Create_Valid_Title_Sets_Props()
    {
        var t = new TodoItem("Estudar Angular", "Forms", DateTime.UtcNow);
        t.Title.Should().Be("Estudar Angular");
        t.IsCompleted.Should().BeFalse();
    }

    [Fact]
    public void Complete_Sets_IsCompleted()
    {
        var t = new TodoItem("X");
        t.Complete();
        t.IsCompleted.Should().BeTrue();
        t.UpdatedAt.Should().NotBeNull();
    }

    [Fact]
    public void Create_Empty_Title_Should_Throw()
    {
        Action act = () => new TodoItem("");
        act.Should().Throw<ArgumentException>().WithMessage("Title is required*");
    }

    [Fact]
    public void Update_Should_Change_Properties()
    {
        var t = new TodoItem("Old title");
        t.Update("New title", "New desc", DateTime.UtcNow);

        t.Title.Should().Be("New title");
        t.Description.Should().Be("New desc");
        t.UpdatedAt.Should().NotBeNull();
    }

    [Fact]
    public void Uncomplete_Should_Reset_IsCompleted()
    {
        var t = new TodoItem("Study");
        t.Complete();
        t.Uncomplete();

        t.IsCompleted.Should().BeFalse();
        t.UpdatedAt.Should().NotBeNull();
    }
}
