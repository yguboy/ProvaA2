using Microsoft.EntityFrameworkCore;

namespace FelipePupo.Models;

public class AppDataContext : DbContext
{
    public DbSet<Funcionario> Funcionarios { get; set; }
    // public DbSet<Funcionario> Folha { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=ygorespada_felipepupo.db");
    }
}
