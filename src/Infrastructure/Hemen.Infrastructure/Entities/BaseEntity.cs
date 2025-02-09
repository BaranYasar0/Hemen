namespace Hemen.Infrastructure.Entities;
public class BaseEntity<TId> {

    public TId Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? EntityStatus { get; set; }

    public BaseEntity() {
        Id = default!;
    }
    public BaseEntity(TId id) {
        Id = id;
    }
}
