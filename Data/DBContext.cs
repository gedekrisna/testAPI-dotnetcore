using test.Models;  
using Microsoft.EntityFrameworkCore; 

namespace test.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("employee"); 
        }
    }
}