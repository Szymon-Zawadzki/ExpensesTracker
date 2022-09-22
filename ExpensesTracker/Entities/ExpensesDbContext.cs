using Microsoft.EntityFrameworkCore;

namespace ExpensesTracker.Entities
{
    public class ExpensesDbContext : DbContext
    {
        private string _connectionString =
            "Server = (localdb)\\mssqllocaldb; Database = ExpensesDb; Trusted_Connection = True;";

        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<IncomingExpenses> IncomingExpenses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expenses>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<IncomingExpenses>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
    
}
