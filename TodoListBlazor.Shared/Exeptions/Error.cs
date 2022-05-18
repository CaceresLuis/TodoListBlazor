using TodoListBlazor.Shared.Enums;

namespace TodoListBlazor.Shared.Exeptions
{
    public class Error
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
