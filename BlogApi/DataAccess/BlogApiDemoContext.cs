using Microsoft.EntityFrameworkCore;

namespace BlogApi.DataAccess;

public class BlogApiDemoContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost;Database=BlogApiDemo;User=sa;Password=Enes35.*;");
    }

    public DbSet<Employee> Employees { get; set; }
}