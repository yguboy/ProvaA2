using System.ComponentModel.DataAnnotations;
using FelipePupo.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>();

var ygorespada_felipepupo = builder.Build();

List<Funcionario> funcionarios = new List<Funcionario>();

// List<Folha> folhas = new List<Folha>();

//POST: http://localhost:5113/felipepupo/models/funcionario/cadastrar
ygorespada_felipepupo.MapPost("/felipepupo/funcionario/cadastrar/", ([FromBody] Funcionario funcionario, [FromServices] AppDataContext context) =>
{
    // List<ValidationResult> erros = new List<ValidationResult>();
    // if (!Validator.TryValidateObject(funcionario, new ValidationContext(funcionario), erros, true))
    // {
    //     return Results.BadRequest(erros);
    // }

    Funcionario? funcionarioBuscar = context.Funcionarios.FirstOrDefault(x => x.Nome == funcionario.Nome);
    // return Results.BadRequest("Já existe um funcionario com o mesmo nome");
});

//GET: http://localhost:5113/felipepupo/models/funcionario/listar
ygorespada_felipepupo.MapGet("/felipepupo/funcionario/listar/", ([FromServices] AppDataContext context) =>
{
    if (context.Funcionarios.Any())
    {
        return Results.Ok(context.Funcionarios.ToList());
    }
    return Results.NotFound("Funcionario não encontrado!");
});

//POST: http://localhost:5113/felipepupo/folha/cadastrar
ygorespada_felipepupo.MapPost("/FelipePupo/models/folha/cadastrar", ([FromBody] Folha folhas, [FromServices] AppDataContext context) =>
{
    List<ValidationResult> erros = new List<ValidationResult>();
    if (!Validator.TryValidateObject(folhas, new ValidationContext(folhas), erros, true))
    {
        return Results.BadRequest(erros);
    }
    return Results.BadRequest("Folha não encontrada");
});

//GET: http://localhost:5113/felipepupo/folha/listar
ygorespada_felipepupo.MapGet("/FelipePupo/models/folha/listar", ([FromServices] AppDataContext context) =>
{
    if (context.Funcionarios.Any())
    {
        return Results.Ok(context.Funcionarios.ToList());
    }
    return Results.NotFound("Folha não encontrado!");
});

ygorespada_felipepupo.Run();