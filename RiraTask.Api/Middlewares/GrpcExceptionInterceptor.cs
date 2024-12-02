using System.Net;
using Grpc.Core;
using Grpc.Core.Interceptors;
using RiraTask.Core.Exceptions;

namespace RiraTask.Api.Middlewares;

public class GrpcExceptionInterceptor(ILogger<GrpcExceptionInterceptor> logger) : Interceptor
{
    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
        TRequest request,
        ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        try
        {
            return await continuation(request, context);
        }
        catch (RpcException)
        {
            // Already a gRPC exception, let it bubble up
            throw;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);

            var message = "An unhandled exception occurred during the gRPC call.";
            var statusCode = StatusCode.Internal;

            if (ex is CustomException customException)
            {
                message = ex.Message;
                statusCode = customException.StatusCode switch
                {
                    HttpStatusCode.NotFound => StatusCode.NotFound,
                    HttpStatusCode.BadRequest => StatusCode.InvalidArgument,
                    _ => statusCode
                };
            }

            throw new RpcException(new Status(statusCode, message));
        }
    }
}