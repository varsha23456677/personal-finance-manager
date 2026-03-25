//namespace PersonalFinanceAPI.Data
//{
//    public class AppDbContext
//    {
//    }
//}
using Microsoft.EntityFrameworkCore;
using PersonalFinanceAPI.Models;

namespace PersonalFinanceAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Each DbSet = one table in SQL Server
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Saving> Savings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ensure Amount columns use decimal precision
            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Budget>()
                .Property(b => b.MonthlyLimit)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Saving>()
                .Property(s => s.TargetAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Saving>()
                .Property(s => s.CurrentAmount)
                .HasColumnType("decimal(18,2)");
        }
    }
}