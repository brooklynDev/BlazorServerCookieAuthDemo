using System.Threading.Tasks;
using BlazorServerAuthDemo.Web.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorServerAuthDemo.Web.Pages
{
    public partial class Signup
    {
        [Inject]
        public LoginService LoginService { get; set; }
        
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public async Task OnSignupClick()
        {
            await LoginService.Signup(Email, FirstName, LastName, Password);
            NavigationManager.NavigateTo("/login");
        }
        
    }
}