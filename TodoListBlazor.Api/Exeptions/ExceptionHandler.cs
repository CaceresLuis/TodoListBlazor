using System.Net;

namespace TodoListBlazor.Api.Exeptions
{
    public class ExceptionHandler : Exception
    {
        public HttpStatusCode Code { get; }
        public Error Error { get; }
        public ExceptionHandler(HttpStatusCode code, Error error)
        {
            Code = code;
            Error = error;
        }
    }
}
