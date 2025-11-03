
using Todo.Application.DTOs;
using Todo.Application.Services;
using Todo.Domain.Abstractions;
using Todo.Domain.Entities;
using Xunit;
using FluentAssertions;

public class FakeRepo : ITodoRepository
{
    public List<TodoItem> Items = new();

    public Task<TodoItem> AddAsync(TodoItem item, CancellationToken ct = default)
    {
        Items.Add(item);
        return Task.FromResult(item);
    }

    public Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        Items.RemoveAll(x => x.Id == id);
        return Task.CompletedTask;
    }

    public Task<TodoItem?> GetAsync(Guid id, CancellationToken ct = default)
        => Task.FromResult(Items.FirstOrDefault(x => x.Id == id));

    public Task<IReadOnlyList<TodoItem>> ListAsync(CancellationToken ct = default)
        => Task.FromResult((IReadOnlyList<TodoItem>)Items);

    public Task UpdateAsync(TodoItem item, CancellationToken ct = default)
        => Task.CompletedTask;
}

public class TodoServiceTests
{
    [Fact]
    public async Task Should_Create_Task()
    {
        var repo = new FakeRepo();
        var service = new TodoService(repo);

        var dto = new TodoCreateDto("Test", null, null);

        var result = await service.CreateAsync(dto);

        repo.Items.Should().HaveCount(1);
        result.Title.Should().Be("Test");
    }

    [Fact]
    public async Task Should_List_All_Tasks()
    {
        var repo = new FakeRepo();
        var service = new TodoService(repo);

        await service.CreateAsync(new TodoCreateDto("A", null, null));
        await service.CreateAsync(new TodoCreateDto("B", null, null));

        var list = await service.ListAsync();

        list.Should().HaveCount(2);
    }

    [Fact]
    public async Task Should_Update_Task()
    {
        var repo = new FakeRepo();
        var service = new TodoService(repo);

        var created = await service.CreateAsync(new TodoCreateDto("Old", null, null));
        var ok = await service.UpdateAsync(created.Id, new TodoUpdateDto("New", "Desc", null));

        ok.Should().BeTrue();
        repo.Items.First().Title.Should().Be("New");
    }

    [Fact]
    public async Task Should_Toggle_Complete()
    {
        var repo = new FakeRepo();
        var service = new TodoService(repo);

        var created = await service.CreateAsync(new TodoCreateDto("X", null, null));
        await service.ToggleCompleteAsync(created.Id, true);

        repo.Items.First().IsCompleted.Should().BeTrue();
    }

    [Fact]
    public async Task Should_Delete_Task()
    {
        var repo = new FakeRepo();
        var service = new TodoService(repo);

        var created = await service.CreateAsync(new TodoCreateDto("X", null, null));
        await service.DeleteAsync(created.Id);

        repo.Items.Should().BeEmpty();
    }
}
