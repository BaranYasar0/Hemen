using Hemen.Infrastructure.Entities;

namespace Hemen.Identity.API.Entities;

public class User : BaseEntity<Guid> {
    public string Email { get; set; }

    public User() {
        PasswordHash = Array.Empty<byte>();
        PasswordSalt = Array.Empty<byte>();
    }
    public User(Guid id) : base(id) {
        PasswordHash = Array.Empty<byte>();
        PasswordSalt = Array.Empty<byte>();
    }

    public User(string email, byte[] passwordSalt, byte[] passwordHash) {
        Email = email;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
    }

    public User(Guid id, string email, byte[] passwordSalt, byte[] passwordHash) : base(id) {
        Email = email;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
    }

    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }



}
