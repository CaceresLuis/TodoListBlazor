using System.ComponentModel.DataAnnotations;

namespace TodoListBlazor.Api.Data.Entities
{
    public class Todo
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string? Title { get; set; }
        [MaxLength(100)]
        public string? TodoState { get; set; }
        [MaxLength(1000)]
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
