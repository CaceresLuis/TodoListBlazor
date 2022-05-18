using MediatR;
using TodoListBlazor.Shared.Dtos;

namespace TodoListBlazor.Api.Aplication.TodoActions.Commands
{
    public class UpdateTodoCommand : IRequest<bool>
    {
        public TodoDto TodoDto { get; set; }
    }
}
