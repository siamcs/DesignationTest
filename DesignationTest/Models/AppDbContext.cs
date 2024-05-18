using Microsoft.EntityFrameworkCore;

namespace DesignationTest.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

       
        public DbSet<Designation> Designations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DesignationDB;Trusted_Connection=True;");
        }

    }
}
