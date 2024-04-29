using System.ComponentModel.DataAnnotations;
using FelipePupo.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>();

var app = builder.Build();

List<Funcionario> funcionarios = new List<Funcionario>();

List<Folha> folhas = new List<Folha>();

//POST: http://localhost:5113/felipepupo/funcionario/cadastrar
app.MapPost("/FelipePupo/models/funcionario", ([FromBody] Funcionario funcionarios, [FromServices] AppDataContext context) =>
{
    List<ValidationResult> erros = new List<ValidationResult>();
    if (!Validator.TryValidateObject(funcionarios, new ValidationContext(funcionarios), erros, true))
    {
        return Results.BadRequest(erros);
    }
    return Results.BadRequest("Já existe um funcionario com o mesmo nome");
});

//GET: http://localhost:5113/felipepupo/funcionario/listar
app.MapGet("/FelipePupo/models/funcionario/listar", ([FromServices] AppDataContext context) =>
{
    if (context.Funcionarios.Any())
    {
        return Results.Ok(context.Funcionarios.ToList());
    }
    return Results.NotFound("Funcionario não encontrado!");
});

//POST: http://localhost:5113/felipepupo/folha/cadastrar
app.MapPost("/FelipePupo/models/folha/cadastrar", ([FromBody] Folha folhas, [FromServices] AppDataContext context) =>
{
    List<ValidationResult> erros = new List<ValidationResult>();
    if (!Validator.TryValidateObject(folhas, new ValidationContext(folhas), erros, true))
    {
        return Results.BadRequest(erros);
    }
    return Results.BadRequest("Folha não encontrada");
});

//GET: http://localhost:5113/felipepupo/folha/listar
app.MapGet("/FelipePupo/models/folha/listar", ([FromServices] AppDataContext context) =>
{
    if (context.Funcionarios.Any())
    {
        return Results.Ok(context.Funcionarios.ToList());
    }
    return Results.NotFound("Folha não encontrado!");
});

// //GET: http://localhost:5113/felipepupo/folha/buscar/{iddafolha}
// app.MapGet("/FelipePupo/folha/buscar/{id}", ([FromRoute] string Id, [FromRoute] AppDataContext context) =>
// {
//     Folha? folha = context.Folhas.FirstOrDefault(x => x.Id == id);

//     if (folha is null)
//     {
//         return Results.NotFound("Folha não encontrado!");
//     }
//     return Results.Ok(folha);
// });

app.Run();