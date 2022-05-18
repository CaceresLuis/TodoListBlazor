namespace TodoListBlazor.Models.Dtos
{
    public class TodoDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string TodoState { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
