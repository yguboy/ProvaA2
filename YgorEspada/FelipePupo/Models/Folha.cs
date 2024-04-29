using System.ComponentModel.DataAnnotations;

namespace FelipePupo.Models;

public class Folha
{
    public Folha(double valor, double quantidade, double mes, double ano)
    {
        Id = Guid.NewGuid().ToString();
        Valor = valor;
        Quantidade = quantidade;
        Mes = mes;
        Ano = ano;
    }

    public string Id { get; set; }

    [MinLength(1, ErrorMessage = "Este campo deve ter no mínimo 1 caracteres!")]
    public double Valor { get; set; }
    [MinLength(1, ErrorMessage = "Este campo deve ter no mínimo 1 caracteres!")]
    public double Quantidade { get; set; }
    [MinLength(1, ErrorMessage = "Este campo deve ter no mínimo 1 caracteres!")]
    public double Mes { get; set; }
    [MinLength(4, ErrorMessage = "Este campo deve ter no mínimo 4 caracteres!")]
    public double Ano { get; set; }
}