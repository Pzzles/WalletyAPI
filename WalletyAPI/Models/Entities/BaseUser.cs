using WalletyAPI.Utils.Enums;

namespace WalletyAPI.Models.Entities
{
    public class BaseUser
    {
        public required Guid UserId { get; set; }
        public RoleEnum Role { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string PasswordHash { get; set; }
        public required string PasswordSalt { get; set; }
        public string? ProfilePictureUrl { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedDate { get; set; }

    }
}
