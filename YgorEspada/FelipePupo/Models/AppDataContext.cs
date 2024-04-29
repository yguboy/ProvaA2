using Microsoft.EntityFrameworkCore;

namespace FelipePupo.Models;

public class AppDataContext : DbContext
{
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Funcionario> Folhas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("ygorespada_felipepupo.db");
    }
}
