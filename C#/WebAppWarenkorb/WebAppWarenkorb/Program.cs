using WebAppWarenkorb;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<WarenkorbService>();

var app = builder.Build();

app.UseSwagger(); // Swagger
app.UseSwaggerUI(); // Swagger

app.MapGet("/", () => "Hello world!");

app.MapGet("/produkte/total", (WarenkorbService svc) =>
{
    return Results.Ok(new { total = svc.GetTotal() });
});

app.MapGet("/produkte", (WarenkorbService svc, decimal? minPreis) =>
{
    if (minPreis.HasValue)
    {
        var gefiltert = svc.GetAll().Where(p => p.Preis >= minPreis.Value).ToList();
        return Results.Ok(gefiltert);
    }
    return Results.Ok(svc.GetAll());
});

app.MapGet("/produkte/{id}", (WarenkorbService svc, int id) =>
{
    var produkt = svc.GetById(id);
    return produkt != null ? Results.Ok(produkt) : Results.NotFound();
});

app.MapPost("/produkte", (WarenkorbService svc, ProduktRequest request) =>
{
    var produkt = svc.Add(request.Name, request.Preis);
    return Results.Created($"/produkte/{produkt.Id}", produkt);
});

app.MapDelete("/produkte/{id}", (WarenkorbService svc, int id) =>
{
    bool removed = svc.Remove(id);
    return removed ? Results.NoContent() : Results.NotFound();
});

app.Run();

record ProduktRequest(string Name, decimal Preis);