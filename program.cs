using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
await using var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/", (Func<string>)(() =>
{
    return @"
        <!DOCTYPE html>
        <html>
        <head>
            <title>Hola Mundo</title>
        </head>
        <body>
            <h1>Hola Mundo</h1>
        </body>
        </html>";
}));

await app.RunAsync();

