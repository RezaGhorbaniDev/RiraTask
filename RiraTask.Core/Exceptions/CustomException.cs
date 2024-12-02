using System.Net;

namespace RiraTask.Core.Exceptions;

public abstract class CustomException : Exception
{
    public CustomException(string message) : base(message)
    {
        StatusCode = HttpStatusCode.InternalServerError;
    }

    public HttpStatusCode StatusCode { get; protected set; }
}
