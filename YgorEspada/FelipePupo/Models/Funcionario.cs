using System.ComponentModel.DataAnnotations;

namespace FelipePupo.Models;

public class Funcionario
{
    public Funcionario(string nome, double cpf)
    {
        Id = Guid.NewGuid().ToString();
        Nome = nome;
        Cpf = cpf;
    }
    public string Id { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório!")]
    public string? Nome { get; set; }

    [MinLength(11, ErrorMessage = "Este campo deve ter no mínimo 11 caracteres!")]
    public double Cpf { get; set; }
}