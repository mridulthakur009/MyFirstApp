public class MycustomMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await context.Response.WriteAsync("Custom Middleware -  Starts Here \n");
        await next(context);
        await context.Response.WriteAsync("Custom Middleware - Ends Here \n");
    }
}