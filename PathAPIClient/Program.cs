using PathAPI.Models;
using PathAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<WorkspaceDatabaseSettings>(
    builder.Configuration.GetSection("WorkspaceDatabaseSettings"));
builder.Services.Configure<TaskDatabaseSettings>(
    builder.Configuration.GetSection("TaskDatabaseSettings"));
builder.Services.Configure<UserDatabaseSettings>(
    builder.Configuration.GetSection("UserDatabaseSettings"));
builder.Services.AddScoped<IWorkspaceRepository, WorkspaceRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
