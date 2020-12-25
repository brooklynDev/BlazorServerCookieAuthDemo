using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BlazorServerAuthDemo.Web.Data;
using BlazorServerAuthDemo.Web.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;

namespace BlazorServerAuthDemo.Web.Pages
{
    public partial class Login
    {
        [Inject]
        public IJSRuntime JsRuntime { get; set; }
        
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        
        private IJSObjectReference _module;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                return;
            }
            _module = await JsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./js/login.js");
        }

        public string Email { get; set; }
        public string Password { get; set; }

        public bool ShowErrorMessage { get; set; }

        public async Task OnLoginClick()
        {
            var result = await _module.InvokeAsync<LoginResult>("login", Email, Password);
            if (result.Success)
            {
                NavigationManager.NavigateTo("/secret", true);
            }
            else
            {
                ShowErrorMessage = true;
            }
        }
    }
}