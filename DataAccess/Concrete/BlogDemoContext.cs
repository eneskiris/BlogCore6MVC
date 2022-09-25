using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete;

public class BlogDemoContext : IdentityDbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost;Database=BlogDemo;User=sa;Password=Enes35.*;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<MessageWithWriter>()
               .HasOne(x => x.SenderUser)
               .WithMany(y => y.WriterSender)
               .HasForeignKey(z => z.SenderId)
               .OnDelete(DeleteBehavior.ClientSetNull);

        builder.Entity<MessageWithWriter>()
               .HasOne(x => x.ReceiverUser)
               .WithMany(y => y.WriterReceiver)
               .HasForeignKey(z => z.ReceiverId)
               .OnDelete(DeleteBehavior.ClientSetNull);
        base.OnModelCreating(builder);
    }

    public DbSet<About> Abouts { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Writer> Writers { get; set; }
    public DbSet<NewsLetter> NewsLetters { get; set; }
    public DbSet<BlogRating> BlogRatings { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<MessageWithWriter> MessageWithWriters { get; set; }
    public DbSet<Admin> Admins { get; set; }
}