using MediatR;
using AutoMapper;
using System.Net;
using TodoListBlazor.Shared.Enums;
using TodoListBlazor.Api.Exeptions;
using TodoListBlazor.Api.Data.Entities;
using TodoListBlazor.Api.Repositories.Contracts;
using TodoListBlazor.Api.Aplication.TodoActions.Commands;

namespace TodoListBlazor.Api.Aplication.TodoActions.Handlers
{
    public class AddTodoHandler : IRequestHandler<AddTodoCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly ITodoRepository _todoRepository;

        public AddTodoHandler(IMapper mapper, ITodoRepository todoRepository)
        {
            _mapper = mapper;
            _todoRepository = todoRepository;
        }

        public async Task<bool> Handle(AddTodoCommand request, CancellationToken cancellationToken)
        {
            if (await _todoRepository.GetTodo(request.AddTodoDto.Title) != null)
                throw new ExceptionHandler(HttpStatusCode.BadRequest,
                        new Error
                        {
                            Code = "Error",
                            Message = $"There is already a task with the title {request.AddTodoDto.Title}",
                            Title = "Error",
                            State = StateAlert.error,
                            IsSuccess = false
                        });
            Todo todo = _mapper.Map<Todo>(request.AddTodoDto);
            return await _todoRepository.AddTodo(todo);
        }
    }
}
