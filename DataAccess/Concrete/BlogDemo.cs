using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete;

public class BlogDemo : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=myDataBase;User Id=postgres;Password=enes35;");
    }
}