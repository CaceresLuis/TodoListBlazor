using MediatR;
using AutoMapper;
using System.Net;
using TodoListBlazor.Shared.Dtos;
using TodoListBlazor.Shared.Enums;
using TodoListBlazor.Api.Exeptions;
using TodoListBlazor.Api.Data.Entities;
using TodoListBlazor.Api.Repositories.Contracts;
using TodoListBlazor.Api.Aplication.TodoActions.Queries;

namespace TodoListBlazor.Api.Aplication.TodoActions.Handlers
{
    public class GetTodoHandler : IRequestHandler<GetTodoQuery, TodoDto>
    {
        private readonly IMapper _mapper;
        private readonly ITodoRepository _todoRepository;

        public GetTodoHandler(IMapper mapper, ITodoRepository todoRepository)
        {
            _mapper = mapper;
            _todoRepository = todoRepository;
        }

        public async Task<TodoDto> Handle(GetTodoQuery request, CancellationToken cancellationToken)
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

            return _mapper.Map<TodoDto>(todo);
        }
    }
}
