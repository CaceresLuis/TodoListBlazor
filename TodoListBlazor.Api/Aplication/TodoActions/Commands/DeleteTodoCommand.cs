using MediatR;

namespace TodoListBlazor.Api.Aplication.TodoActions.Commands
{
    public class DeleteTodoCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
