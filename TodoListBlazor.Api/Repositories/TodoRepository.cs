using TodoListBlazor.Api.Data;
using Microsoft.EntityFrameworkCore;
using TodoListBlazor.Api.Data.Entities;
using TodoListBlazor.Api.Repositories.Contracts;

namespace TodoListBlazor.Api.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _dataContext;

        public TodoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Todo>> GetTodos()
        {
            return await _dataContext.Todos.ToListAsync();
        }

        public async Task<bool> AddTodo(Todo todo)
        {
            _dataContext.Todos.Add(todo);
            var data = await _dataContext.SaveChangesAsync();

            return data > 0;
        }

        public async Task<Todo> GetTodo(Guid id)
        {
            return await _dataContext.Todos.FindAsync(id);
        }

        public async Task<Todo> GetTodo(string title)
        {
            return await _dataContext.Todos.FirstOrDefaultAsync(t => t.Title == title);
        }

        public async Task<IEnumerable<Todo>> GetTodoContain(string text)
        {
            return await _dataContext.Todos.Where(t => t.Title.Contains(text)).ToListAsync();
        }

        public async Task<bool> UpdateTodo(Todo todo)
        {
            _dataContext.Todos.Update(todo);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteTodo(Todo todo)
        {
            _dataContext.Todos.Remove(todo);
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
