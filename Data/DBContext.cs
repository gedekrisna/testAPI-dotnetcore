using test.Models;  
using Microsoft.EntityFrameworkCore; 

namespace test.Data
{
    public class MyDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("employee"); 
        }
    }
}