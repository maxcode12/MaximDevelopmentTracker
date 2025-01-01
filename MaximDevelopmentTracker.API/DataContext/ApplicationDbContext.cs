using MaximDevelopmentTracker.API.Models;
using Microsoft.EntityFrameworkCore;

namespace MaximDevelopmentTracker.API.DataContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Goal> Goals { get; set; }
    public DbSet<ProgressLog> ProgressLogs { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the relationships and other customizations here
        // Example: One-to-many relationship between User and Goal
        modelBuilder.Entity<User>()
            .HasMany(u => u.Goals)
            .WithOne(g => g.User)
            .HasForeignKey(g => g.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Example: One-to-many relationship between Goal and ProgressLog
        modelBuilder.Entity<Goal>()
            .HasMany(g => g.ProgressLogs)
            .WithOne(pl => pl.Goal)
            .HasForeignKey(pl => pl.GoalId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}
