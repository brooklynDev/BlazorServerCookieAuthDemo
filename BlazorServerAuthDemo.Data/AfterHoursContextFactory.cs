using System.IO;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BlazorServerAuthDemo.Data
{
    public class AfterHoursContextFactory : IDesignTimeDbContextFactory<AuthDemoDataContext>
    {
        public AuthDemoDataContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), $"..{Path.DirectorySeparatorChar}BlazorServerAuthDemo.Web"))
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json", true, true)
                .AddJsonFile("appsettings.local.json", true, true).Build();

            return new AuthDemoDataContext(config.GetConnectionString("DefaultConnection"));
        }
    }
}