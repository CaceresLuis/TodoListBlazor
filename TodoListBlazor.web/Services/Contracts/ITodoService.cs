using TodoListBlazor.Shared.Dtos;

namespace TodoListBlazor.web.Services.Contracts
{
    public interface ITodoService
    {
        Task CreateTodo(AddTodoDto todoDto);
        Task DeleteTodo(Guid id);
        Task<TodoDto> GetTodo(Guid id);
        Task<List<TodoDto>> ListTodo();
        Task UpdateTodo(TodoDto todoDto);
    }
}
