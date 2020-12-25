using System.Threading.Tasks;
using BlazorServerAuthDemo.Data;
using Microsoft.Extensions.Configuration;

namespace BlazorServerAuthDemo.Web.Services
{
    public class LoginService
    {
        private readonly UserRepository _userRepository;
        
        public LoginService(IConfiguration configuration)
        {
            _userRepository = new UserRepository(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<bool> Signup(string email, string firstName, string lastName, string password)
        {
            if (await _userRepository.GetByEmail(email) != null)
            {
                return false;
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PasswordHash = passwordHash
            };
            await _userRepository.AddUser(user);
            return true;
        }

        public async Task<User> Login(string email, string password)
        {
            var user = await _userRepository.GetByEmail(email);
            if (user == null)
            {
                return null;
            }

            return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash) ? user : null;
        }

        public Task<User> GetUser(string email)
        {
            return _userRepository.GetByEmail(email);
        }
    }
}