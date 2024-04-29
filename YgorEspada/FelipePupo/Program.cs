using System.ComponentModel.DataAnnotations;
using FelipePupo.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

List<Funcionario> funcionarios = new List<Funcionario>();

//POST: http://localhost:/felipepupo/funcionario/cadastrar
app.MapPost("/FelipePupo/models/funcionario", ([FromBody] Funcionario funcionarios, [FromServices] AppDataContext context) =>
{
    List<ValidationResult> erros = new List<ValidationResult>();
    if (!Validator.TryValidateObject(funcionarios, new ValidationContext(funcionarios), erros, true))
    {
        return Results.BadRequest(erros);
    }
    return Results.BadRequest("Já existe um funcionario com o mesmo nome");
});
