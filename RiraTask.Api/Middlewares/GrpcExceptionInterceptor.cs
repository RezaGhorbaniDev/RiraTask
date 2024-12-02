using Grpc.Core;
using Grpc.Core.Interceptors;
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
            // Already is a gRPC exception
            throw;
        }
        catch (Exception ex)
        {
            // TODO user NLog
            logger.LogError(ex, "An unhandled exception occurred.");
            throw new RpcException(new Status(StatusCode.Internal, "An internal server error occurred"), ex.Message);
        }
    }
}
