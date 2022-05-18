using MediatR;
using AutoMapper;
using TodoListBlazor.Shared.Dtos;
using TodoListBlazor.Api.Data.Entities;
using TodoListBlazor.Api.Repositories.Contracts;
using TodoListBlazor.Api.Aplication.TodoActions.Queries;

namespace TodoListBlazor.Api.Aplication.TodoActions.Handlers
{
    public class ListTodoHandler : IRequestHandler<ListTodoQuery, IEnumerable<TodoDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITodoRepository _todoRepository;

        public ListTodoHandler(IMapper mapper, ITodoRepository todoRepository)
        {
            _mapper = mapper;
            _todoRepository = todoRepository;
        }

        public async Task<IEnumerable<TodoDto>> Handle(ListTodoQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Todo>? todo = await _todoRepository.GetTodos();
            return _mapper.Map<IEnumerable<TodoDto>>(todo);
        }
    }
}
