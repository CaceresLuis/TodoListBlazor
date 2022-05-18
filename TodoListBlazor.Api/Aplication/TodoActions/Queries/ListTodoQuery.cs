using MediatR;
using TodoListBlazor.Shared.Dtos;

namespace TodoListBlazor.Api.Aplication.TodoActions.Queries
{
    public class ListTodoQuery : IRequest<IEnumerable<TodoDto>>
    {
    }
}
