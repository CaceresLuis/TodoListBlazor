using Microsoft.EntityFrameworkCore;
using TodoListBlazor.Api.Data.Entities;

namespace TodoListBlazor.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Todo> Todos { get; set; }
    }
}
