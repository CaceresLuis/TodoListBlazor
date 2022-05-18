using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoListBlazor.Shared.Dtos;
using TodoListBlazor.Api.Aplication.TodoActions.Queries;
using TodoListBlazor.Api.Aplication.TodoActions.Commands;

namespace TodoListBlazor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<TodoDto>> GetAll()
        {
            return await _mediator.Send(new ListTodoQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoDto>> Get(Guid id)
        {
            return await _mediator.Send(new GetTodoQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddTodo([FromBody] AddTodoDto addTodoDto)
        {
            if (await _mediator.Send(new AddTodoCommand { AddTodoDto = addTodoDto }))
                return true;

            return false;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Put(Guid id, TodoDto todoDto)
        {
            todoDto.Id = id;
            return await _mediator.Send(new UpdateTodoCommand { TodoDto = todoDto });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteTodoCommand { Id = id });
        }
    }
}
