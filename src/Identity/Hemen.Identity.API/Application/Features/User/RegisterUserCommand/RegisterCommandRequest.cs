namespace Hemen.Identity.API.Application.Features.User.RegisterUserCommand {
    public class RegisterCommandRequest : IBaseApiRequest<RegisterCommandResponse> {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
