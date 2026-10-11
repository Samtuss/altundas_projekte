namespace StudentsApiNeu
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddSingleton<StudentService>();



            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            var students = new List<string> { "Alice", "Bob", "Charlie" };

            app.MapGet("/students/{id}", (int id) =>
            {
                if (id < 0 || id >= students.Count)
                {
                    return Results.BadRequest("Existiert nicht");
                }
                return Results.Ok(students[id]);
            });

            app.MapGet("/students/all", (StudentService svc) => svc.GetAll());

            app.UseSwagger();
            app.UseSwaggerUI();

            app.Run();



        }
    }
}
