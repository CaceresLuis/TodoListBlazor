using Moq;
using System;
using System.Collections.Generic;
using TodoListBlazor.Api.Data.Entities;
using TodoListBlazor.Api.Repositories.Contracts;
using TodoListBlazor.Shared.Dtos;

namespace TodoListBlazor.Test.Mocks
{
    public static class MockTodoRepository
    {
        public static Mock<ITodoRepository> GetAll()
        {
            List<Todo> todos = new()
            {
                new Todo
                {
                    Id =  Guid.NewGuid(),
                    Title = "tarea 1",
                    TodoState = "Do",
                    Description = "tarea de prueba",
                    IsCompleted = true,
                },
                new Todo
                {
                    Id =  Guid.NewGuid(),
                    Title = "tarea 2",
                    TodoState = "Doing",
                    Description = "tarea de pruebas",
                    IsCompleted = true,
                }
            };

            var mockRepo = new Mock<ITodoRepository>();
            mockRepo.Setup(r => r.GetTodos()).ReturnsAsync(todos);

            mockRepo.Setup(r => r.AddTodo(It.IsAny<Todo>())).ReturnsAsync((Todo todo) =>
            {
                todos.Add(todo);
                return true;
            });

            return mockRepo;
        }
    }
}
