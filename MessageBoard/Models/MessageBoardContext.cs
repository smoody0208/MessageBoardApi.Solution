using Microsoft.EntityFrameworkCore;

namespace MessageBoard.Models
{
  public class MessageBoardContext : DbContext
  {
    public MessageBoardContext(DbContextOptions<MessageBoardContext> options) : base(options)
    {
    }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Board> Boards { get; set; }
    public DbSet<User> Users { get; set; } 

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<User>()
      .HasData(
        new User { Id = 1, FirstName = "Admin", LastName = "User", Username = "admin", Password = "admin", Role = Role.Admin },
        new User { Id = 2, FirstName = "Normal", LastName = "User", Username = "user", Password = "user", Role = Role.User } 
      );

      builder.Entity<Board>().HasData(
        new Board { BoardId = 1, Name = "Programming", Description = "General discussions about computer programming i.e., best prectices, tips-and-trick, etc..."},
        new Board { BoardId = 2, Name = "Pets", Description = "A place where we can share cute things our pets have done"},
        new Board { BoardId = 3, Name = "Diet/Nutrition", Description = "Trading nutrition tips, recipes, and support"},
        new Board { BoardId = 4, Name = "Video Games", Description = "A friendly chat about what video games we are playing these days"},
        new Board { BoardId = 5, Name = "Eats!", Description = "Best places to eat around Portland"}
      );
    }
  }
}