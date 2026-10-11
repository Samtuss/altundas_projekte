using StudentApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<StudentService>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

var students = new List<string> { "Anna", "Ben", "Clara" };

app.MapGet("/students", () => students);

app.MapGet("/students/{id}", (int id) =>
{
    if (id < 0 || id >= students.Count)
        return Results.BadRequest("Exisitiert nicht");
    return Results.Ok(students[id]);
});



app.MapGet("/students/all", (StudentService svc) => svc.GetAll());
app.Run();
