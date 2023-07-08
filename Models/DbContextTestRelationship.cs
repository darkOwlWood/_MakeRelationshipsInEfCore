using Microsoft.EntityFrameworkCore;
namespace TestRelationship.Models;

public class DbContextTestRelationship : DbContext
{
    public DbSet<UserModel> Users { get; init; }
    public DbSet<MessageModel> Messages { get; init; }
    public DbContextTestRelationship(DbContextOptions<DbContextTestRelationship> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        new UserModelConfiguration().Configure(builder.Entity<UserModel>());
        new MessageModelConfiguration().Configure(builder.Entity<MessageModel>());
    }
}