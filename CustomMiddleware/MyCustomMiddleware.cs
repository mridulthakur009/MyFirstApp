public class MycustomMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await context.Response.WriteAsync("Custom Middleware -  Starts Here \n");
        await next(context);
        await context.Response.WriteAsync("Custom Middleware - Ends Here \n");
    }
}
public static class CustomMiddlewareExtension
{
    public static IApplicationBuilder UseMyCustomMiddlewareExtension(this IApplicationBuilder app)
    {
        return app.UseMiddleware<MycustomMiddleware>();
    }
}