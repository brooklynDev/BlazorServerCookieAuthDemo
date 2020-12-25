using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BlazorServerAuthDemo.Web.Data;
using BlazorServerAuthDemo.Web.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServerAuthDemo.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly LoginService _loginService;
        private readonly HttpContextAccessor _contextAccessor;

        public AuthController(LoginService loginService, HttpContextAccessor contextAccessor)
        {
            _loginService = loginService;
            _contextAccessor = contextAccessor;
        }

        [HttpPost]
        [Route("login")]
        public async Task<LoginResult> Login(LoginViewModel viewModel)
        {
            var (email, password) = viewModel;
            var user = await _loginService.Login(email, password);
            if (user is null)
            {
                return new LoginResult(false);
            }
            
            var claims = new List<Claim>
            {
                new("user", email)
            };
            
            await _contextAccessor.HttpContext.SignInAsync(new ClaimsPrincipal(
                new ClaimsIdentity(claims, "Cookies", "user", "role")));
            return new LoginResult(true);
        }

        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _contextAccessor.HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}