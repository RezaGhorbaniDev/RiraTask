
namespace RiraTask.Core.Exceptions;

public class BadRequestException : CustomException
{
    public BadRequestException(string message) : base(message)
    {
        StatusCode = System.Net.HttpStatusCode.BadRequest;  
    }
}
