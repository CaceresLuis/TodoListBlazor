using MediatR;
using TodoListBlazor.Shared.Dtos;

namespace TodoListBlazor.Api.Aplication.TodoActions.Commands
{
    public class AddTodoCommand : IRequest<bool>
    {
        public AddTodoDto AddTodoDto { get; set; }
    }
}
