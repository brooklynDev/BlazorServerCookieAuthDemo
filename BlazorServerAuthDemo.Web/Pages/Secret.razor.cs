using System.Threading.Tasks;
using BlazorServerAuthDemo.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace BlazorServerAuthDemo.Web.Pages
{
    [Authorize]
    public partial class Secret
    {
        [CascadingParameter] 
        public Task<User> CurrentUserTask { get; set; }
    
        string _userFullName;
        protected override async Task OnInitializedAsync()
        {
            var user = await CurrentUserTask;
            _userFullName = $"{user.FirstName} {user.LastName}";
        }
    }
}