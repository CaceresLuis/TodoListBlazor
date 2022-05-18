using System.Net;

namespace TodoListBlazor.Shared.Exeptions
{
    public class ExceptionHandler : Exception
    {
        public Error Error { get; }
        public ExceptionHandler(Error error)
        {
            Error = error;
        }
    }
}
