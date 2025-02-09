using Hemen.Infrastructure.Result;
using MediatR;

namespace Hemen.Identity.API.Application.Features.User.RegisterUserCommand;

public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, BaseApiResult<RegisterCommandResponse>> {
    public Task<BaseApiResult<RegisterCommandResponse>> Handle(RegisterCommandRequest request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}
