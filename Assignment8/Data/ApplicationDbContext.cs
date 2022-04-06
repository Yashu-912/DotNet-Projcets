using Microsoft.EntityFrameworkCore;
using Assignment8.Models;


namespace Assignment8 {

    public class ApplicationDbContext : DbContext {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

        }

        public DbSet<Student>? Student {get; set;}

        public DbSet<Teacher>? Teacher {get; set;}

        
    }
}