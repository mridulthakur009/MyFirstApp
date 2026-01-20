using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// app.Run(async(HttpContext context) =>
// {
//     // Adding a custom header to the response
//     context.Response.Headers["TestHeader"] = "Value"; 
//     //Note: Headers must be added before writing to the response body. 
//     //Theres should be no space between the while naming key.

//     //Server
//     //Renaming the Server header from the response 
//     context.Response.Headers["Server"] = "MyCustomServer/1.0";
//     // Note: The Server header is added by default by ASP.NET Core.
//     //By setting it to a custom value, we effectively override the default behavior.
//     //This can be useful for security reasons or to provide specific server information.
//     //However, completely removing the Server header is not directly supported in ASP.NET Core.
//     //Setting it to a custom value is a common practice to obscure server details.
//     //This will not going to change the existing behavior of the Server header.

//     //ContentType
//     //How to parse HTML content in the response body
//     context.Response.ContentType = "text/html; charset=utf-8";
//     //or context.Response.Headers["Content-Type"] = "text/html; charset=utf-8";
//     // Setting the Content-Type header to indicate that the response body contains HTML content.

//     context.Response.StatusCode = 200;
//     await context.Response.WriteAsync("<h1>Hello!</h1></br> ");  //WriteAsync method Writes the given text to the response body. UTF-8 encoding will be used.
//     await context.Response.WriteAsync("<h2>I am learning about HTTP Status Codes! </h2>");


// });

app.Run(async (HttpContext context) =>
{
    //HTTP Request
    // string path = context.Request.Path;
    // string method = context.Request.Method;
    // context.Response.ContentType = "text/plain; charset=utf-8";
    // await context.Response.WriteAsync($"Request Path: {path}\n");
    // await context.Response.WriteAsync($"Request Method: {method}\n");

    //HTTP Status Codes (Response.StatusCode)
    // context.Response.StatusCode = 404; // Not Found
    // await context.Response.WriteAsync($"Response Status Code: {context.Response.StatusCode}\n");

    // string path = context.Request.Path;
    // string method = context.Request.Method;

    // context.Response.ContentType = "text/html";
    // if(path == "/")
    // {
    //     await context.Response.WriteAsync("<h1>Welcome to the Home Page!</h1>\n");
    //     await context.Response.WriteAsync($"<h2>HTTP Method: {method}</h2>\n");

    // }
    // else if(path == "/about")
    // {
    //     await context.Response.WriteAsync("<h1>About Us</h1>\n");
    // }
    // else
    // {
    //     context.Response.StatusCode = 404; // Not Found
    //     await context.Response.WriteAsync("<h1>404 - Page Not Found</h1>\n");
    // }
    // await context.Response.WriteAsync($"<h1>Request Path: {path}</h1>\n");

    // //Query Parameters on GET Request
    // if(context.Request.Method == "GET")
    // {
    //     if(context.Request.Query.ContainsKey("name"))
    //     {
    //         string name = context.Request.Query["name"];
    //         await context.Response.WriteAsync($"<h2>Hello, My name is {name}!</h2>\n");
    //     }
    // }
        
        //StreamReader is used to read the body of the request. 
        //context.Response.Body is a stream that represents the body of the HTTP response.
        //The ReadToEndAsync method reads the entire stream asynchronously and returns the content as a string.
        
        StreamReader reader = new StreamReader(context.Request.Body);
        string body = await reader.ReadToEndAsync();

        //stringValues can hold multiple values for a single key.
        //but string can hold only one value.
        //QueryHelpers.ParseQuery method is used to parse the query string from the body of the request.
        Dictionary<string, StringValues> queryParameters = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);

        if(queryParameters.ContainsKey("name"))
        {
            string ?name = queryParameters["name"][0];
            await context.Response.WriteAsync($"<h2>Hello, My name is {name}!</h2>\n");
        }
});

app.Run();
