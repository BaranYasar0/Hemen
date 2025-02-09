using Hemen.Infrastructure.Entities;

namespace Hemen.Identity.API.Entities;

public class UserOperationClaim : BaseEntity<int> {
    public Guid UserId { get; set; }
    public int OperationClaimId { get; set; }
    public UserOperationClaim(int id) : base(id) {
    }
    public UserOperationClaim(Guid userId, int operationClaimId) {
        UserId = userId;
        OperationClaimId = operationClaimId;
    }
    public UserOperationClaim(int id, Guid userId, int operationClaimId) : base(id) {
        UserId = userId;
        OperationClaimId = operationClaimId;
    }
}
