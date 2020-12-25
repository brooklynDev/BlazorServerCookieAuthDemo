using Microsoft.EntityFrameworkCore;

namespace BlazorServerAuthDemo.Data
{
    public class AuthDemoDataContext : DbContext
    {
        private readonly string _connectionString;

        public AuthDemoDataContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<User> Users { get; set; }
    }
}