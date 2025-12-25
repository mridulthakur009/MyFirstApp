var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async(HttpContext context) =>
{
    // Adding a custom header to the response
    context.Response.Headers["TestHeader"] = "Value"; 
    //Note: Headers must be added before writing to the response body. 
    //Theres should be no space between the while naming key.

    //Removing the Server header from the response 
    context.Response.Headers["Server"] = "MyCustomServer/1.0";
    // Note: The Server header is added by default by ASP.NET Core.
    //By setting it to a custom value, we effectively override the default behavior.
    //This can be useful for security reasons or to provide specific server information.
    //However, completely removing the Server header is not directly supported in ASP.NET Core.
    //Setting it to a custom value is a common practice to obscure server details.
    //This will not going to change the existing behavior of the Server header.
    
    context.Response.StatusCode = 200;
    await context.Response.WriteAsync("Hello! ");  //WriteAsync method Writes the given text to the response body. UTF-8 encoding will be used.
    await context.Response.WriteAsync("I am learning about HTTP Status Codes!");


});

app.Run();
