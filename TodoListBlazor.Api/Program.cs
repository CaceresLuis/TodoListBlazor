using MediatR;
using TodoListBlazor.Api.Data;
using TodoListBlazor.Api.Exeptions;
using Microsoft.EntityFrameworkCore;
using TodoListBlazor.Api.Repositories;
using TodoListBlazor.Api.Repositories.Contracts;
using TodoListBlazor.Api.Aplication.TodoActions.Commands;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(conf =>
{
    conf.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddMediatR(typeof(AddTodoCommand).Assembly);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ITodoRepository, TodoRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy =>
{
    policy.WithOrigins("http://localhost:7132", "https://localhost:7132")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType);
});

app.UseMiddleware<MiddelwareHandler>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
