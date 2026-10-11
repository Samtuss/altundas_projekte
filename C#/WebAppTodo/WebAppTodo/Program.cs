namespace WebAppTodo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<TodoService>();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            // Phase B: Endpoints

            app.MapGet("/todos", (TodoService service) =>
                Results.Ok(service.GetAll()));

            app.MapGet("/todos/{id}", (int id, TodoService service) =>
            {
                var todo = service.GetById(id);
                return todo is not null ? Results.Ok(todo) : Results.NotFound();
            });

            app.MapPost("/todos", (string title, TodoService service) =>
            {
                var todo = service.Add(title);
                return Results.Created($"/todos/{todo.Id}", todo);
            });

            app.MapDelete("/todos/{id}", (int id, TodoService service) =>
            {
                var deleted = service.Delete(id);
                return deleted ? Results.NoContent() : Results.NotFound();
            });

            // Erweiterung 1: Nur erledigte Todos
            app.MapGet("/todos/done", (TodoService service) =>
                Results.Ok(service.GetDone()));

            // Erweiterung 2: Todo als erledigt markieren
            app.MapPut("/todos/{id}/done", (int id, TodoService service) =>
            {
                var marked = service.MarkDone(id);
                return marked ? Results.NoContent() : Results.NotFound();
            });

            app.Run();
        }
    }
}
