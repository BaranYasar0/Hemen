using Hemen.Infrastructure.Entities;

namespace Hemen.Identity.API.Entities;

public class OperationClaim : BaseEntity<int> {
    public string Name { get; set; }
    public OperationClaim(int id) : base(id) {
    }
    public OperationClaim(string name) {
        Name = name;
    }
    public OperationClaim(int id, string name) : base(id) {
        Name = name;
    }
}
