using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Todo.Api.Hubs;
using Todo.Application.Services;
using Todo.Domain.Abstractions;
using Todo.Infrastructure.Persistence;
using Todo.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<TodoService>();

builder.Services.AddSignalR();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("ng", p => p
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .WithOrigins("http://localhost:4200"));
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("ng");

app.MapControllers();

// SignalR Hub
app.MapHub<TodoHub>("/hubs/todo");

app.Run();
