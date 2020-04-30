using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Db
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quote>()
                 .HasKey(rel => rel.Id);
            modelBuilder.Entity<User>()
                .HasKey(rel => rel.Id);
        }

        public DbSet<Quote> Quotes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
