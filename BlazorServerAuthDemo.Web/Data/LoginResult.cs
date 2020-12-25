namespace BlazorServerAuthDemo.Web.Data
{
    public record LoginResult(bool Success);

    public record LoginViewModel(string Email, string Password);
}