using Microsoft.EntityFrameworkCore;
using UserTest_01.Model;

namespace UserTest_01.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
 : base(options)
        {
        } 

        public DbSet<Register>Registers { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestResult> TestResults { get; set; }

    }
}
