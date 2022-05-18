using AutoMapper;
using Moq;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoListBlazor.Api.Aplication.TodoActions.Commands;
using TodoListBlazor.Api.Aplication.TodoActions.Handlers;
using TodoListBlazor.Api.Mapping;
using TodoListBlazor.Api.Repositories.Contracts;
using TodoListBlazor.Shared.Dtos;
using TodoListBlazor.Test.Mocks;
using Xunit;

namespace TodoListBlazor.Test.TodoActions.Command
{
    public class AddTodoHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ITodoRepository> _mockRepo;
        private readonly AddTodoDto _todoDto;

        public AddTodoHandlerTest()
        {
            MapperConfiguration? mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MapProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _mockRepo = MockTodoRepository.GetAll();

            _todoDto = new AddTodoDto
            {
                Title = "tarea 1",
                TodoState = "Do",
                Description = "tarea de prueba",
                IsCompleted = true,
            };
        }

        [Fact]
        public async Task AddTodo()
        {
            var handler = new AddTodoHandler(_mapper, _mockRepo.Object);
            var result = await handler.Handle(new AddTodoCommand() { AddTodoDto = _todoDto }, CancellationToken.None);

            System.Collections.Generic.IEnumerable<Api.Data.Entities.Todo>? todos = await _mockRepo.Object.GetTodos();
            result.ShouldBeOfType<bool>();
            todos.Count().ShouldBe(3);

        }
    }
}
