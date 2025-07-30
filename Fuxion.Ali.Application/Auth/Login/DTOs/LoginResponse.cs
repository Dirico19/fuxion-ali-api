namespace Fuxion.Ali.Application.Auth.Login.DTOs
{
    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;

        public LoginResponse(string token)
        {
            Token = token;
        }
    }
}
