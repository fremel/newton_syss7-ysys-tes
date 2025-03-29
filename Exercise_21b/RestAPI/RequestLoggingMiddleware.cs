public class RequestLoggingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // Log information about the incoming request
        Console.WriteLine($"Received {context.Request.Method} request for {context.Request.Path}");

        // Call the next middleware in the pipeline
        await next(context);
    }
}
