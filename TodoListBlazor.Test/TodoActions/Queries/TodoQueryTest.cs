using Moq;
using Xunit;
using Shouldly;
using AutoMapper;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoListBlazor.Test.Mocks;
using System.Collections.Generic;
using TodoListBlazor.Shared.Dtos;
using TodoListBlazor.Api.Mapping;
using TodoListBlazor.Api.Repositories.Contracts;
using TodoListBlazor.Api.Aplication.TodoActions.Handlers;
using TodoListBlazor.Api.Aplication.TodoActions.Queries;

namespace TodoListBlazor.Test.TodoActions.Queries
{
    public class TodoQueryTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ITodoRepository> _mockRepo;

        public TodoQueryTest()
        {
            MapperConfiguration? mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MapProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _mockRepo = MockTodoRepository.GetAll();
        }

        [Fact]
        public async Task GetTodos()
        {
            ListTodoHandler? handler = new ListTodoHandler(_mapper, _mockRepo.Object);

            IEnumerable<TodoDto>? result = await handler.Handle(new ListTodoQuery(), CancellationToken.None);
            result.ShouldBeOfType<List<TodoDto>>();
            result.Count().ShouldBe(2);
        }
    }
}
