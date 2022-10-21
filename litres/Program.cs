using System.Data;
using litres;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var service = new Litres();

app.MapGet("/", () => "Hello World!!!");

app.MapPost("/litres", (LitresRequest request) =>
{
    try
    {
        return Results.Ok(service.FindBook(request.Name));
    }
    catch (DataException e)
    {
        return Results.NotFound();
    }
});

app.Run();