namespace Hemen.Identity.API.Application.Features.User.RegisterUserCommand;

public class RegisterCommandResponse {
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public string[] Errors { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
}
