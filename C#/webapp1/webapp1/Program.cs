using static System.Index;
var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

app.MapGet("/Pages", () =>
{

});

app.MapGet("/", () => "Hello World!");

var studierende = new string[] { "Alice", "Bob", "Charlie" };

app.MapGet("/studierende", () => studierende);

var objects = new object[] { 42, "Hello", DateTime.Now };

app.MapGet("/object", () => objects);

app.MapGet("/object/{index}", (int index) =>
{
    if (index < 0 || index >= objects.Length)
    {
        return Results.BadRequest("Index out of range");
    }
    return Results.Ok(objects[index]);
});

app.Run();
