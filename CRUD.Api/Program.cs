using CRUD.Application.DTOs;
using CRUD.Application.Interfaces;
using CRUD.Application.Services;
using CRUD.Domain.Interfaces;
using CRUD.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddOpenApi();
builder.Services.AddSingleton<ICrudRepository, InMemoryCrudRepository>();
builder.Services.AddScoped<ICrudService, CrudService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var carros = app.MapGroup("/carros");

carros.MapGet("/", async (ICrudService service) =>
{
    var resultado = await service.GetAllAsync();
    return Results.Ok(resultado);
});

carros.MapGet("/{id:int}", async (int id, ICrudService service) =>
{
    var resultado = await service.GetByIdAsync(id);
    return resultado is null ? Results.NotFound() : Results.Ok(resultado);
});

carros.MapPost("/", async (CrudCreateDto dto, ICrudService service) =>
{
    var resultado = await service.AddAsync(dto);
    return Results.Created($"/carros/{resultado.Id}", resultado);
});

carros.MapPut("/{id:int}", async (int id, CrudUpdateDto dto, ICrudService service) =>
{
    var atualizado = await service.UpdateAsync(id, dto);
    return atualizado ? Results.NoContent() : Results.NotFound();
});

carros.MapDelete("/{id:int}", async (int id, ICrudService service) =>
{
    var removido = await service.DeleteAsync(id);
    return removido ? Results.NoContent() : Results.NotFound();
});

app.Run();
