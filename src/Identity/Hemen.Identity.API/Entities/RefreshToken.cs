using Hemen.Infrastructure.Entities;

namespace Hemen.Identity.API.Entities;

public class RefreshToken : BaseEntity<Guid> {
    public Guid UserId { get; set; }
    public string Token { get; set; } = default!;
    public DateTime ExpiredDate { get; set; }
    public bool IsExpired => DateTime.UtcNow >= ExpiredDate;
    public DateTime CreatedDate { get; set; }
    public string CreatedByIp { get; set; }
    public DateTime? RevokedDate { get; set; }
    public string? RevokedByIp { get; set; }
    public string? ReplacedByToken { get; set; }
    public bool IsActive => RevokedDate == null && !IsExpired;


}
