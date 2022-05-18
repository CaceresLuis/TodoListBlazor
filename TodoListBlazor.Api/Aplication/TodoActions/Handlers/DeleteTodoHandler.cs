using MediatR;
using System.Net;
using TodoListBlazor.Shared.Enums;
using TodoListBlazor.Api.Exeptions;
using TodoListBlazor.Api.Data.Entities;
using TodoListBlazor.Api.Repositories.Contracts;
using TodoListBlazor.Api.Aplication.TodoActions.Commands;

namespace TodoListBlazor.Api.Aplication.TodoActions.Handlers
{
    public class DeleteTodoHandler : IRequestHandler<DeleteTodoCommand, bool>
    {
        private readonly ITodoRepository _todoRepository;

        public DeleteTodoHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<bool> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            Todo todo = await _todoRepository.GetTodo(request.Id);
            if (todo == null)
                throw new ExceptionHandler(HttpStatusCode.BadRequest,
                    new Error
                    {
                        Code = "Error",
                        Message = "Task does exist",
                        Title = "Error",
                        State = StateAlert.error,
                        IsSuccess = false
                    });

            return await _todoRepository.DeleteTodo(todo);
        }
    }
}
