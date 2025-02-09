using Hemen.Identity.API.Entities;

namespace Hemen.Identity.API.Application.JWT;

public interface ITokenHelper {
    public AccessToken CreateToken(User user, IList<OperationClaim> operationClaims);
    public RefreshToken CreateRefreshToken(User user, string ipAddress = "");
}
