using MediatR;
using TodoListBlazor.Shared.Dtos;

namespace TodoListBlazor.Api.Aplication.TodoActions.Queries
{
    public class GetTodoQuery : IRequest<TodoDto>
    {
        public Guid Id { get; set; }
    }
}
