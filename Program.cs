var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async(HttpContext context) =>
{
    context.Response.StatusCode = 400;
    await context.Response.WriteAsync("Hello! ");  //WriteAsync method Writes the given text to the response body. UTF-8 encoding will be used.
    await context.Response.WriteAsync("This is my first .NET Core Web Application");
});

app.Run();
