using MediatR;
using System.Net;
using TodoListBlazor.Shared.Dtos;
using TodoListBlazor.Shared.Enums;
using TodoListBlazor.Api.Exeptions;
using TodoListBlazor.Api.Data.Entities;
using TodoListBlazor.Api.Repositories.Contracts;
using TodoListBlazor.Api.Aplication.TodoActions.Commands;

namespace TodoListBlazor.Api.Aplication.TodoActions.Handlers
{
    public class UpdateTodoHandler : IRequestHandler<UpdateTodoCommand, bool>
    {
        private readonly ITodoRepository _todoRepository;

        public UpdateTodoHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<bool> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            TodoDto todoDto = request.TodoDto;
            Todo todo = await _todoRepository.GetTodo(todoDto.Id);
            if (todo == null)
                throw new ExceptionHandler(HttpStatusCode.BadRequest,
                    new Error
                    {
                        Code = "Error",
                        Message = "Task does exist",
                        Title = "Erro",
                        State = StateAlert.error,
                        IsSuccess = false
                    });

            if (todo.Title != todoDto.Title && todoDto.Title != null)
            {
                if (await _todoRepository.GetTodo(todoDto.Title) != null)
                    throw new ExceptionHandler(HttpStatusCode.BadRequest,
                    new Error
                    {
                        Code = "Error",
                        Message = "Task does exist",
                        Title = "Erro",
                        State = StateAlert.error,
                        IsSuccess = false
                    });
            }

            todo.Title = todoDto.Title ?? todo.Title;
            todo.Description = todoDto.Description ?? todo.Description;
            todo.TodoState = todoDto.TodoState ?? todo.TodoState;
            todo.IsCompleted = todoDto.IsCompleted;

            return await _todoRepository.UpdateTodo(todo);
        }
    }
}
