using TodoListBlazor.Api.Data.Entities;

namespace TodoListBlazor.Api.Repositories.Contracts
{
    public interface ITodoRepository
    {
        Task<bool> AddTodo(Todo todo);
        Task<bool> DeleteTodo(Todo todo);
        Task<Todo> GetTodo(Guid id);
        Task<Todo> GetTodo(string title);
        Task<IEnumerable<Todo>> GetTodoContain(string text);
        Task<IEnumerable<Todo>> GetTodos();
        Task<bool> UpdateTodo(Todo todo);
    }
}
