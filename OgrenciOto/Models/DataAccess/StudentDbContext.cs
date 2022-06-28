using Microsoft.EntityFrameworkCore;
using OgrenciOto.Models.Entity;

namespace OgrenciOto.Models.DataAccess
{
    public class StudentDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=StudentDb; Trusted_Connection= True");
        }
        public DbSet<Student> Students { get; set; }
    }
}
