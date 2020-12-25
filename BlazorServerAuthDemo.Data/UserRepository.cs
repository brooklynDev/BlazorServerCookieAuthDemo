using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerAuthDemo.Data
{
    public class UserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task AddUser(User user)
        {
            await using var context = new AuthDemoDataContext(_connectionString);
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }
        
        public async Task<User> GetByEmail(string email)
        {
            await using var context = new AuthDemoDataContext(_connectionString);
            return await context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}